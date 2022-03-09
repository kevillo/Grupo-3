using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace Clinica_Medica_Polanco.Empleados
{
    public class empleadosDAL
    {
        public static int AgregarEmpleado(Empleados empleados)
        {
            try
            {

                ConexionBaseDeDatos.ObtenerConexion();
                int retorno = 0;
                SqlCommand comando = new SqlCommand("exec Empleados_Insert " +
                                                   "@codigoJornada ," +
                                                   "@codigoPuesto," +
                                                   "@idUsuario," +
                                                   "@nombreEmpleado," +
                                                   "@identidadEmpleado," +
                                                   "@telefonoEmpleado," +
                                                   "@fechaNacimiento_Empleado," +
                                                   "@correoEmpleado," +
                                                   "@alturaEmpleado," +
                                                   "@tipoSangreEmpleado," +
                                                   "@direccionEmpleado," +
                                                   "@apellidoEmpleado," +
                                                   "@estadoEmpleado," +
                                                   "@fechaContratacion," +
                                                   "@fechaPago," +
                                                   "@sueldoBase," +
                                                   "@codigoSucursal", ConexionBaseDeDatos.conexion);

                retorno = comando.ExecuteNonQuery();
                return retorno;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al ingresar empleado " + error.Message);
                return -1;
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static List<Empleados> BuscarPaciente(string pDato)
        {


            try
            {
                List<Empleados> Lista = new List<Empleados>();
                ConexionBaseDeDatos.ObtenerConexion();
                // aqui en la sentencia tenes que poner todos los campos de la tabla empleados, osea un select nombre.. from empleados
                SqlCommand comando = new SqlCommand("where Nombre_Empleado like @nombreEmpleado or Identidad_Empleado=@identidadEmpleado", ConexionBaseDeDatos.conexion);
                comando.Parameters.AddWithValue("nombreEmpleado", pDato);
                comando.Parameters.AddWithValue("identidadEmpleado", pDato);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                   //aqui vas a poner cada uno de los campos de la clase empledos y seguis el ejemplo de pacientesDAL 
                }
                return Lista;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al actualizar" + err.Message);
                return new List<Empleados>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }


        }


    }

}
