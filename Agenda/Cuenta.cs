using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Agenda
{
    public partial class Cuenta : Form
    {
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=agenda_salon;";
        static string query = "SELECT SUM(PRECIO) FROM eventos";

        
        public Cuenta()
        {
            InitializeComponent();
            
            dataGridView1.Columns.Add("mes", "MES");
            dataGridView1.Columns.Add("precio", "PRECIO");
            
           



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
                        txtAcum.Text = "Acumulado: $" + (reader.GetString(0));
                    }
                }

                databaseConnection.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=agendaeventos;";
            string query = "SELECT SUM(PRECIO), MONTH(FECHA) FROM eventos GROUP BY MONTH(FECHA)";

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
                        
                        dataGridView1.Rows.Add(reader.GetString(1), reader.GetString(0));
                        
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









