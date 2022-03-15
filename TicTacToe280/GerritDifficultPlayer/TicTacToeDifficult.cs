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
            if (availableMoves.Count == 0)
                return null;

            // Check if this player goes first
            if (availableMoves.Count == 9)
            {
                int corner = rnd.Next(1, 4);

                if (corner == 1)
                    return availableMoves[0];
                else if (corner == 2)
                    return availableMoves[2];
                else if (corner == 3)
                    return availableMoves[6];
                else
                    return availableMoves[8];
            }
            
            // If this player went first, continue here
            if (availableMoves.Count == 7)
            {
                if (this.board[1,1] == 0)
                {
                    // Top left corner
                    if (this.board[0,0] == this.symbol)
                    {
                        if ((this.board[0, 1] != 0 && this.board[0, 1] != this.symbol) || (this.board[0, 2] != 0 && this.board[0, 2] != this.symbol))
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                return availableMoves[6];
                            else
                                return availableMoves[8];
                        }                      
                        else if ((this.board[1, 0] != 0 && this.board[1, 0] != this.symbol) || (this.board[2, 0] != 0 && this.board[2, 0] != this.symbol))
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                return availableMoves[2];
                            else
                                return availableMoves[8];
                        }
                        else
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                return availableMoves[2];
                            else
                                return availableMoves[6];
                        } 
                    } // Top right corner
                    else if (this.board[0, 2] == this.symbol)
                    {
                        if ((this.board[2, 1] != 0 && this.board[2, 1] != this.symbol) || (this.board[2, 2] != 0 && this.board[2, 2] != this.symbol))
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                return availableMoves[0];
                            else
                                return availableMoves[6];
                        }
                        else if ((this.board[0, 0] != 0 && this.board[0, 0] != this.symbol) || (this.board[0, 1] != 0 && this.board[0, 1] != this.symbol))
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                return availableMoves[6];
                            else
                                return availableMoves[8];
                        }
                        else
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                return availableMoves[0];
                            else
                                return availableMoves[8];
                        }
                    } // Bottom left corner
                    // Bottom right corner
                }
            }

            return availableMoves[0]; // CHANGE THIS! SILENCING ERROR!
        }
    }
}
