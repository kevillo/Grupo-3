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
                comando.Parameters.AddWithValue("Estado_Proveedor", SqlDbType.Bit).Value = proveedores.EstadoProveedor;
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
        public static List<proveedoresVentas> BuscarProveedor(string pDato)
        {
            try
            {
                //Validación datos
                List<proveedoresVentas> Lista = new List<proveedoresVentas>();
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand(String.Format("Select Inventario.Codigo_Insumo,Insumos.Nombre_Insumo,Proveedores.Nombre_Proveedor,Sucursales.Nombre_Sucursal,Inventario.Existencia, " +
                                                    "Inventario.Fecha_Ingreso, Inventario.Inventario_Año, Inventario.Inventario_Mes, Inventario.numero_lote from Inventario " +
                                                    " inner join Proveedores on Proveedores.Codigo_Proveedor = Inventario.Codigo_Proveedor " +
                                                    " inner join Insumos on insumos.Codigo_Insumo = Inventario.Codigo_Insumo " +
                                                    " inner join Sucursales on Inventario.Codigo_Sucursal = Sucursales.Codigo_Sucursal " +
                                                    " where Inventario.Inventario_Mes = MONTH(GETDATE()) AND Inventario_Año = YEAR(GETDATE()) " +
                                                    " and Proveedores.Codigo_Proveedor = {0}",int.Parse(pDato)), ConexionBaseDeDatos.conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    proveedoresVentas nuevoProveddor = new();
                    nuevoProveddor.CodigoInsumo = reader.GetInt32(0);
                    nuevoProveddor.NombreInsumo = reader.GetString(1);
                    nuevoProveddor.NombreProveedor = reader.GetString(2);
                    nuevoProveddor.NombreSucursal = reader.GetString(3);
                    nuevoProveddor.Existencia = reader.GetInt32(4);
                    nuevoProveddor.FechaIngreso = reader.GetDateTime(5);
                    nuevoProveddor.AnioInventario = reader.GetInt32(6);
                    nuevoProveddor.MesInventario = reader.GetInt32(7);
                    nuevoProveddor.NumeroLote = reader.GetString(8);
                    Lista.Add(nuevoProveddor);
                    
                }
                return Lista;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al consultar" + err.Message);
                return new List<proveedoresVentas>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static Proveedores BuscarProveedorPorId(int pDato)
        {
            try
            {
                //Validación de datos
                Proveedores pProveedores = new Proveedores();               
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand(string.Format("Select Codigo_Proveedor, Codigo_Area_Trabajo,Nombre_Proveedor, Apellido_Proveedor, Direccion_Proveedor, Correro_Proveedor, Telefono_Proveedor,Estado_Proveedor from [dbo].[vProveedoresBuscar] where Codigo_Proveedor = {0}", pDato), ConexionBaseDeDatos.conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    pProveedores.CodigoProveedor = reader.GetInt32(0);
                    pProveedores.CodigoAreaTrabajo = reader.GetInt32(1);
                    pProveedores.NombreProveedor = reader.GetString(2);
                    pProveedores.ApellidoProveedor = reader.GetString(3);
                    pProveedores.DireccionProveedor = reader.GetString(4);
                    pProveedores.CorreoProveedor = reader.GetString(5);
                    pProveedores.TelefonoProveedor = reader.GetString(6);
                    pProveedores.EstadoProveedor = reader.GetBoolean(7);

                }
                return pProveedores;
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
        public static int traerCodigoProveedor(string identidad)
        {
            try
            {
                int codProveedor = 0;
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new(string.Format("Select Codigo_Proveedor from Proveedor where Codigo_Proveedor = '{0}'", identidad), ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    codProveedor = dr.GetInt32(0);
                }
                return codProveedor;
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo encontrar el código del proveedor " + error.Message);
                return -1;
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }

        }
        public static void ModificarProveedor(Proveedores proveedores)
        {
            try
            {
                //Validación datos
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Proveedores_Update", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codigo_Proveedor", SqlDbType.Int).Value = proveedores.CodigoProveedor;
                comando.Parameters.AddWithValue("Codigo_Area_Trabajo", SqlDbType.VarChar).Value = proveedores.CodigoAreaTrabajo;
                comando.Parameters.AddWithValue("Nombre_Proveedor", SqlDbType.VarChar).Value = proveedores.NombreProveedor;
                comando.Parameters.AddWithValue("Apellido_Proveedor", SqlDbType.VarChar).Value = proveedores.ApellidoProveedor;
                comando.Parameters.AddWithValue("Direccion_Proveedor", SqlDbType.VarChar).Value = proveedores.DireccionProveedor;
                comando.Parameters.AddWithValue("Correro_Proveedor", SqlDbType.VarChar).Value = proveedores.CorreoProveedor;
                comando.Parameters.AddWithValue("Telefono_Proveedor", SqlDbType.VarChar).Value = proveedores.TelefonoProveedor;
                comando.Parameters.AddWithValue("Estado_Proveedor", SqlDbType.Bit).Value = proveedores.EstadoProveedor;
                comando.ExecuteReader();
                MessageBox.Show("Proveedor actualizado exitosamente");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al actualizar proveedor", error.Message);
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
        public static void EliminarProveedor(int codigoProveedor)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Proveedores_Delete", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codigo_A_Eliminar", DbType.Int32).Value = codigoProveedor;
                comando.ExecuteReader();
                MessageBox.Show("Proveedor deshabilitado con éxito");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al eliminar los datos ", error.Message);
            }
            finally
            {

                ConexionBaseDeDatos.CerrarConexion();
            }
        }
        //Función para cargar datos desde la bd al combobox ÁreaTrabajo 
        public static void CargarAreaTrabajo(ComboBox cmb_Area_Trabajo_Proveedor_Agregar)
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
        //Cargar datos desde la bd al cmb Proveedores
        public static void CargarProveedores(ComboBox cmb_Gestionar_Insumo_Nombre_Proveedor)
        {

            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                string Query = "Select Nombre_Proveedor from Proveedores";
                SqlCommand createCommand = new SqlCommand(cmdText: Query, ConexionBaseDeDatos.conexion);
                SqlDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr.GetString(0);
                    cmb_Gestionar_Insumo_Nombre_Proveedor.Items.Add(nombre);
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

        public static void cargarEmpleados(ComboBox cmb_Administrador,int codSucursal)
        {

            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                string Query =string.Format("select CONCAT(Nombre_Empleado,' ',Apellido_Empleado) AS [Empleado] from Empleados where Codigo_puesto!=1 AND Codigo_Sucursal = {0}",codSucursal);
                SqlCommand createCommand = new SqlCommand(cmdText: Query, ConexionBaseDeDatos.conexion);
                SqlDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr.GetString(0);
                    cmb_Administrador.Items.Add(nombre);
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

