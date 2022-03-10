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
using Clinica_Medica_Polanco.Empleados;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para EliminarEmpleado.xaml
    /// </summary>
    public partial class AgregarEmpleado : Window
    {
        public AgregarEmpleado()
        {
            InitializeComponent();
            this.SourceInitialized += AgregarEmpleado_SourceInitialized;
            cargarJornada();
            cargarCargo();
            cargarSucursal();

            dtp_Nacimiento.Text = DateTime.Now.ToShortDateString();
            dtp_Ingreso_Agregar_Empleado.Text = "1999/01/01";
            dtp_Pago_Agregar_Empleado.Text = "1999/01/01";
            cmb_Tipo_Sangre.Items.Add("A+");
            cmb_Tipo_Sangre.Items.Add("O");
            cmb_Tipo_Sangre.Items.Add("AB+");
            cmb_Tipo_Sangre.Items.Add("AB-");
        }
        private void btn_Salir_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AgregarEmpleado_SourceInitialized(object sender, EventArgs e)
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


        private void btn_Agregar_Empleado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int resultado = 0;


                Empleados.Empleados empleados1 = new();
                empleados1.NombreEmpleado = txt_Nombre.Text;
                empleados1.ApellidoEmpleado = txt_Apellido.Text;
                empleados1.IdentidadEmpleado = txt_Identidad.Text;
                empleados1.TelefonoEmpleado = txt_Telefono.Text;
                empleados1.FechaNacimientoEmpleado = Convert.ToDateTime(dtp_Nacimiento.Text);
                empleados1.CorreoEmpleado = txt_Correo.Text;
                empleados1.AlturaEmpleado = string.IsNullOrEmpty(txt_Altura.Text) ? 0 : int.Parse(txt_Altura.Text);
                empleados1.TipoSangreEmpleado = cmb_Tipo_Sangre.SelectedItem.ToString();
                empleados1.DireccionEmpleado = string.IsNullOrWhiteSpace(StringFromRichTextBox(rtb_Direccion)) ? null : StringFromRichTextBox(rtb_Direccion);
                empleados1.SueldoBase = string.IsNullOrEmpty(txt_Sueldo.Text) ? -1 : int.Parse(txt_Sueldo.Text);
                empleados1.FechaPago = Convert.ToDateTime(dtp_Pago_Agregar_Empleado.Text);
                empleados1.FechaContratacion = Convert.ToDateTime(dtp_Ingreso_Agregar_Empleado.Text);
                empleados1.CodigoJornada = cmb_Jornada_Laboral.SelectedIndex + 1;
                empleados1.CodigoPuesto = cmb_Cargo.SelectedIndex + 1;
                empleados1.CodigoSucursal = cmb_Sucursal.SelectedIndex +1;
                empleadosDAL.AgregarEmpleado(empleados1);
                this.Close();

            }

            catch (FormatException error)
            {
                if (error.StackTrace.Contains("Nombre")) validateFields(txt_Nombre, leyenda: "Nombre");
                else if (error.StackTrace.Contains("Apellido")) validateFields(txt_Apellido, leyenda: "Apellido");
                else if (error.StackTrace.Contains("Identidad")) validateFields(txt_Identidad, leyenda: "Identidad");
                else if (error.StackTrace.Contains("Telefono")) validateFields(txt_Telefono, leyenda: "Teléfono");
                else if (error.StackTrace.Contains("Correo")) validateFields(txt_Correo, leyenda: "Correo");
                else if (error.StackTrace.Contains("Altura")) validateFields(txt_Altura, leyenda: "Altura");
                else if (error.StackTrace.Contains("FechaNacimiento")) validateFields(leyenda: "Fecha de nacimiento", dt: dtp_Nacimiento, refer: 2);
                else if (error.StackTrace.Contains("TipoSangre")) validateFields(leyenda: "Tipo de sangre", cmb: cmb_Tipo_Sangre, refer: 3);
                else if (error.StackTrace.Contains("Direccion")) validateFields(rtb: rtb_Direccion, leyenda: "Dirección", refer: 4);
                else if (error.StackTrace.Contains("Sueldo")) validateFields(txt_Sueldo, leyenda: "Sueldo");
                else if (error.StackTrace.Contains("Cargo")) validateFields(leyenda: "Cargo", cmb: cmb_Cargo, refer: 3);
                else if (error.StackTrace.Contains("Jornada")) validateFields(leyenda: "Jornada laboral", cmb: cmb_Jornada_Laboral, refer: 3);
                else if (error.StackTrace.Contains("Sucursal")) validateFields(leyenda: "Sucursal", cmb: cmb_Sucursal, refer: 3);
                else if (error.StackTrace.Contains("FechaPago")) validateFields(leyenda: "Fecha de pago", dt: dtp_Pago_Agregar_Empleado, refer: 2);
                else if (error.StackTrace.Contains("FechaContratacion")) validateFields(leyenda: "Fecha de ingreso", dt: dtp_Ingreso_Agregar_Empleado, refer: 2);

            }
        }
        private void validateFields([Optional] TextBox txts, [Optional] RichTextBox rtb, String leyenda, [Optional] DatePicker dt, [Optional] ComboBox cmb, [Optional] int refer)
        {
            MessageBox.Show("No se pueden dejar espacios en blanco o ingresar caracteres inválidos en " + leyenda);

            if (refer == 2) dt.Focus();
            else if (refer == 3) cmb.Focus();
            else if (refer == 4) rtb.Focus();
            else txts.Focus();

        }

        private string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                rtb.Document.ContentStart,
                rtb.Document.ContentEnd
            );

            return textRange.Text;
        }


        void cargarJornada()
        {
            SqlConnection conexion = new SqlConnection("server = localhost; database=Clinica medica polanco; Integrated Security = true");

            try
            {
                conexion.Open();
                string Query = "Select Codigo_Jornada, Descripcion_Jornada from Jornadas_Empleados";
                SqlCommand createCommand = new SqlCommand(cmdText: Query, conexion);
                SqlDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr.GetString(1);
                    cmb_Jornada_Laboral.Items.Add(nombre);
                }

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void cargarCargo()
        {
            SqlConnection conexion = new SqlConnection("server = localhost; database=Clinica medica polanco; Integrated Security = true");

            try
            {
                conexion.Open();
                string Query = "Select Codigo_Puestos, Descripcion_Puesto from Puestos_Empleados";
                SqlCommand createCommand = new SqlCommand(cmdText: Query, conexion);
                SqlDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr.GetString(1);
                    cmb_Cargo.Items.Add(nombre);
                }

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void cargarSucursal()
        {
            SqlConnection conexion = new SqlConnection("server = localhost; database=Clinica medica polanco; Integrated Security = true");

            try
            {
                conexion.Open();
                string Query = "Select Codigo_Sucursal, Nombre_Sucursal from Sucursales";
                SqlCommand createCommand = new SqlCommand(cmdText: Query, conexion);
                SqlDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr.GetString(1);
                    cmb_Sucursal.Items.Add(nombre);
                }

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}