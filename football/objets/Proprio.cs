using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace football.objets
{
    public class Proprio
    {
        private string nom;
        private double caisse;
        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public double Caisse
        {
            get { return this.caisse; }
            set { this.caisse = value; }
        }
        public Proprio() {}
        public Proprio(string nom, double caisse)
        {
            this.nom = nom;
            this.caisse = caisse;
        }
        public static Proprio getProprio()
        {
            string query = "SELECT * FROM proprio";
            Connexion connex = new Connexion();
            NpgsqlConnection conn = connex.DbConnect();
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = command.ExecuteReader();
            Proprio proprio = new Proprio();
            while(reader.Read())
            {
                proprio.Nom = (string)reader["nom"];
                proprio.Caisse = (double)reader["caisse"];
            }

            conn.Close();

            return proprio;
        }
        public void miseAjourCaisse()
        {
            string query = "UPDATE proprio SET caisse = " + Caisse;
            Connexion connex = new Connexion();
            NpgsqlConnection conn = connex.DbConnect();
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = command.ExecuteReader();

            conn.Close();
        }
    }
}
