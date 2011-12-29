using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JamesGames.PlayingCards;

namespace JamesGames.War
{
    /// <summary>
    /// A player of the game of war.
    /// </summary>
    public class WarPlayer
    {
        private int _MaxAttackIndex = 0;
        private readonly PlayingCardList _Cards = new PlayingCardList();
        private AbstractWarGame _Game;

        public string Name { get; set; }

        public AbstractWarGame Game
        {
            get { return _Game; }
            set
            {
                if (_Game != null && value != null)
                    throw new InvalidOperationException("Player already belongs to a game.");

                _Game = value;
            }
        }

        public PlayingCardList Cards 
        {
            get { return this._Cards; }
        }

        public void Play()
        {
            if(this.Cards.Count == 0)
                throw new InvalidOperationException("No cards to play.");

            switch (Game.GameState)
            {
                case WarGameState.AtBattle:
                    Game.PlayerBattle(this);
                    break;
                case WarGameState.AtWar:
                    _MaxAttackIndex = Game.PlayerGoToWar(this) -1;
                    break;
                case WarGameState.AtWarBattle:
                    Game.PlayerPickWarAttack(this, _MaxAttackIndex);
                    break;
                case WarGameState.GameOver: default:
                    throw new InvalidOperationException("Cannot play after game has ended.");
            }
        }
    }
}
