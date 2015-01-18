using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamesGames.PlayingCards.Tests
{
    public class TestData
    {
        public static Card[] Standard52CardDeck = {  
            Card.AceOfClubs,
            Card.TwoOfClubs,
            Card.ThreeOfClubs,
            Card.FourOfClubs,
            Card.FiveOfClubs,
            Card.SixOfClubs,
            Card.SevenOfClubs,
            Card.EightOfClubs,
            Card.NineOfClubs,
            Card.TenOfClubs,
            Card.JackOfClubs,
            Card.QueenOfClubs,
            Card.KingOfClubs,
            Card.AceOfDiamonds,
            Card.TwoOfDiamonds,
            Card.ThreeOfDiamonds,
            Card.FourOfDiamonds,
            Card.FiveOfDiamonds,
            Card.SixOfDiamonds,
            Card.SevenOfDiamonds,
            Card.EightOfDiamonds,
            Card.NineOfDiamonds,
            Card.TenOfDiamonds,
            Card.JackOfDiamonds,
            Card.QueenOfDiamonds,
            Card.KingOfDiamonds,
            Card.AceOfHearts,
            Card.TwoOfHearts,
            Card.ThreeOfHearts,
            Card.FourOfHearts,
            Card.FiveOfHearts,
            Card.SixOfHearts,
            Card.SevenOfHearts,
            Card.EightOfHearts,
            Card.NineOfHearts,
            Card.TenOfHearts,
            Card.JackOfHearts,
            Card.QueenOfHearts,
            Card.KingOfHearts,
            Card.AceOfSpades,
            Card.TwoOfSpades,
            Card.ThreeOfSpades,
            Card.FourOfSpades,
            Card.FiveOfSpades,
            Card.SixOfSpades,
            Card.SevenOfSpades,
            Card.EightOfSpades,
            Card.NineOfSpades,
            Card.TenOfSpades,
            Card.JackOfSpades,
            Card.QueenOfSpades,
            Card.KingOfSpades };
        
        public static void AssertIsStandard52CardDeck(Card[] cards, int expectedDeckCount = 1)
        {
            Assert.AreEqual(cards.Length, Standard52CardDeck.Length * expectedDeckCount);

            foreach (var expectedCard in Standard52CardDeck)
            {
                Assert.IsTrue(cards.Contains(expectedCard));
            }
        }
    }
}
