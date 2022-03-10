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
                SqlCommand comando = new SqlCommand();
                comando.Connection = ConexionBaseDeDatos.conexion;
                comando.CommandText = "Empleados_Insert @codigoJornada";

                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("codigoJornada", empleados.CodigoJornada);
                comando.Parameters.AddWithValue("codigoPuesto", empleados.CodigoPuesto);
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
                comando.Parameters.AddWithValue("fechaPago", empleados.FechaPago);
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
                SqlCommand comando = new SqlCommand("Select Codigo_Empleado, Codigo_Jornada, Codigo_puesto, Nombre_Empleado, Apellido_Empleado, Identidad_Empleado, Telefono_Empleado, Fecha_Nacimiento_Empleado, Correo_Empleado, Altura_Empleado(Cm), Tipo_Sangre_Empleado, Direccion_Empleado, Estado_Empleado, Codigo_Sucursal, Fecha_Contratacion, Fecha_Pago, Sueldo_Base From Empleados");
                comando.Parameters.AddWithValue("nombreEmpleado", pDato);
                comando.Parameters.AddWithValue("identidadEmpleado", pDato);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Empleados eEmpleados = new Empleados();
                    eEmpleados.CodigoEmpleado = reader.GetInt32(0);
                    eEmpleados.CodigoJornada = reader.GetInt32(1);
                    eEmpleados.CodigoPuesto = reader.GetInt32(2);
                    eEmpleados.NombreEmpleado = reader.GetString(3);
                    eEmpleados.ApellidoEmpleado = reader.GetString(4);
                    eEmpleados.IdentidadEmpleado = reader.GetString(5);
                    eEmpleados.TelefonoEmpleado = reader.GetString(6);
                    eEmpleados.FechaNacimientoEmpleado = reader.GetDateTime(7);
                    eEmpleados.CorreoEmpleado = reader.GetString(8);
                    eEmpleados.AlturaEmpleado = reader.GetInt32(9);
                    eEmpleados.TipoSangreEmpleado = reader.GetString(10);
                    eEmpleados.DireccionEmpleado = reader.GetString(11);
                    eEmpleados.EstadoEmpleado = reader.GetBoolean(12);
                    eEmpleados.CodigoSucursal = reader.GetInt32(13);
                    eEmpleados.FechaContratacion = reader.GetDateTime(14);
                    eEmpleados.FechaPago = reader.GetDateTime(15);
                    eEmpleados.SueldoBase = reader.GetDecimal(16);
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
                    Empleados eEmpleados = new Empleados();
                    eEmpleados.CodigoEmpleado = reader.GetInt32(0);
                    eEmpleados.CodigoJornada = reader.GetInt32(1);
                    eEmpleados.CodigoPuesto = reader.GetInt32(2);
                    eEmpleados.NombreEmpleado = reader.GetString(3);
                    eEmpleados.ApellidoEmpleado = reader.GetString(4);
                    eEmpleados.IdentidadEmpleado = reader.GetString(5);
                    eEmpleados.TelefonoEmpleado = reader.GetString(6);
                    eEmpleados.FechaNacimientoEmpleado = reader.GetDateTime(7);
                    eEmpleados.CorreoEmpleado = reader.GetString(8);
                    eEmpleados.AlturaEmpleado = reader.GetInt32(9);
                    eEmpleados.TipoSangreEmpleado = reader.GetString(10);
                    eEmpleados.DireccionEmpleado = reader.GetString(11);
                    eEmpleados.EstadoEmpleado = reader.GetBoolean(12);
                    eEmpleados.CodigoSucursal = reader.GetInt32(13);
                    eEmpleados.FechaContratacion = reader.GetDateTime(14);
                    eEmpleados.FechaPago = reader.GetDateTime(15);
                    eEmpleados.SueldoBase = reader.GetDecimal(16);
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
