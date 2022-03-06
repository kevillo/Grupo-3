using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Interop;
using Clinica_medica_polanco.Pacientes;

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
            MessageBox.Show("Información actualizada");
            this.Close();
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
