using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using Clinica_Medica_Polanco.Proveedores;

namespace Clinica_Medica_Polanco.Proveedores
{
    class ProveedoresDAL
    {
        public static void AgregarProveedor(Proveedores proveedores)
        {
            try
            {
                //Validación datos
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Proveedores_Insert", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codigo_Area_Trabajo", SqlDbType.Int).Value = proveedores.CodigoAreaTrabajo;
                comando.Parameters.AddWithValue("Nombre_Proveedor", SqlDbType.VarChar).Value = proveedores.NombreProveedor;
                comando.Parameters.AddWithValue("Apellido_Proveedor", SqlDbType.VarChar).Value = proveedores.ApellidoProveedor;
                comando.Parameters.AddWithValue("Direccion_Proveedor", SqlDbType.VarChar).Value = proveedores.DireccionProveedor;
                comando.Parameters.AddWithValue("Correro_Proveedor", SqlDbType.VarChar).Value = proveedores.CorreoProveedor;
                comando.Parameters.AddWithValue("Telefono_Proveedor", SqlDbType.VarChar).Value = proveedores.TelefonoProveedor;
                comando.Parameters.AddWithValue("Estado_Proveedor", SqlDbType.Bit).Value = "True";
                comando.ExecuteReader();
                MessageBox.Show("Proveedor agregado exitosamente");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al ingresar proveedor " + error.Message);
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
        public static List<Proveedores> BuscarProveedor(string pDato)
        {


            try
            {
                //Validación datos
                List<Proveedores> Lista = new List<Proveedores>();
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Select Codigo_Proveedor, Codigo_Area_Trabajo, Nombre_Proveedor, Apellido_Proveedor, Direccion_Proveedor, Correo_Proveedor, Telefono_Proveedor, Estado_Proveedor From Proveedores");
                comando.Parameters.AddWithValue("nombreProveedor", pDato);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Proveedores pProveedores = new Proveedores();
                    pProveedores.CodigoProveedor = reader.GetInt32(0);
                    pProveedores.NombreProveedor = reader.GetString(1);
                    pProveedores.ApellidoProveedor = reader.GetString(2);
                    pProveedores.DireccionProveedor = reader.GetString(3);
                    pProveedores.CorreoProveedor = reader.GetString(4);
                    pProveedores.TelefonoProveedor = reader.GetString(5);
                    pProveedores.EstadoProveedor = reader.GetBoolean(6);
                }
                return Lista;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al actualizar" + err.Message);
                return new List<Proveedores>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static Proveedores buscarProveedorPorId(Int64 codigoProveedor)
        {
            try
            {
                //Validación de datos
                Proveedores nuevoProveedor = new();
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("WHERE Codigo_Proveedor = @codigoProveedor", ConexionBaseDeDatos.conexion);
                comando.Parameters.AddWithValue("codigoProveedor", codigoProveedor);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Proveedores pProveedores = new Proveedores();
                    pProveedores.CodigoProveedor = reader.GetInt32(0);
                    pProveedores.NombreProveedor = reader.GetString(1);
                    pProveedores.ApellidoProveedor = reader.GetString(2);
                    pProveedores.DireccionProveedor = reader.GetString(3);
                    pProveedores.CorreoProveedor = reader.GetString(4);
                    pProveedores.TelefonoProveedor = reader.GetString(5);
                    pProveedores.EstadoProveedor = reader.GetBoolean(6);
                }
                return nuevoProveedor;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al buscar el proveedor", error.Message);
                return new Proveedores();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
        public static void modificarProveedor(Proveedores proveedores)
        {
            try
            {
                //Validación datos
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Proveedores_Update", ConexionBaseDeDatos.conexion);
                comando.Parameters.AddWithValue("Codigo_Proveedor", SqlDbType.Int).Value = proveedores.CodigoProveedor;
                comando.Parameters.AddWithValue("Codigo_Area_Trabajo", SqlDbType.VarChar).Value = proveedores.CodigoAreaTrabajo;
                comando.Parameters.AddWithValue("Nombre_Proveedor", SqlDbType.VarChar).Value = proveedores.NombreProveedor;
                comando.Parameters.AddWithValue("Apellido_Proveedor", SqlDbType.VarChar).Value = proveedores.ApellidoProveedor;
                comando.Parameters.AddWithValue("Direccion_Proveedor", SqlDbType.VarChar).Value = proveedores.DireccionProveedor;
                comando.Parameters.AddWithValue("Correro_Proveedor", SqlDbType.VarChar).Value = proveedores.CorreoProveedor;
                comando.Parameters.AddWithValue("Telefono_Proveedor", SqlDbType.VarChar).Value = proveedores.TelefonoProveedor;
                comando.Parameters.AddWithValue("Estado_Proveedor", SqlDbType.Bit).Value = "True";
                comando.ExecuteNonQuery();
                MessageBox.Show("Proveedor actualizado exitosamente");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al actualizar proveedores", error.Message);
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
        public static int eliminarProveedor(Int64 codigoProveedor)
        {
            try
            {
                int retorno = 0;
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Delete from Proveedores where Codigo_Proveedores = @codProveedor", ConexionBaseDeDatos.conexion);
                comando.Parameters.AddWithValue("codProveedor", codigoProveedor);

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
        //Función para cargar datos desde la bd al combobox ÁreaTrabajo 
        public static void cargarAreaTrabajo(ComboBox cmb_Area_Trabajo_Proveedor_Agregar)
        {

            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                string Query = "Select Codigo_Areas, Nombre_Area from Areas_Trabajos";
                SqlCommand createCommand = new SqlCommand(cmdText: Query, ConexionBaseDeDatos.conexion);
                SqlDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr.GetString(1);
                    cmb_Area_Trabajo_Proveedor_Agregar.Items.Add(nombre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
    }
}

