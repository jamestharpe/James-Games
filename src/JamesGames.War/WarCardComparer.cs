﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JamesGames.PlayingCards;

namespace JamesGames.War
{
    /// <summary>
    /// Comparer for <see cref="Card"/>s in the game of War.
    /// </summary>
    class WarCardComparer : Comparer<Card>
    {
        /// <summary>
        /// Performs a comparison of two playing cards and returns a value indicating whether one 
        /// card is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first card to compare.</param>
        /// <param name="y">The second card to compare.</param>
        public override int Compare(Card x, Card y)
        {
            int xCardValue = (x.Face == CardFace.Ace) ? 14 : (int)x.Face;
            int yCardValue = (y.Face == CardFace.Ace) ? 14 : (int)y.Face;

            // ??? return xCardValue - yCardValue;

            if (xCardValue > yCardValue)
            {
                return 1;
            }

            if (xCardValue < yCardValue)
            {
                return -1;
            }

            return 0;
        }
    }
}
