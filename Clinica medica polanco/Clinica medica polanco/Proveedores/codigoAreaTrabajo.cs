using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_medica_polanco.Paciente
{
    class codigoAreaTrabajo
    {
        private string _nombreArea;

        public string NombreArea 
        { 
            get => _nombreArea; 
            set
            {
                if (string.IsNullOrEmpty(value)) _nombreArea = "Error";
                else _nombreArea = value;
            }
        }





    }
}
