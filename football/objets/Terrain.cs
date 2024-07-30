using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace football.objets
{
    internal class Terrain
    {
        private int terrainWidth = 700;
        private int terrainHeight = 500;
        private int campWidth = 50;
        private int campHeight = 100;

        private List<Joueur> joueurs1;
        private List<Joueur> joueurs2;
        private Ballon ballon;
        private Joueur joueurSelectionne1;
        private Joueur joueurSelectionne2;
        private Rectangle campGauche;
        private Rectangle campDroit;
        private Team team1;
        private Team team2;
        private bool butMarque;
        private Match match;
        private Joueur joueurHasBallon;
        private List<Joueur> allJoueurs;

        public int TerrainWidth
        {
            get { return this.terrainWidth; }
            set { this.terrainWidth = value; }
        }
        public int TerrainHeight
        {
            get { return this.terrainHeight; }
            set { this.terrainHeight = value; }
        }
        public int CampWidth
        {
            get { return this.campWidth; }
            set { this.campWidth = value; }
        }
        public int CampHeight
        {
            get { return this.campHeight; }
            set { this.campHeight = value; }
        }
        public List<Joueur> Joueurs1
        {
            get { return this.joueurs1; }
            set { this.joueurs1 = value; }
        }
        public List<Joueur> Joueurs2
        {
            get { return this.joueurs2; }
            set { this.joueurs2 = value; }
        }
        public Ballon Ballon
        {
            get { return this.ballon; }
            set { this.ballon = value; }
        }
        public Joueur JoueurSelectionne1
        {
            get { return this.joueurSelectionne1; }
            set { this.joueurSelectionne1 = value; }
        }
        public Joueur JoueurSelectionne2
        {
            get { return this.joueurSelectionne2; }
            set { this.joueurSelectionne2 = value; }
        }
        public Rectangle CampDroit
        {
            get { return this.campDroit; }
            set { this.campDroit = value; }
        }
        public Rectangle CampGauche
        {
            get { return this.campGauche; }
            set { this.campGauche = value; }
        }
        public Team Team1
        {
            get { return this.team1; }
            set { this.team1 = value; }
        }
        public Team Team2
        {
            get { return this.team2; }
            set { this.team2 = value; }
        }
        public bool ButMarque
        {
            get { return this.butMarque; }
            set { this.butMarque = value; }
        }
        public Match Match
        {
            get { return this.match; }
            set { this.match = value; }
        }
        public Joueur JoueurHasBallon
        {
            get { return this.joueurHasBallon; }
            set { this.joueurHasBallon = value; }
        }
        public List<Joueur> AllJoueurs
        {
            get { return this.allJoueurs; }
            set { this.allJoueurs = value; }
        }
        public Terrain(Match match)
         {
            //Initialization du jeu
            InitializeGame(match);

         }

        //Debut du jeu
        public void InitializeGame(Match match)
        {
            ///Initialisation du jeu
            ButMarque = false;

            //Initialiser les equipes
            team1 = new Team(match.Gamer1.IdGamer, match.Gamer1.Nom, 0, match.Gamer1.Poche);
            team2 = new Team(match.Gamer2.IdGamer, match.Gamer2.Nom, 0, match.Gamer2.Poche);

            // Créer les joueurs
            joueurs1 = new List<Joueur>
            {
                new Joueur(1,team1,"A1", new Point(50, terrainHeight / 2), Brushes.Blue, 0, 0, 100), //Gardien de but
                new Joueur(2,team1,"A2", new Point(100, (terrainHeight / 2) - 50), Brushes.Blue, 1, 30, 200), //Defense
                new Joueur(3,team1,"A3", new Point(100, (terrainHeight / 2) + 50), Brushes.Blue, 1, 30, 200), //Defense
                new Joueur(4,team1,"A4", new Point((terrainWidth / 2) - 30, (terrainHeight / 2) - 150), Brushes.Blue, 2, (terrainWidth / 2) - 150, (terrainWidth / 2) + 150), //Milieu
                new Joueur(5,team1,"A5", new Point((terrainWidth / 2) - 30, (terrainHeight / 2)), Brushes.Blue, 2, (terrainWidth / 2) - 150, (terrainWidth / 2) + 150),   //Milieu
                new Joueur(6,team1,"A6", new Point((terrainWidth / 2) - 30, (terrainHeight / 2) + 150), Brushes.Blue, 2, (terrainWidth / 2) - 150, (terrainWidth / 2) + 150), //Milieu
                new Joueur(7,team1,"A7", new Point(terrainWidth - 150, (terrainHeight / 2) - 30), Brushes.Blue, 3, terrainWidth - 200, terrainWidth - 30),   //Attaquant
                new Joueur(8,team1,"A8", new Point(terrainWidth - 150, (terrainHeight / 2) + 30), Brushes.Blue, 3, terrainWidth - 200, terrainWidth - 30),   //Attaquant
            };
            joueurs2 = new List<Joueur>
            {
                new Joueur(1,team2,"B1", new Point(terrainWidth - 50, terrainHeight / 2), Brushes.Red, 0,  terrainWidth - 100, terrainWidth), //Gardien de but
                new Joueur(2,team2,"B2", new Point(terrainWidth - 100, (terrainHeight / 2) - 60), Brushes.Red,  1,  terrainWidth - 200,  terrainWidth - 30),    //Defense
                new Joueur(3,team2,"B3", new Point(terrainWidth - 100, (terrainHeight / 2) + 60), Brushes.Red,  1,  terrainWidth - 200,  terrainWidth - 30),    //Defense
                new Joueur(4,team2,"B4", new Point((terrainWidth / 2) + 30, (terrainHeight / 2) - 150), Brushes.Red,  2, (terrainWidth/2) - 150,  (terrainWidth/2) + 150),  //Milieu
                new Joueur(5,team2,"B5", new Point((terrainWidth / 2) + 30, (terrainHeight / 2)), Brushes.Red,  2,  (terrainWidth/2) - 150,  (terrainWidth/2) + 150),    //Milieu
                new Joueur(6,team2,"B6", new Point((terrainWidth / 2) + 30, (terrainHeight / 2) + 150), Brushes.Red, 2,  (terrainWidth/2) - 150,  (terrainWidth/2) + 150),  //Milieu
                new Joueur(7,team1,"B7", new Point(120, (terrainHeight / 2) - 30), Brushes.Red, 3, 30, 200),    //Attaquant
                new Joueur(8,team1,"B8", new Point(120, (terrainHeight / 2) + 30), Brushes.Red, 3, 30, 200),    //Attaquant
            };
            //Initaliser tous les joueurs
            allJoueur(joueurs1, joueurs2);

            // Créer le ballon
            ballon = new Ballon(new Point(terrainWidth / 2, terrainHeight / 2));

            //Creer le camp gauche
            campGauche = new Rectangle(1, (terrainHeight - campHeight) / 2, campWidth, campHeight);

            //Creer le camp droit
            campDroit = new Rectangle(terrainWidth - campWidth - 1, (terrainHeight - campHeight) / 2, campWidth, campHeight);
        }

        //Creer un dictionnaire de distance des joueurs par rapport au ballon
        public List<Dictionary<string, object>> listDictionnaireDistance1()
        {
            List<Dictionary<string, object>> listDistanceJoueurAvecBallon = new List<Dictionary<string, object>>();
           
            foreach (Joueur joueur in Joueurs1)
            {
                double dx = joueur.Position.X - Ballon.Position.X;
                double dy = joueur.Position.Y - Ballon.Position.Y;
                double distance = Math.Sqrt(dx * dx + dy * dy);
                Dictionary<string, object> dictionnaireDistanceJoueurBall = new Dictionary<string, object>();
                dictionnaireDistanceJoueurBall.Add("Nom", joueur.Nom);
                dictionnaireDistanceJoueurBall.Add("Distance", distance);
                listDistanceJoueurAvecBallon.Add(dictionnaireDistanceJoueurBall);
            }

            return listDistanceJoueurAvecBallon;
        }
        public List<Dictionary<string, object>> listDictionnaireDistance2()
        {
            List<Dictionary<string, object>> listDistanceJoueurAvecBallon = new List<Dictionary<string, object>>();

            foreach (Joueur joueur in Joueurs2)
            {
                double dx = joueur.Position.X - Ballon.Position.X;
                double dy = joueur.Position.Y - Ballon.Position.Y;
                double distance = Math.Sqrt(dx * dx + dy * dy);
                Dictionary<string, object> dictionnaireDistanceJoueurBall = new Dictionary<string, object>();
                dictionnaireDistanceJoueurBall.Add("Nom", joueur.Nom);
                dictionnaireDistanceJoueurBall.Add("Distance", distance);
                listDistanceJoueurAvecBallon.Add(dictionnaireDistanceJoueurBall);
            }

            return listDistanceJoueurAvecBallon;
        }

        //Retourner le dictionnaire avec la distance minimum
        public Dictionary<string, object> findDistanceMin(List<Dictionary<string, object>> listDistanceJoueurAvecBallon)
        {
            Dictionary<string, object> min = listDistanceJoueurAvecBallon[0];
            foreach (Dictionary<string, object> dictionnaire in listDistanceJoueurAvecBallon)
            {
                if ((double)min["Distance"] > (double)dictionnaire["Distance"])
                {
                    min = dictionnaire;
                }
            }
            return min;
        }

        //Rechercher un joueur par son nom
        public Joueur findJoueur1(Dictionary<string, object> min)
        {
            Joueur joueurProche = new Joueur();
            foreach(Joueur joueur in joueurs1)
            {
                if (joueur.Nom.Equals(min["Nom"]))
                {
                    joueurProche = joueur;
                    break;
                }
            }

            return joueurProche;
        }
        public Joueur findJoueur2(Dictionary<string, object> min)
        {
            Joueur joueurProche = new Joueur();
            foreach (Joueur joueur in joueurs2)
            {
                if (joueur.Nom.Equals(min["Nom"]))
                {
                    joueurProche = joueur;
                    break;
                }
            }

            return joueurProche;
        }

        //Retourne le joueur le plus proche du ballon
        public Joueur joueurPlusProcheBallon1()
        {
            List<Dictionary<string, object>> listDistanceJoueurAvecBallon = listDictionnaireDistance1();
            Dictionary<string, object> joueurDistanceMin = findDistanceMin(listDistanceJoueurAvecBallon);
            return findJoueur1(joueurDistanceMin);
        }
        public Joueur joueurPlusProcheBallon2()
        {
            List<Dictionary<string, object>> listDistanceJoueurAvecBallon = listDictionnaireDistance2();
            Dictionary<string, object> joueurDistanceMin = findDistanceMin(listDistanceJoueurAvecBallon);
            return findJoueur2(joueurDistanceMin);
        }

        //En cas d'une remise enjeu
        public void RemiseEnJeu()
        {
            ///Initialisation du jeu
            ButMarque = false;


            // Créer les joueurs
            // Créer les joueurs

            // Créer les joueurs
            joueurs1 = new List<Joueur>
            {
                new Joueur(1,team1,"A1", new Point(50, terrainHeight / 2), Brushes.Blue, 0, 0, 100), //Gardien de but
                new Joueur(2,team1,"A2", new Point(100, (terrainHeight / 2) - 100), Brushes.Blue, 1, 30, 200), //Defense
                new Joueur(3,team1,"A3", new Point(100, (terrainHeight / 2) + 100), Brushes.Blue, 1, 30, 200), //Defense
                new Joueur(4,team1,"A4", new Point((terrainWidth / 2) - 30, (terrainHeight / 2) - 150), Brushes.Blue, 2, (terrainWidth / 2) - 150, (terrainWidth / 2) + 150), //Milieu
                new Joueur(5,team1,"A5", new Point((terrainWidth / 2) - 30, (terrainHeight / 2)), Brushes.Blue, 2, (terrainWidth / 2) - 150, (terrainWidth / 2) + 150),   //Milieu
                new Joueur(6,team1,"A6", new Point((terrainWidth / 2) - 30, (terrainHeight / 2) + 150), Brushes.Blue, 2, (terrainWidth / 2) - 150, (terrainWidth / 2) + 150), //Milieu
                new Joueur(7,team1,"A7", new Point(terrainWidth - 100, (terrainHeight / 2) - 30), Brushes.Blue, 3, terrainWidth - 200, terrainWidth - 30),   //Attaquant
                new Joueur(8,team1,"A8", new Point(terrainWidth - 100, (terrainHeight / 2) + 30), Brushes.Blue, 3, terrainWidth - 200, terrainWidth - 30),   //Attaquant
            };
            joueurs2 = new List<Joueur>
            {
                new Joueur(1,team2,"B1", new Point(terrainWidth - 50, terrainHeight / 2), Brushes.Red, 0,  terrainWidth - 100, terrainWidth), //Gardien de but
                new Joueur(2,team2,"B2", new Point(terrainWidth - 100, (terrainHeight / 2) - 100), Brushes.Red,  1,  terrainWidth - 200,  terrainWidth - 30),    //Defense
                new Joueur(3,team2,"B3", new Point(terrainWidth - 100, (terrainHeight / 2) + 100), Brushes.Red,  1,  terrainWidth - 200,  terrainWidth - 30),    //Defense
                new Joueur(4,team2,"B4", new Point((terrainWidth / 2) + 30, (terrainHeight / 2) - 150), Brushes.Red,  2, (terrainWidth/2) - 150,  (terrainWidth/2) + 150),  //Milieu
                new Joueur(5,team2,"B5", new Point((terrainWidth / 2) + 30, (terrainHeight / 2)), Brushes.Red,  2,  (terrainWidth/2) - 150,  (terrainWidth/2) + 150),    //Milieu
                new Joueur(6,team2,"B6", new Point((terrainWidth / 2) + 30, (terrainHeight / 2) + 150), Brushes.Red, 2,  (terrainWidth/2) - 150,  (terrainWidth/2) + 150),  //Milieu
                new Joueur(7,team1,"B7", new Point(80, (terrainHeight / 2) - 30), Brushes.Red, 3, 30, 200),    //Attaquant
                new Joueur(8,team1,"B8", new Point(80, (terrainHeight / 2) + 30), Brushes.Red, 3, 30, 200),    //Attaquant
            };
            //Initaliser tous les joueurs
            allJoueur(joueurs1, joueurs2);

            // Créer le ballon
            ballon = new Ballon(new Point(terrainWidth / 2, terrainHeight / 2));

            //Creer le camp gauche
            campGauche = new Rectangle(1, (terrainHeight - campHeight) / 2, campWidth, campHeight);

            //Creer le camp droit
            campDroit = new Rectangle(terrainWidth - campWidth - 1, (terrainHeight - campHeight) / 2, campWidth, campHeight);
        }

        //Verifie l'equipe d'un joueur
        public bool EstCeJoueurTeam1(Joueur joueur)
        {
            if (joueur.IdEquipe == Team1.IdTeam)
            {
                return true;
            }
            return false;
        }

       //Recuperer tous les joueurs
       public void allJoueur(List<Joueur> joueurs1, List<Joueur> joueurs2)
        {
            allJoueurs = new List<Joueur>();
            foreach(Joueur joueur in joueurs1)
            {
                //Console.WriteLine("io ->" + joueur.IdJoueur);
                allJoueurs.Add(joueur);
            }
            foreach (Joueur joueur in joueurs2)
            {
                allJoueurs.Add(joueur);
            }
        }

        //Dessiner le terrain
        public void Draw(Graphics g)
         {
             Pen linePen = new Pen(Color.White, 2);

            // Dessiner le terrain
            g.FillRectangle(Brushes.Green, 0, 0, terrainWidth, terrainHeight);

            //Dessiner les lignes de bordure
            g.DrawRectangle(linePen, 50, 50, terrainWidth-100, terrainHeight-100);


             // dessiner la ligne de milieu de milieu de terrain
             g.DrawLine(linePen, terrainWidth / 2, 50, terrainWidth / 2, terrainHeight - 50);

             // Dessiner les cercles des coins
             int cornerRadius = 50;
             g.DrawArc(linePen, 50, 50, cornerRadius * 2, cornerRadius * 2, 180, 90);
             g.DrawArc(linePen, terrainWidth - cornerRadius * 2 - 50, 50, cornerRadius * 2, cornerRadius * 2, 270, 90);
             g.DrawArc(linePen, 50, terrainHeight - cornerRadius * 2 - 50, cornerRadius * 2, cornerRadius * 2, 90, 90);
             g.DrawArc(linePen, terrainWidth - cornerRadius * 2 - 50, terrainHeight - cornerRadius * 2 - 50, cornerRadius * 2, cornerRadius * 2, 0, 90);

             // Dessiner les demi-cercles des surfaces de reparation
             int penaltyArcRadius = 100;
             g.DrawArc(linePen, -50, terrainHeight / 2 - penaltyArcRadius, penaltyArcRadius * 2, penaltyArcRadius * 2, -90, 180);
             g.DrawArc(linePen, terrainWidth - penaltyArcRadius * 2 + 50, terrainHeight / 2 - penaltyArcRadius, penaltyArcRadius * 2, penaltyArcRadius * 2, 90, 180);

             // Dessiner le point central
             int centerCircleRadius = 10;
             g.DrawEllipse(linePen, terrainWidth / 2 - centerCircleRadius, terrainHeight / 2 - centerCircleRadius, centerCircleRadius * 2, centerCircleRadius * 2);

             //Ajouter les camps de buts
             int goalWidth = 30; // Largeur du camp de but
             int goalHeight = 100; // Hauteur du camp de but

             //Camp de but gauche
             g.DrawRectangle(linePen, campGauche);

             // Camp de but droit
             g.DrawRectangle(linePen, campDroit);

            // Dessiner les joueurs
            foreach (var player in joueurs1)
            {
                player.Draw(g);
            }
            foreach (var player in joueurs2)
            {
                player.Draw(g);
            }

            //Pour les joueurs selectionnes
            Pen linePen1 = new Pen(System.Drawing.Color.White, 3);
            if(JoueurSelectionne1 != null && JoueurSelectionne2 != null)
            {
                g.DrawEllipse(linePen1, JoueurSelectionne1.Position.X - JoueurSelectionne1.Taille / 2, JoueurSelectionne1.Position.Y - JoueurSelectionne1.Taille / 2, JoueurSelectionne1.Taille, JoueurSelectionne1.Taille);
                g.DrawEllipse(linePen1, JoueurSelectionne2.Position.X - JoueurSelectionne2.Taille / 2, JoueurSelectionne2.Position.Y - JoueurSelectionne2.Taille / 2, JoueurSelectionne2.Taille, JoueurSelectionne2.Taille);
            }

            // Dessiner le ballon
            ballon.Draw(g);

            // Afficher les scores
            Font font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular);
            string scoreText = $"Score : {team1.Nom} {team1.Score} - {team2.Score} {team2.Nom}";
            SizeF scoreTextSize = g.MeasureString(scoreText, font);
            PointF scoreTextPosition = new PointF((TerrainWidth - scoreTextSize.Width) / 2 + 20, 10);
            g.DrawString(scoreText, font, Brushes.Black, scoreTextPosition);
        }
    }
}
