
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Inventario
{
    class Inventario
    {
        private int _CodigoInsumo;
        private int _InventarioMes;
        private int _InventarioAño;
        private int _CodigoProveedor;
        private int _CodigoSucursal;
        private DateTime _FechaIngreso;
        
        private string _numerolote;


        // validacion string: que no venga vacio
        // validacion int: que no sea negativo ni que venga vacio
        // validacion para strings que ocupan un numero: que no este vacio y que solo se ingrese un numero
        public int InventarioMes
        {
            get => _InventarioMes;
            set
            {
                if (value <= 0 || string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException("Procure no dejar el Mes de Inventario con un formato incorrecto o vacío.");
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
                    throw new FormatException("Procure no dejar el Año de Inventario con un formato incorrecto o vacío.");
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
                    throw new FormatException("Procure no dejar el Código de Proveedor con un formato incorrecto o vacío.");
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
                    throw new FormatException("Procure no dejar el Código de Sucursal con un formato incorrecto o vacío.");
                }
                else _CodigoSucursal = value;
            }
        }

        

        public string Numerolote
        {
            get => _numerolote;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException("Procure no dejar el Número de Lote con un formato incorrecto o vacío.");
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
