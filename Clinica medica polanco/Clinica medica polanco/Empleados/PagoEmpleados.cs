using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_medica_polanco.Empleados
{
    internal class PagoEmpleados
    {
        private int _codEmpleado;
        private int _mesPlantilla;
        private int _añoPlanilla;
        private DateTime _fechaContratacion;
        private DateTime _fechaPago;
        private float _sueldoBase;
        private float _horasExtra;
        private decimal _ihssPorcentaje;
        private decimal _rapPorcentaje;
        private decimal _seguroDeVidaPorcentaje;

        public int CodigoEmpleado
        {
            get => _codEmpleado;
            set
            {
                if (value <= 0) _codEmpleado = 1;
                else _codEmpleado = value;
            }
        }

        public int MesPlantilla
        {
            get => _mesPlantilla;
            set
            {
                if (value <= 0) _mesPlantilla = 1;
                else _mesPlantilla = value;
            }
        }

        public DateTime FechaContratacion { get => _fechaContratacion; set => _fechaContratacion = value; }

        public DateTime FechaPago { get => _fechaPago; set => _fechaPago = value; }

        public float SueldoBase { get => _sueldoBase; set => _sueldoBase = value; }

        public float HorasExtra { get => _horasExtra; set => _horasExtra = value; }
    }
}
