﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_medica_polanco.Pacientes
{
    class tipoExamenMedicos
    {
        private int _CdigoTipoExamen;
        private string _DescripcionTipoExamen;

        public string DescripcionTipoExamen
        {
            get => _DescripcionTipoExamen;
            set
            {
                if (string.IsNullOrEmpty(value.ToString())) _DescripcionTipoExamen = "EROR";
                else _DescripcionTipoExamen = value;
            }
        }
    }
}