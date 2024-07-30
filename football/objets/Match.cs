using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace football.objets
{
    public class Match
    {
        private double mise;
        private int jeton;
        private double prixJeton;
        private double gain;
        private Gamer gamer1;
        private Gamer gamer2;
        private Proprio proprio;
        private Gamer gamerGagnant;
        private Gamer gamerPerdant;

        public double Mise
        {
            get { return this.mise; }
            set { this.mise = value; }
        }
        public int Jeton
        {
            get { return this.jeton; }
            set { this.jeton = value; }
        }
        public double PrixJeton
        {
            get { return this.prixJeton; }
            set { this.prixJeton = value; }
        }
        public double Gain
        {
            get { return this.gain; }
            set { this.gain = value; }
        }
        public Gamer Gamer1
        {
            get { return this.gamer1; }
            set { this.gamer1 = value; }
        }
        public Gamer Gamer2
        {
            get { return this.gamer2; }
            set { this.gamer2 = value; }
        }
        public Proprio Proprio
        {
            get { return this.proprio; }
            set { this.proprio = value; }
        }
        public Gamer GamerGagnant
        {
            get { return this.gamerGagnant; }
            set { this.gamerGagnant = value; }
        }
        public Gamer GamerPerdant
        {
            get { return this.gamerPerdant; }
            set { this.gamerPerdant = value; }
        }

        public Match(){}

        public Match(double mise, int jeton, double gain, Gamer gamer1, Gamer gamer2, Proprio proprio)
        {
            Mise = mise;
            Jeton = jeton;
            Gain = gain;
            Gamer1 = gamer1;
            Gamer2 = gamer2;
            Proprio = proprio;
            PrixJeton = Mise * 2 - Gain;
            GamerGagnant = null;
            GamerGagnant = null;
        }

       /* public void InsertMatch()
        {
            string query = "INSERT INTO match values (default,'" +TeamA.Nom+"','"+TeamB.Nom+"',"+TeamA.Score+","+TeamB.Score+","+TeamA.Caisse+","+TeamB.Caisse+","+Jeton+")";
            Connexion connex = new Connexion();
            NpgsqlConnection conn = connex.DbConnect();
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = command.ExecuteReader();

            conn.Close();
        }*/
       public void FinMatch()
        {
            GamerGagnant.Poche = Gain;
            GamerPerdant.Poche -= Gain;
            //PrixJeton = Mise * 2 - Gain;
            Proprio.Caisse += PrixJeton;
        }
    }
}