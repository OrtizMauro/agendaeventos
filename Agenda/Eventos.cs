using System;
using System.Collections;
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
    public partial class Eventos : Form
    {
        public Eventos()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("precio", "PRECIO");
            dataGridView1.Columns.Add("nombre", "NOMBRE");
            dataGridView1.Columns.Add("fecha", "FECHA");
            dataGridView1.Columns.Add("cant Per", "CANT PER");
            dataGridView1.Columns.Add("nro eventos", "NRO DE EVENTOS");
            dataGridView1.Columns.Add("nro contacto", "NRO DE CONTACTO");
            dataGridView1.Columns.Add("descripción", "DESCRIPCIÓN");
            
            string[] Meses = new string[13];
            Meses[0] = "SELECCIONA UN MES";
            Meses[1] = "Enero";
            Meses[2] = "Febrero";
            Meses[3] = "Marzo";
            Meses[4] = "Abril";
            Meses[5] = "Mayo";
            Meses[6] = "Junio";
            Meses[7] = "Julio";
            Meses[8] = "Agosto";
            Meses[9] = "Septiembre";
            Meses[10] = "Octubre";
            Meses[11] = "Noviembre";
            Meses[12] = "Diciembre";

            cboMes.Items.Clear();

            for (int i = 0; i <= 12; i++)

            cboMes.Items.Add(Meses[i]);

        }
            private void btnConsulta_Click(object sender, EventArgs e)
            {
            

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=agendaeventos;";
            string query = "SELECT * FROM eventos WHERE MONTH(FECHA) = "+ cboMes.SelectedIndex;
            
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
                        dataGridView1.Rows.Add(reader.GetString(4), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(0), reader.GetString(5), reader.GetString(6));
                        }
                    }

                    databaseConnection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }

            }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
               
        }

        private void Eventos_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string j = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=agenda_salon;";
            string query = "SELECT * FROM eventos WHERE N_EVENT = " + j;


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
                        richTextBox1.Text =  " El Día: " + reader.GetString(2) + " Evento de: " + reader.GetString(1) + " Por la suma: " + reader.GetString(4) +" Descripcion: " + reader.GetString(6);
                    }
                }

                databaseConnection.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string j = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=agenda_salon;";
            string query = "SELECT * FROM eventos WHERE N_EVENT = " + j;


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
                        richTextBox1.Text = " El Día: " + reader.GetString(2) + " Evento de: " + reader.GetString(1) + " Por la suma: $" + reader.GetString(4) + " Numero de contacto:  " + reader.GetString(5) + " Descripcion: " + reader.GetString(6);
                    }
                }
                

                databaseConnection.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bntNom_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=agenda_salon;";
            string query = "SELECT * FROM eventos WHERE NOMBRE = '"+txtNombre.Text+"'";

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
                        dataGridView1.Rows.Add(reader.GetString(4), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(0), reader.GetString(5), reader.GetString(6));
                    }
                }

                databaseConnection.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }

    }
}

