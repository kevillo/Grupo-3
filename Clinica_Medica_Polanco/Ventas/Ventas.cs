using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_medica_polanco.Ventas
{
     public class Ventas
    {
        private int _codFacturaVenta;
        private int[] _codExamenMedico;
        private int _codFacturador;
        private int _codMicrobiologo;
        private int _codEnfermero;
        private int _codPaciente;
        private int _codCliente;
        private int _metodoEntregaExamen;
        private int _metodoPagoExamen;
        private DateTime _fechaOrden;
        private DateTime _fechaFactura;
        private bool _examenCombo;
        private int _cantidad;
        private int _estadoExamenMedico;
        private float _iSV;
        private float _descuento;
        private float _totalVenta;

        public int CodigoFacturaVenta
        {
            get => _codFacturaVenta;
            set
            {
                if (value <= 0) _codFacturaVenta = 1;
                else _codFacturaVenta = value;
            }
        }
        public int[] CodigoExamenMedico
        {
            get => _codExamenMedico;
            set
            {
                if (value.Length ==0 ) throw new FormatException();
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
                if (string.IsNullOrEmpty(value.ToString()) || value <= 0) throw new FormatException();
                else _codPaciente = value;
            }
        }

        public int CodigoCliente
        {
            get => _codCliente;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value <=0 ) throw new FormatException();
                else _codCliente = value;
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

        public int Cantidad
        {
            get => _cantidad;
            set
            {
                if (value <= 0) throw new FormatException();
                else _cantidad = value;
            }
        }

        public int EstadoExamenMedico
        {
            get => _estadoExamenMedico;
            set
            {
                if (value <= 0) throw new FormatException();
                else _estadoExamenMedico = value;
            }
        }
        
        public DateTime FechaOrden { get => _fechaOrden; set => _fechaOrden = value; }

        public DateTime FechaFactura { get => _fechaFactura; set => _fechaFactura = value;}

        public float TotalVenta { get => _totalVenta; set => _totalVenta = value; }
        public bool ExamenCombo { get => _examenCombo; set => _examenCombo = value; }
        public float ISV { get => _iSV; set => _iSV = value; }
        public float Descuento { get => _descuento; set => _descuento = value; }
    }
}

    

