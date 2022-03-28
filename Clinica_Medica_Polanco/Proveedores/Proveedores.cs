using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            set 
            {
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
            set 
            {
                // valida si la cadena esta vacia o si tiene una longitud menor a 2
                if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 51)
                {
                    throw new FormatException("Procure no dejar el Nombre con un formato incorrecto o vacío.");
                }
                else _nombreProveedor = value;
            }
        }
        public string ApellidoProveedor
        {
            get => _apellidoProveedor;
            set
            {
                // valida si la cadena esta vacia o si tiene una longitud menor a 2
                if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 51)
                {

                    throw new FormatException("Procure no dejar el Apellido con un formato incorrecto o vacío.");
                }
                else _apellidoProveedor = value;
            }
        }
        public string DireccionProveedor
        {
            get => _direccionProveedor;
            set
            {
                if (string.IsNullOrEmpty(value) || (value.Length < 10 || value.Length > 255))
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
                if (validarEmail(value) == false)
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
                // valida si la cadena no esta vacia, si es un numero, y si tiene exactamente 8 caracteres
                if (string.IsNullOrEmpty(value) || !Int64.TryParse(value, out long _) || validarTelefono(value) == false || value.Length != 8)
                {
                    throw new FormatException("Procure no dejar el Teléfono con un formato incorrecto o vacío.");
                }
                else _telefonoProveedor = value;
            }
        }
        public bool EstadoProveedor { get => _estadoProveedor; set => _estadoProveedor = value; }


        public static bool validarTelefono(string telefono)
        {
            if (telefono.StartsWith("9") || telefono.StartsWith("8") || telefono.StartsWith("3") || telefono.StartsWith("2"))
            {
                return true;
            }
            else
            {
                System.Windows.MessageBox.Show("El número de telefóno debe comenzar por 2, 3, 8 o 9");
                return false;
            }
        }


        public static bool validarEmail(string comprobarEmail)
        {
            string emailFormato;
            emailFormato = "\\w+([-+.']\\w+)*@\\w+([-+.']\\w+)*\\.\\w+([-+.']\\w+)*";
            if (Regex.IsMatch(comprobarEmail, emailFormato))
            {
                if (Regex.Replace(comprobarEmail, emailFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
