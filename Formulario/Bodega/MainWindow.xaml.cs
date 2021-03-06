using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            cargarObjetivos();
            cargarOperacion();
            cargarEquipo();
        }
        
        public MySqlConnection conexion()
        {
            // Usamos la ruta de conexíon que se nos adapte mejor 
                //Nos funciona a Silvia y a mi
            //string connectionString = "datasource=127.0.0.1;port=3306;username=root;database=bodega;";
                //Le funciona a Antonio
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=1234;database=bodega;";

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
            txtFecha.Text = DateTime.Now.ToString("dd-MM-yyyy  -   HH:mm:ss");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void getImageBlob(String from, int index)
        {
            db = conexion();
            string query = "select imagen from " + from + " where id_" + from + " = " + index;
            db.Open();
            MySqlCommand commandDatabase = new MySqlCommand(query, db);


            // Leemos el resultado de la consulta 
            MySqlDataReader reader = commandDatabase.ExecuteReader();

            if (reader.Read())
            {
                try
                {
                    byte[] imagenByte = (byte[])reader["imagen"];
                    MemoryStream ms = new MemoryStream(imagenByte);
                    BitmapImage imageSource = new BitmapImage();
                    imageSource.BeginInit();
                    imageSource.StreamSource = ms;
                    imageSource.EndInit();

                    // Le asigna al control Image la imagen recuperada
                    if (String.Equals(from, "localizacion"))
                    {
                        localizacionimg.Source = imageSource;
                    }
                    else
                    {
                        equipoimg.Source = imageSource;
                    }
                }
                catch (System.InvalidCastException e)
                {
                    if (String.Equals(from, "localizacion"))
                    {
                        localizacionimg.Source = null;
                    }
                    else
                    {
                        equipoimg.Source = null;
                    }
                }

            }
        }
        private void cargarGrupos()
        {
            try
            {
                // Creamos una conexion con la base de datos y realizamos una consulta
                db=conexion();
                string query = "select id_grupo, nombre from grupo";
                
                db.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, db);

                // Leemos el resultado de la consulta 
                MySqlDataReader reader = commandDatabase.ExecuteReader();
                cmbGrupo.Items.Add("Seleccionar uno..."); // El campo por defecto

                // Annadimos los datos obtenidos en el comboBox
                while (reader.Read())
                {
                    cmbGrupo.Items.Add(reader.GetString("nombre"));
                    //cmbGrupo.SelectedValue = "id_grupo";
                }
                cmbGrupo.SelectedIndex = 0;

                // Cerramos la conexion con la base de datos 
                db.Close();
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
                cmbLocalizacion.Items.Add("Seleccionar uno...");
                while (reader.Read())
                {
                    cmbLocalizacion.Items.Add(reader.GetString("nombre"));
                    cmbLocalizacion.SelectedValue = "id_localizacion";
                }
        
                cmbLocalizacion.SelectedIndex = 0;
                db.Close();
            }
            catch (Exception ex)
            {
            }
        }
        private void cargarObjetivos()
        {
            try
            {
                db = conexion();
                string query = "select id_objetivo, nombre from objetivo";

                db.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, db);
                MySqlDataReader reader = commandDatabase.ExecuteReader();
                cmbObjetivo.Items.Add("Seleccionar uno...");
                while (reader.Read())
                {
                    cmbObjetivo.Items.Add(reader.GetString("nombre"));
                    cmbObjetivo.SelectedValue = "id_objetivo";
                }
                cmbObjetivo.SelectedIndex = 0;
                db.Close();
            }
            catch (Exception ex)
            {
            }
        }

        public void cargarOperacion()
        {
            try
            {
                db = conexion();
                string query = "select id_operacion, nombre from operacion";

                db.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, db);
                MySqlDataReader reader = commandDatabase.ExecuteReader();
                cmbOperacion.Items.Add("Seleccionar uno...");
                while (reader.Read())
                {
                    cmbOperacion.Items.Add(reader.GetString("nombre"));
                    cmbOperacion.SelectedValue = "id_operacion";
                }
                cmbOperacion.SelectedIndex = 0;
                db.Close();
            }
            catch (Exception ex)
            {
            }
        }

        public void cargarEquipo()
        {
            try
            {
                db = conexion();
                string query = "select id_equipo, nombre from equipo";

                db.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, db);
                MySqlDataReader reader = commandDatabase.ExecuteReader();
                cmbEquipo.Items.Add("Seleccionar uno...");
                while (reader.Read())
                {
                    cmbEquipo.Items.Add(reader.GetString("nombre"));
                    //cmbEquipo.SelectedValue = "id_equipo";
                }

                cmbEquipo.SelectedIndex = 0;
                db.Close();
            }
            catch (Exception ex)
            {
            }
        }

        public void insertRegistro()
        {
            // Annadimos en una tabla nueva Registro, los resultados obtenidos 
            db = conexion();
            string query = "INSERT INTO registro(fecha_hora, id_grupo, id_localizacion,id_objetivo,id_operacion,id_equipo) VALUES( '" + txtFecha.Text + "' , " + cmbGrupo.SelectedIndex + " , " + cmbLocalizacion.SelectedIndex + " , " + cmbObjetivo.SelectedIndex + " , " + cmbOperacion.SelectedIndex + " , " + cmbEquipo.SelectedIndex +")";
            db.Open();
            MySqlCommand commandDatabase = new MySqlCommand(query,db);
            commandDatabase.ExecuteNonQuery();
            db.Close();
        }

        private void cmbGrupo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            // Comprobamos los resultados obtenidos 

            if (cmbGrupo.SelectedIndex == 0 || cmbLocalizacion.SelectedIndex == 0 || cmbObjetivo.SelectedIndex == 0 || cmbOperacion.SelectedIndex == 0 || cmbEquipo.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor rellene todos los campos");
            }
            else
            {
                MessageBox.Show("Registro introducido exitosamente");

                insertRegistro();
                
            }
        }

        private void cmbLocalizacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indiceactual = (int)cmbLocalizacion.SelectedIndex;
            getImageBlob("localizacion", indiceactual);
        }

        private void cmbEquipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indiceactual = (int)cmbEquipo.SelectedIndex;
            getImageBlob("equipo", indiceactual);
        }
    }
}
