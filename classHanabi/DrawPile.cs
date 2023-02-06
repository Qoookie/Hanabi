using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classHanabi
{
    public class DrawPile
    {
        private List<Card> _drawPile;

        public List<Card> Pile { get => _drawPile; set => _drawPile = value; }

        public DrawPile()
        {
            Pile = new List<Card>();
        }

        /// <summary>
        /// Compte le nombre de carte restante dans la pioche
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return Pile.Count();
        }

        /// <summary>
        /// Permet de remplir la pioche
        /// </summary>
        /// <param name="card"></param>
        public void Fill(Card card)
        {
            Pile.Add(card);
        }

        /// <summary>
        /// Mélange la pioche
        /// </summary>
        public void Shuffle()
        {
            Pile.ShuffleCards();
        }

        /// <summary>
        /// Vérifie qu'il reste des cartes dans la pioche
        /// a la fin de chaque round
        /// </summary>
        /// <returns>
        /// True    => La partie se termine, les joueurs ont perdu
        /// False   => La partie continue
        /// </returns>
        public bool CheckEmpty()
        {
            if (Pile.Count == 0)
                return true;
            return false;
        }

        /// <summary>
        /// Enlève la première carte de la pioche
        /// L'ajoute a la main du joueur
        /// </summary>
        /// <returns>La carte a ajouter au joueur</returns>
        public Card PickCard()
        {
            Card temp = Pile[0];
            Pile.Remove(Pile[0]);
            return temp;
        }
    }
}
