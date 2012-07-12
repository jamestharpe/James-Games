using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamesGames.Core
{
    public abstract class CardGame
    {
        public abstract Action<CardGamePlayer>[] GetAvailableActions(CardGamePlayer player)
        {
        }

        public void TakeAction(Action<CardGamePlayer> action)
        {
        }

        public abstract void AdvancePlay();
    }
}
