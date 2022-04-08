using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Insumos
{
    public class Insumos
    {
        //Estableciendo datos
        private int _codigoCategoriaInsumo;
        private int _codigoInsumo;
        private string _nombreInsumo;
        private DateTime _fechaExpiracion;
        private decimal _precioUnitario;
        private string _numeroSerie;
        private bool _estado;
        private string _DescripcionCategoriaInsumo;
        private int _Existencia;



        // validación string: que no venga vacío
        // validación int: que no sea negativo ni que venga vacío
        // validación para strings que ocupan un número: que no esté vacío y que solo se ingrese un número


        //Validación de datos
        public int Existencia
        {
            get => _Existencia;
            set
            { 
                //Valida si la cadena no está vacía y si tiene una longitud menor o igual a 0
                if (value <= 0 || string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException("Procure no dejar la Existencia con un formato incorrecto o vacío.");
                }
                else _Existencia = value;
            }
        }
        public string DescripcionCategoriaInsumo
        {
            get => _DescripcionCategoriaInsumo;
            set
            {
                //Valida si la cadena no está vacía
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException("Procure no dejar la Categoría de Insumo con un formato incorrecto o vacío.");
                }
                else _DescripcionCategoriaInsumo = value;
            }
        }
        public int CodigoCategoriaInsumo
        {
            get => _codigoCategoriaInsumo;
            set
            {
                //Valida si tiene una longitud menor o igual a 0
                if (value <= 0) throw new FormatException();
                else _codigoCategoriaInsumo = value;
            }
        }
        public string NombreInsumo
        {
            get => _nombreInsumo;
            set
            {
                //Valida si la cadena no está vacía o si tiene una longitud menor a 2
                if (string.IsNullOrEmpty(value) || value.Length < 2|| value.Length >50 || int.TryParse(NombreInsumo,out int _))
                {
                    throw new FormatException("Procure no dejar el Nombre con un formato incorrecto o vacío.");
                }
                else _nombreInsumo = value;
            }
        }

        public DateTime FechaExpiracion
        {
            get => _fechaExpiracion;
            set
            {
                //Valida que la fecha final sea mayor que la de inicio 
                if (value.ToShortDateString() == DateTime.Now.ToShortDateString()||value < DateTime.Now ) throw new FormatException();
                else _fechaExpiracion = value;
            }
        }

        public decimal PrecioUnitario 
        { 
            get => _precioUnitario; 
            set
            {
                //Valida si el precio unitario es positivo y si es un deciamal, y que tenga una longitud menor a 4 y una mayor a 10
                if (value <= 0 || !decimal.TryParse(value.ToString(), out decimal _)|| (value.ToString()).Length < 4|| (value.ToString()).Length > 10)
                {
                    throw new FormatException("Procure no dejar el Precio Unitario con un formato incorrecto o vacío.");
                }
                else _precioUnitario = value;
            }
        }
        
        
        public string NumeroSerie
        {
            get => _numeroSerie;
            set
            {
                //Valida si la cadena no está vacía, si es un número, y si está en un rango de 10 caracteres
                if (int.Parse(value) <=0 || string.IsNullOrEmpty(value) || !Int64.TryParse(value, out long _) || value.Length > 10)
                {
                    throw new FormatException("Procure no dejar el Número de serie con un formato incorrecto o vacío.");
                }
                else _numeroSerie = value;
            }
        }
        public bool Estado { get => _estado; set => _estado = value; }
        public int CodigoInsumo { get => _codigoInsumo; set => _codigoInsumo = value; }
    }
}
