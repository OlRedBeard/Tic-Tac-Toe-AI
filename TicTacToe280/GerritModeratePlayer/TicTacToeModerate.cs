using System;
using TicTacToeBasePlayer;

namespace GerritModeratePlayer
{
    public class TicTacToeModerate : TicTacToeBase
    {
        public TicTacToeModerate(int symbol) : base(symbol)
        {
            this.playername = "~n00bSl4y3r~";
        }

        public override Tuple<int, int> MakeMove()
        {
            return base.MakeMove();
        }
    }
}
