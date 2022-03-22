using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clinica_Medica_Polanco.Empleados
{
    public class Empleados
    {
        private int _codigoEmpleado;
        private int _codigoJornada;
        private int _codigoPuesto;
        private int _idUsuario;
        private string _nombreEmpleado;
        private string _apellidoEmpleado;
        private string _identidadEmpleado;
        private string _telefonoEmpleado;
        private DateTime _fechaNacimientoEmpleado;
        private string _correoEmpleado;
        private decimal _alturaEmpleado;
        private string _tipoSangreEmpleado;
        private string _direccionEmpleado;
        private int _codigoSucursal;
        private DateTime _fechaPago;
        private DateTime _fechaContratacion;
        private decimal _sueldoBase;
        private bool _estadoEmpleado;
        private string _cargoEmpleado;
        private string _jornadaEmpleado;
        // validacion string: que no venga vacio
        // validacion int: que no sea negativo ni que venga vacio
        // validacion para strings que ocupan un numero: que no este vacio y que solo se ingrese un numero


        
        public int CodigoJornada 
        { 
            get => _codigoJornada;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value <= 0)
                {
                    throw new FormatException();
                }
                else _codigoJornada = value;
            }
                
        }
        public int CodigoPuesto 
        { 
            get => _codigoPuesto;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value <= 0)
                {
                    throw new FormatException();
                }
                else _codigoPuesto = value;
            }
        }
        public int IdUsuario 
        { 
            get => _idUsuario;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value <= 0)
                {
                    throw new FormatException();
                }
                else _idUsuario = value;
            }
        }
        public string NombreEmpleado 
        { 
            get => _nombreEmpleado;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _nombreEmpleado = value;
            }
        }
        public string ApellidoEmpleado 
        { 
            get => _apellidoEmpleado;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _apellidoEmpleado = value;
            }
        }
        public string IdentidadEmpleado 
        { 
            get => _identidadEmpleado;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || !Int64.TryParse(value, out long _) )
                {
                    throw new FormatException();
                }
                else _identidadEmpleado = value;
            }
        }


        public string TelefonoEmpleado 
        { 
            get => _telefonoEmpleado;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _telefonoEmpleado = value;
            }

        }
        public DateTime FechaNacimientoEmpleado 
        { 
            get => _fechaNacimientoEmpleado;
            set
            {
                if (value.ToShortDateString()==DateTime.Now.ToShortDateString())
                {
                    throw new FormatException();
                }
                else _fechaNacimientoEmpleado = value;
            }
        }
        public string CorreoEmpleado 
        { 
            get => _correoEmpleado;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _correoEmpleado = value;
            }


        }
        public decimal AlturaEmpleado 
        { 
            get => _alturaEmpleado;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value <= 0)
                {
                    throw new FormatException();
                }
                else _alturaEmpleado = value;
            }

        }
        public string TipoSangreEmpleado 
        { 
            get => _tipoSangreEmpleado;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _tipoSangreEmpleado = value;
            }
        }
        public string DireccionEmpleado 
        { 
          get => _direccionEmpleado;
          set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new FormatException();
                }
                else _direccionEmpleado = value;
            }
        }
        public int CodigoSucursal 
        { 
            get => _codigoSucursal;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value < 0)
                {
                    throw new FormatException();
                }
                else _codigoSucursal = value;
            }
        }

        public DateTime FechaPago 
        { 
            get => _fechaPago; 
            set
            {
                if (value.ToShortDateString() == "1/1/1999") throw new FormatException();  
                else _fechaPago = value;
            }
         }
        public DateTime FechaContratacion
        {
            get => _fechaContratacion;
            set
            {
                if (value.ToShortDateString() == "1/1/1999") throw new FormatException();
                else _fechaContratacion = value;
            }
        }
        public decimal SueldoBase 
        { 
            get => _sueldoBase; 
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value < 0)
                {
                    throw new FormatException();
                }
                else _sueldoBase = value;
            }
        }

        public int CodigoEmpleado 
        { 
            get => _codigoEmpleado; 
            set
            {
                if (string.IsNullOrEmpty(value.ToString())) throw new FormatException();
                else _codigoEmpleado = value;
            }
        }

        public bool EstadoEmpleado { get => _estadoEmpleado; set => _estadoEmpleado = value; }
        public string CargoEmpleado
        {
            get => _cargoEmpleado;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _cargoEmpleado = value;
            }
        }

        public string JornadaEmpleado
        {
            get => _jornadaEmpleado;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _jornadaEmpleado = value;
            }
        }
    }
}