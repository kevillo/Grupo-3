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
        //Función para traer el nombre del facturador
        public static string traerNombreFacturador(int codEmpleado)
        {
            try
            {
                string nombre = "";
                ConexionBaseDeDatos.ObtenerConexion(); //Estableciendo conexión con la base de datos
                Servicios nuevoServicios = new();
                SqlCommand comando = new(string.Format("Select CONCAT(Empleados.Nombre_Empleado,' ',Empleados.Apellido_Empleado) from Empleados where Codigo_Empleado = {0}", codEmpleado), ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    nombre = dr.GetString(0);
                }
                return nombre;

            }
            catch //Excepción que nos indicará si hay un error, en caso de que sí, mostrará el siguiente mensaje
            {
                MessageBox.Show("No se pudo cargar el nombre del facturador debido a un error.");
                return "";
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion(); //Cerrando conexión con la base de datos
            }
        }

        //Función para traer el nombre del paciente
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
            catch //Excepción que nos indicará si hay un error, en caso de que sí, mostrará el siguiente mensaje
            {
                MessageBox.Show("No se pudo cargar el nombre del paciente debido a un error.");
                return "";
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        //Función para traer el nombre del examen
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
            catch //Excepción que nos indicará si hay un error, en caso de que sí, mostrará el siguiente mensaje
            {
                MessageBox.Show("No se puede cargar el nombre del examen médico debido a un error.");
                return "";
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        //Función para trtaer el nombre del método de entrega del examen
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
            catch //Excepción que nos indicará si hay un error, en caso de que sí, mostrará el siguiente mensaje
            {
                MessageBox.Show("No se puede cargar el nombre de método entrega debido a un error.");
                return "";
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        //Función para traer el nombre del método de pago
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
            catch //Excepción que nos indicará si hay un error, en caso de que sí, mostrará el siguiente mensaje
            {
                MessageBox.Show("No se puede cargar el nombre de método pago debido a un error.");
                return "";
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
    }
}
