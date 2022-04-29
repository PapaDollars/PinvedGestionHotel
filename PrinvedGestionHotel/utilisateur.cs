using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinvedGestionHotel
{
    public partial class utilisateur : Form
    {
        public utilisateur()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void quitter_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
