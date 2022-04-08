using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.servicios
{
    public class Servicios
    {
        //Estableciendo datos
        private string _nombreExamen;
        private string _nombrePaciente;
        private string _nombreEmpleado;
        private string _nombreMetodoEntrega;
        private string _nombreMetodoPago;


        //Validación de datos
        public string NombreExamen
        {
            get => _nombreExamen;
            set
            {
                //Valida si la cadena no está vacía
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _nombreExamen = value;
            }
        }
        public string NombrePaciente
        {
            get => _nombrePaciente;
            set
            {
                //Valida si la cadena no está vacía
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _nombrePaciente = value;
            }
        }
        public string NombreMetodoEntrega
        {
            get => _nombreMetodoEntrega;
            set 
            {
                //Valida si la cadena no está vacía
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _nombreMetodoEntrega = value;
            }
        }
        public string NombreMetodoPago
        {
            get => _nombreMetodoPago; 
            set
            {
                //Valida si la cadena no está vacía
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _nombreMetodoPago = value;
            }
        }

        public string NombreEmpleado { get => _nombreEmpleado; set => _nombreEmpleado = value; }
    }
}