
namespace HanabiServeur
{
    partial class HistoriqueGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoriqueGame));
            this.lblTitre = new System.Windows.Forms.Label();
            this.pnlHistoric = new System.Windows.Forms.Panel();
            this.lbxParticipant = new System.Windows.Forms.ListBox();
            this.cbxMulticolor = new System.Windows.Forms.CheckBox();
            this.lblFault = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDuree = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblHintScore = new System.Windows.Forms.Label();
            this.lblHintDate = new System.Windows.Forms.Label();
            this.lblHintDuree = new System.Windows.Forms.Label();
            this.lblHintHint = new System.Windows.Forms.Label();
            this.lblHintFault = new System.Windows.Forms.Label();
            this.lblHintMulticolor = new System.Windows.Forms.Label();
            this.lblHintParticipant = new System.Windows.Forms.Label();
            this.pnlHistoric.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.Location = new System.Drawing.Point(4, 9);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(299, 31);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Historique des parties";
            // 
            // pnlHistoric
            // 
            this.pnlHistoric.Controls.Add(this.lbxParticipant);
            this.pnlHistoric.Controls.Add(this.cbxMulticolor);
            this.pnlHistoric.Controls.Add(this.lblFault);
            this.pnlHistoric.Controls.Add(this.lblHint);
            this.pnlHistoric.Controls.Add(this.lblDate);
            this.pnlHistoric.Controls.Add(this.lblDuree);
            this.pnlHistoric.Controls.Add(this.lblScore);
            this.pnlHistoric.Location = new System.Drawing.Point(12, 76);
            this.pnlHistoric.Name = "pnlHistoric";
            this.pnlHistoric.Size = new System.Drawing.Size(429, 55);
            this.pnlHistoric.TabIndex = 8;
            this.pnlHistoric.Visible = false;
            // 
            // lbxParticipant
            // 
            this.lbxParticipant.FormattingEnabled = true;
            this.lbxParticipant.Location = new System.Drawing.Point(4, 6);
            this.lbxParticipant.Name = "lbxParticipant";
            this.lbxParticipant.Size = new System.Drawing.Size(120, 43);
            this.lbxParticipant.TabIndex = 0;
            // 
            // cbxMulticolor
            // 
            this.cbxMulticolor.AutoSize = true;
            this.cbxMulticolor.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbxMulticolor.Checked = true;
            this.cbxMulticolor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxMulticolor.Location = new System.Drawing.Point(380, 6);
            this.cbxMulticolor.Name = "cbxMulticolor";
            this.cbxMulticolor.Size = new System.Drawing.Size(15, 14);
            this.cbxMulticolor.TabIndex = 6;
            this.cbxMulticolor.UseVisualStyleBackColor = true;
            // 
            // lblFault
            // 
            this.lblFault.AutoSize = true;
            this.lblFault.Location = new System.Drawing.Point(330, 6);
            this.lblFault.Name = "lblFault";
            this.lblFault.Size = new System.Drawing.Size(13, 13);
            this.lblFault.TabIndex = 5;
            this.lblFault.Text = "5";
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Location = new System.Drawing.Point(298, 6);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(13, 13);
            this.lblHint.TabIndex = 4;
            this.lblHint.Text = "8";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(230, 6);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(61, 13);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "01.01.2022";
            // 
            // lblDuree
            // 
            this.lblDuree.AutoSize = true;
            this.lblDuree.Location = new System.Drawing.Point(180, 6);
            this.lblDuree.Name = "lblDuree";
            this.lblDuree.Size = new System.Drawing.Size(40, 13);
            this.lblDuree.TabIndex = 2;
            this.lblDuree.Text = "999.99";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(130, 6);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(19, 13);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "25";
            // 
            // lblHintScore
            // 
            this.lblHintScore.AutoSize = true;
            this.lblHintScore.Location = new System.Drawing.Point(142, 46);
            this.lblHintScore.Name = "lblHintScore";
            this.lblHintScore.Size = new System.Drawing.Size(35, 13);
            this.lblHintScore.TabIndex = 2;
            this.lblHintScore.Text = "Score";
            // 
            // lblHintDate
            // 
            this.lblHintDate.AutoSize = true;
            this.lblHintDate.Location = new System.Drawing.Point(242, 46);
            this.lblHintDate.Name = "lblHintDate";
            this.lblHintDate.Size = new System.Drawing.Size(30, 13);
            this.lblHintDate.TabIndex = 4;
            this.lblHintDate.Text = "Date";
            // 
            // lblHintDuree
            // 
            this.lblHintDuree.AutoSize = true;
            this.lblHintDuree.Location = new System.Drawing.Point(192, 46);
            this.lblHintDuree.Name = "lblHintDuree";
            this.lblHintDuree.Size = new System.Drawing.Size(36, 13);
            this.lblHintDuree.TabIndex = 3;
            this.lblHintDuree.Text = "Durée";
            // 
            // lblHintHint
            // 
            this.lblHintHint.AutoSize = true;
            this.lblHintHint.Location = new System.Drawing.Point(310, 46);
            this.lblHintHint.Name = "lblHintHint";
            this.lblHintHint.Size = new System.Drawing.Size(26, 13);
            this.lblHintHint.TabIndex = 5;
            this.lblHintHint.Text = "Hint";
            // 
            // lblHintFault
            // 
            this.lblHintFault.AutoSize = true;
            this.lblHintFault.Location = new System.Drawing.Point(342, 46);
            this.lblHintFault.Name = "lblHintFault";
            this.lblHintFault.Size = new System.Drawing.Size(30, 13);
            this.lblHintFault.TabIndex = 6;
            this.lblHintFault.Text = "Fault";
            // 
            // lblHintMulticolor
            // 
            this.lblHintMulticolor.AutoSize = true;
            this.lblHintMulticolor.Location = new System.Drawing.Point(389, 46);
            this.lblHintMulticolor.Name = "lblHintMulticolor";
            this.lblHintMulticolor.Size = new System.Drawing.Size(52, 13);
            this.lblHintMulticolor.TabIndex = 7;
            this.lblHintMulticolor.Text = "Multicolor";
            // 
            // lblHintParticipant
            // 
            this.lblHintParticipant.AutoSize = true;
            this.lblHintParticipant.Location = new System.Drawing.Point(13, 46);
            this.lblHintParticipant.Name = "lblHintParticipant";
            this.lblHintParticipant.Size = new System.Drawing.Size(57, 13);
            this.lblHintParticipant.TabIndex = 1;
            this.lblHintParticipant.Text = "Participant";
            // 
            // HistoriqueGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(479, 292);
            this.Controls.Add(this.lblHintParticipant);
            this.Controls.Add(this.lblHintMulticolor);
            this.Controls.Add(this.pnlHistoric);
            this.Controls.Add(this.lblHintFault);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.lblHintHint);
            this.Controls.Add(this.lblHintScore);
            this.Controls.Add(this.lblHintDate);
            this.Controls.Add(this.lblHintDuree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HistoriqueGame";
            this.Text = "HistoriqueGame";
            this.pnlHistoric.ResumeLayout(false);
            this.pnlHistoric.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel pnlHistoric;
        private System.Windows.Forms.Label lblHintMulticolor;
        private System.Windows.Forms.Label lblHintFault;
        private System.Windows.Forms.Label lblHintHint;
        private System.Windows.Forms.Label lblHintDuree;
        private System.Windows.Forms.Label lblHintDate;
        private System.Windows.Forms.Label lblHintScore;
        private System.Windows.Forms.Label lblFault;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDuree;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.CheckBox cbxMulticolor;
        private System.Windows.Forms.Label lblHintParticipant;
        private System.Windows.Forms.ListBox lbxParticipant;
    }
}