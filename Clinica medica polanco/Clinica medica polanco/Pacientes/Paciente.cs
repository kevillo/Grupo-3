using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_medica_polanco.Pacientes
{
    public class Paciente
    {
        private int _codigo;
        private String _nombre;
        private String _apellido;
        private String _identidad;
        private String _telefono;
        private DateTime _fechaNacimiento;
        private String _correo;
        private int _altura;
        private String _tipoSangre;
        private String _direccion;
        private bool _estado;

        public Paciente() { }    
        public Paciente(int pCodigo, String pNombre, String pApellido, String pIdentidad, String pTelefono, DateTime pFechaNacimiento, String pCorreo, int pAltura, String pTipoSangre, String pDireccion, bool pEstado)
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
                if (string.IsNullOrEmpty(value)) _nombre = "Error";
                else _nombre = value;
            }
        }
        public string Apellido
        {
            get => _apellido;
            set
            {
                if (string.IsNullOrEmpty(value)) _apellido = "Error";
                else _apellido = value;
            }
        }
        public string Identidad
        {
            get => _identidad;
            set
            {
                if (string.IsNullOrEmpty(value)) _identidad = "Error";
                else _identidad = value;
            }
        }
        public string Telefono
        {
            get => _telefono;
            set
            {
                if (string.IsNullOrEmpty(value)) _telefono = "Error";
                else _telefono = value;
            }
        }
        public DateTime FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public string Correo
        {
            get => _correo;
            set
            {
                if (string.IsNullOrEmpty(value)) _correo = "Error";
                else _correo = value;
            }
        }
        public int Altura
        {
            get => _altura;
            set
            {
                if (value <= 0) _altura = 1;
                else _altura = value;
            }
        }
        public string TipoSangre
        {
            get => _tipoSangre;
            set
            {
                if (string.IsNullOrEmpty(value)) _tipoSangre = "Error";
                else _tipoSangre = value;
            }
        }
        public string Direccion
        {
            get => _direccion;
            set
            {
                if (string.IsNullOrEmpty(value)) _direccion = "Error";
                else _direccion = value;
            }
        }
        public bool Estado { get => _estado; set => _estado = value; }
    }
}
