using JamesGames.PlayingCards;
using System;

namespace JamesGames.PlayingCards.Tests.Mocks
{
    public class Mock1AceOfSpadesDeckOfCardSupplier : IDeckOfCardsSupplier
    {

        public PlayingCard[] SupplyDeck()
		{
		    return new PlayingCard[] {
		        PlayingCard.AceOfSpades
		    };
        }
    }
}
