using JamesGames.War;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JamesGames.PlayingCards;
using System.Collections.Generic;
using System.Linq;
namespace JamesGames.War.Tests
{
    
    
    /// <summary>
    ///This is a test class for BattleFieldTest and is intended
    ///to contain all BattleFieldTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BattleFieldTest
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


        private static void AssertTargetIsNotMidBattle(BattleField target)
        {
            Assert.AreEqual(0, target.ActiveAttackCount);
            Assert.AreEqual(0, target.CardCount);
            Assert.AreEqual(0, target.HighCardHolders.Count());
            Assert.IsNull(target.Winner);
        }
        /// <summary>
        ///A test for BattleField Constructor
        ///</summary>
        [TestMethod()]
        public void BattleFieldConstructorTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" },
                new WarPlayer(){ Name = "Player 2" } };
            BattleField target = new BattleField(players);
            
            AssertTargetIsNotMidBattle(target);
        }

        #region AwardWinner Method tests
        /// <summary>
        ///A test for AwardWinner
        ///</summary>
        [TestMethod()]
        public void AwardWinnerAfterWinTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" },
                new WarPlayer(){ Name = "Player 2" } };

            players[0].Cards.Add(PlayingCard.AceOfDiamonds);
            players[1].Cards.Add(PlayingCard.TwoOfDiamonds);

            BattleField target = new BattleField(players);
            target.PlayerBattle(players[0]);
            target.PlayerBattle(players[1]);

            const int expected = 2;
            int actual = target.AwardWinner();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(2, players[0].Cards.Count);
            Assert.AreEqual(0, players[1].Cards.Count);
        }

        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void AwardWinnerAfterDrawTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" },
                new WarPlayer(){ Name = "Player 2" } };

            players[0].Cards.Add(PlayingCard.AceOfDiamonds);
            players[1].Cards.Add(PlayingCard.AceOfClubs);

            BattleField target = new BattleField(players);
            target.PlayerBattle(players[0]);
            target.PlayerBattle(players[1]);

            int actual = target.AwardWinner();
            Assert.Fail();
        }

        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void AwardWinnerBeforeAllPlayersPlayedTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" },
                new WarPlayer(){ Name = "Player 2" } };

            players[0].Cards.Add(PlayingCard.AceOfDiamonds);
            players[1].Cards.Add(PlayingCard.TwoOfDiamonds);

            BattleField target = new BattleField(players);
            target.PlayerBattle(players[0]);

            int actual = target.AwardWinner();
            Assert.Fail();
        }

        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void AwardWinnerBeforePlayTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" },
                new WarPlayer(){ Name = "Player 2" } };

            players[0].Cards.Add(PlayingCard.AceOfDiamonds);
            players[1].Cards.Add(PlayingCard.AceOfClubs);

            BattleField target = new BattleField(players);
            int actual = target.AwardWinner();
            Assert.Fail();
        }
        #endregion AwardWinner Method tests

        #region Clear method tests
        /// <summary>
        ///A test for Clear
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" },
                new WarPlayer(){ Name = "Player 2" } };

            BattleField target = new BattleField(players);

            target.Clear();
            AssertTargetIsNotMidBattle(target);
        }

        [TestMethod()]
        public void ClearAfterPlayCompletedTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" },
                new WarPlayer(){ Name = "Player 2" } };

            players[0].Cards.Add(PlayingCard.AceOfDiamonds);
            players[1].Cards.Add(PlayingCard.TwoOfDiamonds);

            BattleField target = new BattleField(players);
            target.PlayerBattle(players[0]);
            target.PlayerBattle(players[1]);

            int actual = target.AwardWinner();

            target.Clear();
            AssertTargetIsNotMidBattle(target);
        }

        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void ClearInMidPlayTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" },
                new WarPlayer(){ Name = "Player 2" } };

            players[0].Cards.Add(PlayingCard.AceOfDiamonds);
            players[1].Cards.Add(PlayingCard.TwoOfDiamonds);

            BattleField target = new BattleField(players);
            target.PlayerBattle(players[0]);

            target.Clear();

            Assert.Fail();
        }

        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void ClearBeforeAwardingWinnerTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" },
                new WarPlayer(){ Name = "Player 2" } };

            players[0].Cards.Add(PlayingCard.AceOfDiamonds);
            players[1].Cards.Add(PlayingCard.TwoOfDiamonds);

            BattleField target = new BattleField(players);
            target.PlayerBattle(players[0]);
            target.PlayerBattle(players[1]);
            target.Clear();
            Assert.Fail();
        }
        #endregion Clear method tests

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

            BattleField target = new BattleField(players);
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

            BattleField target = new BattleField(players);
            target.PlayerBattle(players[0]);
            Assert.Fail();
        }
        #endregion PlayerBattle method tests

        #region PlayerGoToWar method tests
        /// <summary>
        ///A test for PlayerGoToWar
        ///</summary>
        [TestMethod()]
        public void PlayerGoToWarTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" },
                new WarPlayer(){ Name = "Player 2" } };

            players[0].Cards.Add(PlayingCard.TwoOfDiamonds);
            players[0].Cards.Add(PlayingCard.ThreeOfDiamonds);
            players[0].Cards.Add(PlayingCard.FourOfDiamonds);

            BattleField target = new BattleField(players);
            target.PlayerGoToWar(players[0]);

            Assert.AreEqual(0, players[0].Cards.Count);
            Assert.AreEqual(0, players[1].Cards.Count);
            Assert.AreEqual(3, target.CardCount);
        }

        [TestMethod()]
        public void PlayerGoToWarWithOnlyTwoCardsTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" } };

            players[0].Cards.Add(PlayingCard.TwoOfDiamonds);
            players[0].Cards.Add(PlayingCard.ThreeOfDiamonds);

            BattleField target = new BattleField(players);
            target.PlayerGoToWar(players[0]);

            Assert.AreEqual(0, players[0].Cards.Count);
            Assert.AreEqual(0, target.ActiveAttackCount);
            Assert.AreEqual(2, target.CardCount);
        }

        [TestMethod()]
        public void PlayerGoToWarWithOnlyOneCardTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" } };

            players[0].Cards.Add(PlayingCard.TwoOfDiamonds);

            BattleField target = new BattleField(players);
            target.PlayerGoToWar(players[0]);

            Assert.AreEqual(0, players[0].Cards.Count);
            Assert.AreEqual(0, target.ActiveAttackCount);
            Assert.AreEqual(1, target.CardCount);
        }
        #endregion PlayerGoToWar method tests

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

            BattleField target = new BattleField(players);
            target.PlayerGoToWar(players[0]);
            PlayingCard attackCard = target.PlayerPickWarAttack(players[0], 1);

            Assert.AreEqual(PlayingCard.ThreeOfDiamonds, attackCard);
            
            Assert.AreEqual(target.Winner, players[0]);
            Assert.AreEqual(0, players[0].Cards.Count);
            Assert.AreEqual(3, target.CardCount);
        }

        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void PlayerPickWarAttackTwiceTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" }};

            players[0].Cards.Add(PlayingCard.TwoOfDiamonds);
            players[0].Cards.Add(PlayingCard.ThreeOfDiamonds);
            players[0].Cards.Add(PlayingCard.FourOfDiamonds);

            BattleField target = new BattleField(players);
            target.PlayerGoToWar(players[0]);
            target.PlayerPickWarAttack(players[0], 1);
            target.PlayerPickWarAttack(players[0], 1);

            Assert.Fail();
        }
        #endregion PlayerPickWarAttack method tests

        #region ActiveAttackCount property tests
        /// <summary>
        ///A test for ActiveAttackCount
        ///</summary>
        [TestMethod()]
        public void ActiveAttackCountTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" },
                new WarPlayer(){ Name = "Player 2" },
                new WarPlayer(){ Name = "Player 3" }};

            players[0].Cards.Add(PlayingCard.AceOfDiamonds);
            players[1].Cards.Add(PlayingCard.TwoOfDiamonds);
            players[2].Cards.Add(PlayingCard.ThreeOfDiamonds);

            BattleField target = new BattleField(players);
            Assert.AreEqual(0, target.ActiveAttackCount);
            target.PlayerBattle(players[0]);
            Assert.AreEqual(1, target.ActiveAttackCount);
            target.PlayerBattle(players[1]);
            Assert.AreEqual(2, target.ActiveAttackCount);
            target.PlayerBattle(players[2]);
            Assert.AreEqual(3, target.ActiveAttackCount);
        }

        [TestMethod()]
        public void ActiveAttackCountWarTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" },
                new WarPlayer(){ Name = "Player 2" },
                new WarPlayer(){ Name = "Player 3" }};

            players[0].Cards.Add(PlayingCard.AceOfDiamonds);
            players[0].Cards.Add(PlayingCard.AceOfClubs);
            players[1].Cards.Add(PlayingCard.TwoOfDiamonds);
            players[1].Cards.Add(PlayingCard.TwoOfClubs);
            players[2].Cards.Add(PlayingCard.ThreeOfDiamonds);
            players[2].Cards.Add(PlayingCard.ThreeOfClubs);

            BattleField target = new BattleField(players);
            Assert.AreEqual(0, target.ActiveAttackCount);
            target.PlayerGoToWar(players[0]);
            Assert.AreEqual(0, target.ActiveAttackCount);
            target.PlayerGoToWar(players[1]);
            Assert.AreEqual(0, target.ActiveAttackCount);
            target.PlayerGoToWar(players[2]);
            Assert.AreEqual(0, target.ActiveAttackCount);

            target.PlayerPickWarAttack(players[0], 0);
            Assert.AreEqual(1, target.ActiveAttackCount);
            target.PlayerPickWarAttack(players[1], 1);
            Assert.AreEqual(2, target.ActiveAttackCount);
            target.PlayerPickWarAttack(players[2], 0);
            Assert.AreEqual(3, target.ActiveAttackCount);
        }
        #endregion ActiveAttackCount property tests

        #region CardCount property tests
        /// <summary>
        ///A test for CardCount
        ///</summary>
        [TestMethod()]
        public void CardCountTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" },
                new WarPlayer(){ Name = "Player 2" },
                new WarPlayer(){ Name = "Player 3" }};

            players[0].Cards.Add(PlayingCard.AceOfDiamonds);
            players[1].Cards.Add(PlayingCard.TwoOfDiamonds);
            players[2].Cards.Add(PlayingCard.ThreeOfDiamonds);

            BattleField target = new BattleField(players);
            Assert.AreEqual(0, target.CardCount);
            target.PlayerBattle(players[0]);
            Assert.AreEqual(1, target.CardCount);
            target.PlayerBattle(players[1]);
            Assert.AreEqual(2, target.CardCount);
            target.PlayerBattle(players[2]);
            Assert.AreEqual(3, target.CardCount);
        }

        [TestMethod()]
        public void CardCountWarTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" },
                new WarPlayer(){ Name = "Player 2" },
                new WarPlayer(){ Name = "Player 3" }};

            players[0].Cards.Add(PlayingCard.AceOfDiamonds);
            players[0].Cards.Add(PlayingCard.AceOfClubs);
            players[1].Cards.Add(PlayingCard.TwoOfDiamonds);
            players[1].Cards.Add(PlayingCard.TwoOfClubs);
            players[2].Cards.Add(PlayingCard.ThreeOfDiamonds);
            players[2].Cards.Add(PlayingCard.ThreeOfClubs);

            BattleField target = new BattleField(players);
            Assert.AreEqual(0, target.CardCount);
            target.PlayerGoToWar(players[0]);
            Assert.AreEqual(2, target.CardCount);
            target.PlayerGoToWar(players[1]);
            Assert.AreEqual(4, target.CardCount);
            target.PlayerGoToWar(players[2]);
            Assert.AreEqual(6, target.CardCount);
        }
        #endregion CardCount property tests

        /// <summary>
        ///A test for HighCardHolders
        ///</summary>
        [TestMethod()]
        public void HighCardHoldersTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" },
                new WarPlayer(){ Name = "Player 2" },
                new WarPlayer(){ Name = "Player 3" }};

            players[0].Cards.Add(PlayingCard.AceOfDiamonds);
            players[1].Cards.Add(PlayingCard.TwoOfDiamonds);
            players[2].Cards.Add(PlayingCard.ThreeOfDiamonds);

            BattleField target = new BattleField(players);
            Assert.AreEqual(0, target.ActiveAttackCount);
            target.PlayerBattle(players[0]);
            Assert.AreEqual(1, target.ActiveAttackCount);
            target.PlayerBattle(players[1]);
            Assert.AreEqual(2, target.ActiveAttackCount);
            target.PlayerBattle(players[2]);
            Assert.AreEqual(3, target.ActiveAttackCount);
        }

        /// <summary>
        ///A test for Winner
        ///</summary>
        [TestMethod()]
        public void WinnerTest()
        {
            WarPlayer[] players = null; // TODO: Initialize to an appropriate value
            BattleField target = new BattleField(players); // TODO: Initialize to an appropriate value
            WarPlayer actual;
            actual = target.Winner;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
