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
    /// Lógica de interacción para agregarProveedor.xaml
    /// </summary>
    public partial class agregarProveedor : UserControl
    {
        public agregarProveedor()
        {
            InitializeComponent();
        }

        private void btn_Agregar_Informacion_Proveedor_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Proveedor agregado correctamente");
        }
    }
}
