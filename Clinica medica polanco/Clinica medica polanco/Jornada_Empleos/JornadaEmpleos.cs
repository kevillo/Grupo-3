using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_medica_polanco.Jornada_Empleo
{
    class JornadaEmpleos
    {
        private int _CodigoJornada;
        private string _DescripcionJornada;
        private DateTime _HoraEntrada;
        private DateTime _HoraSalida;

        public string DescripcionJornada 
        { 
            get => _DescripcionJornada; 
            set
            {
                if (string.IsNullOrEmpty(value.ToString())) _DescripcionJornada = "ERROR";
                else _DescripcionJornada = value;
            }
        }
    }
}
