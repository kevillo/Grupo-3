using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.ExamenesMedicos
{
    public class ExamenesMedicos
    {
        private int _codigoExamen;
        private int _codigoTipoExamen;
        private decimal _precioUnitario;
        private bool _estado;

        // validacion string: que no venga vacio
        // validacion int: que no sea negativo ni que venga vacio
        // validacion para strings que ocupan un numero: que no este vacio y que solo se ingrese un numero
        public int CodigoExamen { get => _codigoExamen; set => _codigoExamen = value; }
        public int CodigoTipoExamen
        {
            get => _codigoTipoExamen;
            set {
                if (value <= 0) _codigoTipoExamen = 1;
                else _codigoTipoExamen = value;
            }
        }
        public decimal PrecioUnitario { get => _precioUnitario; set => _precioUnitario = value; }
        public bool Estado { get => _estado; set => _estado = value; }
    }
}
