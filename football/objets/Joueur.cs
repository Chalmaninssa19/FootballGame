using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace football.objets
{
    internal class Joueur
    {
        private int idJoueur;
        private int idEquipe;
        private string nom;
        private bool hasBallon;
        private int vitesse;
        private int taille;
        private Point position;
        private Point positionPrecedente;
        private Brush color;
        private Team myTeam;
        private int poste;
        private int zoneLimitMin;
        private int zoneLimitMax;

        public event EventHandler ButMarque;

        public event EventHandler OnPlayerMoved;
        public int IdJoueur
        {
            get { return this.idJoueur; }
            set { this.idJoueur = value; }
        }
        public int IdEquipe
        {
            get { return this.idEquipe; }
            set { this.idEquipe = value; }
        }
        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public bool HasBallon
        {
            get { return this.hasBallon; }
            set { this.hasBallon = value; }
        }
        public int Vitesse
        {
            get { return this.vitesse; }
            set { this.vitesse = value; }
        }
        public int Taille
        {
            get { return this.taille; }
            set { this.taille = value; }
        }
        public Point Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public Point PositionPrecedente
        {
            get { return this.positionPrecedente; }
            set { this.positionPrecedente = value; }
        }
        public Brush Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        public Team MyTeam
        {
            get { return this.myTeam; }
            set { this.myTeam = value; }
        }
        public int Poste
        {
            get { return this.poste; }
            set { this.poste = value; }
        }
        public int ZoneLimitMin
        {
            get { return this.zoneLimitMin; }
            set { this.zoneLimitMin = value; }
        }
        public int ZoneLimitMax
        {
            get { return this.zoneLimitMax; }
            set { this.zoneLimitMax = value; }
        }

        public Joueur() {}
        public Joueur(int idJoueur, Team myTeam, string nom, Point position, Brush color, int poste, int zoneLimitMin, int zoneLimitMax)
        {
            IdJoueur = idJoueur;
            IdEquipe = idEquipe;
            Nom = nom;
            HasBallon = false;
            Vitesse = 5;
            Taille = 30;
            Position = position;
            Color = color;
            MyTeam = myTeam;
            Poste = poste;
            ZoneLimitMin = zoneLimitMin;
            ZoneLimitMax = zoneLimitMax;
        }
        public void MoveUp()
        {
            PositionPrecedente = Position;
            Position = new Point(Position.X, Math.Max(Position.Y - Vitesse, 0));
        }


        public void MoveDown(int heightTerrain)
        {
            PositionPrecedente = Position;
            Position = new Point(Position.X, Math.Min(Position.Y + Vitesse, heightTerrain));
        }

        public void MoveLeft()
        {
            Console.WriteLine("gauche");
            Console.WriteLine("PosJ->" + Position.X + " <= Limit" + ZoneLimitMin);
            if(Position.X <= ZoneLimitMin)
            {
                PositionPrecedente = Position;
                Position = new Point(Position.X, Position.Y);
            }
            else
            {
                PositionPrecedente = Position;
                Position = new Point(Position.X - Vitesse, Position.Y);
            }
        }

        public void MoveRight(int widthTerrain)
        {
            Console.WriteLine("Right");
            Console.WriteLine("PosJ->" + Position.X + " >= Limit" + ZoneLimitMax);
            if (Position.X >= ZoneLimitMax)
            {
                PositionPrecedente = Position;
                Position = new Point(Position.X, Position.Y);
            }
            else
            {
                PositionPrecedente = Position;
                Position = new Point(Position.X + Vitesse, Position.Y);
            }
        }
        public void Dribbler(Ballon ball)
        {
            if (HasBallon)
            {
                ball.Position = Position;
            }
        }

        public void Tirer(Ballon ball, Keys direction, Rectangle campAdverse, Rectangle campPropre)
        {
            if (HasBallon)
            {
                Point target = GetTargetPosition(direction);
                ball.Tirer(target);
                HasBallon = false;
            }

            if (campAdverse.Contains(ball.Position))
            {
                OnButMarque();
            }
            if (campPropre.Contains(ball.Position))
            {
                OnButMarque();
            }
        }
        private Point GetTargetPosition(Keys direction)
        {
            // Calculer la position cible en fonction de la direction
            int targetX = Position.X;
            int targetY = Position.Y;

            switch (direction)
            {
                case Keys.T:    //Diagonale haut gauche
                    targetY -= 500;
                    targetX -= 500;
                    break;
                case Keys.H:    //Diagonale bas gauche
                    targetY += 500; 
                    targetX -= 500;
                    break;
                case Keys.J:    //Diagonale bas droit
                    targetY += 500;
                    targetX += 500;
                    break;
                case Keys.I:    //Diagonale haut droit
                    targetY -= 500;
                    targetX += 500;
                    break;
                case Keys.U: //droit
                    targetX += 500;
                    break;
                case Keys.Y:    //gauche
                    targetX -= 500; 
                    break;
                case Keys.G:    //haut
                    targetY -= 500;
                    break;
                case Keys.K:     //bas
                    targetY += 500;
                    break;
            }

            return new Point(targetX, targetY);
        }

        public Joueur VerifierCollisionEntreJoueurs(List<Joueur> joueurs)
        {
            foreach(Joueur joueur in joueurs )
            {
                if (joueur != this && joueur.ContainsPoint(Position))
                {
                    return joueur;
                }
            }
            return null;
        }
        public Joueur JoueurSelectionneHasBallon(Ballon ballon)
        {
            if (this.ContainsPoint(ballon.Position))
            {
                HasBallon = true;
                return this;
            }

            HasBallon = false;
            return null;
        }
        protected virtual void OnButMarque()
        {
            ButMarque?.Invoke(this, EventArgs.Empty);
        }
        public void Draw(Graphics g)
        {
            g.FillEllipse(color, Position.X - Taille / 2, Position.Y - Taille / 2, Taille, Taille);
        }

        public bool ContainsPoint(Point point)
        {
            return Math.Abs(point.X - Position.X) <= Taille / 2 && Math.Abs(point.Y - Position.Y) <= Taille / 2;
        }

        //Verifier qui a intercepte le ballon
        public int VerifierIntercept(List<Joueur> joueurs1)
        {
            foreach(Joueur joueur in joueurs1)
            {
                if(IdEquipe == joueur.idEquipe)
                {
                    return 1;
                }
            }
            return 2;
        }
    }
}
