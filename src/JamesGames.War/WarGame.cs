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
    /// <remarks>
    /// In War, the deck is divided evenly among the players, giving each a down stack. In unison, 
    /// each player reveals the top card on his deck (a "battle"), and the player with the higher 
    /// card takes both the cards played and moves them to the bottom of his stack. If the two 
    /// cards played are of equal value, each player lays down three face-down cards and picks one 
    /// of the cards out of the three (a "war"), and the higher-valued card wins all of the cards 
    /// on the table, which are then added to the bottom of the player's stack. In the case of 
    /// another tie, the war process is repeated until there is no tie.
    /// </remarks>
    public class WarGame : AbstractWarGame
    {
        private readonly List<WarPlayer> _Players = new List<WarPlayer>();
        private readonly DeckOfCards _Cards = new DeckOfCards();
        private BattleTracker _BattleTracker;

        private void EnforceRequiredPlayerCount()
        {
            if (_Players.Count != RequiredPlayerCount)
                throw new InvalidOperationException("War requires exactly two players");
        }

        private void RequireGameState(params WarGameState[] validGameStates)
        {
            if(!validGameStates.Contains(GameState))
                throw new InvalidOperationException("Action cannot be performed at this point in the game.");
        }

        protected int AwardBattleWinner()
        {
            var winner = _BattleTracker.Winner;
            if (winner == null)
                throw new InvalidOperationException("No winner for the current battle.");

            int result = 0;

            PlayingCardList winStack = new PlayingCardList();
            foreach (PlayingCardList attack in _BattleTracker.PlayerAttacks.Values)
            {
                while (attack.Count > 0)
                {
                    attack.DealTo(winStack);
                    result++;
                }
            }
            winStack.Shuffle();
            while (winStack.Count > 0)
                winStack.DealTo(winner.Cards);

            var numberOfCards = _Players
                .Select(player => player.Cards)
                .Sum(cards => cards.Count);

            Debug.Assert(
                numberOfCards == _Cards.Size,
                String.Format("Wrong number of cards: {0}.", numberOfCards));

            Debug.Assert(result > 0, "No cards awarded.");
            Debug.WriteLine(String.Format("{0} cards awarded to {1}", result, winner.Name));

            return result;
        }

        internal override PlayingCard PlayerBattle(WarPlayer player)
        {
            //
            // Pre conditions

            Debug.Assert(_BattleTracker.PlayerAttacks.Keys.Contains(player), "Player is not part of game.");
            RequireGameState(WarGameState.AtBattle, WarGameState.NewGame);
            
            //
            // Perform "battle" action

            PlayingCard result = player.Cards.DealTo(_BattleTracker.PlayerAttacks[player]);
            _BattleTracker.ActiveAttacks[player] = result;

            Debug.WriteLine(String.Format("{0} went to battle with the {1}", player.Name, result));

            return result;
        }

        /// <summary>
        /// Deals three cards (or players remaining cards, if fewer than three) for war.
        /// </summary>
        /// <param name="player">Specifies the player going to war.</param>
        /// <returns>The number of cards dealt for the war.</returns>
        internal override int PlayerDeclareWar(WarPlayer player)
        {
            //
            // Pre conditions

            if (!_BattleTracker.PlayerAttacks.Keys.Contains(player))
                throw new InvalidOperationException("Cannot declare war without having attacked first.");

            RequireGameState(WarGameState.WarDeclared);

            //
            // Deactivate active attack

            _BattleTracker.ActiveAttacks.Remove(player);
            if (!_BattleTracker.ActiveWars.ContainsKey(player))
                _BattleTracker.ActiveWars[player] = new List<PlayingCardList>();
            _BattleTracker.ActiveWars[player].Add(new PlayingCardList(NumberOfCardsToDealForWar));
            var warIndex = _BattleTracker.ActiveWars[player].Count - 1;

            //
            // Deal cards to "declare war"

            var result = 0;
            for (var i = 1; i <= NumberOfCardsToDealForWar && player.Cards.Count > 0; i++)
            {
                var card = player.Cards.DealTo(_BattleTracker.PlayerAttacks[player]);
                _BattleTracker.ActiveWars[player][warIndex].Add(card);
                result++;
            }

            Debug.Assert(result <= NumberOfCardsToDealForWar, "Did not deal enough war cards.");
            Debug.Assert(!_BattleTracker.ActiveAttacks.ContainsKey(player), "Player has invalid attack.");
            Debug.WriteLine(player.Name + " declared war!");

            return result;
        }

        internal override PlayingCard PlayerPickWarAttack(WarPlayer player, int attackIndex)
        {
            //
            // Pre conditions

            if (!_BattleTracker.PlayerAttacks.Keys.Contains(player))
                throw new InvalidOperationException("Cannot go to war without having attacked first.");
            if (!_BattleTracker.ActiveWars.ContainsKey(player) || _BattleTracker.ActiveWars[player].Count == 0)
                throw new InvalidOperationException(String.Format("{0} has not declared war.", player.Name));
            if (_BattleTracker.ActiveAttacks.ContainsKey(player))
                throw new InvalidOperationException(String.Format("{0} already has an active attack.", player.Name));

            RequireGameState(WarGameState.AtWar);

            //
            // Validate attack index

            const int maxIndex = NumberOfCardsToDealForWar - 1;
            if ((attackIndex == -1) && (player.Cards.Count == 0))
                //
                // Player is out of cards, default to last attack.
            {
                var lastAttachIndex = _BattleTracker.PlayerAttacks[player].Count - 1;
                var defactoResult = _BattleTracker.PlayerAttacks[player][lastAttachIndex];
                _BattleTracker.ActiveAttacks[player] = defactoResult;
                return defactoResult;
            }
            else if (attackIndex > maxIndex || attackIndex < 0)
                throw new ArgumentOutOfRangeException("attackIndex",
                    String.Format("Index must be from 0 to {0} (was {1})", maxIndex, attackIndex));

            //
            // Activate the selected attack 

            var wars = _BattleTracker.ActiveWars[player];
            var warCards = wars[wars.Count - 1];
            var result = warCards[attackIndex];
            _BattleTracker.ActiveAttacks[player] = result;

            Debug.WriteLine(String.Format("{0} went to war with the {1}", player.Name, result));

            return result;
        }

        public const int RequiredPlayerCount = 2;
        public const int NumberOfCardsToDealForWar = 3;

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

        /// <summary>
        /// Gets a value indicating the state of the game instance.
        /// <seealso cref="WarGameState"/>
        /// </summary>
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
                // Check for new game

                if (_Cards.Any())
                    return WarGameState.NewGame;

                //
                // Check for war declaration

                if (_BattleTracker.HighCardHolders.Count() > 1)
                    return WarGameState.WarDeclared;
                if (_BattleTracker.ActiveWars.Count > 0)
                {
                    if (_BattleTracker.ActiveWars.Count < _Players.Count)
                        return WarGameState.WarDeclared;
                    if (_BattleTracker.ActiveWars.Values.Any(list => list.Count < _BattleTracker.ActiveWars.Values.Max(item => item.Count)))
                        return WarGameState.WarDeclared;
                }

                //
                // Check for war

                if ((_BattleTracker.ActiveWars.Count == _Players.Count) && (_BattleTracker.ActiveAttacks.Values.Count != _Players.Count))
                    return WarGameState.AtWar;

                //
                // Check for battle

                if (_BattleTracker.ActiveAttacks.Values.Count != _Players.Count)
                    return WarGameState.AtBattle;

                Debug.Assert(false, "Indeterminate game state.");
                throw new InvalidOperationException("Indeterminate game state.");
            }
        }

        public void AddPlayers(params WarPlayer[] players)
        {
            foreach (var player in players)
            {
                player.Game = this;
                this._Players.Add(player);
            }

            _BattleTracker = new BattleTracker(this._Players.ToArray());
        }

        public void RemovePlayers(params WarPlayer[] players)
        {
            foreach (var player in players)
            {
                player.Game = null;
                this._Players.Remove(player);
            }

            _BattleTracker = new BattleTracker(this._Players.ToArray());
        }

        public void NewGame()
        {
            //
            // Pre-conditions

            EnforceRequiredPlayerCount();

            if (GameState == WarGameState.AtBattle || GameState == WarGameState.WarDeclared)
                throw new InvalidOperationException("Cannot start a new game in mid play.");

            //
            // Reset the deck

            _Cards.Reset();
            _Cards.Shuffle();
            _BattleTracker.Clear();

            //
            // Deal

            _Players.ForEach(p => p.Cards.Clear());
            while(_Cards.Count > 0)
                foreach (WarPlayer player in _Players)
                    _Cards.DealTo(player.Cards);
        }

        public override void AdvancePlay()
        {
            EnforceRequiredPlayerCount();

            switch (GameState)
            {
                //
                // Playable states

                case WarGameState.NewGame:
                case WarGameState.AtBattle:
                case WarGameState.WarDeclared:
                case WarGameState.AtWar:
                    foreach (WarPlayer player in _Players)
                        player.Play();
                    if (_BattleTracker.Winner != null)
                    {
                        AwardBattleWinner();
                        _BattleTracker.Clear();
                    }
                    break;

                //
                // Un-playable states

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
