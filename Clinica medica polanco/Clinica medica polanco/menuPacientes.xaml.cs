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
    /// Lógica de interacción para menuPacientes.xaml
    /// </summary>
    public partial class menuPacientes : UserControl
    {
        public menuPacientes()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            agregarPaciente nuevoPaciente = new();
         
            nuevoPaciente.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            borrarPaciente borrar = new();
            borrar.ShowDialog();
        }
    }
}
