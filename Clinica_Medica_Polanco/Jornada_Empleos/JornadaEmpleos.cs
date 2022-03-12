
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Jornada_Empleo
{
    class JornadaEmpleos
    {
        private int _CodigoJornada;
        private string _DescripcionJornada;
        private DateTime _HoraEntrada;
        private DateTime _HoraSalida;

        // validacion string: que no venga vacio
        // validacion int: que no sea negativo ni que venga vacio
        // validacion para strings que ocupan un numero: que no este vacio y que solo se ingrese un numero
        public string DescripcionJornada
        {
            get => _DescripcionJornada;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException("Este campos esta vacio o tiene numeros negativos");
                }
                else _DescripcionJornada = value;
            }
        }

        public DateTime HoraEntrada
        {
            get => _HoraEntrada;
            set => _HoraEntrada = value;
        }

        public DateTime HoraSalida
        {
            get => _HoraSalida;
            set => _HoraSalida = value;
        }
    }
}