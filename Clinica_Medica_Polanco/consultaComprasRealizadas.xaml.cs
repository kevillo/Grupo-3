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
    /// Lógica de interacción para consultaComprasRealizadas.xaml
    /// </summary>
    public partial class consultaComprasRealizadas : Window
    {

        int codEmpleador = 0;
        public consultaComprasRealizadas(int cod)
        {
            codEmpleador = cod;
            InitializeComponent();
            this.SourceInitialized += ConsultarComprasRealizadas_SourceInitialized;
        }

        private void btn_Consulta_Compras_Realizadas_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Función para evitar el movimiento del form
        private void ConsultarComprasRealizadas_SourceInitialized(object sender, EventArgs e)
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int codSucursal = ventasDAL.obtenerIdSucursal(codEmpleador);
            dtg_Consulta_Compras_Realizadas.ItemsSource = Compras.comprasDAL.obtenerInfoCompras(codSucursal);
        }
    }
}
