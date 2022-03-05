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
using Clinica_medica_polanco.Pacientes;

namespace Clinica_medica_polanco
{
    /// <summary>
    /// Lógica de interacción para agregarPaciente.xaml
    /// </summary>
    public partial class agregarPaciente : Window
    {
        public agregarPaciente()
        {
            InitializeComponent();

            this.SourceInitialized += AgregarPaciente_SourceInitialized;
            cmb_Tipo_Sangre_Paciente.Items.Add("A");
            cmb_Tipo_Sangre_Paciente.Items.Add("O+");
            cmb_Tipo_Sangre_Paciente.Items.Add("");
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


            Pacientes.Paciente paciente1 = new();
            try
            {
                int resultado = 0;
                paciente1.Nombre = txt_Nombre_Paciente.Text;
                paciente1.Apellido = txt_Apellido_Paciente.Text;
                paciente1.Identidad = txt_Identidad_Paciente.Text;
                paciente1.Telefono = txt_Telefono_Paciente.Text;
                paciente1.FechaNacimiento = Convert.ToDateTime(dtp_Fecha_Nacimiento_Paciente.DisplayDate);
                paciente1.Correo = txt_Correo_Paciente.Text;
                paciente1.Altura = string.IsNullOrEmpty(txt_Altura_Paciente.Text) ? 0 : int.Parse(txt_Altura_Paciente.Text);
                paciente1.TipoSangre = Convert.ToString(cmb_Tipo_Sangre_Paciente.Text);
                paciente1.Direccion = Rtb_direccion_Paciente.Selection.Text;
                paciente1.Estado = true;
                resultado = PacientesDAL.AgregarPaciente(paciente1);
                if (resultado > 0)
                    MessageBox.Show("Datos Guardados Correctamente", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Error al Guardar los Datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }

            catch(FormatException error)
            {
                if (error.StackTrace.Contains("Apellido")) validateTxtFields(txt_Apellido_Paciente,"Apellido");
                else if (error.StackTrace.Contains("Nombre")) validateTxtFields(txt_Nombre_Paciente,"Nombre");
                else if (error.StackTrace.Contains("Identidad")) validateTxtFields(txt_Identidad_Paciente, "Identidad");
                else if (error.StackTrace.Contains("Teléfono")) validateTxtFields(txt_Telefono_Paciente, "Teléfono");
                else if (error.StackTrace.Contains("Correo")) validateTxtFields(txt_Correo_Paciente, "Correo");
            }
        }

        private void validateTxtFields(TextBox txts,String leyenda)
        {
            MessageBox.Show("No se puede dejar espacios en blanco en el " + leyenda);
            txts.Focus();

        }
    }
}
