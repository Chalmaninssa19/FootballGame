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
    public partial class Form1 : Form
    {
        Terrain terrain;
        Match match;
        private Timer animationTimer;
        public Form1(Match match)
        {
            InitializeComponent();
            this.match = match;
            terrain = new Terrain(match);

            //Initializer les labels
            caisse1.Text = match.Gamer1.Nom+" = "+match.Gamer1.Poche.ToString()+" ariary";
            caisse2.Text = match.Gamer2.Nom + " = " + match.Gamer2.Poche.ToString()+"ariary";
            miseLabel.Text = "Mise : "+match.Mise.ToString()+" ariary";
            jetonLabel.Text = "Jeton : "+match.Jeton.ToString();
            gainLabel.Text = "Prix gagant : "+match.Gain.ToString()+" ariary";
            prixJetonLabel.Text = "Prix jeton :"+match.PrixJeton.ToString()+" ariary";

            // Gérer les événements du clavier
            KeyDown += Form1_KeyDown;

            animationTimer = new Timer();
            animationTimer.Interval = 16; // Rafraîchissement toutes les 16 millisecondes (environ 60 FPS)
            animationTimer.Tick += AnimationTimer_Tick;
        }
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Mettre à jour l'animation du tir du ballon
            terrain.Ballon.UpdateAnimation(terrain.AllJoueurs);

            //Verifie si le ballon est intercepte
            if(terrain.Ballon.JoueurIntercept != null)
            {
                if(terrain.Ballon.JoueurIntercept.VerifierIntercept(terrain.Joueurs1) == 1)
                {
                    terrain.JoueurSelectionne1 = terrain.Ballon.JoueurIntercept;
                    terrain.Ballon.JoueurIntercept = null;
                    animationTimer.Stop();
                }
                else
                {
                    terrain.JoueurSelectionne2 = terrain.Ballon.JoueurIntercept;
                    terrain.Ballon.JoueurIntercept = null;
                    animationTimer.Stop();
                }             
            }
            //Verifier si le ballon a atteint les bords
            verifierCollisionSurBord();

            //Verifie si le ballon est marque
            IsButMarque();

            //Avoir le joueur le plus proche du ballon et le selectionne
            Joueur joueurProcheBallon1 = terrain.joueurPlusProcheBallon1();
            Joueur joueurProcheBallon2 = terrain.joueurPlusProcheBallon2();
            terrain.JoueurSelectionne1 = joueurProcheBallon1;
            terrain.JoueurSelectionne2 = joueurProcheBallon2;

            // Rafraîchir l'affichage
            Refresh();
        }
         private void IsButMarque()    //Verifie si le but est marque
        {
            if (terrain.CampGauche.Contains(terrain.Ballon.Position))
            {
                match.Jeton--;
                jetonLabel.Text = "Jeton : " + match.Jeton.ToString();
                terrain.Team2.Score++;
                terrain.ButMarque = true;
                int posX = terrain.Ballon.Position.X - 20;
                terrain.Ballon.Position = new Point(posX, terrain.Ballon.Position.Y);
                animationTimer.Stop();
                if(match.Jeton == 0)
                {
                    match.GamerGagnant = match.Gamer2;
                    match.GamerPerdant = match.Gamer1;
                    match.FinMatch();
                }
            }
            if (terrain.CampDroit.Contains(terrain.Ballon.Position))
            {
                match.Jeton--;
                jetonLabel.Text = "Jeton : " + match.Jeton.ToString();
                terrain.Team1.Score++;
                terrain.ButMarque = true;
                int posX = terrain.Ballon.Position.X + 20;
                terrain.Ballon.Position = new Point(posX, terrain.Ballon.Position.Y);
                animationTimer.Stop();
                if (match.Jeton == 0)
                {
                    match.GamerGagnant = match.Gamer1;
                    match.GamerPerdant = match.Gamer2;
                    match.FinMatch();
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            terrain.Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Vérifier si un joueur est sélectionné
            if (terrain.JoueurSelectionne1 == null && terrain.JoueurSelectionne2 == null)
                return;

            //Verifier si le joueur selectionne est en collision avec les autres joueurs
            if(terrain.JoueurHasBallon != null)
            {
                verifierCollisionEntreJoueurs();
            }         

            //Verifier si un but est marque
            if (terrain.ButMarque == true)
            {
                terrain.RemiseEnJeu();
            }

            // Déplacer le joueur en fonction de la touche pressée
            switch (e.KeyCode)
            {
                case Keys.Up:
                    terrain.JoueurSelectionne1.MoveUp();
                    break;
                case Keys.Down:
                    terrain.JoueurSelectionne1.MoveDown(Height);
                    break;
                case Keys.Left:
                    terrain.JoueurSelectionne1.MoveLeft();
                    break;
                case Keys.Right:
                    terrain.JoueurSelectionne1.MoveRight(Width);
                    break;
                case Keys.W:
                    terrain.JoueurSelectionne2.MoveUp();
                    break;
                case Keys.S:
                    terrain.JoueurSelectionne2.MoveDown(Height);
                    break;
                case Keys.Q:
                    terrain.JoueurSelectionne2.MoveLeft();
                    break;
                case Keys.E:
                    terrain.JoueurSelectionne2.MoveRight(Width);
                    break;
                case Keys.T:    //Tirer diagonale haut gauche
                    terrain.JoueurHasBallon.Tirer(terrain.Ballon, e.KeyCode, terrain.CampGauche, terrain.CampDroit);
                    animationTimer.Start();
                    break;
                case Keys.H:    //Tirer diagonale bas gauche
                    terrain.JoueurHasBallon.Tirer(terrain.Ballon, e.KeyCode, terrain.CampGauche, terrain.CampDroit);
                    animationTimer.Start();
                    break;
                case Keys.J:    //Tirer diagonale bas-droit
                    terrain.JoueurHasBallon.Tirer(terrain.Ballon, e.KeyCode, terrain.CampGauche, terrain.CampDroit);
                    animationTimer.Start();
                    break;
                case Keys.I:    //Tirer diagonale haut-droit
                    terrain.JoueurHasBallon.Tirer(terrain.Ballon, e.KeyCode, terrain.CampGauche, terrain.CampDroit);
                    animationTimer.Start();
                    break;
                case Keys.U:    //Tirer droit
                    terrain.JoueurHasBallon.Tirer(terrain.Ballon, e.KeyCode, terrain.CampGauche, terrain.CampDroit);
                    animationTimer.Start();
                    break;
                case Keys.Y:    //Tirer gauche
                    terrain.JoueurHasBallon.Tirer(terrain.Ballon, e.KeyCode, terrain.CampGauche, terrain.CampDroit);
                    animationTimer.Start();
                    break;
                case Keys.G:    //Passer en haut
                    terrain.JoueurHasBallon.Tirer(terrain.Ballon, e.KeyCode, terrain.CampGauche, terrain.CampDroit);
                    animationTimer.Start();
                    break;
                case Keys.K:    //Passer en bas
                    terrain.JoueurHasBallon.Tirer(terrain.Ballon, e.KeyCode, terrain.CampGauche, terrain.CampDroit);
                    animationTimer.Start();
                    break;
            }

            //Esct ce que le joueur selectionne a le ballon
            if (terrain.JoueurSelectionne1.JoueurSelectionneHasBallon(terrain.Ballon) != null)
            {
                terrain.JoueurHasBallon = terrain.JoueurSelectionne1.JoueurSelectionneHasBallon(terrain.Ballon);
            }
            else if (terrain.JoueurSelectionne2.JoueurSelectionneHasBallon(terrain.Ballon) != null)
            {
                terrain.JoueurHasBallon = terrain.JoueurSelectionne2.JoueurSelectionneHasBallon(terrain.Ballon);
            }
            else
            {
                terrain.JoueurHasBallon = null;
            }

            //Dribbler le ballon lorsque le joueur selectionne a le ballon
            terrain.JoueurSelectionne1.Dribbler(terrain.Ballon);
            terrain.JoueurSelectionne2.Dribbler(terrain.Ballon);

            Refresh();
        }
       
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // Sélectionner le joueur si on clique dessus
            foreach (var player in terrain.Joueurs1)
            {
                if (player.ContainsPoint(e.Location))
                {
                    terrain.JoueurSelectionne1 = player;
                    Refresh();
                    break;
                }
            }
            foreach (var player in terrain.Joueurs2)
            {
                if (player.ContainsPoint(e.Location))
                {
                    terrain.JoueurSelectionne2 = player;
                    Refresh();
                    break;
                }
            }
        }
        //Fonction pour verifier si le ballon a atteint le bord du terrain
        public void verifierCollisionSurBord()
        {
            // Vérifier si le ballon atteint les bords du terrain
            if (terrain.Ballon.Position.X <= 50)
            {
                // Le ballon a atteint les bords horizontaux gauche du terrain
                terrain.Ballon.Position = new Point(50, terrain.Ballon.Position.Y); // Inverser la direction horizontale
                animationTimer.Stop();
            }
            if (terrain.Ballon.Position.X >= terrain.TerrainWidth - 50)
            {
                // Le ballon a atteint les bords horizontaux droite du terrain
                terrain.Ballon.Position = new Point(terrain.TerrainWidth - 50, terrain.Ballon.Position.Y); // Inverser la direction horizontale
                animationTimer.Stop();
            }
            if (terrain.Ballon.Position.Y <= 55)
            {
                // Le ballon a atteint les bords verticaux haut du terrain
                terrain.Ballon.Position = new Point(terrain.Ballon.Position.X, 55); // Inverser la direction verticale
                animationTimer.Stop();
            }
            if (terrain.Ballon.Position.Y >= terrain.TerrainHeight - 55)
            {
                // Le ballon a atteint les bords verticaux du terrain
                terrain.Ballon.Position = new Point(terrain.Ballon.Position.X, terrain.TerrainHeight - 55); // Inverser la direction verticale
                animationTimer.Stop();
            }
        }
        //Verifier la collision entre les joueurs
        public void verifierCollisionEntreJoueurs()
        {
 
                /*if (terrain.JoueurHasBallon.VerifierCollisionEntreJoueurs(terrain.AllJoueurs) != null)
                {

                    Joueur joueurDefense = (terrain.JoueurHasBallon.VerifierCollisionEntreJoueurs(terrain.AllJoueurs));
                    //Reinitialiser sa position a celle de precedente
                    terrain.JoueurHasBallon.Position = terrain.JoueurHasBallon.PositionPrecedente;

                    if (joueurDefense.VerifierIntercept(terrain.Joueurs1) == 1)
                    {
                        terrain.JoueurSelectionne1 = joueurDefense;
                        terrain.JoueurSelectionne1.HasBallon = true;
                        animationTimer.Stop();
                    }
                    else
                    {
                        terrain.JoueurSelectionne2 = joueurDefense;
                        terrain.JoueurSelectionne2.HasBallon = true;
                        animationTimer.Stop();
                    }
                }
            
               /* if (terrain.JoueurSelectionne.HasBallon == true)
                {
                    terrain.JoueurSelectionne = joueurDefense;
                    terrain.JoueurSelectionne.HasBallon = true;
                    terrain.JoueurSelectionne.Dribbler(terrain.Ballon);
                }*/
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Console.WriteLine("Mandeha");
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //terrain.Joueur.deplacer(e.KeyCode);
        }

        private void mise_Click(object sender, EventArgs e)
        {

        }

        private void gainLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
