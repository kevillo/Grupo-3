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
    public partial class revisionExamen : Window
    {
        public revisionExamen()
        {
            InitializeComponent();
            this.SourceInitialized += RevisionExamen_SourceInitialized;
            List<Ventas.Ventas> analizarVentas = ExamenesMedicos.ExamenesDAL.analsisExamen();
            dtg_Revision_Examen_Examenes.ItemsSource = analizarVentas;

        }

        // Funcion para no mover la ventana del form
        private void RevisionExamen_SourceInitialized(object sender, EventArgs e)
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




        private void btn_Revision_Examen_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Revision_Examen_Ir_Click(object sender, RoutedEventArgs e)
        {

            if (dtg_Revision_Examen_Examenes.Items.Count > 0)
            {

                Ventas.Ventas venta = (Ventas.Ventas)dtg_Revision_Examen_Examenes.SelectedItem;
                
                this.Close();
                AnalizarExamenMedico nuevoAnalisis = new(venta);
                nuevoAnalisis.ShowDialog();
            }
            else MessageBox.Show("No hay exámenes por revisar");
        }

    }
}
