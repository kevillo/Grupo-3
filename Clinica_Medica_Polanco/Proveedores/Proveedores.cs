using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Proveedores
{

    public class Proveedores
    {
        private int _codigoProveedor;
        private int _codigoAreaTrabajo;
        private string _nombreProveedor;
        private string _apellidoProveedor;
        private string _direccionProveedor;
        private string _correoProveedor;
        private string _telefonoProveedor;
        private bool _estadoProveedor;

        // validacion string: que no venga vacio
        // validacion int: que no sea negativo ni que venga vacio
        // validacion para strings que ocupan un numero: que no este vacio y que solo se ingrese un numero
        public int CodigoProveedor
        {
            get => _codigoProveedor;
            set {
                if (value <= 0) _codigoProveedor = 1;
                else _codigoProveedor = value;
            }
        }
        public int CodigoAreaTrabajo
        {
            get => _codigoAreaTrabajo;
            set {
                if (string.IsNullOrEmpty(value.ToString()) || value < 0)
                {
                    throw new FormatException();
                }
                else _codigoAreaTrabajo = value;
            }
        }
        public string NombreProveedor
        {
            get => _nombreProveedor;
            set {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _nombreProveedor = value;
            }
        }
        public string ApellidoProveedor
        {
            get => _apellidoProveedor;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _apellidoProveedor = value;
            }
        }
        public string DireccionProveedor
        {
            get => _direccionProveedor;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new FormatException();
                }
                else _direccionProveedor = value;
            }
        }
        public string CorreoProveedor
        {
            get => _correoProveedor;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _correoProveedor = value;
            }
        }
        public string TelefonoProveedor
        {
            get => _telefonoProveedor;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _telefonoProveedor = value;
            }
        }
        public bool EstadoProveedor { get => _estadoProveedor; set => _estadoProveedor = value; }
    }
}
