using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Threading;

namespace Bodega
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection db;
        public MainWindow()
        {
            InitializeComponent();
            cargarGrupos();
            cargaHoraActual();
            cargarLocalizaciones();
        }

        public MySqlConnection conexion()
        {
            //Nos funciona a Silvia y a mi
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;database=bodega;";
            //Le funciona a Antonio
            //string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=1234;database=bodega;";
            // Tu consulta en SQL
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            return databaseConnection;
        }
        public void cargaHoraActual()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += timer_tick;
            timer.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void cargarGrupos()
        {
            try
            {
                db=conexion();
                string query = "select id_grupo, nombre from grupo";
                
                db.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, db);
                MySqlDataReader reader = commandDatabase.ExecuteReader();

                while (reader.Read())
                {
                    cmbGrupo.Items.Add(reader.GetString("nombre"));
                    //cmbGrupo.SelectedValue = "id_grupo";
                }            
            }
            catch (Exception ex)
            {
            }
        }
        private void cargarLocalizaciones()
        {
            try
            {
                db = conexion();
                string query = "select id_localizacion, nombre from localizacion";

                db.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, db);
                MySqlDataReader reader = commandDatabase.ExecuteReader();

                while (reader.Read())
                {
                    cmbLocalizacion.Items.Add(reader.GetString("nombre"));
                    cmbLocalizacion.SelectedValue = "id_localizacion";
                }
            }
            catch (Exception ex)
            {
            }
        }



        public void insertRegistro()
        {
            string query = "INSERT INTO registro(id_registro, fecha_hora, id_grupo, id_localizacion, id_objetivo, id_operacion, id_equipo) " +
               "VALUES(" + cmbGrupo.SelectedValue.ToString() + ", ? address)";
            //" + id + ",'" + txtTitulo.Text + "','" + txtCategoria.Text + "','" + dtpFecha.Value + "','" + txtDescripcion.Text + "','" + txtUrl.Text + "','" + txtCodigo.Text + "') "

        }

        private void cmbGrupo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("valor grupo",cmbGrupo.SelectedIndex.ToString());
            MessageBox.Show("valor localizacion", cmbLocalizacion.SelectedItem.ToString());
        }
    }
}
