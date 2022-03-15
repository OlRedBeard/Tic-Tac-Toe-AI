using System;
using System.Collections.Generic;

namespace TicTacToeBasePlayer
{
    public class TicTacToeBase : ITicTacToePlayer
    {
        // Make a good use of randoms
        private static Random srnd = new Random();
        protected Random rnd = new Random(srnd.Next());
        // Make a game board to represent the game state
        protected int[,] board;
        protected string playerName = "";
        protected int symbol = 0;
        protected List<Tuple<int, int>> availableMoves = new List<Tuple<int, int>>();

        public TicTacToeBase(int symbol)
        {
            this.symbol = symbol;
            this.playerName = "basePlayer";
        }

        public void GameChanged(int[,] g, List<Tuple<int, int>> moves)
        {
            // Update the board state
            this.board = g;
            // Update available moves
            this.availableMoves = moves;
        }

        public virtual Tuple<int, int> MakeMove()
        {
            // There are no moves left to make
            if (availableMoves.Count == 0)
                return null;
            // Player logic goes here, base chooses at random
            int a = rnd.Next(0, availableMoves.Count);
            return availableMoves[a];
        }

        public string Name()
        {
            return this.playerName;
        }

        public int Symbol()
        {
            return this.symbol;
        }
    }
}
