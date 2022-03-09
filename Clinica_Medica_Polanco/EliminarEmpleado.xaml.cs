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
    /// Lógica de interacción para EliminarEmpleado.xaml
    /// </summary>
    public partial class EliminarEmpleado : Window
    {
        public EliminarEmpleado()
        {
            InitializeComponent();
            this.SourceInitialized += EliminarEmpleado_SourceInitialized;
        }
        private void EliminarEmpleado_SourceInitialized(object sender, EventArgs e)
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


        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Borrar_Empleado_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Empleado eliminado correctamente");
            this.Close();
        }

        private void btn_Buscar_Eliminar_Empleado_Click(object sender, RoutedEventArgs e)
        {
            string consultar_empleado = txt_ID_Eliminar_Empleado.Text;
            if (!string.IsNullOrEmpty(consultar_empleado))
            {

            }
            else MessageBox.Show("Ingrese un id de empleado válido");
        }
    }
}
