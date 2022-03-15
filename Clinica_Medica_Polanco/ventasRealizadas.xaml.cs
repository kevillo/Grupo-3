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
using Clinica_Medica_Polanco.Ventas;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para ventasRealizadas.xaml
    /// </summary>
    public partial class ventasRealizadas : Window
    {
        int codEmpleador = 0;
        public ventasRealizadas(int cod)
        {
            codEmpleador = cod;

            InitializeComponent();
            this.SourceInitialized += VentasRealizadas_SourceInitialized;

          //  dtg_Ventas_Realizadas.ItemsSource = ventasDAL.MostrarVentas();
        }

        private void VentasRealizadas_SourceInitialized(object sender, EventArgs e)
        {
            WindowInteropHelper helper = new(this);
            HwndSource souce = HwndSource.FromHwnd(helper.Handle);
            souce.AddHook(WndProc);
        }

        // Funcion para no mover la ventana del form
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int codSucursal = ventasDAL.obtenerIdSucursal(codEmpleador);
            dtg_Ventas_Realizadas.ItemsSource = ventasDAL.MostrarVentas(codSucursal);
        }
    }
}
