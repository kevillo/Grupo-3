using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Proveedores
{
    class proveedoresVentas
    {
        private int _codigoInsumo;
        private string _nombreInsumo;
        private string _nombreProveedor;
        private string _nombreSucursal;
        private int _existencia;
        private DateTime _FechaIngreso;
        private int _anioInventario;
        private int _mesInventario;
        private string _numeroLote;

        public int CodigoInsumo { get => _codigoInsumo; set => _codigoInsumo = value; }
        public string NombreInsumo { get => _nombreInsumo; set => _nombreInsumo = value; }
        public string NombreProveedor { get => _nombreProveedor; set => _nombreProveedor = value; }
        public string NombreSucursal { get => _nombreSucursal; set => _nombreSucursal = value; }
        public int Existencia { get => _existencia; set => _existencia = value; }
        public DateTime FechaIngreso { get => _FechaIngreso; set => _FechaIngreso = value; }
        public int AnioInventario { get => _anioInventario; set => _anioInventario = value; }
        public int MesInventario { get => _mesInventario; set => _mesInventario = value; }
        public string NumeroLote { get => _numeroLote; set => _numeroLote = value; }
    }
}
