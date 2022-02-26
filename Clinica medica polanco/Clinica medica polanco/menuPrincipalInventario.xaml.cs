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

namespace Clinica_medica_polanco
{
    /// <summary>
    /// Lógica de interacción para menuPrincipal_Inventario.xaml
    /// </summary>
    public partial class menuPrincipalInventario : UserControl
    {
        public menuPrincipalInventario()
        {
            InitializeComponent();
        }

        private void btn_Gestionar_Insumos_Click(object sender, RoutedEventArgs e)
        {
            menuPrincipalGestionarInsumos gestion = new();
            gestion.ShowDialog();
        }

        private void btn_Gestionar_Proveedores_Click(object sender, RoutedEventArgs e)
        {
            menuPrincipalGestionarProveedores gestion = new();
            gestion.ShowDialog();
        }

        private void btn_Ver_Ventas_Click(object sender, RoutedEventArgs e)
        {
            ventasRealizadas nuevaventa = new();
            nuevaventa.ShowDialog();
        }
    }
}
