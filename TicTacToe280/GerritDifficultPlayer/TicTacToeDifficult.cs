using System;
using TicTacToeBasePlayer;

namespace GerritDifficultPlayer
{
    public class TicTacToeDifficult : TicTacToeBase
    {
        int player = 0;
        int opponent = 0;

        public TicTacToeDifficult(int symbol) : base(symbol)
        {
            this.playername = "Matthew Broderic";
            player = symbol;
            opponent = symbol * -1;
        }

        public bool isMovesLeft(int[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 0)
                        return true;
                }
            }
            return false;
        }

        public override Tuple<int, int> MakeMove()
        {
            if (availableMoves.Count == 0)
                return null;
            else
                return FindBestMove(this.board);
        }

        public int Evaluate(int[,] b)
        {
            for (int row = 0; row < 3; row++)
            {
                if (b[row, 0] == b[row, 1] && b[row, 1] == b[row, 2])
                {
                    if (b[row, 0] == player)
                        return +10;
                    else if (b[row, 0] == opponent)
                        return -10;
                }
            }

            for (int col = 0; col < 3; col++)
            {
                if (b[0, col] == b[1, col] && b[1, col] == b[2, col])
                {
                    if (b[0, col] == player)
                        return +10;
                    else if (b[0, col] == opponent)
                        return -10;
                }
            }

            if (b[0,2] == b[1,1] && b[1,1] == b[2, 0])
            {
                if (b[0, 2] == player)
                    return +10;
                else if (b[0, 2] == opponent)
                    return -10;
            }

            return 0;
        }

        public int Minimax(int [,] board, bool isMax)
        {
            int score = Evaluate(board);

            if (score == 10)
                return score;

            if (score == -10)
                return score;

            if (isMovesLeft(board) == false)
                return 0;

            if (isMax)
            {
                int best = -1000;

                for (int i=0; i<3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == 0)
                        {
                            board[i, j] = player;

                            best = Math.Max(best, Minimax(board, !isMax));
                            board[i, j] = 0;
                        }
                    }
                }
                return best;
            }

            else
            {
                int best = 1000;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == 0)
                        {
                            board[i, j] = opponent;

                            best = Math.Min(best, Minimax(board, !isMax));

                            board[i, j] = 0;
                        }
                    }
                }
                return best;
            }
        }

        public Tuple<int, int> FindBestMove(int[,] board)
        {
            int bestVal = -1000;
            Tuple<int, int> move = new Tuple<int, int>(-1, -1);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 0)
                    {
                        board[i, j] = player;
                        int moveVal = Minimax(board, false);
                        board[i, j] = 0;

                        if (moveVal > bestVal)
                        {
                            move = new Tuple<int, int>(i, j);
                            bestVal = moveVal;
                        }
                    }
                }
            }

            return move;
        }
    }
}
