
namespace Hanabi
{
    partial class HanabiGame
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
            _serverConnection.RemoveIncomingPacketHandler("HandHasChanged");
            _serverConnection.RemoveIncomingPacketHandler("Finish");
            _serverConnection.RemoveIncomingPacketHandler("monde");
            _serverConnection.RemoveIncomingPacketHandler("ReceiveHint");

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HanabiGame));
            this.pnlJoueur1 = new System.Windows.Forms.Panel();
            this.pnlJoueur4 = new System.Windows.Forms.Panel();
            this.pnlJoueur2 = new System.Windows.Forms.Panel();
            this.pnlJoueur3 = new System.Windows.Forms.Panel();
            this.pnlPoint = new System.Windows.Forms.Panel();
            this.pnlPioche = new System.Windows.Forms.Panel();
            this.pnlDefausse = new System.Windows.Forms.Panel();
            this.pnlEclair = new System.Windows.Forms.Panel();
            this.pnlIndice = new System.Windows.Forms.Panel();
            this.lblJoueur3 = new System.Windows.Forms.Label();
            this.lblJoueur1 = new System.Windows.Forms.Label();
            this.lblJoueur4 = new System.Windows.Forms.Label();
            this.btnHintNumber = new System.Windows.Forms.Button();
            this.btnHintColor = new System.Windows.Forms.Button();
            this.btnHint1 = new System.Windows.Forms.Button();
            this.btnHint2 = new System.Windows.Forms.Button();
            this.btnHint3 = new System.Windows.Forms.Button();
            this.btnHint4 = new System.Windows.Forms.Button();
            this.btnHint5 = new System.Windows.Forms.Button();
            this.pnlHintSender = new System.Windows.Forms.Panel();
            this.btnGiveUp = new System.Windows.Forms.Button();
            this.gbxHint = new System.Windows.Forms.GroupBox();
            this.lblJoueur2 = new System.Windows.Forms.Label();
            this.lblJoueur5 = new System.Windows.Forms.Label();
            this.pnlJoueur5 = new System.Windows.Forms.Panel();
            this.btnPlayCard = new System.Windows.Forms.Button();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblShowIndice = new System.Windows.Forms.Label();
            this.btnDisplayBoard = new System.Windows.Forms.Button();
            this.pnlHintSender.SuspendLayout();
            this.gbxHint.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlJoueur1
            // 
            this.pnlJoueur1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlJoueur1.BackColor = System.Drawing.Color.Transparent;
            this.pnlJoueur1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlJoueur1.Location = new System.Drawing.Point(400, 476);
            this.pnlJoueur1.Name = "pnlJoueur1";
            this.pnlJoueur1.Size = new System.Drawing.Size(300, 110);
            this.pnlJoueur1.TabIndex = 0;
            this.pnlJoueur1.Visible = false;
            // 
            // pnlJoueur4
            // 
            this.pnlJoueur4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlJoueur4.BackColor = System.Drawing.Color.Transparent;
            this.pnlJoueur4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlJoueur4.Enabled = false;
            this.pnlJoueur4.Location = new System.Drawing.Point(12, 175);
            this.pnlJoueur4.Name = "pnlJoueur4";
            this.pnlJoueur4.Size = new System.Drawing.Size(100, 300);
            this.pnlJoueur4.TabIndex = 13;
            this.pnlJoueur4.Visible = false;
            this.pnlJoueur4.Click += new System.EventHandler(this.PlayerName_Click);
            // 
            // pnlJoueur2
            // 
            this.pnlJoueur2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlJoueur2.BackColor = System.Drawing.Color.Transparent;
            this.pnlJoueur2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlJoueur2.Enabled = false;
            this.pnlJoueur2.Location = new System.Drawing.Point(575, 25);
            this.pnlJoueur2.Name = "pnlJoueur2";
            this.pnlJoueur2.Size = new System.Drawing.Size(300, 100);
            this.pnlJoueur2.TabIndex = 9;
            this.pnlJoueur2.Visible = false;
            this.pnlJoueur2.Click += new System.EventHandler(this.PlayerName_Click);
            // 
            // pnlJoueur3
            // 
            this.pnlJoueur3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pnlJoueur3.BackColor = System.Drawing.Color.Transparent;
            this.pnlJoueur3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlJoueur3.Enabled = false;
            this.pnlJoueur3.Location = new System.Drawing.Point(972, 175);
            this.pnlJoueur3.Name = "pnlJoueur3";
            this.pnlJoueur3.Size = new System.Drawing.Size(100, 300);
            this.pnlJoueur3.TabIndex = 7;
            this.pnlJoueur3.Visible = false;
            this.pnlJoueur3.Click += new System.EventHandler(this.PlayerName_Click);
            // 
            // pnlPoint
            // 
            this.pnlPoint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlPoint.BackColor = System.Drawing.Color.Transparent;
            this.pnlPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlPoint.Location = new System.Drawing.Point(400, 250);
            this.pnlPoint.Name = "pnlPoint";
            this.pnlPoint.Size = new System.Drawing.Size(300, 100);
            this.pnlPoint.TabIndex = 14;
            this.pnlPoint.Click += new System.EventHandler(this.PnlPoint_Click);
            this.pnlPoint.MouseHover += new System.EventHandler(this.PnlPoint_MouseHover);
            // 
            // pnlPioche
            // 
            this.pnlPioche.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlPioche.BackColor = System.Drawing.Color.Transparent;
            this.pnlPioche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPioche.Location = new System.Drawing.Point(334, 250);
            this.pnlPioche.Name = "pnlPioche";
            this.pnlPioche.Size = new System.Drawing.Size(60, 100);
            this.pnlPioche.TabIndex = 15;
            this.pnlPioche.MouseHover += new System.EventHandler(this.PnlPioche_MouseHover);
            // 
            // pnlDefausse
            // 
            this.pnlDefausse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlDefausse.BackColor = System.Drawing.Color.Transparent;
            this.pnlDefausse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDefausse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlDefausse.Location = new System.Drawing.Point(706, 250);
            this.pnlDefausse.Name = "pnlDefausse";
            this.pnlDefausse.Size = new System.Drawing.Size(60, 100);
            this.pnlDefausse.TabIndex = 16;
            this.pnlDefausse.Click += new System.EventHandler(this.PnlDefausse_Click);
            this.pnlDefausse.MouseHover += new System.EventHandler(this.PnlDefausse_MouseHover);
            // 
            // pnlEclair
            // 
            this.pnlEclair.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlEclair.BackColor = System.Drawing.Color.Transparent;
            this.pnlEclair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEclair.Location = new System.Drawing.Point(400, 356);
            this.pnlEclair.Name = "pnlEclair";
            this.pnlEclair.Size = new System.Drawing.Size(300, 30);
            this.pnlEclair.TabIndex = 18;
            this.pnlEclair.MouseHover += new System.EventHandler(this.PnlEclair_MouseHover);
            // 
            // pnlIndice
            // 
            this.pnlIndice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlIndice.BackColor = System.Drawing.Color.Transparent;
            this.pnlIndice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIndice.Location = new System.Drawing.Point(400, 214);
            this.pnlIndice.Name = "pnlIndice";
            this.pnlIndice.Size = new System.Drawing.Size(300, 30);
            this.pnlIndice.TabIndex = 17;
            this.pnlIndice.MouseHover += new System.EventHandler(this.PnlIndice_MouseHover);
            // 
            // lblJoueur3
            // 
            this.lblJoueur3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblJoueur3.AutoSize = true;
            this.lblJoueur3.BackColor = System.Drawing.Color.Transparent;
            this.lblJoueur3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblJoueur3.ForeColor = System.Drawing.Color.White;
            this.lblJoueur3.Location = new System.Drawing.Point(969, 478);
            this.lblJoueur3.Name = "lblJoueur3";
            this.lblJoueur3.Size = new System.Drawing.Size(55, 13);
            this.lblJoueur3.TabIndex = 6;
            this.lblJoueur3.Text = "lblJoueur3";
            this.lblJoueur3.Visible = false;
            this.lblJoueur3.Click += new System.EventHandler(this.PlayerName_Click);
            // 
            // lblJoueur1
            // 
            this.lblJoueur1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblJoueur1.AutoSize = true;
            this.lblJoueur1.BackColor = System.Drawing.Color.Transparent;
            this.lblJoueur1.Enabled = false;
            this.lblJoueur1.ForeColor = System.Drawing.Color.White;
            this.lblJoueur1.Location = new System.Drawing.Point(400, 589);
            this.lblJoueur1.Name = "lblJoueur1";
            this.lblJoueur1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblJoueur1.Size = new System.Drawing.Size(55, 13);
            this.lblJoueur1.TabIndex = 1;
            this.lblJoueur1.Text = "lblJoueur1";
            this.lblJoueur1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblJoueur1.Visible = false;
            // 
            // lblJoueur4
            // 
            this.lblJoueur4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblJoueur4.AutoSize = true;
            this.lblJoueur4.BackColor = System.Drawing.Color.Transparent;
            this.lblJoueur4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblJoueur4.ForeColor = System.Drawing.Color.White;
            this.lblJoueur4.Location = new System.Drawing.Point(9, 478);
            this.lblJoueur4.Name = "lblJoueur4";
            this.lblJoueur4.Size = new System.Drawing.Size(55, 13);
            this.lblJoueur4.TabIndex = 12;
            this.lblJoueur4.Text = "lblJoueur4";
            this.lblJoueur4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblJoueur4.Visible = false;
            this.lblJoueur4.Click += new System.EventHandler(this.PlayerName_Click);
            // 
            // btnHintNumber
            // 
            this.btnHintNumber.ForeColor = System.Drawing.Color.Black;
            this.btnHintNumber.Location = new System.Drawing.Point(4, 19);
            this.btnHintNumber.Name = "btnHintNumber";
            this.btnHintNumber.Size = new System.Drawing.Size(54, 23);
            this.btnHintNumber.TabIndex = 0;
            this.btnHintNumber.Text = "Nombre";
            this.btnHintNumber.UseVisualStyleBackColor = true;
            this.btnHintNumber.Click += new System.EventHandler(this.BtnHintNumber_Click);
            // 
            // btnHintColor
            // 
            this.btnHintColor.ForeColor = System.Drawing.Color.Black;
            this.btnHintColor.Location = new System.Drawing.Point(64, 19);
            this.btnHintColor.Name = "btnHintColor";
            this.btnHintColor.Size = new System.Drawing.Size(53, 23);
            this.btnHintColor.TabIndex = 1;
            this.btnHintColor.Text = "Couleur";
            this.btnHintColor.UseVisualStyleBackColor = true;
            this.btnHintColor.Click += new System.EventHandler(this.BtnHintColor_Click);
            // 
            // btnHint1
            // 
            this.btnHint1.ForeColor = System.Drawing.Color.Black;
            this.btnHint1.Location = new System.Drawing.Point(4, 7);
            this.btnHint1.Name = "btnHint1";
            this.btnHint1.Size = new System.Drawing.Size(28, 23);
            this.btnHint1.TabIndex = 0;
            this.btnHint1.Text = "btnHint1";
            this.btnHint1.UseVisualStyleBackColor = true;
            this.btnHint1.Visible = false;
            this.btnHint1.Click += new System.EventHandler(this.SendHint_Click);
            // 
            // btnHint2
            // 
            this.btnHint2.ForeColor = System.Drawing.Color.Black;
            this.btnHint2.Location = new System.Drawing.Point(38, 7);
            this.btnHint2.Name = "btnHint2";
            this.btnHint2.Size = new System.Drawing.Size(28, 23);
            this.btnHint2.TabIndex = 1;
            this.btnHint2.Text = "btnHint2";
            this.btnHint2.UseVisualStyleBackColor = true;
            this.btnHint2.Visible = false;
            this.btnHint2.Click += new System.EventHandler(this.SendHint_Click);
            // 
            // btnHint3
            // 
            this.btnHint3.ForeColor = System.Drawing.Color.Black;
            this.btnHint3.Location = new System.Drawing.Point(72, 7);
            this.btnHint3.Name = "btnHint3";
            this.btnHint3.Size = new System.Drawing.Size(28, 23);
            this.btnHint3.TabIndex = 2;
            this.btnHint3.Text = "btnHint3";
            this.btnHint3.UseVisualStyleBackColor = true;
            this.btnHint3.Visible = false;
            this.btnHint3.Click += new System.EventHandler(this.SendHint_Click);
            // 
            // btnHint4
            // 
            this.btnHint4.ForeColor = System.Drawing.Color.Black;
            this.btnHint4.Location = new System.Drawing.Point(106, 7);
            this.btnHint4.Name = "btnHint4";
            this.btnHint4.Size = new System.Drawing.Size(28, 23);
            this.btnHint4.TabIndex = 3;
            this.btnHint4.Text = "btnHint4";
            this.btnHint4.UseVisualStyleBackColor = true;
            this.btnHint4.Visible = false;
            this.btnHint4.Click += new System.EventHandler(this.SendHint_Click);
            // 
            // btnHint5
            // 
            this.btnHint5.ForeColor = System.Drawing.Color.Black;
            this.btnHint5.Location = new System.Drawing.Point(140, 7);
            this.btnHint5.Name = "btnHint5";
            this.btnHint5.Size = new System.Drawing.Size(28, 23);
            this.btnHint5.TabIndex = 4;
            this.btnHint5.Text = "btnHint5";
            this.btnHint5.UseVisualStyleBackColor = true;
            this.btnHint5.Visible = false;
            this.btnHint5.Click += new System.EventHandler(this.SendHint_Click);
            // 
            // pnlHintSender
            // 
            this.pnlHintSender.Controls.Add(this.btnHint1);
            this.pnlHintSender.Controls.Add(this.btnHint5);
            this.pnlHintSender.Controls.Add(this.btnHint2);
            this.pnlHintSender.Controls.Add(this.btnHint3);
            this.pnlHintSender.Controls.Add(this.btnHint4);
            this.pnlHintSender.Location = new System.Drawing.Point(4, 43);
            this.pnlHintSender.Name = "pnlHintSender";
            this.pnlHintSender.Size = new System.Drawing.Size(172, 33);
            this.pnlHintSender.TabIndex = 2;
            // 
            // btnGiveUp
            // 
            this.btnGiveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGiveUp.ForeColor = System.Drawing.Color.Red;
            this.btnGiveUp.Location = new System.Drawing.Point(7, 584);
            this.btnGiveUp.Name = "btnGiveUp";
            this.btnGiveUp.Size = new System.Drawing.Size(75, 23);
            this.btnGiveUp.TabIndex = 21;
            this.btnGiveUp.Text = "Abandonner";
            this.btnGiveUp.UseVisualStyleBackColor = true;
            this.btnGiveUp.Click += new System.EventHandler(this.BtnGiveUp_Click);
            // 
            // gbxHint
            // 
            this.gbxHint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gbxHint.BackColor = System.Drawing.Color.Transparent;
            this.gbxHint.Controls.Add(this.pnlHintSender);
            this.gbxHint.Controls.Add(this.btnHintNumber);
            this.gbxHint.Controls.Add(this.btnHintColor);
            this.gbxHint.ForeColor = System.Drawing.Color.White;
            this.gbxHint.Location = new System.Drawing.Point(12, 494);
            this.gbxHint.Name = "gbxHint";
            this.gbxHint.Size = new System.Drawing.Size(181, 84);
            this.gbxHint.TabIndex = 5;
            this.gbxHint.TabStop = false;
            this.gbxHint.Text = "Donner un indice a ";
            this.gbxHint.Visible = false;
            // 
            // lblJoueur2
            // 
            this.lblJoueur2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblJoueur2.AutoSize = true;
            this.lblJoueur2.BackColor = System.Drawing.Color.Transparent;
            this.lblJoueur2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblJoueur2.ForeColor = System.Drawing.Color.White;
            this.lblJoueur2.Location = new System.Drawing.Point(820, 9);
            this.lblJoueur2.Name = "lblJoueur2";
            this.lblJoueur2.Size = new System.Drawing.Size(55, 13);
            this.lblJoueur2.TabIndex = 8;
            this.lblJoueur2.Text = "lblJoueur2";
            this.lblJoueur2.Visible = false;
            this.lblJoueur2.Click += new System.EventHandler(this.PlayerName_Click);
            // 
            // lblJoueur5
            // 
            this.lblJoueur5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblJoueur5.AutoSize = true;
            this.lblJoueur5.BackColor = System.Drawing.Color.Transparent;
            this.lblJoueur5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblJoueur5.ForeColor = System.Drawing.Color.White;
            this.lblJoueur5.Location = new System.Drawing.Point(222, 9);
            this.lblJoueur5.Name = "lblJoueur5";
            this.lblJoueur5.Size = new System.Drawing.Size(55, 13);
            this.lblJoueur5.TabIndex = 10;
            this.lblJoueur5.Text = "lblJoueur5";
            this.lblJoueur5.Visible = false;
            this.lblJoueur5.Click += new System.EventHandler(this.PlayerName_Click);
            // 
            // pnlJoueur5
            // 
            this.pnlJoueur5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlJoueur5.BackColor = System.Drawing.Color.Transparent;
            this.pnlJoueur5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlJoueur5.Enabled = false;
            this.pnlJoueur5.Location = new System.Drawing.Point(225, 25);
            this.pnlJoueur5.Name = "pnlJoueur5";
            this.pnlJoueur5.Size = new System.Drawing.Size(300, 100);
            this.pnlJoueur5.TabIndex = 11;
            this.pnlJoueur5.Visible = false;
            // 
            // btnPlayCard
            // 
            this.btnPlayCard.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPlayCard.ForeColor = System.Drawing.Color.Black;
            this.btnPlayCard.Location = new System.Drawing.Point(706, 563);
            this.btnPlayCard.Name = "btnPlayCard";
            this.btnPlayCard.Size = new System.Drawing.Size(103, 23);
            this.btnPlayCard.TabIndex = 2;
            this.btnPlayCard.Text = "Jouer la carte";
            this.btnPlayCard.UseVisualStyleBackColor = true;
            this.btnPlayCard.Visible = false;
            this.btnPlayCard.Click += new System.EventHandler(this.BtnPlayCard_Click);
            // 
            // btnDiscard
            // 
            this.btnDiscard.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDiscard.ForeColor = System.Drawing.Color.Black;
            this.btnDiscard.Location = new System.Drawing.Point(815, 563);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(112, 23);
            this.btnDiscard.TabIndex = 3;
            this.btnDiscard.Text = "Défausser la carte";
            this.btnDiscard.UseVisualStyleBackColor = true;
            this.btnDiscard.Visible = false;
            this.btnDiscard.Click += new System.EventHandler(this.BtnDiscard_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(933, 563);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lblShowIndice
            // 
            this.lblShowIndice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblShowIndice.AutoSize = true;
            this.lblShowIndice.BackColor = System.Drawing.Color.Transparent;
            this.lblShowIndice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowIndice.ForeColor = System.Drawing.Color.White;
            this.lblShowIndice.Location = new System.Drawing.Point(450, 391);
            this.lblShowIndice.Name = "lblShowIndice";
            this.lblShowIndice.Size = new System.Drawing.Size(201, 16);
            this.lblShowIndice.TabIndex = 19;
            this.lblShowIndice.Text = "XXX a envoyé l\'indice XXX à XXX";
            this.lblShowIndice.Visible = false;
            // 
            // btnDisplayBoard
            // 
            this.btnDisplayBoard.BackColor = System.Drawing.Color.Transparent;
            this.btnDisplayBoard.BackgroundImage = global::Hanabi.Properties.Resources.interrogation;
            this.btnDisplayBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDisplayBoard.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDisplayBoard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDisplayBoard.ForeColor = System.Drawing.Color.Transparent;
            this.btnDisplayBoard.Location = new System.Drawing.Point(1030, 9);
            this.btnDisplayBoard.Margin = new System.Windows.Forms.Padding(0);
            this.btnDisplayBoard.Name = "btnDisplayBoard";
            this.btnDisplayBoard.Size = new System.Drawing.Size(40, 40);
            this.btnDisplayBoard.TabIndex = 20;
            this.btnDisplayBoard.UseVisualStyleBackColor = false;
            this.btnDisplayBoard.Visible = false;
            this.btnDisplayBoard.Click += new System.EventHandler(this.BtnDisplayBoard_Click);
            // 
            // HanabiGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = global::Hanabi.Properties.Resources.backGround;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1084, 611);
            this.Controls.Add(this.btnDisplayBoard);
            this.Controls.Add(this.lblShowIndice);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDiscard);
            this.Controls.Add(this.btnPlayCard);
            this.Controls.Add(this.lblJoueur5);
            this.Controls.Add(this.gbxHint);
            this.Controls.Add(this.pnlJoueur5);
            this.Controls.Add(this.btnGiveUp);
            this.Controls.Add(this.lblJoueur4);
            this.Controls.Add(this.lblJoueur1);
            this.Controls.Add(this.lblJoueur3);
            this.Controls.Add(this.lblJoueur2);
            this.Controls.Add(this.pnlEclair);
            this.Controls.Add(this.pnlDefausse);
            this.Controls.Add(this.pnlPioche);
            this.Controls.Add(this.pnlPoint);
            this.Controls.Add(this.pnlJoueur3);
            this.Controls.Add(this.pnlJoueur2);
            this.Controls.Add(this.pnlJoueur4);
            this.Controls.Add(this.pnlJoueur1);
            this.Controls.Add(this.pnlIndice);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HanabiGame";
            this.Text = "HanabiGame";
            this.pnlHintSender.ResumeLayout(false);
            this.gbxHint.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlJoueur1;
        private System.Windows.Forms.Panel pnlJoueur4;
        private System.Windows.Forms.Panel pnlJoueur2;
        private System.Windows.Forms.Panel pnlJoueur3;
        private System.Windows.Forms.Panel pnlPoint;
        private System.Windows.Forms.Panel pnlPioche;
        private System.Windows.Forms.Panel pnlDefausse;
        private System.Windows.Forms.Panel pnlEclair;
        private System.Windows.Forms.Panel pnlIndice;
        private System.Windows.Forms.Label lblJoueur3;
        private System.Windows.Forms.Label lblJoueur1;
        private System.Windows.Forms.Label lblJoueur4;
        private System.Windows.Forms.Button btnHintNumber;
        private System.Windows.Forms.Button btnHintColor;
        private System.Windows.Forms.Button btnHint1;
        private System.Windows.Forms.Button btnHint2;
        private System.Windows.Forms.Button btnHint3;
        private System.Windows.Forms.Button btnHint4;
        private System.Windows.Forms.Button btnHint5;
        private System.Windows.Forms.Panel pnlHintSender;
        private System.Windows.Forms.Button btnGiveUp;
        private System.Windows.Forms.GroupBox gbxHint;
        private System.Windows.Forms.Label lblJoueur2;
        private System.Windows.Forms.Label lblJoueur5;
        private System.Windows.Forms.Panel pnlJoueur5;
        private System.Windows.Forms.Button btnPlayCard;
        private System.Windows.Forms.Button btnDiscard;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblShowIndice;
        private System.Windows.Forms.Button btnDisplayBoard;
    }
}