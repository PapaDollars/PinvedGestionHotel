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

namespace PrinvedGestionHotel
{
    public partial class client : Form
    {
        public client()
        {
            InitializeComponent();
            generates();
        }

        public void generates()
        {
            MySqlConnection connexion = new MySqlConnection("database=prinvedreservationhotel ; server=localhost ; user id=root ; pwd=");
            connexion.Open();
            try
            {
                string requete = "select * from clients";
                MySqlCommand cmmd = new MySqlCommand(requete, connexion);
                MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                view.DataSource = dt;

                connexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void quitter_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //grid view client

            if (view.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                view.CurrentRow.Selected = true;

                cni.Text = view.Rows[e.RowIndex].Cells[0].Value.ToString();
                nomclient.Text = view.Rows[e.RowIndex].Cells[1].Value.ToString();
                prenomclient.Text = view.Rows[e.RowIndex].Cells[2].Value.ToString();
                genre.Text = view.Rows[e.RowIndex].Cells[3].Value.ToString();
                telephoneclient.Text = view.Rows[e.RowIndex].Cells[4].Value.ToString();
                email.Text = view.Rows[e.RowIndex].Cells[5].Value.ToString();
                statutR.Text = view.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Enregistrer un client
        }

        private void label1_Click(object sender, EventArgs e)
        {
            chambre objects = new chambre();
            objects.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            categories objects = new categories();
            objects.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            client objects = new client();
            objects.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            reservation objects = new reservation();
            objects.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            tableau objects = new tableau();
            objects.Show();
            this.Hide();
        }
    }
}
