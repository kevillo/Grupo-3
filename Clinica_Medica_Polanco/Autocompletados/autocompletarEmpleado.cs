using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Medica_Polanco.Autocompletados
{
    class autocompletarEmpleado
    {
        static public List<string> GetData()
        {
            ConexionBaseDeDatos.conexion.Open();
            List<string> data = new List<string>();
            SqlCommand comando = new SqlCommand(String.Format("Select Identidad_Empleado, Nombre_Empleado, Apellido_Empleado from Empleados;"), ConexionBaseDeDatos.conexion);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                data.Add(reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2));
            }
            ConexionBaseDeDatos.conexion.Close();
            return data;
        }
    }
}
