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

        public override int GetHashCode()
        {
            return (this.Face.GetHashCode() * 50) ^ (this.Suit.GetHashCode());
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

        #region Static Cards - Clubs
        public static PlayingCard AceOfClubs
        {
            get { return new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Ace); }
        }

        public static PlayingCard TwoOfClubs
        {
            get { return new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Two); }
        }

        public static PlayingCard ThreeOfClubs
        {
            get { return new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Three); }
        }

        public static PlayingCard FourOfClubs
        {
            get { return new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Four); }
        }

        public static PlayingCard FiveOfClubs
        {
            get { return new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Five); }
        }

        public static PlayingCard SixOfClubs
        {
            get { return new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Six); }
        }

        public static PlayingCard SevenOfClubs
        {
            get { return new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Seven); }
        }

        public static PlayingCard EightOfClubs
        {
            get { return new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Eight); }
        }

        public static PlayingCard NineOfClubs
        {
            get { return new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Nine); }
        }

        public static PlayingCard TenOfClubs
        {
            get { return new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Ten); }
        }

        public static PlayingCard JackOfClubs
        {
            get { return new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Jack); }
        }

        public static PlayingCard QueenOfClubs
        {
            get { return new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Queen); }
        }

        public static PlayingCard KingOfClubs
        {
            get { return new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.King); }
        }
        #endregion Static Cards - Clubs

        #region Static Cards - Diamonds
        public static PlayingCard AceOfDiamonds
        {
            get { return new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Ace); }
        }

        public static PlayingCard TwoOfDiamonds
        {
            get { return new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Two); }
        }

        public static PlayingCard ThreeOfDiamonds
        {
            get { return new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Three); }
        }

        public static PlayingCard FourOfDiamonds
        {
            get { return new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Four); }
        }

        public static PlayingCard FiveOfDiamonds
        {
            get { return new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Five); }
        }

        public static PlayingCard SixOfDiamonds
        {
            get { return new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Six); }
        }

        public static PlayingCard SevenOfDiamonds
        {
            get { return new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Seven); }
        }

        public static PlayingCard EightOfDiamonds
        {
            get { return new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Eight); }
        }

        public static PlayingCard NineOfDiamonds
        {
            get { return new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Nine); }
        }

        public static PlayingCard TenOfDiamonds
        {
            get { return new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Ten); }
        }

        public static PlayingCard JackOfDiamonds
        {
            get { return new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Jack); }
        }

        public static PlayingCard QueenOfDiamonds
        {
            get { return new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Queen); }
        }

        public static PlayingCard KingOfDiamonds
        {
            get { return new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.King); }
        }
        #endregion Static Cards - Diamonds

        #region Static Cards - Hearts
        public static PlayingCard AceOfHearts
        {
            get { return new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Ace); }
        }

        public static PlayingCard TwoOfHearts
        {
            get { return new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Two); }
        }

        public static PlayingCard ThreeOfHearts
        {
            get { return new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Three); }
        }

        public static PlayingCard FourOfHearts
        {
            get { return new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Four); }
        }

        public static PlayingCard FiveOfHearts
        {
            get { return new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Five); }
        }

        public static PlayingCard SixOfHearts
        {
            get { return new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Six); }
        }

        public static PlayingCard SevenOfHearts
        {
            get { return new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Seven); }
        }

        public static PlayingCard EightOfHearts
        {
            get { return new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Eight); }
        }

        public static PlayingCard NineOfHearts
        {
            get { return new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Nine); }
        }

        public static PlayingCard TenOfHearts
        {
            get { return new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Ten); }
        }

        public static PlayingCard JackOfHearts
        {
            get { return new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Jack); }
        }

        public static PlayingCard QueenOfHearts
        {
            get { return new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Queen); }
        }

        public static PlayingCard KingOfHearts
        {
            get { return new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.King); }
        }
        #endregion Static Cards - Hearts

        #region Static Cards - Spades
        public static PlayingCard AceOfSpades
        {
            get { return new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Ace); }
        }

        public static PlayingCard TwoOfSpades
        {
            get { return new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Two); }
        }

        public static PlayingCard ThreeOfSpades
        {
            get { return new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Three); }
        }

        public static PlayingCard FourOfSpades
        {
            get { return new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Four); }
        }

        public static PlayingCard FiveOfSpades
        {
            get { return new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Five); }
        }

        public static PlayingCard SixOfSpades
        {
            get { return new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Six); }
        }

        public static PlayingCard SevenOfSpades
        {
            get { return new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Seven); }
        }

        public static PlayingCard EightOfSpades
        {
            get { return new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Eight); }
        }

        public static PlayingCard NineOfSpades
        {
            get { return new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Nine); }
        }

        public static PlayingCard TenOfSpades
        {
            get { return new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Ten); }
        }

        public static PlayingCard JackOfSpades
        {
            get { return new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Jack); }
        }

        public static PlayingCard QueenOfSpades
        {
            get { return new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Queen); }
        }

        public static PlayingCard KingOfSpades
        {
            get { return new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.King); }
        }
        #endregion Static Cards - Spades
    }
}
