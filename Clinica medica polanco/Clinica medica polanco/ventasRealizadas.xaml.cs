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
    /// Lógica de interacción para ventasRealizadas.xaml
    /// </summary>
    public partial class ventasRealizadas : Window
    {
        public ventasRealizadas()
        {
            InitializeComponent();
        }

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
