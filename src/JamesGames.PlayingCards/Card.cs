[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1633:FileMustHaveHeader", Justification = "Reviewed.")]

namespace JamesGames.PlayingCards
{
    using System;

    /// <summary>
    /// A playing card.
    /// </summary>
    public class Card : ICloneable
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="suit">Specifies the card suit (hearts, spades, etc).</param>
        /// <param name="face">Specifies the card face (10, Jack, etc).</param>
        public Card(CardSuit suit, CardFace face)
        {
            this.Suit = suit;
            this.Face = face;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        public Card()
            : this(CardSuit.Spades, CardFace.Ace) 
        { 
        }

        #endregion Constructors

        #region Static Cards - Clubs
        /// <summary>
        /// Gets the Ace of clubs.
        /// </summary>
        public static Card AceOfClubs
        {
            get { return new Card(CardSuit.Clubs, CardFace.Ace); }
        }

        /// <summary>
        /// Gets the two of clubs.
        /// </summary>
        public static Card TwoOfClubs
        {
            get { return new Card(CardSuit.Clubs, CardFace.Two); }
        }

        /// <summary>
        /// Gets the Three of clubs.
        /// </summary>
        public static Card ThreeOfClubs
        {
            get { return new Card(CardSuit.Clubs, CardFace.Three); }
        }

        /// <summary>
        /// Gets the Four of clubs.
        /// </summary>
        public static Card FourOfClubs
        {
            get { return new Card(CardSuit.Clubs, CardFace.Four); }
        }

        /// <summary>
        /// Gets the Five of clubs.
        /// </summary>
        public static Card FiveOfClubs
        {
            get { return new Card(CardSuit.Clubs, CardFace.Five); }
        }

        /// <summary>
        /// Gets the Six of clubs.
        /// </summary>
        public static Card SixOfClubs
        {
            get { return new Card(CardSuit.Clubs, CardFace.Six); }
        }

        /// <summary>
        /// Gets the Seven of clubs.
        /// </summary>
        public static Card SevenOfClubs
        {
            get { return new Card(CardSuit.Clubs, CardFace.Seven); }
        }

        /// <summary>
        /// Gets the Eight of clubs.
        /// </summary>
        public static Card EightOfClubs
        {
            get { return new Card(CardSuit.Clubs, CardFace.Eight); }
        }

        /// <summary>
        /// Gets the Nine of clubs.
        /// </summary>
        public static Card NineOfClubs
        {
            get { return new Card(CardSuit.Clubs, CardFace.Nine); }
        }

        /// <summary>
        /// Gets the Ten of clubs.
        /// </summary>
        public static Card TenOfClubs
        {
            get { return new Card(CardSuit.Clubs, CardFace.Ten); }
        }

        /// <summary>
        /// Gets the Jack of clubs.
        /// </summary>
        public static Card JackOfClubs
        {
            get { return new Card(CardSuit.Clubs, CardFace.Jack); }
        }

        /// <summary>
        /// Gets the Queen of clubs.
        /// </summary>
        public static Card QueenOfClubs
        {
            get { return new Card(CardSuit.Clubs, CardFace.Queen); }
        }

        /// <summary>
        /// Gets the King of clubs.
        /// </summary>
        public static Card KingOfClubs
        {
            get { return new Card(CardSuit.Clubs, CardFace.King); }
        }

        #endregion Static Cards - Clubs

        #region Static Cards - Diamonds

        /// <summary>
        /// Gets the Ace of diamonds.
        /// </summary>
        public static Card AceOfDiamonds
        {
            get { return new Card(CardSuit.Diamonds, CardFace.Ace); }
        }

        /// <summary>
        /// Gets the Two of diamonds.
        /// </summary>
        public static Card TwoOfDiamonds
        {
            get { return new Card(CardSuit.Diamonds, CardFace.Two); }
        }

        /// <summary>
        /// Gets the Three of diamonds.
        /// </summary>
        public static Card ThreeOfDiamonds
        {
            get { return new Card(CardSuit.Diamonds, CardFace.Three); }
        }

        /// <summary>
        /// Gets the Four of diamonds.
        /// </summary>
        public static Card FourOfDiamonds
        {
            get { return new Card(CardSuit.Diamonds, CardFace.Four); }
        }

        /// <summary>
        /// Gets the Five of diamonds.
        /// </summary>
        public static Card FiveOfDiamonds
        {
            get { return new Card(CardSuit.Diamonds, CardFace.Five); }
        }

        /// <summary>
        /// Gets the Six of diamonds.
        /// </summary>
        public static Card SixOfDiamonds
        {
            get { return new Card(CardSuit.Diamonds, CardFace.Six); }
        }

        /// <summary>
        /// Gets the Seven of diamonds.
        /// </summary>
        public static Card SevenOfDiamonds
        {
            get { return new Card(CardSuit.Diamonds, CardFace.Seven); }
        }

        /// <summary>
        /// Gets the Eight of diamonds.
        /// </summary>
        public static Card EightOfDiamonds
        {
            get { return new Card(CardSuit.Diamonds, CardFace.Eight); }
        }

        /// <summary>
        /// Gets the Nine of diamonds.
        /// </summary>
        public static Card NineOfDiamonds
        {
            get { return new Card(CardSuit.Diamonds, CardFace.Nine); }
        }

        /// <summary>
        /// Gets the Ten of diamonds.
        /// </summary>
        public static Card TenOfDiamonds
        {
            get { return new Card(CardSuit.Diamonds, CardFace.Ten); }
        }

        /// <summary>
        /// Gets the Jack of diamonds.
        /// </summary>
        public static Card JackOfDiamonds
        {
            get { return new Card(CardSuit.Diamonds, CardFace.Jack); }
        }

        /// <summary>
        /// Gets the Queen of diamonds.
        /// </summary>
        public static Card QueenOfDiamonds
        {
            get { return new Card(CardSuit.Diamonds, CardFace.Queen); }
        }

        /// <summary>
        /// Gets the King of diamonds.
        /// </summary>
        public static Card KingOfDiamonds
        {
            get { return new Card(CardSuit.Diamonds, CardFace.King); }
        }

        #endregion Static Cards - Diamonds

        #region Static Cards - Hearts

        /// <summary>
        /// Gets the Ace of hearts.
        /// </summary>
        public static Card AceOfHearts
        {
            get { return new Card(CardSuit.Hearts, CardFace.Ace); }
        }

        /// <summary>
        /// Gets the Two of hearts.
        /// </summary>
        public static Card TwoOfHearts
        {
            get { return new Card(CardSuit.Hearts, CardFace.Two); }
        }

        /// <summary>
        /// Gets the Three of hearts.
        /// </summary>
        public static Card ThreeOfHearts
        {
            get { return new Card(CardSuit.Hearts, CardFace.Three); }
        }

        /// <summary>
        /// Gets the Four of hearts.
        /// </summary>
        public static Card FourOfHearts
        {
            get { return new Card(CardSuit.Hearts, CardFace.Four); }
        }

        /// <summary>
        /// Gets the Five of hearts.
        /// </summary>
        public static Card FiveOfHearts
        {
            get { return new Card(CardSuit.Hearts, CardFace.Five); }
        }

        /// <summary>
        /// Gets the Six of hearts.
        /// </summary>
        public static Card SixOfHearts
        {
            get { return new Card(CardSuit.Hearts, CardFace.Six); }
        }

        /// <summary>
        /// Gets the Seven of hearts.
        /// </summary>
        public static Card SevenOfHearts
        {
            get { return new Card(CardSuit.Hearts, CardFace.Seven); }
        }

        /// <summary>
        /// Gets the Eight of hearts.
        /// </summary>
        public static Card EightOfHearts
        {
            get { return new Card(CardSuit.Hearts, CardFace.Eight); }
        }

        /// <summary>
        /// Gets the Nine of hearts.
        /// </summary>
        public static Card NineOfHearts
        {
            get { return new Card(CardSuit.Hearts, CardFace.Nine); }
        }

        /// <summary>
        /// Gets the Ten of hearts.
        /// </summary>
        public static Card TenOfHearts
        {
            get { return new Card(CardSuit.Hearts, CardFace.Ten); }
        }

        /// <summary>
        /// Gets the Jack of hearts.
        /// </summary>
        public static Card JackOfHearts
        {
            get { return new Card(CardSuit.Hearts, CardFace.Jack); }
        }

        /// <summary>
        /// Gets the Queen of hearts.
        /// </summary>
        public static Card QueenOfHearts
        {
            get { return new Card(CardSuit.Hearts, CardFace.Queen); }
        }

        /// <summary>
        /// Gets the King of hearts.
        /// </summary>
        public static Card KingOfHearts
        {
            get { return new Card(CardSuit.Hearts, CardFace.King); }
        }

        #endregion Static Cards - Hearts

        #region Static Cards - Spades

        /// <summary>
        /// Gets the Ace of spades.
        /// </summary>
        public static Card AceOfSpades
        {
            get { return new Card(CardSuit.Spades, CardFace.Ace); }
        }

        /// <summary>
        /// Gets the Two of spades.
        /// </summary>
        public static Card TwoOfSpades
        {
            get { return new Card(CardSuit.Spades, CardFace.Two); }
        }

        /// <summary>
        /// Gets the Three of spades.
        /// </summary>
        public static Card ThreeOfSpades
        {
            get { return new Card(CardSuit.Spades, CardFace.Three); }
        }

        /// <summary>
        /// Gets the Four of spades.
        /// </summary>
        public static Card FourOfSpades
        {
            get { return new Card(CardSuit.Spades, CardFace.Four); }
        }

        /// <summary>
        /// Gets the Five of spades.
        /// </summary>
        public static Card FiveOfSpades
        {
            get { return new Card(CardSuit.Spades, CardFace.Five); }
        }

        /// <summary>
        /// Gets the Six of spades.
        /// </summary>
        public static Card SixOfSpades
        {
            get { return new Card(CardSuit.Spades, CardFace.Six); }
        }

        /// <summary>
        /// Gets the Seven of spades.
        /// </summary>
        public static Card SevenOfSpades
        {
            get { return new Card(CardSuit.Spades, CardFace.Seven); }
        }

        /// <summary>
        /// Gets the Eight of spades.
        /// </summary>
        public static Card EightOfSpades
        {
            get { return new Card(CardSuit.Spades, CardFace.Eight); }
        }

        /// <summary>
        /// Gets the Nine of spades.
        /// </summary>
        public static Card NineOfSpades
        {
            get { return new Card(CardSuit.Spades, CardFace.Nine); }
        }

        /// <summary>
        /// Gets the Ten of spades.
        /// </summary>
        public static Card TenOfSpades
        {
            get { return new Card(CardSuit.Spades, CardFace.Ten); }
        }

        /// <summary>
        /// Gets the Jack of spades.
        /// </summary>
        public static Card JackOfSpades
        {
            get { return new Card(CardSuit.Spades, CardFace.Jack); }
        }

        /// <summary>
        /// Gets the Queen of spades.
        /// </summary>
        public static Card QueenOfSpades
        {
            get { return new Card(CardSuit.Spades, CardFace.Queen); }
        }

        /// <summary>
        /// Gets the King of spades.
        /// </summary>
        public static Card KingOfSpades
        {
            get { return new Card(CardSuit.Spades, CardFace.King); }
        }

        #endregion Static Cards - Spades

        /// <summary>
        /// Gets or sets a value indicating the playing card suit (hearts, clubs...).
        /// </summary>
        public CardSuit Suit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the playing card face (ace, two, three...).
        /// </summary>
        public CardFace Face { get; set; }

        #region Operators

        /// <summary>
        /// Applies the equals (==) operator.
        /// </summary>
        /// <param name="card1">The first card to compare.</param>
        /// <param name="card2">The second card to compare.</param>
        /// <returns>True if the cards match Face and Suite values.</returns>
        public static bool operator ==(Card card1, Card card2)
        {
            if (object.ReferenceEquals(card1, card2))
            {
                return true; // For two nulls
            }

            if (object.ReferenceEquals(card1, null) || object.ReferenceEquals(card2, null))
            {
                return false; // For one nulls, one not null
            }

            return (card1.Face == card2.Face) && (card1.Suit == card2.Suit);
        }

        /// <summary>
        /// Applies the equals (==) operator.
        /// </summary>
        /// <param name="card1">The first card to compare.</param>
        /// <param name="card2">The second card to compare.</param>
        /// <returns>True if the cards do not match Face and Suite values.</returns>
        public static bool operator !=(Card card1, Card card2)
        {
            if (object.ReferenceEquals(card1, card2))
            {
                return false; // For nulls
            }

            if (object.ReferenceEquals(card1, null) || object.ReferenceEquals(card2, null))
            {
                return true; // For one nulls, one not null
            }

            return (card1.Face != card2.Face) || (card1.Suit != card2.Suit);
        }

        #endregion Operators

        /// <summary>
        /// Converts the card to a string representation.
        /// </summary>
        /// <returns>A string.</returns>
        public override string ToString()
        {
            return string.Format("{0} of {1}", this.Face, this.Suit);
        }

        /// <summary>
        /// Returns a string representing the card face. For example: King.
        /// </summary>
        /// <returns>A short string representation of the card.</returns>
        public string ToShortString()
        {
            return this.Face.ToString();
        }

        /// <summary>
        /// Compares the specified object to the instance.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>True if the objects are equal.</returns>
        public override bool Equals(object obj)
        {
            return this == (Card)obj;
        }

        /// <summary>
        /// Returns the hash code for the value of this instance.
        /// </summary>
        /// <returns>An integer.</returns>
        public override int GetHashCode()
        {
            return (this.Face.GetHashCode() * 50) ^ this.Suit.GetHashCode();
        }

        #region ICloneable Members

        /// <summary>
        /// Clones the current instance.
        /// </summary>
        /// <returns>The cloned instance.</returns>
        public object Clone()
        {
            return new Card(this.Suit, this.Face);
        }

        #endregion
    }
}
