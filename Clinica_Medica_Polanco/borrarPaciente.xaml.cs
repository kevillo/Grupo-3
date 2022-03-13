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
        }

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
            MessageBox.Show("Paciente eliminado correctamente");
            this.Close();
        }

        public Pacient pacienteSeleccionado { get; set; }
        public Pacient pacienteActual { get; set; }

        private void btn_Buscar_Click(object sender, RoutedEventArgs e)
        {
            string buscar_Paciente = txt_Buscar_Paciente.Text;
            pacienteSeleccionado = PacientesDAL.BuscarPaciente(buscar_Paciente);
            if (!string.IsNullOrEmpty(buscar_Paciente))
            {
                // aqui pone el codigo  que llama a la funcion de eliminar paciente arnold
                pacienteActual = pacienteSeleccionado;
                txt_Nombre_Paciente.Text = pacienteSeleccionado.Nombre;
                txt_Apellido_Paciente.Text = pacienteSeleccionado.Apellido;
                txt_Identidad_Paciente.Text = pacienteSeleccionado.Identidad;
                txt_Telefono_Paciente.Text = pacienteSeleccionado.Telefono;
                txt_Fecha_Nacimiento_Paciente.Text = Convert.ToString(pacienteSeleccionado.FechaNacimiento);
                txt_Correo_Paciente.Text = pacienteSeleccionado.Correo;
                txt_Altura_Paciente.Text = Convert.ToString(pacienteSeleccionado.Altura);
                cmd_Tipo_Sangre.SelectedItem = pacienteSeleccionado.TipoSangre;
                prueba(Rtb_direccion_Paciente, pacienteSeleccionado.Direccion);
            }
            else MessageBox.Show("Ingrese un id de paciente válido");
        }

        private void prueba(RichTextBox rtb, string textoSet)
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            textRange.Text = textoSet;
        }

        private void txt_Buscar_Paciente_KeyUp(object sender, KeyEventArgs e)
        {
            stc_InfoPaciente.Visibility = Visibility.Visible;
            scv_BuscarPaciente.Visibility = Visibility.Visible;
            brd_BuscarPaciente.Visibility = Visibility.Visible;
            //scv_BuscarPaciente.Background = new 
            bool found = false;
            var border = (stc_InfoPaciente.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.Model.GetData();

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

    }
}
