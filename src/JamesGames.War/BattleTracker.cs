using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JamesGames.PlayingCards;

namespace JamesGames.War
{
    class BattleTracker
    {
        private readonly Dictionary<WarPlayer, PlayingCardList> _PlayerAttacks = new Dictionary<WarPlayer, PlayingCardList>();
        private readonly Dictionary<WarPlayer, List<PlayingCardList>> _ActiveWars = new Dictionary<WarPlayer, List<PlayingCardList>>();
        private readonly Dictionary<WarPlayer, PlayingCard> _ActiveAttacks = new Dictionary<WarPlayer, PlayingCard>();

        public BattleTracker(params WarPlayer[] players)
        {
            foreach (WarPlayer player in players)
                PlayerAttacks.Add(player, new PlayingCardList());
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

        public Dictionary<WarPlayer, PlayingCardList> PlayerAttacks
        {
            get { return _PlayerAttacks; }
        }

        public Dictionary<WarPlayer, List<PlayingCardList>> ActiveWars
        {
            get { return _ActiveWars; }
        }

        public Dictionary<WarPlayer, PlayingCard> ActiveAttacks
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
