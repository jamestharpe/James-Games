using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamesGames.PlayingCards
{
    /// <summary>
    /// Represents a list of playing cards.
    /// </summary>
    public class PlayingCardList : List<PlayingCard>
    {
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

        public PlayingCard DealTo(PlayingCardList cards)
        {
            if (this.Count < 1)
                throw new InvalidOperationException("List is Empty.");

            PlayingCard result = this[0];
            cards.Add(result);
            this.RemoveAt(0);

            return result;   
        }
    }
}
