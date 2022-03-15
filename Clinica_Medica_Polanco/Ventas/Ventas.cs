using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Ventas
{
     public class Ventas
    {
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
        private int _codigoFacturaVenta;
        private int _codigoSucursal;
        private int _codigoCliente;
        private DateTime _fechaFactura;
        private float _subtotal;
        private float _isv;
        private float _descuento;
        private float _totalVenta;
        private int _codigoComprador;
        private int _codigoProveedor;
        private int _codigoAdministrador;
        private int _codigoFacturaCompra;
        private float _totalCompra;

        // validacion string: que no venga vacio
        // validacion int: que no sea negativo ni que venga vacio
        // validacion para strings que ocupan un numero: que no este vacio y que solo se ingrese un numero
        public int CodigoExamenMedico
        {
            get => _codExamenMedico;
            set
            {
                if (value<0 ) throw new FormatException();
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
                if (value <= 0) throw new FormatException();
                else _estadoExamenMedico = value;
            }
        }
        public DateTime FechaOrden { get => _fechaOrden; set => _fechaOrden = value; }

        public bool ExamenCombo { get => _examenCombo; set => _examenCombo = value; }
        public int CodigoFacturaVenta { get => _codigoFacturaVenta; set => _codigoFacturaVenta = value; }
        public int CodigoSucursal { get => _codigoSucursal; set => _codigoSucursal = value; }
        public int CodigoCliente { get => _codigoCliente; set => _codigoCliente = value; }
        public DateTime FechaFactura { get => _fechaFactura; set => _fechaFactura = value; }
        public float Subtotal { get => _subtotal; set => _subtotal = value; }
        public float Isv { get => _isv; set => _isv = value; }
        public float Descuento { get => _descuento; set => _descuento = value; }
        public float TotalVenta { get => _totalVenta; set => _totalVenta = value; }
        public int CodigoComprador { get => _codigoComprador; set => _codigoComprador = value; }
        public int CodigoProveedor { get => _codigoProveedor; set => _codigoProveedor = value; }
        public int CodigoAdministrador { get => _codigoAdministrador; set => _codigoAdministrador = value; }
        public int CodigoFacturaCompra { get => _codigoFacturaCompra; set => _codigoFacturaCompra = value; }
        public float TotalCompra { get => _totalCompra; set => _totalCompra = value; }
    }
}

    

