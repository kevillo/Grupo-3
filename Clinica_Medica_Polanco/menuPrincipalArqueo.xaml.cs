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
    /// Lógica de interacción para menuPrincipalArqueo.xaml
    /// </summary>
    public partial class menuPrincipalArqueo : UserControl
    {
        int codEmpleador = 0;
        public menuPrincipalArqueo(int cod)
        {
            codEmpleador = cod;
            InitializeComponent();
        }

      

        private void btn_Verificar_Monto_Click(object sender, RoutedEventArgs e)
        {
            int codArqueo = Arqueo.arqueoDAL.traerCodArqueo();
            decimal cantidad = Arqueo.arqueoDAL.traerMontoInicial(codArqueo+1);
            MessageBox.Show("Usted inicia con un monto de: "+ cantidad.ToString()+"\n\nSi el valor es negativo signfica que la anterior caja quedo con un saldo negativo\n\nSi el arqueo es 0 es por que no se hizo ni una venta o compra en el turno anterior");

        }

        private void btn_Realizar_Arqueo_Click(object sender, RoutedEventArgs e)
        {
            Arqueo.arqueoDAL.generarArqueo(codEmpleador);
            int codArqueo = Arqueo.arqueoDAL.traerCodArqueo();
            decimal cantidad = Arqueo.arqueoDAL.traerMontoInicial(codArqueo + 1);
            MessageBox.Show("El dinero en caja debe ser: " + cantidad.ToString());
        }
    }
}
