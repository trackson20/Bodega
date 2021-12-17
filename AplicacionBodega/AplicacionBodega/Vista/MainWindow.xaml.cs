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

namespace AplicacionBodega
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Acciones_BotonPulsado(object sender, Vista.VistaAcciones.BotonPulsadoArgs e)
        {
            MessageBox.Show("has pulsado en " + e.Accion);
            if (e.Accion.Equals("Registro"))
            {
                MessageBox.Show("registro");
            }
            else if (e.Accion.Equals("Configuracion"))
            {
                MessageBox.Show("config");
            }
        }
    }
}
