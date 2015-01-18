using System;
using System.Collections.Generic;

namespace JamesGames.PlayingCards
{
    /// <summary>
    /// Represents a list of playing cards.
    /// </summary>
    public class PlayingCardList : List<PlayingCard>, ICloneable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of PlayingCardList.
        /// </summary>
        public PlayingCardList()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of PlayingCardList.
        /// </summary>
        public PlayingCardList(int capacity)
            : base(capacity)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of PlayingCardList.
        /// </summary>
        /// <param name="cards">The cards that initially make up the list.</param>
        public PlayingCardList(IEnumerable<PlayingCard> cards)
            : base(cards)
        {
            
        }
        #endregion Constructors

        /// <summary>
        /// Deals the top card from the current instance to the specified instance.
        /// </summary>
        /// <param name="cards">Specifies the destination for the dealt card.</param>
        /// <returns>The <see cref="PlayingCard"/> that was dealt.</returns>
        public PlayingCard DealTo(PlayingCardList cards)
        {
            if (this.Count < 1)
                throw new InvalidOperationException("There are no cards to deal.");

            PlayingCard result = this[0];
            cards.Add(result);
            RemoveAt(0);

            return result;   
        }

        #region ICloneable Members

        /// <summary>
        /// Clones the collection of cards.
        /// </summary>
        /// <returns>A <see cref="PlayingCardList"/>.</returns>
        public virtual object Clone()
        {
            var result = new PlayingCardList();
            foreach (var card in this)
            {
                result.Add((PlayingCard)card.Clone());
            }

            return result;
        }

        #endregion
    }
}
