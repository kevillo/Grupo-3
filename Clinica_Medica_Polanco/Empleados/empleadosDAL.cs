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
                                                   "@fechaNacimientoEmpleado," +
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

                comando.Parameters.AddWithValue("codigoJornada", empleados.CodigoJornada);
                comando.Parameters.AddWithValue("codigoPuesto", empleados.CodigoPuesto);
                comando.Parameters.AddWithValue("idUsuario", empleados.IdUsuario);
                comando.Parameters.AddWithValue("nombreEmpleado", empleados.NombreEmpleado);
                comando.Parameters.AddWithValue("identidadEmpleado", empleados.IdentidadEmpleado);
                comando.Parameters.AddWithValue("telefonoEmpleado", empleados.TelefonoEmpleado);
                comando.Parameters.AddWithValue("fechaNacimientoEmpleado", empleados.FechaNacimientoEmpleado);
                comando.Parameters.AddWithValue("correoEmpleado", empleados.CorreoEmpleado);
                comando.Parameters.AddWithValue("alturaEmpleado", empleados.AlturaEmpleado);
                comando.Parameters.AddWithValue("tipoSangreEmpleado", empleados.TipoSangreEmpleado);
                comando.Parameters.AddWithValue("direccionEmpleado", empleados.DireccionEmpleado);
                comando.Parameters.AddWithValue("apellidoEmpleado", empleados.ApellidoEmpleado);
                comando.Parameters.AddWithValue("estadoEmpleado", "True");
                comando.Parameters.AddWithValue("fechaContratacion", empleados.FechaContratacion);
                comando.Parameters.AddWithValue("fechaContratacion", empleados.FechaContratacion);
                comando.Parameters.AddWithValue("sueldoBase", empleados.SueldoBase);
                comando.Parameters.AddWithValue("codigoSucursal", empleados.CodigoSucursal);
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

        public static List<Empleados> BuscarEmpleado(string pDato)
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

        public static Empleados buscarEmpleadoPorId(Int64 codigoEmpleado)
        {
            try
            {
                Empleados nuevoEmpleado = new();
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("WHERE Codigo_Empleado = @codigoEmpleado",ConexionBaseDeDatos.conexion);
                comando.Parameters.AddWithValue("codigoEmpleado", codigoEmpleado);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {

                    //aqui vas a poner cada uno de los campos de la clase empledos y seguis el ejemplo de pacientesDAL 
                }
                return nuevoEmpleado;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al buscar el empleado", error.Message);
                return new Empleados();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static int modificarEmpleado(Empleados empleados)
        {
            try
            {
                int retorno = 0;
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("exec Empleados_Update" +
                                                   "@CodigoEmpleado"+
                                                   "@codigoJornada ," +
                                                   "@codigoPuesto," +
                                                   "@idUsuario," +
                                                   "@nombreEmpleado," +
                                                   "@identidadEmpleado," +
                                                   "@telefonoEmpleado," +
                                                   "@fechaNacimientoEmpleado," +
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
                comando.Parameters.AddWithValue("CodigoEmpleado", empleados.CodigoEmpleado);
                comando.Parameters.AddWithValue("codigoJornada", empleados.CodigoJornada);
                comando.Parameters.AddWithValue("codigoPuesto", empleados.CodigoPuesto);
                comando.Parameters.AddWithValue("idUsuario", empleados.IdUsuario);
                comando.Parameters.AddWithValue("nombreEmpleado", empleados.NombreEmpleado);
                comando.Parameters.AddWithValue("identidadEmpleado", empleados.IdentidadEmpleado);
                comando.Parameters.AddWithValue("telefonoEmpleado", empleados.TelefonoEmpleado);
                comando.Parameters.AddWithValue("fechaNacimientoEmpleado", empleados.FechaNacimientoEmpleado);
                comando.Parameters.AddWithValue("correoEmpleado", empleados.CorreoEmpleado);
                comando.Parameters.AddWithValue("alturaEmpleado", empleados.AlturaEmpleado);
                comando.Parameters.AddWithValue("tipoSangreEmpleado", empleados.TipoSangreEmpleado);
                comando.Parameters.AddWithValue("direccionEmpleado", empleados.DireccionEmpleado);
                comando.Parameters.AddWithValue("apellidoEmpleado", empleados.ApellidoEmpleado);
                comando.Parameters.AddWithValue("estadoEmpleado", empleados.EstadoEmpleado);
                comando.Parameters.AddWithValue("fechaContratacion", empleados.FechaContratacion);
                comando.Parameters.AddWithValue("fechaContratacion", empleados.FechaContratacion);
                comando.Parameters.AddWithValue("sueldoBase", empleados.SueldoBase);
                comando.Parameters.AddWithValue("codigoSucursal", empleados.CodigoSucursal);

                retorno = comando.ExecuteNonQuery();
                return retorno;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al modificar empleados ", error.Message);
                return -1;
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }

        }


        public static int eliminarEmpleado(Int64 codigoEmpleado)
        {
            try
            {
                int retorno = 0;
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Delete from Empleados where Codigo_Empleado = @codEmpleado", ConexionBaseDeDatos.conexion);
                comando.Parameters.AddWithValue("codEmpleado", codigoEmpleado);

                retorno = comando.ExecuteNonQuery();
                return retorno;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al eliminar los datos ", error.Message);
                return -1;
            }
            finally
            {

                ConexionBaseDeDatos.CerrarConexion();
            }

        }


    }

}
