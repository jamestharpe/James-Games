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
            new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Ace),
            new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Two),
            new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Three),
            new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Four),
            new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Five),
            new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Six),
            new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Seven),
            new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Eight),
            new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Nine),
            new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Ten),
            new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Jack),
            new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Queen),
            new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.King),
            new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Ace),
            new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Two),
            new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Three),
            new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Four),
            new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Five),
            new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Six),
            new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Seven),
            new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Eight),
            new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Nine),
            new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Ten),
            new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Jack),
            new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.Queen),
            new PlayingCard(PlayingCardSuit.Diamonds, PlayingCardFace.King),
            new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Ace),
            new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Two),
            new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Three),
            new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Four),
            new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Five),
            new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Six),
            new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Seven),
            new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Eight),
            new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Nine),
            new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Ten),
            new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Jack),
            new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.Queen),
            new PlayingCard(PlayingCardSuit.Hearts, PlayingCardFace.King),
            new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Ace),
            new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Two),
            new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Three),
            new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Four),
            new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Five),
            new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Six),
            new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Seven),
            new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Eight),
            new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Nine),
            new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Ten),
            new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Jack),
            new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Queen),
            new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.King) };
        
        public static void AssertIsStandard52CardDeck(PlayingCard[] cards)
        {
            Assert.AreEqual(cards.Length, Standard52CardDeck.Length);

            foreach (PlayingCard expectedCard in Standard52CardDeck) //Do not assume order
                Assert.IsTrue(cards.Contains(expectedCard));
        }
    }
}
