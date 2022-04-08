using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.servicios
{
    public class serviciosEntrega
    {
        //Estableciendo datos
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
     
        
        
        //Validación de datos
        public string NombreExamen
        {
            get => _nombreExamen;
            set
            {
                //Valida si la cadena no está vacía
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
                //Valida si la cadena no está vacía
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
                //Valida si la cadena no está vacía
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
                //Valida si la cadena no está vacía
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _nombreMetodoPago = value;
            }
        }

        public string NombreEmpleado { get => _nombreEmpleado; set => _nombreEmpleado = value; }

        // validación string: que no venga vacío
        // validación int: que no sea negativo ni que venga vacío
        // validación para strings que ocupan un número: que no este vacío y que solo se ingrese un número

        public int CodigoExamenMedico
        {
            get => _codExamenMedico;
            set
            {
                //Valida si la cadena no está vacía
                if (value < 0) throw new FormatException();
                else _codExamenMedico = value;
            }
        }

        public int CodigoFacturador
        {
            get => _codFacturador;
            set
            {
                //Valida si la cadena no está vacía
                if (value <= 0) throw new FormatException();
                else _codFacturador = value;
            }
        }

        public int CodigoMicrobiologo
        {
            get => _codMicrobiologo;
            set
            {
                //Valida si la cadena no está vacía
                if (value < 0) throw new FormatException();
                else _codMicrobiologo = value;
            }
        }

        public int CodigoEnfermero
        {
            get => _codEnfermero;
            set
            {
                //Valida si la cadena no está vacía
                if (value < 0) throw new FormatException();
                else _codEnfermero = value;
            }
        }

        public int CodigoPaciente
        {
            get => _codPaciente;
            set
            {
                //Valida si la cadena no está vacía
                if (string.IsNullOrEmpty(value.ToString()) || value < 0) throw new FormatException();
                else _codPaciente = value;
            }
        }


        public int MetodoEntregaExamen
        {
            get => _metodoEntregaExamen;
            set
            {
                //Valida si la cadena tiene una longitud menor a 0
                if (value < 0) throw new FormatException();
                else _metodoEntregaExamen = value;
            }
        }

        public int MetodoPagoExamen
        {
            get => _metodoPagoExamen;
            set
            {
                //Valida si la cadena tiene una longitud menor a 0
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
                //Valida si la cadena tiene una longitud menor a 0
                if (value < 0) throw new FormatException();
                else _estadoExamenMedico = value;
            }
        }
        public DateTime FechaOrden { get => _fechaOrden; set => _fechaOrden = value; }

        public bool ExamenCombo { get => _examenCombo; set => _examenCombo = value; }
        public int CodFacturaVenta { get => _codFacturaVenta; set => _codFacturaVenta = value; }
    }
}
