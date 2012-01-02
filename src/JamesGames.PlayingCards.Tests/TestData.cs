using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamesGames.PlayingCards.Tests
{
    public class TestData
    {
        public static PlayingCard[] Standard52CardDeck = {  
            PlayingCard.AceOfClubs,
            PlayingCard.TwoOfClubs,
            PlayingCard.ThreeOfClubs,
            PlayingCard.FourOfClubs,
            PlayingCard.FiveOfClubs,
            PlayingCard.SixOfClubs,
            PlayingCard.SevenOfClubs,
            PlayingCard.EightOfClubs,
            PlayingCard.NineOfClubs,
            PlayingCard.TenOfClubs,
            PlayingCard.JackOfClubs,
            PlayingCard.QueenOfClubs,
            PlayingCard.KingOfClubs,
            PlayingCard.AceOfDiamonds,
            PlayingCard.TwoOfDiamonds,
            PlayingCard.ThreeOfDiamonds,
            PlayingCard.FourOfDiamonds,
            PlayingCard.FiveOfDiamonds,
            PlayingCard.SixOfDiamonds,
            PlayingCard.SevenOfDiamonds,
            PlayingCard.EightOfDiamonds,
            PlayingCard.NineOfDiamonds,
            PlayingCard.TenOfDiamonds,
            PlayingCard.JackOfDiamonds,
            PlayingCard.QueenOfDiamonds,
            PlayingCard.KingOfDiamonds,
            PlayingCard.AceOfHearts,
            PlayingCard.TwoOfHearts,
            PlayingCard.ThreeOfHearts,
            PlayingCard.FourOfHearts,
            PlayingCard.FiveOfHearts,
            PlayingCard.SixOfHearts,
            PlayingCard.SevenOfHearts,
            PlayingCard.EightOfHearts,
            PlayingCard.NineOfHearts,
            PlayingCard.TenOfHearts,
            PlayingCard.JackOfHearts,
            PlayingCard.QueenOfHearts,
            PlayingCard.KingOfHearts,
            PlayingCard.AceOfSpades,
            PlayingCard.TwoOfSpades,
            PlayingCard.ThreeOfSpades,
            PlayingCard.FourOfSpades,
            PlayingCard.FiveOfSpades,
            PlayingCard.SixOfSpades,
            PlayingCard.SevenOfSpades,
            PlayingCard.EightOfSpades,
            PlayingCard.NineOfSpades,
            PlayingCard.TenOfSpades,
            PlayingCard.JackOfSpades,
            PlayingCard.QueenOfSpades,
            PlayingCard.KingOfSpades };
        
        public static void AssertIsStandard52CardDeck(PlayingCard[] cards)
        {
            Assert.AreEqual(cards.Length, Standard52CardDeck.Length);

            foreach (PlayingCard expectedCard in Standard52CardDeck) //Do not assume order
                Assert.IsTrue(cards.Contains(expectedCard));
        }
    }
}
