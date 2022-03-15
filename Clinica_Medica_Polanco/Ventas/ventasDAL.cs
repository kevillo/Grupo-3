using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Clinica_Medica_Polanco.Ventas
{
    class ventasDAL
    {
        public static int ObtenerIdVenta()
        {
            try
            {
                int codFacturaVenta=0;
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new("select distinct top 1 rf.Cod_Factura_Venta from Resumen_Factura_Venta rf " +
                                          " order by Cod_Factura_Venta desc", ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    codFacturaVenta = dr.GetInt32(0);
                }
                return codFacturaVenta;
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al buscar el codigo de la factura venta ",error.Message);
                return -1;
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static void GenerarFactura()
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new("Actualizar_Ventas_Insumos", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.ExecuteReader();
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al generar factura ",error.Message);
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static void RegistrarVenta(Ventas nuevaVenta,int codVenta)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new("Detalle_Factura_Venta_Insert", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cod_Factura_Venta", SqlDbType.Int).Value =codVenta;
                comando.Parameters.AddWithValue("Cod_Examen_Medico", SqlDbType.Int).Value =nuevaVenta.CodigoExamenMedico;
                comando.Parameters.AddWithValue("Cod_Facturador", SqlDbType.Int).Value =nuevaVenta.CodigoFacturador;
                comando.Parameters.AddWithValue("Cod_Microbiologo", SqlDbType.Int).Value =nuevaVenta.CodigoMicrobiologo;
                comando.Parameters.AddWithValue("Cod_Enfermero", SqlDbType.Int).Value = nuevaVenta.CodigoEnfermero;
                comando.Parameters.AddWithValue("Cod_Paciente", SqlDbType.Int).Value =nuevaVenta.CodigoPaciente;
                comando.Parameters.AddWithValue("Metodo_Entrega_Examen", SqlDbType.Int).Value =nuevaVenta.MetodoEntregaExamen;
                comando.Parameters.AddWithValue("Metodo_Pago_Examen", SqlDbType.Int).Value =nuevaVenta.MetodoPagoExamen;
                comando.Parameters.AddWithValue("Fecha_Orden", SqlDbType.DateTime).Value =nuevaVenta.FechaOrden;
                comando.Parameters.AddWithValue("Examen_Combo", SqlDbType.Int).Value =nuevaVenta.ExamenCombo;
                comando.Parameters.AddWithValue("Cantidad", SqlDbType.Int).Value =nuevaVenta.Cantidad;
                comando.Parameters.AddWithValue("Estado_Examen_Medico", SqlDbType.Bit).Value =nuevaVenta.EstadoExamenMedico;
                comando.ExecuteReader();  
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al registrar venta ",error.Message);
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static int TraerCodigoPaciente(string identidadEmpleado)
        {
            int codigoPaciente = 0;
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new(string.Format("select Pacientes.Codigo_Paciente from Pacientes where Pacientes.Identidad_Paciente = '{0}'", identidadEmpleado), ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while(dr.Read())
                {
                    codigoPaciente = dr.GetInt32(0);
                }
                return codigoPaciente;
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al encontrar el codigo", error.Message);
                return -1;
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static List<Ventas> MostrarVentas()
        {
            try
            {    //Por si te sirve de algo esta kk que hice :(
                //Validación de datos
                List<Ventas> Lista = new List<Ventas>();
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand(String.Format("Select * From Resumen_Factura_Venta"), ConexionBaseDeDatos.conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Ventas vVentas = new Ventas();
                    vVentas.CodigoFacturaVenta = reader.GetInt32(0);
                    vVentas.CodigoSucursal = reader.GetInt32(1);
                    vVentas.CodigoCliente = reader.GetInt32(2);
                    vVentas.CodigoFacturador = reader.GetInt32(3);
                    vVentas.FechaFactura = reader.GetDateTime(4);
                    vVentas.Subtotal = reader.GetFloat(5);
                    vVentas.Isv = reader.GetFloat(6);
                    vVentas.Descuento = reader.GetFloat(7);
                    vVentas.TotalVenta = reader.GetFloat(8);
                    Lista.Add(vVentas);
                }
                return Lista;
            }
            catch (Exception err)
            {
                MessageBox.Show("No hay ventas que mostrar" + err.Message);
                return new List<Ventas>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static List<Ventas> MostrarCompras()
        {
            try
            {   
                //Validación de datos
                List<Ventas> Lista = new List<Ventas>();
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand(String.Format("Select * From Resumen_Factura_Compras"), ConexionBaseDeDatos.conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Ventas cCompras = new Ventas();
                    cCompras.CodigoFacturaCompra = reader.GetInt32(0);
                    cCompras.CodigoComprador = reader.GetInt32(1);
                    cCompras.CodigoProveedor = reader.GetInt32(2);
                    cCompras.FechaFactura = reader.GetDateTime(3);
                    cCompras.Isv = reader.GetFloat(4);
                    cCompras.CodigoAdministrador = reader.GetInt32(5);
                    cCompras.TotalCompra = reader.GetFloat(6);
                    Lista.Add(cCompras);
                }
                return Lista;
            }
            catch (Exception err)
            {
                MessageBox.Show("No hay ventas que mostrar" + err.Message);
                return new List<Ventas>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
    }
}
