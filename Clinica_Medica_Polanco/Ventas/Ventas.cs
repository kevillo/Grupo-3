using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Ventas
{
     public class Ventas
    {
        //Estableciendo datos
        private int _codFacturaVenta;
        private int _codExamenMedico;
        private int _codFacturador;
        private int _codMicrobiologo;
        private int _codEnfermero;
        private int _codPaciente;
        private int _metodoEntregaExamen;
        private int _metodoPagoExamen;
        private DateTime _fechaOrden;
        private bool _examenCombo;
        private int _cantidad;
        private int _estadoExamenMedico;

        // validación string: que no venga vacío
        // validación int: que no sea negativo ni que venga vacío
        // validación para strings que ocupan un número: que no este vacío y que solo se ingrese un número

        //Validación de datos
        public int CodigoExamenMedico
        {
            get => _codExamenMedico;
            set
            {
                if (value <= 0 ) throw new FormatException();
                else _codExamenMedico= value;
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
                if (value < 0) throw new FormatException();
                else _metodoEntregaExamen = value;
            }
        }

        public int MetodoPagoExamen
        {
            get => _metodoPagoExamen;
            set
            {
                if (value <= 0) throw new FormatException();
                else _metodoPagoExamen = value;
            }
        }

        public int Cantidad
        {
            get => _cantidad;
            set
            {
                if (value<0) throw new FormatException();
                else _cantidad = value;
            }
        }

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