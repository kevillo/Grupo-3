using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Insumos
{
    public class Insumos
    {
        //Validación de valores
        private int _codigoCategoriaInsumo;
        private int _codigoInsumo;
        private string _nombreInsumo;
        private DateTime _fechaExpiracion;
        private decimal _precioUnitario;
        private string _numeroSerie;
        private bool _estado;
        private string _DescripcionCategoriaInsumo;
        private int _Existencia;



        // validacion string: que no venga vacio
        // validacion int: que no sea negativo ni que venga vacio
        // validacion para strings que ocupan un numero: que no este vacio y que solo se ingrese un numero

        public int Existencia
        {
            get => _Existencia;
            set
            {
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
                if (value <= 0) throw new FormatException();
                else _codigoCategoriaInsumo = value;
            }
        }
        public string NombreInsumo
        {
            get => _nombreInsumo;
            set
            {
                // valida si la cadena esta vacia o si tiene una longitud menor a 2
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
                if (value.ToShortDateString() == DateTime.Now.ToShortDateString()||value < DateTime.Now ) throw new FormatException();
                else _fechaExpiracion = value;
            }
        }

        public decimal PrecioUnitario 
        { 
            get => _precioUnitario; 
            set
            {
                //valida si la altura es positiva y si es un deciamal
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
                // valida si la cadena no esta vacia, si es un numero, y si está en un rango de 10 caracteres
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
