
namespace Hanabi
{
    partial class Index
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.lblBienvenue = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblPseudo = new System.Windows.Forms.Label();
            this.tbxPseudo = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.pnlAdresseIP = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fourth = new System.Windows.Forms.MaskedTextBox();
            this.third = new System.Windows.Forms.MaskedTextBox();
            this.second = new System.Windows.Forms.MaskedTextBox();
            this.first = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblRequierd2 = new System.Windows.Forms.Label();
            this.lblRequierd1 = new System.Windows.Forms.Label();
            this.btnLoopback = new System.Windows.Forms.Button();
            this.pnlAdresseIP.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBienvenue
            // 
            this.lblBienvenue.AutoSize = true;
            this.lblBienvenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenue.Location = new System.Drawing.Point(3, 9);
            this.lblBienvenue.Name = "lblBienvenue";
            this.lblBienvenue.Size = new System.Drawing.Size(268, 29);
            this.lblBienvenue.TabIndex = 0;
            this.lblBienvenue.Text = "Bienvenue sur Hanabi";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 189);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(247, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Démarrer";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblPseudo
            // 
            this.lblPseudo.AutoSize = true;
            this.lblPseudo.Location = new System.Drawing.Point(12, 99);
            this.lblPseudo.Name = "lblPseudo";
            this.lblPseudo.Size = new System.Drawing.Size(109, 13);
            this.lblPseudo.TabIndex = 5;
            this.lblPseudo.Text = "Entrez votre Pseudo :";
            // 
            // tbxPseudo
            // 
            this.tbxPseudo.Location = new System.Drawing.Point(12, 115);
            this.tbxPseudo.MaxLength = 15;
            this.tbxPseudo.Name = "tbxPseudo";
            this.tbxPseudo.Size = new System.Drawing.Size(247, 20);
            this.tbxPseudo.TabIndex = 7;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 141);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(247, 25);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connexion";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // pnlAdresseIP
            // 
            this.pnlAdresseIP.BackColor = System.Drawing.Color.White;
            this.pnlAdresseIP.Controls.Add(this.label5);
            this.pnlAdresseIP.Controls.Add(this.label4);
            this.pnlAdresseIP.Controls.Add(this.label3);
            this.pnlAdresseIP.Controls.Add(this.fourth);
            this.pnlAdresseIP.Controls.Add(this.third);
            this.pnlAdresseIP.Controls.Add(this.second);
            this.pnlAdresseIP.Controls.Add(this.first);
            this.pnlAdresseIP.Location = new System.Drawing.Point(12, 60);
            this.pnlAdresseIP.Name = "pnlAdresseIP";
            this.pnlAdresseIP.Size = new System.Drawing.Size(169, 25);
            this.pnlAdresseIP.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(122, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = ".";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = ".";
            // 
            // fourth
            // 
            this.fourth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fourth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fourth.Location = new System.Drawing.Point(140, 7);
            this.fourth.Mask = "099";
            this.fourth.Name = "fourth";
            this.fourth.Size = new System.Drawing.Size(23, 15);
            this.fourth.TabIndex = 6;
            this.fourth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fourth_KeyDown);
            this.fourth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fourth_KeyUp);
            // 
            // third
            // 
            this.third.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.third.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.third.Location = new System.Drawing.Point(93, 7);
            this.third.Mask = "099";
            this.third.Name = "third";
            this.third.Size = new System.Drawing.Size(23, 15);
            this.third.TabIndex = 4;
            this.third.KeyDown += new System.Windows.Forms.KeyEventHandler(this.third_KeyDown);
            this.third.KeyUp += new System.Windows.Forms.KeyEventHandler(this.third_KeyUp);
            // 
            // second
            // 
            this.second.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.second.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.second.Location = new System.Drawing.Point(46, 7);
            this.second.Mask = "099";
            this.second.Name = "second";
            this.second.Size = new System.Drawing.Size(23, 15);
            this.second.TabIndex = 2;
            this.second.KeyDown += new System.Windows.Forms.KeyEventHandler(this.second_KeyDown);
            this.second.KeyUp += new System.Windows.Forms.KeyEventHandler(this.second_KeyUp);
            // 
            // first
            // 
            this.first.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.first.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.first.Location = new System.Drawing.Point(4, 7);
            this.first.Mask = "099";
            this.first.Name = "first";
            this.first.Size = new System.Drawing.Size(23, 15);
            this.first.TabIndex = 0;
            this.first.KeyDown += new System.Windows.Forms.KeyEventHandler(this.first_KeyDown);
            this.first.KeyUp += new System.Windows.Forms.KeyEventHandler(this.first_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Entrez l\'adresse IP du serveur :";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(12, 173);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(45, 13);
            this.lblError.TabIndex = 9;
            this.lblError.Text = "lblErreur";
            this.lblError.Visible = false;
            // 
            // lblRequierd2
            // 
            this.lblRequierd2.AutoSize = true;
            this.lblRequierd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequierd2.ForeColor = System.Drawing.Color.Red;
            this.lblRequierd2.Location = new System.Drawing.Point(118, 99);
            this.lblRequierd2.Name = "lblRequierd2";
            this.lblRequierd2.Size = new System.Drawing.Size(13, 16);
            this.lblRequierd2.TabIndex = 6;
            this.lblRequierd2.Text = "*";
            // 
            // lblRequierd1
            // 
            this.lblRequierd1.AutoSize = true;
            this.lblRequierd1.BackColor = System.Drawing.Color.Transparent;
            this.lblRequierd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequierd1.ForeColor = System.Drawing.Color.Red;
            this.lblRequierd1.Location = new System.Drawing.Point(162, 38);
            this.lblRequierd1.Name = "lblRequierd1";
            this.lblRequierd1.Size = new System.Drawing.Size(13, 16);
            this.lblRequierd1.TabIndex = 2;
            this.lblRequierd1.Text = "*";
            // 
            // btnLoopback
            // 
            this.btnLoopback.Location = new System.Drawing.Point(184, 60);
            this.btnLoopback.Name = "btnLoopback";
            this.btnLoopback.Size = new System.Drawing.Size(75, 23);
            this.btnLoopback.TabIndex = 4;
            this.btnLoopback.Text = "Loopback";
            this.btnLoopback.UseVisualStyleBackColor = true;
            this.btnLoopback.Click += new System.EventHandler(this.btnLoopback_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 222);
            this.Controls.Add(this.btnLoopback);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBienvenue);
            this.Controls.Add(this.pnlAdresseIP);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbxPseudo);
            this.Controls.Add(this.lblPseudo);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblRequierd2);
            this.Controls.Add(this.lblRequierd1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Index";
            this.Text = "Hanabi";
            this.pnlAdresseIP.ResumeLayout(false);
            this.pnlAdresseIP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenue;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblPseudo;
        private System.Windows.Forms.TextBox tbxPseudo;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Panel pnlAdresseIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox fourth;
        private System.Windows.Forms.MaskedTextBox third;
        private System.Windows.Forms.MaskedTextBox second;
        private System.Windows.Forms.MaskedTextBox first;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblRequierd2;
        private System.Windows.Forms.Label lblRequierd1;
        private System.Windows.Forms.Button btnLoopback;
    }
}

