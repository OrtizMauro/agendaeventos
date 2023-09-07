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
    public partial class Editar : Form
    {
        public Editar()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=agendaeventos;";
            string query = "";

            if (txtNombreMod.Text != "")
            {
                query = "UPDATE eventos SET NOMBRE = '" + txtNombreMod.Text + "' WHERE N_EVENT = " + txtEventoMod.Text;
            }
            if (txtFechaMod.Text != "")
            {
                query = "UPDATE eventos SET FECHA = '" +txtFechaMod.Text+ "' WHERE N_EVENT = " + txtEventoMod.Text;
            }
            if (txtPersonasMod.Text != "")
            {
                query = "UPDATE eventos SET CANT_PER = '" +txtPersonasMod.Text+ "' WHERE N_EVENT = " + txtEventoMod.Text;
            }
            if (txtPrecioMod.Text != "") 
            {
                query = "UPDATE eventos SET PRECIO = '" + txtPrecioMod.Text+ "' WHERE N_EVENT = " + txtEventoMod.Text;
            }
            if (txtDesMod.Text != "")
            {
                query = "UPDATE eventos SET DESCRIPCIÓN = '" + txtDesMod.Text + "' WHERE N_EVENT = " + txtEventoMod.Text;
            }
            if (txtNroMod.Text != "")
            {
                query = "UPDATE eventos SET NRO_CONTACTO = '" + txtNroMod.Text + "' WHERE N_EVENT = " + txtEventoMod.Text;
            }

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

        private void btnConfirF_Click(object sender, EventArgs e)
        {
            DateTime fecha = monthCalendar1.SelectionStart;
            string formato = "yyyy-MM-dd HH mm";
            txtFechaMod.Text = fecha.ToString(formato);
        }

        private void Editar_Load(object sender, EventArgs e)
        {

        }
    }
}