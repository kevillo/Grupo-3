using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Clinica_Medica_Polanco.Pacientes
{
    public class Pacient
    {
        private int _codigo;
        private String _nombre;
        private String _apellido;
        private String _identidad;
        private String _telefono;
        private DateTime _fechaNacimiento;
        private String _correo;
        private decimal _altura;
        private String _tipoSangre;
        private String _direccion;
        private bool _estado;


        // validacion string: que no venga vacio
        // validacion int: que no sea negativo ni que venga vacio
        // validacion para strings que ocupan un numero: que no este vacio y que solo se ingrese un numero
        public Pacient() { }    
        public Pacient(int pCodigo, String pNombre, String pApellido, String pIdentidad, String pTelefono, DateTime pFechaNacimiento, String pCorreo, int pAltura, String pTipoSangre, String pDireccion, bool pEstado)
        {
            this._codigo = pCodigo;
            this._nombre = pNombre;
            this._apellido = pApellido;
            this._identidad = pIdentidad;
            this._telefono= pTelefono;
            this._fechaNacimiento= pFechaNacimiento;
            this._correo= pCorreo;
            this._altura = pAltura;
            this._tipoSangre= pTipoSangre;
            this._direccion= pDireccion;
            this._estado= pEstado;
        }

        public int Codigo
        {
            get => _codigo;
            set
            {
                if (value <= 0) _codigo = 1;
                else _codigo = value;
            }
        }
        public string Nombre
        {
            get => _nombre;
            set
            {
                // valida si la cadena esta vacia o si tiene una longitud menor a 2
                if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 51)
                {
                    throw new FormatException("Procure no dejar el Nombre con un formato incorrecto o vacío.");
                }
                else _nombre = value;
            }
        }
        public string Apellido
        {
            get => _apellido;
            set
            {
                // valida si la cadena esta vacia o si tiene una longitud menor a 2
                if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 51)
                {

                    throw new FormatException("Procure no dejar el Apellido con un formato incorrecto o vacío.");
                }
                else _apellido = value;
            }
        }
        public string Identidad
        {
            get => _identidad;
            set
            {
                // valida si la cadena no esta vacia, si es un numero, y si tiene exactamente 13 caracteres
                if (string.IsNullOrEmpty(value) || !Int64.TryParse(value, out long _) || value.Length != 13)
                {
                    throw new FormatException("Procure no dejar la Identidad con un formato incorrecto o vacío.");
                }
                else _identidad = value;
            }
        }
        public string Telefono
        {
            get => _telefono;
            set
            {
                // valida si la cadena no esta vacia, si es un numero, y si tiene exactamente 8 caracteres
                if (string.IsNullOrEmpty(value)|| !Int64.TryParse(value,out long _) || validarTelefono(value) == false || value.Length!=8)
                {
                    throw new FormatException("Procure no dejar el Teléfono con un formato incorrecto o vacío.");
                }
                else _telefono = value;
            }
        }
        public DateTime FechaNacimiento 
        { 
            get => _fechaNacimiento;
            set
            {
                // valida si la fecha no es la fecha de hoy y si la fecha no es mayor a la fecha de hoy: 
                // por ejemplo, no se puede poner una fecha como  15/04/2022 por que es mayor a la de hoy
                if (value.ToShortDateString() == DateTime.Now.ToShortDateString() || value > DateTime.Now)
                {
                    throw new FormatException();
                }
                else _fechaNacimiento = value;
            }
            
                
        }
        public string Correo
        {
            get => _correo;
            set
            {
                // valida si el email es verdadero ( aqui se pone falso por que asi entrara en el catch de ser falso)
                if (validarEmail(value) == false)
                {
                    throw new FormatException("Procure no dejar el Correo con un formato incorrecto o vacío.");
                }
                else _correo = value;
            }
        }
        public decimal Altura
        {
            get => _altura;
            set
            {
                //valida si la altura es positiva y si es un deciamal
                if (value <= 0 || !decimal.TryParse(value.ToString(), out decimal _) || value.ToString().Length < 1 || value.ToString().Length > 3)
                {
                    throw new FormatException("Procure no dejar la Altura con un formato incorrecto o vacío.");
                }
                else _altura = value;
            }
        }
        public string TipoSangre
        {
            get => _tipoSangre;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _tipoSangre = value;
            }
            
        }
        public string Direccion
        {
            get => _direccion;
            set
            {
                if (string.IsNullOrEmpty(value) || (value.Length < 10 || value.Length > 255))
                {
                    throw new FormatException();
                }
                else _direccion = value;
            }
        }
        public bool Estado { get => _estado; set => _estado = value; }


        // valida si el correo tiene un @, si hay algo antes y despues del @ y si tiene un .com o algo asi
        public static bool validarEmail(string comprobarEmail)
        {
            string emailFormato;
            emailFormato = "\\w+([-+.']\\w+)*@\\w+([-+.']\\w+)*\\.\\w+([-+.']\\w+)*";
            if (Regex.IsMatch(comprobarEmail, emailFormato))
            {
                if (Regex.Replace(comprobarEmail, emailFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //valida si el telefono empieza en 9 8 3 2 
        public static bool validarTelefono(string telefono)
        {
            if (telefono.StartsWith("9") || telefono.StartsWith("8") || telefono.StartsWith("3") || telefono.StartsWith("2"))
            {
                return true;
            }
            else
            {
                System.Windows.MessageBox.Show("El número de telefóno debe comenzar por 2, 3, 8 o 9");
                return false;
            }
        }
    }
}
