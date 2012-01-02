using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamesGames.War
{
    public enum WarGameState
    {
        /// <summary>
        /// Game is ready to begin.
        /// </summary>
        NewGame,
        /// <summary>
        /// Game is at the point where each player reveals the top card on his deck (a "battle"), 
        /// and the player with the higher card takes both the cards played and moves them to the 
        /// bottom of his stack. If the cards are of equal value, a war is declared.
        /// <seealso cref="WarDeclared"/>
        /// </summary>
        AtBattle,
        /// <summary>
        /// A battle has lead to a draw (the two cards played are of equal value), so each player 
        /// must lay down three face-down cards to declare 
        /// "war."
        /// <seealso cref="AtWar"/>
        /// </summary>
        WarDeclared,
        /// <summary>
        /// With war declared, each player must one card out of the three cards dealt when 
        /// declaring war. The higher-valued card wins all of the cards on the table. If the cards
        /// have the same value, the a new war is declared.
        /// </summary>
        AtWar,
        /// <summary>
        /// The game is over.
        /// </summary>
        GameOver
    }
}