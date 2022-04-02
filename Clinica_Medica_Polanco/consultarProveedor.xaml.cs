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
    /// Lógica de interacción para consultarProveedor.xaml
    /// </summary>
    public partial class consultarProveedor : UserControl
    {
        public consultarProveedor()
        {
            InitializeComponent();

            //Cargar datos desde la bd al cmb
            ProveedoresDAL.CargarAreaTrabajo(cmb_Area_Trabajo);
        }

        private void txt_Gestionar_Proveedores_Buscar_KeyUp(object sender, KeyEventArgs e)
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
                txt_Gestionar_Proveedores_Buscar.Text = (sender as TextBlock).Text.Split(" - ")[0];
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

        private void btn_Gestionar_Proveedores_Buscar_Click(object sender, RoutedEventArgs e)
        {
            string provBuscar = txt_Gestionar_Proveedores_Buscar.Text;
            if (!string.IsNullOrEmpty(provBuscar) && int.TryParse(provBuscar, out int _) && !provBuscar.StartsWith(" ")  && !provBuscar.EndsWith(" ")&& int.Parse(provBuscar)>0)
            {
                Proveedores.Proveedores provConsultar = ProveedoresDAL.BuscarProveedorPorId(int.Parse(provBuscar));
                txt_Gestionar_Proveedores_Nombre.Text = provConsultar.NombreProveedor;
                txt_Gestionar_Proveedores_Apellido.Text = provConsultar.ApellidoProveedor;
                txt_Gestionar_Proveedores_Correo.Text = provConsultar.CorreoProveedor;
                strinARtb(rtb_Direccion_Proveedor, provConsultar.DireccionProveedor);
                txt_Gestionar_Proveedores_Nombre.Text = provConsultar.NombreProveedor;
                txt_Gestionar_Proveedores_Telefono.Text = provConsultar.TelefonoProveedor;
                cmb_Area_Trabajo.SelectedIndex = provConsultar.CodigoAreaTrabajo - 1;
                chb_Disponibilidad.IsChecked = provConsultar.EstadoProveedor;
                dtg_Gestionar_Proveedores_Consulta.ItemsSource = ProveedoresDAL.BuscarProveedor(provBuscar.Trim());
            }
            else
            {
                MessageBox.Show("Procure no dejar la Identidad del proveedor con un formato incorrecto o vacío.");
                txt_Gestionar_Proveedores_Buscar.Clear();
                txt_Gestionar_Proveedores_Buscar.Focus();
            }

            stc_InfoProveedor.Visibility = Visibility.Hidden;
            scv_BuscarProveedor.Visibility = Visibility.Hidden;
            brd_BuscarProveedor.Visibility = Visibility.Hidden;


        }

        private void strinARtb(RichTextBox rtb, string textoSet)
        {
            try
            {
                TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                textRange.Text = textoSet;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Error al recuperar la informacion del proveedor a buscar");
                txt_Gestionar_Proveedores_Buscar.Clear();
                txt_Gestionar_Proveedores_Buscar.Focus();
                stc_InfoProveedor.Visibility = Visibility.Hidden;
                scv_BuscarProveedor.Visibility = Visibility.Hidden;
                brd_BuscarProveedor.Visibility = Visibility.Hidden;
            }
           
        }
    }
}
