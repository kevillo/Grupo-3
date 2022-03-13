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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para EliminarInsumo.xaml
    /// </summary>
    public partial class EliminarInsumo : UserControl
    {
        public EliminarInsumo()
        {
            InitializeComponent();
        }

        private void btn_Deshabilitar_Insumo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Producto eliminado correctamente");
        }

        private void txt_Codigo_Insumo_KeyUp(object sender, KeyEventArgs e)
        {
            stc_InfoPaciente.Visibility = Visibility.Visible;
            scv_BuscarPaciente.Visibility = Visibility.Visible;
            brd_BuscarPaciente.Visibility = Visibility.Visible;
            //scv_BuscarPaciente.Background = new 
            bool found = false;
            var border = (stc_InfoPaciente.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarProducto.GetData();

            string query = (sender as TextBox).Text;

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

            // Add the result   
            foreach (var obj in data)
            {
                if (obj.ToLower().StartsWith(query.ToLower()))
                {
                    // The word starts with this... Autocomplete must work   
                    addItem(obj);
                    found = true;
                }
            }

            if (!found)
            {
                stc_InfoPaciente.Children.Add(new TextBlock() { Text = "No existe ese No. de Identidad de paciente." });
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
                txt_Codigo_Insumo.Text = (sender as TextBlock).Text.Split(" ")[0];
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

        public Insumos.Insumos insumoSeleccionado { get; set; }
        public Insumos.Insumos insumoActual { get; set; }
        public Proveedores.Proveedores proveedorSeleccionado { get; set; }
        public Proveedores.Proveedores proveedorActual { get; set; }
        private void btn__Buscar_Insumo_Click(object sender, RoutedEventArgs e)
        {
            string buscar_Insumo = txt_Codigo_Insumo.Text;
            insumoSeleccionado = Insumos.insumosDAL.BuscarInsumoPorNombreOId(buscar_Insumo);

            if (!string.IsNullOrEmpty(buscar_Insumo))
            {
                insumoActual = insumoSeleccionado;
                proveedorActual = proveedorSeleccionado;
                txt_Nombre_Insumo.Text = insumoSeleccionado.NombreInsumo;
                //txt_Nombre_Proveedor.Text = proveedorSeleccionado.NombreProveedor;
                txt_Precio_Unitario.Text = Convert.ToString(insumoSeleccionado.PrecioUnitario);
                txt_Numero_de_serie.Text = insumoSeleccionado.NumeroSerie;
            }
        }
    }
}
