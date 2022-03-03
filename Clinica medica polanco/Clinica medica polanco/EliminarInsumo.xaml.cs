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

namespace Clinica_medica_polanco
{
    /// <summary>
    /// Lógica de interacción para EliminarInsumo.xaml
    /// </summary>
    public partial class EliminarInsumo : UserControl
    {
        public EliminarInsumo()
        {
            InitializeComponent();
        }

        private void btn_Deshabilitar_Insumo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Producto eliminado correctamente");
        }
    }
}
