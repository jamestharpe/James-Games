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
        ///A test for PlayingCard Constructor
        ///</summary>
        [TestMethod()]
        public void PlayingCardConstructorTest()
        {
            PlayingCard target = new PlayingCard(PlayingCardSuit.Clubs, PlayingCardFace.Four);
            Assert.AreEqual(target.Face, PlayingCardFace.Four);
            Assert.AreEqual(target.Suit, PlayingCardSuit.Clubs);
        }

        /// <summary>
        ///A test for PlayingCard Constructor
        ///</summary>
        [TestMethod()]
        public void PlayingCardDefaultConstructorTest()
        {
            PlayingCard target = new PlayingCard();
            Assert.AreEqual(target.Face, PlayingCardFace.Ace);
            Assert.AreEqual(target.Suit, PlayingCardSuit.Spades);
        }

        /// <summary>
        ///A test for Face
        ///</summary>
        [TestMethod()]
        public void FaceTest()
        {
            PlayingCard target = PlayingCard.EightOfDiamonds;
            Assert.AreEqual(target.Face, PlayingCardFace.Eight);
            target.Face = PlayingCardFace.Five;
            Assert.AreEqual(target.Face, PlayingCardFace.Five);
        }

        /// <summary>
        ///A test for Suit
        ///</summary>
        [TestMethod()]
        public void SuitTest()
        {
            PlayingCard target = PlayingCard.FiveOfHearts;
            Assert.AreEqual(target.Suit, PlayingCardSuit.Hearts);
            target.Suit = PlayingCardSuit.Spades;
            Assert.AreEqual(target.Suit, PlayingCardSuit.Spades);
        }
    }
}
