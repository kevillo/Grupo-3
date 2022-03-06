﻿
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