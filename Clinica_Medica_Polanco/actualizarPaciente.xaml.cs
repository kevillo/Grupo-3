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

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para actualizarD_Pacientes.xaml
    /// </summary>
    public partial class actualizarPaciente : Window
    {
        public actualizarPaciente()
        {
            InitializeComponent();
            this.SourceInitialized += ActualizarPaciente_SourceInitialized;

            dtp_Actualizar_Paciente_FechaNac.Text = DateTime.Now.ToShortDateString();
            cmb_Actualizar_Paciente_TipoSangre.Items.Add("O-");
            cmb_Actualizar_Paciente_TipoSangre.Items.Add("O+");
            cmb_Actualizar_Paciente_TipoSangre.Items.Add("A+");
            cmb_Actualizar_Paciente_TipoSangre.Items.Add("A-");
            cmb_Actualizar_Paciente_TipoSangre.Items.Add("AB+");
            cmb_Actualizar_Paciente_TipoSangre.Items.Add("AB-");
            cmb_Actualizar_Paciente_TipoSangre.Items.Add("B-");
            cmb_Actualizar_Paciente_TipoSangre.Items.Add("B+");
        }

        // Funcion para no mover la ventana del form
        private void ActualizarPaciente_SourceInitialized(object sender, EventArgs e)
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

        private void btn_Actualizar_Paciente_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Actualizar_Paciente_ActualizarInformacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_PacienteId.Text))
                {
                    //Validar datos
                    string direccionP = rtbAString(rtb_Actualizar_Paciente_Direccion);
                    Pacient paciente1 = new();
                    paciente1.Codigo = PacientesDAL.ObtenerIdPaciente(txt_PacienteId.Text);
                    paciente1.Nombre = (txt_Actualizar_Paciente_Nombre.Text).StartsWith(" ") ? null : (txt_Actualizar_Paciente_Nombre.Text).EndsWith(" ") ? null : Regex.Replace(txt_Actualizar_Paciente_Nombre.Text, "\\s+", " ");
                    paciente1.Apellido = (txt_Actualizar_Paciente_Apellido.Text).StartsWith(" ") ? null : (txt_Actualizar_Paciente_Apellido.Text).EndsWith(" ") ? null : Regex.Replace(txt_Actualizar_Paciente_Apellido.Text, "\\s+", " ");
                    paciente1.Identidad = txt_PacienteId.Text;
                    paciente1.Telefono = txt_Actualizar_Paciente_Telefono.Text;
                    paciente1.FechaNacimiento = string.IsNullOrEmpty(dtp_Actualizar_Paciente_FechaNac.Text) ? DateTime.Now : Convert.ToDateTime(dtp_Actualizar_Paciente_FechaNac.Text);
                    paciente1.Correo = (txt_Actualizar_Paciente_CorreoE.Text).StartsWith(" ") ? " " : (txt_Actualizar_Paciente_CorreoE.Text).EndsWith(" ") ? " " : txt_Actualizar_Paciente_CorreoE.Text;
                    paciente1.Altura = (txt_Actualizar_Paciente_Altura.Text).StartsWith(" ") ? 0 : (txt_Actualizar_Paciente_Altura.Text).EndsWith(" ") ? 0 : string.IsNullOrEmpty(txt_Actualizar_Paciente_Altura.Text) ? 0 : decimal.Parse(Regex.Replace(txt_Actualizar_Paciente_Altura.Text, "\\s", ""));
                    paciente1.TipoSangre = Convert.ToString(cmb_Actualizar_Paciente_TipoSangre.Text);
                    paciente1.Direccion = (direccionP).StartsWith(" ") ? null : (direccionP).EndsWith(" ") ? null : Regex.Replace(direccionP, "\\s+", " ");
                    paciente1.Estado = (bool)chk_Actualizar_Paciente_EstadoPaciente.IsChecked;

                    //Validación de un correo duplicado en la base de datos
                    int validarCorreo = PacientesDAL.ValidarCorreoPaciente(paciente1.Correo);

                    //Si el correo está duplicado, manda error
                    if (validarCorreo < 1)
                    {
                        PacientesDAL.ModificarPaciente(paciente1);
                        this.Close();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Correo repetido: Por favor, ingrese un correo diferente.");
                        txt_Actualizar_Paciente_CorreoE.Clear();
                        txt_Actualizar_Paciente_CorreoE.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Procure no dejar la Identidad del paciente con un formato incorrecto o vacío.");
                    txt_PacienteId.Clear();
                    txt_PacienteId.Focus();
                    stc_Paciente.Visibility = Visibility.Hidden;
                    scv_Paciente.Visibility = Visibility.Hidden;
                    brd_Paciente.Visibility = Visibility.Hidden;
                }
            }
            catch (FormatException error)
            { 
                //Excepción que nos indicará si hay algún error
                if (error.StackTrace.Contains("Nombre")) ValidarCampos(txt_Actualizar_Paciente_Nombre, leyenda: "Nombre");
                else if (error.StackTrace.Contains("Apellido")) ValidarCampos(txt_Actualizar_Paciente_Apellido, leyenda: "Apellido");
                else if (error.StackTrace.Contains("Codigo")) ValidarCampos(txt_PacienteId, leyenda: "Codigo");
                else if (error.StackTrace.Contains("Identidad")) ValidarCampos(txt_PacienteId, leyenda: "Identidad");
                else if (error.StackTrace.Contains("Telefono")) ValidarCampos(txt_Actualizar_Paciente_Telefono, leyenda: "Teléfono");
                else if (error.StackTrace.Contains("Correo")) ValidarCampos(txt_Actualizar_Paciente_CorreoE, leyenda: "Correo");
                else if (error.StackTrace.Contains("Altura")) ValidarCampos(txt_Actualizar_Paciente_Altura, leyenda: "Altura");
                else if (error.StackTrace.Contains("FechaNacimiento")) ValidarCampos(leyenda: "Fecha de nacimiento", dt: dtp_Actualizar_Paciente_FechaNac, refer: 2);
                else if (error.StackTrace.Contains("TipoSangre")) ValidarCampos(leyenda: "Tipo de sangre", cmb: cmb_Actualizar_Paciente_TipoSangre, refer: 3);
                else if (error.StackTrace.Contains("Direccion")) ValidarCampos(rtb:rtb_Actualizar_Paciente_Direccion, leyenda: "Dirección", refer: 4);
            }
        }
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

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            stc_Paciente.Visibility = Visibility.Visible;
            scv_Paciente.Visibility = Visibility.Visible;
            brd_Paciente.Visibility = Visibility.Visible;
            //scv_BuscarPaciente.Background = new 
            bool found = false;
            var border = (stc_Paciente.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarPacinte.GetData();
            
            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                // Clear   
                stc_Paciente.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list   
            stc_Paciente.Children.Clear();

            stc_Paciente.Children.Add(new TextBlock() { Text = " Identidad                 Nombre      Apellido" });
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
                stc_Paciente.Children.Add(new TextBlock() { Text = "No existe ese No. de Identidad de paciente." });
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
                txt_PacienteId.Text = (sender as TextBlock).Text.Split(" - ")[0];
                stc_Paciente.Visibility = Visibility.Hidden;
                scv_Paciente.Visibility = Visibility.Hidden;
                brd_Paciente.Visibility = Visibility.Hidden;
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
            stc_Paciente.Children.Add(block);
        }

        public Pacient pacienteSeleccionado { get; set; }
        public Pacient pacienteActual { get; set; }

        private void btn_Actualizar_Paciente_Buscar_Click(object sender, RoutedEventArgs e)
        {
            string buscar_Paciente = txt_PacienteId.Text;
            pacienteSeleccionado = PacientesDAL.BuscarPaciente(buscar_Paciente);

            if (!string.IsNullOrEmpty(buscar_Paciente) && Int64.TryParse(buscar_Paciente,out long _))
            {
                // aqui pone el codigo  que llama a la funcion de buscar
                pacienteActual = pacienteSeleccionado;
                txt_Actualizar_Paciente_Codigo.Text = Convert.ToString(pacienteSeleccionado.Codigo);
                txt_Actualizar_Paciente_Nombre.Text = pacienteSeleccionado.Nombre;
                txt_Actualizar_Paciente_Apellido.Text = pacienteSeleccionado.Apellido;
                txt_Actualizar_Paciente_Telefono.Text = pacienteSeleccionado.Telefono;
                dtp_Actualizar_Paciente_FechaNac.Text = Convert.ToString(pacienteSeleccionado.FechaNacimiento);
                txt_Actualizar_Paciente_CorreoE.Text = pacienteSeleccionado.Correo;
                txt_Actualizar_Paciente_Altura.Text = Convert.ToString(pacienteSeleccionado.Altura);
                cmb_Actualizar_Paciente_TipoSangre.SelectedItem = pacienteSeleccionado.TipoSangre;
                prueba(rtb_Actualizar_Paciente_Direccion,pacienteSeleccionado.Direccion);
                chk_Actualizar_Paciente_EstadoPaciente.IsChecked = pacienteSeleccionado.Estado;
            }
            else
            {
                MessageBox.Show("Procure no dejar la Identidad el paciente con un formato incorrecto o vacío.");
                stc_Paciente.Visibility = Visibility.Hidden;
                scv_Paciente.Visibility = Visibility.Hidden;
                brd_Paciente.Visibility = Visibility.Hidden;
                txt_PacienteId.Clear();
                txt_PacienteId.Focus();

            }
                
        }
        private void prueba(RichTextBox rtb,string textoSet)
        {
            try
            {
                TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                textRange.Text = textoSet;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Error al recuperar la dirección del paciente ingresado");
                txt_PacienteId.Clear();
                txt_PacienteId.Focus();
                stc_Paciente.Visibility = Visibility.Hidden;
                scv_Paciente.Visibility = Visibility.Hidden;
                brd_Paciente.Visibility = Visibility.Hidden;

            }
        }

        //validacion para que solo se pueda ingresar letras a un campo
        private void txt_Actualizar_Paciente_Nombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        //validacion para que solo se pueda ingresar letras a un campo
        private void txt_Actualizar_Paciente_Apellido_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        private void txt_Actualizar_Paciente_Altura_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void txt_Actualizar_Paciente_Telefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void txt_Actualizar_Paciente_CorreoE_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if ((ascci >= 65 && ascci <= 90) || (ascci >= 97 && ascci <= 122) || (ascci >= 48 && ascci <= 57) || ascci == 64 || ascci == 95 || ascci == 46 || ascci == 45)

                e.Handled = false;

            else e.Handled = true;
        }
    }
}
