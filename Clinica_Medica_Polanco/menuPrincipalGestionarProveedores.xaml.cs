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

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para menuPrincipalGestionarProveedores.xaml
    /// </summary>
    public partial class menuPrincipalGestionarProveedores : Window
    {
        public menuPrincipalGestionarProveedores()
        {
            InitializeComponent();
        }

        private void btn_Menu_Principal_Proveedores_LostFocus(object sender, RoutedEventArgs e)
        {
            Button Objeto_Boton = (((Button)sender));
            Objeto_Boton.Background = new SolidColorBrush(Color.FromRgb(13, 45, 111));
            btn_poly_decor_LostFocus();

        }

        private void btn_poly_decor_LostFocus()
        {
            poly_Deco_Actualizar_Proveedor.Fill = new SolidColorBrush(Colors.Transparent);
            poly_Deco_Actualizar_Proveedor.Stroke = new SolidColorBrush(Colors.Transparent);

            poly_Deco_Agregar_Proveedor.Fill = new SolidColorBrush(Colors.Transparent);
            poly_Deco_Agregar_Proveedor.Stroke = new SolidColorBrush(Colors.Transparent);

            poly_Deco_Consultar_Proveedor.Fill = new SolidColorBrush(Colors.Transparent);
            poly_Deco_Consultar_Proveedor.Stroke = new SolidColorBrush(Colors.Transparent);

            poly_Deco_Eliminar_Proveedor.Fill = new SolidColorBrush(Colors.Transparent);
            poly_Deco_Eliminar_Proveedor.Stroke = new SolidColorBrush(Colors.Transparent);
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


        private void btn_Agregar_Proveedor_Click(object sender, RoutedEventArgs e)
        {
            btn_poly_decor_click(poly_Deco_Agregar_Proveedor, btn_Agregar_Proveedor);
            agregarProveedor agregar = new();
            panel_Menu_Principal_Proveedores.Children.Clear();
            panel_Menu_Principal_Proveedores.Children.Add(agregar);
        }

        private void btn_Eliminar_Proveedor_Click(object sender, RoutedEventArgs e)
        {
            btn_poly_decor_click(poly_Deco_Eliminar_Proveedor, btn_Eliminar_Proveedor);
            eliminarProveedor eliminado = new();
            panel_Menu_Principal_Proveedores.Children.Clear();
            panel_Menu_Principal_Proveedores.Children.Add(eliminado);
        }


        private void btn_Consultar_Proveedor_Click(object sender, RoutedEventArgs e)
        {
            btn_poly_decor_click(poly_Deco_Consultar_Proveedor, btn_Consultar_Proveedor);
            consultarProveedor consultarProv = new();
            panel_Menu_Principal_Proveedores.Children.Clear();
            panel_Menu_Principal_Proveedores.Children.Add(consultarProv);
        }

        private void btn_Actualizar_Proveedor_Click(object sender, RoutedEventArgs e)
        {
            btn_poly_decor_click(poly_Deco_Actualizar_Proveedor, btn_Actualizar_Proveedor);
            actualizarProveedor actualizarProv = new();
            panel_Menu_Principal_Proveedores.Children.Clear();
            panel_Menu_Principal_Proveedores.Children.Add(actualizarProv);
        }
    }
}
