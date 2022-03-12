using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Paciente
{
    class Compras
    {
        private int _codFacturaCompra;
        private int _codComprador;
        private int codProveedor;
        private DateTime fechaFactura;
        private float _isv;
        private int _codAdministrador;
        private int _codigoInsumo;
        private int _cantidad;

        // validacion string: que no venga vacio
        // validacion int: que no sea negativo ni que venga vacio
        // validacion para strings que ocupan un numero: que no este vacio y que solo se ingrese un numero
        public int CodFacturaCompra { get => _codFacturaCompra; set => _codFacturaCompra = value; }
        public int CodComprador { get => _codComprador; set => _codComprador = value; }
        public int CodProveedor { get => codProveedor; set => codProveedor = value; }
        public DateTime FechaFactura { get => fechaFactura; set => fechaFactura = value; }
        public float Isv { get => _isv; set => _isv = value; }
        public int CodAdministrador { get => _codAdministrador; set => _codAdministrador = value; }
        public int CodigoInsumo
        {
            get => _codigoInsumo;
            set
            {
                if (value < 0 || string.IsNullOrEmpty(value.ToString())) _codigoInsumo = 1;
                else _codigoInsumo = value;
            }
        }

        public int Cantidad 
        { 
            get => _cantidad;
            set
            {
                if (value < 0 || string.IsNullOrEmpty(value.ToString())) _cantidad= 1;
                else _cantidad= value;
            }
        }
    }
}
