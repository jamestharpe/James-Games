using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JamesGames.PlayingCards;

namespace JamesGames.War
{
    public abstract class AbstractWarGame
    {
        internal abstract Card PlayerBattle(WarPlayer player);
        internal abstract int PlayerDeclareWar(WarPlayer player);
        internal abstract Card PlayerPickWarAttack(WarPlayer player, int attackIndex);

        public abstract WarGameState GameState { get; }

        public abstract void AdvancePlay();
    }
}
