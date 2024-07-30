namespace football
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.jetonLabel = new System.Windows.Forms.Label();
            this.miseLabel = new System.Windows.Forms.Label();
            this.caisse1 = new System.Windows.Forms.Label();
            this.caisse2 = new System.Windows.Forms.Label();
            this.gainLabel = new System.Windows.Forms.Label();
            this.prixJetonLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(682, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Caisse :";
            // 
            // jetonLabel
            // 
            this.jetonLabel.AutoSize = true;
            this.jetonLabel.Location = new System.Drawing.Point(682, 117);
            this.jetonLabel.Name = "jetonLabel";
            this.jetonLabel.Size = new System.Drawing.Size(48, 13);
            this.jetonLabel.TabIndex = 1;
            this.jetonLabel.Text = "Jeton : 5";
            // 
            // miseLabel
            // 
            this.miseLabel.AutoSize = true;
            this.miseLabel.Location = new System.Drawing.Point(682, 81);
            this.miseLabel.Name = "miseLabel";
            this.miseLabel.Size = new System.Drawing.Size(78, 13);
            this.miseLabel.TabIndex = 2;
            this.miseLabel.Text = "Mise : 10 ariary";
            this.miseLabel.Click += new System.EventHandler(this.mise_Click);
            // 
            // caisse1
            // 
            this.caisse1.AutoSize = true;
            this.caisse1.Location = new System.Drawing.Point(727, 20);
            this.caisse1.Name = "caisse1";
            this.caisse1.Size = new System.Drawing.Size(70, 13);
            this.caisse1.TabIndex = 3;
            this.caisse1.Text = "J1 = 10 ariary";
            // 
            // caisse2
            // 
            this.caisse2.AutoSize = true;
            this.caisse2.Location = new System.Drawing.Point(727, 49);
            this.caisse2.Name = "caisse2";
            this.caisse2.Size = new System.Drawing.Size(70, 13);
            this.caisse2.TabIndex = 4;
            this.caisse2.Text = "J2 = 10 ariary";
            // 
            // gainLabel
            // 
            this.gainLabel.AutoSize = true;
            this.gainLabel.Location = new System.Drawing.Point(682, 157);
            this.gainLabel.Name = "gainLabel";
            this.gainLabel.Size = new System.Drawing.Size(115, 13);
            this.gainLabel.TabIndex = 5;
            this.gainLabel.Text = "Prix gagant : 100 ariary";
            this.gainLabel.Click += new System.EventHandler(this.gainLabel_Click);
            // 
            // prixJetonLabel
            // 
            this.prixJetonLabel.AutoSize = true;
            this.prixJetonLabel.Location = new System.Drawing.Point(682, 192);
            this.prixJetonLabel.Name = "prixJetonLabel";
            this.prixJetonLabel.Size = new System.Drawing.Size(96, 13);
            this.prixJetonLabel.TabIndex = 6;
            this.prixJetonLabel.Text = "Prix jeu : 100 ariary";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 537);
            this.Controls.Add(this.prixJetonLabel);
            this.Controls.Add(this.gainLabel);
            this.Controls.Add(this.caisse2);
            this.Controls.Add(this.caisse1);
            this.Controls.Add(this.miseLabel);
            this.Controls.Add(this.jetonLabel);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label jetonLabel;
        private System.Windows.Forms.Label miseLabel;
        private System.Windows.Forms.Label caisse1;
        private System.Windows.Forms.Label caisse2;
        private System.Windows.Forms.Label gainLabel;
        private System.Windows.Forms.Label prixJetonLabel;
    }
}

