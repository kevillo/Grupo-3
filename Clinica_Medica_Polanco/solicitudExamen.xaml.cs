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
using Clinica_Medica_Polanco.ExamenesMedicos;
using System.Runtime.InteropServices;
using System.Data;
namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para solicitudExamen.xaml
    /// </summary>
    /// 
    
    public partial class solicitudExamen : Window
    {
        private int codEmpleado;
        private DataTable tabla;
        private List<Ventas.Ventas> nuevaVenta = new List<Ventas.Ventas>();
        public solicitudExamen(int id)
        {
            codEmpleado = id;
            InitializeComponent();
            tabla = new DataTable();
            this.SourceInitialized += SolicitudExamen_SourceInitialized;
            ExamenesDAL.CargarMicrobiologo(cmb_Solicitud_Examen_Microbiologo);
            ExamenesDAL.CargarEnfermeros(cmb_Solicitud_Examen_Enfermero);
            ExamenesDAL.CargarEntregaExamen(cmb_Forma_Entrega);
            ExamenesDAL.CargarFormaPago(cmb_Forma_Pago);

            tabla.Columns.Add("examen medico");
            tabla.Columns.Add("facturador");
            tabla.Columns.Add("microbiologo");
            tabla.Columns.Add("enfermero");
            tabla.Columns.Add("paciente");
            tabla.Columns.Add("forma entrega examen");
            tabla.Columns.Add("forma pago examen");
            tabla.Columns.Add("cantidad");
            tabla.Columns.Add("estado examen");
            tabla.Columns.Add("combo");
            tabla.Columns.Add("Fecha factura");
            dtg_Solicitud_Examen_Examenes.ItemsSource = tabla.AsDataView();
        }
        private void SolicitudExamen_SourceInitialized(object sender, EventArgs e)
        {
            WindowInteropHelper helper = new(this);
            HwndSource souce = HwndSource.FromHwnd(helper.Handle);
            souce.AddHook(WndProc);
        }

        // Funcion para no mover la ventana del form
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


        private void btn_Solicitud_Examen_Procesar_Orden_Click(object sender, RoutedEventArgs e)
        {
            Ventas.ventasDAL.GenerarFactura();

            int codigoFacturaVenta = Ventas.ventasDAL.ObtenerIdVenta();

            try
            {

                foreach(Ventas.Ventas v in nuevaVenta)
                {
                    MessageBox.Show(codigoFacturaVenta.ToString(),v.Cantidad.ToString());
                    Ventas.ventasDAL.RegistrarVenta(v, codigoFacturaVenta);
                }
                pagarExamenMedico nuevopago = new pagarExamenMedico(nuevaVenta);
                this.Close();
                nuevopago.ShowDialog();
            }

            catch(FormatException error)
            {
                if (error.StackTrace.Contains("CodigoPaciente")) validarCampos("paciente", txt_Solicitud_Examen_ID_Cliente, refer: 1);
                else if (error.StackTrace.Contains("CodigoMicrobiologo")) validarCampos("Microbiologo", cmb: cmb_Solicitud_Examen_Microbiologo, refer: 2);
                else if (error.StackTrace.Contains("CodigoEnfermero")) validarCampos("Enfermero", cmb: cmb_Solicitud_Examen_Enfermero, refer: 2);
                else if (error.StackTrace.Contains("MetodoEntregaExamen")) validarCampos("Metodo de entrega", cmb: cmb_Forma_Entrega, refer: 2);
                else if (error.StackTrace.Contains("MetodoPagoExamen")) validarCampos("Metodo de pago", cmb: cmb_Forma_Pago, refer: 2);
            }   
        }

        private void validarCampos(string leyenda, [Optional]TextBox txt,[Optional]ComboBox cmb,[Optional] int refer)
        {
            MessageBox.Show($"No se puede dejar {leyenda} vacío");
            if (refer == 1) txt.Focus();
            else if (refer == 2) cmb.Focus();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Solicitud_Examen_Cargar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Validación de datos

                Ventas.Ventas nuev = new();
                nuev.Cantidad= string.IsNullOrEmpty(txt_Cantidad_Examen.Text) ? -1 : int.Parse(txt_Cantidad_Examen.Text);
                nuev.CodigoPaciente= Ventas.ventasDAL.TraerCodigoPaciente(txt_Solicitud_Examen_ID_Cliente.Text);
                nuev.CodigoEnfermero = cmb_Solicitud_Examen_Enfermero.SelectedIndex+1;
                nuev.CodigoExamenMedico = string.IsNullOrEmpty(txt_Solicitud_Examen_Buscar.Text) ? -1 : int.Parse(txt_Solicitud_Examen_Buscar.Text);
                nuev.CodigoFacturador = codEmpleado;
                nuev.CodigoMicrobiologo = cmb_Solicitud_Examen_Microbiologo.SelectedIndex+1;
                nuev.EstadoExamenMedico = 1;
                nuev.ExamenCombo = (bool)chk_Solicitud_Examen_Combo_Si.IsChecked;
                nuev.FechaOrden = DateTime.Now;
                nuev.MetodoEntregaExamen = cmb_Forma_Entrega.SelectedIndex + 1;
                nuev.MetodoPagoExamen = cmb_Forma_Pago.SelectedIndex+1;
                nuevaVenta.Add(nuev);

                tabla.Rows.Add(nuev.CodigoExamenMedico, nuev.CodigoFacturador, nuev.CodigoMicrobiologo,
                                    nuev.CodigoEnfermero, nuev.CodigoPaciente, nuev.MetodoEntregaExamen, nuev.MetodoPagoExamen,
                                    nuev.Cantidad, nuev.EstadoExamenMedico, nuev.ExamenCombo, nuev.FechaOrden);     
                
                dtg_Solicitud_Examen_Examenes.DataContext = tabla;


            }
            catch (FormatException error)
            {
                //Excepción que nos indicará si hay algún error
                if (error.StackTrace.Contains("CodigoPaciente")) validarCampos("paciente", txt_Solicitud_Examen_ID_Cliente, refer: 1);
                else if (error.StackTrace.Contains("Cantidad")) validarCampos("cantidad", txt_Cantidad_Examen, refer: 1);
                else if (error.StackTrace.Contains("CodigoMicrobiologo")) validarCampos("Microbiologo", cmb: cmb_Solicitud_Examen_Microbiologo, refer: 2);
                else if (error.StackTrace.Contains("CodigoEnfermero")) validarCampos("Enfermero", cmb: cmb_Solicitud_Examen_Enfermero, refer: 2);
                else if (error.StackTrace.Contains("MetodoEntregaExamen")) validarCampos("Metodo de entrega", cmb: cmb_Forma_Entrega, refer: 2);
                else if (error.StackTrace.Contains("MetodoPagoExamen")) validarCampos("Metodo de pago", cmb: cmb_Forma_Pago, refer: 2);
            }
        }

        private void btn_Solicitud_Examen_Nuevo_Cliente_Click(object sender, RoutedEventArgs e)
        {
            agregarPaciente nuevoPaciente = new();
            nuevoPaciente.ShowDialog();
        }

        private void txt_Solicitud_Examen_Buscar_KeyUp(object sender, KeyEventArgs e)
        {
            stc_InfoPaciente.Visibility = Visibility.Visible;
            scv_BuscarPaciente.Visibility = Visibility.Visible;
            brd_BuscarPaciente.Visibility = Visibility.Visible;
            //scv_BuscarPaciente.Background = new 
            bool found = false;
            var border = (stc_InfoPaciente.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarExamenMedico.GetData();

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
                txt_Solicitud_Examen_Buscar.Text = (sender as TextBlock).Text.Split("-")[1];
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

        private void txt_Solicitud_Examen_ID_Cliente_KeyUp(object sender, KeyEventArgs e)
        {
            stc_InfoCliente.Visibility = Visibility.Visible;
            scv_BuscarCliente.Visibility = Visibility.Visible;
            brd_BuscarCliente.Visibility = Visibility.Visible;
            bool found = false;
            var border = (stc_InfoPaciente.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarEmpleado.GetData();

            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                // Clear   
                stc_InfoCliente.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list   
            stc_InfoCliente.Children.Clear();

            // Add the result   
            foreach (var obj in data)
            {
                if (obj.ToLower().StartsWith(query.ToLower()))
                {
                    // The word starts with this... Autocomplete must work   
                    addItem1(obj);
                    found = true;
                }
            }

            if (!found)
            {
                stc_InfoCliente.Children.Add(new TextBlock() { Text = "No existe ese No. de Identidad de paciente." });
            }
        }

        private void addItem1(String text)
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
                txt_Solicitud_Examen_ID_Cliente.Text = (sender as TextBlock).Text.Split(" ")[0];
                stc_InfoCliente.Visibility = Visibility.Hidden;
                scv_BuscarCliente.Visibility = Visibility.Hidden;
                brd_BuscarCliente.Visibility = Visibility.Hidden;
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
            stc_InfoCliente.Children.Add(block);
        }
    }
}
