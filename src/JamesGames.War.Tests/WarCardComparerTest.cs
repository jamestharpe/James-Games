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


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


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
