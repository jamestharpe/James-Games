using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace JamesGames.PlayingCards
{
    /// <summary>
    /// Implements <see cref="IDeckOfCardSupplier"/> to supply a standard 52 card deck.
    /// </summary>
    public class StandardDeckOfCardsSupplier : IDeckOfCardsSupplier
    {
        /// <summary>
        /// Creates a standard 52-card set of cards and returns them as an array.
        /// </summary>
        public PlayingCard[] SupplyDeck()
        {
            PlayingCardSuit[] cardSuits = (PlayingCardSuit[])Enum.GetValues(typeof(PlayingCardSuit));
            PlayingCardFace[] cardFaces = (PlayingCardFace[])Enum.GetValues(typeof(PlayingCardFace));
            int resultCount = cardSuits.Length * cardFaces.Length;
            Debug.Assert(resultCount == 52); // Last time I checked, a standard deck of cards 
                                             // contains 52 cards.

            List<PlayingCard> result = new List<PlayingCard>(resultCount);
            foreach (PlayingCardSuit suit in cardSuits)
                foreach (PlayingCardFace face in cardFaces)
                    result.Add(new PlayingCard(suit, face));

            Debug.Assert(result.Count == resultCount);

            return result.ToArray();
        }
    }
}
