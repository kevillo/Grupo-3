using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_medica_polanco.Paciente
{

    class Proveedores
    {
        private int _codigoAreaTrabajo;
        private string _nombreProveedor;
        private string _apellidoProveedor;
        private string _direccionProveedor;
        private string _correoProveedor;
        private string _telefonoProveedor;
        private bool _estadoProveedor;

        public int CodigoAreaTrabajo 
        { 
            get => _codigoAreaTrabajo;
            set {
                if (value <= 0) _codigoAreaTrabajo = 1;
                else _codigoAreaTrabajo = value;
            }
        }
        public string NombreProveedor 
        { 
            get => _nombreProveedor;
            set 
            {
                if (String.IsNullOrEmpty(value)) _nombreProveedor = "Error";
                else _nombreProveedor = value;
            }
        }
        public string ApellidoProveedor
        {
            get => _apellidoProveedor;
            set
            {
                if (String.IsNullOrEmpty(value)) _apellidoProveedor = "Error";
                else _apellidoProveedor = value;
            }
        }

        public string DireccionProveedor 
        { 
            get => _direccionProveedor;
            set
            {
                if (String.IsNullOrEmpty(value)) _direccionProveedor = "Error";
                else _direccionProveedor = value;
            }
        }
        public string CorreoProveedor 
        { 
            get => _correoProveedor;
            set
            {
                if (String.IsNullOrEmpty(value)) _correoProveedor = "Error";
                else _correoProveedor= value;
            }
        }
        public string TelefonoProveedor
        { 
            get => _telefonoProveedor;
            set
            {
                if (String.IsNullOrEmpty(value)) _telefonoProveedor = "Error";
                else _telefonoProveedor= value;
            }
        }
        public bool EstadoProveedor { get => _estadoProveedor; set => _estadoProveedor = value; }
    }
}
