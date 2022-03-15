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


        public static Pago cargarDatosPago(int codFacturaVenta)
        {

            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                Pago nuevoPago = new();
                SqlCommand comando = new("traer_Info_Venta", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cod_Factura", SqlDbType.Int).Value = codFacturaVenta;
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    nuevoPago.ISV = dr.GetDecimal(0);
                    nuevoPago.Descuento = dr.GetDecimal(1);
                    nuevoPago.TotalVenta = dr.GetDecimal(2);
                    nuevoPago.Subtotal = dr.GetDecimal(3);
                    
                }
                return nuevoPago;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al generar factura ", error.Message);
                return new Pago();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static Pago cargarDatosVenta(int codFacturaVenta)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                Pago nuevoPago = new();
                SqlCommand comando = new("infor_Venta_Paciente", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cod_Factura_Venta", SqlDbType.Int).Value = codFacturaVenta;
                SqlDataReader dr= comando.ExecuteReader();
                while(dr.Read())
                {
                    nuevoPago.NombrePaciente = dr.GetString(0);
                    nuevoPago.TelefonoPaciente = dr.GetString(1);
                    nuevoPago.CorreoPaciente = dr.GetString(2);
                    nuevoPago.FechaOrden = dr.GetDateTime(3).ToShortDateString();
                    nuevoPago.MetodoEntrega = dr.GetString(4);
                    nuevoPago.MetodoPago = dr.GetString(5);
                }
                return nuevoPago;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al generar factura ", error.Message);
                return new Pago();  
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
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

        public static int obtenerIdSucursal(int codEmpleado)
        {
            try
            {
                int codSucursal = 0;
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new(String.Format("select Empleados.Codigo_Sucursal from Empleados where Codigo_Empleado = {0}",codEmpleado), ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while(dr.Read())
                {
                    codSucursal = dr.GetInt32(0);
                }
                return codSucursal;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al generar factura ", error.Message);
                return -1;
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static void GenerarFactura(int codSucursal)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new("Actualizar_Ventas_Insumos", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codigo_Sucursal", SqlDbType.Int).Value = codSucursal;
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
                comando.Parameters.AddWithValue("Estado_Examen_Medico", SqlDbType.Bit).Value =1;    
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

        public static List<ventasRealizadas> MostrarVentas(int codSucursal)
        {
            try
            {  

                //Validación de datos
                List<ventasRealizadas> Lista = new List<ventasRealizadas>();
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand(String.Format("ventas_Realizadas"), ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cod_Sucursal", SqlDbType.Int).Value = codSucursal;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ventasRealizadas nuevaVenta = new();
                    nuevaVenta.CodFactura = reader.GetInt32(0);
                    nuevaVenta.NombreSucursal = reader.GetString(1);
                    nuevaVenta.NombrePaciente = reader.GetString(2);
                    nuevaVenta.NombreaEmpleado = reader.GetString(3);
                    nuevaVenta.FechaFactura = reader.GetDateTime(4);
                    nuevaVenta.SubtotalVenta = reader.GetDecimal(5);
                    nuevaVenta.IsvVenta = reader.GetDecimal(6);
                    nuevaVenta.DescuentoVenta = reader.GetDecimal(7);
                    nuevaVenta.TotalVenta = reader.GetDecimal(8);
                    Lista.Add(nuevaVenta);

                }
                return Lista;
            }
            catch (Exception err)
            {
                MessageBox.Show("No hay ventas que mostrar" + err.Message);
                return new List<ventasRealizadas>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

     /*   public static List<Ventas> MostrarCompras()
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
        }*/
    }
}
