using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Clinica_Medica_Polanco.ExamenesMedicos
{
    class ExamenesDAL
    {
        public static void SolicitudExamen(ExamenesMedicos examenes)
        {
            try
            {
                //Validación de datos
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Examenes_Medicos_Insert", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codigo_Tipo_Examen", SqlDbType.Int).Value = examenes.CodigoTipoExamen;
                comando.Parameters.AddWithValue("Precio_Unitario", SqlDbType.Float).Value = examenes.PrecioUnitario;
                comando.Parameters.AddWithValue("Estado", SqlDbType.Bit).Value = "True";
                comando.ExecuteReader();
                MessageBox.Show("Exámenes solicitado exitosamente");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al solicitar examen" + error.Message);

            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
        public static List<ExamenesMedicos> BuscarExamen(string pDato)
        {
            List<ExamenesMedicos> Lista = new List<ExamenesMedicos>();
            ConexionBaseDeDatos.ObtenerConexion();
            SqlCommand comando = new SqlCommand(string.Format("Select * from Examenes_Medicos where Cod_Examen_Medico = '{0}'", pDato), ConexionBaseDeDatos.conexion);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                ExamenesMedicos eExamenes = new ExamenesMedicos();
                eExamenes.CodigoExamen = reader.GetInt32(0);
                eExamenes.CodigoTipoExamen = reader.GetInt32(1);
                eExamenes.PrecioUnitario = reader.GetDecimal(2);
                eExamenes.Estado = reader.GetBoolean(3);
                Lista.Add(eExamenes);
            }
            return Lista;
            
        }
        public static ExamenesMedicos BuscarExamenPorId(Int64 pDato)
        {
            try
            {
                //Validación de datos
                ExamenesMedicos nuevoExamen = new();
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Select Cod_Examen_Medico, Codigo_Tipo_Examen, Precio_Unitario, Estado From Examenes_Medicos WHERE Cod_Examen_Medico = @Cod_Examen", ConexionBaseDeDatos.conexion);
                comando.Parameters.AddWithValue("cod_Examen_Medico", pDato);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ExamenesMedicos eExamenes = new ExamenesMedicos();
                    eExamenes.CodigoExamen = reader.GetInt32(0);
                    eExamenes.CodigoTipoExamen = reader.GetInt32(1);
                    eExamenes.PrecioUnitario = reader.GetDecimal(2);
                    eExamenes.Estado = reader.GetBoolean(3);
                    break;
                }
                return nuevoExamen;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al buscar el examen", error.Message);
                return new ExamenesMedicos();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
        //Función para cargar datos al combobox de microbiológo
        public static void CargarMicrobiologo(ComboBox cmb_Solicitud_Examen_Microbiologo)
        {

            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                string Query = "Select Nombre_Empleado from Empleados";
                SqlCommand createCommand = new SqlCommand(cmdText: Query, ConexionBaseDeDatos.conexion);
                SqlDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr.GetString(0);
                    cmb_Solicitud_Examen_Microbiologo.Items.Add(nombre);
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
        //Función para cargar datos al combobox de enfermeros
        public static void CargarEnfermeros(ComboBox cmb_Solicitud_Examen_Enfermero)
        {

            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                string Query = "Select Nombre_Empleado from Empleados";
                SqlCommand createCommand = new SqlCommand(cmdText: Query, ConexionBaseDeDatos.conexion);
                SqlDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr.GetString(0);
                    cmb_Solicitud_Examen_Enfermero.Items.Add(nombre);
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
        //Función para cargar datos al combobox forma de entrega examen
        public static void CargarEntregaExamen(ComboBox cmb_Forma_Entrega)
        {

            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                string Query = "Select Descripcion_Metodo_Entrega from Metodos_Entrega";
                SqlCommand createCommand = new SqlCommand(cmdText: Query, ConexionBaseDeDatos.conexion);
                SqlDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr.GetString(0);
                    cmb_Forma_Entrega.Items.Add(nombre);
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
        //Función para cargar datos al combobox de forma pago
        public static void CargarFormaPago(ComboBox cmb_Forma_Pago)
        {

            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                string Query = "Select Descripcion_Metodo_Pago from Metodos_Pagos";
                SqlCommand createCommand = new SqlCommand(cmdText: Query, ConexionBaseDeDatos.conexion);
                SqlDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr.GetString(0);
                    cmb_Forma_Pago.Items.Add(nombre);
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
        //Función para cargar datos al combobox de sucursal
        public static void CargarSucursal(ComboBox cmb_Sucursal_Buscar)
        {

            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                string Query = "Select Nombre_Sucursal from Sucursales";
                SqlCommand createCommand = new SqlCommand(cmdText: Query, ConexionBaseDeDatos.conexion);
                SqlDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr.GetString(0);
                    cmb_Sucursal_Buscar.Items.Add(nombre);
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

        public static List<ExamenesMedicos> obtenerInforPorSucursalExamen(int codSucursal,int codExamen)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                List<ExamenesMedicos> nuevoExamenConsultar = new();
                SqlCommand comando = new("Infor_Examenes_Sucursal", ConexionBaseDeDatos.conexion);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cod_Sucursal", SqlDbType.Int).Value = codSucursal;
                comando.Parameters.AddWithValue("Cod_Examen", SqlDbType.Int).Value = codExamen;
                SqlDataReader dr = comando.ExecuteReader();
                while(dr.Read())
                {
                    ExamenesMedicos nuevoExamennConsultar = new();
                    nuevoExamennConsultar.CodigoExamen = codExamen;
                    nuevoExamennConsultar.CodSucursal = dr.GetInt32(0);
                    nuevoExamennConsultar.NombreSucursal = dr.GetString(1);
                    nuevoExamennConsultar.CodigoExamen = dr.GetInt32(2);
                    nuevoExamennConsultar.CodigoTipoExamen = dr.GetInt32(3);
                    nuevoExamennConsultar.TipoExamen = dr.GetString(4);
                    nuevoExamennConsultar.PrecioUnitario = dr.GetDecimal(5);
                    nuevoExamennConsultar.Estado = dr.GetBoolean(6);
                    nuevoExamenConsultar.Add(nuevoExamennConsultar);
                }
                return nuevoExamenConsultar;
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo encontrar el examen para esa sucursal o examen "+ error.Message);
                return new List<ExamenesMedicos>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
        public static List<ExamenesMedicos> obtenerInforPorSucursalExamen(int codSucursal)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                List<ExamenesMedicos> nuevoExamenConsultar = new();
                SqlCommand comando = new("Infor_Examenes_Sucursal_Detalle_Examen", ConexionBaseDeDatos.conexion);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cod_Sucursal", SqlDbType.Int).Value = codSucursal;
                
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ExamenesMedicos nuevoExamennConsultar = new();
                    nuevoExamennConsultar.CodSucursal = dr.GetInt32(0);
                    nuevoExamennConsultar.NombreSucursal = dr.GetString(1);
                    nuevoExamennConsultar.CodigoExamen = dr.GetInt32(2);
                    nuevoExamennConsultar.CodigoTipoExamen = dr.GetInt32(3);
                    nuevoExamennConsultar.TipoExamen = dr.GetString(4);
                    nuevoExamennConsultar.PrecioUnitario = dr.GetDecimal(5);
                    nuevoExamennConsultar.Estado = dr.GetBoolean(6);
                    nuevoExamenConsultar.Add(nuevoExamennConsultar);
                }
                return nuevoExamenConsultar;
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo encontrar el examen para esa sucursal o examen " + error.Message);
                return new List<ExamenesMedicos>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
        public static List<ExamenesMedicos> obtenerInforPorSucursalExamen(string codExamen)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                List<ExamenesMedicos> nuevoExamenConsultar = new();
                SqlCommand comando = new("Infor_Examenes_Sucursal_Detalle_Sucursal", ConexionBaseDeDatos.conexion);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cod_Examen", SqlDbType.Int).Value = int.Parse(codExamen);

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ExamenesMedicos nuevoExamennConsultar = new();
                    nuevoExamennConsultar.CodSucursal = dr.GetInt32(0);
                    nuevoExamennConsultar.NombreSucursal = dr.GetString(1);
                    nuevoExamennConsultar.CodigoExamen = dr.GetInt32(2);
                    nuevoExamennConsultar.CodigoTipoExamen = dr.GetInt32(3);
                    nuevoExamennConsultar.TipoExamen = dr.GetString(4);
                    nuevoExamennConsultar.PrecioUnitario = dr.GetDecimal(5);
                    nuevoExamennConsultar.Estado = dr.GetBoolean(6);
                    nuevoExamenConsultar.Add(nuevoExamennConsultar);
                }
                return nuevoExamenConsultar;
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo encontrar el examen para esa sucursal o examen " + error.Message);
                return new List<ExamenesMedicos>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }


        public static List<Ventas.Ventas> obtenerExamenesParaEntregar(int codFactura)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                List<Ventas.Ventas> ventasEntregar= new();
                SqlCommand comando = new(string.Format("select * from Detalle_Factura_Venta "+
                                         " where Cod_Factura_Venta = {0} and Estado_Examen_Medico=2", codFactura), ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Ventas.Ventas entregarV = new();
                    entregarV.CodFacturaVenta = dr.GetInt32(0);
                    entregarV.CodigoExamenMedico = dr.GetInt32(1);
                    entregarV.CodigoFacturador = dr.GetInt32(2);
                    entregarV.CodigoMicrobiologo = dr.GetInt32(3);
                    entregarV.CodigoEnfermero = dr.GetInt32(4);
                    entregarV.CodigoPaciente = dr.GetInt32(5);
                    entregarV.MetodoEntregaExamen = dr.GetInt32(6);
                    entregarV.MetodoPagoExamen = dr.GetInt32(7);
                    entregarV.FechaOrden = dr.GetDateTime(8);
                    entregarV.ExamenCombo = dr.GetBoolean(9);
                    entregarV.Cantidad = dr.GetInt32(10);
                    entregarV.EstadoExamenMedico = dr.GetInt32(11);
                    ventasEntregar.Add(entregarV);
                }
                return ventasEntregar;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al generar entrega ", error.Message);
                return new List<Ventas.Ventas>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static List<Ventas.Ventas> obtenerExamenesParaEntregar(string identidadPaciente )
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                List<Ventas.Ventas> ventasEntregar = new();
                SqlCommand comando = new(string.Format("select Detalle_Factura_Venta.* from Detalle_Factura_Venta"+
                                                       " inner join Pacientes on Detalle_Factura_Venta.Cod_Paciente = Pacientes.Codigo_Paciente"+
                                                       " where Pacientes.Identidad_Paciente = '{0}' and Detalle_Factura_Venta.Estado_Examen_Medico = 2",identidadPaciente), ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Ventas.Ventas entregarV = new();
                    entregarV.CodFacturaVenta = dr.GetInt32(0);
                    entregarV.CodigoExamenMedico = dr.GetInt32(1);
                    entregarV.CodigoFacturador = dr.GetInt32(2);
                    entregarV.CodigoMicrobiologo = dr.GetInt32(3);
                    entregarV.CodigoEnfermero = dr.GetInt32(4);
                    entregarV.CodigoPaciente = dr.GetInt32(5);
                    entregarV.MetodoEntregaExamen = dr.GetInt32(6);
                    entregarV.MetodoPagoExamen = dr.GetInt32(7);
                    entregarV.FechaOrden = dr.GetDateTime(8);
                    entregarV.ExamenCombo = dr.GetBoolean(9);
                    entregarV.Cantidad = dr.GetInt32(10);
                    entregarV.EstadoExamenMedico = dr.GetInt32(11);
                    ventasEntregar.Add(entregarV);
                }
                return ventasEntregar;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al generar entrega", error.Message);
                return new List<Ventas.Ventas>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
        public static List<servicios.serviciosEntrega> analsisExamen()
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                List<servicios.serviciosEntrega> ventasEntregar = new();
                SqlCommand comando = new("select * from vAnalizarExamen", ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    servicios.serviciosEntrega entregarV = new();
                    entregarV.NombreExamen = dr.GetString(0);
                    entregarV.NombrePaciente = dr.GetString(2);
                    entregarV.NombreMetodoPago = dr.GetString(3);
                    entregarV.NombreMetodoEntrega = dr.GetString(4);
                    entregarV.NombreEmpleado = dr.GetString(5);
                    entregarV.CodFacturaVenta = dr.GetInt32(6);
                    entregarV.CodigoExamenMedico = dr.GetInt32(7);
                    entregarV.CodigoFacturador = dr.GetInt32(9);
                    entregarV.CodigoMicrobiologo = dr.GetInt32(8);
                    entregarV.CodigoEnfermero = dr.GetInt32(10);
                    entregarV.CodigoPaciente = dr.GetInt32(11);
                    entregarV.MetodoEntregaExamen = dr.GetInt32(12);
                    entregarV.MetodoPagoExamen = dr.GetInt32(13);
                    entregarV.FechaOrden = dr.GetDateTime(14);
                    entregarV.ExamenCombo = dr.GetBoolean(15);
                    entregarV.EstadoExamenMedico = dr.GetInt32(16);
                    ventasEntregar.Add(entregarV);
                }
                return ventasEntregar;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al generar analsis", error.Message);
                return new List<servicios.serviciosEntrega>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static void analizarExamenMedico(int codFactura,int CodExamen,string analisis)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
               
                SqlCommand comando = new("Detalle_Factura_Venta_Update", ConexionBaseDeDatos.conexion);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cod_Factura_Venta", SqlDbType.Int).Value = codFactura;
                comando.Parameters.AddWithValue("Cod_Examen_Medico", SqlDbType.Int).Value = CodExamen;
                comando.Parameters.AddWithValue("Estado_Examen_Medico", SqlDbType.Int).Value = 2;
                comando.Parameters.AddWithValue("Diagnostico", SqlDbType.VarChar).Value = analisis;
                comando.ExecuteReader();
                MessageBox.Show("Informacion actualizada correctamente");
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo terminar de guardar la informacion del examen analizado " + error.Message);
                
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }


        public static void entregarExamenMedico(int codFactura)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();

                SqlCommand comando = new("Detalle_Factura_Venta_Update_Factura", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cod_Factura_Venta", SqlDbType.Int).Value = codFactura;
                comando.Parameters.AddWithValue("Estado_Examen_Medico", SqlDbType.Int).Value = 3;
                comando.ExecuteReader();
                MessageBox.Show("Informacion actualizada correctamente");
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo terminar de guardar la informacion del examen a entregar " + error.Message);

            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }



    }
}

