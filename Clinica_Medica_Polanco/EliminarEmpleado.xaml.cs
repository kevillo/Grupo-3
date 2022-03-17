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
using Clinica_Medica_Polanco.Empleados;
using Clinica_Medica_Polanco.Pacientes;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para EliminarEmpleado.xaml
    /// </summary>
    public partial class EliminarEmpleado : Window
    {
        public EliminarEmpleado()
        {
            InitializeComponent();
            this.SourceInitialized += EliminarEmpleado_SourceInitialized;

            //Llamado a las funciones para cargar datos desde la bd a los cmb
            empleadosDAL.CargarCargo(cmb_Eliminar_Empleado_Cargo);
            empleadosDAL.CargarJornada(cmb_Eliminar_Empleado_Jornada);
            cmb_Eliminar_Empleado_Tip_Sangre.Items.Add("O-");
            cmb_Eliminar_Empleado_Tip_Sangre.Items.Add("O+");
            cmb_Eliminar_Empleado_Tip_Sangre.Items.Add("A+");
            cmb_Eliminar_Empleado_Tip_Sangre.Items.Add("A-");
            cmb_Eliminar_Empleado_Tip_Sangre.Items.Add("AB+");
            cmb_Eliminar_Empleado_Tip_Sangre.Items.Add("AB-");
            cmb_Eliminar_Empleado_Tip_Sangre.Items.Add("B-");
            cmb_Eliminar_Empleado_Tip_Sangre.Items.Add("B+");
        }
        private void EliminarEmpleado_SourceInitialized(object sender, EventArgs e)
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

        private void btn_Borrar_Empleado_Click(object sender, RoutedEventArgs e)
        {
            empleadosDAL.EliminarEmpleado(int.Parse(txt_Codigo_Eliminar_Empleado.Text));
            this.Close();
        }

        private Empleados.Empleados empleadoSeleccionado { get; set; }
        
        private void btn_Buscar_Eliminar_Empleado_Click(object sender, RoutedEventArgs e)
        {
            string buscar_Empleado = txt_ID_Eliminar_Empleado.Text;
            empleadoSeleccionado = empleadosDAL.BuscarEmpleadoPorId(buscar_Empleado);

            if (!string.IsNullOrEmpty(buscar_Empleado))
            {
                txt_Codigo_Eliminar_Empleado.Text = Convert.ToString(empleadoSeleccionado.CodigoEmpleado);
                txt_Nombre_Eliminar_Empleado.Text = (empleadoSeleccionado.NombreEmpleado + " "+ empleadoSeleccionado.ApellidoEmpleado);
                txt_Identidad_Eliminar_Empleado.Text = empleadoSeleccionado.IdentidadEmpleado;
                txt_Telefono_Eliminar_Empleado.Text = empleadoSeleccionado.TelefonoEmpleado;
                dtp_Nacimiento_Eliminar_Empleado.Text = Convert.ToString(empleadoSeleccionado.FechaNacimientoEmpleado);
                txt_Correo_Eliminar_Empleado.Text = empleadoSeleccionado.CorreoEmpleado;
                txt_Altura_Eliminar_Empleado.Text = Convert.ToString(empleadoSeleccionado.AlturaEmpleado);
                cmb_Eliminar_Empleado_Tip_Sangre.SelectedItem = empleadoSeleccionado.TipoSangreEmpleado;
                prueba(rtx_Direccion_Eliminar_Empleado, empleadoSeleccionado.DireccionEmpleado);
                txt_Sueldo_Eliminar_Empleado.Text = Convert.ToString(empleadoSeleccionado.SueldoBase);
                cmb_Eliminar_Empleado_Cargo.SelectedIndex= empleadoSeleccionado.CodigoPuesto;
                cmb_Eliminar_Empleado_Jornada.SelectedIndex= empleadoSeleccionado.CodigoJornada;
                dtp_Pago_Eliminar_Empleado.Text = Convert.ToString(empleadoSeleccionado.FechaPago);
                dtp_Ingreso_Eliminar_Empleado.Text = Convert.ToString(empleadoSeleccionado.FechaContratacion);
            }
            else MessageBox.Show("Ingrese un id de empleado válido");
        }

        private void prueba(RichTextBox rtb, string textoSet)
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            textRange.Text = textoSet;
        }

        private void txt_ID_Eliminar_Empleado_KeyUp(object sender, KeyEventArgs e)
        {
            stc_InfoPaciente.Visibility = Visibility.Visible;
            scv_BuscarPaciente.Visibility = Visibility.Visible;
            brd_BuscarPaciente.Visibility = Visibility.Visible;
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

            stc_InfoPaciente.Children.Add(new TextBlock() { Text = "Identidad            Nombre      Apellido" });
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
                txt_ID_Eliminar_Empleado.Text = (sender as TextBlock).Text.Split(" ")[0];
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
