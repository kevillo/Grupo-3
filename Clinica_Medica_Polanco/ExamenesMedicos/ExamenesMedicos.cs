using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.ExamenesMedicos
{
    public class ExamenesMedicos
    {
        //Estableciendo datos
        private int _codigoExamen;
        private int _codSucursal;
        private string _nombreSucursal;
        private string _tipoExamen;
        private int _codigoTipoExamen;
        private decimal _precioUnitario;
        private bool _estado;

        // validación string: que no venga vacío
        // validación int: que no sea negativo ni que venga vacío
        // validación para strings que ocupan un número: que no esté vacío y que solo se ingrese un número

        //Validación de datos
        public int CodigoExamen { get => _codigoExamen; set => _codigoExamen = value; }
        public string TipoExamen
        {
            get => _tipoExamen;
            set {
                //Valida que la cadena no está vacía
                if (string.IsNullOrEmpty(value)) throw new FormatException();
                else _tipoExamen = value;
            }
        }
        public decimal PrecioUnitario { get => _precioUnitario; set => _precioUnitario = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public int CodSucursal { get => _codSucursal; set => _codSucursal = value; }
        public string NombreSucursal { get => _nombreSucursal; set => _nombreSucursal = value; }
        public int CodigoTipoExamen { get => _codigoTipoExamen; set => _codigoTipoExamen = value; }
    }
}
