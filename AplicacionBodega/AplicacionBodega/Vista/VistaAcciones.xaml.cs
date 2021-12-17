using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplicacionBodega.Vista
{
    /// <summary>
    /// Lógica de interacción para VistaAcciones.xaml
    /// </summary>
    public partial class VistaAcciones : UserControl
    {
        //Función delegada
        public delegate void BotonPulsado(object sender, BotonPulsadoArgs e);
        //Definimos el evento
        public event BotonPulsado botonPulsado;
        public VistaAcciones()
        {
            InitializeComponent();
        }

        public class BotonPulsadoArgs : EventArgs
        {
            public string Accion { get; set; }

            public BotonPulsadoArgs(string accion)
            {
                Accion = accion;
            }
        }

        private void btnAnnadir_Click(object sender, RoutedEventArgs e)
        {
            BotonPulsadoArgs args = new BotonPulsadoArgs("Añadir");
            botonPulsado(this, args);
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            BotonPulsadoArgs args = new BotonPulsadoArgs("Modificar");
            botonPulsado(this, args);
        }

        private void btnRegistro_Click(object sender, RoutedEventArgs e)
        {
            BotonPulsadoArgs args = new BotonPulsadoArgs("Registro");
            botonPulsado(this, args);
        }
    }
}
