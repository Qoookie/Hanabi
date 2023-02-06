using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classHanabi
{
    public class PointPile
    {
        private List<Card> _blueCard;
        private List<Card> _redCard;
        private List<Card> _greenCard;
        private List<Card> _whiteCard;
        private List<Card> _yellowCard;

        public List<Card> BlueCard { get => _blueCard; set => _blueCard = value; }
        public List<Card> RedCard { get => _redCard; set => _redCard = value; }
        public List<Card> GreenCard { get => _greenCard; set => _greenCard = value; }
        public List<Card> WhiteCard { get => _whiteCard; set => _whiteCard = value; }
        public List<Card> YellowCard { get => _yellowCard; set => _yellowCard = value; }

        public PointPile()
        {
            BlueCard = new List<Card>();
            RedCard = new List<Card>();
            GreenCard = new List<Card>();
            WhiteCard = new List<Card>();
            YellowCard = new List<Card>();
        }

        /// <summary>
        /// si vous finissez une pile
        /// un jeton indice vous est automatiquement redonné
        /// </summary>
        public bool CheckPillFinished(List<Card> cardAdded)
        {
            if (cardAdded.Count == 5)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Peremet de récuperer toute les piles
        /// va surtout servir lors de l'affichage
        /// </summary>
        /// <returns>La liste des tas de points</returns>
        public List<List<Card>> getAllPill()
        {
            List<List<Card>> allPill = new List<List<Card>>();
            allPill.Add(BlueCard);
            allPill.Add(RedCard);
            allPill.Add(GreenCard);
            allPill.Add(WhiteCard);
            allPill.Add(YellowCard);

            return allPill;
        }

        /// <summary>
        /// Compte le nombre de point qui a été fait durant la partie
        /// </summary>
        /// <returns>le nombre de point (1 par feux)</returns>
        public int CountPoint()
        {
            return BlueCard.Count + RedCard.Count + GreenCard.Count + WhiteCard.Count + YellowCard.Count;
        }

        /// <summary>
        /// Après chaque tour
        /// Vérifie que tout les feux d'artifices ne soit pas terminé
        /// </summary>
        /// <returns>
        /// True    => La partie se termine les joueurs ont gagné
        /// False   => La parie continue
        /// </returns>
        public bool CheckFireworkFinished()
        {
            if (BlueCard.Count == 5 && RedCard.Count == 5 && GreenCard.Count == 5 && WhiteCard.Count == 5 && YellowCard.Count == 5)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Ajoute une carte qui peut etre joué à la pile
        /// </summary>
        /// <param name="card">Carte qui a été joué</param>
        public bool CardPlayed(Card card)
        {
            bool giveOneMoreHint = false;
            switch (card.Color)
            {
                case "red":
                    RedCard.Add(card);
                    giveOneMoreHint = CheckPillFinished(RedCard);
                    break;
                case "green":
                    GreenCard.Add(card);
                    giveOneMoreHint = CheckPillFinished(GreenCard);
                    break;
                case "blue":
                    BlueCard.Add(card);
                    giveOneMoreHint = CheckPillFinished(BlueCard);
                    break;
                case "white":
                    WhiteCard.Add(card);
                    giveOneMoreHint = CheckPillFinished(WhiteCard);
                    break;
                case "yellow":
                    YellowCard.Add(card);
                    giveOneMoreHint = CheckPillFinished(YellowCard);
                    break;
                case "violet":
                    foreach (List<Card> whereCardIsAdd in getAllPill())
                    {
                        if (CheckNumber(whereCardIsAdd, card.Number))
                        {
                            whereCardIsAdd.Add(card);
                            giveOneMoreHint = CheckPillFinished(whereCardIsAdd);
                            break;
                        }
                    }
                    break;
            }
            return giveOneMoreHint;
        }

        /// <summary>
        /// Vérifie si une carte peut etre ajouter a un feu d'artifice
        /// Cherche dans le tableau de la couleur correspondante
        /// </summary>
        /// <returns>
        /// True    => la carte peut etre ajouté
        /// False   => la carte ne peut etre ajouté
        /// </returns>
        public bool CardIsPlayable(Card card)
        {
            switch (card.Color)
            {
                case "red":
                    return CheckNumber(RedCard, card.Number);
                case "green":
                    return CheckNumber(GreenCard, card.Number);
                case "blue":
                    return CheckNumber(BlueCard, card.Number);
                case "white":
                    return CheckNumber(WhiteCard, card.Number);
                case "yellow":
                    return CheckNumber(YellowCard, card.Number);
                case "violet":
                    return CheckVioletCardPlay(card.Number);
            }
            return false;
        }

        /// <summary>
        /// vérifie si la carte peut etre posé sur une autre
        /// Si pas de carte alors carte numéro doit etre posé
        /// </summary>
        /// <param name="toCheck">Liste en fonction de la couleur de la carte</param>
        /// <param name="number">Nombre qui sera vérifier pour voir si la carte posé est bien la bonne</param>
        /// <returns></returns>
        private bool CheckNumber(List<Card> toCheck, int number)
        {
            if (toCheck.Count == 0 && number == 1)
                return true;
            if (toCheck.Count > 0 && toCheck[toCheck.Count - 1].Number == number - 1)
                return true;
            return false;
        }

        private bool CheckVioletCardPlay(int number)
        {
            foreach (List<Card> toCheck in getAllPill())
            {
                if (toCheck.Count == 0 && number == 1)
                    return true;
                if (toCheck.Count > 0 && toCheck[toCheck.Count - 1].Number == number - 1)
                    return true;
            }
            return false;
        }
    }
}
