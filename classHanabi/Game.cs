using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace classHanabi
{
    public class Game
    {
        private List<Player> _players;
        private List<Card> _discardPile;
        private PointPile _pointPile;
        private DrawPile _drawPile;

        private Player _currentUser;

        private int iRound;

        private int iHintBase;
        private int iHintAvailable;

        private int iFaultBase;
        private int iFaultAvailable;

        private bool bIsMulticolored;

        private double iDuration;

        private bool bIsFinished;

        public int FaultBase { get => iFaultBase; set => iFaultBase = value; }
        public int FaultUsed { get => iFaultAvailable; set => iFaultAvailable = value; }
        public int HintBase { get => iHintBase; set => iHintBase = value; }
        public int HintUsed { get => iHintAvailable; set => iHintAvailable = value; }
        public bool IsMulticolored { get => bIsMulticolored; set => bIsMulticolored = value; }
        public double Duration { get => iDuration; set => iDuration = value; }
        public int Round { get => iRound; set => iRound = value; }
        public List<Player> Players { get => _players; set => _players = value; }
        public List<Card> DiscardPile { get => _discardPile; set => _discardPile = value; }
        public PointPile PointPile { get => _pointPile; set => _pointPile = value; }
        public DrawPile DrawPile { get => _drawPile; set => _drawPile = value; }
        public bool IsFinished { get => bIsFinished; set => bIsFinished = value; }
        public Player CurrentUser { get => _currentUser; set => _currentUser = value; }

        public Game(List<Player> participant, int hintNumber, int faultNumber, bool isMulticolored)
        {
            DiscardPile = new List<Card>();
            PointPile = new PointPile();
            DrawPile = new DrawPile();

            FaultBase = faultNumber;
            HintBase = hintNumber;
            IsMulticolored = isMulticolored;
            Players = participant;

            CurrentUser = Players[0];
            CurrentUser.TurnToPlay = true;

            IsFinished = false;
            Round = 0;

            InitializeGame();
        }

        /// <summary>
        /// Besoin lors de la sérialisation / déserialistation
        /// Librairie Newtonsoft.Json
        /// </summary>
        public Game()
        { }

        /// <summary>
        /// Dans une partie classique il y a 50 cartes de 5 couleurs différente
        /// Cette méthodes va donc crée les 50 cartes
        /// Et appeler la méthode pour faire piocher les joueurs
        /// </summary>
        private void InitializeGame()
        {
            string[] color;
            color = new string[] { "blue", "white", "red", "yellow", "green" };

            for (int i = 0; i < 50; i++)
            {
                switch (i % 10)
                {
                    case 0:
                    case 1:
                    case 2:
                        DrawPile.Fill(new Card(i,color[i / 10],1));
                        break;
                    case 3:
                    case 4:
                        DrawPile.Fill(new Card(i,color[i / 10], 2));
                        break;
                    case 5:
                    case 6:
                        DrawPile.Fill(new Card(i,color[i / 10], 3));
                        break;
                    case 7:
                    case 8:
                        DrawPile.Fill(new Card(i,color[i / 10], 4));
                        break;
                    case 9:
                        DrawPile.Fill(new Card(i,color[i / 10], 5));
                        break;
                }
            }
            if (IsMulticolored)
            {
                for (int i = 50; i < 55; i++)
                {
                    DrawPile.Fill(new Card(i, "violet", (i % 50) + 1));
                }
            }

            DrawPile.Shuffle();
            DrawHandPlayer();
        }

        /// <summary>
        /// Fait piocher au joueur le bon nombre de carte en fonction du bon nombre de joueur
        /// </summary>
        private void DrawHandPlayer()
        {
            int CardToDraw = Players.Count > 3 ? 4 : 5;
            foreach (Player player in Players)
            {
                for (int i = 0; i < CardToDraw; i++)
                {
                    player.DrawCard(DrawPile.PickCard());
                }
            }
        }

        /// <summary>
        /// Indique à la partie qu'une carte est joué
        /// récupère la carte séléctionner par le joueur
        /// </summary>
        /// <returns>
        /// True    => le coup est valide (La carte est enlevé de la main et ajouté dans la zone de point)
        /// False   => le coup n'est pas valide (+ 1 éclair et la carte est placé dans la pile de défausse)
        /// </returns>
        public void CardIsPlay(Player player, Card card)
        {
            if (player == CurrentUser)
            {
                player.PlayCard(card);
                if (PointPile.CardIsPlayable(card))
                {
                    if (PointPile.CardPlayed(card) && HintUsed > 0)
                    {
                        HintUsed--;
                    }
                }
                else
                {
                    DiscardPile.Add(card);
                    FaultUsed++;
                }
                EndRound(true);
                if (!DrawPile.CheckEmpty())
                    player.DrawCard(DrawPile.PickCard());
            }
        }

        /// <summary>
        /// A la fin du tour, le jeu va vérifier si la partie n'est pas fini
        /// il y a 3 moyens de finir, Il n'y a plus de carte dans la pioche
        /// Tous les éclairs on été utilisé
        /// La partie est gagné tout les feux d'artifices sont fait
        /// </summary>
        private void EndRound(bool needToDraw)
        {
            Round++;
            CurrentUser.TurnToPlay = false;
            if (GameLoose() || PointPile.CheckFireworkFinished())
            {
                IsFinished = true;
                CurrentUser = null;
            }
            else
            {
                if (needToDraw && DrawPile.CheckEmpty())
                {
                    IsFinished = true;
                    CurrentUser = null;
                }
                CurrentUser = Players[Round % Players.Count];
                CurrentUser.TurnToPlay = true;
            }
        }

        /// <summary>
        /// Récupère la carte joué par le joueur
        /// L'ajoute a la pile de défausse
        /// Ajoute un indice
        /// Nécéssite de piocher
        /// </summary>
        /// <param name="card">carte qui est défaussé</param>
        /// <returns>
        /// True    => Tout les jetons ne sont pas accéssible, action posible
        /// False   => Il y a encore tout les jetons, action impossible
        /// </returns>
        public bool DiscardCard(Player player, Card card)
        {
            if (HintUsed > 0)
            {
                player.PlayCard(card);
                DiscardPile.Add(card);
                HintUsed--;
                EndRound(true);
                if (!DrawPile.CheckEmpty())
                    player.DrawCard(DrawPile.PickCard());
                return true;
            }
            return false;
        }

        /// <summary>
        /// A la fin de chaque tour
        /// Vérifie que le nombre de faute restante est suffisant
        /// </summary>
        /// <returns>
        /// True    => Il n'y a plus assez d'éclair, la partie est fini
        /// False   => Il y a assez d'éclair, la partie continue
        /// </returns>
        public bool GameLoose()
        {
            if (FaultBase == FaultUsed)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Les joueurs ont abandonné
        /// La partie s'arrete
        /// </summary>
        public void GiveUpGame()
        {
            IsFinished = true;
            CurrentUser = null;
        }

        /// <summary>
        /// Récupère la liste de cartes qui sera affiché
        /// La méthodes pour récuperer un indice est séparé en deux partie
        /// une premiere qui va chercher la liste des cartes a afficher dans la main du joueur
        /// et la seconde qui va changer les paramètres de la partie.
        /// </summary>
        /// <param name="receiver">Personne qui recoit l'indice</param>
        /// <param name="number">Nombre qui sera cherché dans la main du joueur</param>
        /// <returns>La liste des cartes impacté par la demande</returns>
        public List<Card> GiveAdvice(Player receiver, int number)
        {
            HintUsed++;
            EndRound(false);
            return receiver.ShowHint(number);
        }

        /// <summary>
        /// Récupère la liste de cartes qui sera affiché
        /// La méthodes pour récuperer un indice est séparé en deux partie
        /// une premiere qui va chercher la liste des cartes a afficher dans la main du joueur
        /// et la seconde qui va changer les paramètres de la partie.
        /// </summary>
        /// <param name="receiver">Personne qui recoit l'indice</param>
        /// <param name="color">Couleur qui sera cherché dans la main de la personne</param>
        /// <returns>La liste des cartes impacté par la demande</returns>
        public List<Card> GiveAdvice(Player receiver, string color)
        {
            HintUsed++;
            EndRound(false);
            return receiver.ShowHint(color);
        }

        /// <summary>
        /// Lorsque la partie est fini cette méthode va écrire les différentes informations dans un fichier texte
        /// </summary>
        public void StockEndGameData()
        {
            string path = @".\score.csv";

            TextWriter tw = new StreamWriter(path, true);

            string stockData = "";
            foreach (Player player in Players)
            {
                stockData += player.Name + ";";
            }
            stockData += PointPile.CountPoint() + ";" + Duration + ";" + DateTime.Today.ToString("dd.MM.yyyy") + ";" + HintBase + ";" + FaultBase + ";" + IsMulticolored + "\n";

            tw.Write(stockData);
            tw.Close();
        }
    }
}
