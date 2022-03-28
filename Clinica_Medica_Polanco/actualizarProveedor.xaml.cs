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
using System.Windows.Interop;
using Clinica_Medica_Polanco.Proveedores;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

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

            //Llamado de función para cargar datos desde la bd al cmb
            ProveedoresDAL.CargarAreaTrabajo(cmb_Area_Trabajo_Proveedor_Actualizar);
        }

        private void btn_Actualizar_Informacion_Proveedor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_Codigo_Proveedor_Actualizar.Text))
                {
                    int codProveedor = int.Parse(txt_Codigo_Proveedor_Actualizar.Text);
                    string direccionPr = rtbAString(rtb_Direccion_Proveedor_Actualizar);
                    Proveedores.Proveedores proveedores1 = new();
                    proveedores1.CodigoProveedor = codProveedor;
                    proveedores1.NombreProveedor = (txt_Nombre_Proveedor_Actualizar.Text).StartsWith(" ") ? null : (txt_Nombre_Proveedor_Actualizar.Text).EndsWith(" ") ? null : Regex.Replace(txt_Nombre_Proveedor_Actualizar.Text, "\\s+", " ");
                    proveedores1.ApellidoProveedor = (txt_Apellido_Proveedor_Actualizar.Text).StartsWith(" ") ? null : (txt_Apellido_Proveedor_Actualizar.Text).EndsWith(" ") ? null : Regex.Replace(txt_Apellido_Proveedor_Actualizar.Text, "\\s+", " ");
                    proveedores1.TelefonoProveedor = txt_Telefono_Proveedor_Actualizar.Text;
                    proveedores1.CorreoProveedor = (txt_Correo_Proveedor_Actualizar.Text).StartsWith(" ") ? " " : (txt_Correo_Proveedor_Actualizar.Text).EndsWith(" ") ? " " : txt_Correo_Proveedor_Actualizar.Text;
                    proveedores1.DireccionProveedor = (direccionPr).StartsWith(" ") ? null : (direccionPr).EndsWith(" ") ? null : Regex.Replace(direccionPr, "\\s+", " ");
                    proveedores1.CodigoAreaTrabajo = cmb_Area_Trabajo_Proveedor_Actualizar.SelectedIndex + 1;
                    proveedores1.EstadoProveedor = (bool)chb_Disponibilidad_Proveedor_Actualizar.IsChecked;

                    //validacion de un correo duplicado en la base de datos
                    int validarCorreo = ProveedoresDAL.ValidarCorreoProveedor(proveedores1.CorreoProveedor);

                    //Si el correo está duplicado, manda error
                    if (validarCorreo < 1)
                    {
                        ProveedoresDAL.ModificarProveedor(proveedores1);
                        reiniciarPantalla();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Correo repetido: Por favor, ingrese un correo diferente.");
                        txt_Correo_Proveedor_Actualizar.Clear();
                        txt_Correo_Proveedor_Actualizar.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un proveedor válido");
                    txt_Codigo_Proveedor_Actualizar.Clear();
                    txt_Codigo_Proveedor_Actualizar.Focus();
                    stc_Proveedor.Visibility = Visibility.Hidden;
                    scv_Proveedor.Visibility = Visibility.Hidden;
                    brd_Proveedor.Visibility = Visibility.Hidden;
                }
            }
            catch (FormatException error)
            {
                //Excepción que nos indicará si ocurre un error
                if (error.StackTrace.Contains("Nombre")) ValidarCampos(txt_Nombre_Proveedor_Actualizar, leyenda: "Nombre");
                else if (error.StackTrace.Contains("Apellido")) ValidarCampos(txt_Apellido_Proveedor_Actualizar, leyenda: "Apellido");
                else if (error.StackTrace.Contains("Telefono")) ValidarCampos(txt_Telefono_Proveedor_Actualizar, leyenda: "Teléfono");
                else if (error.StackTrace.Contains("Correo")) ValidarCampos(txt_Correo_Proveedor_Actualizar, leyenda: "Correo");
                else if (error.StackTrace.Contains("Direccion")) ValidarCampos(rtb: rtb_Direccion_Proveedor_Actualizar, leyenda: "Dirección", refer: 4);
                else if (error.StackTrace.Contains("AreaTrabajo")) ValidarCampos(leyenda: "Área de trabajo", cmb: cmb_Area_Trabajo_Proveedor_Actualizar, refer: 3);
            }
        }
        //Validar campos tipo txt, rtb, dt, cmb
        private void ValidarCampos([Optional] TextBox txts, [Optional] RichTextBox rtb, String leyenda, [Optional] DatePicker dt, [Optional] ComboBox cmb, [Optional] int refer)
        {
            MessageBox.Show("Procure no dejar un formato incorrecto o vacío en " + leyenda);

            if (refer == 2) dt.Focus();
            else if (refer == 3) cmb.Focus();
            else if (refer == 4) rtb.Focus();
            else txts.Focus();
        }
        private string rtbAString(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                rtb.Document.ContentStart,
                rtb.Document.ContentEnd
         );

            return textRange.Text;
        }

        private void txt_Codigo_Proveedor_Actualizar_KeyUp(object sender, KeyEventArgs e)
        {
            stc_Proveedor.Visibility = Visibility.Visible;
            scv_Proveedor.Visibility = Visibility.Visible;
            brd_Proveedor.Visibility = Visibility.Visible;
            //scv_BuscarPaciente.Background = new 
            bool found = false;
            var border = (stc_Proveedor.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarProveedor.GetData();

            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                // Clear   
                stc_Proveedor.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list   
            stc_Proveedor.Children.Clear();
            stc_Proveedor.Children.Add(new TextBlock() { Text = "Código          Nombre" });
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
                stc_Proveedor.Children.Add(new TextBlock() { Text = "No existe ese proveedor o el código es inválido." });
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
                txt_Codigo_Proveedor_Actualizar.Text = (sender as TextBlock).Text.Split(" - ")[0];
                stc_Proveedor.Visibility = Visibility.Hidden;
                scv_Proveedor.Visibility = Visibility.Hidden;
                brd_Proveedor.Visibility = Visibility.Hidden;
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
            stc_Proveedor.Children.Add(block);
        }
        public Proveedores.Proveedores proveedorSeleccionado { get; set; }
        public Proveedores.Proveedores proveedorActual { get; set; }

        private void btn_Buscar_Proveedor_Click(object sender, RoutedEventArgs e)
        {
            string buscar_Proveedor = txt_Codigo_Proveedor_Actualizar.Text;
            
            if (!string.IsNullOrEmpty(buscar_Proveedor) && int.TryParse(buscar_Proveedor, out int _))
            {
                proveedorSeleccionado = ProveedoresDAL.BuscarProveedorPorId(int.Parse(buscar_Proveedor));
                proveedorActual = proveedorSeleccionado;
                txt_Nombre_Proveedor_Actualizar.Text = proveedorSeleccionado.NombreProveedor;
                txt_Apellido_Proveedor_Actualizar.Text = proveedorSeleccionado.ApellidoProveedor;
                txt_Telefono_Proveedor_Actualizar.Text = proveedorSeleccionado.TelefonoProveedor;
                txt_Correo_Proveedor_Actualizar.Text = proveedorSeleccionado.CorreoProveedor;
                setTextToRTB(rtb_Direccion_Proveedor_Actualizar, proveedorSeleccionado.DireccionProveedor);
                cmb_Area_Trabajo_Proveedor_Actualizar.SelectedIndex = proveedorSeleccionado.CodigoAreaTrabajo-1;
                chb_Disponibilidad_Proveedor_Actualizar.IsChecked = proveedorSeleccionado.EstadoProveedor;
            }
            else
            {
                MessageBox.Show("Procure no dejar la Identidad del proveedor con un formato incorrecto o vacío.");
                txt_Codigo_Proveedor_Actualizar.Clear();
                txt_Codigo_Proveedor_Actualizar.Focus();
                stc_Proveedor.Visibility = Visibility.Hidden;
                scv_Proveedor.Visibility = Visibility.Hidden;
                brd_Proveedor.Visibility = Visibility.Hidden;
            }
        }
        private void setTextToRTB(RichTextBox rtb, string textoSet)
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            textRange.Text = textoSet;
        }
        //Función para reinicar pantalla y a la vez limpiar los campos
        private void reiniciarPantalla()
        {
            txt_Nombre_Proveedor_Actualizar.Clear();
            txt_Apellido_Proveedor_Actualizar.Clear();
            txt_Telefono_Proveedor_Actualizar.Clear();
            txt_Correo_Proveedor_Actualizar.Clear();
            rtb_Direccion_Proveedor_Actualizar.Document.Blocks.Clear();
            cmb_Area_Trabajo_Proveedor_Actualizar.SelectedIndex = 0;
        }

        //validacion para que solo se pueda ingresar letras a un campo
        private void txt_Nombre_Proveedor_Actualizar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        //validacion para que solo se pueda ingresar letras a un campo
        private void txt_Apellido_Proveedor_Actualizar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }
    }
}
