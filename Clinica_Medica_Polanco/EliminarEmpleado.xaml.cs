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
            int codEliminar = !string.IsNullOrEmpty(txt_ID_Eliminar_Empleado.Text) ? int.Parse(txt_ID_Eliminar_Empleado.Text) : 0;
            if (codEliminar != 0)
                empleadosDAL.EliminarEmpleado(codEliminar);
            else
            {
                MessageBox.Show("Ingrese un código de empleado para eliminar");
                txt_ID_Eliminar_Empleado.Focus();
            }

        }

        private Empleados.Empleados empleadoSeleccionado { get; set; }

        private void btn_Buscar_Eliminar_Empleado_Click(object sender, RoutedEventArgs e)
        {
            string buscar_Empleado = txt_ID_Eliminar_Empleado.Text;
            empleadoSeleccionado = empleadosDAL.BuscarEmpleadoPorId(buscar_Empleado);

            if (!string.IsNullOrEmpty(buscar_Empleado))
            {
                txt_Codigo_Eliminar_Empleado.Text = Convert.ToString(empleadoSeleccionado.CodigoEmpleado);
                txt_Nombre_Eliminar_Empleado.Text = (empleadoSeleccionado.NombreEmpleado + " " + empleadoSeleccionado.ApellidoEmpleado);
                txt_Identidad_Eliminar_Empleado.Text = empleadoSeleccionado.IdentidadEmpleado;
                txt_Telefono_Eliminar_Empleado.Text = empleadoSeleccionado.TelefonoEmpleado;
                dtp_Nacimiento_Eliminar_Empleado.Text = Convert.ToString(empleadoSeleccionado.FechaNacimientoEmpleado);
                txt_Correo_Eliminar_Empleado.Text = empleadoSeleccionado.CorreoEmpleado;
                txt_Altura_Eliminar_Empleado.Text = Convert.ToString(empleadoSeleccionado.AlturaEmpleado);
                cmb_Eliminar_Empleado_Tip_Sangre.SelectedItem = empleadoSeleccionado.TipoSangreEmpleado;
                prueba(rtx_Direccion_Eliminar_Empleado, empleadoSeleccionado.DireccionEmpleado);
                txt_Sueldo_Eliminar_Empleado.Text = Convert.ToString(empleadoSeleccionado.SueldoBase);
                cmb_Eliminar_Empleado_Cargo.SelectedIndex = empleadoSeleccionado.CodigoPuesto;
                cmb_Eliminar_Empleado_Jornada.SelectedIndex = empleadoSeleccionado.CodigoJornada;
                dtp_Pago_Eliminar_Empleado.Text = Convert.ToString(empleadoSeleccionado.FechaPago);
                dtp_Ingreso_Eliminar_Empleado.Text = Convert.ToString(empleadoSeleccionado.FechaContratacion);
            }
            else
            {
                MessageBox.Show("Ingrese un id de empleado válido");
                txt_Codigo_Eliminar_Empleado.Clear();
                txt_Codigo_Eliminar_Empleado.Focus();

                stc_InfoEmpleado.Visibility = Visibility.Hidden;
                scv_BuscarEmpleado.Visibility = Visibility.Hidden;
                brd_BuscarEmpleado.Visibility = Visibility.Hidden;
            }
        }

        private void prueba(RichTextBox rtb, string textoSet)
        {
            try
            {

                TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                textRange.Text = textoSet;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Error al recuperar la dirección del empleado ingresado");
                txt_ID_Eliminar_Empleado.Clear();
                txt_ID_Eliminar_Empleado.Focus();
                stc_InfoEmpleado.Visibility = Visibility.Hidden;
                scv_BuscarEmpleado.Visibility = Visibility.Hidden;
                brd_BuscarEmpleado.Visibility = Visibility.Hidden;

            }
        }

        private void txt_ID_Eliminar_Empleado_KeyUp(object sender, KeyEventArgs e)
        {
            stc_InfoEmpleado.Visibility = Visibility.Visible;
            scv_BuscarEmpleado.Visibility = Visibility.Visible;
            brd_BuscarEmpleado.Visibility = Visibility.Visible;
            bool found = false;
            var border = (stc_InfoEmpleado.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarEmpleado.GetData();

            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                // Clear   
                stc_InfoEmpleado.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list   
            stc_InfoEmpleado.Children.Clear();

            stc_InfoEmpleado.Children.Add(new TextBlock() { Text = "Identidad            Nombre      Apellido" });
            // Add the result   
            foreach (var obj in data)
            {
                if (obj.Split(" - ")[0].ToLower().StartsWith(query.ToLower()) || obj.Split(" - ")[1].ToLower().StartsWith(query.ToLower()))
                {
                    // The word starts with this... Autocomplete must work   
                    addItem(obj);
                    found = true;
                }
            }

            if (!found)
            {
                stc_InfoEmpleado.Children.Add(new TextBlock() { Text = "No existe ese No. de Identidad de empleado." });
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
                txt_ID_Eliminar_Empleado.Text = (sender as TextBlock).Text.Split(" - ")[0];
                stc_InfoEmpleado.Visibility = Visibility.Hidden;
                scv_BuscarEmpleado.Visibility = Visibility.Hidden;
                brd_BuscarEmpleado.Visibility = Visibility.Hidden;
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
            stc_InfoEmpleado.Children.Add(block);
        }

        //Validación para que solo se pueda ingresar numeros a un campo
        private void txt_Identidad_Eliminar_Empleado_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        //Validación para que solo se pueda ingresar numeros a un campo
        private void txt_Telefono_Eliminar_Empleado_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        //Validación para que solo se pueda ingresar letras a un campo
        private void txt_Nombre_Eliminar_Empleado_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        //validacion para que solo se pueda ingresar numeros a un campo
        private void txt_ID_Eliminar_Empleado_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }
    }
}
