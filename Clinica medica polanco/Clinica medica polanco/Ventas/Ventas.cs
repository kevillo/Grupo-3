using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_medica_polanco.Ventas
{
    internal class Ventas
    {
        private int _codFacturaVenta;
        private int _codExamenMedico;
        private int _codFacturador;
        private int _codMicrobiologo;
        private int _codEnfermero;
        private int _codPaciente;
        private int _codCliente;
        private int _metodoEntregaExamen;
        private int _metodoPagoExamen;
        private DateTime _fechaOrden;
        private DateTime _fechaFactura;
        private byte _examenCombo;
        private int _cantidad;
        private int _estadoExamenMedico;
        private decimal _iSV;
        private decimal _descuento;
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
        public int CodigoExamenMedico
        {
            get => _codExamenMedico;
            set
            {
                if (value <= 0) _codExamenMedico = 1;
                else _codExamenMedico= value;
            }
        }
        
        public int CodigoFacturador
        {
            get => _codFacturador;
            set
            {
                if (value <= 0) _codFacturador= 1;
                else _codFacturador = value;
            }
        }

        public int CodigoMicrobiologo
        {
            get => _codMicrobiologo;
            set
            {
                if (value <= 0) _codMicrobiologo = 1;
                else _codMicrobiologo = value;
            }
        }

        public int CodigoEnfermero
        {
            get => _codEnfermero;
            set
            {
                if (value <= 0) _codEnfermero = 1;
                else _codEnfermero = value;
            }
        }

        public int CodigoPaciente
        {
            get => _codPaciente;
            set
            {
                if (value <= 0) _codPaciente = 1;
                else _codPaciente = value;
            }
        }

        public int CodigoCliente
        {
            get => _codCliente;
            set
            {
                if (value <= 0) _codCliente = 1;
                else _codCliente = value;
            }
        }

        public int MetodoEntregaExamen
        {
            get => _metodoEntregaExamen;
            set
            {
                if (value <= 0) _metodoEntregaExamen = 1;
                else _metodoEntregaExamen = value;
            }
        }

        public int MetodoPagoExamen
        {
            get => _metodoPagoExamen;
            set
            {
                if (value <= 0) _metodoPagoExamen = 1;
                else _metodoPagoExamen = value;
            }
        }

        public int Cantidad
        {
            get => _cantidad;
            set
            {
                if (value <= 0) _cantidad = 1;
                else _cantidad = value;
            }
        }

        public int EstadoExamenMedico
        {
            get => _estadoExamenMedico;
            set
            {
                if (value <= 0) _estadoExamenMedico = 1;
                else _estadoExamenMedico = value;
            }
        }
        
        public DateTime FechaOrden { get => _fechaOrden; set => _fechaOrden = value; }

        public DateTime FechaFactura { get => _fechaFactura; set => _fechaFactura = value;}

        public float TotalVenta { get => _totalVenta; set => _totalVenta = value; }
       
        
    }
}

    

