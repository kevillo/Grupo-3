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
using System.Windows.Shapes;

namespace Clinica_medica_polanco
{
    /// <summary>
    /// Lógica de interacción para menuPrincipalNa.xaml
    /// </summary>
    public partial class menuPrincipal : Window
    {
        public menuPrincipal()
        {
            InitializeComponent();
            this.Width = 1080;
            this.Height = 620;
        }

        private void btn_Examenes_medicos_Click(object sender, RoutedEventArgs e)
        {
            menuPrincipalExamenes nuevo = new();
            panel_Menu_Principal.Children.Clear();
            panel_Menu_Principal.Children.Add(nuevo);

        }
        private void btn_Configuracion_Click(object sender, RoutedEventArgs e)
        {
            menuPrincipalConfiguracion conf = new();
            panel_Menu_Principal.Children.Clear();
            panel_Menu_Principal.Children.Add(conf);
        }
    }
}
