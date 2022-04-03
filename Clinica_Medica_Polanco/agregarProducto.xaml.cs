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
using Clinica_Medica_Polanco.Insumos;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para agregarProducto.xaml
    /// </summary>
    public partial class agregarProducto : UserControl
    {
        public agregarProducto()
        {
            InitializeComponent();
            insumosDAL.CargarTipoInsumo(cmb_Tipo_Insumo);
            dtp_Fecha_Expiracion.Text = DateTime.Now.ToShortDateString();
        }

        private void btn_Agregar_Producto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Validación de datos
                Insumos.Insumos nuevoInsumo = new();
                nuevoInsumo.NombreInsumo = (txt_Nombre_Producto.Text).StartsWith(" ") ? null : (txt_Nombre_Producto.Text).EndsWith(" ") ? null : int.TryParse(txt_Nombre_Producto.Text,out int _)? null : Regex.Replace(txt_Nombre_Producto.Text, "\\s+", " ");
                nuevoInsumo.NumeroSerie = (txt_Numero_Serie.Text).StartsWith(" ") ? null : (txt_Numero_Serie.Text).EndsWith(" ") ? null : Regex.Replace(txt_Numero_Serie.Text, "\\s+", " ");
                nuevoInsumo.PrecioUnitario = (txt_Precio_Unitario.Text).StartsWith(" ") ? 0 : (txt_Precio_Unitario.Text).EndsWith(" ") ? 0 : string.IsNullOrEmpty(txt_Precio_Unitario.Text) ? 0 : decimal.Parse(Regex.Replace(txt_Precio_Unitario.Text, "\\s", ""));
                nuevoInsumo.CodigoCategoriaInsumo = cmb_Tipo_Insumo.SelectedIndex+1;
                nuevoInsumo.FechaExpiracion = string.IsNullOrEmpty(dtp_Fecha_Expiracion.Text) ? DateTime.Now : Convert.ToDateTime(dtp_Fecha_Expiracion.Text);
                nuevoInsumo.Estado = (bool)chb_Disponibilidad.IsChecked;

                //Validación de número de serie duplicada en la base de datos
                int ValidadNumeroSerieInsumo = insumosDAL.ValidadNumeroSerieInsumo(nuevoInsumo.NumeroSerie);

                //Si el número de serie está duplicado, manda error
                if (ValidadNumeroSerieInsumo < 1)
                {
                    insumosDAL.AgregarInsumo(nuevoInsumo);
                    reiniciarPantalla();
                }
                else
                {
                    System.Windows.MessageBox.Show("Número de serie repetido: Por favor, ingrese otro número.");
                    txt_Numero_Serie.Clear();
                    txt_Numero_Serie.Focus();
                }

            }
            catch(FormatException error)
            {
                //Excepción que nos indicará si ocurre un error
                if (error.StackTrace.Contains("NombreInsumo")) validarCampos(txt_Nombre_Producto,leyenda: "Nombre insumo" );
                else if (error.StackTrace.Contains("NumeroSerie")) validarCampos(txt_Numero_Serie, leyenda: "Numero serie");
                else if (error.StackTrace.Contains("PrecioUnitario")) validarCampos(txt_Precio_Unitario, leyenda: "precio unitario");
                else if (error.StackTrace.Contains("CodigoCategoriaInsumo")) validarCampos(cmb: cmb_Tipo_Insumo, leyenda: "tipo insumo", refer: 3);
                else if (error.StackTrace.Contains("FechaExpiracion")) validarCampos(dt: dtp_Fecha_Expiracion, leyenda: "Fecha expiracion", refer: 2);

            }
        }

        //Validar campos de tipo txt, cmb. rtb y dt
        private void validarCampos([Optional] TextBox txts, [Optional] RichTextBox rtb, String leyenda, [Optional] DatePicker dt, [Optional] ComboBox cmb, [Optional] int refer)
        {
            MessageBox.Show("Procure no dejar un formato incorrecto o vacío en " + leyenda);

            if (refer == 2) dt.Focus();
            else if (refer == 3) cmb.Focus();
            else if (refer == 4) rtb.Focus();
            else txts.Focus();

        }
        //Función para reinicar pantalla y a la vez limpiar los campos
        private void reiniciarPantalla()
        {
            txt_Nombre_Producto.Clear();
            txt_Numero_Serie.Clear();
            txt_Precio_Unitario.Clear();
            cmb_Tipo_Insumo.SelectedIndex = 0;
            dtp_Fecha_Expiracion.Text = DateTime.Now.ToShortDateString();
            chb_Disponibilidad.IsChecked = false;
        }

        //validación para que solo se pueda ingresar numeros a un campo
        private void txt_Numero_Serie_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void txt_Nombre_Producto_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        private void txt_Precio_Unitario_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57 || ascci == 46) e.Handled = false;

            else e.Handled = true;
        }
    }
}
