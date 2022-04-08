using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Ventas
{
    class ventasRealizadas
    {
        //Estableciendo datos
        private int _codFactura;
        private string _nombreSucursal;
        private string _nombrePaciente;
        private string _nombreaEmpleado;
        private DateTime _fechaFactura;
        private decimal _subtotalVenta;
        private decimal _IsvVenta;
        private decimal _descuentoVenta;
        private decimal _totalVenta;

        //Validación de datos
        public int CodFactura { get => _codFactura; set => _codFactura = value; }
        public string NombreSucursal { get => _nombreSucursal; set => _nombreSucursal = value; }
        public string NombrePaciente { get => _nombrePaciente; set => _nombrePaciente = value; }
        public string NombreaEmpleado { get => _nombreaEmpleado; set => _nombreaEmpleado = value; }
        public DateTime FechaFactura { get => _fechaFactura; set => _fechaFactura = value; }
        public decimal SubtotalVenta { get => _subtotalVenta; set => _subtotalVenta = value; }
        public decimal IsvVenta { get => _IsvVenta; set => _IsvVenta = value; }
        public decimal DescuentoVenta { get => _descuentoVenta; set => _descuentoVenta = value; }
        public decimal TotalVenta { get => _totalVenta; set => _totalVenta = value; }
    }
}
