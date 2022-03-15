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
        int codEmpleador = 0;
        public consultarExamen(int codEmpleado)
        {
            codEmpleador = codEmpleado;
            InitializeComponent();
            this.SourceInitialized += ConsultarExamen_SourceInitialized;

            ExamenesDAL.CargarSucursal(cmb_Sucursal_Buscar);
            cmb_Sucursal_Buscar.SelectedIndex = Ventas.ventasDAL.obtenerIdSucursal(codEmpleado) - 1;
            cmb_Sucursal_Buscar.Items.Add("Global");
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
            
            if (cmb_Sucursal_Buscar.SelectedIndex == 3)
            {
                dtg_Consulta_Examen_Examenes.ItemsSource = ExamenesDAL.obtenerInforPorSucursalExamen(consultarExamen);
            }
            else if (!string.IsNullOrEmpty(consultarExamen))
            {
                int codExamen = int.Parse(consultarExamen);
                int codSucursal = cmb_Sucursal_Buscar.SelectedIndex + 1;
                dtg_Consulta_Examen_Examenes.ItemsSource  = ExamenesDAL.obtenerInforPorSucursalExamen(codSucursal, codExamen);
            }
            else
            {

                int codSucursal = cmb_Sucursal_Buscar.SelectedIndex + 1;
                dtg_Consulta_Examen_Examenes.ItemsSource = ExamenesDAL.obtenerInforPorSucursalExamen(codSucursal);
            }
        }

        private void txt_Consulta_Examen_Buscar_KeyUp(object sender, KeyEventArgs e)
        {
            stc_InfoPaciente.Visibility = Visibility.Visible;
            scv_BuscarPaciente.Visibility = Visibility.Visible;
            brd_BuscarPaciente.Visibility = Visibility.Visible;
            //scv_BuscarPaciente.Background = new 
            bool found = false;
            var border = (stc_InfoPaciente.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarExamenMedico.GetData(); // trae la lista de las coincidencias

            string query = (sender as TextBox).Text;

            // condiciona si hay o no texto en el textbox
            if (query.Length == 0)
            {
                // Clear   
                stc_InfoPaciente.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list   
            stc_InfoPaciente.Children.Clear();

            stc_InfoPaciente.Children.Add(new TextBlock() { Text = "Codigo      Descripcion" });
            // Add the result   
            foreach (var obj in data)
            {
                // aqui se compara el texto ingresado con el texto en el autocompletado mostrado
                if (obj.Split(" - ")[0].ToLower().StartsWith(query.ToLower()) || obj.Split(" - ")[1].ToLower().StartsWith(query.ToLower()))
                {
                    // The word starts with this... Autocomplete must work   
                    addItem(obj);
                    found = true;
                }
            }

            if (!found)
            {
                stc_InfoPaciente.Children.Add(new TextBlock() { Text = "No existe ese código de examen médico." });
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
                txt_Consulta_Examen_Buscar.Text = (sender as TextBlock).Text.Split("-")[0];
                stc_InfoPaciente.Visibility = Visibility.Hidden;
                scv_BuscarPaciente.Visibility = Visibility.Hidden;
                brd_BuscarPaciente.Visibility = Visibility.Hidden;
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
            stc_InfoPaciente.Children.Add(block);
        }
    }
}
