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
using Clinica_Medica_Polanco.Proveedores;


namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para eliminarProveedor.xaml
    /// </summary>
    public partial class eliminarProveedor : UserControl
    {
        public eliminarProveedor()
        {
            InitializeComponent();
        }

        private void btn_Deshabilitar_proveedor_Click(object sender, RoutedEventArgs e)
        {
            int codEliminar = !string.IsNullOrEmpty(txt_Codigo_Proveedor_Buscar.Text) ? int.Parse(txt_Codigo_Proveedor_Buscar.Text):0;
            if(codEliminar !=0)
                ProveedoresDAL.EliminarProveedor(codEliminar);
            else
            {
                MessageBox.Show("Ingrese un código de proveedor para eliminar");
                txt_Codigo_Proveedor_Buscar.Focus();
            }
            reiniciarPantalla();
        }

        private void txt_Codigo_Proveedor_Buscar_KeyUp(object sender, KeyEventArgs e)
        {
            stc_InfoProveedor.Visibility = Visibility.Visible;
            scv_BuscarProveedor.Visibility = Visibility.Visible;
            brd_BuscarProveedor.Visibility = Visibility.Visible;
            //scv_BuscarPaciente.Background = new 
            bool found = false;
            var border = (stc_InfoProveedor.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarProveedor.GetData();

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

            stc_InfoProveedor.Children.Add(new TextBlock() { Text = "Código          Nombre" });
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
                stc_InfoProveedor.Children.Add(new TextBlock() { Text = "No existe ese No. de Identidad de proveedor." });
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
                txt_Codigo_Proveedor_Buscar.Text = (sender as TextBlock).Text.Split(" - ")[0];
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

        public Proveedores.Proveedores proveedorSeleccionado { get; set; }
        public Proveedores.Proveedores proveedorActual { get; set; }

        private void btn_Buscar_Proveedor_Click(object sender, RoutedEventArgs e)
        {
            string buscar_Proveedor = txt_Codigo_Proveedor_Buscar.Text;

            if (!string.IsNullOrEmpty(buscar_Proveedor) && int.TryParse(buscar_Proveedor, out int _))
            {

                proveedorSeleccionado = ProveedoresDAL.BuscarProveedorPorId(int.Parse(buscar_Proveedor));
                proveedorActual = proveedorSeleccionado;
                txt_Nombre_Proveedor_Eliminar.Text = proveedorSeleccionado.NombreProveedor;
                txt_Apellido_Proveedor_Eliminar.Text = proveedorSeleccionado.ApellidoProveedor;
                txt_Correo_Proveedor_Eliminar.Text = proveedorSeleccionado.CorreoProveedor;
                txt_Telefono_Proveedor_Eliminar.Text = proveedorSeleccionado.TelefonoProveedor;
            }
            else
            {
                MessageBox.Show("Ingrese un id de proveedor válido.");
                txt_Codigo_Proveedor_Buscar.Clear();
                txt_Codigo_Proveedor_Buscar.Focus();
            }
            stc_InfoProveedor.Visibility = Visibility.Hidden;
            scv_BuscarProveedor.Visibility = Visibility.Hidden;
            brd_BuscarProveedor.Visibility = Visibility.Hidden;

        }
        private void reiniciarPantalla()
        {
            txt_Codigo_Proveedor_Buscar.Clear();
            txt_Nombre_Proveedor_Eliminar.Clear();
            txt_Apellido_Proveedor_Eliminar.Clear();
            txt_Telefono_Proveedor_Eliminar.Clear();
            txt_Correo_Proveedor_Eliminar.Clear();
        }

        //validacion para que solo se pueda ingresar numeros a un campo
        

        //validacion para que solo se pueda ingresar letras a un campo
        private void txt_Nombre_Proveedor_Eliminar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        //validacion para que solo se pueda ingresar letras a un campo
        private void txt_Apellido_Proveedor_Eliminar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        //validacion para que solo se pueda ingresar numeros a un campo
        private void txt_Telefono_Proveedor_Eliminar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }
    }
}
