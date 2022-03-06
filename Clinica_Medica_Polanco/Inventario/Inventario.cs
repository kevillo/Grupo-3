
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
                if (value <= 0 || string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException("Este campos esta vacio o tiene numeros negativos");
                }
                else _InventarioMes = value;
            }
        }

        public int InventarioAño
        {
            get => _InventarioAño;
            set
            {
                if (value <= 0 || string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException("Este campos esta vacio o tiene numeros negativos");
                }
                else _InventarioAño = value;
            }
        }

        public int CodigoProveedor
        {
            get => _CodigoProveedor;
            set
            {
                if (value <= 0 || string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException("Este campos esta vacio o tiene numeros negativos");
                }
                else _CodigoProveedor = value;
            }
        }

        public int CodigoSucursal
        {
            get => _CodigoSucursal;
            set
            {
                if (value <= 0 || string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException("Este campos esta vacio o tiene numeros negativos");
                }
                else _CodigoSucursal = value;
            }
        }

        public int Existencia
        {
            get => _Existencia;
            set
            {
                if (value <= 0 || string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException("Este campos esta vacio o tiene numeros negativos");
                }
                else _Existencia = value;
            }
        }

        public string Numerolote
        {
            get => _numerolote;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException("Este campos esta vacio o tiene numeros negativos");
                }
                else _numerolote = value;
            }
        }

        public DateTime FechaIngreso
        {
            get => _FechaIngreso;
            set => _FechaIngreso = value;
        }
    }
}
