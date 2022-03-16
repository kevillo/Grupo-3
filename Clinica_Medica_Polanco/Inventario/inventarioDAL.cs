using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace Clinica_Medica_Polanco.Inventario
{
    class inventarioDAL
    {
        public static void actualizarStock(int codInsumo, int codSucursal,int codProveedor,int existencia)
        {
            try
            {
                DateTime fecha = DateTime.Now;
                int mes = fecha.Month;
                int anio = fecha.Year;
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new("Inventario_Update", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codigo_Insumo", SqlDbType.Int).Value = codInsumo;
                comando.Parameters.AddWithValue("Inventario_Mes", SqlDbType.Int).Value = mes;
                comando.Parameters.AddWithValue("Inventario_Año", SqlDbType.Int).Value = anio;
                comando.Parameters.AddWithValue("Codigo_Proveedor", SqlDbType.Int).Value = codProveedor;
                comando.Parameters.AddWithValue("Existencia", SqlDbType.Int).Value = existencia;
                comando.Parameters.AddWithValue("Codigo_Sucursal", SqlDbType.Int).Value = codSucursal;
                comando.ExecuteReader();
                MessageBox.Show("Inventario actualizado");
            }
            catch
            {
                MessageBox.Show("No se pudo actualizar el inventario");
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }


    }
}
