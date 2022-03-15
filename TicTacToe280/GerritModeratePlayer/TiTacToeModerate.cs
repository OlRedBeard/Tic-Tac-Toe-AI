using System;
using TicTacToeBasePlayer;

namespace GerritModeratePlayer
{
    public class TiTacToeModerate : TicTacToeBase
    {
        public TiTacToeModerate(int symbol) : base(symbol)
        {
            this.playerName = "~n00bSl4y3r~";
        }

        public override Tuple<int, int> MakeMove()
        {
            return base.MakeMove();
        }
    }
}
