using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Medica_Polanco.Autocompletados
{
    class autocompletarEntregaExamenMedico
    {
        static public List<string> GetData()
        {
            ConexionBaseDeDatos.conexion.Open();
            List<string> data = new List<string>();
            SqlCommand comando = new SqlCommand(String.Format("Select Identidad_Paciente, Cod_Factura_Venta, CONCAT(Nombre_Paciente, ' ', Apellido_Paciente) from [dbo].[vAutocompletarEntregaExamen]"), ConexionBaseDeDatos.conexion);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                data.Add(reader.GetString(0) + " - " + reader.GetInt32(1) + " - " + reader.GetString(2));
            }
            ConexionBaseDeDatos.conexion.Close();
            return data;
        }
    }
}
