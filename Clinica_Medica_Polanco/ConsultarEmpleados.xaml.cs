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
using Clinica_Medica_Polanco.Empleados;


namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para ConsultarEmpleados.xaml
    /// </summary>
    public partial class ConsultarEmpleados : Window
    {
        public ConsultarEmpleados()
        {
            InitializeComponent();
            this.SourceInitialized += ConsultarEmpleados_SourceInitialized;
        }

   
        private void ConsultarEmpleados_SourceInitialized(object sender, EventArgs e)
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
        private void btn_ConsultarEmpleados_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Consultar_Empleados_Buscar_Click(object sender, RoutedEventArgs e)
        {
            string consultar_empleado = txt_Consultar_Empleados_Buscar.Text;
            if (!string.IsNullOrEmpty(consultar_empleado))
                dtg_Consultar_Empleados.ItemsSource = empleadosDAL.BuscarEmpleado(consultar_empleado);
            else MessageBox.Show("Ingrese un id de empleado válido");
        }
    }
}
