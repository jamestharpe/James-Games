using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JamesGames.PlayingCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamesGames.War.Mocks
{
    class MockWarGame : AbstractWarGame
    {
        private readonly CardList _DealtCards = new CardList();
        private WarGameState _WarGameState;
        private int count_PlayerBattle = 0;
        private int count_PlayerGoToWar = 0;
        private int count_PlayerPickWarAttack = 0;
        private int value_lastAttackIndex = -1;
        
        public MockWarGame(WarGameState useGameState)
        {
            _WarGameState = useGameState;
        }

        public void AssertCallCounts(int playerBattle = 0, int playerGoToWar = 0, int playerPickWarAttack = 0, int lastAttackIndex = -1)
        {
            Assert.AreEqual(playerBattle, count_PlayerBattle);
            Assert.AreEqual(playerGoToWar, count_PlayerGoToWar);
            Assert.AreEqual(playerPickWarAttack, count_PlayerPickWarAttack);
            Assert.AreEqual(lastAttackIndex, value_lastAttackIndex);
        }

        internal override Card PlayerBattle(WarPlayer player)
        {
            count_PlayerBattle++;
            return player.Cards.DealTo(_DealtCards);
        }

        internal override int PlayerDeclareWar(WarPlayer player)
        {
            count_PlayerGoToWar++;
            return 3;
        }

        internal override Card PlayerPickWarAttack(WarPlayer player, int attackIndex)
        {
            count_PlayerPickWarAttack++;
            value_lastAttackIndex = attackIndex;
            return Card.EightOfSpades;
        }

        public override WarGameState GameState
        {
            get { return _WarGameState; }
        }

        public void SetGameState(WarGameState warGameState)
        {
            _WarGameState = warGameState;
        }

        public override void AdvancePlay()
        {
            throw new NotImplementedException();
        }
    }
}
