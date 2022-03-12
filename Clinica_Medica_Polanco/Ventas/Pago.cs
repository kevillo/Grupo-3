using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Ventas
{
    class Pago
    {
        private float _iSV;
        private float _descuento;
        private float _totalVenta;

        public float ISV { get => _iSV; set => _iSV = value; }
        public float Descuento { get => _descuento; set => _descuento = value; }
        public float TotalVenta { get => _totalVenta; set => _totalVenta = value; }
    }
}
