using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rolcore.Collections;

namespace JamesGames.PlayingCards
{
    /// <summary>
    /// Represents a deck of cards, such as to be used in a card game.
    /// </summary>
    public class DeckOfCards : PlayingCardList, ICloneable
    {
        public const int DefaultNumberOfDecks = 1;

        public DeckOfCards(int numberOfDecks = DefaultNumberOfDecks)
        {
            var cardSuits = (PlayingCardSuit[])Enum.GetValues(typeof(PlayingCardSuit));
            var cardFaces = (PlayingCardFace[])Enum.GetValues(typeof(PlayingCardFace));

            for (int i = 0; i < numberOfDecks; i++)
            {
                foreach (var suit in cardSuits)
                {
                    foreach (var face in cardFaces)
                    {
                        this.Add(new PlayingCard(suit, face));
                    }
                }
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var card in this)
            {
                result.AppendLine(card.ToString());
            }

            return result.ToString();
        }

        /// <summary>
        /// Clones the current object.
        /// </summary>
        /// <returns>A new instance of <see cref="DeckOfCards"/> exactly like the current instance.</returns>
        public override object Clone()
        {
            PlayingCardList cards = (PlayingCardList)base.Clone();
            DeckOfCards result = new DeckOfCards();
            result.Clear();
            result.AddRange(cards);
            return result;
        }
    }
}
