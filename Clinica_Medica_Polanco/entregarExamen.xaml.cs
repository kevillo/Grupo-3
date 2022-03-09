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
using System.Windows.Interop;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para revisionExamen.xaml
    /// </summary>
    public partial class entregarExamen : Window
    {
        public entregarExamen()
        {
            InitializeComponent();
            this.SourceInitialized += entregarExamen_SourceInitialized;
        }

        private void btn_Revision_Examen_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void entregarExamen_SourceInitialized(object sender, EventArgs e)
        {
            WindowInteropHelper helper = new(this);
            HwndSource souce = HwndSource.FromHwnd(helper.Handle);
            souce.AddHook(WndProc);
        }
        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MOVE = 0xF010;
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {

            switch (msg)
            {
                case WM_SYSCOMMAND:
                    int command = wParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                    {
                        handled = true;
                    }
                    break;
                default:
                    break;
            }
            return IntPtr.Zero;
        }

        private void btn_Entrega_Examen_Fisico_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Exámen/es actualizado/s");
            this.Close();
        }

        private void btn_Entrega_Examen_Correo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Exámen/es actualizado/s y enviados al correo");
            this.Close();
        }

        private void btn_Entrega_Examen_Buscar_Click(object sender, RoutedEventArgs e)
        {
            string clienteExamen = txt_Entrega_Examen_Buscar.Text;
            if (!string.IsNullOrEmpty(clienteExamen))
            {
                // traer los examenes de ese paciente , ordenados por estado 
            }
            else MessageBox.Show("No puede ir el id vacío");
        }
    }
}
