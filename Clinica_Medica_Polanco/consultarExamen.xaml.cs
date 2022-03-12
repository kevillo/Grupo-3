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
using Clinica_Medica_Polanco.ExamenesMedicos;
using System.Windows.Interop;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para consultarExamen.xaml
    /// </summary>
    public partial class consultarExamen : Window
    {
        public consultarExamen()
        {
            InitializeComponent();
            this.SourceInitialized += ConsultarExamen_SourceInitialized;

            ExamenesDAL.CargarSucursal(cmb_Sucursal_Buscar);
        }
        private void ConsultarExamen_SourceInitialized(object sender, EventArgs e)
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


        private void btn_Consulta_Examen_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Consulta_Examen_Buscar_Click(object sender, RoutedEventArgs e)
        {
            string consultarExamen = txt_Consulta_Examen_Buscar.Text;
            if (!string.IsNullOrEmpty(consultarExamen))
            {
                // aqui se traen los examenes por nombre de examenes o por codigo de la sucursal del empleado
            }
            else MessageBox.Show("No puede dejar el nombre de examen vacío ");
        }
    }
}
