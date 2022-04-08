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

        //Función para validar el número de serie del insumo
        public static int ValidadNumeroSerieInsumo(string numSerie)
        {
            try
            {
                int coincidencias = 0;
                ConexionBaseDeDatos.ObtenerConexion(); //Estableciendo conexión con la base de datos
                SqlCommand comando = new(string.Format("select count(Codigo_Insumo) from Insumos where Numero_Serie = '{0}'", numSerie), ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    coincidencias = dr.GetInt32(0);
                }
                return coincidencias;
            }
            catch (Exception) //Excepción que indicará si ocurre un error, mostraría el mensaje siguiente
            {
                MessageBox.Show("No se pudo comprobar si el número de serie ya existe en la base de datos.");
                return -1;
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion(); //Cerrando conexión con la base de datos
            }
        }

        //Función para agregar nuevos insumos
        public static void AgregarInsumo(Insumos nuevoInsumo)
        {
            try
            {
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
                MessageBox.Show("Insumo agregado exitosamente.");
            }
            catch (Exception error) //Excepción que indicará si ocurre un error, mostraría el mensaje siguiente
            {
                MessageBox.Show("No se pudo agregar el insumo debido a un error." + error.Message);
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
        
        //Función para obtener el código del insumo
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
            catch (Exception error) //Excepción que indicará si ocurre un error, mostraría el mensaje siguiente
            {
                MessageBox.Show("No se pudo buscar el código del insumo debido a un error." + error.Message);
                return -1;
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        //Creación de lista para buscar insumos
        public static List<Insumos> BuscarInsumos(string pDato)
        {
            try
            {
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
                return Lista; //Retorno de lista
            }
            catch (Exception err) //Excepción que indicará si ocurre un error, mostraría el mensaje siguiente
            {
                MessageBox.Show("No se pudo encontrar el insumo debido a un error." + err.Message);
                return new List<Insumos>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        //Función para buscar el insumo por código
        public static Insumos BuscarInsumoPorNombreOId(int pDato)
        {
            try
            {
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
            catch (Exception error) //Excepción que indicará si ocurre un error, mostraría el mensaje siguiente
            {
                MessageBox.Show("No se pudo buscar el insumo debido a un error.", error.Message);
                return new Insumos();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        //Función para modificar o actulizar los insumos
        public static void ModificarInsumo(Insumos vInsumo)
        {
            try
            {  
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
                MessageBox.Show("Insumo actualizado correctamente.");
            }
            catch (Exception error) //Excepción que indicará si ocurre un error, mostraría el mensaje siguiente
            {
                MessageBox.Show("No se pudo actualizar insumo debido a un error.", error.Message);     
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        //Función para obtener la información del stock
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
            catch //Excepción que indicará si ocurre un error, mostraría el mensaje siguiente
            {
                MessageBox.Show("No se ha podido encontrar ningún insumo.");
                return new Insumos();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        //Creación de lista para obtener la información del stock por sucursal
        public static List<String> obtenerInfoStockSucursal(int codInsumo)
        {
            try
            {
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
                return informacion; //Retorno de lista
            }
            catch (Exception error) //Excepción que indicará si ocurre un error, mostraría el mensaje siguiente
            {
                MessageBox.Show("No se pudo eliminar los datos debido a un error.", error.Message);
                return new List<string>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        //Función para deshabilitar insumos
        public static void EliminarInsumo(int codigoInsumo)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("insumos_Delete", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codigo_Insumos", SqlDbType.Int).Value=codigoInsumo;
                comando.ExecuteReader();
                MessageBox.Show("Insumo deshabilitado exitosamente.");
            }
            catch (Exception error) //Excepción que indicará si ocurre un error, mostraría el mensaje siguiente
            {
                MessageBox.Show("No se pudo deshabilitar insumo debido a un error.", error.Message);
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        //Función para cargar el tipo de insumo
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
            catch (Exception ex) //Excepción que indicará si ocurre un error
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
