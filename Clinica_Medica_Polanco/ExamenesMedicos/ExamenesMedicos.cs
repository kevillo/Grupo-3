using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.ExamenesMedicos
{
    class ExamenesMedicos
    {
        private int _codigoExamen;
        private int _codigoTipoExamen;
        private float _precioUnitario;
        private bool _estado;

        public int CodigoExamen { get => _codigoExamen; set => _codigoExamen = value; }
        public int CodigoTipoExamen
        {
            get => _codigoTipoExamen;
            set {
                if (value <= 0) _codigoTipoExamen = 1;
                else _codigoTipoExamen = value;
            }
        }
        public float PrecioUnitario { get => _precioUnitario; set => _precioUnitario = value; }
        public bool Estado { get => _estado; set => _estado = value; }
    }
}
