using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Clinica_Medica_Polanco.servicios
{
    class serviciosDAL
    {
        public static string traerNombreFacturador(int codEmpleado)
        {
            try
            {
                string nombre = "";
                ConexionBaseDeDatos.ObtenerConexion();
                Servicios nuevoServicios = new();
                SqlCommand comando = new(string.Format("Select CONCAT(Empleados.Nombre_Empleado,' ',Empleados.Apellido_Empleado) from Empleados where Codigo_Empleado = {0}", codEmpleado), ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    nombre = dr.GetString(0);
                }
                return nombre;

            }
            catch
            {
                MessageBox.Show("No se puede cargar el nombre del Facturador");
                return "";
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static string traerNombrePaciente(int codPaciente)
        {
            try
            {
                string nombre = "";
                ConexionBaseDeDatos.ObtenerConexion();
                Servicios nuevoServicios = new();
                SqlCommand comando = new(string.Format("Select CONCAT(Pacientes.Nombre_Paciente,' ',Pacientes.Apellido_Paciente) from Pacientes where Codigo_Paciente = {0}", codPaciente), ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    nombre = dr.GetString(0);
                }
                return nombre;

            }
            catch
            {
                MessageBox.Show("No se puede cargar el nombre del Paciente");
                return "";
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static string traerNombreExamen(int codExamenMedico)
        {
            try
            {
                string nombre = "";
                ConexionBaseDeDatos.ObtenerConexion();
                Servicios nuevoServicios = new();
                SqlCommand comando = new(string.Format("Select Tipos_Examenes_Medicos.Descripcion_Tipo_Examen from Tipos_Examenes_Medicos inner join Examenes_Medicos on Examenes_Medicos.Codigo_Tipo_Examen = Tipos_Examenes_Medicos.Codigo_Tipo_Examen where Cod_Examen_Medico = {0}", codExamenMedico), ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    nombre = dr.GetString(0);
                }
                return nombre;

            }
            catch
            {
                MessageBox.Show("No se puede cargar el nombre del examen médico");
                return "";
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static string traerNombreMetodoEntrega(int codMetodoEntrega)
        {
            try
            {
                string nombre = "";
                ConexionBaseDeDatos.ObtenerConexion();
                Servicios nuevoServicios = new();
                SqlCommand comando = new(string.Format("Select Metodos_Entrega.Descripcion_Metodo_Entrega from Metodos_Entrega where Codigo_Metodo_Entrega = {0}", codMetodoEntrega), ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    nombre = dr.GetString(0);
                }
                return nombre;

            }
            catch
            {
                MessageBox.Show("No se puede cargar el nombre de método entrega");
                return "";
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static string traerNombreMetodoPago(int codMetodoPago)
        {
            try
            {
                string nombre = "";
                ConexionBaseDeDatos.ObtenerConexion();
                Servicios nuevoServicios = new();
                SqlCommand comando = new(string.Format("Select Metodos_Pagos.Descripcion_Metodo_Pago from Metodos_Pagos where Codigo_Metodo_Pago ={0}", codMetodoPago), ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    nombre = dr.GetString(0);
                }
                return nombre;

            }
            catch
            {
                MessageBox.Show("No se puede cargar el nombre de método pago");
                return "";
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
    }
}
