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
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="suit">Specifies the card suit (hearts, spades, etc).</param>
        /// <param name="face">Specifies the card face (10, Jack, etc).</param>
        public PlayingCard(PlayingCardSuit suit, PlayingCardFace face)
        {
            this.Suit = suit;
            this.Face = face;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PlayingCard()
            : this(PlayingCardSuit.Spades, PlayingCardFace.Ace) { }

        /// <summary>
        /// Gets and sets a value indicating the playing card suit (hearts, clubs...).
        /// </summary>
        public PlayingCardSuit Suit { get; set; }

        /// <summary>
        /// Gets and sets a value indicating the playing card face (ace, two, three...).
        /// </summary>
        public PlayingCardFace Face { get; set; }
    }
}
