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
    /// Lógica de interacción para menuPrincipalInformes.xaml
    /// </summary>
    public partial class menuPrincipalInformes : UserControl
    {
        public menuPrincipalInformes()
        {
            InitializeComponent();
        }

        private void btn_Informes_Inventario_Click(object sender, RoutedEventArgs e)
        {
            InformesInventario nuevoInforme = new();
            nuevoInforme.ShowDialog();
        }

        private void btn_Informes_Ventas_Click(object sender, RoutedEventArgs e)
        {
            InformeVentas ventas = new();
            ventas.ShowDialog();
        }

        private void btn_Informes_Empleado_Click(object sender, RoutedEventArgs e)
        {
            InformeEmpleados nuevoEmpleado = new();
            nuevoEmpleado.ShowDialog();
        }

        private void btn_Informes_Compras_Click(object sender, RoutedEventArgs e)
        {
            informesCompras informes = new();
            informes.ShowDialog();
        }

        private void btn_Informes_Paciente_Click(object sender, RoutedEventArgs e)
        {
            informePacientes pacientes = new();
            pacientes.ShowDialog();
        }

        private void btn_Informes_Examenes_Medicos_Click(object sender, RoutedEventArgs e)
        {
            InfomesExamenesMedicos examenes = new();
            examenes.ShowDialog();
        }
    }
}
