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

namespace Clinica_medica_polanco
{
    /// <summary>
    /// Lógica de interacción para menuPrincipalGestionarInsumos.xaml
    /// </summary>
    public partial class menuPrincipalGestionarInsumos : Window
    {
        public menuPrincipalGestionarInsumos()
        {
            InitializeComponent();
        }


        private void btn_Agregar_Producto_Click(object sender, RoutedEventArgs e)
        {
            btn_poly_decor_click(poly_Deco_Agregar_Producto, btn_Agregar_Producto);
        }

        private void btn_Eliminar_Producto_Click(object sender, RoutedEventArgs e)
        {
            btn_poly_decor_click(poly_Deco_Eliminar_Producto, btn_Eliminar_Producto);
        }

        private void btn_Consultar_Stock_Click(object sender, RoutedEventArgs e)
        {
            btn_poly_decor_click(poly_Deco_Consultar_Stock, btn_Consultar_Stock);
        }

        private void btn_Actualizar_Producto_Click(object sender, RoutedEventArgs e)
        {
            btn_poly_decor_click(poly_Deco_Actualizar_Producto, btn_Actualizar_Producto);
        }

        private void btn_Menu_Principal_Insumos_LostFocus(object sender, RoutedEventArgs e)
        {
            Button Objeto_Boton = (((Button)sender));
            Objeto_Boton.Background = new SolidColorBrush(Color.FromRgb(13, 45, 111));
            btn_poly_decor_LostFocus();

        }

        private void btn_poly_decor_LostFocus()
        {
            poly_Deco_Actualizar_Producto.Fill = new SolidColorBrush(Colors.Transparent);
            poly_Deco_Actualizar_Producto.Stroke = new SolidColorBrush(Colors.Transparent);

            poly_Deco_Agregar_Producto.Fill = new SolidColorBrush(Colors.Transparent);
            poly_Deco_Agregar_Producto.Stroke = new SolidColorBrush(Colors.Transparent);

            poly_Deco_Consultar_Stock.Fill = new SolidColorBrush(Colors.Transparent);
            poly_Deco_Consultar_Stock.Stroke = new SolidColorBrush(Colors.Transparent);

            poly_Deco_Eliminar_Producto.Fill = new SolidColorBrush(Colors.Transparent);
            poly_Deco_Eliminar_Producto.Stroke = new SolidColorBrush(Colors.Transparent);
        }

        private void btn_poly_decor_click(Polygon poligon, Button button)
        {
            button.Background = new SolidColorBrush(Color.FromRgb(255, 84, 84));
            poligon.Fill = new SolidColorBrush(Colors.White);
            poligon.Stroke = new SolidColorBrush(Colors.White);

        }

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
