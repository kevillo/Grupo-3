using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinica_medica_polanco.Pacientes;
using System.Data.SqlClient;

namespace Clinica_medica_polanco.Pacientes
{
    public class Model
    {
        static public List<string> GetData()
        {
            List<string> data = new List<string>();

            //ConexionBaseDeDatos.ObtenerConexion();
            SqlCommand comando = new SqlCommand(String.Format("Select Nombre_Paciente from Pacientes;"), ConexionBaseDeDatos.ObtenerConexion());
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                data.Add(reader.GetString(0));
            }

            return data;
        }
    }
}
