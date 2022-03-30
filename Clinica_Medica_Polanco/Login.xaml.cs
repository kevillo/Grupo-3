using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_IniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            int codigoError = -5; 
            int estado = ConexionBaseDeDatos.LogIn(txt_Usuario.Text, pwb_Login_Contraseña);
            if(estado  != codigoError)
            {
                menuPrincipal menu = new menuPrincipal(estado);
                menu.Show();
                this.Close();
            }
            else
            {
                txt_Usuario.Clear();
                pwb_Login_Contraseña.Clear();
                txt_Usuario.Focus();
                
            }
            
        }

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btn_Contraseña_Olvidada_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Póngase en contacto con el administrador para solicitar su contraseña");
        }
    }
}
