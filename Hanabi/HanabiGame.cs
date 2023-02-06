using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using classHanabi;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet;

namespace Hanabi
{
    public partial class HanabiGame : Form
    {
        private Game game;
        private Connection _serverConnection;

        private PictureBox selectedCard;
        private Card usedCard;

        private Player myself;
        private Player hintReceiver;

        private Size cardSize;
        private List<Control> symbol;

        public HanabiGame()
        {
            InitializeComponent();
        }

        public HanabiGame(Connection serveurConnection, string strgame)
        {
            InitializeComponent();
            cardSize = new Size(60, 100);
            _serverConnection = serveurConnection;

            game = JsonConvert.DeserializeObject<Game>(strgame);
            _serverConnection.AppendIncomingPacketHandler<string>("monde", ReceiveGame);
            _serverConnection.AppendIncomingPacketHandler<string>("ReceiveHint", ReceiveHint);
            _serverConnection.AppendIncomingPacketHandler<string>("HandHasChanged", ReiceiveRedrawHand);
            _serverConnection.AppendIncomingPacketHandler<int>("Finish", ShowFinish);

            myself = game.Players[0];
            symbol = new List<Control>();
            foreach (Card card in myself.Hand)
            {
                symbol.Add(DrawUserSymbole(card));
            }
            DisplayBoard();

            lblShowIndice.Visible = true;
            lblShowIndice.Text = "C'est au tour de " + game.CurrentUser.Name + " de jouer";

            //Affiche les mains de chaque joueur
            int playerInList = 1;
            foreach (Player player in game.Players)
            {
                string strPanel = "pnlJoueur" + playerInList;
                this.Controls[strPanel].Visible = true;
                this.Controls[strPanel].Tag = player;

                if (playerInList == 1)
                {
                    this.Controls[strPanel].Controls.AddRange(DisplayHidenCard(player).ToArray());
                }
                else
                {
                    this.Controls[strPanel].Controls.AddRange(ShowPlayerHand(player, playerInList).ToArray());
                }

                string strLabel = "lblJoueur" + playerInList;
                this.Controls[strLabel].Text = player.Name;
                this.Controls[strLabel].Visible = true;
                this.Controls[strLabel].Tag = player;
                this.Controls[strLabel].ForeColor = Color.White;
                this.Controls[strLabel].BackColor = Color.Transparent;

                if (game.CurrentUser.Connection == player.Connection && player.TurnToPlay)
                {
                    this.Controls[strLabel].ForeColor = Color.Black;
                    this.Controls[strLabel].BackColor = Color.White;
                }
                playerInList++;
            }

            pnlPioche.Controls.Add(ShowDrawPill());
            pnlIndice.Controls.AddRange(DrawHint().ToArray());
        }

        /// <summary>
        /// Change le nom des différents panel en fonction de la disposition du terrain
        /// </summary>
        private void DisplayBoard()
        {
            if (game.Players.Count < 5)
            {
                pnlJoueur2.Location = new Point(pnlJoueur1.Location.X, 22);
                lblJoueur2.Location = new Point(pnlJoueur2.Right - lblJoueur2.Width, 6);
                if (game.Players.Count > 2)
                {
                    pnlJoueur2.Name = "pnlJoueur3";
                    pnlJoueur3.Name = "pnlJoueur2";

                    lblJoueur2.Name = "lblJoueur3";
                    lblJoueur3.Name = "lblJoueur2";
                }
            }
            else
            {
                pnlJoueur2.Name = "pnlJoueur3";
                pnlJoueur3.Name = "pnlJoueur2";
                pnlJoueur4.Name = "pnlJoueur5";
                pnlJoueur5.Name = "pnlJoueur4";

                lblJoueur2.Name = "lblJoueur3";
                lblJoueur3.Name = "lblJoueur2";
                lblJoueur4.Name = "lblJoueur5";
                lblJoueur5.Name = "lblJoueur4";
            }

        }

        #region Game Action

