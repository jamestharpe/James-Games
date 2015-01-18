using System;
using JamesGames.PlayingCards;
using JamesGames.War.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamesGames.War.Tests
{
    
    
    /// <summary>
    ///This is a test class for WarPlayerTest and is intended
    ///to contain all WarPlayerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WarPlayerTest
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

        #region Game property tests
        /// <summary>
        ///A test for Game
        ///</summary>
        [TestMethod()]
        public void GameSimpleAssignmentTest()
        {
            WarPlayer target = new WarPlayer(); // TODO: Initialize to an appropriate value
            AbstractWarGame expected = new MockWarGame(WarGameState.AtBattle);
            AbstractWarGame actual = expected;
            target.Game = expected;
            actual = target.Game;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Game
        ///</summary>
        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void GameInvalidReAssignmentTest()
        {
            WarPlayer target = new WarPlayer();
            target.Game = new MockWarGame(WarGameState.AtBattle);
            target.Game = new MockWarGame(WarGameState.AtBattle);
            Assert.Fail();
        }

        /// <summary>
        ///A test for Game
        ///</summary>
        [TestMethod()]
        public void GameProperReAssignmentTest()
        {
            WarPlayer target = new WarPlayer();
            AbstractWarGame expected = new MockWarGame(WarGameState.AtBattle);
            target.Game = new MockWarGame(WarGameState.AtBattle);
            target.Game = null;
            target.Game = expected;
            Assert.AreEqual(expected, target.Game);
        }
        #endregion Game property tests

        #region Play method tests
        /// <summary>
        ///A test for Play
        ///</summary>
        [TestMethod()]
        public void PlayAtBattleTest()
        {
            WarPlayer target = new WarPlayer(); // TODO: Initialize to an appropriate value
            target.Cards.AddRange(CardList.CreateDeck());
            MockWarGame warGame = new MockWarGame(WarGameState.AtBattle);
            target.Game = warGame;
            target.Play();
            warGame.AssertCallCounts(playerBattle:1);
        }

        [TestMethod()]
        public void PlayWarDeclaredTest()
        {
            WarPlayer target = new WarPlayer();
            target.Cards.AddRange(CardList.CreateDeck());
            MockWarGame warGame = new MockWarGame(WarGameState.WarDeclared);
            target.Game = warGame;
            target.Play();
            warGame.AssertCallCounts(playerGoToWar: 1);
        }

        [TestMethod()]
        public void PlayAtWarBattleTest()
        {
            WarPlayer target = new WarPlayer();
            target.Cards.AddRange(CardList.CreateDeck());
            MockWarGame warGame = new MockWarGame(WarGameState.WarDeclared);
            target.Game = warGame;
            target.Play();
            warGame.SetGameState(WarGameState.AtWar);
            target.Play();
            warGame.AssertCallCounts(playerGoToWar:1, playerPickWarAttack:1, lastAttackIndex:2);
        }

        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void PlayGameOverTest()
        {
            WarPlayer target = new WarPlayer();
            target.Cards.AddRange(CardList.CreateDeck());
            MockWarGame warGame = new MockWarGame(WarGameState.GameOver);
            target.Game = warGame;
            target.Play();
            warGame.AssertCallCounts();
        }

        /// <summary>
        ///A test for Play
        ///</summary>
        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void PlayWithoutCardsTest()
        {
            WarPlayer target = new WarPlayer(); // TODO: Initialize to an appropriate value
            MockWarGame warGame = new MockWarGame(WarGameState.AtBattle);
            target.Game = warGame;
            target.Play();
            warGame.AssertCallCounts(
                playerBattle: 1,
                playerGoToWar: 0,
                playerPickWarAttack: 0);
        }
        #endregion Play method tests

        /// <summary>
        ///A test for Cards
        ///</summary>
        [TestMethod()]
        public void CardsTest()
        {
            WarPlayer target = new WarPlayer(); // TODO: Initialize to an appropriate value
            CardList actual = target.Cards;
            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            WarPlayer target = new WarPlayer();
            const string expected = "James";
            target.Name = expected;
            string actual = target.Name;
            Assert.AreEqual(expected, actual);
        }
    }
}
