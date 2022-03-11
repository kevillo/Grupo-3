
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Insumos
{
    class categoriaInsumo
    {
        private int _CodigoCategoriaInsumo;
        private string _DescripcionCategoriaInsumo;

        public string DescripcionCategoriaInsumo
        {
            get => _DescripcionCategoriaInsumo;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException("Este campos esta vacio");
                }
                else _DescripcionCategoriaInsumo = value;
            }
        }
    }
}