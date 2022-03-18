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
                string nombre="";
                ConexionBaseDeDatos.ObtenerConexion();
                Servicios nuevoServicios = new();
                SqlCommand comando = new(string.Format("select CONCAT(Empleados.Nombre_Empleado,' ',Empleados.Apellido_Empleado) from Empleados where Codigo_Empleado = {0}", codEmpleado), ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while(dr.Read())
                {
                    nombre = dr.GetString(0);
                }
                return nombre;

            }
            catch
            {
                MessageBox.Show("No se puede cargar el nombre del facturador");
                return "";
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
    }
}
