using JamesGames.War;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JamesGames.PlayingCards;

namespace JamesGames.War.Tests
{
    
    
    /// <summary>
    ///This is a test class for WarCardComparerTest and is intended
    ///to contain all WarCardComparerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WarCardComparerTest
    {

        /// <summary>
        ///A test for Compare
        ///</summary>
        [TestMethod()]
        public void CompareUsingSortTest()
        {
            WarCardComparer target = new WarCardComparer(); // TODO: Initialize to an appropriate value

            Card[] unorderedCards = {   
                Card.AceOfClubs,
                Card.TwoOfClubs,
                new Card(CardSuit.Clubs, CardFace.King),
                Card.AceOfDiamonds };

            CardList cardList = new CardList(unorderedCards);

            cardList.Sort(new WarCardComparer());

            Assert.AreEqual(cardList[0].Face, CardFace.Two);
            Assert.AreEqual(cardList[1].Face, CardFace.King);
            Assert.AreEqual(cardList[2].Face, CardFace.Ace);
            Assert.AreEqual(cardList[3].Face, CardFace.Ace);
        }
    }
}
