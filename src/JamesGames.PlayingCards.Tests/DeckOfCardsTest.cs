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
    public class DeckOfCardsTest
    {
        [TestMethod]
        public void DeckOfCardsConstructor_DefaultsToASingleStandardDeck()
        {
            DeckOfCards sut = new DeckOfCards();
            TestData.AssertIsStandard52CardDeck(sut.ToArray());
        }

        [TestMethod]
        public void DeckOfCardsConstructor_CreatesSpecifiedNumberOfDecks()
        {
            var sut = new DeckOfCards(2);
            TestData.AssertIsStandard52CardDeck(sut.ToArray(), 2);
        }
    }
}
