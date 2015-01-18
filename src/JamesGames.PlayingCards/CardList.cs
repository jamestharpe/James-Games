[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1633:FileMustHaveHeader", Justification = "Reviewed.")]

namespace JamesGames.PlayingCards
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Represents a list of playing cards.
    /// </summary>
    public class CardList : List<Card>, ICloneable
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CardList"/> class.
        /// </summary>
        public CardList()
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CardList"/> class.
        /// </summary>
        /// <param name="capacity">The number of cards the list can initially store.</param>
        public CardList(int capacity)
            : base(capacity)
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CardList"/> class.
        /// </summary>
        /// <param name="cards">The cards that initially make up the list.</param>
        public CardList(IEnumerable<Card> cards)
            : base(cards)
        {            
        }

        #endregion Constructors

        /// <summary>
        /// Creates the specified number of standard 52 card decks.
        /// </summary>
        /// <param name="numberOfDecks">The number of decks to create.</param>
        /// <returns>The deck of cards.</returns>
        public static CardList CreateDecks(int numberOfDecks = 1)
        {
            var cardSuits = (CardSuit[])Enum.GetValues(typeof(CardSuit));
            var cardFaces = (CardFace[])Enum.GetValues(typeof(CardFace));
            var result = new CardList(numberOfDecks * cardSuits.Length * cardFaces.Length);

            for (int i = 0; i < numberOfDecks; i++)
            {
                foreach (var suit in cardSuits)
                {
                    foreach (var face in cardFaces)
                    {
                        result.Add(new Card(suit, face));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Creates a standard deck of cards.
        /// </summary>
        /// <returns>A deck of cards</returns>
        public static CardList CreateDeck()
        {
            return CreateDecks();
        }

        /// <summary>
        /// Deals the top card from the current instance to the specified instance.
        /// </summary>
        /// <param name="cards">Specifies the destination for the dealt card.</param>
        /// <returns>The <see cref="Card"/> that was dealt.</returns>
        public Card DealTo(CardList cards)
        {
            if (this.Count < 1)
            {
                throw new InvalidOperationException("There are no cards to deal.");
            }

            var result = this[0];
            cards.Add(result);
            this.RemoveAt(0);

            return result;   
        }

        /// <summary>
        /// Returns a string representation of the card list.
        /// </summary>
        /// <returns>A string.</returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            this.ForEach(c => result.AppendLine(c.ToString()));
            return result.ToString();
        }

        #region ICloneable Members

        /// <summary>
        /// Clones the collection of cards.
        /// </summary>
        /// <returns>A <see cref="CardList"/>.</returns>
        public virtual object Clone()
        {
            var result = new CardList();
            foreach (var card in this)
            {
                result.Add((Card)card.Clone());
            }

            return result;
        }

        #endregion
    }
}
