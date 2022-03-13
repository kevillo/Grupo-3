using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Medica_Polanco.Autocompletados
{
    class autocompletarExamenMedico
    {
        static public List<string> GetData()
        {
            ConexionBaseDeDatos.conexion.Open();
            List<string> data = new List<string>();
            SqlCommand comando = new SqlCommand(String.Format("Select Descripcion_Tipo_Examen, Cod_Examen_Medico from vAutocompletadoExamenMedico"), ConexionBaseDeDatos.conexion);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                data.Add(reader.GetString(0) + " - " + reader.GetInt32(1));
            }
            ConexionBaseDeDatos.conexion.Close();
            return data;
        }
    }
}
