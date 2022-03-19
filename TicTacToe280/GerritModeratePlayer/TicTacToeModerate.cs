using System;
using TicTacToeBasePlayer;

namespace GerritModeratePlayer
{
    public class TicTacToeModerate : TicTacToeBase
    {
        public TicTacToeModerate(int symbol) : base(symbol)
        {
            this.playerName = "~n00bSl4y3r~";
        }

        public override Tuple<int, int> MakeMove()
        {
            return base.MakeMove();
        }
    }
}
