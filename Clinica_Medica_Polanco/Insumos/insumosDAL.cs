using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Clinica_Medica_Polanco.Insumos;
using System.Windows;


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
        public static Insumos BuscarInsumoPorNombreOId(string pDato)
        {

            try
            {
                //Validación de datos
                Insumos consultaInsumos = new();
                Proveedores.Proveedores consultaProveedor = new();
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand(String.Format("Select * from [dbo].[vEliminarProductoBuscar] where Codigo_Insumo = '{0}'", pDato), ConexionBaseDeDatos.conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    consultaInsumos.NombreInsumo = reader.GetString(0);
                    consultaProveedor.NombreProveedor = reader.GetString(1);
                    consultaInsumos.PrecioUnitario = reader.GetDecimal(2);
                    consultaInsumos.NumeroSerie = reader.GetString(3);
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

        public static int ModificarInsumo(Insumos vInsumo)
        {
            try
            {
                //Validación de datos
                int retorno = 0;
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("exec Insumos_Update", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Codigo_Insumo", SqlDbType.Int).Value = vInsumo.CodigoInsumo;
                comando.Parameters.AddWithValue("@Codigo_Categoria_Insumo", SqlDbType.Int).Value = vInsumo.CodigoCategoriaInsumo;
                comando.Parameters.AddWithValue("@Nombre_Insumo", SqlDbType.VarChar).Value = vInsumo.NombreInsumo;
                comando.Parameters.AddWithValue("@Fecha_Expiracion", SqlDbType.DateTime).Value = vInsumo.FechaExpiracion;
                comando.Parameters.AddWithValue("@Precio_Unitario", SqlDbType.Money).Value = vInsumo.PrecioUnitario;
                comando.Parameters.AddWithValue("@Numero_Serie", SqlDbType.VarChar).Value = vInsumo.NumeroSerie;
                comando.Parameters.AddWithValue("@Estado_Insumo", SqlDbType.Bit).Value = vInsumo.Estado;
                retorno = comando.ExecuteNonQuery();
                return retorno;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al modificar insumos", error.Message);
                return -1;
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }

        }

        public static int EliminarInsumo(Int64 codigoInsumo)
        {
            try
            {
                //Validación de datos
                int retorno = 0;
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Delete from Insumos Codigo_Insumo where = @codInsumo", ConexionBaseDeDatos.conexion);
                comando.Parameters.AddWithValue("codInsumo", codigoInsumo);
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
