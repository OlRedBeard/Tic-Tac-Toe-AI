using System;
using TicTacToeBasePlayer;

namespace GerritDifficultPlayer
{
    public class TicTacToeDifficult : TicTacToeBase
    {
        public TicTacToeDifficult(int symbol) : base(symbol)
        {
            this.playerName = "Matthew Broderic";
        }

        public override Tuple<int, int> MakeMove()
        {
            return base.MakeMove();
        }
    }
}
