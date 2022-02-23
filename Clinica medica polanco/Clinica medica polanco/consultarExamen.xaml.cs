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
    /// Lógica de interacción para consultarExamen.xaml
    /// </summary>
    public partial class consultarExamen : Window
    {
        public consultarExamen()
        {
            InitializeComponent();
        }

        private void btn_Consulta_Examen_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Consulta_Examen_Buscar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
