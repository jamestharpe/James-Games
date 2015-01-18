using JamesGames.PlayingCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JamesGames.PlayingCards.Tests
{
    
    
    /// <summary>
    ///This is a test class for PlayingCardTest and is intended
    ///to contain all PlayingCardTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PlayingCardTests
    {

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
        ///A test for PlayingCard Constructor
        ///</summary>
        [TestMethod()]
        public void PlayingCardConstructor_SetsFaceAndSuit()
        {
            var sut = new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Four);
            Assert.AreEqual(sut.Face, PlayingCardFace.Four);
            Assert.AreEqual(sut.Suit, PlayingCardSuit.Clubs);
        }

        /// <summary>
        ///A test for PlayingCard Constructor
        ///</summary>
        [TestMethod()]
        public void PlayingCardDefaultConstructor_DefaultsToAceOfSpades()
        {
            var sut = new PlayingCard();
            Assert.AreEqual(sut.Face, PlayingCardFace.Ace);
            Assert.AreEqual(sut.Suit, PlayingCardSuit.Spades);
        }

        /// <summary>
        ///A test for Face
        ///</summary>
        [TestMethod()]
        public void Face_IsReadWrite()
        {
            var target = new PlayingCard();
            target.Face = PlayingCardFace.Five;
            Assert.AreEqual(target.Face, PlayingCardFace.Five);
        }

        /// <summary>
        ///A test for Suit
        ///</summary>
        [TestMethod()]
        public void Suit_IsReadWrite()
        {
            var target = new PlayingCard();
            target.Suit = PlayingCardSuit.Clubs;
            Assert.AreEqual(target.Suit, PlayingCardSuit.Clubs);
        }
    }
}
