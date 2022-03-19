using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.servicios
{
    public class serviciosEntrega
    {

        private int _codFacturaVenta;
        private int _codExamenMedico;
        private string _nombreExamen;
        private int _codFacturador;
        private string _nombreEmpleado;
        private int _codMicrobiologo;
        private int _codEnfermero;
        private int _codPaciente;
        private string _nombrePaciente;
        private int _metodoEntregaExamen;
        private string _nombreMetodoEntrega;
        private int _metodoPagoExamen;
        private string _nombreMetodoPago;
        private int _estadoExamenMedico;
        private bool _examenCombo;
        private DateTime _fechaOrden;
     
        
        

        public string NombreExamen
        {
            get => _nombreExamen;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _nombreExamen = value;
            }
        }
        public string NombrePaciente
        {
            get => _nombrePaciente;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _nombrePaciente = value;
            }
        }
        public string NombreMetodoEntrega
        {
            get => _nombreMetodoEntrega;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _nombreMetodoEntrega = value;
            }
        }
        public string NombreMetodoPago
        {
            get => _nombreMetodoPago;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _nombreMetodoPago = value;
            }
        }

        public string NombreEmpleado { get => _nombreEmpleado; set => _nombreEmpleado = value; }

        // validacion string: que no venga vacio
        // validacion int: que no sea negativo ni que venga vacio
        // validacion para strings que ocupan un numero: que no este vacio y que solo se ingrese un numero
        public int CodigoExamenMedico
        {
            get => _codExamenMedico;
            set
            {
                if (value < 0) throw new FormatException();
                else _codExamenMedico = value;
            }
        }

        public int CodigoFacturador
        {
            get => _codFacturador;
            set
            {
                if (value <= 0) throw new FormatException();
                else _codFacturador = value;
            }
        }

        public int CodigoMicrobiologo
        {
            get => _codMicrobiologo;
            set
            {
                if (value < 0) throw new FormatException();
                else _codMicrobiologo = value;
            }
        }

        public int CodigoEnfermero
        {
            get => _codEnfermero;
            set
            {
                if (value < 0) throw new FormatException();
                else _codEnfermero = value;
            }
        }

        public int CodigoPaciente
        {
            get => _codPaciente;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value < 0) throw new FormatException();
                else _codPaciente = value;
            }
        }


        public int MetodoEntregaExamen
        {
            get => _metodoEntregaExamen;
            set
            {
                if (value < 0) throw new FormatException();
                else _metodoEntregaExamen = value;
            }
        }

        public int MetodoPagoExamen
        {
            get => _metodoPagoExamen;
            set
            {
                if (value < 0) throw new FormatException();
                else _metodoPagoExamen = value;
            }
        }

   /*     public int Cantidad
        {
            get => _cantidad;
            set
            {
                if (value < 0) throw new FormatException();
                else _cantidad = value;
            }
        }
   */
        public int EstadoExamenMedico
        {
            get => _estadoExamenMedico;
            set
            {
                if (value < 0) throw new FormatException();
                else _estadoExamenMedico = value;
            }
        }
        public DateTime FechaOrden { get => _fechaOrden; set => _fechaOrden = value; }

        public bool ExamenCombo { get => _examenCombo; set => _examenCombo = value; }
        public int CodFacturaVenta { get => _codFacturaVenta; set => _codFacturaVenta = value; }
    }
}
