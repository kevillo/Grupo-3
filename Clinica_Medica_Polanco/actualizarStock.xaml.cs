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
    /// Lógica de interacción para actualizarStock.xaml
    /// </summary>
    public partial class actualizarStock : Window
    {

        int codEmpleador = 0;
        public actualizarStock(int cod)
        {
            codEmpleador = cod;
            InitializeComponent();
            this.SourceInitialized += ActualizarStock_SourceInitialized;
            int codSucursal = Ventas.ventasDAL.obtenerIdSucursal(codEmpleador);
            Proveedores.ProveedoresDAL.CargarProveedores(cmb_Proveedor_Actualizar_Stock);
            Proveedores.ProveedoresDAL.cargarEmpleados(cmb_Administrador_Actualizar, codSucursal);
        }

        // Funcion para no mover la ventana del form
        private void ActualizarStock_SourceInitialized(object sender, EventArgs e)
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

        private void btn_Actualizar_Stock_Click(object sender, RoutedEventArgs e)
        {
            int codSucursal = Ventas.ventasDAL.obtenerIdSucursal(codEmpleador);
            Inventario.inventarioDAL.actualizarStock(cmb_Administrador_Actualizar.SelectedIndex + 1, codSucursal, cmb_Proveedor_Actualizar_Stock.SelectedIndex + 1, codEmpleador);
            Inventario.inventarioDAL.ingresarInventario(int.Parse(txt_Codigo_Insumo_Actualizar_Stock.Text), int.Parse(txt_Cantidad_Actualizar_Stock.Text));


            this.Close();
        }

        private void txt_Codigo_Insumo_Actualizar_Stock_KeyUp(object sender, KeyEventArgs e)
        {
            stc_Insumo.Visibility = Visibility.Visible;
            scv_Insumo.Visibility = Visibility.Visible;
            brd_Insumo.Visibility = Visibility.Visible;
            //scv_BuscarPaciente.Background = new 
            bool found = false;
            var border = (stc_Insumo.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarProducto.GetData();

            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                // Clear   
                stc_Insumo.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list   
            stc_Insumo.Children.Clear();
            stc_Insumo.Children.Add(new TextBlock() { Text = "Codigo      Nombre" });
            // Add the result   
            foreach (var obj in data)
            {
                if (obj.Split(" - ")[1].ToLower().StartsWith(query.ToLower()) || obj.Split(" - ")[0].ToLower().StartsWith(query.ToLower()))
                {
                    // The word starts with this... Autocomplete must work   
                    addItem(obj);
                    found = true;
                }
            }

            if (!found)
            {
                stc_Insumo.Children.Add(new TextBlock() { Text = "No existe ese producto o es invalido" });
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
                txt_Codigo_Insumo_Actualizar_Stock.Text = (sender as TextBlock).Text.Split(" - ")[0];
                stc_Insumo.Visibility = Visibility.Hidden;
                scv_Insumo.Visibility = Visibility.Hidden;
                brd_Insumo.Visibility = Visibility.Hidden;
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
            stc_Insumo.Children.Add(block);
        }
    }
}
