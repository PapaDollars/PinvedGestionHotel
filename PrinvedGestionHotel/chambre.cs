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
    public partial class chambre : Form
    {
        public chambre()
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
                string requete = "select * from chambre";
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void quitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //grid view chambre

            if (view.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                view.CurrentRow.Selected = true;

                numerochambre.Text = view.Rows[e.RowIndex].Cells[0].Value.ToString();
                telephonechambre.Text = view.Rows[e.RowIndex].Cells[1].Value.ToString();
                numcategorie.Text = view.Rows[e.RowIndex].Cells[2].Value.ToString();
                niveau.Text = view.Rows[e.RowIndex].Cells[3].Value.ToString();
                statutchambre.Text = view.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            categories objects = new categories();
            objects.Show();
            this.Hide();
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

        private void label4_Click(object sender, EventArgs e)
        {
            reservation objects = new reservation();
            objects.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            client objects = new client();
            objects.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void quitter_Click_1(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            chambre objects = new chambre();
            objects.Show();
            this.Hide();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quitter_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        { 
            //Annuler Chambre

            numerochambre.Text = " ";
            numcategorie.Text = " ";
            telephonechambre.Text = " ";
            niveau.Text = " ";
            statutchambre.Text = " ";
            numerochambre.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Enregistrer Chambre

            String numcham = numerochambre.Text;
            String nomcham = numcategorie.Text;
            String phonecham = telephonechambre.Text;
            String ni = niveau.Text;
            String statcham = statutchambre.Text;

            if (numcham != "" & nomcham != "" & phonecham != "" & ni != "" & statcham != "")
            {
                if (statcham == "Occuper" | statcham == "Libre" )
                {

                    try
                    {
                        MySqlConnection connexion = new MySqlConnection("database=prinvedreservationhotel ; server=localhost ; user id=root ; pwd=");
                        connexion.Open();
                        // La commande Insert.
                        String sql = "insert into chambre (NUMEROCHAMBRE, NUMERORESERV, TELEPHONECHAMBRE, NIVEAU, STATUT) "
                                                         + " values (@numcham, @numcategorie, @phonecham, @ni, @statcham) ";

                        MySqlCommand cmd = connexion.CreateCommand();
                        cmd.CommandText = sql;

                        cmd.CommandText = "INSERT INTO chambre (NUMEROCHAMBRE, NUMERORESERV, TELEPHONECHAMBRE, NIVEAU, STATUT) "
                                                         + " values (@numcham, @numcategorie, @phonecham, @ni, @statcham) ";

                        cmd.Parameters.AddWithValue("@NUMEROCHAMBRE", numerochambre.Text);
                        cmd.Parameters.AddWithValue("@NUMERORESERV", numcategorie.Text);
                        cmd.Parameters.AddWithValue("@TELEPHONECHAMBRE", telephonechambre.Text);
                        cmd.Parameters.AddWithValue("@NIVEAU", niveau.Text);
                        cmd.Parameters.AddWithValue("@STATUT", statutchambre.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("REUSSI ! ");

                        connexion.Close();

                        numerochambre.Focus();
                    }
                    catch
                    {
                        MessageBox.Show(" Echec De Connexion. ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else { MessageBox.Show("Statut Non Sélectionner ! "); }

            }
            else { MessageBox.Show(" Erreur(s) Champ(s) Vide(s) ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Modifier chambre

            if (numerochambre.Text == "" | numcategorie.Text == "" | telephonechambre.Text == "" | niveau.Text == "" | statutchambre.Text == "") { MessageBox.Show(" Impossible de modifier. il y'a Un(des) Champ(s) Vide(s). ", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                try
                {
                    MySqlConnection connexion = new MySqlConnection("database=prinvedreservationhotel ; server=localhost ; user id=root ; pwd=");
                    connexion.Open();

                    MySqlCommand cmd = new MySqlCommand();//NUMEROCHAMBRE, NUMEROR TELEPHONECHAMBRE, NIVEAU, STATUT
                    cmd.Connection = connexion;
                    cmd.CommandText = String.Format("update chambre set NIVEAU='{0}', STATUT='{1}' where  NUMEROCHAMBRE='{2}' AND NUMERORESERV='{3}' AND TELEPHONECHAMBRE='{4}' ", niveau.Text, statutchambre.Text, numerochambre.Text, numcategorie.Text, telephonechambre.Text);
                    int r = cmd.ExecuteNonQuery();

                    if (r != 0)
                    {
                        MessageBox.Show("Chambre Bien Modifier ", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connexion.Close();
                    }
                    else { MessageBox.Show(" Rien n'a été Modifier "); }
                }
                catch
                {
                    MessageBox.Show(" La Modification à Echouer ", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //Supprimer Chambre

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

    

    }
}
