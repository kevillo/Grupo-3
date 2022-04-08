using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Compras
{
    class comprasRealizadas
    {
        //Estableciendo datos en la clase
        private int _codFacturaCompra;
        private string _nombreSucursal;
        private string _nombreAdministrador;
        private string _nombreProveedor;
        private DateTime _fechaFactura;
        private decimal _isvCompra;
        private decimal _totalCompra;

        public int CodFacturaCompra { get => _codFacturaCompra; set => _codFacturaCompra = value; }
        public string NombreAdministrador { get => _nombreAdministrador; set => _nombreAdministrador = value; }
        public string NombreProveedor { get => _nombreProveedor; set => _nombreProveedor = value; }
        public DateTime FechaFactura { get => _fechaFactura; set => _fechaFactura = value; }
        public decimal IsvCompra { get => _isvCompra; set => _isvCompra = value; }
        public decimal TotalCompra { get => _totalCompra; set => _totalCompra = value; }
        public string NombreSucursal { get => _nombreSucursal; set => _nombreSucursal = value; }
    }
}
