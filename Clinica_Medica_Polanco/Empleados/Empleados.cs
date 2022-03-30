﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;

namespace Clinica_Medica_Polanco.Empleados
{
    public class Empleados
    {
        private int _codigoEmpleado;
        private int _codigoJornada;
        private int _codigoPuesto;
        private int _idUsuario;
        private string _nombreEmpleado;
        private string _apellidoEmpleado;
        private string _identidadEmpleado;
        private string _telefonoEmpleado;
        private DateTime _fechaNacimientoEmpleado;
        private string _correoEmpleado;
        private decimal _alturaEmpleado;
        private string _tipoSangreEmpleado;
        private string _direccionEmpleado;
        private int _codigoSucursal;
        private DateTime _fechaPago;
        private DateTime _fechaContratacion;
        private decimal _sueldoBase;
        private bool _estadoEmpleado;
        private string _cargoEmpleado;
        private string _jornadaEmpleado;
        // validacion string: que no venga vacio
        // validacion int: que no sea negativo ni que venga vacio
        // validacion para strings que ocupan un numero: que no este vacio y que solo se ingrese un numero


        
        public int CodigoJornada 
        { 
            get => _codigoJornada;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value <= 0)
                {
                    throw new FormatException();
                }
                else _codigoJornada = value;
            }
                
        }
        public int CodigoPuesto 
        { 
            get => _codigoPuesto;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value <= 0)
                {
                    throw new FormatException();
                }
                else _codigoPuesto = value;
            }
        }
        public int IdUsuario 
        { 
            get => _idUsuario;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value <= 0)
                {
                    throw new FormatException();
                }
                else _idUsuario = value;
            }
        }
        public string NombreEmpleado 
        { 
            get => _nombreEmpleado;
            set
            {
                // valida si la cadena esta vacia o si tiene una longitud menor a 2
                if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 51)
                {
                    throw new FormatException("Procure no dejar el Nombre con un formato incorrecto o vacío.");
                }
                else _nombreEmpleado = value;
            }
        }
        public string ApellidoEmpleado 
        { 
            get => _apellidoEmpleado;
            set
            {
                // valida si la cadena esta vacia o si tiene una longitud menor a 2
                if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 51)
                {

                    throw new FormatException("Procure no dejar el Apellido con un formato incorrecto o vacío.");
                }
                else _apellidoEmpleado = value;
            }
        }
        public string IdentidadEmpleado 
        { 
            get => _identidadEmpleado;
            set
            {
                // valida si la cadena no esta vacia, si es un numero, y si tiene exactamente 13 caracteres
                if (string.IsNullOrEmpty(value) || !Int64.TryParse(value, out long _) || value.Length != 13 || !IdentidadNoGenerica(value))
                {
                    throw new FormatException("Procure no dejar la Identidad con un formato incorrecto o vacío.");
                }
                else _identidadEmpleado = value;
            }
        }


        public string TelefonoEmpleado 
        { 
            get => _telefonoEmpleado;
            set
            {
                // valida si la cadena no esta vacia, si es un numero, y si tiene exactamente 8 caracteres
                if (string.IsNullOrEmpty(value) || !Int64.TryParse(value, out long _) || validarTelefono(value) == false || value.Length != 8 || !NumeroNoGenerico(value))
                {
                    throw new FormatException("Procure no dejar el Teléfono con un formato incorrecto o vacío.");
                }
                else _telefonoEmpleado = value;
            }

        }
        public DateTime FechaNacimientoEmpleado 
        { 
            get => _fechaNacimientoEmpleado;
            set
            {
                // valida si la fecha no es la fecha de hoy y si la fecha no es mayor a la fecha de hoy: 
                // por ejemplo, no se puede poner una fecha como  15/04/2022 por que es mayor a la de hoy
                if (value.ToShortDateString() == DateTime.Now.ToShortDateString() || value > DateTime.Now)
                {
                    throw new FormatException();
                }
                else _fechaNacimientoEmpleado = value;
            }
        }
        public string CorreoEmpleado 
        { 
            get => _correoEmpleado;
            set
            {
                // valida si el email es verdadero ( aqui se pone falso por que asi entrara en el catch de ser falso)
                if (!validarEmail(value) )
                {
                    throw new FormatException("Procure no dejar el Correo con un formato incorrecto o vacío.");
                }
                else _correoEmpleado = value;
            }


        }
        public decimal AlturaEmpleado 
        { 
            get => _alturaEmpleado;
            set
            {
                //valida si la altura es positiva y si es un deciamal
                if (value <= 0 || !decimal.TryParse(value.ToString(), out decimal _) || value.ToString().Length<1 || value.ToString().Length > 3)
                {
                    throw new FormatException("Procure no dejar la Altura con un formato incorrecto o vacío.");
                }
                else _alturaEmpleado = value;
            }

        }
        public string TipoSangreEmpleado 
        { 
            get => _tipoSangreEmpleado;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _tipoSangreEmpleado = value;
            }
        }
        public string DireccionEmpleado 
        { 
          get => _direccionEmpleado;
          set
            {
                if (string.IsNullOrEmpty(value) || (value.Length < 10 || value.Length > 255))
                {
                    throw new FormatException();
                }
                else _direccionEmpleado = value;
            }
        }
        public int CodigoSucursal 
        { 
            get => _codigoSucursal;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value < 0)
                {
                    throw new FormatException();
                }
                else _codigoSucursal = value;
            }
        }

        public DateTime FechaPago 
        { 
            get => _fechaPago; 
            set
            {
                // valida si la fecha no es la fecha de hoy y si la fecha no es mayor a la fecha de hoy: 
                // por ejemplo, no se puede poner una fecha como  15/04/2022 por que es menor a la de hoy
                if (value.ToShortDateString() == DateTime.Now.ToShortDateString() )
                {
                    throw new FormatException();
                }
                else _fechaPago = value;
            }
         }
        public DateTime FechaContratacion
        {
            get => _fechaContratacion;
            set
            {
                // valida si la fecha no es la fecha de hoy y si la fecha no es mayor a la fecha de hoy: 
                // por ejemplo, no se puede poner una fecha como  15/04/2022 por que es menor a la de hoy
                if (value.ToShortDateString() == DateTime.Now.ToShortDateString() )
                {
                    throw new FormatException();
                }
                else _fechaContratacion = value;
            }
        }
        public decimal SueldoBase 
        { 
            get => _sueldoBase; 
            set
            {
                // valida si la cadena no esta vacia, si es un numero, y si tiene exactamente 10 caracteres
                if ( value <=0 ||  string.IsNullOrEmpty(value.ToString())|| !decimal.TryParse(value.ToString(), out decimal _) || value.ToString().Length<4 || value.ToString().Length > 10)
                {
                    throw new FormatException("Procure no dejar el Sueldo con un formato incorrecto o vacío.");
                }
                else _sueldoBase = value;
            }
        }

        public int CodigoEmpleado 
        { 
            get => _codigoEmpleado; 
            set
            {
                if (string.IsNullOrEmpty(value.ToString())) throw new FormatException();
                else _codigoEmpleado = value;
            }
        }

        public bool EstadoEmpleado { get => _estadoEmpleado; set => _estadoEmpleado = value; }
        public string CargoEmpleado
        {
            get => _cargoEmpleado;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _cargoEmpleado = value;
            }
        }

        public string JornadaEmpleado
        {
            get => _jornadaEmpleado;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _jornadaEmpleado = value;
            }
        }

        // valida si el correo tiene un @, si hay algo antes y despues del @ y si tiene un .com o algo asi
        private  bool validarEmail(string comprobarEmail)
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

        public bool IdentidadNoGenerica(string identidad)
        {
            Dictionary<char, int> contadorOcurrencias = new Dictionary<char, int>();
            int max = -1;

            foreach(char c in identidad)
            {
                if (contadorOcurrencias.TryGetValue(c, out int _))
                {
                    contadorOcurrencias[c] += 1; 
                }
                else contadorOcurrencias.Add(c, 1);
            }

            foreach( char c in contadorOcurrencias.Keys)
            {
                if (contadorOcurrencias[c] > max) max = contadorOcurrencias[c];
            }
            if (max > 9) return false;
            return true;

        }


        public bool NumeroNoGenerico(string telefono)
        {
            Dictionary<char, int> contadorOcurrencias = new Dictionary<char, int>();
            int max = -1;

            foreach (char c in telefono)
            {
                if (contadorOcurrencias.TryGetValue(c, out int _))
                {
                    contadorOcurrencias[c] += 1;
                }
                else contadorOcurrencias.Add(c, 1);
            }

            foreach (char c in contadorOcurrencias.Keys)
            {
                if (contadorOcurrencias[c] > max) max = contadorOcurrencias[c];
            }
            if (max == 8) return false;
            return true;
        }
        //valida si el telefono empieza en 9 8 3 2 
        private  bool validarTelefono(string telefono)
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
    }
}