using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classHanabi
{
    public class Player
    {
        private string strName;
        private List<Card> _hand;
        private string strConnection;
        private bool bTurnToPlay;

        public string Name { get => strName; set => strName = value; }
        public List<Card> Hand { get => _hand; set => _hand = value; }
        public string Connection { get => strConnection; set => strConnection = value; }
        public bool TurnToPlay { get => bTurnToPlay; set => bTurnToPlay = value; }

        public Player(string connection, string name)
        {
            Name = name;
            Hand = new List<Card>();
            Connection = connection;
        }

        /// <summary>
        /// Méthode appelé lorsque quelqu'un veut envoyer un indice couleur
        /// </summary>
        /// <returns>Une liste des couleur uniques dans la main du joueur</returns>
        public string[] GetListOfColor()
        {
            List<string> available = new List<string>();
            foreach (Card card in Hand)
            {
                if (!available.Exists(x => x == card.Color))
                {
                    available.Add(card.Color);
                }
            }
            return available.ToArray();
        }

        /// <summary>
        /// Méthode appelé lorsque quelqu'un veut envoyer un indice nombre
        /// </summary>
        /// <returns>Une liste des nombres uniques dans la main du joueur</returns>
        public int[] GetListOfNumber()
        {
            List<int> available = new List<int>();
            foreach (Card card in Hand)
            {
                if (!available.Exists(x => x == card.Number))
                {
                    available.Add(card.Number);
                }
            }
            available.Sort();
            return available.ToArray();
        }


        /// <summary>
        /// Donne la carte qui sera joué par le joueur
        /// </summary>
        /// <returns>La carte séléctionné par le joueur</returns>
        public void PlayCard(Card card)
        {
            Hand.Remove(Hand.Where(c => c.Index == card.Index).Single());
        }

        /// <summary>
        /// Permet au joueur de piocher une carte
        /// </summary>
        /// <param name="card">carte que le joueur a piocher</param>
        public void DrawCard(Card card)
        {
            Hand.Add(card);
        }

        /// <summary>
        /// Permet de changer l'emplacement des cartes dans une main
        /// </summary>
        /// <param name="card">Carte qui a changé de postion visuellement</param>
        /// <param name="newPosition">Nouvelle position de la carte</param>
        public void HandChangePosition(Card card, int newPosition)
        {
            int ancientPosition = Hand.IndexOf(Hand.Where(handCard => handCard.Index == card.Index).Single());
            Hand.Remove(Hand.Where(handcard => handcard.Index == card.Index).Single());
            List<Card> temp = new List<Card>();

            if (ancientPosition < newPosition && newPosition != 0 && newPosition != 5)
            {
                temp = Hand.GetRange(newPosition - 1, (Hand.Count + 1) - newPosition);
                Hand.RemoveRange(newPosition - 1, (Hand.Count + 1) - newPosition);
            }
            if (ancientPosition >= newPosition || newPosition == 0 && newPosition != 5)
            {
                temp = Hand.GetRange(newPosition, Hand.Count - newPosition);
                Hand.RemoveRange(newPosition, Hand.Count - newPosition);
            }

            Hand.Add(card);

            if (temp.Count > 0)
            {
                Hand.AddRange(temp);
            }
        }

        /// <summary>
        /// Indique les cartes qui doivent etre mise en évidence
        /// </summary>
        /// <param name="color">quelle couleur de carte doit etre mis en évidence</param>
        /// <returns>Liste des cartes a mettre en évidence</returns>
        public List<Card> ShowHint(string color)
        {
            List<Card> temp = Hand.Where(x => x.Color == color).ToList();
            return temp;
        }

        /// <summary>
        /// Indique les cartes qui doivent etre mise en évidence
        /// </summary>
        /// <param name="number">quelle numero de carte doit etre mis en évidence</param>
        /// <returns>Liste des cartes a mettre en évidence</returns>
        public List<Card> ShowHint(int number)
        {
            List<Card> temp = Hand.Where(x => x.Number == number).ToList();
            return temp;
        }
    }
}
