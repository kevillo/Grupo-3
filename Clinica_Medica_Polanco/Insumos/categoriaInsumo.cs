
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_medica_polanco.Pacientes
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