using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Clinica_Medica_Polanco.Autocompletados
{
    public class Model
    {
        static public List<string> GetData()
        {            
            ConexionBaseDeDatos.conexion.Open();
            List<string> data = new List<string>();
            SqlCommand comando = new SqlCommand(String.Format("Select Identidad_Paciente,Nombre_Paciente,Apellido_Paciente from Pacientes;"), ConexionBaseDeDatos.conexion);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                data.Add(reader.GetString(0) +" "+reader.GetString(1) + " " + reader.GetString(2));
            }
            ConexionBaseDeDatos.conexion.Close();
            return data;                     
        }        
    }
}
