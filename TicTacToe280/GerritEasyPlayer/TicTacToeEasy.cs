using System;
using TicTacToeBasePlayer;

namespace GerritEasyPlayer
{
    public class TicTacToeEasy : TicTacToeBase
    {
        public TicTacToeEasy(int symbol) : base(symbol)
        {
            this.playerName = "Thick Bunkus";
        }

        public override Tuple<int, int> MakeMove()
        {
            // Put in some logic for the easy player to make a move
            // Make 3 of these classes in seperate projects (easy, regular, hard)
            return base.MakeMove();
        }
    }
}
