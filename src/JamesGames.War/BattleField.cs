using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JamesGames.PlayingCards;

namespace JamesGames.War
{
    class BattleField
    {
        private readonly Dictionary<WarPlayer, PlayingCardList> _Attacks = new Dictionary<WarPlayer, PlayingCardList>();
        private readonly Dictionary<WarPlayer, PlayingCardList> _ActiveWars = new Dictionary<WarPlayer, PlayingCardList>();
        private readonly Dictionary<WarPlayer, PlayingCard> _ActiveAttacks = new Dictionary<WarPlayer, PlayingCard>();

        const int NumberOfCardsToDealForWar = 3;

        public BattleField(params WarPlayer[] players)
        {
            foreach (WarPlayer player in players)
                _Attacks.Add(player, new PlayingCardList());
        }

        public int CardCount
        {
            get { return _Attacks.Values.Sum(cards => cards.Count); }
        }

        public int ActiveAttackCount
        {
            get { return _ActiveAttacks.Values.Count; }
        }

        public void Clear()
        {
            if (CardCount > 0)
                throw new InvalidOperationException("Cannot clear battle field until attack cards have been awarded.");

            _ActiveWars.Clear();
            _ActiveAttacks.Clear();
        }

        public IEnumerable<WarPlayer> HighCardHolders
        {
            get
            {
                if(CardCount == 0)
                    return new WarPlayer[]{}; // Empty

                PlayingCard highestValueCard = _ActiveAttacks.Values
                    .OrderByDescending(card => card, new WarCardComparer())
                    .First();

                return _ActiveAttacks.Keys
                    .Where(player =>
                        _ActiveAttacks[player].Face == highestValueCard.Face);
            }
        }

        public WarPlayer Winner
        {
            get
            {
                if(_ActiveAttacks.Count != _Attacks.Count)
                    return null; // Not everyone has played yet

                if (HighCardHolders.Count() == 1)
                    return HighCardHolders.Single();

                return null;
            }
        }

        public PlayingCard PlayerBattle(WarPlayer player)
        {
            Debug.Assert(_Attacks.Keys.Contains(player));

            PlayingCard result = player.Cards.DealTo(_Attacks[player]);
            _ActiveAttacks[player] = result;

            return result;
        }

        /// <summary>
        /// Deals three cards (or players remaining cards, if fewer than three) for war.
        /// </summary>
        /// <param name="player">Specifies the player going to war.</param>
        /// <returns>The number of cards dealt for the war.</returns>
        public int PlayerGoToWar(WarPlayer player)
        {
            Debug.Assert(_Attacks.Keys.Contains(player));

            _ActiveAttacks.Remove(player);
            _ActiveWars[player] = new PlayingCardList(NumberOfCardsToDealForWar);

            int result = 0;
            for (int i = 1; i <= NumberOfCardsToDealForWar && player.Cards.Count > 0; i++)
            {
                PlayingCard card = player.Cards.DealTo(_Attacks[player]);
                _ActiveWars[player].Add(card);
                result++;
            }

            Debug.Assert(result <= NumberOfCardsToDealForWar);

            return result;
        }

        public PlayingCard PlayerPickWarAttack(WarPlayer player, int attackIndex)
        {
            Debug.Assert(_Attacks.Keys.Contains(player));

            if(!_ActiveWars.ContainsKey(player) || _ActiveWars[player].Count == 0)
                throw new InvalidOperationException("Player has not gone to war.");
            if(_ActiveAttacks.ContainsKey(player))
                throw new InvalidOperationException("Player has not gone to war or has already made war attack.");

            const int maxIndex = NumberOfCardsToDealForWar - 1;
            if(attackIndex > maxIndex || attackIndex < 0)
                throw new ArgumentOutOfRangeException("Index must be from 0 to " + maxIndex);

            PlayingCard result = _ActiveWars[player][attackIndex];
            _ActiveAttacks[player] = result;

            return result;
        }

        public int AwardWinner()
        {
            WarPlayer winner = this.Winner;
            if (winner == null)
                throw new InvalidOperationException("No winner for the current battle.");

            int result = 0;
            foreach (PlayingCardList attack in _Attacks.Values)
            {
                while (attack.Count > 0)
                {
                    attack.DealTo(winner.Cards);
                    result++;
                }
            }

            Debug.Assert(result > 0, "No cards awarded.");

            return result;
        }
    }
}
