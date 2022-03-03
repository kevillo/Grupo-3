using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_medica_polanco.Pacientes
{
    public class Paciente
    {
        public int Codigo { set; get; }
        public String Nombre { set; get; }
        public String Apellido { set; get; }
        public String Identidad { set; get; }
        public String Telefono { set; get; }
        public DateTime FechaNacimiento { set; get; }
        public String Correo { set; get; }
        public int Altura { set; get; }
        public String TipoSangre { set; get; }
        public String Direccion { set; get; }
        public bool Estado { set; get; }

        public Paciente() { }

        public Paciente(int pCodigo, String pNombre, String pApellido, String pIdentidad, String pTelefono, DateTime pFechaNacimiento, String pCorreo, int pAltura, String pTipoSangre, String pDireccion, bool pEstado)
        {
            this.Codigo = pCodigo;
            this.Nombre = pNombre;
            this.Apellido = pApellido;
            this.Identidad = pIdentidad;
            this.Telefono = pTelefono;
            this.FechaNacimiento = pFechaNacimiento;
            this.Correo = pCorreo;
            this.Altura = pAltura;
            this.TipoSangre = pTipoSangre;
            this.Direccion = pDireccion;
            this.Estado = pEstado;
        }
    }
}
