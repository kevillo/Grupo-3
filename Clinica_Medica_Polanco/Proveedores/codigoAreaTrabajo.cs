using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Proveedores
{
    public class codigoAreaTrabajo
    {
        public string _nombreArea;

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
