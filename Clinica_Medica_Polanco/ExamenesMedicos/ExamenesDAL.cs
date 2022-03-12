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
            try
            {
                //Validación de datos
                List<ExamenesMedicos> Lista = new List<ExamenesMedicos>();
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Select Cod_Examen_Medico, Codigo_Tipo_Examen, Precio_Unitario, Estado From Examenes_Medicos WHERE Cod_Examen_Medico = @Cod_Examen");
                comando.Parameters.AddWithValue("cod_Examen_Medico", pDato);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ExamenesMedicos eExamenes = new ExamenesMedicos();
                    eExamenes.CodigoExamen = reader.GetInt32(0);
                    eExamenes.CodigoTipoExamen = reader.GetInt32(1);
                    eExamenes.PrecioUnitario = reader.GetFloat(2);
                    eExamenes.Estado = reader.GetBoolean(3);
                    Lista.Add(eExamenes);
                }
                return Lista;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al buscar examen" + err.Message);
                return new List<ExamenesMedicos>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
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
                    eExamenes.PrecioUnitario = reader.GetFloat(2);
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
    }
}

