using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JamesGames.PlayingCards;
using Rolcore.Collections;
using System.Diagnostics;

namespace JamesGames.War
{
    /// <summary>
    /// Represents an instance of the card game War.
    /// </summary>
    public class WarGame : AbstractWarGame
    {
        private readonly List<WarPlayer> _Players = new List<WarPlayer>();
        private readonly DeckOfCards _Cards = new DeckOfCards();
        private BattleField _BattleField = null;

        private void EnforceRequiredPlayerCount()
        {
            if (_Players.Count != RequiredPlayerCount)
                throw new ArgumentException("War requires exactly two players");
        }

        internal override PlayingCard PlayerBattle(WarPlayer player)
        {
            int playerIndex = _Players.IndexOf(player);
            int expectedBattleFieldCount = playerIndex;

            Debug.Assert(GameState == WarGameState.AtBattle);
            Debug.Assert(_BattleField.CardCount == ++expectedBattleFieldCount);
            PlayingCard result = _BattleField.PlayerBattle(player);
            Debug.Assert(_BattleField.CardCount == ++expectedBattleFieldCount);

            return result;
        }

        internal override int PlayerGoToWar(WarPlayer player)
        {
            return _BattleField.PlayerGoToWar(player);
        }

        internal override void PlayerPickWarAttack(WarPlayer player, int attackIndex)
        {
            _BattleField.PlayerPickWarAttack(player, attackIndex);
        }

        public const int RequiredPlayerCount = 2;

        /// <summary>
        /// Initializes a new instance of <see cref="WarGame"/>.
        /// </summary>
        /// <param name="players">The players of the game.</param>
        public WarGame(params WarPlayer[] players)
        {
            if(players != null && players.Length > 0)
                AddPlayers(players);

            NewGame();
        }

        /// <summary>
        /// Gets a value indicating the game winner. Returns null if there is no winner (e.g. 
        /// because the game is in play or no game has been played).
        /// </summary>
        public WarPlayer Winner
        {
            get { return _Players.SingleOrDefault(player => player.Cards.Count == _Cards.Size); }
        }

        public override WarGameState GameState
        {
            get
            {
                //
                // Check for game over

                if (_Players.Count != RequiredPlayerCount)
                    return WarGameState.GameOver;
                if (this.Winner != null)
                    return WarGameState.GameOver;

                //
                // Check for war

                if (_BattleField.HighCardHolders.Count() > 1)
                    return WarGameState.AtWar;
                
                //
                // Check for battle

                if (_BattleField.ActiveAttackCount != _Players.Count)
                    return WarGameState.AtBattle;

                Debug.Assert(false, "Indeterminate game state.");
                throw new InvalidOperationException("Indeterminate game state.");
            }
        }

        public void AddPlayers(params WarPlayer[] players)
        {
            foreach (WarPlayer player in players)
            {
                player.Game = this;
                this._Players.Add(player);
            }

            _BattleField = new BattleField(this._Players.ToArray());
        }

        public void RemovePlayers(params WarPlayer[] players)
        {
            foreach (WarPlayer player in players)
            {
                player.Game = null;
                this._Players.Remove(player);
            }
        }

        public void NewGame()
        {
            EnforceRequiredPlayerCount();

            if (GameState == WarGameState.AtBattle || GameState == WarGameState.AtWar)
                throw new InvalidOperationException("Cannot start a new game in mid play.");

            //
            // Reset the deck

            _Cards.Reset();
            _Cards.Shuffle();
            _BattleField.Clear();

            //
            // Deal

            foreach (WarPlayer player in _Players)
                _Cards.DealTo(player.Cards);
        }

        public override void AdvancePlay()
        {
            EnforceRequiredPlayerCount();

            switch (GameState)
            {
                case WarGameState.AtBattle:
                case WarGameState.AtWar:
                case WarGameState.AtWarBattle:
                    foreach (WarPlayer player in _Players)
                        player.Play();
                    if (_BattleField.Winner != null)
                    {
                        _BattleField.AwardWinner();
                        _BattleField.Clear();
                    }
                    break;
                case WarGameState.GameOver:
                    NewGame();
                    break;
                default:
                    Debug.Assert(false, "Unknown GameState Value");
                    throw new InvalidOperationException("Unknown GameState Value");
            }
        }
    }
}
