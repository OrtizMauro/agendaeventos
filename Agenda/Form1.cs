using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Agenda
{
    public partial class Form1 : Form
    {
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=agendaeventos;";
        static string query = "SELECT * FROM eventos";

        
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("nro eventos", "NRO DE EVENTOS");
            dataGridView1.Columns.Add("nombre", "NOMBRE");
            dataGridView1.Columns.Add("fecha", "FECHA");
            dataGridView1.Columns.Add("cant Per", "CANT PER");
            dataGridView1.Columns.Add("precio", "PRECIO");
            dataGridView1.Columns.Add("nro contacto", "NRO CONTACTO");
            dataGridView1.Columns.Add("descripcion", "DESCRIPCIÓN");
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void prepararConexion()
        {
            
        }

        private void Conectar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();

                MySqlDataReader reader = commandDatabase.ExecuteReader();
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                    }
                }

                databaseConnection.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            Agregar agregar = new Agregar();
            agregar.Show();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            Eliminar eliminar = new Eliminar();
            eliminar.Show();
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            Editar editar = new Editar();
            editar.Show(); 
        }

        private void btnEventos_Click(object sender, EventArgs e)
        {
            Eventos eventos = new Eventos();
            eventos.Show();
        }

        private void btnCuenta_Click(object sender, EventArgs e)
        {
            Cuenta cuenta = new Cuenta();    
            cuenta.Show();
        }
    }
}
