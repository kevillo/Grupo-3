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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para agregarProducto.xaml
    /// </summary>
    public partial class agregarProducto : UserControl
    {
        public agregarProducto()
        {
            InitializeComponent();
        }

        private void btn_Proveedor_Olvidado_Click(object sender, RoutedEventArgs e)
        {
            menuPrincipalGestionarProveedores nuevoProveedor = new();
            nuevoProveedor.ShowDialog();
        }

        private void btn_Agregar_Producto_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Producto agregado correctamente");
        }
    }
}
