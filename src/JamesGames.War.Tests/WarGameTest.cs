using JamesGames.War;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JamesGames.PlayingCards;

namespace JamesGames.War.Tests
{
    /// <summary>
    ///This is a test class for WarGameTest and is intended
    ///to contain all WarGameTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WarGameTest
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

        [TestMethod()]
        public void AdvancePlayWarTest()
        {
            WarGame target = new WarGame(
                new WarPlayer() { Name = "Player 1" },
                new WarPlayer() { Name = "Player 2" });
        }

        /// <summary>
        ///A test for GameState
        ///</summary>
        [TestMethod()]
        public void GameStateTest()
        {
            WarPlayer[] players = null; // TODO: Initialize to an appropriate value
            WarGame target = new WarGame(players); // TODO: Initialize to an appropriate value
            WarGameState actual;
            actual = target.GameState;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Winner
        ///</summary>
        [TestMethod()]
        public void WinnerTest()
        {
            WarPlayer[] players = null; // TODO: Initialize to an appropriate value
            WarGame target = new WarGame(players); // TODO: Initialize to an appropriate value
            WarPlayer actual;
            actual = target.Winner;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RemovePlayers
        ///</summary>
        [TestMethod()]
        public void RemovePlayersTest()
        {
            WarPlayer[] players = null; // TODO: Initialize to an appropriate value
            WarGame target = new WarGame(players); // TODO: Initialize to an appropriate value
            WarPlayer[] players1 = null; // TODO: Initialize to an appropriate value
            target.RemovePlayers(players1);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for NewGame
        ///</summary>
        [TestMethod()]
        public void NewGameTest()
        {
            WarPlayer[] players = null; // TODO: Initialize to an appropriate value
            WarGame target = new WarGame(players); // TODO: Initialize to an appropriate value
            target.NewGame();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AdvancePlay
        ///</summary>
        [TestMethod()]
        public void AdvancePlayTest()
        {
            WarPlayer[] players = null; // TODO: Initialize to an appropriate value
            WarGame target = new WarGame(players); // TODO: Initialize to an appropriate value
            target.AdvancePlay();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddPlayers
        ///</summary>
        [TestMethod()]
        public void AddPlayersTest()
        {
            WarPlayer[] players = null; // TODO: Initialize to an appropriate value
            WarGame target = new WarGame(players); // TODO: Initialize to an appropriate value
            WarPlayer[] players1 = null; // TODO: Initialize to an appropriate value
            target.AddPlayers(players1);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WarGame Constructor
        ///</summary>
        [TestMethod()]
        public void WarGameConstructorTest()
        {
            WarPlayer[] players = null; // TODO: Initialize to an appropriate value
            WarGame target = new WarGame(players);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        #region PlayerPickWarAttack method tests
        /// <summary>
        ///A test for PlayerPickWarAttack
        ///</summary>
        [TestMethod()]
        public void PlayerPickWarAttackTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" } };

            players[0].Cards.Add(PlayingCard.TwoOfDiamonds);
            players[0].Cards.Add(PlayingCard.ThreeOfDiamonds);
            players[0].Cards.Add(PlayingCard.FourOfDiamonds);

            WarGame target = new WarGame(players);
            target.PlayerDeclareWar(players[0]);
            PlayingCard attackCard = target.PlayerPickWarAttack(players[0], 1);

            Assert.AreEqual(PlayingCard.ThreeOfDiamonds, attackCard);

            Assert.AreEqual(target.Winner, players[0]);
            Assert.AreEqual(0, players[0].Cards.Count);
        }

        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void PlayerPickWarAttackTwiceTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" }};

            players[0].Cards.Add(PlayingCard.TwoOfDiamonds);
            players[0].Cards.Add(PlayingCard.ThreeOfDiamonds);
            players[0].Cards.Add(PlayingCard.FourOfDiamonds);

            WarGame target = new WarGame(players);
            target.PlayerDeclareWar(players[0]);
            target.PlayerPickWarAttack(players[0], 1);
            target.PlayerPickWarAttack(players[0], 1);

            Assert.Fail();
        }
        #endregion PlayerPickWarAttack method tests

        #region PlayerGoToWar method tests
        /// <summary>
        ///A test for PlayerGoToWar
        ///</summary>
        [TestMethod()]
        public void PlayerGoToWarTest()
        {
            var players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" },
                new WarPlayer(){ Name = "Player 2" } };

            players[0].Cards.Add(PlayingCard.TwoOfDiamonds);
            players[0].Cards.Add(PlayingCard.ThreeOfDiamonds);
            players[0].Cards.Add(PlayingCard.FourOfDiamonds);

            var target = new WarGame(players);
            target.PlayerDeclareWar(players[0]);

            Assert.AreEqual(0, players[0].Cards.Count);
            Assert.AreEqual(0, players[1].Cards.Count);
        }

        [TestMethod()]
        public void PlayerGoToWarWithOnlyTwoCardsTest()
        {
            var players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" } };

            players[0].Cards.Add(PlayingCard.TwoOfDiamonds);
            players[0].Cards.Add(PlayingCard.ThreeOfDiamonds);

            var target = new WarGame(players);
            target.PlayerDeclareWar(players[0]);

            Assert.AreEqual(0, players[0].Cards.Count);
        }

        [TestMethod()]
        public void PlayerGoToWarWithOnlyOneCardTest()
        {
            var players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" } };

            players[0].Cards.Add(PlayingCard.TwoOfDiamonds);

            var target = new WarGame(players);
            target.PlayerDeclareWar(players[0]);

            Assert.AreEqual(0, players[0].Cards.Count);
        }
        #endregion PlayerGoToWar method tests

        #region PlayerBattle method tests
        /// <summary>
        ///A test for PlayerBattle
        ///</summary>
        [TestMethod()]
        public void PlayerBattleTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" }};

            players[0].Cards.Add(PlayingCard.AceOfDiamonds);

            var target = new WarGame(players);
            target.PlayerBattle(players[0]);
            Assert.AreEqual(0, players[0].Cards.Count);
        }

        /// <summary>
        ///A test for PlayerBattle
        ///</summary>
        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void PlayerBattleWithoutCardsTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" }};

            var target = new WarGame(players);
            target.PlayerBattle(players[0]);
            Assert.Fail();
        }
        #endregion PlayerBattle method tests
    }
}
