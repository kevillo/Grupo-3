﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace Clinica_Medica_Polanco.Arqueo
{
    class arqueoDAL
    {

        public static int traerCodArqueo()
        {
            int codArqueo = 0;
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new("select top(1)Cod_Arqueo  from Arqueos_Cajas order by Cod_Arqueo desc", ConexionBaseDeDatos.conexion);
                SqlDataReader dr =  comando.ExecuteReader();
                while(dr.Read())
                {
                    codArqueo = dr.GetInt32(0);
                }
                return codArqueo;   
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo traer el numero de arqueo: ", error.Message);
                return -1;
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }

        public static void generarArqueo(int codEmpleado)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                SqlCommand comando = new("Arqueos_Cajas_Insert",ConexionBaseDeDatos.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Cod_Empleado", SqlDbType.Int).Value = codEmpleado;
                comando.Parameters.AddWithValue("Fecha_arqueo", SqlDbType.DateTime).Value = DateTime.Now;
                comando.ExecuteReader();
                MessageBox.Show("Arqueo realizado");
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo realizar el arqueo debido a un error: ", error.Message);
            }
            finally
            {
                ConexionBaseDeDatos.CerrarConexion();
            }
        }
    
    public static decimal traerMontoInicial(int codArqueo)
    {

        decimal montoInicial=0;
        try
       {
          ConexionBaseDeDatos.ObtenerConexion();
          SqlCommand comando = new("TraerMontoInicial", ConexionBaseDeDatos.conexion);
          comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("CodigoArqueo", SqlDbType.Int).Value = codArqueo;
          SqlDataReader  dr = comando.ExecuteReader();
          while(dr.Read())
          {
                montoInicial = dr.GetDecimal(0);
          }
          return montoInicial;
       }
       catch(Exception error)
       {
            MessageBox.Show("No se pudo traer el monto inicial ",error.Message);
            return -1;
       }
       finally
       {
          ConexionBaseDeDatos.CerrarConexion();
       }

    }
  }
}
