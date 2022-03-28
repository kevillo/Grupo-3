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
using Clinica_Medica_Polanco.Insumos;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

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
            insumosDAL.CargarTipoInsumo(cmb_Gestionar_Insumo_Tipo_Insumo);

        }

        private void btn_Gestionar_Insumo_Actualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(txt_Gestionar_Insumos_Buscar.Text))
                {
                    Insumos.Insumos nuevoInsumo = new();
                    nuevoInsumo.CodigoInsumo = int.Parse(txt_Gestionar_Insumos_Buscar.Text);
                    nuevoInsumo.NombreInsumo = (txt_Gestionar_Insumos_Nombre_Producto.Text).StartsWith(" ") ? null : (txt_Gestionar_Insumos_Nombre_Producto.Text).EndsWith(" ") ? null : Regex.Replace(txt_Gestionar_Insumos_Nombre_Producto.Text, "\\s+", " ");
                    nuevoInsumo.NumeroSerie = txt_Gestionar_Insumos_Num_Serie.Text;
                    nuevoInsumo.PrecioUnitario = string.IsNullOrEmpty(txt_Gestionar_Insumos_Precio.Text) ? -1 : decimal.Parse(txt_Gestionar_Insumos_Precio.Text);
                    nuevoInsumo.CodigoCategoriaInsumo = cmb_Gestionar_Insumo_Tipo_Insumo.SelectedIndex + 1;
                    nuevoInsumo.FechaExpiracion = string.IsNullOrEmpty(dtp_Fecha_Expiracion.Text) ? DateTime.Now : Convert.ToDateTime(dtp_Fecha_Expiracion.Text);
                    nuevoInsumo.Estado = (bool)chk_Disponibilidad.IsChecked;
                    insumosDAL.ModificarInsumo(nuevoInsumo);         
                }
                else
                {
                    MessageBox.Show("Procure no dejar la Identidad del Insumo con un formato incorrecto o vacío.");
                    txt_Gestionar_Insumos_Buscar.Clear();   
                    txt_Gestionar_Insumos_Buscar.Focus();
                    stc_Insumo.Visibility = Visibility.Hidden;
                    scv_Insumo.Visibility = Visibility.Hidden;
                    brd_Insumo.Visibility = Visibility.Hidden;
                }
                reiniciarPantalla();
            }
            catch (FormatException error)
            {
                //Excepción que nos indicará si ocurre un error
                if (error.StackTrace.Contains("NombreInsumo")) validarCampos(txt_Gestionar_Insumos_Nombre_Producto, leyenda: "Nombre insumo");
                else if (error.StackTrace.Contains("NumeroSerie")) validarCampos(txt_Gestionar_Insumos_Num_Serie, leyenda: "Numero serie");
                else if (error.StackTrace.Contains("PrecioUnitario")) validarCampos(txt_Gestionar_Insumos_Precio, leyenda: "precio unitario");
                else if (error.StackTrace.Contains("CodigoInsumo")) validarCampos(txt_Gestionar_Insumos_Buscar, leyenda: "Codigo de insumo");
                else if (error.StackTrace.Contains("CodigoCategoriaInsumo")) validarCampos(cmb: cmb_Gestionar_Insumo_Tipo_Insumo, leyenda: "tipo insumo", refer: 3);
                else if (error.StackTrace.Contains("FechaExpiracion")) validarCampos(dt: dtp_Fecha_Expiracion, leyenda: "Fecha expiracion", refer: 2);
            }
        }
        private void reiniciarPantalla()
        {
            txt_Gestionar_Insumos_Nombre_Producto.Clear();
            txt_Gestionar_Insumos_Num_Serie.Clear();
            txt_Gestionar_Insumos_Precio.Clear();
            txt_Gestionar_Insumos_Buscar.Clear();
            cmb_Gestionar_Insumo_Tipo_Insumo.SelectedIndex = 0;
            dtp_Fecha_Expiracion.Text = DateTime.Now.ToShortDateString();
            chk_Disponibilidad.IsChecked = false;
        }


        private void validarCampos([Optional] TextBox txts, [Optional] RichTextBox rtb, String leyenda, [Optional] DatePicker dt, [Optional] ComboBox cmb, [Optional] int refer)
        {
            MessageBox.Show("Procure no dejar un formato incorrecto o vacío en " + leyenda);

            if (refer == 2) dt.Focus();
            else if (refer == 3) cmb.Focus();
            else if (refer == 4) rtb.Focus();
            else txts.Focus();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            menuPrincipalGestionarProveedores nuevoProveedor = new();
            nuevoProveedor.ShowDialog();
        }

        private void txt_Gestionar_Insumos_Buscar_KeyUp(object sender, KeyEventArgs e)
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
            stc_Insumo.Children.Add(new TextBlock() { Text = "Código      Nombre" });
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
                stc_Insumo.Children.Add(new TextBlock() { Text = "No existe ese insumo o es inválido" });
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

        public Insumos.Insumos insumoSeleccionado { get; set; }
     
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string buscar_Insumo = txt_Gestionar_Insumos_Buscar.Text;
            
            if (!string.IsNullOrEmpty(buscar_Insumo))
            {
                insumoSeleccionado = Insumos.insumosDAL.BuscarInsumoPorNombreOId(int.Parse(buscar_Insumo));
                txt_Gestionar_Insumos_Nombre_Producto.Text = insumoSeleccionado.NombreInsumo;
                txt_Gestionar_Insumos_Precio.Text = Convert.ToString(insumoSeleccionado.PrecioUnitario);
                txt_Gestionar_Insumos_Num_Serie.Text = insumoSeleccionado.NumeroSerie;
                dtp_Fecha_Expiracion.Text = Convert.ToString(insumoSeleccionado.FechaExpiracion);
                chk_Disponibilidad.IsChecked = insumoSeleccionado.Estado;
                cmb_Gestionar_Insumo_Tipo_Insumo.SelectedIndex = insumoSeleccionado.CodigoCategoriaInsumo - 1;
            }
            else
            {
                MessageBox.Show("Procure no dejar la Identidad de Insumo con un formato incorrecto o vacío.");
                txt_Gestionar_Insumos_Buscar.Clear();
                txt_Gestionar_Insumos_Buscar.Focus();
                stc_Insumo.Visibility = Visibility.Hidden;
                scv_Insumo.Visibility = Visibility.Hidden;
                brd_Insumo.Visibility = Visibility.Hidden;

            }
        }

        //validación para que solo se pueda ingresar letras a un campo
        private void txt_Gestionar_Insumos_Nombre_Producto_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        //validación para que solo se pueda ingresar numeros a un campo
        private void txt_Gestionar_Insumos_Num_Serie_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }
    }
}
