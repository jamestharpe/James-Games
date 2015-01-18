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
        private readonly List<WarPlayer> players = new List<WarPlayer>();
        private DeckOfCards cards = new DeckOfCards();
        private BattleTracker battleTracker;

        private void EnforceRequiredPlayerCount()
        {
            if (players.Count != RequiredPlayerCount)
                throw new InvalidOperationException("War requires exactly two players");
        }

        private void RequireGameState(params WarGameState[] validGameStates)
        {
            if(!validGameStates.Contains(GameState))
                throw new InvalidOperationException("Action cannot be performed at this point in the game.");
        }

        protected int AwardBattleWinner()
        {
            var winner = battleTracker.Winner;
            if (winner == null)
                throw new InvalidOperationException("No winner for the current battle.");

            int result = 0;

            PlayingCardList winStack = new PlayingCardList();
            foreach (PlayingCardList attack in battleTracker.PlayerAttacks.Values)
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

            var numberOfCards = players
                .Select(player => player.Cards)
                .Sum(cards => cards.Count);

            Debug.Assert(result > 0, "No cards awarded.");
            Debug.WriteLine(String.Format("{0} cards awarded to {1}", result, winner.Name));

            return result;
        }

        internal override PlayingCard PlayerBattle(WarPlayer player)
        {
            Debug.Assert(battleTracker.PlayerAttacks.Keys.Contains(player), "Player is not part of game.");
            this.RequireGameState(WarGameState.AtBattle, WarGameState.NewGame);
            
            var result = player.Cards.DealTo(battleTracker.PlayerAttacks[player]);
            battleTracker.ActiveAttacks[player] = result;

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

            if (!battleTracker.PlayerAttacks.Keys.Contains(player))
                throw new InvalidOperationException("Cannot declare war without having attacked first.");

            RequireGameState(WarGameState.WarDeclared);

            //
            // Deactivate active attack

            battleTracker.ActiveAttacks.Remove(player);
            if (!battleTracker.ActiveWars.ContainsKey(player))
                battleTracker.ActiveWars[player] = new List<PlayingCardList>();
            battleTracker.ActiveWars[player].Add(new PlayingCardList(NumberOfCardsToDealForWar));
            var warIndex = battleTracker.ActiveWars[player].Count - 1;

            //
            // Deal cards to "declare war"

            var result = 0;
            for (var i = 1; i <= NumberOfCardsToDealForWar && player.Cards.Count > 0; i++)
            {
                var card = player.Cards.DealTo(battleTracker.PlayerAttacks[player]);
                battleTracker.ActiveWars[player][warIndex].Add(card);
                result++;
            }

            Debug.Assert(result <= NumberOfCardsToDealForWar, "Did not deal enough war cards.");
            Debug.Assert(!battleTracker.ActiveAttacks.ContainsKey(player), "Player has invalid attack.");
            Debug.WriteLine(player.Name + " declared war!");

            return result;
        }

        internal override PlayingCard PlayerPickWarAttack(WarPlayer player, int attackIndex)
        {
            //
            // Pre conditions

            if (!battleTracker.PlayerAttacks.Keys.Contains(player))
                throw new InvalidOperationException("Cannot go to war without having attacked first.");
            if (!battleTracker.ActiveWars.ContainsKey(player) || battleTracker.ActiveWars[player].Count == 0)
                throw new InvalidOperationException(String.Format("{0} has not declared war.", player.Name));
            if (battleTracker.ActiveAttacks.ContainsKey(player))
                throw new InvalidOperationException(String.Format("{0} already has an active attack.", player.Name));

            RequireGameState(WarGameState.AtWar);

            //
            // Validate attack index

            const int maxIndex = NumberOfCardsToDealForWar - 1;
            if ((attackIndex == -1) && (player.Cards.Count == 0))
                //
                // Player is out of cards, default to last attack.
            {
                var lastAttachIndex = battleTracker.PlayerAttacks[player].Count - 1;
                var defactoResult = battleTracker.PlayerAttacks[player][lastAttachIndex];
                battleTracker.ActiveAttacks[player] = defactoResult;
                return defactoResult;
            }
            else if (attackIndex > maxIndex || attackIndex < 0)
                throw new ArgumentOutOfRangeException("attackIndex",
                    String.Format("Index must be from 0 to {0} (was {1})", maxIndex, attackIndex));

            //
            // Activate the selected attack 

            var wars = battleTracker.ActiveWars[player];
            var warCards = wars[wars.Count - 1];
            var result = warCards[attackIndex];
            battleTracker.ActiveAttacks[player] = result;

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
            if (players != null && players.Length > 0)
            {
                this.AddPlayers(players);
            }

            this.NewGame();
        }

        /// <summary>
        /// Gets a value indicating the game winner. Returns null if there is no winner (e.g. 
        /// because the game is in play or no game has been played).
        /// </summary>
        public WarPlayer Winner
        {
            get { return this.players.SingleOrDefault(player => player.Cards.Count == this.cards.Count); }
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

                if (players.Count != RequiredPlayerCount)
                    return WarGameState.GameOver;
                if (this.Winner != null)
                    return WarGameState.GameOver;

                //
                // Check for new game

                if (cards.Any())
                    return WarGameState.NewGame;

                //
                // Check for war declaration

                if (battleTracker.HighCardHolders.Count() > 1)
                    return WarGameState.WarDeclared;
                if (battleTracker.ActiveWars.Count > 0)
                {
                    if (battleTracker.ActiveWars.Count < players.Count)
                        return WarGameState.WarDeclared;
                    if (battleTracker.ActiveWars.Values.Any(list => list.Count < battleTracker.ActiveWars.Values.Max(item => item.Count)))
                        return WarGameState.WarDeclared;
                }

                //
                // Check for war

                if ((battleTracker.ActiveWars.Count == players.Count) && (battleTracker.ActiveAttacks.Values.Count != players.Count))
                    return WarGameState.AtWar;

                //
                // Check for battle

                if (battleTracker.ActiveAttacks.Values.Count != players.Count)
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
                this.players.Add(player);
            }

            battleTracker = new BattleTracker(this.players.ToArray());
        }

        public void RemovePlayers(params WarPlayer[] players)
        {
            foreach (var player in players)
            {
                player.Game = null;
                this.players.Remove(player);
            }

            battleTracker = new BattleTracker(this.players.ToArray());
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

            this.cards = new DeckOfCards();
            cards.Shuffle();
            battleTracker.Clear();

            //
            // Deal

            players.ForEach(p => p.Cards.Clear());
            while (cards.Count > 0)
            {
                foreach (WarPlayer player in players)
                {
                    cards.DealTo(player.Cards);
                }
            }

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
                    foreach (WarPlayer player in players)
                        player.Play();
                    if (battleTracker.Winner != null)
                    {
                        AwardBattleWinner();
                        battleTracker.Clear();
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
