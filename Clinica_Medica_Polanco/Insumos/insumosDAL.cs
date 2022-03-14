using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Clinica_Medica_Polanco.Insumos;
using System.Windows;
using System.Windows.Controls;

namespace Clinica_Medica_Polanco.Insumos
{
    class insumosDAL
    {

        public static void AgregarInsumo(Insumos nuevoInsumo)
        {
            try
            {
                //Validación de datos
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Insumos_Insert", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codigo_Categoria_Insumo", SqlDbType.Int).Value = nuevoInsumo.CodigoCategoriaInsumo;
                comando.Parameters.AddWithValue("Nombre_Insumo", SqlDbType.VarChar).Value = nuevoInsumo.NombreInsumo;
                comando.Parameters.AddWithValue("Fecha_Expiracion", SqlDbType.DateTime).Value = nuevoInsumo.FechaExpiracion;
                comando.Parameters.AddWithValue("Precio_Unitario", SqlDbType.Money).Value = nuevoInsumo.PrecioUnitario;
                comando.Parameters.AddWithValue("Numero_Serie", SqlDbType.VarChar).Value = nuevoInsumo.NumeroSerie;
                comando.Parameters.AddWithValue("Estado_Insumo", SqlDbType.Bit).Value = nuevoInsumo.Estado;
                comando.ExecuteReader();
                MessageBox.Show("Insumo agregado exitosamente");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al ingresar insumo " + error.Message);

            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static int obtenerIdInsumo(string numSerie)
        {
            int codInsumo = 0;
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new(string.Format("select Codigo_Insumo from Insumos where Numero_Serie = {0}", numSerie), ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while(dr.Read())
                {
                    codInsumo = dr.GetInt32(0);
                }
                return codInsumo; 
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al buscar el id de insumo " + error.Message);
                return -1;
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
        public static List<Insumos> BuscarInsumos(string pDato)
        {
            try
            {
                //Validación de datos
                List<Insumos> Lista = new List<Insumos>();
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("SELECT Codigo_Insumo, Codigo_Categoria_Insumo, Nombre_Insumo, Fecha_Expiracion, Precio_Unitario, Numero_Serie, Estado_Insumo FROM Insumos WHERE Nombre_Insumo = @nombreInsumo OR Codigo_Insumo = @codInsumo");
                comando.Parameters.AddWithValue("nombreInsumo", pDato);
                comando.Parameters.AddWithValue("codInsumo", int.Parse(pDato));
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Insumos nuevoInsumo = new();
                    nuevoInsumo.CodigoInsumo = reader.GetInt32(0);
                    nuevoInsumo.CodigoCategoriaInsumo = reader.GetInt32(1);
                    nuevoInsumo.NombreInsumo = reader.GetString(2);
                    nuevoInsumo.FechaExpiracion = reader.GetDateTime(3);
                    nuevoInsumo.PrecioUnitario = reader.GetDecimal(4);
                    nuevoInsumo.NumeroSerie = reader.GetString(5);
                    nuevoInsumo.Estado = reader.GetBoolean(6);
                    Lista.Add(nuevoInsumo);
                }
                return Lista;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al encontrar insumos" + err.Message);
                return new List<Insumos>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
        public static Insumos BuscarInsumoPorNombreOId(int pDato)
        {

            try
            {
                //Validación de datos

                ConexionBaseDeDatos.ObtenerConexion();
                Insumos consultaInsumos = new();
                SqlCommand comando = new SqlCommand(String.Format("Select * from Insumos where Codigo_Insumo = {0}", pDato), ConexionBaseDeDatos.conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    consultaInsumos.CodigoInsumo = reader.GetInt32(0);
                    consultaInsumos.CodigoCategoriaInsumo = reader.GetInt32(1);
                    consultaInsumos.NombreInsumo = reader.GetString(2);
                    consultaInsumos.FechaExpiracion = reader.GetDateTime(3);
                    consultaInsumos.PrecioUnitario = reader.GetDecimal(4);
                    consultaInsumos.NumeroSerie = reader.GetString(5);
                    consultaInsumos.Estado = reader.GetBoolean(6);
                }
                return consultaInsumos;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al buscar el insumo", error.Message);
                return new Insumos();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static void ModificarInsumo(Insumos vInsumo)
        {
            try
            {
                //Validación de datos
                
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Insumos_Update", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codigo_Insumo", SqlDbType.Int).Value = vInsumo.CodigoInsumo;
                comando.Parameters.AddWithValue("Codigo_Categoria_Insumo", SqlDbType.Int).Value = vInsumo.CodigoCategoriaInsumo;
                comando.Parameters.AddWithValue("Nombre_Insumo", SqlDbType.VarChar).Value = vInsumo.NombreInsumo;
                comando.Parameters.AddWithValue("Fecha_Expiracion", SqlDbType.DateTime).Value = vInsumo.FechaExpiracion;
                comando.Parameters.AddWithValue("Precio_Unitario", SqlDbType.Money).Value = vInsumo.PrecioUnitario;
                comando.Parameters.AddWithValue("Numero_Serie", SqlDbType.VarChar).Value = vInsumo.NumeroSerie;
                comando.Parameters.AddWithValue("Estado_Insumo", SqlDbType.Bit).Value = vInsumo.Estado;
                comando.ExecuteReader();
                MessageBox.Show("Insumo actualizado correctamente");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al modificar insumos", error.Message);
                
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }

        }

        public static Insumos obtenerInfoStock(int codInsumo)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                Insumos consultaInsumos = new();
                SqlCommand comando = new SqlCommand("Stock_Info", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cod_Insumo", SqlDbType.Int).Value = codInsumo;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    consultaInsumos.CodigoInsumo = reader.GetInt32(0);
                    consultaInsumos.NombreInsumo = reader.GetString(1);
                    consultaInsumos.DescripcionCategoriaInsumo = reader.GetString(2);
                    consultaInsumos.FechaExpiracion = reader.GetDateTime(3);
                    consultaInsumos.NumeroSerie = reader.GetString(4);
                    consultaInsumos.Estado = reader.GetBoolean(5);
                    consultaInsumos.Existencia = reader.GetInt32(6);
                    consultaInsumos.PrecioUnitario = reader.GetDecimal(7);
                }

                return consultaInsumos;
            }
            catch
            {
                MessageBox.Show("No se ha encontrado ningun producto");
                return new Insumos();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static List<String> obtenerInfoStockSucursal(int codInsumo)
        {
            try
            {
                //Validación de datos
                ConexionBaseDeDatos.ObtenerConexion();
                List<string> informacion = new();
                SqlCommand comando = new SqlCommand("Stock_Info_Sucursal", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cod_Insumo", SqlDbType.Int).Value = codInsumo;
                SqlDataReader dr =  comando.ExecuteReader();
                while(dr.Read())
                {
                    informacion.Add(dr.GetString(1) + " -> " + dr.GetInt32(2));
                }
                return informacion;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al eliminar los datos ", error.Message);
                return new List<string>();
            }
            finally
            {

                ConexionBaseDeDatos.CerrarConexion();
            }
        }
        public static void EliminarInsumo(int codigoInsumo)
        {
            try
            {
                //Validación de datos
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("insumos_Delete", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codigo_Insumos", SqlDbType.Int).Value=codigoInsumo;
                comando.ExecuteReader();
                MessageBox.Show("Insumo deshabilitado exitosamente");
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


        public static void CargarTipoInsumo(ComboBox cmb_Tipo_Insumo)
        {

            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                string Query = "select Codigo_Categoria_Insumo,Descripcion_Categoria_Insumo from Categoria_Insumos";
                SqlCommand createCommand = new (cmdText: Query, ConexionBaseDeDatos.conexion);
                SqlDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr.GetString(1);
                    cmb_Tipo_Insumo.Items.Add(nombre);
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
