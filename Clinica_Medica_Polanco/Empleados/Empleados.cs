﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Empleados
{
    class Empleados
    {
        private int _codigoJornada;
        private int _codigoPuesto;
        private int _idUsuario;
        private string _nombreEmpleado;
        private string _apellidoEmpleado;
        private string _identidadEmpleado;
        private string _telefonoEmpleado;
        private DateTime _fechaNacimientoEmpleado;
        private string _correoEmpleado;
        private int _alturaEmpleado;
        private string _tipoSangreEmpleado;
        private string _direccionEmpleado;
        private int _codigoSucursal;

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
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _nombreEmpleado = value;
            }
        }
        public string ApellidoEmpleado 
        { 
            get => _apellidoEmpleado;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _apellidoEmpleado = value;
            }
        }
        public string IdentidadEmpleado 
        { 
            get => _identidadEmpleado;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || Int64.TryParse(value, out long _) )
                {
                    throw new FormatException();
                }
                else _identidadEmpleado = value;
            }
        }


        public string TelefonoEmpleado 
        { 
            get => _telefonoEmpleado;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _telefonoEmpleado = value;
            }

        }
        public DateTime FechaNacimientoEmpleado 
        { 
            get => _fechaNacimientoEmpleado;
            set
            {
                if (value.ToShortDateString()==DateTime.Now.ToShortDateString())
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
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new FormatException();
                }
                else _correoEmpleado = value;
            }


        }
        public int AlturaEmpleado 
        { 
            get => _alturaEmpleado;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value <= 0)
                {
                    throw new FormatException();
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
                if (string.IsNullOrEmpty(value.ToString()))
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
                if (string.IsNullOrEmpty(value.ToString()) || value <= 0)
                {
                    throw new FormatException();
                }
                else _codigoSucursal = value;
            }
        }
    }
}
