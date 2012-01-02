using System;
using JamesGames.PlayingCards;

namespace JamesGames.War
{
    /// <summary>
    /// A player of the game of war.
    /// </summary>
    public class WarPlayer
    {
        private int _MaxAttackIndex = -1;
        private readonly PlayingCardList _Cards = new PlayingCardList();
        private AbstractWarGame _Game;

        /// <summary>
        /// Gets and sets the player's name.
        /// </summary>
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

            switch (Game.GameState)
            {
                case WarGameState.NewGame:
                case WarGameState.AtBattle:
                    if (this.Cards.Count == 0)
                        throw new InvalidOperationException("No cards to play.");
                    Game.PlayerBattle(this);
                    break;
                case WarGameState.WarDeclared:
                    _MaxAttackIndex = Game.PlayerDeclareWar(this) -1;
                    break;
                case WarGameState.AtWar:
                    Game.PlayerPickWarAttack(this, _MaxAttackIndex);
                    break;
                case WarGameState.GameOver: default:
                    throw new InvalidOperationException("Cannot play after game has ended.");
            }
        }
    }
}
