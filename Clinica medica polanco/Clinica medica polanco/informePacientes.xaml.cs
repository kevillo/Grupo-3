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
    /// Lógica de interacción para informePacientes.xaml
    /// </summary>
    public partial class informePacientes : Window
    {
        public informePacientes()
        {
            InitializeComponent();
        }

        private void btn_Informe_Pacientes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
