using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JamesGames.PlayingCards;

namespace JamesGames.War
{
    class BattleTracker
    {
        private readonly Dictionary<WarPlayer, CardList> _PlayerAttacks = new Dictionary<WarPlayer, CardList>();
        private readonly Dictionary<WarPlayer, List<CardList>> _ActiveWars = new Dictionary<WarPlayer, List<CardList>>();
        private readonly Dictionary<WarPlayer, Card> _ActiveAttacks = new Dictionary<WarPlayer, Card>();

        public BattleTracker(params WarPlayer[] players)
        {
            foreach (WarPlayer player in players)
                PlayerAttacks.Add(player, new CardList());
        }

        public void Clear()
        {
            if (PlayerAttacks.Values.Sum(cards => cards.Count) > 0)
                throw new InvalidOperationException("Cannot clear battle field until attack cards have been awarded.");

            ActiveWars.Clear();
            ActiveAttacks.Clear();
        }

        public IEnumerable<WarPlayer> HighCardHolders
        {
            get
            {
                var emptyResult = new WarPlayer[] { }; // Empty
                
                if (PlayerAttacks.Values.Sum(cards => cards.Count) == 0)
                    return emptyResult;

                var highestValueCard = ActiveAttacks.Values
                    .OrderByDescending(card => card, new WarCardComparer())
                    .FirstOrDefault();

                if (highestValueCard == null)
                    return emptyResult;

                return ActiveAttacks.Keys
                    .Where(player =>
                        ActiveAttacks[player].Face == highestValueCard.Face);
            }
        }

        public Dictionary<WarPlayer, CardList> PlayerAttacks
        {
            get { return _PlayerAttacks; }
        }

        public Dictionary<WarPlayer, List<CardList>> ActiveWars
        {
            get { return _ActiveWars; }
        }

        public Dictionary<WarPlayer, Card> ActiveAttacks
        {
            get
            {
                return _ActiveAttacks;
            }
        }
        public WarPlayer Winner
        {
            get
            {
                if (ActiveAttacks.Count != PlayerAttacks.Count)
                    return null; // Not everyone has played yet

                if (HighCardHolders.Count() == 1)
                    return HighCardHolders.Single();

                return null;
            }
        }
    }
}
