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

            #region goingfirst
            // THIS PLAYER GOES FIRST - FIRST TURN
            if (availableMoves.Count == 9)
            {
                int corner = rnd.Next(1, 5); // Take a corner spot

                if (corner == 1)
                    return availableMoves[0];
                else if (corner == 2)
                    return availableMoves[2];
                else if (corner == 3)
                    return availableMoves[6];
                else
                    return availableMoves[8];
            }

            // THIS PLAYER GOES FIRST - SECOND TURN
            else if (availableMoves.Count == 7)
            {
                if (this.board[1,1] == 0) // If the opposing player didn't take center space
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
                        if ((this.board[1, 2] != 0 && this.board[1, 2] != this.symbol) || (this.board[2, 2] != 0 && this.board[2, 2] != this.symbol))
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
                    else if (this.board[2, 0] == this.symbol)
                    {
                        if ((this.board[2, 1] != 0 && this.board[2, 1] != this.symbol) || (this.board[2, 2] != 0 && this.board[2, 2] != this.symbol))
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                return availableMoves[0];
                            else
                                return availableMoves[2];
                        }
                        else if ((this.board[0, 0] != 0 && this.board[0, 0] != this.symbol) || (this.board[1, 0] != 0 && this.board[1, 0] != this.symbol))
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
                                return availableMoves[0];
                            else
                                return availableMoves[8];
                        }
                    } // Bottom right corner
                    else
                    {
                        if ((this.board[2, 0] != 0 && this.board[2, 0] != this.symbol) || (this.board[2, 1] != 0 && this.board[2, 1] != this.symbol))
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                return availableMoves[0];
                            else
                                return availableMoves[2];
                        }
                        else if ((this.board[0, 2] != 0 && this.board[0, 2] != this.symbol) || (this.board[0, 1] != 0 && this.board[0, 1] != this.symbol))
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                return availableMoves[0];
                            else
                                return availableMoves[6];
                        }
                        else
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                return availableMoves[2];
                            else
                                return availableMoves[6];
                        }
                    }
                } // If opposing player took the center space
                else
                {
                    // Top left corner
                    if (this.board[0, 0] == this.symbol)
                    {
                        return availableMoves[8];
                    } // Top right corner
                    else if (this.board[0, 2] == this.symbol)
                    {
                        return availableMoves[6];                        
                    } // Bottom left corner 
                    else if (this.board[2, 0] == this.symbol)
                    {
                        return availableMoves[2];
                    } // Bottom right corner
                    else
                    {
                        return availableMoves[0];
                    }
                }
            } // END OF SECOND TURN

            // THIS PLAYER GOES FIRST - THIRD TURN
            else if (availableMoves.Count == 5)
            {
                if (this.board[0, 0] == this.symbol) // one symbol top-left
                {

                }
                else if (this.board[0,2] == this.symbol) // one symbol top-right
                {

                }
                else if (this.board[2,0] == this.symbol) // one symbol bottom-left
                {

                }
            } // END OF THIRD TURN
            #endregion
            // https://www.wikihow.com/Win-at-Tic-Tac-Toe#Never_Losing_when_Playing_Second_sub

            return availableMoves[0]; // CHANGE THIS! SILENCING ERROR!
        }
    }
}
