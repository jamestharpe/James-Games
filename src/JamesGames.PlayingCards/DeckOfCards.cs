using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamesGames.PlayingCards
{
    /// <summary>
    /// Represents a deck of cards, such as to be used in a card game.
    /// </summary>
    public class DeckOfCards : PlayingCardList
    {
        private readonly IDeckOfCardsSupplier _CardSupplier;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of DeckOfCards.
        /// </summary>
        /// <param name="cardSupplier">Specifies the source of cards for the deck.</param>
        public DeckOfCards(IDeckOfCardsSupplier cardSupplier)
        {
            _CardSupplier = cardSupplier ?? new StandardDeckOfCardsSupplier();
            Reset();
        }

        /// <summary>
        /// Initializes a new instance of DeckOfCards.
        /// </summary>
        public DeckOfCards() : this(null) { }
        #endregion Constructors

        /// <summary>
        /// Resets the deck instance to it's original state, with a fully new set of cards. It 
        /// should not be assumed that the cards are in any particular order (e.g. shuffled or 
        /// sorted).
        /// </summary>
        public void Reset()
        {
            this.Clear();
            this.AddRange(_CardSupplier.SupplyDeck());
            Rolcore.Collections.ListExtensions.Shuffle(this);
        }
    }
}
