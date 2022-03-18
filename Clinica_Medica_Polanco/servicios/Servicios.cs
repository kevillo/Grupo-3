using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.servicios
{
    public class Servicios
    {
        private string _nombreExamen;
        private string _nombrePaciente;
        private string _nombreEmpleado;
        private string _nombreMetodoEntrega;
        private string _nombreMetodoPago;

        public string NombreExamen
        {
            get => _nombreExamen;
            set
            {
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