using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace Clinica_medica_polanco.Pacientes
{
    public class PacientesDAL
    {
          public static int AgregarPaciente(Paciente pPaciente)
        {

            ConexionBaseDeDatos.ObtenerConexion();
            int retorno = 0;
            SqlCommand comando = new SqlCommand(String.Format("Insert Into Pacientes(Nombre_Paciente, Apellido_Paciente, Identidad_Paciente, Telefono_Paciente, Fecha_Nacimiento, Correo_Paciente, [Altura_Paciente(cm)], Tipo_Sangre_Paciente, Direccion_Paciente, Estado_Paciente) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
            pPaciente.Nombre, pPaciente.Apellido, pPaciente.Identidad, pPaciente.Telefono, pPaciente.FechaNacimiento, pPaciente.Correo, pPaciente.Altura, pPaciente.TipoSangre, pPaciente.Direccion, pPaciente.Estado), ConexionBaseDeDatos.conexion);
            retorno = comando.ExecuteNonQuery();
            ConexionBaseDeDatos.CerrarConexion();
            return retorno;
        }

        public static List<Paciente> BuscarPaciente(String pNombre)
        {
            List<Paciente> Lista = new List<Paciente>();
            using (SqlConnection Conn = ConexionBaseDeDatos.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(String.Format("Select Codigo_Paciente, Nombre_Paciente, Apellido_Paciente, Identidad_Paciente, Telefono_Paciente, Fecha_Nacimiento, Correo_Paciente, [Altura_Paciente(cm)], Tipo_Sangre_Paciente, Direccion_Paciente, Estado_Paciente from Pacientes where Nombre_Paciente like '%{0}%'", pNombre), Conn);
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
                ConexionBaseDeDatos.CerrarConexion();
                return Lista;
            }
        }

        public static Paciente ConsultarPaciente(Int64 pCodigo_Paciente)
        {
            using (SqlConnection conn = ConexionBaseDeDatos.ObtenerConexion())
            {
                Paciente pPaciente = new Paciente();

                SqlCommand comando = new SqlCommand(String.Format("Select Codigo_Paciente, Nombre_Paciente, Apellido_Paciente, Identidad_Paciente, Telefono_Paciente, Fecha_Nacimiento, Correo_Paciente, [Altura_Paciente(cm)], Tipo_Sangre_Paciente, Direccion_Paciente, Estado_Paciente from Pacientes where Codigo_Paciente = {0}'", pCodigo_Paciente), conn);
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
                ConexionBaseDeDatos.CerrarConexion();
                return pPaciente;
            }
        }

        public static int ModificarPaciente(Paciente pPaciente)
        {
            int retorno = 0;
            using (SqlConnection conn = ConexionBaseDeDatos.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(String.Format("Update Pacientes set Nombre_Paciente = '{0}', Apellido_Paciente = '{1}', Identidad_Paciente = '{2}', Telefono_Paciente = '{3}', Fecha_Nacimiento = '{4}', Correo_Paciente = '{5}', Altura_Paciente = '{6}', Tipo_Sangre_Paciente = '{7}', Direccion_Paciente = '{8}', Estado_Paciente = '{9}' where Codigo_Paciente = '{10}'", pPaciente.Nombre, pPaciente.Apellido, pPaciente.Identidad, pPaciente.Telefono, pPaciente.FechaNacimiento, pPaciente.Correo, pPaciente.Altura, pPaciente.TipoSangre, pPaciente.Direccion, pPaciente.Estado, pPaciente.Codigo), conn);

                retorno = comando.ExecuteNonQuery();
                ConexionBaseDeDatos.CerrarConexion();
            }
            return retorno;
        }

        public static int eliminar(Int64 pCodigo_Paciente)
        {
            int retorno = 0;
            using (SqlConnection conn = ConexionBaseDeDatos.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(String.Format("Delete from Pacientes where Codigo_Paciente = {0}", pCodigo_Paciente), conn);

                retorno = comando.ExecuteNonQuery();
                ConexionBaseDeDatos.CerrarConexion();
            }
            return retorno;
        }
    }
}