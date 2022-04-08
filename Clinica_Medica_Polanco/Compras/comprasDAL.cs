using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
namespace Clinica_Medica_Polanco.Compras
{
    class comprasDAL
    {
        //Función de una lista para obtener la información de las compras realizadas 
        public static List<comprasRealizadas> obtenerInfoCompras(int codSucursal)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion(); //Estableciendo la conexión con la base de datos
                List<comprasRealizadas> lista = new();
                SqlCommand comando = new("compras_realizadas", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cod_Sucursal", SqlDbType.Int).Value = codSucursal;
                SqlDataReader dr = comando.ExecuteReader();
                while(dr.Read())
                {
                    comprasRealizadas nuevCompra = new();
                    nuevCompra.CodFacturaCompra = dr.GetInt32(0);
                    nuevCompra.NombreSucursal = dr.GetString(1);
                    nuevCompra.NombreAdministrador = dr.GetString(2);
                    nuevCompra.NombreProveedor = dr.GetString(3);
                    nuevCompra.FechaFactura = dr.GetDateTime(4);
                    nuevCompra.IsvCompra = dr.GetDecimal(5);
                    nuevCompra.TotalCompra = dr.GetDecimal(6);
                    lista.Add(nuevCompra);
                }
                return lista; //Haciendo retorno de la lista

            }
            catch(Exception error) //Excepción indicará si ocurre un error, mostraría el mensaje siguiente
            {
                MessageBox.Show("No se pudo cargar las compras realizadas debido a un error."+error.Message);
                return new List<comprasRealizadas>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion(); //Cerrando la conexión con la base de datos
            }
        }
    }
}
