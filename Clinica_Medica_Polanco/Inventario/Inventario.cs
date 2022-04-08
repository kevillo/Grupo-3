
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Inventario
{
    class Inventario
    {
        //Estableciendo datos
        private int _CodigoInsumo;
        private int _InventarioMes;
        private int _InventarioAño;
        private int _CodigoProveedor;
        private int _CodigoSucursal;
        private DateTime _FechaIngreso;
        private string _numerolote;

        // validación string: que no venga vacío
        // validación int: que no sea negativo ni que venga vacío
        // validación para strings que ocupan un número: que no esté vacío y que solo se ingrese un número


        //Validación de datos
        public int InventarioMes
        {
            get => _InventarioMes;
            set
            {
                //Valida si la cadena no está vacía
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
                //Valida si la cadena no está vacía
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
                //Valida si la cadena no está vacía
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
                //Valida si la cadena no está vacía
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
                //Valida si la cadena no está vacía
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
