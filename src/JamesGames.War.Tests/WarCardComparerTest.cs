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

            PlayingCard[] unorderedCards = {   
                PlayingCard.AceOfClubs,
                PlayingCard.TwoOfClubs,
                new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.King),
                PlayingCard.AceOfDiamonds };

            PlayingCardList cardList = new PlayingCardList(unorderedCards);

            cardList.Sort(new WarCardComparer());

            Assert.AreEqual(cardList[0].Face, PlayingCardFace.Two);
            Assert.AreEqual(cardList[1].Face, PlayingCardFace.King);
            Assert.AreEqual(cardList[2].Face, PlayingCardFace.Ace);
            Assert.AreEqual(cardList[3].Face, PlayingCardFace.Ace);
        }
    }
}
