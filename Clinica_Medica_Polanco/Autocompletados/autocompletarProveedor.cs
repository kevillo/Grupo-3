﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Medica_Polanco.Autocompletados
{
    class autocompletarProveedor
    {
        static public List<string> GetData()
        {
            ConexionBaseDeDatos.conexion.Open();
            List<string> data = new List<string>();
            SqlCommand comando = new SqlCommand(String.Format("Select CONCAT(Nombre_Proveedor, ' ', Apellido_Proveedor), Codigo_Proveedor from Proveedores"), ConexionBaseDeDatos.conexion);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                data.Add(reader.GetInt32(1) + " - " +reader.GetString(0));
            }
            ConexionBaseDeDatos.conexion.Close();
            return data;
        }
    }
}
