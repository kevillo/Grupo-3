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
            cmb_Tipo_Insumo.Items.Add("a");
            dtp_Fecha_Expiracion.Text = DateTime.Now.ToShortDateString();
        }


        private void btn_Agregar_Producto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Validación de datos
                Insumos.Insumos nuevoInsumo = new();
                nuevoInsumo.NombreInsumo = txt_Nombre_Producto.Text;
                nuevoInsumo.NumeroSerie = txt_Numero_Serie.Text;
                nuevoInsumo.PrecioUnitario =  string.IsNullOrEmpty(txt_Precio_Unitario.Text) ? -1 : int.Parse(txt_Precio_Unitario.Text);              
                nuevoInsumo.CodigoCategoriaInsumo = cmb_Tipo_Insumo.SelectedIndex+1;
                nuevoInsumo.FechaExpiracion = Convert.ToDateTime(dtp_Fecha_Expiracion.Text);
                nuevoInsumo.Estado = (bool)chb_Disponibilidad.IsChecked;
                insumosDAL.AgregarInsumo(nuevoInsumo);
                reiniciarPantalla();

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
            MessageBox.Show("No se pueden dejar espacios en blanco o ingresar caracteres inválidos en " + leyenda);

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


    }
}
