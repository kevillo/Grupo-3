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
    /// Lógica de interacción para menuPacientes.xaml
    /// </summary>
    public partial class menuPrincipalPacientes : UserControl
    {
        public menuPrincipalPacientes()
        {
            InitializeComponent();
        }

        private void btn_Agregar_Paciente_click(object sender, RoutedEventArgs e)
        {
            
            agregarPaciente nuevoPaciente = new();
         
            nuevoPaciente.ShowDialog();
        }

        private void btn_Borrar_Paciente_click(object sender, RoutedEventArgs e)
        {
            borrarPaciente borrar = new();
            borrar.ShowDialog();
        }

        private void btn_Actualizar_Paciente_Click(object sender, RoutedEventArgs e)
        {
            actualizarPaciente actualizar = new();
            actualizar.ShowDialog();
        }

        private void btn_Consultar_Paciente_Click(object sender, RoutedEventArgs e)
        {
            ConsultarPaciente nuevaConsulta = new();
            nuevaConsulta.ShowDialog();
        }
    }
}
