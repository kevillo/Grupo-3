using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Data.SqlClient;

namespace Clinica_medica_polanco
{
    public class ConexionBaseDeDatos
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection("server = localhost; database=Clinica medica polanco; Integrated Security = true");
            try
            {
                conexion.Open();
                return conexion;
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al abrir conexion con la base de datos: " + error.Message);
                return null;
            }

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
