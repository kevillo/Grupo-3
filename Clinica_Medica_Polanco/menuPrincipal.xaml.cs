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

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para menuPrincipal.xaml
    /// </summary>
    public partial class menuPrincipal : Window
    {
        private int codEmpleado;
        public menuPrincipal(int id)
        {

            InitializeComponent();
            codEmpleado = id;
            // se busca el rol del empleado en la base y si no es admin se configura la pantalla como empleado
             string rol = ConexionBaseDeDatos.confEmpleado(id);
            if (!(rol == "Administrador")) EmployeeConfiguration();
        }

        private void EmployeeConfiguration()
        {
            btn_Empleados.Visibility = Visibility.Hidden;
            btn_Informes.Visibility = Visibility.Hidden;
            btn_Inventario.Visibility = Visibility.Hidden;
            imgEmpleado.Visibility = Visibility.Hidden;
            imgInformes.Visibility = Visibility.Hidden;
            imgInventario.Visibility = Visibility.Hidden;
        }

      
        private void btn_Examenes_medicos_Click(object sender, RoutedEventArgs e)
        {

            btn_poly_decor_click(poly_Deco_Examenes, btn_Examenes_medicos);
            menuPrincipalExamenes nuevo = new(codEmpleado);
            panel_Menu_Principal.Children.Clear();
            panel_Menu_Principal.Children.Add(nuevo);

        }
        private void btn_Configuracion_Click(object sender, RoutedEventArgs e)
        {
            btn_poly_decor_click(poly_Deco_Configuracion, btn_Configuracion);
            menuPrincipalConfiguracion conf = new();
            panel_Menu_Principal.Children.Clear();
            panel_Menu_Principal.Children.Add(conf);
        }

        private void btn_Pacientes_Click(object sender, RoutedEventArgs e)
        {
            btn_poly_decor_click(poly_Deco_Pacientes, btn_Pacientes);
            menuPrincipalPacientes paciente1 = new();
            panel_Menu_Principal.Children.Clear();
            panel_Menu_Principal.Children.Add(paciente1);

        }

        private void btn_Informes_Click(object sender, RoutedEventArgs e)
        {
            btn_poly_decor_click(poly_Deco_Informes, btn_Informes);
            menuPrincipalInformes infor = new();
            panel_Menu_Principal.Children.Clear();
            panel_Menu_Principal.Children.Add(infor);
        }

        private void btn_Inventario_Click(object sender, RoutedEventArgs e)
        {
            btn_poly_decor_click(poly_Deco_Inventario, btn_Inventario);
            menuPrincipalInventario inv = new(codEmpleado);
            panel_Menu_Principal.Children.Clear();
            panel_Menu_Principal.Children.Add(inv);
        }

        private void btn_Arqueo_Click(object sender, RoutedEventArgs e)
        {
            btn_poly_decor_click(poly_Deco_Arqueo, btn_Arqueo);
            menuPrincipalArqueo arqueonuevo = new(codEmpleado);
            panel_Menu_Principal.Children.Clear();
            panel_Menu_Principal.Children.Add(arqueonuevo);
        }

        private void btn_Empleados_Click(object sender, RoutedEventArgs e)
        {
            btn_poly_decor_click(poly_Deco_Empleados, btn_Empleados);
            menuPrincipalEmpleados nuevoEmpleado = new();
            panel_Menu_Principal.Children.Clear();
            panel_Menu_Principal.Children.Add(nuevoEmpleado);
        }

        private void btn_Menu_Principal_LostFocus(object sender, RoutedEventArgs e)
        {
            Button Objeto_Boton = (((Button)sender));
            Objeto_Boton.Background = new SolidColorBrush(Color.FromRgb(13, 45, 111));
            btn_poly_decor_LostFocus();

        }

        private void btn_poly_decor_LostFocus()
        {
            poly_Deco_Examenes.Fill = new SolidColorBrush(Colors.Transparent);
            poly_Deco_Examenes.Stroke = new SolidColorBrush(Colors.Transparent);

            poly_Deco_Arqueo.Fill = new SolidColorBrush(Colors.Transparent);
            poly_Deco_Arqueo.Stroke = new SolidColorBrush(Colors.Transparent);
            
            poly_Deco_Configuracion.Fill = new SolidColorBrush(Colors.Transparent);
            poly_Deco_Configuracion.Stroke = new SolidColorBrush(Colors.Transparent);
            
            poly_Deco_Empleados.Fill = new SolidColorBrush(Colors.Transparent);
            poly_Deco_Empleados.Stroke = new SolidColorBrush(Colors.Transparent);
            
            poly_Deco_Informes.Fill = new SolidColorBrush(Colors.Transparent);
            poly_Deco_Informes.Stroke = new SolidColorBrush(Colors.Transparent);

            poly_Deco_Pacientes.Fill = new SolidColorBrush(Colors.Transparent);
            poly_Deco_Pacientes.Stroke = new SolidColorBrush(Colors.Transparent);
            
            poly_Deco_Inventario.Fill = new SolidColorBrush(Colors.Transparent);
            poly_Deco_Inventario.Stroke = new SolidColorBrush(Colors.Transparent);

        }
        // funcion para poner estilos a los botones 
        private void btn_poly_decor_click(Polygon poligon, Button button)
        {
            button.Background = new SolidColorBrush(Color.FromRgb(255, 84, 84));
            poligon.Fill = new SolidColorBrush(Colors.White);
            poligon.Stroke = new SolidColorBrush(Colors.White);

        }

        private void btn_Cerrar_Sesion_Click(object sender, RoutedEventArgs e)
        {

            Login nuevoLogin = new();
            this.Close();
            nuevoLogin.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConexionBaseDeDatos.ObtenerConexion();
                MessageBox.Show("Conexion establecida correctamente");
            }
            catch
            {
                MessageBox.Show("Error al conectar a sql");
            }
            
        }

    }
}
