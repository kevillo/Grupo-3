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
using System.Text.RegularExpressions;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para AnalizarExamenMedico.xaml
    /// </summary>
    public partial class AnalizarExamenMedico : Window
    {
        private servicios.serviciosEntrega ventaAnalisis = new();
        public AnalizarExamenMedico(servicios.serviciosEntrega venta)
        {
            InitializeComponent();
            ventaAnalisis = venta;
            this.SourceInitialized += AnalizarExamenMedico_SourceInitialized;
        }

        /// Funcion para evitar el movimiento del formulario
        private void AnalizarExamenMedico_SourceInitialized(object sender, EventArgs e)
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

        private void btn_Guardar_Analisis_Click(object sender, RoutedEventArgs e)
        {

            string analisis = rtbAString(rtb_Diagnostico_Analisis);
            if (!string.IsNullOrEmpty(analisis)  && !string.IsNullOrWhiteSpace(analisis) && !((analisis).StartsWith(" ") || (analisis).EndsWith(" ")))
            {
                // aqui actualizamos el estado del examen dicho a 2: listo
                ExamenesMedicos.ExamenesDAL.analizarExamenMedico(ventaAnalisis.CodFacturaVenta, ventaAnalisis.CodigoExamenMedico, Regex.Replace(analisis, "\\s+", " "));
                this.Close();
            }
            else MessageBox.Show("Procure no dejar el análisis del examen con un formato incorrecto o vacío.");      
        }


        private string rtbAString(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                rtb.Document.ContentStart,
                rtb.Document.ContentEnd
            );

            return textRange.Text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Pacientes.Pacient nuevoPaciente;
            nuevoPaciente = Pacientes.PacientesDAL.BuscarPaciente(ventaAnalisis.CodigoPaciente);
            txt_Fecha_Orden_Analisis.Text = ventaAnalisis.FechaOrden.ToShortDateString();
            txt_Orden_Analisis.Text = ventaAnalisis.CodFacturaVenta.ToString();
            txt_Correo_Analisis.Text = nuevoPaciente.Correo;
            txt_Nombre_Analisis.Text = nuevoPaciente.Nombre;
            txt_Fecha_Nacimiento_Analisis.Text = nuevoPaciente.FechaNacimiento.ToShortDateString();
        }
    }
}
