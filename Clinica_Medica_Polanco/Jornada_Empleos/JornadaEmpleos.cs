
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Jornada_Empleo
{
    class JornadaEmpleos
    {
        //Estableciendo valores
        private int _CodigoJornada;
        private string _DescripcionJornada;
        private DateTime _HoraEntrada;
        private DateTime _HoraSalida;

        // validación string: que no venga vacío
        // validación int: que no sea negativo ni que venga vacío
        // validación para strings que ocupan un número: que no este vacío y que solo se ingrese un número

        //Validación de datos
        public string DescripcionJornada
        {
            get => _DescripcionJornada;
            set
            { 
                //Valida si la cadena no está vacía
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException("Procure no dejar la Jornada con un formato incorrecto o vacío.");
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