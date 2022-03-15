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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clinica_Medica_Polanco
{
    /// <summary>
    /// Lógica de interacción para menuPrincipal_Inventario.xaml
    /// </summary>
    public partial class menuPrincipalInventario : UserControl
    {
        int empleado = 0;
        public menuPrincipalInventario(int codEmpleado)
        {
            empleado = codEmpleado;
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

        private void btn_Ver_Compras_Click(object sender, RoutedEventArgs e)
        {
            consultaComprasRealizadas consultaCompras = new(empleado);
            consultaCompras.ShowDialog();
        }

        private void btn_Actualizar_Stock_Click(object sender, RoutedEventArgs e)
        {
            actualizarStock compras = new(empleado);
            compras.ShowDialog();
        }

        private void btn_Ver_Ventas_Click(object sender, RoutedEventArgs e)
        {
            ventasRealizadas ventas = new(empleado);
            ventas.ShowDialog();
        }
    }
}
