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

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para menuPrincipalConfiguracion.xaml
    /// </summary>
    public partial class menuPrincipalConfiguracion : UserControl
    {
        public menuPrincipalConfiguracion()
        {
            InitializeComponent();
        }

        private void btn_Cerrar_Sesion_Click(object sender, RoutedEventArgs e)
        {
            Login nuevologin = new();
            nuevologin.ShowDialog();

           
        }

        private void btn_Infor_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sistema para Clinica Médica Polanco, hecho por el grupo 3.", "Sobre nosotros");
        }

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btn_Infor_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sistema para Clinica Médica Polanco, hecho por el grupo  grupo 3.", "Sobre nosotros");
        }
    }
}
