using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para EnviarCorreo.xaml
    /// </summary>
    public partial class EnviarCorreo : Window
    {
        Correo correo = new Correo();

        public EnviarCorreo(string correoEnviar)
        {
            InitializeComponent();
            txt_Correo_Para.Text = correoEnviar;
            
        }

        private void btn_Correo_Adjuntar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new Microsoft.Win32.OpenFileDialog();
                dialog.FileName = "Archivos"; 
                dialog.DefaultExt = ".txt, .pdf, .jpeg, .png";
                dialog.Filter = "Todos los archivos (*.png;*.jpeg;*.txt;*.pdf)|*.png;*.jpeg;*.txt;*.pdf|All files (*.*)|*.*"; 
                bool? result = dialog.ShowDialog();
                if (dialog.FileName.Equals("") == false)
                {
                    txt_Correo_Adjuntar.Text = dialog.FileName;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al adjuntar la ruta del archivo: ", ex.ToString());
            }
        }

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Correo_Enviar_Click(object sender, RoutedEventArgs e)
        {
           correo.enviarCorreo(txt_Correo_Para.Text, txt_Correo_Asunto.Text, txt_Correo_Adjuntar.Text, txt_Correo_Cuerpo.Text);
        }
    }
}