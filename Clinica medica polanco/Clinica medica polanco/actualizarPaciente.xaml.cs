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

namespace Clinica_medica_polanco
{
    /// <summary>
    /// Lógica de interacción para actualizarD_Pacientes.xaml
    /// </summary>
    public partial class actualizarPaciente : Window
    {
        public actualizarPaciente()
        {
            InitializeComponent();
        }
    
        private void btn_Actualizar_Paciente_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
