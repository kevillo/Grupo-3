using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new FormatException("No se puede ingresar campos vacíos en  nombre");
                }
                else _nombre = value;
            }
        }
        public string Apellido
        {
            get => _apellido;
            set
            {
                if (string.IsNullOrEmpty(value))
                {

                    throw new FormatException("No se puede ingresar campos vacíos en apellido");
                }
                else _apellido = value;
            }
        }
        public string Identidad
        {
            get => _identidad;
            set
            {
                if (string.IsNullOrEmpty(value) || !Int64.TryParse(value, out long _))
                {
                    throw new FormatException("No se puede ingresar campos vacíos en identidad");
                }
                else _identidad = value;
            }
        }
        public string Telefono
        {
            get => _telefono;
            set
            {
                if (string.IsNullOrEmpty(value)|| !Int64.TryParse(value,out long _))
                {
                    throw new FormatException("No se puede ingresar campos vacíos en telefono");
                }
                else _telefono = value;
            }
        }
        public DateTime FechaNacimiento 
        { 
            get => _fechaNacimiento;
            set
            {
                if (value.ToShortDateString() == DateTime.Now.ToShortDateString())
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new FormatException("No se puede ingresar campos vacíos en correo");
                }
                else _correo = value;
            }
        }
        public decimal Altura
        {
            get => _altura;
            set
            {
                if (value <= 0)
                {
                    throw new FormatException("No se pueden ingresar campos vacíos en altura");
                }
                else _altura = value;
            }
        }
        public string TipoSangre
        {
            get => _tipoSangre;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new FormatException("No se pueden ingresar campos vacíos en tipo sangre");
                }
                else _tipoSangre = value;
            }
            
        }
        public string Direccion
        {
            get => _direccion;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new FormatException("No se puede ingresar campos vacíos en direccion");
                }
                else _direccion = value;
            }
        }
        public bool Estado { get => _estado; set => _estado = value; }
    }
}
