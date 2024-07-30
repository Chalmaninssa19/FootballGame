using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace football.objets
{
    internal class V_gamerTeam
    {
        private int idTeam;
        private int idGamer;
        private string gamer;
        private string team;
        private double poche;
        public int IdTeam
        {
            get { return this.idTeam; }
            set { this.idTeam = value; }
        }
        public int IdGamer
        {
            get { return this.idGamer; }
            set { this.idGamer = value; }
        }
        public string Gamer
        {
            get { return this.gamer; }
            set { this.gamer = value; }
        }
        public string Team
        {
            get { return this.team; }
            set { this.team = value; }
        }
        public double Poche
        {
            get { return this.poche; }
            set { this.poche = value; }
        }

        public V_gamerTeam()
        {
        }

        public V_gamerTeam(int idTeam, int idGamer, string gamer, string team, double poche)
        {
            this.idTeam = idTeam;
            this.idGamer = idGamer;
            this.gamer = gamer;
            this.team = team;
            this.poche = poche;
        }

        public static List<V_gamerTeam> getAllV_gamerTeam()
        {
            string query = "SELECT * FROM v_gamerTeam";
            Connexion connex = new Connexion();
            NpgsqlConnection conn = connex.DbConnect();
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = command.ExecuteReader();
            List<V_gamerTeam> allGamerTeam = new List<V_gamerTeam>();
            while (reader.Read())
            {
                allGamerTeam.Add(new V_gamerTeam((int)reader["idTeam"], (int)reader["idGamer"], (string)reader["gamer"], (string)reader["team"], (double)reader["poche"]));
            }

            conn.Close();

            return allGamerTeam;
        }
    }
}
