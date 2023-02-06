using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.Connections;
using System.Diagnostics;

namespace Hanabi
{
    public partial class Index : Form
    {
        Connection serverConnection;

        public Index()
        {
            InitializeComponent();
            tbxPseudo.Text = Environment.UserName;
            this.MaximumSize = this.MinimumSize = this.Size;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string adresseServer = first.Text + "." + second.Text + "." + third.Text + "." + fourth.Text;
            adresseServer = adresseServer.Trim();
            adresseServer = adresseServer.Replace(" ", "");

            lblError.ForeColor = Color.Red;
            string strPseudo = tbxPseudo.Text.Trim().Replace(" ", "").Replace(";", "");

            switch (ValidateIPv4(adresseServer))
            {
                case 0:
                    if (strPseudo != "")
                    {
                        ConnectionInfo machineInfo = new ConnectionInfo(adresseServer, 60000);
                        try
                        {
                            serverConnection = TCPConnection.GetConnection(machineInfo);
                            switch (serverConnection.SendReceiveObject<string, int>("Connexion", "ServerResponse", 1000, strPseudo))
                            {
                                case 1:
                                    btnStart.Visible = true;
                                    GameJoin();
                                    break;
                                case 0:
                                    GameJoin();
                                    break;
                                case -1:
                                    lblError.Text = "Il y a trop de personne dans la partie";
                                    break;
                            }
                        }
                        catch (ConnectionSetupException ex)
                        {
                            Debug.Write(ex);
                            lblError.Text = "Impossible de se connecter au serveur réessayer";
                        }
                    }
                    else
                    {
                        lblError.Text = "Veuiller entrée un pseudo";
                    }
                    break;
                case -1:
                    lblError.Text = "Veuillez Entrer une adresse IP";
                    break;
                case -2:
                    lblError.Text = "Adresse IP incomplète";
                    break;
                case -3:
                    lblError.Text = "Adresse IP non valide";
                    break;
            }
            lblError.Visible = true;
        }

        private void GameJoin()
        {
            lblError.ForeColor = Color.Green;
            lblError.Text = "Bienvenue dans la partie";

            btnLoopback.Enabled = false;
            btnConnect.Enabled = false;
            pnlAdresseIP.Enabled = false;
            tbxPseudo.Enabled = false;

            serverConnection.AppendIncomingPacketHandler<string>("monde", GameStart);
        }

        private void GameStart(PacketHeader header, Connection connection, string game)
        {
            connection.RemoveIncomingPacketHandler("monde");
            HanabiGame hanabiGame = new HanabiGame(connection, game);
            this.Invoke(new MethodInvoker(delegate
            {
                hanabiGame.Show();
            }));
        }

        private void btnLoopback_Click(object sender, EventArgs e)
        {
            FillAdresseTextBox(new string[] { "127", "0", "0", "1" });
            //btnConnect_Click(sender, e);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            GameRule gameRule = new GameRule();
            if (gameRule.ShowDialog() == DialogResult.OK)
            {
                if (!serverConnection.SendReceiveObject<int[], bool>("GameReady", "Start", 1000, gameRule.GetRuleValue()))
                {
                    lblError.Text = "Il n'y a pas assez de personne pour lancer la partie";
                    lblError.ForeColor = Color.Red;
                }
                else
                {
                    lblError.ForeColor = Color.Green;
                    lblError.Text = "Bienvenue dans la partie";
                    btnStart.Enabled = false;
                }
            }
            else
            { }
        }

        #region TextBox AdresseIP

        //Fonctionnement:
        //4 MaskedTextBox dans un panel
        //Lorsque le mask est complet -> Va dans la TextBox suivante
        //Si le le point est appuyé -> va directement dans la Textbox suivante
        //Si la fleche gauche ou droite est appuye -> va dans la TextBox suivante/precedante
        //Si le bouton supprimé est appuyé dans la derniere case -> supprime le caractère de la textbox suivante
        //On peut copier-coller des adresses IP complète
        //Même fonctionnement que l'entrées des adresses IP dans windows 10

        bool bfirst, bsecond, bthird, bfourth;
        string strfirst, strSecond, strThird, strfourth;
        string clipBoard = "";
        bool bClipBoard = false;

        private void first_KeyDown(object sender, KeyEventArgs e)
        {
            MaskedTextBox text = sender as MaskedTextBox;
            strSecond = second.Text;
            if (first.SelectionStart == first.Mask.Length && e.KeyCode == Keys.Right)
            {
                second.Focus();
            }
            cutIpAdresse(text, e);
        }

        private void first_KeyUp(object sender, KeyEventArgs e)
        {
            if (first.Text != strfirst)
            {
                bfirst = true;
            }
            if (first.MaskFull && bfirst || first.Focused && e.KeyCode == Keys.OemPeriod && first.Text.Length >= 1)
            {
                if (e.KeyCode != Keys.Delete && e.KeyCode != Keys.Back)
                {
                    second.Focus();
                    bfirst = false;
                    strfirst = first.Text;
                }
            }
            if (bClipBoard)
            {
                bClipBoard = false;
                Clipboard.SetText(clipBoard);
            }
        }

