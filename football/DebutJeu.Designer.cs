namespace football
{
    partial class DebutJeu
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
            this.gamer1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gamer2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maCaisse = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.b_commencer = new System.Windows.Forms.Button();
            this.mise = new System.Windows.Forms.TextBox();
            this.gain = new System.Windows.Forms.TextBox();
            this.jeton = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // gamer1
            // 
            this.gamer1.FormattingEnabled = true;
            this.gamer1.Location = new System.Drawing.Point(125, 104);
            this.gamer1.Name = "gamer1";
            this.gamer1.Size = new System.Drawing.Size(121, 21);
            this.gamer1.TabIndex = 0;
            this.gamer1.SelectedIndexChanged += new System.EventHandler(this.gamer1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choisissez gamer: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "FOOTBALL GAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Gamer 1 ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Gamer 2";
            // 
            // gamer2
            // 
            this.gamer2.FormattingEnabled = true;
            this.gamer2.Location = new System.Drawing.Point(366, 104);
            this.gamer2.Name = "gamer2";
            this.gamer2.Size = new System.Drawing.Size(121, 21);
            this.gamer2.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(537, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ma caisse :";
            // 
            // maCaisse
            // 
            this.maCaisse.AutoSize = true;
            this.maCaisse.Location = new System.Drawing.Point(618, 51);
            this.maCaisse.Name = "maCaisse";
            this.maCaisse.Size = new System.Drawing.Size(42, 13);
            this.maCaisse.TabIndex = 7;
            this.maCaisse.Text = "0 Ariary";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Mise :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Jeton :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 283);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Gain :";
            // 
            // b_commencer
            // 
            this.b_commencer.Location = new System.Drawing.Point(322, 345);
            this.b_commencer.Name = "b_commencer";
            this.b_commencer.Size = new System.Drawing.Size(120, 47);
            this.b_commencer.TabIndex = 16;
            this.b_commencer.Text = "Commencer";
            this.b_commencer.UseVisualStyleBackColor = true;
            this.b_commencer.Click += new System.EventHandler(this.b_commencer_Click);
            // 
            // mise
            // 
            this.mise.Location = new System.Drawing.Point(125, 157);
            this.mise.Name = "mise";
            this.mise.Size = new System.Drawing.Size(100, 20);
            this.mise.TabIndex = 17;
            // 
            // gain
            // 
            this.gain.Location = new System.Drawing.Point(125, 283);
            this.gain.Name = "gain";
            this.gain.Size = new System.Drawing.Size(100, 20);
            this.gain.TabIndex = 18;
            // 
            // jeton
            // 
            this.jeton.Location = new System.Drawing.Point(125, 215);
            this.jeton.Name = "jeton";
            this.jeton.Size = new System.Drawing.Size(100, 20);
            this.jeton.TabIndex = 19;
            // 
            // DebutJeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.jeton);
            this.Controls.Add(this.gain);
            this.Controls.Add(this.mise);
            this.Controls.Add(this.b_commencer);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.maCaisse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gamer2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gamer1);
            this.Name = "DebutJeu";
            this.Text = "DebutJeu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox gamer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox gamer2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label maCaisse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button b_commencer;
        private System.Windows.Forms.TextBox mise;
        private System.Windows.Forms.TextBox gain;
        private System.Windows.Forms.TextBox jeton;
    }
}