        /// <summary>
        /// deux possibilité
        /// Clique gauche avec la souris :
        ///     Séléctionne une carte
        ///     et la met en évidence
        /// Clique droit avec la souris
        ///     Si une carte est séléctionner
        ///     Elle est changéde place en fonctione de sa position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardClick(Object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                if (selectedCard != null)
                {
                    int cursorPosition = me.X + ((Control)sender).Left;
                    ChangeCardPosition(cursorPosition);
                    CardIsUsed();
                }
            }
            if (me.Button == MouseButtons.Left)
            {
                gbxHint.Visible = false;
                if (selectedCard != null)
                {
                    CardIsUsed();
                }
                selectedCard = sender as PictureBox;
                selectedCard.BorderStyle = BorderStyle.None;
                usedCard = selectedCard.Tag as Card;
                selectedCard.Location = new Point(selectedCard.Location.X, 0);

                btnPlayCard.Visible = true;
                btnPlayCard.Location = new Point(pnlJoueur1.Right + 5, pnlJoueur1.Bottom - btnPlayCard.Height);
                btnDiscard.Visible = true;
                btnDiscard.Location = new Point(btnPlayCard.Right + 5, pnlJoueur1.Bottom - btnPlayCard.Height);
                btnCancel.Visible = true;
                btnCancel.Location = new Point(btnDiscard.Right + 5, pnlJoueur1.Bottom - btnPlayCard.Height);
            }
        }

        /// <summary>
        /// Envoie au serveur que les joueurs abandonne la partie
        /// Demande une confirmation avant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGiveUp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Etes vous sur de vouloir abandonner", "Abandonner", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _serverConnection.SendObject("GiveUp", true);
            }
            else
            { }
        }

        /// <summary>
        /// Envoie la nouvelle position de la carte séléctionné au serveur 
        /// En fonction d'ou se trouve le curseur
        /// </summary>
        /// <param name="cursorPosition"></param>
        private void ChangeCardPosition(int cursorPosition)
        {
            int personne = 0;

            if (cursorPosition >= 0 && cursorPosition <= 29)
                personne = 0;
            if (cursorPosition >= 30 && cursorPosition <= 89)
                personne = 1;
            if (cursorPosition >= 90 && cursorPosition <= 149)
                personne = 2;
            if (cursorPosition >= 150 && cursorPosition <= 209)
                personne = 3;
            if (cursorPosition >= 210 && cursorPosition <= 269)
                personne = 4;
            if (cursorPosition >= 270 && cursorPosition <= 300)
                personne = 5;

            string[] info = new string[2] { JsonConvert.SerializeObject(usedCard), personne.ToString() };
            _serverConnection.SendObject("HandChangePosition", JsonConvert.SerializeObject(info));
        }

        /// <summary>
        /// Si une carte est séléctionner
        /// et que l'utilisateur appuie sur la zone de point
        /// La carte est joué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PnlPoint_Click(object sender, EventArgs e)
        {
            if (usedCard != null)
            {
                _serverConnection.SendObject<string>("PlayCard", JsonConvert.SerializeObject(usedCard));
                CardIsUsed();
            }
        }

        /// <summary>
        /// Dès qu'une action est faites avec une carte
        /// Elle est deséléctionné
        /// </summary>
        private void CardIsUsed()
        {
            usedCard = null;
            if (selectedCard != null)
            {
                selectedCard.BorderStyle = BorderStyle.FixedSingle;
                selectedCard.Location = new Point(selectedCard.Location.X, 10);
            }
            btnPlayCard.Visible = false;
            btnDiscard.Visible = false;
            btnCancel.Visible = false;
            selectedCard = null;
        }

        /// <summary>
        /// Si une carte est séléctionne
        /// et que l'utilisateur click sur la pile
        /// l'actionne défausser est envoyé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PnlDefausse_Click(object sender, EventArgs e)
        {
            if (usedCard != null)
            {
                _serverConnection.SendObject<string>("DiscardCard", JsonConvert.SerializeObject(usedCard));
                CardIsUsed();
            }
        }

        /// <summary>
        /// après avoir séléctionner le type d'indice
        /// un message au serveur est envoyé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendHint_Click(Object sender, EventArgs e)
        {
            gbxHint.Visible = false;

            string hintSender = JsonConvert.SerializeObject(myself);
            string receiver = JsonConvert.SerializeObject(hintReceiver);
            string parameterToSend = (sender as Control).Tag.ToString();

            string[] tableSend = new string[] { hintSender, receiver, parameterToSend };
            string send = JsonConvert.SerializeObject(tableSend);

            _serverConnection.SendObject("SendHint", send);
        }

        /// <summary>
        /// Une fois la partie fini, le score final est affiché
        /// </summary>
        /// <param name="header"></param>
        /// <param name="connection"></param>
        /// <param name="iPoint"></param>
        private void ShowFinish(PacketHeader header, Connection connection, int iPoint)
        {
            endGame endgame = new endGame(iPoint);
            this.Invoke(new MethodInvoker(delegate
            {
                pnlJoueur1.Controls.Clear();
                pnlJoueur1.Controls.AddRange(ShowPlayerHand(myself, 1).ToArray());
                
                foreach (Control control in this.Controls)
                {
                    control.Enabled = false;
                }

                btnDisplayBoard.Enabled = true;
                btnDisplayBoard.Visible = true;

                endgame.TopLevel = false;
                endgame.Location = new Point(this.Width / 2 - endgame.Width / 2, pnlIndice.Location.Y - 5);
                endgame.Show();
                this.Controls.Add(endgame);
                endgame.BringToFront();

                btnDisplayBoard.Tag = endgame;
            }));
        }

        /// <summary>
        /// Fait les meme action que si l'on appuyait sur la zone de point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlayCard_Click(object sender, EventArgs e)
        {
            if (usedCard != null)
            {
                PnlPoint_Click(sender, e);
            }
            CardIsUsed();
        }

        /// <summary>
        /// Fait les meme action que si l'on appuyait sur la pile de défausse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDiscard_Click(object sender, EventArgs e)
        {
            if (usedCard != null)
            {
                PnlDefausse_Click(sender, e);
            }
            CardIsUsed();
        }

        /// <summary>
        /// Déséléctionne la carte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CardIsUsed();
        }

        #endregion

        #region Game Display
        /// <summary>
        /// Reçois la partie par le serveur
        /// </summary>
        /// <param name="header"></param>
        /// <param name="connection"></param>
        /// <param name="strGame"></param>
        private void ReceiveGame(PacketHeader header, Connection connection, string strGame)
        {
            game = JsonConvert.DeserializeObject<Game>(strGame);
            myself = game.Players[0];
            this.Invoke(new MethodInvoker(delegate
            {
                DrawGame();
            }));
        }

        /// <summary>
        /// Affiche dans les différents panel les cartes qui doivent y etre
        /// </summary>
        private void DrawGame()
        {
            pnlJoueur1.Controls.Clear();
            pnlPioche.Controls.Clear();
            pnlPoint.Controls.Clear();
            pnlDefausse.Controls.Clear();
            pnlIndice.Controls.Clear();

            if (game.CurrentUser != null)
            {
                lblShowIndice.Text = "C'est au tour de " + game.CurrentUser.Name + " de jouer";
                lblShowIndice.Location = new Point(this.Width / 2 - lblShowIndice.Width / 2, lblShowIndice.Location.Y);
            }
            else
            {
                lblShowIndice.Visible = false;
            }

            gbxHint.Visible = false;

            int playerInList = 1;
            //Affiche les mains de chaque joueur
            foreach (Player player in game.Players)
            {
                string strLabel = "lblJoueur" + playerInList;
                string strPanel = "pnlJoueur" + playerInList;

                this.Controls[strPanel].Controls.Clear();
                if (playerInList == 1)
                {
                    this.Controls[strPanel].Controls.AddRange(DisplayHidenCard(player).ToArray());
                }
                else
                {
                    this.Controls[strPanel].Controls.AddRange(ShowPlayerHand(player, playerInList).ToArray());
                }

                this.Controls[strLabel].ForeColor = Color.White;
                this.Controls[strLabel].BackColor = Color.Transparent;
                this.Controls[strLabel].Tag = player;
                if (game.CurrentUser != null && game.CurrentUser.Connection == player.Connection && player.TurnToPlay)
                {
                    this.Controls[strLabel].BackColor = Color.White;
                    this.Controls[strLabel].ForeColor = Color.Black;
                }
                playerInList++;
            }
            pnlIndice.Controls.AddRange(DrawHint().ToArray());
            pnlEclair.Controls.AddRange(DrawError().ToArray());
            pnlPioche.Controls.Add(ShowDrawPill());
            pnlPoint.Controls.AddRange(DrawPointPill().ToArray());
            pnlDefausse.Controls.Add(DrawDiscardPill());
        }

        /// <summary>
        /// Créer la picture box qui affichera la zone de pioche
        /// </summary>
        /// <returns></returns>
        private Control ShowDrawPill()
        {
            PictureBox drawPill = new PictureBox();
            drawPill.Image = DisplayDrawCard(game.DrawPile.Count());
            drawPill.MouseHover += new EventHandler(PnlPioche_MouseHover);
            drawPill.Size = cardSize;
            return drawPill;
        }

        /// <summary>
        /// Créer la liste de cartes qui sera affiché
        /// Ici les cartes seront déssiné face non caché
        /// </summary>
        /// <param name="player"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        private List<Control> ShowPlayerHand(Player player, int position)
        {
            List<Control> affichage = new List<Control>();
            int handPosition = 0;
            foreach (Card card in player.Hand)
            {
                PictureBox drawCard = new PictureBox();
                drawCard.Tag = card;
                drawCard.Image = DiplayHandCards(card.Color, card.Number, position);
                if (position == 1 || position == 2 && game.Players.Count == 2 || position == 3 || position == 4 && game.Players.Count == 5)
                {
                    drawCard.Size = cardSize;
                    drawCard.Location = new Point(handPosition * cardSize.Width, 0);
                }
                if (position == 2 && game.Players.Count >= 3 || position == 4 && game.Players.Count == 4 || position == 5)
                {
                    drawCard.Size = new Size(cardSize.Height, cardSize.Width);
                    drawCard.Location = new Point(0, handPosition * cardSize.Width);
                }
                drawCard.BorderStyle = BorderStyle.FixedSingle;
                drawCard.Click += new EventHandler(CardClick);

                affichage.Add(drawCard);
                handPosition++;
            }
            return affichage;
        }

        /// <summary>
        /// Crée visuellement une carte vu de face avec son numero et sa couleur
        /// </summary>
        /// <source href="https://stackoverflow.com/questions/6311545/c-sharp-write-text-on-bitmap">Afficher du texte dans une image</source>
        /// <param name="color">Couleur de la carte</param>
        /// <param name="number">Numero qui y apparaitra</param>
        /// <returns></returns>
        private Image DiplayHandCards(string color, int number, int position)
        {
            Bitmap cardImage = new Bitmap(cardSize.Width, cardSize.Height);
            if (position == 2 && game.Players.Count >= 3 || position == 4 && game.Players.Count == 4 || position == 5)
            {
                cardImage = new Bitmap(cardSize.Height, cardSize.Width);
            }
            Graphics g = Graphics.FromImage(cardImage);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            if (position == 1 || position == 2 && game.Players.Count == 2 || position == 3 || position == 4 && game.Players.Count == 5)
            {
                g.FillRectangle(new SolidBrush(Color.FromName(color)), new Rectangle(0, 0, cardSize.Width, cardSize.Height));
            }
            if (position == 2 && game.Players.Count >= 3 || position == 4 && game.Players.Count == 4 || position == 5)
            {
                g.FillRectangle(new SolidBrush(Color.FromName(color)), new Rectangle(0, 0, cardSize.Height, cardSize.Width));
            }
            if (colorIsCloseToWhite(Color.FromName(color)))
            {
                g.DrawString(number.ToString(), new Font("Tahoma", 12), Brushes.Black, 24, 15);
            }
            else
            {
                g.DrawString(number.ToString(), new Font("Tahoma", 12), Brushes.White, 24, 15);
            }
            g.Flush();
            return cardImage;
        }


        private Image DrawMiddleZone(string color, int number, int zoneColor)
        {
            Bitmap cardImage = new Bitmap(cardSize.Width, cardSize.Height);
            Graphics g = Graphics.FromImage(cardImage);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;

            if (color == "violet")
            {
                string firstColor = "";
                switch (zoneColor)
                {
                    case 0:
                        firstColor = "blue";
                        break;
                    case 1:
                        firstColor = "red";
                        break;
                    case 2:
                        firstColor = "green";
                        break;
                    case 3:
                        firstColor = "white";
                        break;
                    case 4:
                        firstColor = "yellow";
                        break;
                    case 5:
                        firstColor = "violet";
                        break;
                }
                LinearGradientBrush gradientBush = new LinearGradientBrush(new Point(0, 0), new Point(0, cardSize.Height), Color.FromName(firstColor), Color.FromName(color));
                g.FillRectangle(gradientBush, new Rectangle(0, 0, cardSize.Width, cardSize.Height));
                if (colorIsCloseToWhite(Color.FromName(firstColor)))
                {
                    g.DrawString(number.ToString(), new Font("Tahoma", 12), Brushes.Black, 24, 15);
                }
                else
                {
                    g.DrawString(number.ToString(), new Font("Tahoma", 12), Brushes.White, 24, 15);
                }
            }
            else
            {
                g.FillRectangle(new SolidBrush(Color.FromName(color)), new Rectangle(0, 0, cardSize.Width, cardSize.Height));
                if (colorIsCloseToWhite(Color.FromName(color)))
                {
                    g.DrawString(number.ToString(), new Font("Tahoma", 12), Brushes.Black, 24, 15);
                }
                else
                {
                    g.DrawString(number.ToString(), new Font("Tahoma", 12), Brushes.White, 24, 15);
                }
            }
            g.Flush();
            return cardImage;
        }


        /// <summary>
        /// Vérifie que la couleur ne soit pas trop proche du blanc,
        /// Utilisé pour que les couleurs soit visible tout au long de la partie
        /// </summary>
        /// <source href="https://stackoverflow.com/questions/25168445/how-to-determine-if-a-color-is-close-to-another-color"></source>
        /// <param name="a"></param>
        /// <param name="threshold"></param>
        /// <returns>Si la couleur est proche ou non du blanc</returns>
        private bool colorIsCloseToWhite(Color a, int threshold = 255)
        {

            int r = (int)a.R - Color.White.R,
                g = (int)a.G - Color.White.G,
                b = (int)a.B - Color.White.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }

        /// <summary>
        /// Créer la liste de cartes que le joueurs ne verra 
        /// (sa propre main)
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private List<Control> DisplayHidenCard(Player player)
        {
            List<Control> ShadowHand = new List<Control>();

            int positionInPanel = 0;
            foreach (Card card in player.Hand)
            {
                PictureBox drawCard = new PictureBox();
                if (symbolExist(card))
                {
                    drawCard.Controls.Add(symbol.Where(control => control.Name == card.Index.ToString()).First());
                }
                else
                {
                    RecreateSymbolListe(card);
                    drawCard.Controls.Add(symbol.Where(control => control.Name == card.Index.ToString()).First());
                }
                drawCard.Tag = card;
                drawCard.Location = new Point(positionInPanel * cardSize.Width, 10);
                drawCard.Size = cardSize;
                drawCard.BorderStyle = BorderStyle.FixedSingle;
                drawCard.Click += new EventHandler(CardClick);
                drawCard.Cursor = Cursors.Hand;

                Bitmap cardImage = new Bitmap(cardSize.Width, cardSize.Height);
                Graphics g = Graphics.FromImage(cardImage);
                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, cardSize.Width, cardSize.Height));
                g.Flush();

                drawCard.Image = cardImage;
                ShadowHand.Add(drawCard);
                positionInPanel++;
            }

            return ShadowHand;
        }

        private bool symbolExist(Card card)
        {
            foreach (Control control in symbol)
            {
                if (control.Name == card.Index.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        private void RecreateSymbolListe(Card newCard)
        {
            Control addToList = new Control();
            Control removeToList = new Control();
            bool hasChanged = false;

            foreach (Control control in symbol)
            {
                bool bExist = false;
                foreach (Card card in myself.Hand)
                {
                    if (card.Index.ToString() == control.Name)
                    {
                        bExist = true;
                        hasChanged = true;
                    }
                }
                if (!bExist)
                {
                    addToList = DrawUserSymbole(newCard);
                    removeToList = control;
                }
            }
            if (hasChanged)
            {
                symbol.Remove(removeToList);
                symbol.Add(addToList);
            }
        }

        /// <summary>
        /// Affiche sur les cartes une petite picturebox
        /// si on clique dessus un petit symbloe apparait
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSmallSymbole(Object sender, EventArgs e)
        {
            PictureBox symbole = sender as PictureBox;
            switch ((int)symbole.Tag)
            {
                case 0:
                    symbole.Image = Properties.Resources.losange;
                    symbole.Tag = 1;
                    break;
                case 1:
                    symbole.Image = Properties.Resources.rond;
                    symbole.Tag = 2;
                    break;
                case 2:
                    symbole.Image = Properties.Resources.triangle;
                    symbole.Tag = 3;
                    break;
                case 3:
                    symbole.Image = null;
                    symbole.Tag = 0;
                    break;

            }
        }

        /// <summary>
        /// Créer l'imge qui sera affiché sur la picture box de la pioche
        /// L'image contient le nombre de carte restante dans la pioche
        /// </summary>
        /// <param name="amoutCard"></param>
        /// <returns></returns>
        private Image DisplayDrawCard(int amoutCard)
        {
            Bitmap cardImage = new Bitmap(cardSize.Width, cardSize.Height);
            Graphics g = Graphics.FromImage(cardImage);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, cardSize.Width, cardSize.Height));
            g.DrawString(amoutCard.ToString(), new Font("Tahoma", 12), Brushes.White, 18, 27);
            g.Flush();
            return cardImage;
        }

        /// <summary>
        /// Affiche le nombre d'erreur faites (éclair)
        /// </summary>
        /// <returns>Tout les éclaires à afficher</returns>
        private List<Control> DrawError()
        {
            List<Control> erreurs = new List<Control>();
            if (game.FaultUsed > 0)
            {
                for (int positionInPanel = 0; positionInPanel < game.FaultUsed; positionInPanel++)
                {
                    PictureBox drawCard = new PictureBox();
                    drawCard.Image = Properties.Resources.eclair;
                    drawCard.Size = new Size(30, 30);
                    drawCard.Location = new Point(30 * positionInPanel, 0);
                    drawCard.MouseHover += new EventHandler(PnlEclair_MouseHover);
                    drawCard.SizeMode = PictureBoxSizeMode.Zoom;
                    erreurs.Add(drawCard);
                }
            }
            return erreurs;
        }

        /// <summary>
        /// Dès qu'un indice est donné la liste des indices restants est modifié pour correspondre au nombre d'ince restant
        /// </summary>
        /// <returns></returns>
        private List<Control> DrawHint()
        {
            List<Control> hint = new List<Control>();
            if (game.HintUsed < 8)
            {
                for (int positionInPanel = 0; positionInPanel < game.HintBase - game.HintUsed; positionInPanel++)
                {
                    PictureBox drawCard = new PictureBox();
                    drawCard.Image = Properties.Resources.Ampoule;
                    drawCard.Size = new Size(30, 30);
                    drawCard.Location = new Point(30 * positionInPanel, 0);
                    drawCard.SizeMode = PictureBoxSizeMode.Zoom;
                    drawCard.MouseHover += new EventHandler(PnlIndice_MouseHover);
                    hint.Add(drawCard);
                }
            }
            return hint;
        }

        /// <summary>
        /// Affiche toute les zones de points une a coté de l'autre
        /// </summary>
        /// <returns>La carte sur le dessus de chaque pile de point</returns>
        private List<Control> DrawPointPill()
        {
            List<Control> pointPill = new List<Control>();
            int positionInLabel = 0;
            foreach (List<Card> cards in game.PointPile.getAllPill())
            {
                if (cards.Count > 0)
                {
                    PictureBox drawCard = new PictureBox();
                    drawCard.MouseHover += new EventHandler(PnlPoint_MouseHover);
                    drawCard.Click += new EventHandler(PnlPoint_Click);
                    drawCard.Image = DrawMiddleZone(cards.Last().Color, cards.Last().Number, positionInLabel);
                    drawCard.Size = cardSize;
                    drawCard.Location = new Point(positionInLabel * cardSize.Width, 0);
                    drawCard.BorderStyle = BorderStyle.FixedSingle;
                    pointPill.Add(drawCard);
                }
                positionInLabel++;
            }
            return pointPill;
        }

        /// <summary>
        /// Affiche la pile de défausses
        /// </summary>
        /// <returns>la carte sur le dessus de la pile de défausse</returns>
        private Control DrawDiscardPill()
        {
            Control discardPill = new Control();
            if (game.DiscardPile.Count > 0)
            {
                PictureBox drawCard = new PictureBox();
                drawCard.MouseHover += new EventHandler(PnlDefausse_MouseHover);
                drawCard.Click += new EventHandler(PnlDefausse_Click);
                drawCard.Image = DrawMiddleZone(game.DiscardPile.Last().Color, game.DiscardPile.Last().Number, 5);
                drawCard.Size = cardSize;
                drawCard.Location = new Point(0, 0);
                drawCard.BorderStyle = BorderStyle.FixedSingle;
                discardPill = drawCard;
            }
            return discardPill;
        }

        #endregion

        #region Hint

        /// <summary>
        /// Dès que l'on clicque sur le nom d'un joueur vous pouvz donner un indice a ce joueur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerName_Click(object sender, EventArgs e)
        {
            if (selectedCard != null)
            {
                CardIsUsed();
            }

            Control ctrlHint = sender as Control;
            hintReceiver = ctrlHint.Tag as Player;
            btnHintColor.Location = new Point(65, 19);
            btnHintNumber.Location = new Point(5, 19);
            btnHintColor.Tag = 0;
            btnHintNumber.Tag = 0;
            switch (ctrlHint.Name)
            {
                case "lblJoueur2":
                    if (game.Players.Count > 2)
                    {
                        gbxHint.Location = new Point(pnlJoueur3.Right - gbxHint.Width, lblJoueur3.Bottom + 5);
                        btnHintColor.Location = new Point(gbxHint.Width - 2 - btnHintColor.Width, btnHintColor.Location.Y);
                        btnHintNumber.Location = new Point(gbxHint.Width - 4 - btnHintColor.Width - btnHintNumber.Width, btnHintColor.Location.Y);
                        btnHintColor.Tag = 1;
                        btnHintNumber.Tag = 1;
                    }
                    else
                    {
                        gbxHint.Location = new Point(pnlJoueur2.Right + 3, pnlJoueur2.Top);
                    }
                    break;
                case "lblJoueur3":
                    gbxHint.Location = new Point(pnlJoueur2.Right + 3, pnlJoueur2.Top);
                    break;
                case "lblJoueur4":
                    if (game.Players.Count >= 5)
                    {
                        gbxHint.Location = new Point(pnlJoueur5.Left - (gbxHint.Width + 5), pnlJoueur5.Top);
                        btnHintColor.Location = new Point(gbxHint.Width - 2 - btnHintColor.Width, btnHintColor.Location.Y);
                        btnHintNumber.Location = new Point(gbxHint.Width - 4 - btnHintColor.Width - btnHintNumber.Width, btnHintColor.Location.Y);
                        btnHintColor.Tag = 1;
                        btnHintNumber.Tag = 1;
                    }
                    else
                    {
                        gbxHint.Location = new Point(lblJoueur4.Left, lblJoueur4.Bottom);
                    }
                    break;
                case "lblJoueur5":
                    gbxHint.Location = new Point(lblJoueur4.Left, lblJoueur4.Bottom);
                    break;
            }

            gbxHint.Text = "Donner un indice à " + hintReceiver.Name;
            gbxHint.Visible = true;
            pnlHintSender.Visible = false;
        }

        /// <summary>
        /// méthodes applé si vous décidez d'envoyer un indice de nombre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHintNumber_Click(object sender, EventArgs e)
        {
            foreach (Control control in pnlHintSender.Controls)
            {
                control.Visible = false;
            }
            int positionInPanel = 1;
            pnlHintSender.Visible = true;
            if ((int)(sender as Control).Tag == 1)
            {
                positionInPanel = 5;
            }
            foreach (int number in hintReceiver.GetListOfNumber())
            {
                string strbutton = "btnHint" + positionInPanel;
                pnlHintSender.Controls[strbutton].Text = number.ToString();
                pnlHintSender.Controls[strbutton].BackColor = Control.DefaultBackColor;
                pnlHintSender.Controls[strbutton].Tag = number;
                pnlHintSender.Controls[strbutton].Visible = true;
                if ((int)(sender as Control).Tag == 0)
                {
                    positionInPanel++;
                }
                else
                {
                    positionInPanel--;
                }
            }
        }

        /// <summary>
        /// méthodes applé si vous décidez d'envoyer un indice de couleur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHintColor_Click(object sender, EventArgs e)
        {
            foreach (Control control in pnlHintSender.Controls)
            {
                control.Visible = false;
            }
            int positionInPanel = 1;
            pnlHintSender.Visible = true;

            if ((int)(sender as Control).Tag == 1)
            {
                positionInPanel = 5;
            }

            foreach (string color in hintReceiver.GetListOfColor())
            {
                string strbutton = "btnHint" + positionInPanel;
                pnlHintSender.Controls[strbutton].Text = "";
                pnlHintSender.Controls[strbutton].BackColor = Color.FromName(color);
                pnlHintSender.Controls[strbutton].Tag = color;
                pnlHintSender.Controls[strbutton].Visible = true;
                if ((int)(sender as Control).Tag == 0)
                {
                    positionInPanel++;
                }
                else
                {
                    positionInPanel--;
                }
            }
        }

        /// <summary>
        /// Cette méthodes recoit tout les paramètres que le serveur envoie pour que le client puisse afficher les indices
        /// </summary>
        /// <param name="header"></param>
        /// <param name="connection"></param>
        /// <param name="strHint"></param>
        private void ReceiveHint(PacketHeader header, Connection connection, string strHint)
        {
            string[] info = JsonConvert.DeserializeObject<string[]>(strHint);
            string strType = info[0];
            Player receiver = JsonConvert.DeserializeObject<Player>(info[1]);
            Player sender = JsonConvert.DeserializeObject<Player>(info[3]);
            List<Card> Given = JsonConvert.DeserializeObject<List<Card>>(info[2]);

            this.Invoke(new MethodInvoker(delegate
            {
                DisplayHint(receiver, sender,strType, Given);
            }));
        }

        /// <summary>
        /// Pour ne pas redessiner le terrain complet lorsue qu'un joueur bouge les cartes de sa main
        /// Uniquement son jeu sera redessiner
        /// </summary>
        /// <param name="header"></param>
        /// <param name="connection"></param>
        /// <param name="strHint"></param>
        private void ReiceiveRedrawHand(PacketHeader header, Connection connection, string strPlayer)
        {
            Player editPlayer = JsonConvert.DeserializeObject<Player>(strPlayer);
            foreach (Control control in this.Controls)
            {
                if (control is Panel)
                {
                    if (control.Tag != null && (control.Tag as Player).Connection == editPlayer.Connection)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            RedrawHand(editPlayer, control);
                        }));
                    }
                }
            }
        }

        /// <summary>
        /// Redessine uniquement la main du joueur
        /// qui a déplacer ces cartes
        /// </summary>
        /// <param name="editer"></param>
        /// <param name="playerPanel"></param>
        private void RedrawHand(Player editer, Control playerPanel)
        {

            if (editer.Connection == myself.Connection)
            {
                List<Control> temporaryPlayerPanel = new List<Control>();
                int i = 0;
                foreach (Card card in editer.Hand)
                {
                    foreach (Control control in playerPanel.Controls)
                    {

                        if ((control.Tag as Card).Index == card.Index)
                        {
                            control.Location = new Point(i * cardSize.Width, 10);
                            temporaryPlayerPanel.Add(control);
                            i++;
                        }
                    }
                }
                playerPanel.Controls.Clear();
                playerPanel.Controls.AddRange(temporaryPlayerPanel.ToArray());
            }
            else
            {
                playerPanel.Controls.Clear();
                playerPanel.Controls.AddRange(ShowPlayerHand(editer, game.Players.IndexOf(game.Players.Where(player => player.Connection == editer.Connection).First()) + 1).ToArray());
            }
        }


        /// <summary>
        /// Retourne la petite picturebox qui sera positionné sur le haut gauche de la carte retourné
        /// </summary>
        /// <returns></returns>
        private Control DrawUserSymbole(Card card)
        {
            PictureBox symbole = new PictureBox();
            symbole.Size = new Size(15, 15);
            symbole.Location = new Point(45, 0);
            symbole.Name = card.Index.ToString();
            symbole.BackColor = Color.Black;
            symbole.Tag = 0;
            symbole.Click += new EventHandler(AddSmallSymbole);
            symbole.BorderStyle = BorderStyle.FixedSingle;
            symbole.SizeMode = PictureBoxSizeMode.Zoom;
            return symbole;
        }

        /// <summary>
        /// Affiche les indices main uniquement au personne séléctionner
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="type"></param>
        /// <param name="toShow"></param>
        private void DisplayHint(Player receiver, Player sender,string type, List<Card> toShow)
        {
            if (receiver.Connection == myself.Connection)
            {
                foreach (PictureBox pbx in pnlJoueur1.Controls)
                {
                    foreach (Card toDraw in toShow)
                    {
                        if ((pbx.Tag as Card).Index == toDraw.Index)
                        {
                            if (type == "Nombre")
                            {
                                Bitmap cardImage = new Bitmap(cardSize.Width, cardSize.Height);
                                Graphics g = Graphics.FromImage(cardImage);
                                g.SmoothingMode = SmoothingMode.AntiAlias;
                                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, cardSize.Width, cardSize.Height));
                                g.DrawString(toShow[0].Number.ToString(), new Font("Tahoma", 12), Brushes.White, 24, 15);
                                g.Flush();

                                pbx.Image = cardImage;
                            }
                            if (type == "Couleur")
                            {
                                pbx.BackColor = Color.FromName(toShow[0].Color);
                                Bitmap cardImage = new Bitmap(cardSize.Width, cardSize.Height);
                                Graphics g = Graphics.FromImage(cardImage);
                                g.FillRectangle(new SolidBrush(Color.FromName(toShow[0].Color)), new Rectangle(0, 0, cardSize.Width, cardSize.Height));
                                g.Flush();
                                pbx.Image = cardImage;
                            }
                        }
                    }
                }
            }
            else
            {
                if (type == "Nombre")
                {
                    lblShowIndice.Text = sender.Name + " a envoyé l'indice " + toShow[0].Number + " à " + receiver.Name;
                }
                else
                {
                    lblShowIndice.Text = sender.Name + " a envoyé l'indice " + toShow[0].Color + " à " + receiver.Name;
                }
                lblShowIndice.Location = new Point(this.Width / 2 - lblShowIndice.Width / 2, lblShowIndice.Location.Y);
            }
        }

        #endregion

        #region MouseHover

        private void PnlDefausse_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.ShowAlways = true;
            ToolTip1.SetToolTip(sender as Control, "Pile de défausse");
        }

        private void PnlPoint_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.ShowAlways = true;
            ToolTip1.SetToolTip(sender as Control, "Zone de point - Vous avez " + game.PointPile.CountPoint() + " points");
        }

        private void PnlPioche_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.ShowAlways = true;
            ToolTip1.SetToolTip(sender as Control, "Pioche - " + game.DrawPile.Count() + " cartes restantes");
        }

        private void PnlIndice_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.ShowAlways = true;
            ToolTip1.SetToolTip(sender as Control, "Indice restant - Il vous en reste " + (game.HintBase - game.HintUsed).ToString());
        }

        private void PnlEclair_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.ShowAlways = true;
            ToolTip1.SetToolTip(sender as Control, "Nombre de faute - Vous en avez fait " + game.FaultUsed.ToString());
        }

        #endregion

        private void BtnDisplayBoard_Click(object sender, EventArgs e)
        {
            ((sender as Control).Tag as Control).Visible = !((sender as Control).Tag as Control).Visible;
        }
    }
}

