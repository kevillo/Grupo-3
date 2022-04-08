using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Pacientes
{
    class tipoExamenMedicos
    {
        //Estableciendo datos
        private int _CdigoTipoExamen;
        private string _DescripcionTipoExamen;

        //Validación de datos
        public string DescripcionTipoExamen
        {
            get => _DescripcionTipoExamen;
            set
            {
                //Valida si la cadena no está vacía
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException("Procure no dejar Tipo Examen en un formato incorrecto o vacío.");
                }
                else _DescripcionTipoExamen = value;
            }
        }
    }
}
