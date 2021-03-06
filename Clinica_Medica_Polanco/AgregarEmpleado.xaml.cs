using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interop;
using Clinica_Medica_Polanco.Empleados;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para EliminarEmpleado.xaml
    /// </summary>
    public partial class AgregarEmpleado : Window
    {
        public AgregarEmpleado()
        {
            InitializeComponent();
            this.SourceInitialized += AgregarEmpleado_SourceInitialized;

            //Llamando la función para cargar datos de la bd a los cmb
            empleadosDAL.CargarJornada(cmb_Jornada_Laboral);
            empleadosDAL.CargarCargo(cmb_Cargo);
            empleadosDAL.CargarSucursal(cmb_Sucursal);

            dtp_Nacimiento.Text = DateTime.Now.ToShortDateString();
            dtp_Ingreso_Agregar_Empleado.Text = "1999/01/01";
            dtp_Pago_Agregar_Empleado.Text = "1999/01/01";

            //Estableciendo valores al cmb tipo sangre
            cmb_Tipo_Sangre.Items.Add("O-");
            cmb_Tipo_Sangre.Items.Add("O+");
            cmb_Tipo_Sangre.Items.Add("A+");
            cmb_Tipo_Sangre.Items.Add("A-");
            cmb_Tipo_Sangre.Items.Add("AB+");
            cmb_Tipo_Sangre.Items.Add("AB-");
            cmb_Tipo_Sangre.Items.Add("B-");
            cmb_Tipo_Sangre.Items.Add("B+");
        }
        private void btn_Salir_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btn_Agregar_Empleado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string direccionE = rtbAString(rtb_Direccion);
                Empleados.Empleados empleados1 = new();
                empleados1.NombreEmpleado = (txt_Nombre.Text).StartsWith(" ") ? null : (txt_Nombre.Text).EndsWith(" ") ? null : Regex.Replace(txt_Nombre.Text, "\\s+", " ");
                empleados1.ApellidoEmpleado = (txt_Apellido.Text).StartsWith(" ") ? null : (txt_Apellido.Text).EndsWith(" ") ? null : Regex.Replace(txt_Apellido.Text, "\\s+", " ");
                empleados1.IdentidadEmpleado = txt_Identidad.Text;
                empleados1.TelefonoEmpleado = txt_Telefono.Text;
                empleados1.FechaNacimientoEmpleado = string.IsNullOrEmpty(dtp_Nacimiento.Text)?DateTime.Now: Convert.ToDateTime(dtp_Nacimiento.Text);
                empleados1.CorreoEmpleado = (txt_Correo.Text).StartsWith(" ") ? " " : (txt_Correo.Text).EndsWith(" ") ? " " : txt_Correo.Text;
                // si esta vacio, devuelve 0, si no esta vacio, valida que sea un decimal convirtiendolo, si falla la conversion, devuelve un 0, sino lo que tenga el txt
                empleados1.AlturaEmpleado = (txt_Altura.Text).StartsWith(" ")?0:(txt_Altura.Text).EndsWith(" ")?0:string.IsNullOrEmpty(txt_Altura.Text)?0: decimal.Parse(Regex.Replace(txt_Altura.Text, "\\s", ""));
                empleados1.TipoSangreEmpleado = cmb_Tipo_Sangre.SelectedItem.ToString();
                empleados1.DireccionEmpleado = (direccionE).StartsWith(" ") ? null : (direccionE).EndsWith(" ") ? null : Regex.Replace(direccionE, "\\s+", " ");
                empleados1.SueldoBase = string.IsNullOrEmpty(txt_Sueldo.Text) ? -1 : decimal.Parse(txt_Sueldo.Text);
                empleados1.FechaPago = string.IsNullOrEmpty(dtp_Pago_Agregar_Empleado.Text) ? DateTime.Now : Convert.ToDateTime(dtp_Pago_Agregar_Empleado.Text);
                empleados1.FechaContratacion = string.IsNullOrEmpty(dtp_Ingreso_Agregar_Empleado.Text) ? DateTime.Now : Convert.ToDateTime(dtp_Ingreso_Agregar_Empleado.Text);
                empleados1.CodigoJornada = cmb_Jornada_Laboral.SelectedIndex+1;
                empleados1.CodigoPuesto = cmb_Cargo.SelectedIndex+1;
                empleados1.CodigoSucursal = cmb_Sucursal.SelectedIndex+1;

                //Validación de un correo o identidad duplicada en la base de datos
                int validarIdentidad = empleadosDAL.ValidarIdentidadEmpleado(empleados1.IdentidadEmpleado);
                int validarCorreo = empleadosDAL.validarCorreoEmpleado(empleados1.CorreoEmpleado);

                //Si el correo está duplicado, manda error
                if (validarCorreo < 1)
                {
                    //Si la identidad está duplicada, manda error
                    if (validarIdentidad < 1)
                    {
                        empleadosDAL.AgregarEmpleado(empleados1);
                        this.Close();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Identidad repetida: Por favor, ingrese una identidad diferente.");
                        txt_Identidad.Clear();
                        txt_Identidad.Focus();
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Correo repetido: Por favor, ingrese un correo diferente.");
                    txt_Correo.Clear();
                    txt_Correo.Focus();
                }
            }

            catch (FormatException error) //Excepción que nos indicará si ocurre un error
            {
                if (error.StackTrace.Contains("Nombre")) ValidarCampos(txt_Nombre, leyenda: "Nombre");
                else if (error.StackTrace.Contains("Apellido")) ValidarCampos(txt_Apellido, leyenda: "Apellido");
                else if (error.StackTrace.Contains("Identidad")) ValidarCampos(txt_Identidad, leyenda: "Identidad");
                else if (error.StackTrace.Contains("Telefono")) ValidarCampos(txt_Telefono, leyenda: "Teléfono");
                else if (error.StackTrace.Contains("Correo")) ValidarCampos(txt_Correo, leyenda: "Correo");
                else if (error.StackTrace.Contains("Altura")) ValidarCampos(txt_Altura, leyenda: "Altura");
                else if (error.StackTrace.Contains("FechaNacimiento")) ValidarCampos(leyenda: "Fecha de nacimiento", dt: dtp_Nacimiento, refer: 2);
                else if (error.StackTrace.Contains("TipoSangre")) ValidarCampos(leyenda: "Tipo de sangre", cmb: cmb_Tipo_Sangre, refer: 3);
                else if (error.StackTrace.Contains("Direccion")) ValidarCampos(rtb: rtb_Direccion, leyenda: "Dirección", refer: 4);
                else if (error.StackTrace.Contains("Sueldo")) ValidarCampos(txt_Sueldo, leyenda: "Sueldo");
                else if (error.StackTrace.Contains("Cargo")) ValidarCampos(leyenda: "Cargo", cmb: cmb_Cargo, refer: 3);
                else if (error.StackTrace.Contains("Jornada")) ValidarCampos(leyenda: "Jornada laboral", cmb: cmb_Jornada_Laboral, refer: 3);
                else if (error.StackTrace.Contains("Sucursal")) ValidarCampos(leyenda: "Sucursal", cmb: cmb_Sucursal, refer: 3);
                else if (error.StackTrace.Contains("FechaPago")) ValidarCampos(leyenda: "Fecha de pago", dt: dtp_Pago_Agregar_Empleado, refer: 2);
                else if (error.StackTrace.Contains("FechaContratacion")) ValidarCampos(leyenda: "Fecha de ingreso", dt: dtp_Ingreso_Agregar_Empleado, refer: 2);

            }
            catch(OverflowException errorS)
            {
                if (errorS.StackTrace.Contains("Altura")) ValidarCampos(txt_Altura, leyenda: "Altura");
                else if (errorS.StackTrace.Contains("Sueldo")) ValidarCampos(txt_Sueldo, leyenda: "Sueldo base");

            }
        }
        //Validar campos
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

        /// <summary>
        /// Funcion para evitar el movimiento del formulario
        /// </summary>
        private void AgregarEmpleado_SourceInitialized(object sender, EventArgs e)
        {
            WindowInteropHelper helper = new(this);
            HwndSource souce = HwndSource.FromHwnd(helper.Handle);
            souce.AddHook(WndProc);
        }
        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MOVE = 0xF010;
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {

            switch (msg)
            {
                case WM_SYSCOMMAND:
                    int command = wParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                    {
                        handled = true;
                    }
                    break;
                default:
                    break;
            }
            return IntPtr.Zero;
        }
        //Validación para que solo se pueda ingresar letras a un campo
        private void txt_Nombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        //validacion para que solo se pueda ingresar numeros a un campo
        private void txt_Identidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        //Validación para que solo se pueda ingresar letras a un campo
        private void txt_Apellido_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        //validacion para que solo se pueda ingresar numeros a un campo
        private void txt_Telefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        //Validación para que solo se pueda ingresar números a un campo
        private void txt_Altura_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        //Validación para que solo se pueda ingresar números a un campo
        private void txt_Sueldo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        //Validación para que solo se pueda ingresar letras a un campo
        private void txt_Correo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if ((ascci >= 65 && ascci <= 90) || (ascci >= 97 && ascci <= 122) || (ascci >= 48 && ascci <= 57) || ascci == 64 || ascci == 95 || ascci == 46 || ascci == 45)

                e.Handled = false;

            else e.Handled = true;
        }
    }
}