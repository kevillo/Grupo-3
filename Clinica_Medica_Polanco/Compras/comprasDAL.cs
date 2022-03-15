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
        public static List<comprasRealizadas> obtenerInfoCompras(int codSucursal)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
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
                return lista;

            }
            catch(Exception error)
            {
                MessageBox.Show("No se pueden cargar las compras realizadas "+error.Message);
                return new List<comprasRealizadas>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

    }
}
