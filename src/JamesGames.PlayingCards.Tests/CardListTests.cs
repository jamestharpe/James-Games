using JamesGames.PlayingCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JamesGames.PlayingCards.Tests
{
    /// <summary>
    ///This is a test class for DeckOfCardsTest and is intended
    ///to contain all DeckOfCardsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CardListTests
    {
        [TestMethod]
        public void CreateDeck_CreatesASingleStandardDeck()
        {
            TestData.AssertIsStandard52CardDeck(CardList.CreateDeck().ToArray());
        }

        [TestMethod]
        public void CreateDecks_CreatesDefaultsToASingleStandardDeck()
        {
            TestData.AssertIsStandard52CardDeck(CardList.CreateDecks().ToArray());
        }

        [TestMethod]
        public void CreateDecks_CreatesSpecifiedNumberOfDecks()
        {
            TestData.AssertIsStandard52CardDeck(CardList.CreateDecks(2).ToArray(), 2);
            TestData.AssertIsStandard52CardDeck(CardList.CreateDecks(7).ToArray(), 7);
        }
    }
}
