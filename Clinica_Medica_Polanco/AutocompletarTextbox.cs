using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinica_Medica_Polanco.Pacientes;
using System.Data.SqlClient;

namespace Clinica_Medica_Polanco.Pacientes
{
    public class Model
    {
        static public List<string> GetData()
        {            
            ConexionBaseDeDatos.conexion.Open();
            List<string> data = new List<string>();
            SqlCommand comando = new SqlCommand(String.Format("Select Identidad_Paciente from Pacientes;"), ConexionBaseDeDatos.conexion);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                data.Add(reader.GetString(0));
            }
            ConexionBaseDeDatos.conexion.Close();
            return data;                     
        }        
    }
}
