using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace football.objets
{
    internal class Team
    {
        private int idTeam;
        private string nom;
        private int score;
        private double caisse;

        public Team()
        {
        }

        public int IdTeam
        {
            get { return this.idTeam; }
            set { this.idTeam = value; }
        }
        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }
        public double Caisse
        {
            get { return this.caisse; }
            set { this.caisse = value; }
        }

        public Team(int idTeam, string nom, int score, double caisse)
        {
            IdTeam = idTeam;
            Nom = nom;
            Score = score;
            Caisse = caisse;
        }
    }
}
