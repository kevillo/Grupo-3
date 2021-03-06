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
        //Estableciendo datos
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


        // validación string: que no venga vacío
        // validación int: que no sea negativo ni que venga vacío
        // validación para strings que ocupan un número: que no este vacío y que solo se ingrese un número

        //Validación de datos
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
                //Valida si la cadena no está vacía o si tiene una longitud menor a 2
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
                //Valida si la cadena no está vacía o si tiene una longitud menor a 2
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
                //Valida si la cadena no está vacía, si es un número, y si tiene exactamente 13 caracteres
                if (string.IsNullOrEmpty(value) || !Int64.TryParse(value, out long _) || value.Length != 13 || !IdentidadNoGenerica(value))
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
                //Valida si la cadena no está vacía, si es un número, y si tiene exactamente 8 caracteres
                if (string.IsNullOrEmpty(value)|| !Int64.TryParse(value,out long _) || validarTelefono(value) == false || value.Length!=8 || !NumeroNoGenerico(value))
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
                //Valida si la fecha no es la fecha de hoy y si la fecha no es mayor a la fecha de hoy: 
                //Por ejemplo, no se puede poner una fecha como  15/04/2022 por que es mayor a la de hoy
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
                //Valida si el email es verdadero (aquí se pone falso porque así entrará en el catch de ser falso)
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
                //Valida si la altura es positiva y si es un deciamal
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
                //Valida si la cadena no está vacía
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
                //Valida si la cadena no está vacía y si tiene una longitud menor a 10 y una mayor a 255
                if (string.IsNullOrEmpty(value) || (value.Length < 10 || value.Length > 255))
                {
                    throw new FormatException();
                }
                else _direccion = value;
            }
        }
        public bool Estado { get => _estado; set => _estado = value; }


        //Valida si el correo tiene un @, si hay algo antes y después del @ y si tiene un .com o algo así
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

        //Valida si el teléfono empieza en 9, 8, 3, 2 
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


        private bool IdentidadNoGenerica(string identidad)
        {
            Dictionary<char, int> contadorOcurrencias = new Dictionary<char, int>();
            int max = -1;

            foreach (char c in identidad)
            {
                if (contadorOcurrencias.TryGetValue(c, out int _))
                {
                    contadorOcurrencias[c] += 1;
                }
                else contadorOcurrencias.Add(c, 1);
            }

            foreach (char c in contadorOcurrencias.Keys)
            {
                if (contadorOcurrencias[c] > max) max = contadorOcurrencias[c];
            }
            if (max > 9) return false;
            return true;

        }
        private bool NumeroNoGenerico(string telefono)
        {
            Dictionary<char, int> contadorOcurrencias = new Dictionary<char, int>();
            int max = -1;

            foreach (char c in telefono)
            {
                if (contadorOcurrencias.TryGetValue(c, out int _))
                {
                    contadorOcurrencias[c] += 1;
                }
                else contadorOcurrencias.Add(c, 1);
            }

            foreach (char c in contadorOcurrencias.Keys)
            {
                if (contadorOcurrencias[c] > max) max = contadorOcurrencias[c];
            }
            if (max == 8) return false;
            return true;
        }
    }
}
