using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Paciente
{
    class Insumos
    {
        private int _codigoCategoriaInsumo;
        private string _nombreInsumo;
        private DateTime _fechaExpiracion;
        private float _precioUnitario;
        private string _numeroSerie;
        private bool _estado;

        public int CodigoCategoriaInsumo
        {
            get => _codigoCategoriaInsumo;
            set
            {
                if (value <= 0) _codigoCategoriaInsumo = 1;
                else _codigoCategoriaInsumo = value;
            }
        }
        public string NombreInsumo
        {
            get => _nombreInsumo;
            set
            {
                if (string.IsNullOrEmpty(value)) _nombreInsumo = "Error";
                else _nombreInsumo = value;
            }
        }

        public DateTime FechaExpiracion { get => _fechaExpiracion; set => _fechaExpiracion = value; }
        public float PrecioUnitario { get => _precioUnitario; set => _precioUnitario = value; }
        public string NumeroSerie
        {
            get => _numeroSerie;
            set
            {
                if (string.IsNullOrEmpty(value)) _numeroSerie = "Error";
                else _numeroSerie = value;
            }
        }
        public bool Estado { get => _estado; set => _estado = value; }
    }
}
