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
    /// Lógica de interacción para menuPrincipalExamenes.xaml
    /// </summary>
    public partial class menuPrincipalExamenes : UserControl
    {
        public menuPrincipalExamenes()
        {
            InitializeComponent();
        }

        private void btn_Nuevo_Examen_Click(object sender, RoutedEventArgs e)
        {
            solicitudExamen solicitud = new();
            solicitud.ShowDialog();
        }

        private void btn_Consultar_Examen_Click(object sender, RoutedEventArgs e)
        {
            consultarExamen consultar = new();
            consultar.ShowDialog();
        }

        private void btn_Analizar_Examen_Click(object sender, RoutedEventArgs e)
        {
            revisionExamen revisar = new();
            revisar.ShowDialog();
        }

        private void btn_Entregar_Examen_Click(object sender, RoutedEventArgs e)
        {
            entregarExamen entregar = new();
            entregar.ShowDialog();
        }
    }
}
