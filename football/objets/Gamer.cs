using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace football.objets
{
    public class Gamer
    {
        private int idGamer;
        private string nom;
        private int idEquipe;
        private double poche;

        public int IdGamer
        {
            get { return this.idGamer; }
            set { this.idGamer = value; }
        }
        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public int IdEquipe
        {
            get { return this.idEquipe; }
            set { this.idEquipe = value; }
        }
        public double Poche
        {
            get { return this.poche; }
            set { this.poche = value; }
        }

        public Gamer(){}

        public Gamer(int idGamer, string nom, int idEquipe, double poche)
        {
            this.idGamer = idGamer;
            this.nom = nom;
            this.idEquipe = idEquipe;
            this.poche = poche;
        }

        public static List<Gamer> getAllGamer()
        {
            string query = "SELECT * FROM gamer";
            Connexion connex = new Connexion();
            NpgsqlConnection conn = connex.DbConnect();
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = command.ExecuteReader();
            List<Gamer> allGamer = new List<Gamer>();
            while (reader.Read())
            {
                allGamer.Add(new Gamer((int)reader["idGamer"], (string)reader["nomGamer"], (int)reader["idEquipe"], (double)reader["poche"]));
            }

            conn.Close();

            return allGamer;
        }
        public void miseAjourPoche()
        {
            string query = "UPDATE gamer SET poche = "+Poche+" WHERE idGamer = "+IdGamer;
            Connexion connex = new Connexion();
            NpgsqlConnection conn = connex.DbConnect();
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = command.ExecuteReader();

            conn.Close();
        } 
        public static Gamer findGamerById(int idGamer)
        {
            string query = "SELECT * FROM gamer where idGamer = "+idGamer;
            Connexion connex = new Connexion();
            NpgsqlConnection conn = connex.DbConnect();
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = command.ExecuteReader();
            Gamer gamer = new Gamer();
            while (reader.Read())
            {
                gamer.IdGamer = (int)reader["idGamer"];
                gamer.idEquipe = (int)reader["idEquipe"];
                gamer.Nom = (string)reader["nomGamer"];
                gamer.Poche = (double)reader["poche"];
            }

            conn.Close();

            return gamer;
        }
    }
}
