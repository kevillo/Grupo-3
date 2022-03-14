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
using Clinica_Medica_Polanco.Proveedores;
using System.Windows.Shapes;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para actualizarProducto.xaml
    /// </summary>
    public partial class actualizarProducto : UserControl
    {
        public actualizarProducto()
        {
            InitializeComponent();

        }

        private void btn_Gestionar_Insumo_Actualizar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Información actualizada correctamente");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            menuPrincipalGestionarProveedores nuevoProveedor = new();
            nuevoProveedor.ShowDialog();
        }

        private void txt_Gestionar_Insumos_Buscar_KeyUp(object sender, KeyEventArgs e)
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
            stc_InfoPaciente.Children.Add(new TextBlock() { Text = "Codigo      Nombre" });
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
                stc_InfoPaciente.Children.Add(new TextBlock() { Text = "No existe ese producto o es invalido" });
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
                txt_Gestionar_Insumos_Buscar.Text = (sender as TextBlock).Text.Split(" - ")[0];
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
        public Insumos.categoriaInsumo categoriaSeleccionada { get; set; }
        public Insumos.categoriaInsumo categoriaActual { get; set; }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string buscar_Insumo = txt_Gestionar_Insumos_Buscar.Text;
            insumoSeleccionado = Insumos.insumosDAL.BuscarInsumoPorNombreOId(buscar_Insumo);

            if (!string.IsNullOrEmpty(buscar_Insumo))
            {
                insumoActual = insumoSeleccionado;
                proveedorActual = proveedorSeleccionado;
                categoriaActual = categoriaSeleccionada;
                txt_Gestionar_Insumos_Nombre_Producto.Text = insumoSeleccionado.NombreInsumo;
                //cmb_Gestionar_Insumo_Nombre_Proveedor.Text = proveedorSeleccionado.NombreProveedor;
                txt_Gestionar_Insumos_Precio.Text = Convert.ToString(insumoSeleccionado.PrecioUnitario);
                txt_Gestionar_Insumos_Num_Serie.Text = insumoSeleccionado.NumeroSerie;
                txt_Gestionar_Insumos_Fecha_Expiracion.Text = Convert.ToString(insumoSeleccionado.FechaExpiracion);
                //cmb_Gestionar_Insumo_Tipo_Insumo.SelectedItem = categoriaSeleccionada.DescripcionCategoriaInsumo;
            }
        }
    }
}
