using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamesGames.PlayingCards
{
    /// <summary>
    /// A playing card.
    /// </summary>
    public class PlayingCard
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of PlayingCard.
        /// </summary>
        /// <param name="suit">Specifies the card suit (hearts, spades, etc).</param>
        /// <param name="face">Specifies the card face (10, Jack, etc).</param>
        public PlayingCard(PlayingCardSuit suit, PlayingCardFace face)
        {
            this.Suit = suit;
            this.Face = face;
        }

        /// <summary>
        /// Initializes a new instance of PlayingCard.
        /// </summary>
        public PlayingCard()
            : this(PlayingCardSuit.Spades, PlayingCardFace.Ace) { }
        #endregion Constructors

        /// <summary>
        /// Gets and sets a value indicating the playing card suit (hearts, clubs...).
        /// </summary>
        public PlayingCardSuit Suit { get; set; }

        /// <summary>
        /// Gets and sets a value indicating the playing card face (ace, two, three...).
        /// </summary>
        public PlayingCardFace Face { get; set; }

        #region Operators
        public override bool Equals(object obj)
        {
            return (this == (PlayingCard)obj);
        }

        public static bool operator ==(PlayingCard card1, PlayingCard card2)
        {
            if (object.ReferenceEquals(card1, card2))
                return true; // For two nulls
            if (object.ReferenceEquals(card1, null) || object.ReferenceEquals(card2, null))
                return false; // For one nulls, one not null
            return ((card1.Face == card2.Face) && (card1.Suit == card2.Suit));
        }

        public static bool operator !=(PlayingCard card1, PlayingCard card2)
        {
            if (object.ReferenceEquals(card1, card2))
                return false; // For nulls
            if (object.ReferenceEquals(card1, null) || object.ReferenceEquals(card2, null))
                return true; // For one nulls, one not null
            return ((card1.Face != card2.Face) || (card1.Suit != card2.Suit));
        }
        #endregion Operators
    }
}
