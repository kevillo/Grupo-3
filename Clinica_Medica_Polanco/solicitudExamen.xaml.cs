﻿using System;
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
using System.Runtime.InteropServices;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para solicitudExamen.xaml
    /// </summary>
    public partial class solicitudExamen : Window
    {
        public solicitudExamen()
        {
            InitializeComponent();
            this.SourceInitialized += SolicitudExamen_SourceInitialized;
            cmb_Solicitud_Examen_Microbiologo.Items.Add("a");
            cmb_Solicitud_Examen_Enfermero.Items.Add("a");
            cmb_Forma_Entrega.Items.Add("a");
            cmb_Forma_Pago.Items.Add("a");
        }
        private void SolicitudExamen_SourceInitialized(object sender, EventArgs e)
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


        private void btn_Solicitud_Examen_Procesar_Orden_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                Ventas.Ventas nuevaVenta = new();
                int[] codigosExamen = { 2, 2 };
                nuevaVenta.CodigoFacturaVenta = 45; // aqui habra un metodo para traer el codigo
                nuevaVenta.CodigoExamenMedico = codigosExamen; // aqui se guardaran todos los codigos de examenes del dgv
                nuevaVenta.CodigoFacturador = 2; // aqui vamos a poner el codigo del empleado
                nuevaVenta.CodigoMicrobiologo = cmb_Solicitud_Examen_Microbiologo.SelectedIndex;
                MessageBox.Show(nuevaVenta.CodigoMicrobiologo.ToString());
                nuevaVenta.CodigoEnfermero = cmb_Solicitud_Examen_Enfermero.SelectedIndex;
                nuevaVenta.CodigoCliente = 4;//aqui vamos a seleccionar el id a traves de un autocompletar, que muestre el nombre y apellido
                nuevaVenta.MetodoEntregaExamen = cmb_Forma_Entrega.SelectedIndex;
                nuevaVenta.MetodoPagoExamen = cmb_Forma_Pago.SelectedIndex;
                nuevaVenta.FechaOrden = DateTime.Now;
                nuevaVenta.ExamenCombo =  Convert.ToBoolean(chk_Solicitud_Examen_Combo_Si.IsChecked);
                nuevaVenta.Cantidad = 4; // vamos a sacar el codigo de la cantidad en el dgv
                nuevaVenta.EstadoExamenMedico = 1; // cambiar estado a en proceso
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
            MessageBox.Show($"no se puede dejar {leyenda} vacío");
            if (refer == 1) txt.Focus();
            else if (refer == 2) cmb.Focus();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Solicitud_Examen_Cargar_Click(object sender, RoutedEventArgs e)
        {
            string examenBuscar = txt_Solicitud_Examen_Buscar.Text;
            if (!string.IsNullOrEmpty(examenBuscar))
            {
                // codigo para buscar los examenes 
            }
            else MessageBox.Show("No pueden buscar exámenes vacíos");
        }
    }
}
