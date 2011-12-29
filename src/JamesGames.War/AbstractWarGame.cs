using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JamesGames.PlayingCards;

namespace JamesGames.War
{
    public abstract class AbstractWarGame
    {
        internal abstract PlayingCard PlayerBattle(WarPlayer player);
        internal abstract int PlayerGoToWar(WarPlayer player);
        internal abstract void PlayerPickWarAttack(WarPlayer player, int attackIndex);

        public abstract WarGameState GameState { get; }

        public abstract void AdvancePlay();
    }
}
