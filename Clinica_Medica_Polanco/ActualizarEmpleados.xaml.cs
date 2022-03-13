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
using Clinica_Medica_Polanco.Empleados;
using System.Runtime.InteropServices;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para ActualizarEmpleados.xaml
    /// </summary>
    public partial class ActualizarEmpleados : Window
    {
        public ActualizarEmpleados()
        {
            InitializeComponent();
            this.SourceInitialized += ActualizarEmpleados_SourceInitialized;

            //Llamado de función para cargar datos desde la bd a cmb
            empleadosDAL.CargarJornada(cmb_Actualizar_Empleado_Jornada);
            empleadosDAL.CargarCargo(cmb_Actualizar_Empleado_Cargo);
            empleadosDAL.CargarSucursal(cmb_Actualizar_Empleado_Sucursal);
            dtp_Nacimiento_Actualizar_Empleado.Text = DateTime.Now.ToShortDateString();
            //Estableciendo valores al cmb tipo sangre
            cmb_Actualizar_Empleado_Tipo_Sangre.Items.Add("A");
            cmb_Actualizar_Empleado_Tipo_Sangre.Items.Add("O+");
            cmb_Actualizar_Empleado_Tipo_Sangre.Items.Add("AB+");
            cmb_Actualizar_Empleado_Tipo_Sangre.Items.Add("AB-");
            cmb_Actualizar_Empleado_Tipo_Sangre.Items.Add("a");
        }

        // Funcion para no mover la ventana del form
        private void ActualizarEmpleados_SourceInitialized(object sender, EventArgs e)
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

        private void btn_Actualizar_Empleado_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Actualizar_Empleado_Click(object sender, RoutedEventArgs e)
        {
            int codEmpleado = empleadosDAL.traerCodigoEmpleado(txt_Identidad_Actualizar_Empleado.Text);
            try
            {
                //Validación de datos
                Empleados.Empleados empleados1 = new();
                empleados1.CodigoEmpleado = codEmpleado;
                empleados1.NombreEmpleado = txt_Nombre_Actualizar_Empleado.Text;
                empleados1.ApellidoEmpleado = txt_Apellido_Actualizar_Empleado.Text;
                empleados1.IdentidadEmpleado = txt_Identidad_Actualizar_Empleado.Text;
                empleados1.TelefonoEmpleado = txt_Telefono_Actualizar_Empleado.Text;
                empleados1.FechaNacimientoEmpleado = Convert.ToDateTime(dtp_Nacimiento_Actualizar_Empleado.Text);
                empleados1.CorreoEmpleado = txt_Correo_Actualizar_Empleado.Text;
                empleados1.AlturaEmpleado = string.IsNullOrEmpty(txt_Altura_Actualizar_Empleado.Text) ? 0 : decimal.Parse(txt_Altura_Actualizar_Empleado.Text);
                empleados1.TipoSangreEmpleado = cmb_Actualizar_Empleado_Tipo_Sangre.SelectedItem.ToString();
                empleados1.SueldoBase = string.IsNullOrEmpty(txt_Sueldo_Actualizar_Empleado.Text) ? 0 : decimal.Parse(txt_Sueldo_Actualizar_Empleado.Text);
                empleados1.CodigoPuesto = cmb_Actualizar_Empleado_Cargo.SelectedIndex+1;
                empleados1.CodigoSucursal = cmb_Actualizar_Empleado_Sucursal.SelectedIndex + 1;
                empleados1.CodigoJornada = cmb_Actualizar_Empleado_Jornada.SelectedIndex+1;
                empleados1.FechaPago = Convert.ToDateTime(dtp_Pago_Actualizar_Empleado.Text);
                empleados1.FechaContratacion = Convert.ToDateTime(dtp_Ingreso_Actulizar_Empleado.Text);
                empleados1.DireccionEmpleado = string.IsNullOrWhiteSpace(rtbAString(rtb_Direccion_Actualizar_Empleado)) ? null : rtbAString(rtb_Direccion_Actualizar_Empleado);
                empleados1.EstadoEmpleado = (bool)chb_Estado_Empleado.IsChecked;
                empleadosDAL.ModificarEmpleado(empleados1);
                this.Close();
            }

            catch (FormatException error)
            {
                //Excepción que nos indicará si ocurre un error
                if (error.StackTrace.Contains("Nombre")) ValidarCampos(txt_Nombre_Actualizar_Empleado, leyenda: "Nombre");
                else if (error.StackTrace.Contains("Identidad")) ValidarCampos(txt_Identidad_Actualizar_Empleado, leyenda: "Identidad");
                else if (error.StackTrace.Contains("Telefono")) ValidarCampos(txt_Telefono_Actualizar_Empleado, leyenda: "Teléfono");
                else if (error.StackTrace.Contains("Correo")) ValidarCampos(txt_Correo_Actualizar_Empleado, leyenda: "Correo");
                else if (error.StackTrace.Contains("Altura")) ValidarCampos(txt_Altura_Actualizar_Empleado, leyenda: "Altura");
                else if (error.StackTrace.Contains("FechaNacimiento")) ValidarCampos(leyenda: "Fecha de nacimiento", dt: dtp_Nacimiento_Actualizar_Empleado, refer: 2);
                else if (error.StackTrace.Contains("TipoSangre")) ValidarCampos(leyenda: "Tipo de sangre", cmb: cmb_Actualizar_Empleado_Tipo_Sangre, refer: 3);
                else if (error.StackTrace.Contains("Direccion")) ValidarCampos(rtb: rtb_Direccion_Actualizar_Empleado, leyenda: "Dirección", refer: 4);
                else if (error.StackTrace.Contains("Sueldo")) ValidarCampos(txt_Sueldo_Actualizar_Empleado, leyenda: "Sueldo");
                else if (error.StackTrace.Contains("Cargo")) ValidarCampos(leyenda: "Cargo", cmb: cmb_Actualizar_Empleado_Cargo, refer: 3);
                else if (error.StackTrace.Contains("Jornada")) ValidarCampos(leyenda: "Jornada laboral", cmb: cmb_Actualizar_Empleado_Jornada, refer: 3);
                else if (error.StackTrace.Contains("FechaPago")) ValidarCampos(leyenda: "Fecha de pago", dt: dtp_Pago_Actualizar_Empleado, refer: 2);
                else if (error.StackTrace.Contains("FechaIngreso")) ValidarCampos(leyenda: "Fecha de ingreso", dt: dtp_Ingreso_Actulizar_Empleado, refer: 2);
            }
        }
        //Validar campos tipo txt, rtb, dt, cmb
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
        public Empleados.Empleados empleadoSeleccionado { get; set; }
        public Empleados.Empleados empleadoActual { get; set; }

        private void btn_Buscar_Actualizar_Empleado_Click(object sender, RoutedEventArgs e)
        {
            string buscar_Empleado = txt_Codigo_Actualizar_Empleado.Text;
            empleadoSeleccionado = empleadosDAL.BuscarEmpleadoPorId(buscar_Empleado);

            if (!string.IsNullOrEmpty(buscar_Empleado))
            {
                txt_Nombre_Actualizar_Empleado.Text = empleadoSeleccionado.NombreEmpleado;
                txt_Apellido_Actualizar_Empleado.Text = empleadoSeleccionado.ApellidoEmpleado;
                txt_Identidad_Actualizar_Empleado.Text = empleadoSeleccionado.IdentidadEmpleado;
                txt_Telefono_Actualizar_Empleado.Text = empleadoSeleccionado.TelefonoEmpleado;
                dtp_Nacimiento_Actualizar_Empleado.Text = Convert.ToString(empleadoSeleccionado.FechaNacimientoEmpleado);
                txt_Correo_Actualizar_Empleado.Text = empleadoSeleccionado.CorreoEmpleado;
                txt_Altura_Actualizar_Empleado.Text = Convert.ToString(empleadoSeleccionado.AlturaEmpleado);
                cmb_Actualizar_Empleado_Tipo_Sangre.SelectedItem = empleadoSeleccionado.TipoSangreEmpleado;
                setTextToRTB(rtb_Direccion_Actualizar_Empleado, empleadoSeleccionado.DireccionEmpleado);
                txt_Sueldo_Actualizar_Empleado.Text = Convert.ToString(empleadoSeleccionado.SueldoBase);
                cmb_Actualizar_Empleado_Cargo.SelectedIndex= empleadoSeleccionado.CodigoPuesto-1;
                cmb_Actualizar_Empleado_Sucursal.SelectedIndex = empleadoSeleccionado.CodigoSucursal - 1;
                cmb_Actualizar_Empleado_Jornada.SelectedIndex= empleadoSeleccionado.CodigoJornada-1;
                dtp_Pago_Actualizar_Empleado.Text = Convert.ToString(empleadoSeleccionado.FechaPago);
                dtp_Ingreso_Actulizar_Empleado.Text = Convert.ToString(empleadoSeleccionado.FechaContratacion);
                chb_Estado_Empleado.IsChecked = empleadoSeleccionado.EstadoEmpleado;
            }
        }
        private void setTextToRTB(RichTextBox rtb, string textoSet)
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            textRange.Text = textoSet;
        }

        private void txt_Codigo_Actualizar_Empleado_KeyUp(object sender, KeyEventArgs e)
        {
            stc_InfoPaciente.Visibility = Visibility.Visible;
            scv_BuscarPaciente.Visibility = Visibility.Visible;
            brd_BuscarPaciente.Visibility = Visibility.Visible;
            //scv_BuscarPaciente.Background = new 
            bool found = false;
            var border = (stc_InfoPaciente.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarEmpleado.GetData();

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
                txt_Codigo_Actualizar_Empleado.Text = (sender as TextBlock).Text.Split(" ")[0];
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
    }
}
