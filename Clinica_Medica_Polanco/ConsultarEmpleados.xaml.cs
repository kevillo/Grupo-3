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

        private void txt_Consultar_Empleados_Buscar_KeyUp(object sender, KeyEventArgs e)
        {
            stc_Empleados.Visibility = Visibility.Visible;
            scv_Empleados.Visibility = Visibility.Visible;
            brd_Empleados.Visibility = Visibility.Visible;
            //scv_BuscarPaciente.Background = new 
            bool found = false;
            var border = (stc_Empleados.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarEmpleado.GetData();

            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                // Clear   
                stc_Empleados.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list   
            stc_Empleados.Children.Clear();
            stc_Empleados.Children.Add(new TextBlock() { Text = "Identidad            Nombre      Apellido" });

            // Add the result   
            foreach (var obj in data)
            {
                if (obj.Split(" - ")[0].ToLower().StartsWith(query.ToLower())|| obj.Split(" - ")[1].ToLower().StartsWith(query.ToLower()))
                {
                    // The word starts with this... Autocomplete must work   
                    addItem(obj);
                    found = true;
                }
            }

            if (!found)
            {
                stc_Empleados.Children.Add(new TextBlock() { Text = "No existe ese No. de Identidad de paciente." });
            }
        }

        private void addItem(String text)
        {

            TextBlock block = new TextBlock();

            // Add the text   
            block.Text = text;


            // A little style...   
            block.Margin = new Thickness(2, 3, 2, 3);
            block.Cursor = Cursors.Hand;

            // Mouse events   
            block.MouseLeftButtonUp += (sender, e) =>
            {
                txt_Consultar_Empleados_Buscar.Text = (sender as TextBlock).Text.Split(" - ")[0];
                dtg_Consultar_Empleados.ItemsSource = empleadosDAL.BuscarEmpleado(txt_Consultar_Empleados_Buscar.Text);
                stc_Empleados.Visibility = Visibility.Hidden;
                scv_Empleados.Visibility = Visibility.Hidden;
                brd_Empleados.Visibility = Visibility.Hidden;
            };

            block.MouseEnter += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.PeachPuff;
            };

            block.MouseLeave += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.Transparent;
            };

            // Add to the panel   
            stc_Empleados.Children.Add(block);
        }
    }
}
