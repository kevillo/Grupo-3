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


        // validacion string: que no venga vacio
        // validacion int: que no sea negativo ni que venga vacio
        // validacion para strings que ocupan un numero: que no este vacio y que solo se ingrese un numero
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
                if (string.IsNullOrEmpty(value)) throw new FormatException();
                else _nombreInsumo = value;
            }
        }

        public DateTime FechaExpiracion
        {
            get => _fechaExpiracion;
            set
            {
                if (value.ToShortDateString() == DateTime.Now.ToShortDateString()) throw new FormatException();
                else _fechaExpiracion = value;
            }
        }

        public decimal PrecioUnitario 
        { 
            get => _precioUnitario; 
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value <0) throw new FormatException();
                else _precioUnitario = value;
            }
        }
        
        
        public string NumeroSerie
        {
            get => _numeroSerie;
            set
            {
                if (string.IsNullOrEmpty(value) || !Int64.TryParse(value, out long _)) throw new FormatException();
                else _numeroSerie = value;
            }
        }
        public bool Estado { get => _estado; set => _estado = value; }
        public int CodigoInsumo { get => _codigoInsumo; set => _codigoInsumo = value; }
    }
}
