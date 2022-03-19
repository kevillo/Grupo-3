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

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para ProcesoCorreo.xaml
    /// </summary>
    public partial class ProcesoCorreo : Window
    {
        private servicios.serviciosEntrega entregarVenta = new();
        public ProcesoCorreo(servicios.serviciosEntrega nuevo)
        {
            InitializeComponent();
            entregarVenta = nuevo;

            Pacientes.Pacient entregarPaciente = Pacientes.PacientesDAL.BuscarPaciente(entregarVenta.CodigoPaciente);


            txt_Nombre_Analisis.Text = nuevo.NombrePaciente;
            txt_Orden_Analisis.Text = entregarVenta.CodFacturaVenta.ToString();
            txt_Fecha_Orden_Analisis.Text = entregarVenta.FechaOrden.ToShortDateString();
            txt_Fecha_Nacimiento_Analisis.Text = entregarPaciente.FechaNacimiento.ToShortDateString();
            txt_Correo_Analisis.Text = entregarPaciente.Correo;
            string diagnosticoExamen = Ventas.ventasDAL.traerDiagnostico(entregarVenta.CodFacturaVenta, entregarVenta.CodigoExamenMedico);
            strToRTB(rtb_Diagnostico_Analisis, diagnosticoExamen);
            
        }
        private void strToRTB(RichTextBox rtb, string textoSet)
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            textRange.Text = textoSet;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Proceso_Envio_Click(object sender, RoutedEventArgs e)
        {
            EnviarCorreo enviarCorreo = new EnviarCorreo(txt_Correo_Analisis.Text);
            enviarCorreo.ShowDialog();
            this.Close();
        }

      
    }
}
