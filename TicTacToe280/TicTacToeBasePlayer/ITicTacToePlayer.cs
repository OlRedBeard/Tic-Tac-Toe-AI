using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeBasePlayer
{
    public interface ITicTacToePlayer
    {
        int Symbol();
        string Name();
        Tuple<int, int> MakeMove();
        void GameChanged(int[,] g, List<Tuple<int, int>> moves);
    }
}
