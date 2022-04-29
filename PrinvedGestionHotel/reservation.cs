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
    public partial class reservation : Form
    {
        public reservation()
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
                string requete = "select NUMEROR, CNI, NUMEROCHAMBRE, DATEDEBUT, DATEFIN from reservation,clients,chambre";
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

        private void label4_Click(object sender, EventArgs e)
        {
            reservation objects = new reservation();
            objects.Show();
            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //grid view reservation

            if (view.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                view.CurrentRow.Selected = true;

                numerore.Text = view.Rows[e.RowIndex].Cells[0].Value.ToString();
                numcham.Text = view.Rows[e.RowIndex].Cells[1].Value.ToString();
                cnir.Text = view.Rows[e.RowIndex].Cells[2].Value.ToString();
                datedebut.Text = view.Rows[e.RowIndex].Cells[3].Value.ToString();
                datefin.Text = view.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void quitter_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            client objects = new client();
            objects.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            tableau objects = new tableau();
            objects.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            chambre objects = new chambre();
            objects.Show();
            this.Hide();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            categories objects = new categories();
            objects.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void datedebut_ValueChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {
            //montant

            if ( Convert.ToInt32(datedebut.Text) > Convert.ToInt32(datefin.Text) )
            {
                montant.Text = "23";
            }
        }
    }
}
