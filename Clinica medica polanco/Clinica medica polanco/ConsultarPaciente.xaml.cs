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

namespace Clinica_medica_polanco
{
    /// <summary>
    /// Lógica de interacción para ConsultarPaciente.xaml
    /// </summary>
    public partial class ConsultarPaciente : Window
    {
        public ConsultarPaciente()
        {
            InitializeComponent();
        }

        private void btn_Consultar_Pacientes_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
