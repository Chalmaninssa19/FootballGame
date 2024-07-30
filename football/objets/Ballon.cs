using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace football.objets
{
    internal class Ballon : PictureBox
    {
        int taille = 10;
        public event EventHandler OnBallClicked;
        Point position;
        bool isAnimating;
        Point targetPosition;
        Joueur joueurIntercept;
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
        public bool IsAnimating
        {
            get { return this.isAnimating; }
            set { this.isAnimating = value; }
        }
        public Point TargetPosition
        {
            get { return this.targetPosition; }
            set { this.targetPosition = value; }
        }
        public Joueur JoueurIntercept
        {
            get { return this.joueurIntercept; }
            set { this.joueurIntercept = value; }
        }
        public Ballon(Point position)
        {
            // Charger l'image a partir d'un fichier
            /*this.Image = Image.FromFile("C:\\Users\\Chalman\\Source\\Repos\\football\\football\\image\\ball.png");

            //Taille du ballon
            this.Width = 30;
            this.Height = 30;
            
            this.Location = new Point(x, y);
            SizeMode = PictureBoxSizeMode.StretchImage;*/
            Position = position;
            IsAnimating = false;
            JoueurIntercept = null;
        }
        public void UpdateAnimation(List<Joueur> joueurs)
        {
            // Calculer la direction du tir
            double dx = TargetPosition.X - Position.X;
            double dy = TargetPosition.Y - Position.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);
            double speed = 18; // Vitesse du ballon lors d'un tir
            double vx = dx / distance * speed;
            double vy = dy / distance * speed;

            if (IsAnimating)
            {
                // Mettre à jour progressivement la position du ballon vers la cible
                Position = new Point(Position.X + (int)vx, Position.Y + (int)vy);
                if(VerifierCollisionJoueurEtBallon(this, joueurs) != null)
                {
                    JoueurIntercept = VerifierCollisionJoueurEtBallon(this, joueurs);
                    IsAnimating = false;
                }
                // Vérifier si l'animation est terminée
                if (distance < 1)
                {
                    // L'animation est terminée, arrêter l'animation
                    IsAnimating = false;
                    Position = targetPosition;
                }
            }
        }
        public void Tirer(Point targetPosition)
        {
            // Définir la position cible et démarrer l'animation
            TargetPosition = targetPosition;
            IsAnimating = true;
        }
        public Joueur VerifierCollisionJoueurEtBallon(Ballon ball, List<Joueur> joueurs)
        {
            foreach(Joueur joueur in joueurs)
            {
                if(joueur.ContainsPoint(ball.Position))
                {
                    return joueur;
                }
            }
            return null;
        }
        public void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Black, Position.X - Taille / 2, Position.Y - Taille / 2, Taille, Taille);
        }
    }
}
