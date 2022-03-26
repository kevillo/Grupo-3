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
            int codEliminar = 0;
            if (!string.IsNullOrEmpty(txt_Codigo_Insumo.Text))
            {
                codEliminar = int.Parse(txt_Codigo_Insumo.Text);
                Insumos.insumosDAL.EliminarInsumo(codEliminar);
            }
            else
            {
               MessageBox.Show("Procure no dejar el Código de insumo con un formato incorrecto o vacío.");
               txt_Codigo_Insumo.Clear();
               txt_Codigo_Insumo.Focus();
            }
            reiniciarPantalla();
        }
        private void reiniciarPantalla()
        {
            txt_Codigo_Insumo.Clear();
            txt_Fecha_Expiración_Insumo.Clear();
            txt_Nombre_Insumo.Clear();
            txt_Numero_de_serie.Clear();
            txt_Precio_Unitario.Clear();
        }

        private void txt_Codigo_Insumo_KeyUp(object sender, KeyEventArgs e)
        {
            stc_InfoProveedor.Visibility = Visibility.Visible;
            scv_BuscarProveedor.Visibility = Visibility.Visible;
            brd_BuscarProveedor.Visibility = Visibility.Visible;
            //scv_BuscarPaciente.Background = new 
            bool found = false;
            var border = (stc_InfoProveedor.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarProducto.GetData();

            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                // Clear   
                stc_InfoProveedor.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list   
            stc_InfoProveedor.Children.Clear();

            stc_InfoProveedor.Children.Add(new TextBlock() { Text = "Código      Nombre" });
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
                stc_InfoProveedor.Children.Add(new TextBlock() { Text = "No existe ese producto o es inválido" });
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
                txt_Codigo_Insumo.Text = (sender as TextBlock).Text.Split(" - ")[0];
                stc_InfoProveedor.Visibility = Visibility.Hidden;
                scv_BuscarProveedor.Visibility = Visibility.Hidden;
                brd_BuscarProveedor.Visibility = Visibility.Hidden;
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
            stc_InfoProveedor.Children.Add(block);
        }

        public Insumos.Insumos insumoSeleccionado { get; set; }
        public Insumos.Insumos insumoActual { get; set; }
        private void btn__Buscar_Insumo_Click(object sender, RoutedEventArgs e)
        {
            string buscar_Insumo = txt_Codigo_Insumo.Text;

            if (!string.IsNullOrEmpty(buscar_Insumo) && int.TryParse(buscar_Insumo,out int _))
            {

                insumoSeleccionado = Insumos.insumosDAL.BuscarInsumoPorNombreOId(int.Parse(buscar_Insumo));
                insumoActual = insumoSeleccionado;
                txt_Nombre_Insumo.Text = insumoSeleccionado.NombreInsumo;
                txt_Fecha_Expiración_Insumo.Text = Convert.ToString(insumoSeleccionado.FechaExpiracion);
                txt_Precio_Unitario.Text = Convert.ToString(insumoSeleccionado.PrecioUnitario);
                txt_Numero_de_serie.Text = insumoSeleccionado.NumeroSerie;
            }
            else
            {
                MessageBox.Show("Por favor ingrese un insumo válido.");
                txt_Codigo_Insumo.Clear();
                txt_Codigo_Insumo.Focus();
                stc_InfoProveedor.Visibility = Visibility.Hidden;
                scv_BuscarProveedor.Visibility = Visibility.Hidden;
                brd_BuscarProveedor.Visibility = Visibility.Hidden;
            }
        }

        //validacion para que solo se pueda ingresar letras a un campo
        private void txt_Nombre_Insumo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        //validacion para que solo se pueda ingresar numeros a un campo
        private void txt_Numero_de_serie_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        //validacion para que solo se pueda ingresar numeros a un campo
        private void txt_Codigo_Insumo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }
    }
}