        private void second_KeyDown(object sender, KeyEventArgs e)
        {
            MaskedTextBox text = sender as MaskedTextBox;
            strSecond = second.Text;
            if (text.SelectionStart == 0)
            {
                if (e.KeyCode == Keys.Left)
                {
                    first.Focus();
                }
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {
                    if (first.Text.Length > 0)
                    {
                        first.Text = first.Text.Remove(first.Text.Length - 1, 1);
                    }
                    first.Focus();
                }
            }
            if (second.SelectionStart == second.Mask.Length && e.KeyCode == Keys.Right)
            {
                third.Focus();
            }
            cutIpAdresse(text, e);
        }

        private void second_KeyUp(object sender, KeyEventArgs e)
        {
            if (second.Text != strSecond)
            {
                bsecond = true;
            }
            if (second.MaskFull && bsecond || second.Focused && e.KeyCode == Keys.OemPeriod && second.Text.Length >= 1)
            {
                if (e.KeyCode != Keys.Delete && e.KeyCode != Keys.Back)
                {
                    strSecond = second.Text;
                    third.Focus();
                    bsecond = false;
                }
            }
            if (bClipBoard)
            {
                bClipBoard = false;
                Clipboard.SetText(clipBoard);
            }
        }

        private void third_KeyDown(object sender, KeyEventArgs e)
        {
            MaskedTextBox text = sender as MaskedTextBox;
            strThird = third.Text;
            if (text.SelectionStart == 0)
            {
                if (e.KeyCode == Keys.Left)
                {
                    second.Focus();
                }
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {
                    if (second.Text.Length > 0)
                    {
                        second.Text = second.Text.Remove(second.Text.Length - 1, 1);
                    }
                    second.Focus();
                }
            }
            if (text.SelectionStart == text.Mask.Length && e.KeyCode == Keys.Right)
            {
                fourth.Focus();
            }
            cutIpAdresse(text, e);
        }

        private void third_KeyUp(object sender, KeyEventArgs e)
        {
            if (third.Text != strThird)
            {
                bthird = true;
            }
            if (third.MaskFull && bthird || third.Focused && e.KeyCode == Keys.OemPeriod && third.Text.Length >= 1)
            {
                if (e.KeyCode != Keys.Delete && e.KeyCode != Keys.Back)
                {
                    fourth.Focus();
                    bthird = false;
                    strThird = third.Text;
                }
            }
            if (bClipBoard)
            {
                bClipBoard = false;
                Clipboard.SetText(clipBoard);
            }
        }

        private void fourth_KeyDown(object sender, KeyEventArgs e)
        {
            MaskedTextBox text = sender as MaskedTextBox;
            strfourth = fourth.Text;
            if (text.SelectionStart == 0)
            {
                if (e.KeyCode == Keys.Left)
                {
                    third.Focus();
                }
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {
                    if (third.Text.Length > 0)
                    {
                        third.Text = third.Text.Remove(third.Text.Length - 1, 1);
                    }
                    third.Focus();
                }
            }
            if (fourth.SelectionStart == 0 && e.KeyCode == Keys.Left)
            {
                third.Focus();
            }
            cutIpAdresse(text, e);
        }

        private void fourth_KeyUp(object sender, KeyEventArgs e)
        {
            if (fourth.Text != strfourth)
            {
                bfourth = true;
            }
            if (fourth.MaskFull && bfourth || fourth.Focused && e.KeyCode == Keys.OemPeriod && fourth.Text.Length >= 1)
            {
                if (e.KeyCode != Keys.Delete && e.KeyCode != Keys.Back)
                {
                    btnConnect.Focus();
                    bfourth = false;
                    strfourth = fourth.Text;
                }
            }
            if (bClipBoard)
            {
                bClipBoard = false;
                Clipboard.SetText(clipBoard);
            }
        }

        public void cutIpAdresse(MaskedTextBox text, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                if (Clipboard.ContainsText())
                {
                    if (ValidateIPv4(Clipboard.GetText()) == 0)
                    {
                        FillAdresseTextBox(Clipboard.GetText().Split('.'));
                        clipBoard = Clipboard.GetText();
                        bClipBoard = true;
                        Clipboard.Clear();
                    }
                    else
                    {
                        text.Text = Clipboard.GetText();
                        clipBoard = Clipboard.GetText();
                        bClipBoard = true;
                        Clipboard.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// Remplie les textBox qui contienent les adresses IP
        /// </summary>
        /// <param name="adresse">tableau contenant une adressIP séparer</param>
        public void FillAdresseTextBox(string[] adresse)
        {
            first.Text = adresse[0];
            second.Text = adresse[1];
            third.Text = adresse[2];
            fourth.Text = adresse[3];
        }

        /// <summary>
        /// Vérifie que l'adresse IP soit une vrai adresse IP
        /// </summary>
        /// <param name="ipString"></param>
        /// <returns></returns>
        public int ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString) || ipString == "...")
            {
                return -1;
            }

            string[] splitValues = ipString.Split('.');
            foreach (string Values in splitValues)
            {
                if (String.IsNullOrWhiteSpace(Values))
                {
                    return -2;
                }
            }

            byte tempForParsing;
            return splitValues.All(r => byte.TryParse(r, out tempForParsing)) ? 0 : -3;
        }

        #endregion
    }
}
