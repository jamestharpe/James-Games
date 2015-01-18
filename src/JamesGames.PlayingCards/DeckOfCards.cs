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

        public DeckOfCards(int numberOfDecks)
        {
            this.Reset(numberOfDecks);
        }

        public DeckOfCards() : this(DefaultNumberOfDecks) { }

        public int NumberOfDecksInLastReset { get; private set; }

        public void Reset(int numberOfDecks = 0)
        {
            if (numberOfDecks < 0)
            {
                throw new ArgumentOutOfRangeException("numberOfDecks");
            }
            else if (numberOfDecks == 0)
            {
                numberOfDecks = this.NumberOfDecksInLastReset;
            }

            var cardSuits = (PlayingCardSuit[])Enum.GetValues(typeof(PlayingCardSuit));
            var cardFaces = (PlayingCardFace[])Enum.GetValues(typeof(PlayingCardFace));

            this.Clear();

            for (int i = 0; i < numberOfDecks; i++)
            {
                foreach (PlayingCardSuit suit in cardSuits)
                {
                    foreach (PlayingCardFace face in cardFaces)
                    {
                        this.Add(new PlayingCard(suit, face));
                    }
                }
            }

            this.NumberOfDecksInLastReset = numberOfDecks;
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


        public PlayingCard DealCard(PlayingCardList hand)
        {
            if (this.Count < 1)
                throw new InvalidOperationException("Deck is Empty.");

            var result = this[0];
            hand.Add(result);
            this.RemoveAt(0);
            return result;
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
            result.NumberOfDecksInLastReset = this.NumberOfDecksInLastReset;
            return result;
        }
    }
}
