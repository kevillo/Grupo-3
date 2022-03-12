using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interop;
using Clinica_Medica_Polanco.Proveedores;
using System.Runtime.InteropServices;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para agregarProveedor.xaml
    /// </summary>
    public partial class agregarProveedor : UserControl
    {
        public agregarProveedor()
        {
            InitializeComponent();

            //Llamado a la función donde cargamos datos desde la bd al cmb áreaTrabajo
            ProveedoresDAL.CargarAreaTrabajo(cmb_Area_Trabajo_Proveedor_Agregar);
        }

        private void btn_Agregar_Informacion_Proveedor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Validación de datos
                Proveedores.Proveedores proveedores1 = new();
                proveedores1.NombreProveedor = txt_Nombre_Proveedor_Agregar.Text;
                proveedores1.ApellidoProveedor = txt_Apellido_Proveedor_Agregar.Text;
                proveedores1.TelefonoProveedor = txt_Telefono_Proveedor_Agregar.Text;
                proveedores1.CorreoProveedor = txt_Correo_Proveedor_Agregar.Text;
                proveedores1.DireccionProveedor = string.IsNullOrWhiteSpace(rtbAString(rtb_Direccion_Proveedor)) ? null : rtbAString(rtb_Direccion_Proveedor);
                proveedores1.CodigoAreaTrabajo = cmb_Area_Trabajo_Proveedor_Agregar.SelectedIndex + 1;
                ProveedoresDAL.AgregarProveedor(proveedores1);
                reiniciarPantalla();
            }

            catch (FormatException error)
            {
                //Excepción que nos indica de algún error
                if (error.StackTrace.Contains("Nombre")) ValidarCampos(txt_Nombre_Proveedor_Agregar, leyenda: "Nombre");
                else if (error.StackTrace.Contains("Apellido")) ValidarCampos(txt_Apellido_Proveedor_Agregar, leyenda: "Apellido");
                else if (error.StackTrace.Contains("Telefono")) ValidarCampos(txt_Telefono_Proveedor_Agregar, leyenda: "Teléfono");
                else if (error.StackTrace.Contains("Correo")) ValidarCampos(txt_Correo_Proveedor_Agregar, leyenda: "Correo");
                else if (error.StackTrace.Contains("Direccion")) ValidarCampos(rtb: rtb_Direccion_Proveedor, leyenda: "Dirección", refer: 4);
                else if (error.StackTrace.Contains("Sucursal")) ValidarCampos(leyenda: "Sucursal", cmb: cmb_Area_Trabajo_Proveedor_Agregar, refer: 3);

            }
        }
        //Validando campos como txt, rtb, dt y cmb
        private void ValidarCampos([Optional] TextBox txts, [Optional] RichTextBox rtb, String leyenda, [Optional] DatePicker dt, [Optional] ComboBox cmb, [Optional] int refer)
        {
            MessageBox.Show("No se pueden dejar espacios en blanco o ingresar caracteres inválidos en " + leyenda);

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
        //Función para reinicar pantalla y a la vez limpiar los campos
        private void reiniciarPantalla()
        {
            txt_Nombre_Proveedor_Agregar.Clear();
            txt_Apellido_Proveedor_Agregar.Clear();
            txt_Telefono_Proveedor_Agregar.Clear();
            txt_Correo_Proveedor_Agregar.Clear();
            rtb_Direccion_Proveedor.Document.Blocks.Clear();
            cmb_Area_Trabajo_Proveedor_Agregar.SelectedIndex = 0;
        }
    }
}
