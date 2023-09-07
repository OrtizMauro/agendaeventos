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
    public partial class Agregar : Form
    {
        public Agregar()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void txtConfirmar_Click(object sender, EventArgs e)
        {
            DateTime fecha = monthCalendar1.SelectionStart;
            string formato = "yyyy-MM-dd HH mm";
            txtFecha.Text = fecha.ToString(formato);   

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=agendaeventos;";
            string query = "INSERT INTO eventos (NOMBRE, FECHA, CANT_PER, PRECIO, NRO_CONTACTO, DESCRIPCIÓN) VALUES ('"+txtNombre.Text+ "', '"+txtFecha.Text+ "' , '"+txtPersonas.Text+"','"+txtPrecio.Text+ "', '"+txtNro.Text+"', '" + txtDes.Text+"')";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();

                MySqlDataReader reader = commandDatabase.ExecuteReader();

               
                databaseConnection.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            this.Close();   
        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            calendario calendario = new calendario();
            calendario.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
