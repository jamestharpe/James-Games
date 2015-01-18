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

        #region PlayerPickWarAttack method tests

        [TestMethod(), ExpectedException(typeof(InvalidOperationException))]
        public void PlayerPickWarAttackTwiceTest()
        {
            WarPlayer[] players = new WarPlayer[] {
                new WarPlayer(){ Name = "Player 1" }};

            players[0].Cards.Add(Card.TwoOfDiamonds);
            players[0].Cards.Add(Card.ThreeOfDiamonds);
            players[0].Cards.Add(Card.FourOfDiamonds);

            WarGame target = new WarGame(players);
            target.PlayerDeclareWar(players[0]);
            target.PlayerPickWarAttack(players[0], 1);
            target.PlayerPickWarAttack(players[0], 1);

            Assert.Fail();
        }
        #endregion PlayerPickWarAttack method tests

        #region PlayerBattle method tests
        
        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void PlayerBattle_FailesWithoutCards()
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
