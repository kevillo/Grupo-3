using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data;
using System.Windows;
using System.Data.SqlClient;


namespace Clinica_Medica_Polanco
{
    public class ConexionBaseDeDatos
    {
        public static SqlConnection conexion = new SqlConnection("Data source = localhost; database=Clinica medica polanco; Integrated Security = true");
        
        public static SqlConnection ObtenerConexion()
        {
            try
            {
                conexion.Open();
                MessageBox.Show("Se abrió la conexión");
                return conexion;
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al abrir conexión con la base de datos: " + error.Message);
                return null;
            }

        }

        public static void CerrarConexion()
        {
                try
                {
                    if(conexion != null)
                    {
                        conexion.Close();
                        MessageBox.Show("Se cerró la conexión");
                    }
                    else
                    {
                        MessageBox.Show("La conexión no está abierta");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al cerrar: " + ex);
                }
            
        }

        // codigo de estado -5: error al loguear
        // de lo contrario se retorna el codigo de empleado
        public static int LogIn(String user,PasswordBox pass)
        {
            try
            {
                conexion.Open();
               
                SqlCommand cmd = new SqlCommand("SELECT Usuarios.Nombre_Usuario, Roles_Usuarios.Descripcion_Rol_Usuario, Usuarios.Estado_Usuario,Usuarios.Codigo_Empleado FROM Usuarios inner join Roles_Usuarios on Roles_Usuarios.Codigo_Rol_Usuario = Usuarios.Codigo_Rol_Usuario WHERE Usuarios.Nombre_Usuario = @u AND Usuarios.contraseña = @p", conexion);

                cmd.Parameters.AddWithValue("u", user);
                cmd.Parameters.AddWithValue("p", pass.Password);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if(dt.Rows.Count==1)
                {
                    if (dt.Rows[0][1].ToString() == "Administrador")
                    {
                        if (dt.Rows[0][2].ToString() == "True") return (int)dt.Rows[0][3];
                        else
                        {
                            MessageBox.Show("Usuario o contraseña inválido.");
                            return -5;
                        }
                    }

                    else if (dt.Rows[0][1].ToString() == "Empleado")
                    {
                        if (dt.Rows[0][2].ToString() == "True") return (int)dt.Rows[0][3];

                        else
                        {
                            MessageBox.Show("Usuario o contraseña inválido.");
                            return -5;
                        }
                    }
                   
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña inválido.");
                    return -5;
                }
                

            }
            catch(Exception ERR)
            {
                MessageBox.Show("Error en el login: " + ERR.Message);
                return -5;   
            }
            finally
            {
                conexion.Close();
                
            }
            return -5;
        }


        public static string confEmpleado(int codigoEmpleado)
        {
            try
            {
                ObtenerConexion();
                string nombre = "";
                SqlCommand comando = new SqlCommand(string.Format( "select Roles_Usuarios.Descripcion_Rol_Usuario from Usuarios " +
                                                    " inner join Roles_Usuarios on Usuarios.Codigo_Rol_Usuario = Roles_Usuarios.Codigo_Rol_Usuario" +
                                                    " where Usuarios.Codigo_Empleado = {0}",codigoEmpleado), conexion);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    nombre = dr.GetString(0);

                }
                return nombre;

            }
            catch (Exception error)
            {
                MessageBox.Show("El código no esta asignado a ningún empleado ",error.Message);
                return "error";
            }
            finally
            {
                CerrarConexion();
            }

        }


    }
}
