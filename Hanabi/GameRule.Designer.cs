
namespace Hanabi
{
    partial class GameRule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameRule));
            this.lblRule = new System.Windows.Forms.Label();
            this.rbtExtCouleur = new System.Windows.Forms.RadioButton();
            this.rbtExtNon = new System.Windows.Forms.RadioButton();
            this.gbxExtension = new System.Windows.Forms.GroupBox();
            this.rbtExtJoker = new System.Windows.Forms.RadioButton();
            this.gbxIndice = new System.Windows.Forms.GroupBox();
            this.nupIndice = new System.Windows.Forms.NumericUpDown();
            this.gbxEclair = new System.Windows.Forms.GroupBox();
            this.nupEclair = new System.Windows.Forms.NumericUpDown();
            this.btnReady = new System.Windows.Forms.Button();
            this.gbxExtension.SuspendLayout();
            this.gbxIndice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupIndice)).BeginInit();
            this.gbxEclair.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupEclair)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRule
            // 
            this.lblRule.AutoSize = true;
            this.lblRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRule.Location = new System.Drawing.Point(12, 9);
            this.lblRule.Name = "lblRule";
            this.lblRule.Size = new System.Drawing.Size(175, 29);
            this.lblRule.TabIndex = 0;
            this.lblRule.Text = "Règles du jeu";
            // 
            // rbtExtCouleur
            // 
            this.rbtExtCouleur.AutoSize = true;
            this.rbtExtCouleur.Enabled = false;
            this.rbtExtCouleur.Location = new System.Drawing.Point(114, 19);
            this.rbtExtCouleur.Name = "rbtExtCouleur";
            this.rbtExtCouleur.Size = new System.Drawing.Size(94, 17);
            this.rbtExtCouleur.TabIndex = 2;
            this.rbtExtCouleur.Text = "6ème couleurs";
            this.rbtExtCouleur.UseVisualStyleBackColor = true;
            // 
            // rbtExtNon
            // 
            this.rbtExtNon.AutoSize = true;
            this.rbtExtNon.Checked = true;
            this.rbtExtNon.Location = new System.Drawing.Point(6, 19);
            this.rbtExtNon.Name = "rbtExtNon";
            this.rbtExtNon.Size = new System.Drawing.Size(45, 17);
            this.rbtExtNon.TabIndex = 0;
            this.rbtExtNon.TabStop = true;
            this.rbtExtNon.Text = "Non";
            this.rbtExtNon.UseVisualStyleBackColor = true;
            // 
            // gbxExtension
            // 
            this.gbxExtension.Controls.Add(this.rbtExtJoker);
            this.gbxExtension.Controls.Add(this.rbtExtCouleur);
            this.gbxExtension.Controls.Add(this.rbtExtNon);
            this.gbxExtension.Location = new System.Drawing.Point(15, 156);
            this.gbxExtension.Name = "gbxExtension";
            this.gbxExtension.Size = new System.Drawing.Size(219, 48);
            this.gbxExtension.TabIndex = 3;
            this.gbxExtension.TabStop = false;
            this.gbxExtension.Text = "Extension";
            // 
            // rbtExtJoker
            // 
            this.rbtExtJoker.AutoSize = true;
            this.rbtExtJoker.Location = new System.Drawing.Point(57, 19);
            this.rbtExtJoker.Name = "rbtExtJoker";
            this.rbtExtJoker.Size = new System.Drawing.Size(51, 17);
            this.rbtExtJoker.TabIndex = 1;
            this.rbtExtJoker.Text = "Joker";
            this.rbtExtJoker.UseVisualStyleBackColor = true;
            // 
            // gbxIndice
            // 
            this.gbxIndice.Controls.Add(this.nupIndice);
            this.gbxIndice.Location = new System.Drawing.Point(15, 42);
            this.gbxIndice.Name = "gbxIndice";
            this.gbxIndice.Size = new System.Drawing.Size(219, 51);
            this.gbxIndice.TabIndex = 1;
            this.gbxIndice.TabStop = false;
            this.gbxIndice.Text = "Nombre d\'indice";
            // 
            // nupIndice
            // 
            this.nupIndice.Location = new System.Drawing.Point(12, 19);
            this.nupIndice.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nupIndice.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nupIndice.Name = "nupIndice";
            this.nupIndice.Size = new System.Drawing.Size(196, 20);
            this.nupIndice.TabIndex = 0;
            this.nupIndice.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // gbxEclair
            // 
            this.gbxEclair.Controls.Add(this.nupEclair);
            this.gbxEclair.Location = new System.Drawing.Point(15, 99);
            this.gbxEclair.Name = "gbxEclair";
            this.gbxEclair.Size = new System.Drawing.Size(219, 51);
            this.gbxEclair.TabIndex = 2;
            this.gbxEclair.TabStop = false;
            this.gbxEclair.Text = "Nombre d\'éclair";
            // 
            // nupEclair
            // 
            this.nupEclair.Location = new System.Drawing.Point(12, 19);
            this.nupEclair.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nupEclair.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nupEclair.Name = "nupEclair";
            this.nupEclair.Size = new System.Drawing.Size(196, 20);
            this.nupEclair.TabIndex = 0;
            this.nupEclair.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // btnReady
            // 
            this.btnReady.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnReady.Location = new System.Drawing.Point(17, 214);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(217, 23);
            this.btnReady.TabIndex = 4;
            this.btnReady.Text = "OK";
            this.btnReady.UseVisualStyleBackColor = true;
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
            // 
            // GameRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 249);
            this.Controls.Add(this.btnReady);
            this.Controls.Add(this.gbxEclair);
            this.Controls.Add(this.gbxIndice);
            this.Controls.Add(this.gbxExtension);
            this.Controls.Add(this.lblRule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameRule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameRule";
            this.gbxExtension.ResumeLayout(false);
            this.gbxExtension.PerformLayout();
            this.gbxIndice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupIndice)).EndInit();
            this.gbxEclair.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupEclair)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRule;
        private System.Windows.Forms.RadioButton rbtExtCouleur;
        private System.Windows.Forms.RadioButton rbtExtNon;
        private System.Windows.Forms.GroupBox gbxExtension;
        private System.Windows.Forms.GroupBox gbxIndice;
        private System.Windows.Forms.NumericUpDown nupIndice;
        private System.Windows.Forms.GroupBox gbxEclair;
        private System.Windows.Forms.NumericUpDown nupEclair;
        private System.Windows.Forms.RadioButton rbtExtJoker;
        private System.Windows.Forms.Button btnReady;
    }
}