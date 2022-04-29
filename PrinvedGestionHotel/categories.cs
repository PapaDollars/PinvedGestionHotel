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
    public partial class categories : Form
    {
        public categories()
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
                string requete = "select * from categories";
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

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //grid view categorie

            if (view.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                view.CurrentRow.Selected = true;

                numerocategorie.Text = view.Rows[e.RowIndex].Cells[0].Value.ToString();
                numchambre.Text = view.Rows[e.RowIndex].Cells[1].Value.ToString();
                nomcategorie.Text = view.Rows[e.RowIndex].Cells[2].Value.ToString();
                prix.Text = view.Rows[e.RowIndex].Cells[3].Value.ToString();
                description.Text = view.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Modifier categorie

            String num = numerocategorie.Text;
            String numcham = numchambre.Text;
            String nom = nomcategorie.Text;
            String pr = prix.Text;
            String desc = description.Text;

            if (num == "" | numcham =="" | nom == "" | pr == "" | desc == "") { MessageBox.Show(" Impossible de modifier. il y'a Un(des) Champ(s) Vide(s). ", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                try
                {
                    MySqlConnection connexion = new MySqlConnection("database=prinvedreservationhotel ; server=localhost ; user id=root ; pwd=");
                    connexion.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connexion;//NumeroCategorie, NomCategorie, Prix, Description
                    cmd.CommandText = String.Format("update categories set NOMCATEGORIE='{0}',PRIX='{1}',DESCRIPTION='{2}' where  NUMEROCATEGORIE='{3}' AND NUMEROCHAMBRE ", nomcategorie.Text, prix.Text, description.Text, numerocategorie.Text, numchambre.Text);
                    int r = cmd.ExecuteNonQuery();

                    if (r != 0)
                    {
                        connexion.Close();
                        MessageBox.Show("Catégorie Modifié", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else { MessageBox.Show("Non Modifier"); }
                }
                catch
                {
                    MessageBox.Show(" Echec de Modifier ", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Annuler categorie
            numerocategorie.Text = " ";
            numchambre.Text =" ";
            nomcategorie.Text = " ";
            prix.Text =" ";
            description.Text= " ";
            numerocategorie.Focus();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Enregistrer categorie

            String num = numerocategorie.Text;
            String numcham = numchambre.Text;
            String nom = nomcategorie.Text;
            String pr = prix.Text;
            String desc = description.Text;

            if (num != "" | numcham != "" | nom != "" | pr != "" | desc != "")
            {

                try
                {
                    MySqlConnection connexion = new MySqlConnection("database=prinvedreservationhotel ; server=localhost ; user id=root ; pwd=");
                    connexion.Open();
                    // La commande Insert. //NOMCATEGORIE='{0}',PRIX='{1}',DESCRIPTION='{2}' where  NUMEROCATEGORIE='{3}' AND NUMEROCHAMBRE
                    String sql = "insert into categories (NUMEROCATEGORIE, NUMEROCHAMBRE, NOMCATEGORIE, PRIX, DESCRIPTION) "
                                                        + " values (@num, @numcham, @nom, @pr, @desc) ";

                    MySqlCommand cmd = connexion.CreateCommand();
                    cmd.CommandText = sql;

                    cmd.CommandText = "INSERT INTO categories (NUMEROCATEGORIE, NUMEROCHAMBRE, NOMCATEGORIE, PRIX, DESCRIPTION) "
                                                        + " values (@num, @numcham, @nom, @pr, @desc) ";

                    cmd.Parameters.AddWithValue("@NUMEROCATEGORIE", numerocategorie.Text);
                    cmd.Parameters.AddWithValue("@NUMEROCHAMBRE", numchambre.Text);
                    cmd.Parameters.AddWithValue("@NOMCATEGORIE", nomcategorie.Text);
                    cmd.Parameters.AddWithValue("@PRIX", prix.Text);
                    cmd.Parameters.AddWithValue("@DESCRIPTION", description.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Catégorie Ajouter avec Succès ! ");

                    connexion.Close();

                    numerocategorie.Focus();
                }
                catch
                {
                    MessageBox.Show(" Echec De Connexion. ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else { MessageBox.Show(" Erreur(s) Champ(s) Vide(s) ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //supprimer categorie

            String num = numerocategorie.Text;
            String numcham = numchambre.Text;
            String nom = nomcategorie.Text;
            String pr = prix.Text;
            String desc = description.Text;

            if (num == "" | numcham == "" | nom == "" | pr == "" | desc == "") { MessageBox.Show(" Impossible de Supprimer. il y'a Un(des) Champ(s) Vide(s). ", "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                try
                {
                    MySqlConnection connexion = new MySqlConnection("database=prinvedreservationhotel ; server=localhost ; user id=root ; pwd=");
                    connexion.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connexion;
                    cmd.CommandText = String.Format("delete from categories where NUMEROCATEGORIE='{0}'", numerocategorie.Text);

                    int r = cmd.ExecuteNonQuery();
                    if (r != 0)
                    {
                        MessageBox.Show("Catégorie Supprimé avec Succès", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        numerocategorie.Text = " ";
                        numchambre.Text = " ";
                        nomcategorie.Text = " ";
                        prix.Text = " ";
                        description.Text = " ";
                        numerocategorie.Focus();

                        connexion.Close();
                    }
                    else { MessageBox.Show("Non Supprimer"); }

                }
                catch
                {
                    MessageBox.Show(" Echec de Suppression. ", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            categories objects = new categories();
            objects.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            chambre objects = new chambre();
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
