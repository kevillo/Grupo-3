using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Clinica_medica_polanco
{
    public class ConexionBaseDeDatos
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection("Data source = DESKTOP-7T3QB1P; Initial Catalog = Clinica Medica Grupo 3; Integrated Security = true");
            conexion.Open();

            return conexion;
        }

        public static void CerrarConexion()
        {
            using (SqlConnection conexion = ConexionBaseDeDatos.ObtenerConexion())
            {
                conexion.Close();
            }
        }
    }
}
