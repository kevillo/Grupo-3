﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica_Medica_Polanco.Autocompletados
{
    class autocompletarProducto
    {
        static public List<string> GetData()
        {
            ConexionBaseDeDatos.conexion.Open();
            List<string> data = new List<string>();
            SqlCommand comando = new SqlCommand(String.Format("Select Codigo_Insumo,Nombre_Insumo from Insumos;"), ConexionBaseDeDatos.conexion);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                data.Add(reader.GetInt32(0) + " " + reader.GetString(1));
            }
            ConexionBaseDeDatos.conexion.Close();
            return data;
        }
    }
}
