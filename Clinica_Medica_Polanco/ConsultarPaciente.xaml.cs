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
using Clinica_Medica_Polanco.Pacientes;
using System.Data;
using System.Windows.Controls.Primitives;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para ConsultarPaciente.xaml
    /// </summary>
    public partial class ConsultarPaciente : Window
    {
        public ConsultarPaciente()
        {
            InitializeComponent();
            this.SourceInitialized += ConsultarPaciente_SourceInitialized;
        }

        private void ConsultarPaciente_SourceInitialized(object sender, EventArgs e)
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



        private void btn_Consultar_Pacientes_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Consultar_Pacientes_Click(object sender, RoutedEventArgs e)
        {
            string consultar_paciente = txt_Consultar_Pacientes.Text;

            if (!string.IsNullOrEmpty(consultar_paciente))
            {
                dtg_Consultar_Pacientes.ItemsSource = PacientesDAL.ConsultarPaciente(consultar_paciente);
            }
            else MessageBox.Show("Ingrese un id de paciente válido");  
        }

        private void txt_Consultar_Pacientes_KeyUp(object sender, KeyEventArgs e)
        {
            stc_InfoPaciente.Visibility = Visibility.Visible;
            scv_BuscarPaciente.Visibility = Visibility.Visible;
            brd_BuscarPaciente.Visibility = Visibility.Visible;
            //scv_BuscarPaciente.Background = new 
            bool found = false;
            var border = (stc_InfoPaciente.Parent as ScrollViewer).Parent as Border;
            var data = Autocompletados.autocompletarPacinte.GetData();

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

            stc_InfoPaciente.Children.Add(new TextBlock() { Text = " Identidad                 Nombre      Apellido" });
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

            // Mouse events: cuando le doy click al mouse   
            block.MouseLeftButtonUp += (sender, e) =>
            {
                txt_Consultar_Pacientes.Text = (sender as TextBlock).Text.Split(" ")[0];
                dtg_Consultar_Pacientes.ItemsSource = PacientesDAL.ConsultarPaciente(txt_Consultar_Pacientes.Text);

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
