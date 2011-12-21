using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamesGames.PlayingCards
{
    /// <summary>
    /// When implemented in a derived class, supplies a complete deck of cards. The deck supplied 
    /// is specific to the game being played and is not necessarily shuffled.
    /// </summary>
    public interface IDeckOfCardsSupplier
    {
        PlayingCard[] SupplyDeck();
    }
}
