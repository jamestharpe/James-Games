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
        ///A test for Reset
        ///</summary>
        [TestMethod()]
        public void Reset_DefaultsToStandardDeckTest()
        {
            DeckOfCards target = new DeckOfCards();
            target.Clear();
            Assert.AreEqual(target.Count, 0);
            target.Reset();
            TestData.AssertIsStandard52CardDeck(target.ToArray());
        }

        /// <summary>
        ///A test for DeckOfCards Constructor
        ///</summary>
        [TestMethod()]
        public void DeckOfCardsConstructor_DefaultsToStandardDeckTest()
        {
            DeckOfCards target = new DeckOfCards();
            TestData.AssertIsStandard52CardDeck(target.ToArray());
        }
    }
}
