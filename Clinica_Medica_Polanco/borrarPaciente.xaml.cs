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
    /// Lógica de interacción para borrarPaciente.xaml
    /// </summary>
    public partial class borrarPaciente : Window
    {
        public borrarPaciente()
        {
            InitializeComponent();
            this.SourceInitialized += EliminarPaciente_SourceInitialized;
            cmd_Tipo_Sangre.Items.Add("O-");
            cmd_Tipo_Sangre.Items.Add("O+");
            cmd_Tipo_Sangre.Items.Add("A+");
            cmd_Tipo_Sangre.Items.Add("A-");
            cmd_Tipo_Sangre.Items.Add("AB+");
            cmd_Tipo_Sangre.Items.Add("AB-");
            cmd_Tipo_Sangre.Items.Add("B-");
            cmd_Tipo_Sangre.Items.Add("B+");
        }

        /// Funcion para evitar el movimiento del formulario
        private void EliminarPaciente_SourceInitialized(object sender, EventArgs e)
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

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btn_Eliminar_Paciente_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txt_Identidad_Paciente.Text))
            {

                int codPaciente = PacientesDAL.ObtenerIdPaciente(txt_Identidad_Paciente.Text);
                PacientesDAL.EliminarPaciente(codPaciente);
                this.Close();
            }
            else
            {
                MessageBox.Show("Procure no dejar la Identidad del paciente con un formato incorrecto o vacío.");
                txt_Buscar_Paciente.Clear();
                txt_Buscar_Paciente.Focus();
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
        public Pacient pacienteSeleccionado { get; set; }
        
        private void btn_Buscar_Click(object sender, RoutedEventArgs e)
        {
            string buscar_Paciente = txt_Buscar_Paciente.Text;
            pacienteSeleccionado = PacientesDAL.BuscarPaciente(buscar_Paciente);
            if (!string.IsNullOrEmpty(buscar_Paciente))
            {
                txt_Nombre_Paciente.Text = pacienteSeleccionado.Nombre;
                txt_Apellido_Paciente.Text = pacienteSeleccionado.Apellido;
                txt_Identidad_Paciente.Text = pacienteSeleccionado.Identidad;
                txt_Telefono_Paciente.Text = pacienteSeleccionado.Telefono;
                dtp_Fecha_Nacimiento_Borrar_Empleado.Text = Convert.ToString(pacienteSeleccionado.FechaNacimiento);
                txt_Correo_Paciente.Text = pacienteSeleccionado.Correo;
                txt_Altura_Paciente.Text = Convert.ToString(pacienteSeleccionado.Altura);
                cmd_Tipo_Sangre.SelectedItem = pacienteSeleccionado.TipoSangre;
                prueba(Rtb_direccion_Paciente, pacienteSeleccionado.Direccion);
            }
            else MessageBox.Show("Procure no dejar la Identidad del paciente con un formato incorrecto o vacío.");
        }

        private void prueba(RichTextBox rtb, string textoSet="error")
        {
            try
            {
                
                TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                textRange.Text = textoSet;
            }
            catch(ArgumentNullException)
            {
                MessageBox.Show("No se pudo recuperar la dirección del paciente debido a un error.");
                txt_Buscar_Paciente.Clear();
                txt_Buscar_Paciente.Focus();
                stc_InfoPaciente.Visibility = Visibility.Hidden;
                scv_BuscarPaciente.Visibility = Visibility.Hidden;
                brd_BuscarPaciente.Visibility = Visibility.Hidden;

            }
        }

        private void txt_Buscar_Paciente_KeyUp(object sender, KeyEventArgs e)
        {
            stc_InfoPaciente.Visibility = Visibility.Visible;
            scv_BuscarPaciente.Visibility = Visibility.Visible;
            brd_BuscarPaciente.Visibility = Visibility.Visible;
        
            bool found = false;
            var border = (stc_InfoPaciente.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarPacinte.GetData();

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

            stc_InfoPaciente.Children.Add(new TextBlock() { Text = " Identidad                 Nombre      Apellido" });
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
                txt_Buscar_Paciente.Text = (sender as TextBlock).Text.Split(" ")[0];
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

        //validacion para que solo se pueda ingresar numeros a un campo
        private void txt_Buscar_Paciente_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
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
        private void txt_Telefono_Paciente_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        //validacion para que solo se pueda ingresar numeros a un campo
        private void txt_Identidad_Paciente_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }
    }
}
