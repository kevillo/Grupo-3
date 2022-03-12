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
            empleadosDAL.cargarJornada(cmb_Actualizar_Empleado_Jornada);
            empleadosDAL.cargarCargo(cmb_Actualizar_Empleado_Cargo);

            dtp_Nacimiento_Actualizar_Empleado.Text = DateTime.Now.ToShortDateString();
            //Estableciendo valores al cmb tipo sangre
            cmb_Actualizar_Empleado_Tipo_Sangre.Items.Add("A");
            cmb_Actualizar_Empleado_Tipo_Sangre.Items.Add("O+");
            cmb_Actualizar_Empleado_Tipo_Sangre.Items.Add("AB+");
            cmb_Actualizar_Empleado_Tipo_Sangre.Items.Add("AB-");
        }

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
            try
            {
                //Validación de datos
                int resultado = 0;
                Empleados.Empleados empleados1 = new();
                empleados1.NombreEmpleado = txt_Nombre_Actualizar_Empleado.Text;
                empleados1.IdentidadEmpleado = txt_Identidad_Actualizar_Empleado.Text;
                empleados1.TelefonoEmpleado = txt_Telefono_Actualizar_Empleado.Text;
                empleados1.FechaNacimientoEmpleado = Convert.ToDateTime(dtp_Nacimiento_Actualizar_Empleado.Text);
                empleados1.CorreoEmpleado = txt_Correo_Actualizar_Empleado.Text;
                empleados1.AlturaEmpleado = string.IsNullOrEmpty(txt_Altura_Actualizar_Empleado.Text) ? 0 : int.Parse(txt_Altura_Actualizar_Empleado.Text);
                empleados1.TipoSangreEmpleado = cmb_Actualizar_Empleado_Tipo_Sangre.SelectedItem.ToString();
                empleados1.SueldoBase = string.IsNullOrEmpty(txt_Sueldo_Actualizar_Empleado.Text) ? 0 : int.Parse(txt_Sueldo_Actualizar_Empleado.Text);
                empleados1.CargoEmpleado = cmb_Actualizar_Empleado_Cargo.SelectedItem.ToString();
                empleados1.JornadaEmpleado = cmb_Actualizar_Empleado_Jornada.SelectedItem.ToString();
                empleados1.FechaPago = Convert.ToDateTime(dtp_Pago_Actualizar_Empleado.Text);
                empleados1.FechaContratacion = Convert.ToDateTime(dtp_Ingreso_Actulizar_Empleado.Text);

                empleados1.DireccionEmpleado = string.IsNullOrWhiteSpace(StringFromRichTextBox(rtb_Direccion_Actualizar_Empleado)) ? null : StringFromRichTextBox(rtb_Direccion_Actualizar_Empleado);


                resultado = empleadosDAL.modificarEmpleado(empleados1);
                if (resultado > 0)
                    MessageBox.Show("Datos actualizados correctamente", "Datos Actualizados", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Error al actualizar los datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();

            }

            catch (FormatException error)
            {
                //Excepción que nos indicará si ocurre un error
                if (error.StackTrace.Contains("Nombre")) validateFields(txt_Nombre_Actualizar_Empleado, leyenda: "Nombre");
                else if (error.StackTrace.Contains("Identidad")) validateFields(txt_Identidad_Actualizar_Empleado, leyenda: "Identidad");
                else if (error.StackTrace.Contains("Telefono")) validateFields(txt_Telefono_Actualizar_Empleado, leyenda: "Teléfono");
                else if (error.StackTrace.Contains("Correo")) validateFields(txt_Correo_Actualizar_Empleado, leyenda: "Correo");
                else if (error.StackTrace.Contains("Altura")) validateFields(txt_Altura_Actualizar_Empleado, leyenda: "Altura");
                else if (error.StackTrace.Contains("FechaNacimiento")) validateFields(leyenda: "Fecha de nacimiento", dt: dtp_Nacimiento_Actualizar_Empleado, refer: 2);
                else if (error.StackTrace.Contains("TipoSangre")) validateFields(leyenda: "Tipo de sangre", cmb: cmb_Actualizar_Empleado_Tipo_Sangre, refer: 3);
                else if (error.StackTrace.Contains("Direccion")) validateFields(rtb: rtb_Direccion_Actualizar_Empleado, leyenda: "Dirección", refer: 4);
                else if (error.StackTrace.Contains("Sueldo")) validateFields(txt_Sueldo_Actualizar_Empleado, leyenda: "Sueldo");
                else if (error.StackTrace.Contains("Cargo")) validateFields(leyenda: "Cargo", cmb: cmb_Actualizar_Empleado_Cargo, refer: 3);
                else if (error.StackTrace.Contains("Jornada")) validateFields(leyenda: "Jornada laboral", cmb: cmb_Actualizar_Empleado_Jornada, refer: 3);
                else if (error.StackTrace.Contains("FechaPago")) validateFields(leyenda: "Fecha de pago", dt: dtp_Pago_Actualizar_Empleado, refer: 2);
                else if (error.StackTrace.Contains("FechaIngreso")) validateFields(leyenda: "Fecha de ingreso", dt: dtp_Ingreso_Actulizar_Empleado, refer: 2);

            }
        }
        //Validar campos tipo txt, rtb, dt, cmb
        private void validateFields([Optional] TextBox txts, [Optional] RichTextBox rtb, String leyenda, [Optional] DatePicker dt, [Optional] ComboBox cmb, [Optional] int refer)
        {
            MessageBox.Show("No se pueden dejar espacios en blanco o ingresar caracteres inválidos en " + leyenda);

            if (refer == 2) dt.Focus();
            else if (refer == 3) cmb.Focus();
            else if (refer == 4) rtb.Focus();
            else txts.Focus();

        }
        private string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                rtb.Document.ContentStart,
                rtb.Document.ContentEnd
            );

            return textRange.Text;
        }

        private void btn_Buscar_Actualizar_Empleado_Click(object sender, RoutedEventArgs e)
        {
            string actualizarEmpleado = txt_Codigo_Actualizar_Empleado.Text;
            if (!string.IsNullOrEmpty(actualizarEmpleado))
            {
                // aqui se traen los examenes por codigo de empleado
            }
            else MessageBox.Show("No puede dejar el id del empleado vacío ");
        }
    }
}
