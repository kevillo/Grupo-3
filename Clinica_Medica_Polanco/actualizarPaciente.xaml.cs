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
using System.Runtime.InteropServices;

namespace Clinica_medica_polanco
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
            cmb_Actualizar_Paciente_TipoSangre.Items.Add("A");
            cmb_Actualizar_Paciente_TipoSangre.Items.Add("O+");
        }
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
                int resultado = 0;
                Pacientes.Paciente paciente1 = new();
                paciente1.Nombre = txt_Actualizar_Paciente_Nombre_Completo.Text;
                paciente1.Identidad = txt_Actualizar_Paciente_ID.Text;
                paciente1.Telefono = txt_Actualizar_Paciente_Telefono.Text;
                paciente1.FechaNacimiento = Convert.ToDateTime(dtp_Actualizar_Paciente_FechaNac.Text);
                paciente1.Correo = txt_Actualizar_Paciente_CorreoE.Text;
                paciente1.Altura = string.IsNullOrEmpty(txt_Actualizar_Paciente_Altura.Text) ? 0 : int.Parse(txt_Actualizar_Paciente_Altura.Text);
                paciente1.TipoSangre = Convert.ToString(cmb_Actualizar_Paciente_TipoSangre.Text);
                paciente1.Direccion = string.IsNullOrWhiteSpace(StringFromRichTextBox(rtb_Actualizar_Paciente_Direccion)) ? null : StringFromRichTextBox(rtb_Actualizar_Paciente_Direccion);
                paciente1.Estado = true;

                resultado = PacientesDAL.ModificarPaciente(paciente1);
                if (resultado > 0)
                    MessageBox.Show("Datos actualizados correctamente", "Datos Actualizados", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Error al actualizar los datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();

            }

            catch (FormatException error)
            { 
                if (error.StackTrace.Contains("Nombre")) validateFields(txt_Actualizar_Paciente_Nombre_Completo, leyenda: "Nombre");
                else if (error.StackTrace.Contains("Identidad")) validateFields(txt_Actualizar_Paciente_ID, leyenda: "Identidad");
                else if (error.StackTrace.Contains("Telefono")) validateFields(txt_Actualizar_Paciente_Telefono, leyenda: "Teléfono");
                else if (error.StackTrace.Contains("Correo")) validateFields(txt_Actualizar_Paciente_CorreoE, leyenda: "Correo");
                else if (error.StackTrace.Contains("Altura")) validateFields(txt_Actualizar_Paciente_Altura, leyenda: "Altura");
                else if (error.StackTrace.Contains("FechaNacimiento")) validateFields(leyenda: "Fecha de nacimiento", dt: dtp_Actualizar_Paciente_FechaNac, refer: 2);
                else if (error.StackTrace.Contains("TipoSangre")) validateFields(leyenda: "Tipo de sangre", cmb: cmb_Actualizar_Paciente_TipoSangre, refer: 3);
                else if (error.StackTrace.Contains("Direccion")) validateFields(rtb:rtb_Actualizar_Paciente_Direccion, leyenda: "Dirección", refer: 4);
            }
        }
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

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            bool found = false;
            var border = (stc_InfoPaciente.Parent as ScrollViewer).Parent as Border;
            var data = Model.GetData();

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
                stc_InfoPaciente.Children.Add(new TextBlock() { Text = "No existe ese nombre de paciente." });
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
                txt_Actualizar_Paciente_ID.Text = (sender as TextBlock).Text;
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
