using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_medica_polanco.Inventario
{
    class Inventario
    {
        private int _CodigoInsumo;
        private int _InventarioMes;
        private int _InventarioAño;
        private int _CodigoProveedor;
        private int _CodigoSucursal;
        private DateTime _FechaIngreso;
        private int _Existencia;
        private string _numerolote;

        public int InventarioMes 
        { 
            get => _InventarioMes; 
            set
            {
                if (value <= 0) _InventarioMes = 1;
                else _InventarioMes = value;
            }
        }

        public int InventarioAño 
        { 
            get => _InventarioAño; 
            set
            {
                if (value <= 0) _InventarioAño = 1;
                else _InventarioAño = value;
            }
        }

        public int CodigoProveedor 
        { 
            get => _CodigoProveedor; 
            set
            {
                if (value <= 0) _CodigoProveedor = 1;
                else _CodigoProveedor = value;
            }
        }

        public int CodigoSucursal 
        { 
            get => _CodigoSucursal; 
            set
            {
                if (value <= 0) _CodigoSucursal = 1;
                else _CodigoSucursal = value;
            }
        }

        public int Existencia 
        { 
            get => _Existencia; 
            set
            {
                if (value <= 0) _Existencia = 1;
                else _Existencia = value;
            }
        }

        public string Numerolote 
        {
            get => _numerolote; 
            set
            {
                if (string.IsNullOrEmpty(value.ToString())) _numerolote = "ERROR";
                else _numerolote = value;
            }
        }
    }
}
