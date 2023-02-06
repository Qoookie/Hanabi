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
using NetworkCommsDotNet.Connections;
using DuchosalN;
using classHanabi;
using Newtonsoft.Json;

namespace HanabiServeur
{
    public partial class IndexServeur : Form
    {
        Game game;
        List <Connection> playersConnection;
        List<Player> gamePlayer;

        private DateTime startGame;
        private DateTime endGame;

        public IndexServeur()
        {
            InitializeComponent();

            this.MaximumSize = this.MinimumSize = this.Size;

            NetworkIdentifier server = new NetworkIdentifier();
            lblNetworkInfo.Text = server.ToString();

            playersConnection = new List<Connection>();
            gamePlayer = new List<Player>();

            Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, 60000));
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("Connexion", NewConnexion);
        }

        private void NewConnexion(PacketHeader header, Connection connection, string name)
        {
            if (playersConnection.Count < 5)
            {
                playersConnection.Add(connection);
                gamePlayer.Add(new Player(connection.ToString(), name));

                connection.SendObject("serveurConnection", connection.ToString());
                if (playersConnection.Count > 1)
                {
                    connection.SendObject("ServerResponse", 0);
                }
                else
                {
                    connection.SendObject("ServerResponse", 1);
                    connection.AppendIncomingPacketHandler<int[]>("GameReady", GameInitialize);
                }
            }
            else
            {
                connection.SendObject("ServerResponse", -1);
            }
        }

        private void GameInitialize(PacketHeader header, Connection connection, int[] rules)
        {
            if (gamePlayer.Count > 1)
            {
                game = new Game(gamePlayer, rules[0], rules[1], rules[2] == 0 ? false : true);

                startGame = DateTime.Now;

                foreach (Connection conn in playersConnection)
                {
                    conn.AppendIncomingPacketHandler<string>("PlayCard", PlayCard);
                    conn.AppendIncomingPacketHandler<string>("DiscardCard", DiscardCard);
                    conn.AppendIncomingPacketHandler<string>("SendHint", SendHint);
                    conn.AppendIncomingPacketHandler<string>("HandChangePosition", ChangeHandCardPosition);
                    conn.AppendIncomingPacketHandler<bool>("GiveUp", EndTheGame);
                }

                connection.SendObject("Start", true);
                sendWorld();
                Connection.StopListening();
            }
            else
            {
                connection.SendObject("Start", false);
            }
        }

        private void PlayCard(PacketHeader header, Connection connection, string card)
        {
            if (game.CurrentUser.Connection == connection.ToString())
            {
                Card playedCard = JsonConvert.DeserializeObject<Card>(card);
                game.CardIsPlay(game.Players.Where(user => user.Connection == connection.ToString()).Single(), playedCard);
                sendWorld();
            }
        }

        private void DiscardCard(PacketHeader header, Connection connection, string card)
        {
            if (game.CurrentUser.Connection == connection.ToString())
            {
                Card playedCard = JsonConvert.DeserializeObject<Card>(card);
                if (game.DiscardCard(game.Players.Where(user => user.Connection == connection.ToString()).Single(), playedCard))
                {
                    sendWorld();
                }
            }
        }

        private void EndTheGame(PacketHeader header, Connection connection, bool accept)
        {
            game.GiveUpGame();
            sendWorld();
        }

        private void ChangeHandCardPosition(PacketHeader header, Connection connection, string info)
        {
            string[] separer = JsonConvert.DeserializeObject<string[]>(info);
            Card mooveCard = JsonConvert.DeserializeObject<Card>(separer[0]);
            foreach (Player player in game.Players)
            {
                if (player.Connection == connection.ToString())
                {
                    player.HandChangePosition(mooveCard, Convert.ToInt32(separer[1]));
                    foreach (Connection conn in playersConnection)
                    {
                        string strPlayerHandChange = JsonConvert.SerializeObject(player);
                        if (conn.ConnectionInfo.ConnectionState == NetworkCommsDotNet.ConnectionState.Established)
                        {
                            conn.SendObject("HandHasChanged", strPlayerHandChange);
                        }
                        else
                        {
                            game.IsFinished = true;
                            sendWorld();
                        }
                    }
                }
            }
        }

        private void SendHint(PacketHeader header, Connection connection, string info)
        {
            string[] infoTable = JsonConvert.DeserializeObject<string[]>(info);
            Player sender = JsonConvert.DeserializeObject<Player>(infoTable[0]);
            Player receiver = JsonConvert.DeserializeObject<Player>(infoTable[1]);

            if (sender.Connection == game.CurrentUser.Connection)
            {
                if (game.HintUsed < game.HintBase)
                {
                    string strTypeToShow;
                    string strCardtoshow;
                    string strPlayerToshow = JsonConvert.SerializeObject(receiver);
                    string strPlayerSender = infoTable[0];

                    if (Int32.TryParse(infoTable[2], out int number))
                    {
                        strCardtoshow = JsonConvert.SerializeObject(game.GiveAdvice(receiver, number));
                        strTypeToShow = "Nombre";
                    }
                    else
                    {
                        strCardtoshow = JsonConvert.SerializeObject(game.GiveAdvice(receiver, infoTable[2]));
                        strTypeToShow = "Couleur";
                    }

                    sendWorld();

                    foreach (Connection conn in playersConnection)
                    {
                        if (conn.ConnectionInfo.ConnectionState == NetworkCommsDotNet.ConnectionState.Established)
                        {
                            conn.SendObject<string>("ReceiveHint", JsonConvert.SerializeObject(new string[] { strTypeToShow, strPlayerToshow, strCardtoshow, strPlayerSender }));
                        }
                        else
                        {
                            game.IsFinished = true;
                            sendWorld();
                        }
                    }

                }
            }
        }

        private void sendWorld()
        {
            if (game.IsFinished)
            {
                endGame = DateTime.Now;
                game.Duration = Math.Round((endGame - startGame).TotalSeconds, 2);
                foreach (Connection conn in playersConnection)
                {
                    if (conn.ConnectionInfo.ConnectionState == NetworkCommsDotNet.ConnectionState.Established)
                    {
                        conn.SendObject("Finish", game.PointPile.CountPoint());
                    }
                }
                game.StockEndGameData();
            }

            foreach (Connection conn in playersConnection)
            {
                Game PersonalGame = game.Clone();
                List<Player> temp = new List<Player>();

                foreach (Player player in PersonalGame.Players)
                {
                    if (player.Connection == conn.ToString())
                    {
                        temp = PersonalGame.Players.GetRange(PersonalGame.Players.IndexOf(player), PersonalGame.Players.Count - PersonalGame.Players.IndexOf(player));
                        if (temp.Count != PersonalGame.Players.Count)
                            temp.AddRange(PersonalGame.Players.GetRange(0, PersonalGame.Players.IndexOf(player)));
                    }
                }

                PersonalGame.Players = temp;
                if (conn.ConnectionInfo.ConnectionState == NetworkCommsDotNet.ConnectionState.Established)
                {
                    conn.SendObject<string>("monde", JsonConvert.SerializeObject(PersonalGame));
                }
                else
                {
                    game.IsFinished = true;
                    sendWorld();
                }
            }
            if (game.IsFinished)
            {
                this.Invoke(new MethodInvoker(delegate { 
                    this.Close(); 
                }));
            }
        }

        private void ShowHistorique_Click(object sender, EventArgs e)
        {
            HistoriqueGame game = new HistoriqueGame();
            game.ShowDialog();
        }
    }
}
