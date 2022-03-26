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
using Clinica_Medica_Polanco.Ventas;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para pagarExamenMedico.xaml
    /// </summary>
    public partial class pagarExamenMedico : Window
    {
        private int codFactura = 0;
        public pagarExamenMedico(List<Ventas.Ventas> nuevaVenta,int codFactura)
        {
            List<Ventas.Ventas> pagarVenta = new();
            InitializeComponent();
            
            this.SourceInitialized += PagarExamenMedico_SourceInitialized;
            this.codFactura = codFactura;

            foreach ( Ventas.Ventas v in nuevaVenta)
            {
                v.CodFacturaVenta = codFactura;
                pagarVenta.Add(v);
            }
            dgv_Datos_Pago.ItemsSource = nuevaVenta;

        }


        // Funcion para no mover la ventana del form
        private void PagarExamenMedico_SourceInitialized(object sender, EventArgs e)
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
        private void btn_Pagar_Click(object sender, RoutedEventArgs e)
        {
            Factura nueva = new();
            nueva.ShowDialog();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Pago nuevoPago = ventasDAL.cargarDatosPago(codFactura);
            Pago nuevaVenta = ventasDAL.cargarDatosVenta(codFactura);

            txt_Nombre_Pagar.Text = nuevaVenta.NombrePaciente;
            txt_Telefono_Pagar.Text = nuevaVenta.TelefonoPaciente;
            txt_Email_Pagar.Text = nuevaVenta.CorreoPaciente;
            txt_Fecha_Orden_Pagar.Text = nuevaVenta.FechaOrden;
            txt_Forma_Pagar.Text = nuevaVenta.MetodoPago;
            txt_Forma_Entrega_Pagar.Text = nuevaVenta.MetodoEntrega;
            txt_IVA.Text =  Math.Round(nuevoPago.ISV,2).ToString();
            txt_Descuento.Text = Math.Round(nuevoPago.Descuento, 2).ToString();
            txt_Total_Pagar.Text = Math.Round(nuevoPago.TotalVenta, 2).ToString();
            txt_Subtotal.Text = Math.Round(nuevoPago.Subtotal, 2).ToString();
            txt_Subtotal.Text = Math.Round(nuevoPago.Subtotal, 2).ToString();
        }
    }
}
