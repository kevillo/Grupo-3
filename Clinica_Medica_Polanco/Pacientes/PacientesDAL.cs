using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Runtime.InteropServices;

namespace Clinica_medica_polanco.Pacientes
{
    public class PacientesDAL
    {
        public static int AgregarPaciente(Paciente pPaciente)
        {
            try
            {

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

        public static List<Paciente> BuscarPaciente(string pDato)
        {

            
            try
            {
                List<Paciente> Lista = new List<Paciente>();
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand(String.Format("Select Codigo_Paciente, Nombre_Paciente, Apellido_Paciente, Identidad_Paciente, Telefono_Paciente, Fecha_Nacimiento, Correo_Paciente, [Altura_Paciente(cm)], Tipo_Sangre_Paciente, Direccion_Paciente, Estado_Paciente from Pacientes where Nombre_Paciente like '%{0}%' or Identidad_Paciente='{1}' ", pDato, pDato), ConexionBaseDeDatos.conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Paciente pPaciente = new Paciente();
                    pPaciente.Codigo = reader.GetInt32(0);
                    pPaciente.Nombre = reader.GetString(1);
                    pPaciente.Apellido = reader.GetString(2);
                    pPaciente.Identidad = reader.GetString(3);
                    pPaciente.Telefono = reader.GetString(4);
                    pPaciente.FechaNacimiento = reader.GetDateTime(5);
                    pPaciente.Correo = reader.GetString(6);
                    pPaciente.Altura = reader.GetInt32(7);
                    pPaciente.TipoSangre = reader.GetString(8);
                    pPaciente.Direccion = reader.GetString(9);
                    pPaciente.Estado = reader.GetBoolean(10);
                    Lista.Add(pPaciente);
                }
                return Lista;
            }
            catch(Exception err)
            {
                MessageBox.Show("Error al actualizar" + err.Message) ;
                return new List<Paciente>();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
            

        }

        public static Paciente ConsultarPaciente(Int64 pCodigo_Paciente)
        {
            try
            {
                Paciente pPaciente = new Paciente();
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand(String.Format("Select Codigo_Paciente, Nombre_Paciente, Apellido_Paciente, Identidad_Paciente, Telefono_Paciente, Fecha_Nacimiento, Correo_Paciente, [Altura_Paciente(cm)], Tipo_Sangre_Paciente, Direccion_Paciente, Estado_Paciente from Pacientes where Codigo_Paciente = {0}'", pCodigo_Paciente), ConexionBaseDeDatos.conexion);
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
                    pPaciente.Altura = Convert.ToInt32(reader.GetInt32(7));
                    pPaciente.TipoSangre = reader.GetString(8);
                    pPaciente.Direccion = reader.GetString(9);
                    pPaciente.Estado = reader.GetBoolean(10);
                }
                return pPaciente;
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al buscar el paciente ",error.Message);
                return new Paciente();
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }

        }

        public static int ModificarPaciente(Paciente pPaciente)
        {
            try
            {
                int retorno = 0;
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand(String.Format("Update Pacientes set Nombre_Paciente = '{0}', Apellido_Paciente = '{1}', Identidad_Paciente = '{2}', Telefono_Paciente = '{3}', Fecha_Nacimiento = '{4}', Correo_Paciente = '{5}', Altura_Paciente = '{6}', Tipo_Sangre_Paciente = '{7}', Direccion_Paciente = '{8}', Estado_Paciente = '{9}' where Codigo_Paciente = '{10}'", pPaciente.Nombre, pPaciente.Apellido, pPaciente.Identidad, pPaciente.Telefono, pPaciente.FechaNacimiento, pPaciente.Correo, pPaciente.Altura, pPaciente.TipoSangre, pPaciente.Direccion, pPaciente.Estado, pPaciente.Codigo), ConexionBaseDeDatos.conexion);
                retorno = comando.ExecuteNonQuery();
                return retorno;
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al modificar pacientes ", error.Message);
                return -1;
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }

        }

        public static int eliminar(Int64 pCodigo_Paciente)
        {
            try
            {
                int retorno = 0;
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new SqlCommand(String.Format("Delete from Pacientes where Codigo_Paciente = {0}", pCodigo_Paciente), ConexionBaseDeDatos.conexion);
                retorno = comando.ExecuteNonQuery();
                return retorno;
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al eliminar los datos ", error.Message);
                return -1;
            }
            finally
            {

                ConexionBaseDeDatos.CerrarConexion();
            }
            
        }
    }
}