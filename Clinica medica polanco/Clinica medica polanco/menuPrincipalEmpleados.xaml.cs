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
    /// Lógica de interacción para menuPrincipalEmpleados1.xaml
    /// </summary>
    public partial class menuPrincipalEmpleados:UserControl
    {
        public menuPrincipalEmpleados()
        {
            InitializeComponent();
        }

        private void btn_Consultar_Datos_Empleados_Click(object sender, RoutedEventArgs e)
        {
            ConsultarEmpleados consultar = new();
            consultar.ShowDialog();
        }

        private void btn_Eliminar_Datos_Empleados_Click(object sender, RoutedEventArgs e)
        {
            EliminarEmpleado eliminar = new();
            eliminar.ShowDialog();
        }
    }
}
