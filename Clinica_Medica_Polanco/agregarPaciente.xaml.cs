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
using System.Windows.Shapes;
using System.Windows.Interop;
using Clinica_Medica_Polanco.Pacientes;
using System.Runtime.InteropServices;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    ///  a los Strings: solo que no vayan vacios
    ///  a los enteros: que no vaya negativo y que no vaya vacio
    ///  a los datetime: que no vaya vacio
    ///  a los strings como tipo identidad o telefono: que no vaya vacio y que sea un numero
    /// </summary>
    public partial class agregarPaciente : Window
    {
        public agregarPaciente()
        {
            InitializeComponent();

            this.SourceInitialized += AgregarPaciente_SourceInitialized;


            dtp_Fecha_Nacimiento_Paciente.Text = DateTime.Now.ToShortDateString();
            //Estableciendo valores al cmb tipo sangre
            cmb_Tipo_Sangre_Paciente.Items.Add("A+");
            cmb_Tipo_Sangre_Paciente.Items.Add("O");
            cmb_Tipo_Sangre_Paciente.Items.Add("AB+");
            cmb_Tipo_Sangre_Paciente.Items.Add("AB-");
        }

        private void AgregarPaciente_SourceInitialized(object sender, EventArgs e)
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


        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
        private void btn_Guardar_Datos_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                //Validación de datos
                int resultado = 0;
                Pacient paciente1 = new();
                paciente1.Nombre = txt_Nombre_Paciente.Text;
                paciente1.Apellido = txt_Apellido_Paciente.Text;
                paciente1.Identidad = txt_Identidad_Paciente.Text;
                paciente1.Telefono = txt_Telefono_Paciente.Text;
                paciente1.FechaNacimiento = Convert.ToDateTime(dtp_Fecha_Nacimiento_Paciente.Text);
                paciente1.Correo = txt_Correo_Paciente.Text;
                paciente1.Altura = string.IsNullOrEmpty(txt_Altura_Paciente.Text) ? 0 : int.Parse(txt_Altura_Paciente.Text); 
                paciente1.TipoSangre = cmb_Tipo_Sangre_Paciente.SelectedItem.ToString();
              
                paciente1.Direccion = string.IsNullOrWhiteSpace(rtbAString(Rtb_direccion_Paciente))?null: rtbAString(Rtb_direccion_Paciente);
                paciente1.Estado = true;

                resultado = PacientesDAL.AgregarPaciente(paciente1);
                if (resultado > 0)
                    MessageBox.Show("Datos Guardados Correctamente", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Error al Guardar los Datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();

            }

            catch (FormatException error)
            {
                //Excepción que nos indicará si ocurre un error
                if (error.StackTrace.Contains("Apellido")) ValidarCampos(txt_Apellido_Paciente, leyenda: "Apellido");
                else if (error.StackTrace.Contains("Nombre")) ValidarCampos(txt_Nombre_Paciente, leyenda: "Nombre");
                else if (error.StackTrace.Contains("Identidad")) ValidarCampos(txt_Identidad_Paciente, leyenda: "Identidad");
                else if (error.StackTrace.Contains("Telefono")) ValidarCampos(txt_Telefono_Paciente, leyenda: "Teléfono");
                else if (error.StackTrace.Contains("Correo")) ValidarCampos(txt_Correo_Paciente, leyenda: "Correo");
                else if (error.StackTrace.Contains("Altura")) ValidarCampos(txt_Altura_Paciente, leyenda: "Altura");
                else if (error.StackTrace.Contains("FechaNacimiento")) ValidarCampos(leyenda: "Fecha de nacimiento", dt: dtp_Fecha_Nacimiento_Paciente, refer: 2);
                else if (error.StackTrace.Contains("TipoSangre")) ValidarCampos(leyenda: "Tipo de sangre", cmb: cmb_Tipo_Sangre_Paciente, refer: 3);
                else if (error.StackTrace.Contains("Direccion")) ValidarCampos(rtb:Rtb_direccion_Paciente,  leyenda: "Dirección",refer:4);
            }
            
            
        }
        //Validar campos
        private void ValidarCampos([Optional] TextBox txts, [Optional] RichTextBox rtb, String leyenda,[Optional] DatePicker dt,[Optional] ComboBox cmb,[Optional] int refer)
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
    }
}
