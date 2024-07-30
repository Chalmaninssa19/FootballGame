using football.objets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace football
{
    public partial class DebutJeu : Form
    {
        public DebutJeu()
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeMaCaisse();
        }
        public void InitializeComboBox()
        {
            List<V_gamerTeam> allGamer = V_gamerTeam.getAllV_gamerTeam();
            foreach (V_gamerTeam gamer in allGamer)
            {
                gamer1.Items.Add(gamer.IdGamer+"-"+gamer.Gamer+" "+gamer.Poche+" ariary");
                gamer2.Items.Add(gamer.IdGamer + "-" + gamer.Gamer + " " + gamer.Poche + " ariary");
            }
        }
        public void InitializeMaCaisse()
        {
            Proprio jeuFoot = Proprio.getProprio();
            maCaisse.Text = jeuFoot.Caisse.ToString() + " ariary";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void gamer1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void b_commencer_Click(object sender, EventArgs e)
        {
            //Choix des gamers
            string g1 = gamer1.SelectedItem.ToString();
            string g2 = gamer2.SelectedItem.ToString();
            string [] idG1 = g1.Split('-');
            string [] idG2 = g2.Split('-');
            int idGamer1 = int.Parse(idG1[0]);
            int idGamer2 = int.Parse(idG2[0]);
            Gamer gameer1 = Gamer.findGamerById(idGamer1);
            Gamer gameer2 = Gamer.findGamerById(idGamer2);

            //Debuter le match
            Proprio proprio = Proprio.getProprio();
            string mises = mise.Text;
            string jetons = jeton.Text;
            string gains = gain.Text;
            EstCeNombre(mises);
            EstCeNombre(jetons);
            EstCeNombre(gains);

            Match match = new Match(double.Parse(mises), int.Parse(jetons), double.Parse(gains), gameer1, gameer2, proprio);

            Form1 form = new Form1(match);
            form.Show();
        }

        private void mise_ValueChanged(object sender, EventArgs e)
        {

        }
        public void EstCeNombre(string text)
        {
            if(double.TryParse(text, out double number) == false)
            {
                MessageBox.Show("Veuillez saisir un nombre valide!");
            }
        }
    }
}
