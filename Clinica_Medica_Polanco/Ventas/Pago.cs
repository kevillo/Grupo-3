using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.Ventas
{
    class Pago
    {
        private decimal _iSV;
        private decimal _descuento;
        private decimal _totalVenta;
        private string _metodoPago;
        private string _metodoEntrega;
        private string _nombrePaciente;
        private string _telefonoPaciente;
        private string _correoPaciente;
        private string _fechaOrden;
        private decimal _subtotal;

            
        public decimal ISV { get => _iSV; set => _iSV = value; }
        public decimal Descuento { get => _descuento; set => _descuento = value; }
        public decimal TotalVenta { get => _totalVenta; set => _totalVenta = value; }
        public string MetodoEntrega { get => _metodoEntrega; set => _metodoEntrega = value; }
        public string NombrePaciente { get => _nombrePaciente; set => _nombrePaciente = value; }
        public string TelefonoPaciente { get => _telefonoPaciente; set => _telefonoPaciente = value; }
        public string CorreoPaciente { get => _correoPaciente; set => _correoPaciente = value; }
        public string FechaOrden { get => _fechaOrden; set => _fechaOrden = value; }
        public string MetodoPago { get => _metodoPago; set => _metodoPago = value; }
        public decimal Subtotal { get => _subtotal; set => _subtotal = value; }
    }
}
