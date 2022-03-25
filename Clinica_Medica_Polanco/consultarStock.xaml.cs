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
    /// Lógica de interacción para consultarStock.xaml
    /// </summary>
    public partial class consultarStock : UserControl
    {
        public consultarStock()
        {
            InitializeComponent();
        }

        private void txt_Consultar_Stock_Codigo_Producto_KeyUp(object sender, KeyEventArgs e)
        {
            stc_InfoStock.Visibility = Visibility.Visible;
            scv_BuscarStock.Visibility = Visibility.Visible;
            brd_BuscarStock.Visibility = Visibility.Visible;
            //scv_BuscarPaciente.Background = new 
            bool found = false;
            var border = (stc_InfoStock.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarProducto.GetData();

            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                // Clear   
                stc_InfoStock.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list   
            stc_InfoStock.Children.Clear();
            stc_InfoStock.Children.Add(new TextBlock() { Text = "Codigo      Nombre" });
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
                stc_InfoStock.Children.Add(new TextBlock() { Text = "No existe ese producto o es invalido" });
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
                txt_Consultar_Stock_Codigo_Producto.Text = (sender as TextBlock).Text.Split(" - ")[0];
                stc_InfoStock.Visibility = Visibility.Hidden;
                scv_BuscarStock.Visibility = Visibility.Hidden;
                brd_BuscarStock.Visibility = Visibility.Hidden;
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
            stc_InfoStock.Children.Add(block);
        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            int codInsumo = 0;
            if(!string.IsNullOrEmpty(txt_Consultar_Stock_Codigo_Producto.Text))
            {
                codInsumo = int.Parse(txt_Consultar_Stock_Codigo_Producto.Text);

                Insumos.Insumos nuevoInsumo = Insumos.insumosDAL.obtenerInfoStock(codInsumo);

                List<string> informacionSucursales = Insumos.insumosDAL.obtenerInfoStockSucursal(codInsumo);

                lbl_Consultar_Stock_Nombre.Content = nuevoInsumo.NombreInsumo;
                lbl_Consultar_Stock_Categoria.Content = nuevoInsumo.DescripcionCategoriaInsumo;
                lbl_Consultar_Stock_Codigo.Content = nuevoInsumo.CodigoInsumo;
                lbl_Consultar_Stock_Fecha_Expiracion.Content = nuevoInsumo.FechaExpiracion.ToShortDateString();
                lbl_Consultar_Stock_Num_Serie.Content = nuevoInsumo.NumeroSerie;
                lbl_Consultar_Stock_Estado.Content = Equals(nuevoInsumo.Estado,true) ? "Disponible" : "No disponible";
                lbl_Consultar_Stock_Producto_Stock.Content = nuevoInsumo.Existencia;
                lbl_Consultar_Stock_Producto_Dia.Content = Math.Round(nuevoInsumo.PrecioUnitario,2);
                int cont = informacionSucursales.Count;

                lbl_Consultar_Stock_Sucursales1.Content = (cont < 1) ? "" : !string.IsNullOrEmpty(informacionSucursales[^cont]) ? informacionSucursales[0].Split(" -> ")[0] : "";
                lbl_Consultar_Stock_Sucursales1_existencia.Content = (cont < 1) ? "" : !string.IsNullOrEmpty(informacionSucursales[^cont--]) ? informacionSucursales[0].Split(" -> ")[1] : "";

                lbl_Consultar_Stock_Sucursales2.Content = (cont < 1) ? "" : !string.IsNullOrEmpty(informacionSucursales[^cont]) ? informacionSucursales[1].Split(" -> ")[0] : "";
                lbl_Consultar_Stock_Sucursales2_existencia.Content = (cont < 1) ? "" : !string.IsNullOrEmpty(informacionSucursales[^cont--]) ? informacionSucursales[1].Split(" -> ")[1] : "";

                lbl_Consultar_Stock_Sucursales3.Content = (cont < 1) ? "" : !string.IsNullOrEmpty(informacionSucursales[^cont]) ? informacionSucursales[2].Split(" -> ")[0] : "";
                lbl_Consultar_Stock_Sucursales3_existencia.Content = (cont < 1) ? "" : !string.IsNullOrEmpty(informacionSucursales[^cont--]) ? informacionSucursales[2].Split(" -> ")[1] : "";
            }
            else
            {
                MessageBox.Show("Por favor ingrese un insumo valido");
                txt_Consultar_Stock_Codigo_Producto.Clear();
                txt_Consultar_Stock_Codigo_Producto.Focus();
                stc_InfoStock.Visibility = Visibility.Hidden;
                scv_BuscarStock.Visibility = Visibility.Hidden;
                brd_BuscarStock.Visibility = Visibility.Hidden;
            }
        }
    }
}
