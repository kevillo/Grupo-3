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
using Clinica_Medica_Polanco.Proveedores;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para actualizarProveedor.xaml
    /// </summary>
    public partial class actualizarProveedor : UserControl
    {
        public actualizarProveedor()
        {
            InitializeComponent();

            ProveedoresDAL.CargarAreaTrabajo(cmb_Area_Trabajo_Proveedor_Actualizar);
        }

        private void btn_Actualizar_Informacion_Proveedor_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Información actualizada correctamente");
        }
    }
}
