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
using System.Data;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para revisionExamen.xaml
    /// </summary>
    public partial class entregarExamen : Window
    {
        
        public entregarExamen()
        {
            InitializeComponent();
            
            this.SourceInitialized += entregarExamen_SourceInitialized;
           
        }

        private void btn_Revision_Examen_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void entregarExamen_SourceInitialized(object sender, EventArgs e)
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

        private void btn_Entrega_Examen_Fisico_Click(object sender, RoutedEventArgs e)
        {
            ExamenesMedicos.ExamenesDAL.entregarExamenMedico(int.Parse(txt_Entrega_Examen_Buscar.Text));
            MessageBox.Show("Exámen/es actualizado/s");
            this.Close();
        }

        private void btn_Entrega_Examen_Correo_Click(object sender, RoutedEventArgs e)
        {
            servicios.serviciosEntrega ventaEntregar = (servicios.serviciosEntrega)dtg_Entrega_Examen_Examenes.SelectedItem; 
            ProcesoCorreo procesoCorreo = new ProcesoCorreo(ventaEntregar);
            procesoCorreo.ShowDialog();
            this.Close();
        }
        private void btn_Entrega_Examen_Buscar_Click(object sender, RoutedEventArgs e)
        {
            string buscar_Examen = txt_Entrega_Examen_Buscar.Text;
            if (!string.IsNullOrEmpty(buscar_Examen))
            {
                MessageBox.Show("Si no aparece nada en el recuadro de abajo,\nsignifica que ese paciente no tiene ningun examen listo para entregar");
                if (buscar_Examen.Length < 13)
                {
                    int codFactura = int.Parse(buscar_Examen);
                    cargarDTGEntrega(codFactura);
                }
                else cargarDTGEntrega(buscar_Examen);
            }
            else MessageBox.Show("Ingrese un id de paciente o numero de factura");
        }


        private void cargarDTGEntrega(int facturaCod)
        {
            List<Ventas.Ventas> entregarVenta = ExamenesMedicos.ExamenesDAL.obtenerExamenesParaEntregar(facturaCod);
            servicios.Servicios nuevoServicio = new();
            List<servicios.serviciosEntrega> nuevaEntrega = new();
            foreach (Ventas.Ventas nuev in entregarVenta)
            {
                servicios.serviciosEntrega entrega = new();
                nuevoServicio.NombreExamen = servicios.serviciosDAL.traerNombreExamen(nuev.CodigoExamenMedico);
                nuevoServicio.NombreEmpleado = servicios.serviciosDAL.traerNombreFacturador(nuev.CodigoFacturador);
                nuevoServicio.NombreMetodoEntrega = servicios.serviciosDAL.traerNombreMetodoEntrega(nuev.MetodoEntregaExamen);
                nuevoServicio.NombreMetodoPago = servicios.serviciosDAL.traerNombreMetodoPago(nuev.MetodoPagoExamen);
                nuevoServicio.NombrePaciente = servicios.serviciosDAL.traerNombrePaciente(nuev.CodigoPaciente);

                entrega.CodFacturaVenta = nuev.CodFacturaVenta;
                entrega.CodigoEnfermero = nuev.CodigoEnfermero;
                entrega.CodigoExamenMedico = nuev.CodigoExamenMedico;
                entrega.CodigoFacturador = nuev.CodigoFacturador;
                entrega.CodigoMicrobiologo = nuev.CodigoMicrobiologo;
                entrega.CodigoPaciente = nuev.CodigoPaciente;
                entrega.EstadoExamenMedico = nuev.EstadoExamenMedico;
                entrega.ExamenCombo = nuev.ExamenCombo;
                entrega.MetodoEntregaExamen = nuev.MetodoEntregaExamen;
                entrega.MetodoPagoExamen = nuev.MetodoPagoExamen;
                entrega.NombreEmpleado = nuevoServicio.NombreEmpleado;
                entrega.NombreExamen = nuevoServicio.NombreExamen;
                entrega.NombreMetodoEntrega = nuevoServicio.NombreMetodoEntrega;
                entrega.NombreMetodoPago = nuevoServicio.NombreMetodoPago;
                entrega.NombrePaciente = nuevoServicio.NombrePaciente;
                entrega.FechaOrden = nuev.FechaOrden;

                nuevaEntrega.Add(entrega);
            }

            dtg_Entrega_Examen_Examenes.ItemsSource = nuevaEntrega;
        }
        private void cargarDTGEntrega(string facturaCod)
        {

            List<Ventas.Ventas> entregarVenta = ExamenesMedicos.ExamenesDAL.obtenerExamenesParaEntregar(facturaCod);
            servicios.Servicios nuevoServicio = new();
            List<servicios.serviciosEntrega> nuevaEntrega = new();
            foreach (Ventas.Ventas nuev in entregarVenta)
            {
                servicios.serviciosEntrega entrega = new();
                nuevoServicio.NombreExamen = servicios.serviciosDAL.traerNombreExamen(nuev.CodigoExamenMedico);
                nuevoServicio.NombreEmpleado = servicios.serviciosDAL.traerNombreFacturador(nuev.CodigoFacturador);
                nuevoServicio.NombreMetodoEntrega = servicios.serviciosDAL.traerNombreMetodoEntrega(nuev.MetodoEntregaExamen);
                nuevoServicio.NombreMetodoPago = servicios.serviciosDAL.traerNombreMetodoPago(nuev.MetodoPagoExamen);
                nuevoServicio.NombrePaciente = servicios.serviciosDAL.traerNombrePaciente(nuev.CodigoPaciente);
                
                entrega.CodFacturaVenta = nuev.CodFacturaVenta;
                entrega.CodigoEnfermero = nuev.CodigoEnfermero;
                entrega.CodigoExamenMedico = nuev.CodigoExamenMedico;
                entrega.CodigoFacturador = nuev.CodigoFacturador;
                entrega.CodigoMicrobiologo = nuev.CodigoMicrobiologo;
                entrega.CodigoPaciente = nuev.CodigoPaciente;
                entrega.EstadoExamenMedico = nuev.EstadoExamenMedico;
                entrega.ExamenCombo = nuev.ExamenCombo;
                entrega.MetodoEntregaExamen = nuev.MetodoEntregaExamen;
                entrega.MetodoPagoExamen = nuev.MetodoPagoExamen;
                entrega.NombreEmpleado = nuevoServicio.NombreEmpleado;
                entrega.NombreExamen = nuevoServicio.NombreExamen;
                entrega.NombreMetodoEntrega = nuevoServicio.NombreMetodoEntrega;
                entrega.NombreMetodoPago = nuevoServicio.NombreMetodoPago;
                entrega.NombrePaciente = nuevoServicio.NombrePaciente;
                entrega.FechaOrden = nuev.FechaOrden;

                nuevaEntrega.Add(entrega);
            }
            dtg_Entrega_Examen_Examenes.ItemsSource = nuevaEntrega;

        }

        private void txt_Entrega_Examen_Buscar_KeyUp(object sender, KeyEventArgs e)
        {
            stc_InfoPaciente.Visibility = Visibility.Visible;
            scv_BuscarPaciente.Visibility = Visibility.Visible;
            brd_BuscarPaciente.Visibility = Visibility.Visible;
            bool found = false;
            var border = (stc_InfoPaciente.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarEntregaExamenMedico.GetData();

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

            stc_InfoPaciente.Children.Add(new TextBlock() { Text = "Identidad            Factura      Nombre" });

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
                txt_Entrega_Examen_Buscar.Text = (sender as TextBlock).Text.Split(" - ")[1];
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
