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
    /// Lógica de interacción para solicitudExamen.xaml
    /// </summary>
    public partial class solicitudExamen : Window
    {
        public solicitudExamen()
        {
            InitializeComponent();
        }

        private void btn_Solicitud_Examen_Procesar_Orden_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            pagarExamenMedico nuevopago = new();
            nuevopago.ShowDialog();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
