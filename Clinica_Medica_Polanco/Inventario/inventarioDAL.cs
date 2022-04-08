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
        //Función para modificar o actulizar stock
        public static void actualizarStock(int CodEmpleado, int codSucursal,int codProveedor,int codAdministrador)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion(); //Estableciendo conexión con la base de datos
                SqlCommand comando = new("Resumen_Factura_Compra_Insert", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cod_Comprador", SqlDbType.Int).Value = CodEmpleado;
                comando.Parameters.AddWithValue("Cod_Proveedor", SqlDbType.Int).Value = codProveedor;
                comando.Parameters.AddWithValue("Cod_Sucursal", SqlDbType.Int).Value = codSucursal;
                comando.Parameters.AddWithValue("Cod_Administrador", SqlDbType.Int).Value = codAdministrador;
                comando.ExecuteReader();
                MessageBox.Show("Registro actualizado exitosamente.");
            }
            catch (Exception erro) //Excepción que nos indicará si hay un error, mostraría el siguiente mensaje
            {
                MessageBox.Show("No se pudo ingresar el registro debido a un error.",erro.Message);
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion(); //Cerrando conexión con la base de datos
            }
        }

        //Función para ingresar inventario
        public static void ingresarInventario(int codInsumo, int cantidad)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando2 = new("Detalle_Factura_Compra_Insert", ConexionBaseDeDatos.conexion);
                comando2.CommandType = CommandType.StoredProcedure;
                comando2.Parameters.AddWithValue("Cod_Insumo", SqlDbType.Int).Value = codInsumo;
                comando2.Parameters.AddWithValue("Cantidad", SqlDbType.Int).Value = cantidad;
                comando2.ExecuteReader();
                MessageBox.Show("Inventario actualizado exitosamente.");
            }
            catch (Exception erro) //Excepción que nos indicará si hay un error, mostraría el siguiente mensaje
            {
                MessageBox.Show("No se pudo actualizar el inventario debido a un error.", erro.Message);
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
    }
}
