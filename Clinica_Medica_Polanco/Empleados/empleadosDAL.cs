﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Clinica_Medica_Polanco.Empleados
{
    public class empleadosDAL
    {
        public static void AgregarEmpleado(Empleados empleados)
        {
            try
            {
                //Validación de datos
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Empleados_Insert", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codigo_Jornada",SqlDbType.Int).Value=empleados.CodigoJornada;
                comando.Parameters.AddWithValue("Codigo_puesto", SqlDbType.Int).Value=empleados.CodigoPuesto;
                comando.Parameters.AddWithValue("Nombre_Empleado", SqlDbType.VarChar).Value= empleados.NombreEmpleado;
                comando.Parameters.AddWithValue("Identidad_Empleado", SqlDbType.VarChar).Value=empleados.IdentidadEmpleado;
                comando.Parameters.AddWithValue("Telefono_Empleado", SqlDbType.VarChar).Value=empleados.TelefonoEmpleado;
                comando.Parameters.AddWithValue("Fecha_Nacimiento_Empleado", SqlDbType.DateTime).Value=empleados.FechaNacimientoEmpleado;
                comando.Parameters.AddWithValue("Correo_Empleado", SqlDbType.VarChar).Value= empleados.CorreoEmpleado;
                comando.Parameters.AddWithValue("Altura_Empleado", SqlDbType.Decimal).Value=empleados.AlturaEmpleado;
                comando.Parameters.AddWithValue("Tipo_Sangre_Empleado", SqlDbType.VarChar).Value=empleados.TipoSangreEmpleado;
                comando.Parameters.AddWithValue("Direccion_Empleado", SqlDbType.VarChar).Value=empleados.DireccionEmpleado;
                comando.Parameters.AddWithValue("Apellido_Empleado", SqlDbType.VarChar).Value=empleados.ApellidoEmpleado;
                comando.Parameters.AddWithValue("Estado_Empleado", SqlDbType.Bit).Value = "True";
                comando.Parameters.AddWithValue("Fecha_Contratacion", SqlDbType.DateTime).Value=empleados.FechaContratacion;
                comando.Parameters.AddWithValue("Fecha_Pago", SqlDbType.DateTime).Value=empleados.FechaPago;
                comando.Parameters.AddWithValue("Sueldo_Base", SqlDbType.Money).Value=empleados.SueldoBase;
                comando.Parameters.AddWithValue("Codigo_Sucursal", SqlDbType.Int).Value= empleados.CodigoSucursal;
                comando.ExecuteReader();
                MessageBox.Show("Empleado agregado exitosamente");
            }
            catch (Exception error)//excepción que indica error
            {
                MessageBox.Show("Error al ingresar empleado " + error.Message);
                
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static List<Empleados> BuscarEmpleado(string pDato)
        {
            List<Empleados> Lista = new List<Empleados>();
            ConexionBaseDeDatos.ObtenerConexion();
            SqlCommand comando = new SqlCommand(String.Format("Select * from Empleados where Identidad_Empleado = '{0}'", pDato), ConexionBaseDeDatos.conexion);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Empleados eEmpleados = new Empleados();
                eEmpleados.CodigoEmpleado = reader.GetInt32(0);
                eEmpleados.CodigoJornada = reader.GetInt32(1);
                eEmpleados.CodigoPuesto = reader.GetInt32(2);
                eEmpleados.NombreEmpleado = reader.GetString(3);
                eEmpleados.ApellidoEmpleado = reader.GetString(4);
                eEmpleados.IdentidadEmpleado = reader.GetString(5);
                eEmpleados.TelefonoEmpleado = reader.GetString(6);
                eEmpleados.FechaNacimientoEmpleado = reader.GetDateTime(7);
                eEmpleados.CorreoEmpleado = reader.GetString(8);
                eEmpleados.AlturaEmpleado = reader.GetDecimal(9);
                eEmpleados.TipoSangreEmpleado = reader.GetString(10);
                eEmpleados.DireccionEmpleado = reader.GetString(11);
                eEmpleados.EstadoEmpleado = reader.GetBoolean(12);
                eEmpleados.CodigoSucursal = reader.GetInt32(13);
                eEmpleados.FechaContratacion = reader.GetDateTime(14);
                eEmpleados.FechaPago = reader.GetDateTime(15);
                eEmpleados.SueldoBase = reader.GetDecimal(16);
                Lista.Add(eEmpleados);
            }
            return Lista;
            /*try
            {
                //Validación de datos
                
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al buscar empleados " + err.Message);
                return new List<Empleados>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }*/
        }

        public static Empleados BuscarEmpleadoPorId(string pDato)
        {
            try
            {
                //Validación de datos
                Empleados eEmpleados = new();
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand(string.Format("Select * from Empleados where Identidad_Empleado = '{0}'", pDato), ConexionBaseDeDatos.conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    eEmpleados.CodigoEmpleado = reader.GetInt32(0);
                    eEmpleados.CodigoJornada = reader.GetInt32(1);
                    eEmpleados.CodigoPuesto = reader.GetInt32(2);
                    eEmpleados.NombreEmpleado = reader.GetString(3);
                    eEmpleados.ApellidoEmpleado = reader.GetString(4);
                    eEmpleados.IdentidadEmpleado = reader.GetString(5);
                    eEmpleados.TelefonoEmpleado = reader.GetString(6);
                    eEmpleados.FechaNacimientoEmpleado = reader.GetDateTime(7);
                    eEmpleados.CorreoEmpleado = reader.GetString(8);
                    eEmpleados.AlturaEmpleado = reader.GetDecimal(9);
                    eEmpleados.TipoSangreEmpleado = reader.GetString(10);
                    eEmpleados.DireccionEmpleado = reader.GetString(11);
                    eEmpleados.EstadoEmpleado = reader.GetBoolean(12);
                    eEmpleados.CodigoSucursal = reader.GetInt32(13);
                    eEmpleados.FechaContratacion = reader.GetDateTime(14);
                    eEmpleados.FechaPago = reader.GetDateTime(15);
                    eEmpleados.SueldoBase = reader.GetDecimal(16);
                }

                return eEmpleados;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al buscar el empleado", error.Message);
                return new Empleados();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static  int traerCodigoEmpleado(string identidad)
        {
            try
            {
                int codEmpleado=0;
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new(string.Format("Select Codigo_Empleado from Empleados where Identidad_Empleado = '{0}'", identidad), ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while(dr.Read())
                {
                    codEmpleado = dr.GetInt32(0);
                }
                return codEmpleado;
            }
            catch(Exception error)
            {
                MessageBox.Show("No se pudo encontrar el código del empleado " + error.Message);
                return -1;
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }

        }
        public static void ModificarEmpleado(Empleados empleados)
        {
            try
            {
                //Validación de datos
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Empleados_Update", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codigo_Empleado",SqlDbType.Int).Value= empleados.CodigoEmpleado;
                comando.Parameters.AddWithValue("Codigo_Jornada", SqlDbType.Int).Value= empleados.CodigoJornada;
                comando.Parameters.AddWithValue("Codigo_puesto", SqlDbType.Int).Value=empleados.CodigoPuesto;
                comando.Parameters.AddWithValue("Nombre_Empleado", SqlDbType.VarChar).Value = empleados.NombreEmpleado;
                comando.Parameters.AddWithValue("Identidad_Empleado", SqlDbType.VarChar).Value = empleados.IdentidadEmpleado;
                comando.Parameters.AddWithValue("Telefono_Empleado", SqlDbType.VarChar).Value = empleados.TelefonoEmpleado;
                comando.Parameters.AddWithValue("Fecha_Nacimiento_Empleado", SqlDbType.DateTime).Value = empleados.FechaNacimientoEmpleado;
                comando.Parameters.AddWithValue("Correo_Empleado", SqlDbType.VarChar).Value = empleados.CorreoEmpleado;
                comando.Parameters.AddWithValue("Altura_Empleado", SqlDbType.Decimal).Value = empleados.AlturaEmpleado;
                comando.Parameters.AddWithValue("Tipo_Sangre_Empleado", SqlDbType.VarChar).Value = empleados.TipoSangreEmpleado;
                comando.Parameters.AddWithValue("Direccion_Empleado", SqlDbType.VarChar).Value = empleados.DireccionEmpleado;
                comando.Parameters.AddWithValue("Apellido_Empleado", SqlDbType.VarChar).Value = empleados.ApellidoEmpleado;
                comando.Parameters.AddWithValue("Estado_Empleado", SqlDbType.Bit).Value = empleados.EstadoEmpleado;
                comando.Parameters.AddWithValue("Fecha_Contratacion", SqlDbType.DateTime).Value = empleados.FechaContratacion;
                comando.Parameters.AddWithValue("Fecha_Pago", SqlDbType.DateTime).Value = empleados.FechaPago;
                comando.Parameters.AddWithValue("Sueldo_Base", SqlDbType.Money).Value = empleados.SueldoBase;
                comando.Parameters.AddWithValue("Codigo_Sucursal", SqlDbType.Int).Value = empleados.CodigoSucursal;
                comando.ExecuteReader();
                MessageBox.Show("Empleado actualizado");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al modificar empleados "+error.Message);
                
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }

        }
        public static void EliminarEmpleado(int codigoEmpleado)
        {
            try
            {
                //Validación de datos
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Empleados_Delete", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codigo_A_Eliminar",DbType.Int32).Value=codigoEmpleado;
                comando.ExecuteReader();
                MessageBox.Show("Empleado deshabilitado con exito");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al eliminar los datos ", error.Message);
                
            }
            finally
            {

                ConexionBaseDeDatos.CerrarConexion();
            }
        } 
        //Función para cargar datos al combobox de Jornada Empleado
        public static void CargarJornada(ComboBox cmbJornada)
        {
            
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                string Query = "Select Codigo_Jornada, Descripcion_Jornada from Jornadas_Empleados";
                SqlCommand createCommand = new SqlCommand(cmdText: Query, ConexionBaseDeDatos.conexion);
                SqlDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr.GetString(1);
                    cmbJornada.Items.Add(nombre);
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
        //Función para cargar datos desde la bd al combobox de Sucursal
        public static void CargarSucursal(ComboBox cmbSucursal)
        {
            
            try
            {

                ConexionBaseDeDatos.ObtenerConexion();
                string Query = "Select Codigo_Sucursal, Nombre_Sucursal from Sucursales";
                SqlCommand createCommand = new SqlCommand(cmdText: Query, ConexionBaseDeDatos.conexion);
                SqlDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr.GetString(1);
                    cmbSucursal.Items.Add(nombre);
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

        //Función par cargar datos desde la bd al cmb de Cargo 
        public static void CargarCargo(ComboBox cmbCargo)
        {
            
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                string Query = "Select Codigo_Puestos, Descripcion_Puesto from Puestos_Empleados";
                SqlCommand createCommand = new SqlCommand(cmdText: Query, ConexionBaseDeDatos.conexion);
                SqlDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr.GetString(1);
                    cmbCargo.Items.Add(nombre);
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
