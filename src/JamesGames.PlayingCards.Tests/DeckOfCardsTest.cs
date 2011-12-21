﻿using JamesGames.PlayingCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JamesGames.PlayingCards.Tests.Mocks;

namespace JamesGames.PlayingCards.Tests
{
    /// <summary>
    ///This is a test class for DeckOfCardsTest and is intended
    ///to contain all DeckOfCardsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DeckOfCardsTest
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
        ///A test for Reset
        ///</summary>
        [TestMethod()]
        public void ResetrDefaultsToStandardDeckTest()
        {
            DeckOfCards target = new DeckOfCards();
            target.Clear();
            Assert.AreEqual(target.Count, 0);
            target.Reset();
            TestData.AssertIsStandard52CardDeck(target.ToArray());
        }

        /// <summary>
        ///A test for Reset
        ///</summary>
        [TestMethod()]
        public void ResetrDefaultsToDeckOfCardSupplierTest()
        {
            DeckOfCards target = new DeckOfCards(new Mock1AceOfSpadesDeckOfCardSupplier());
            target.Clear();
            Assert.AreEqual(target.Count, 0);
            target.Reset();
            Assert.AreEqual(target.Count, 1);
            Assert.AreEqual(target[0], new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Ace));
        }

        /// <summary>
        ///A test for DeckOfCards Constructor
        ///</summary>
        [TestMethod()]
        public void DeckOfCardsConstructorDefaultsToStandardDeckTest()
        {
            DeckOfCards target = new DeckOfCards();
            TestData.AssertIsStandard52CardDeck(target.ToArray());
        }

        /// <summary>
        ///A test for DeckOfCards Constructor
        ///</summary>
        [TestMethod()]
        public void DeckOfCardsConstructorUsesDeckOfCardsSupplierTest()
        {
            IDeckOfCardsSupplier cardSupplier = new Mock1AceOfSpadesDeckOfCardSupplier();
            DeckOfCards target = new DeckOfCards(cardSupplier);
            Assert.AreEqual(target.Count, 1);
            Assert.AreEqual(target[0], new PlayingCard(PlayingCardSuit.Spades, PlayingCardFace.Ace));
        }
    }
}
