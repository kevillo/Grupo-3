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
    /// Lógica de interacción para actualizarProveedor.xaml
    /// </summary>
    public partial class actualizarProveedor : UserControl
    {
        public actualizarProveedor()
        {
            InitializeComponent();

            ProveedoresDAL.CargarAreaTrabajo(cmb_Area_Trabajo_Proveedor_Actualizar);
        }

        private void btn_Actualizar_Informacion_Proveedor_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Información actualizada correctamente");
        }

        private void txt_Codigo_Proveedor_Actualizar_KeyUp(object sender, KeyEventArgs e)
        {
            stc_InfoPaciente.Visibility = Visibility.Visible;
            scv_BuscarPaciente.Visibility = Visibility.Visible;
            brd_BuscarPaciente.Visibility = Visibility.Visible;
            //scv_BuscarPaciente.Background = new 
            bool found = false;
            var border = (stc_InfoPaciente.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarProveedor.GetData();

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
                txt_Codigo_Proveedor_Actualizar.Text = (sender as TextBlock).Text.Split("-")[1];
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
        public Proveedores.Proveedores proveedorSeleccionado { get; set; }
        public Proveedores.Proveedores proveedorActual { get; set; }

        private void btn_Buscar_Proveedor_Click(object sender, RoutedEventArgs e)
        {
            Proveedores.codigoAreaTrabajo nuevo = new();
            string buscar_Proveedor = txt_Codigo_Proveedor_Actualizar.Text;
            proveedorSeleccionado = Proveedores.ProveedoresDAL.BuscarProveedorPorId(buscar_Proveedor);

            if (!string.IsNullOrEmpty(buscar_Proveedor))
            {
                proveedorActual = proveedorSeleccionado;
                txt_Nombre_Proveedor_Actualizar.Text = proveedorSeleccionado.NombreProveedor;
                txt_Apellido_Proveedor_Actualizar.Text = proveedorSeleccionado.ApellidoProveedor;
                txt_Telefono_Proveedor_Actualizar.Text = proveedorSeleccionado.CorreoProveedor;
                txt_Correo_Proveedor_Actualizar.Text = proveedorSeleccionado.TelefonoProveedor;
                txt_Direccion_Proveedor_Actualizar.Text = proveedorSeleccionado.TelefonoProveedor;
                cmb_Area_Trabajo_Proveedor_Actualizar.SelectedIndex = proveedorSeleccionado.CodigoAreaTrabajo;
            }
            else MessageBox.Show("Ingrese un No. de Identidad de empleado válido");
        }
    }
}
