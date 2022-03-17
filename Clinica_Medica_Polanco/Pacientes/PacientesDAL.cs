﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Data;

namespace Clinica_Medica_Polanco.Pacientes
{
    public class PacientesDAL
    {
        public static int AgregarPaciente(Pacient pPaciente)
        {
            try
            {
                //Validación de datos
                ConexionBaseDeDatos.ObtenerConexion();
                int retorno = 0;
                SqlCommand comando = new SqlCommand(String.Format("Insert Into Pacientes(Nombre_Paciente, Apellido_Paciente, Identidad_Paciente, Telefono_Paciente, Fecha_Nacimiento, Correo_Paciente, [Altura_Paciente(cm)], Tipo_Sangre_Paciente, Direccion_Paciente, Estado_Paciente) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                pPaciente.Nombre, pPaciente.Apellido, pPaciente.Identidad, pPaciente.Telefono, pPaciente.FechaNacimiento, pPaciente.Correo, pPaciente.Altura, pPaciente.TipoSangre, pPaciente.Direccion, pPaciente.Estado), ConexionBaseDeDatos.conexion);
                retorno = comando.ExecuteNonQuery();
                return retorno;
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al ingresar pacientes " + error.Message);
                return -1;
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static List<Pacient> ConsultarPaciente(string pDato)
        {

            
            try
            {
                //Validación de datos
                List<Pacient> Lista = new List<Pacient>();
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand(String.Format("Select Codigo_Paciente, Nombre_Paciente, Apellido_Paciente, Identidad_Paciente, Telefono_Paciente, Fecha_Nacimiento, Correo_Paciente, [Altura_Paciente(cm)], Tipo_Sangre_Paciente, Direccion_Paciente, Estado_Paciente from Pacientes where Nombre_Paciente like '%{0}%' or Identidad_Paciente='{1}' ", pDato, pDato), ConexionBaseDeDatos.conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Pacient pPaciente = new Pacient();
                    pPaciente.Codigo = reader.GetInt32(0);
                    pPaciente.Nombre = reader.GetString(1);
                    pPaciente.Apellido = reader.GetString(2);
                    pPaciente.Identidad = reader.GetString(3);
                    pPaciente.Telefono = reader.GetString(4);
                    pPaciente.FechaNacimiento = reader.GetDateTime(5);
                    pPaciente.Correo = reader.GetString(6);
                    pPaciente.Altura = reader.GetDecimal(7);
                    pPaciente.TipoSangre = reader.GetString(8);
                    pPaciente.Direccion = reader.GetString(9);
                    pPaciente.Estado = reader.GetBoolean(10);
                    Lista.Add(pPaciente);
                }
                return Lista;
            }
            catch(Exception err)
            {
                MessageBox.Show("No se puede encontrar un paciente con esas especificaciones " + err.Message) ;
                return new List<Pacient>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static  int ObtenerIdPaciente(string identidad)
        {
            int codPaciente = 0;
            try
            {

                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new(string.Format("select Codigo_Paciente from Pacientes where Identidad_Paciente = '{0}'", identidad), ConexionBaseDeDatos.conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while(dr.Read())
                {
                    codPaciente = dr.GetInt32(0);
                }
                return codPaciente;
            }
            catch(Exception err)
            {
                MessageBox.Show("Error al buscar el paciente " + err.Message);
                return -1;
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static Pacient BuscarPaciente(string pCodigo_Paciente)
        {
            try
            {
                //Validación de datos
                Pacient pPaciente = new Pacient();
                int codPac = ObtenerIdPaciente(pCodigo_Paciente);
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand(String.Format("Select Codigo_Paciente, Nombre_Paciente, Apellido_Paciente, Identidad_Paciente, Telefono_Paciente, " +
                    "Fecha_Nacimiento, Correo_Paciente, [Altura_Paciente(cm)], Tipo_Sangre_Paciente, Direccion_Paciente, Estado_Paciente from Pacientes " +
                    "where Codigo_Paciente = {0} OR Identidad_Paciente ='{1}' " ,codPac,pCodigo_Paciente), ConexionBaseDeDatos.conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    pPaciente.Codigo = reader.GetInt32(0);
                    pPaciente.Nombre = reader.GetString(1);
                    pPaciente.Apellido = reader.GetString(2);
                    pPaciente.Identidad = reader.GetString(3);
                    pPaciente.Telefono = reader.GetString(4);
                    pPaciente.FechaNacimiento = reader.GetDateTime(5);
                    pPaciente.Correo = reader.GetString(6);
                    pPaciente.Altura = reader.GetDecimal(7);
                    pPaciente.TipoSangre = reader.GetString(8);
                    pPaciente.Direccion = reader.GetString(9);
                    pPaciente.Estado = reader.GetBoolean(10);
                }
                return pPaciente;
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al buscar el paciente ",error.Message);
                return new Pacient();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }

        }

        public static void ModificarPaciente(Pacient pPaciente)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Pacientes_Update", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Codigo_Paciente", SqlDbType.Int).Value = pPaciente.Codigo;
                comando.Parameters.AddWithValue("@Nombre_Paciente", SqlDbType.Int).Value = pPaciente.Nombre;
                comando.Parameters.AddWithValue("@Identidad_Paciente", SqlDbType.VarChar).Value =pPaciente.Identidad;
                comando.Parameters.AddWithValue("@Telefono_Paciente", SqlDbType.VarChar).Value =pPaciente.Telefono;
                comando.Parameters.AddWithValue("@Fecha_Nacimiento", SqlDbType.DateTime).Value =pPaciente.FechaNacimiento;
                comando.Parameters.AddWithValue("@Correo_Paciente", SqlDbType.VarChar).Value = pPaciente.Correo;
                comando.Parameters.AddWithValue("@Altura_Paciente", SqlDbType.Decimal).Value = pPaciente.Altura;
                comando.Parameters.AddWithValue("@Tipo_Sangre_Paciente", SqlDbType.VarChar).Value =pPaciente.TipoSangre;
                comando.Parameters.AddWithValue("@Direccion_Paciente", SqlDbType.VarChar).Value = pPaciente.Direccion;
                comando.Parameters.AddWithValue("@Apellido_Paciente", SqlDbType.VarChar).Value = pPaciente.Apellido;
                comando.Parameters.AddWithValue("@Estado_Paciente", SqlDbType.Bit).Value = pPaciente.Estado;


                comando.ExecuteReader();
                MessageBox.Show("Paciente modificado exitosamente");
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al modificar pacientes ", error.Message);
                
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static void EliminarPaciente(int  pCodigo_Paciente)
        {
            try
            {
                //Validación de datos
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("Pacientes_Delete", ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Codigo_A_Eliminar",SqlDbType.Int).Value=pCodigo_Paciente;
                comando.ExecuteReader();
                MessageBox.Show("Paciente deshabilitado correctamente");
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al eliminar los datos ", error.Message);
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
            
        }
    }
}