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
            tabla.Columns.Add("Examen médico");
            tabla.Columns.Add("Nombre Examen");
            tabla.Columns.Add("Codigo facturador");
            tabla.Columns.Add("Nombre Facturador");
            tabla.Columns.Add("Microbiólogo");
            tabla.Columns.Add("Enfermero");
            tabla.Columns.Add("Paciente");
            tabla.Columns.Add("Nombre Paciente");
            tabla.Columns.Add("Forma entrega examen");
            tabla.Columns.Add("Descripción Entrega");
            tabla.Columns.Add("Forma pago examen");
            tabla.Columns.Add("Descripción Pago");
            tabla.Columns.Add("Cantidad");
            tabla.Columns.Add("Estado examen");
            tabla.Columns.Add("Combo");
            tabla.Columns.Add("Fecha factura");
            dtg_Solicitud_Examen_Examenes.ItemsSource = tabla.AsDataView();
            dtg_Solicitud_Examen_Examenes.IsReadOnly = true;
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
            int codSucursalEmpleado = Ventas.ventasDAL.obtenerIdSucursal(codEmpleado);
            Ventas.ventasDAL.GenerarFactura(codSucursalEmpleado);
            try
            {
                int codigoFacturaVenta = Ventas.ventasDAL.ObtenerIdVenta();
                
                foreach (Ventas.Ventas v in nuevaVenta)
                {

                    Ventas.ventasDAL.RegistrarVenta(v, codigoFacturaVenta);
                    
                }

                pagarExamenMedico nuevopago = new pagarExamenMedico(nuevaVenta,codigoFacturaVenta);
                nuevopago.ShowDialog();
                this.Close();
            }
            catch(FormatException error)
            {
                if (error.StackTrace.Contains("CodigoPaciente")) validarCampos("Paciente", txt_Solicitud_Examen_ID_Cliente, refer: 1);
                else if (error.StackTrace.Contains("CodigoMicrobiologo")) validarCampos("Microbiólogo", cmb: cmb_Solicitud_Examen_Microbiologo, refer: 2);
                else if (error.StackTrace.Contains("CodigoEnfermero")) validarCampos("Enfermero", cmb: cmb_Solicitud_Examen_Enfermero, refer: 2);
                else if (error.StackTrace.Contains("MetodoEntregaExamen")) validarCampos("Método de entrega", cmb: cmb_Forma_Entrega, refer: 2);
                else if (error.StackTrace.Contains("MetodoPagoExamen")) validarCampos("Método de pago", cmb: cmb_Forma_Pago, refer: 2);
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

        private int cont = 0;
        private int[] codigos = new int[50];

        private void btn_Solicitud_Examen_Cargar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Solicitud_Examen_ID_Cliente.Text))
            {

                try
                {

                    //Validación de datos
                    Ventas.Ventas nuev = new();
                    servicios.Servicios nuevoServicio = new();
                    nuev.Cantidad = string.IsNullOrEmpty(txt_Cantidad_Examen.Text) ? -1 : int.Parse(txt_Cantidad_Examen.Text);
                    nuev.CodigoPaciente = Ventas.ventasDAL.TraerCodigoPaciente(txt_Solicitud_Examen_ID_Cliente.Text);
                    nuev.CodigoEnfermero = cmb_Solicitud_Examen_Enfermero.SelectedIndex + 1;
                    nuev.CodigoExamenMedico = string.IsNullOrEmpty(txt_Solicitud_Examen_Buscar.Text) ? -1 : int.Parse(txt_Solicitud_Examen_Buscar.Text);
                    nuev.CodigoFacturador = codEmpleado;
                    nuev.CodigoMicrobiologo = cmb_Solicitud_Examen_Microbiologo.SelectedIndex + 1;
                    nuev.EstadoExamenMedico = 1;
                    nuev.ExamenCombo = (bool)chk_Solicitud_Examen_Combo_Si.IsChecked;
                    nuev.FechaOrden = DateTime.Now;
                    nuev.MetodoEntregaExamen = cmb_Forma_Entrega.SelectedIndex + 1;
                    nuev.MetodoPagoExamen = cmb_Forma_Pago.SelectedIndex + 1;

                    nuevoServicio.NombreEmpleado = servicios.serviciosDAL.traerNombreFacturador(nuev.CodigoFacturador);
                    nuevoServicio.NombrePaciente = servicios.serviciosDAL.traerNombrePaciente(nuev.CodigoPaciente);
                    nuevoServicio.NombreExamen = servicios.serviciosDAL.traerNombreExamen(nuev.CodigoExamenMedico);
                    nuevoServicio.NombreMetodoEntrega = servicios.serviciosDAL.traerNombreMetodoEntrega(nuev.MetodoEntregaExamen);
                    nuevoServicio.NombreMetodoPago = servicios.serviciosDAL.traerNombreMetodoPago(nuev.MetodoPagoExamen);
              
                    int indice = Array.IndexOf(codigos, nuev.CodigoExamenMedico);
                   

                    if (indice > -1)
                    {
                        MessageBox.Show("El número del examen se repite, por favor ingrese otro examen médico");
                        txt_Solicitud_Examen_Buscar.Clear();
                        txt_Cantidad_Examen.Clear();
                        txt_Solicitud_Examen_Buscar.Focus();
                    }
                    else
                    {
                        codigos[cont++] = nuev.CodigoExamenMedico;
                        nuevaVenta.Add(nuev);

                        tabla.Rows.Add(nuev.CodigoExamenMedico, nuevoServicio.NombreExamen,nuev.CodigoFacturador,nuevoServicio.NombreEmpleado, nuev.CodigoMicrobiologo,
                                            nuev.CodigoEnfermero, nuev.CodigoPaciente,nuevoServicio.NombrePaciente, nuev.MetodoEntregaExamen,nuevoServicio.NombreMetodoEntrega, nuev.MetodoPagoExamen,nuevoServicio.NombreMetodoPago,
                                            nuev.Cantidad, nuev.EstadoExamenMedico, nuev.ExamenCombo, nuev.FechaOrden);
                        dtg_Solicitud_Examen_Examenes.DataContext = tabla;
                    }
                }
                catch (FormatException error)
                {
                    //Excepción que nos indicará si hay algún error
                    if (error.StackTrace.Contains("CodigoPaciente")) validarCampos("Paciente", txt_Solicitud_Examen_ID_Cliente, refer: 1);
                    else if (error.StackTrace.Contains("Cantidad")) validarCampos("Cantidad", txt_Cantidad_Examen, refer: 1);
                    else if (error.StackTrace.Contains("CodigoMicrobiologo")) validarCampos("Microbiólogo", cmb: cmb_Solicitud_Examen_Microbiologo, refer: 2);
                    else if (error.StackTrace.Contains("CodigoEnfermero")) validarCampos("Enfermero", cmb: cmb_Solicitud_Examen_Enfermero, refer: 2);
                    else if (error.StackTrace.Contains("MetodoEntregaExamen")) validarCampos("Método de entrega", cmb: cmb_Forma_Entrega, refer: 2);
                    else if (error.StackTrace.Contains("MetodoPagoExamen")) validarCampos("Método de pago", cmb: cmb_Forma_Pago, refer: 2);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un paciente al que aplicarle un examen");
                txt_Solicitud_Examen_ID_Cliente.Focus();
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
            stc_InfoPaciente.Children.Add(new TextBlock() { Text = "Codigo      Descripcion" });
            // Add the result   
            foreach (var obj in data)
            {
                if (obj.Split(" - ")[0].ToLower().StartsWith(query.ToLower())|| obj.Split(" - ")[1].ToLower().StartsWith(query.ToLower()))
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
                txt_Solicitud_Examen_Buscar.Text = (sender as TextBlock).Text.Split("-")[0];
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
            var data = Autocompletados.autocompletarPacinte.GetData();

            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                // Clear   
                stc_InfoCliente.Children.Clear();

                //border.Visibility = Visibility.Collapsed;
                stc_InfoCliente.Visibility = Visibility.Hidden;
                scv_BuscarCliente.Visibility = Visibility.Hidden;
                brd_BuscarCliente.Visibility = Visibility.Hidden;
            }
            else
            {
                border.Visibility = Visibility.Visible;
            }

            // Clear the list   
            stc_InfoCliente.Children.Clear();
            stc_InfoPaciente.Children.Add(new TextBlock() { Text = " Identidad                 Nombre      Apellido" });
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

        //validacion para que solo se pueda ingresar numeros a un campo
        private void txt_Solicitud_Examen_ID_Cliente_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        //validacion para que solo se pueda ingresar numeros a un campo
        private void txt_Cantidad_Examen_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }
    }
}
