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
    public partial class tableau : Form
    {
        public tableau()
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
                string requete = "select CNI, NOMCLIENT, PRENOMCLIENT, GENRE, TELEPHONECLIENT, EMAIL, STATUTCLIENT, NUMEROR, DATEDEBUT, DATEFIN from clients,reservation";
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
            this.Close();
        }

        private void quitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // grid view tableau de bord
        }

        private void statuttableau_SelectedIndexChanged(object sender, EventArgs e)
        {
            //recherche par statut

            String recherchestatut = statuttableau.Text.ToString();
            search(recherchestatut);
        }

        public void search(String recherchestatut)
        {
            try
            {
                MySqlConnection connexion = new MySqlConnection("database=prinvedreservationhotel ; server=localhost ; user id=root ; pwd=");
                connexion.Open();

                String recherche = "select CNI, NOMCLIENT, PRENOMCLIENT, GENRE, TELEPHONECLIENT, EMAIL, STATUTCLIENT, NUMEROR, DATEDEBUT, DATEFIN from clients,reservation where STATUTCLIENT Like '%" + recherchestatut + "%'";

                MySqlCommand cmmd = new MySqlCommand(recherche, connexion);
                MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                view.DataSource = dt;

                connexion.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message + "  Entrez un ''Statut'' Valide.  ", "Statut", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void cnitableau_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        public void rechercherCNI(String recherchecni)
        {
            try
            {
                MySqlConnection connexion = new MySqlConnection("database=prinvedreservationhotel ; server=localhost ; user id=root ; pwd=");
                connexion.Open();

                String recherche = "select CNI, NOMCLIENT, PRENOMCLIENT, GENRE, TELEPHONECLIENT, EMAIL, STATUTCLIENT, NUMEROR, DATEDEBUT, DATEFIN from clients,reservation where CNI Like '%" + recherchecni + "%'";

                MySqlCommand cmmd = new MySqlCommand(recherche, connexion);
                MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                view.DataSource = dt;

                connexion.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message + "  Entrez un ''CNI'' Valide.  ", "Statut", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //recherche cni

            String recherchecni = cnitableau.Text.ToString();
            rechercherCNI(recherchecni);
        }

        public void rechercheType(String recherchetype)
        {
            try
            {
                MySqlConnection connexion = new MySqlConnection("database=prinvedreservationhotel ; server=localhost ; user id=root ; pwd=");
                connexion.Open();

                String recherche = "select CNI, NOMCLIENT, PRENOMCLIENT, GENRE, TELEPHONECLIENT, EMAIL, STATUTCLIENT, NUMEROR, DATEDEBUT, DATEFIN from clients,reservation where NUMEROR Like '%" + recherchetype + "%'";

                MySqlCommand cmmd = new MySqlCommand(recherche, connexion);
                MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                view.DataSource = dt;

                connexion.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message + "  Entrez un ''Type de Chambre'' Valide.  ", "Statut", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void typechambre_SelectedIndexChanged(object sender, EventArgs e)
        {
            String recherchetype = typechambre.Text.ToString();
            rechercheType(recherchetype);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //actualiser

            MySqlConnection connexion = new MySqlConnection("database=prinvedreservationhotel ; server=localhost ; user id=root ; pwd=");
            connexion.Open();
            try
            {
                string requete = "select CNI, NOMCLIENT, PRENOMCLIENT, GENRE, TELEPHONECLIENT, EMAIL, STATUTCLIENT, NUMEROR, DATEDEBUT, DATEFIN from clients,reservation";
                MySqlCommand cmmd = new MySqlCommand(requete, connexion);
                MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                view.DataSource = dt;

                connexion.Close();
            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.Message);
            }
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
