using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Proveedores
{
    public class codigoAreaTrabajo
    {
        //Estableciendo datos
        public string _nombreArea;

        //Validación de datos
        public string NombreArea 
        { 
            get => _nombreArea; 
            set
            {
                //Validar si la cadena no está vacía
                if (string.IsNullOrEmpty(value)) _nombreArea = "Error";
                else _nombreArea = value;
            }
        }
    }
}
