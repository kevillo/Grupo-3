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
    /// Lógica de interacción para revisionExamen.xaml
    /// </summary>
    public partial class revisionExamen : Window
    {
        public revisionExamen()
        {
            InitializeComponent();
        }

        private void btn_Revision_Examen_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Revision_Examen_Ir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AnalizarExamenMedico nuevoAnalisis = new();
            nuevoAnalisis.ShowDialog();
        }
    }
}
