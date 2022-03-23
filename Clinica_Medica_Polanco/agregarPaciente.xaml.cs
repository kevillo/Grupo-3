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
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
            cmb_Tipo_Sangre_Paciente.Items.Add("O-");
            cmb_Tipo_Sangre_Paciente.Items.Add("O+");
            cmb_Tipo_Sangre_Paciente.Items.Add("A+");
            cmb_Tipo_Sangre_Paciente.Items.Add("A-");
            cmb_Tipo_Sangre_Paciente.Items.Add("AB+");
            cmb_Tipo_Sangre_Paciente.Items.Add("AB-");
            cmb_Tipo_Sangre_Paciente.Items.Add("B-");
            cmb_Tipo_Sangre_Paciente.Items.Add("B+");
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
                Pacientes.Pacient paciente1 = new();
                paciente1.Nombre = txt_Nombre_Paciente.Text;
                paciente1.Apellido = txt_Apellido_Paciente.Text;
                paciente1.Identidad = txt_Identidad_Paciente.Text;
                paciente1.Telefono = txt_Telefono_Paciente.Text;
                paciente1.FechaNacimiento = Convert.ToDateTime(dtp_Fecha_Nacimiento_Paciente.Text);
                paciente1.Correo = txt_Correo_Paciente.Text;
                // si esta vacio, devuelve 0, si no esta vacio, valida que sea un decimal convirtiendolo, si falla la conversion, devuelve un 0, sino lo que tenga el txt
                paciente1.Altura = string.IsNullOrEmpty(txt_Altura_Paciente.Text) ? 0 : decimal.TryParse(txt_Altura_Paciente.Text, out decimal _) ? decimal.Parse(txt_Altura_Paciente.Text): 0;
                paciente1.TipoSangre = cmb_Tipo_Sangre_Paciente.SelectedItem.ToString();
                paciente1.Direccion = string.IsNullOrWhiteSpace(rtbAString(Rtb_direccion_Paciente)) ? null : rtbAString(Rtb_direccion_Paciente);
                
                //validacion de un correo o identidad duplicada en la base de datos
                int validarIdentidad = PacientesDAL.ValidarIdentidadPaciente(paciente1.Identidad);
                int validarCorreo = PacientesDAL.ValidarCorreoPaciente(paciente1.Correo);
                

                // si el correo esta duplicado, manda error
                if (validarCorreo < 1)
                {
                    // si la identidad esta duplicada, manda error
                    if (validarIdentidad < 1)
                    {
                        PacientesDAL.AgregarPaciente(paciente1);
                        this.Close();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Identidad repetida: por favor ingrese una identidad diferente");
                        txt_Identidad_Paciente.Clear();
                        txt_Identidad_Paciente.Focus();
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Correo repetido: Por favor inrgese otro correo");
                    txt_Correo_Paciente.Clear();
                    txt_Correo_Paciente.Focus();
                }

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
        private void ValidarCampos([Optional] System.Windows.Controls.TextBox txts, [Optional] System.Windows.Controls.RichTextBox rtb, String leyenda,[Optional] DatePicker dt,[Optional] System.Windows.Controls.ComboBox cmb,[Optional] int refer)
        {
            System.Windows.MessageBox.Show("No se pueden dejar espacios en blanco o ingresar caracteres inválidos en " + leyenda);

            if (refer == 2) dt.Focus();
            else if (refer == 3) cmb.Focus();
            else if (refer == 4) rtb.Focus();
            else txts.Focus();

        }

        private string rtbAString(System.Windows.Controls.RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                rtb.Document.ContentStart,
                rtb.Document.ContentEnd
            );

            return textRange.Text;
        }

        //validacion para que solo se pueda ingresar letras a un campo
        private void txt_Nombre_Paciente_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        //validacion para que solo se pueda ingresar numeros a un campo
        private void txt_Identidad_Paciente_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;            
        }

        //validacion para que solo se pueda ingresar letras a un campo
        private void txt_Apellido_Paciente_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }
    }
}
