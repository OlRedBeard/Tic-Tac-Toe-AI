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
                if (this.board[1, 1] != 0 && this.board[1, 1] != this.symbol) // OPPONENT HAS CENTER
                {
                    if (this.board[0, 1] != 0 && this.board[0, 1] != this.symbol) // opponent has top-center
                    {
                        if (this.board[2, 1] == 0)
                            return availableMoves[7]; // opponent could win vertically center, block with bottom-center
                    }
                    else if (this.board[2, 1] != 0 && this.board[2, 1] != this.symbol) // oponent has bottom-center
                    {
                        if (this.board[0, 1] == 0)
                            return availableMoves[1]; // opponent could win vertically center, block with top-center
                    }
                    else if (this.board[1, 0] != 0 && this.board[1, 0] != this.symbol) // opponent has center-left
                    {
                        if (this.board[1, 2] == 0) // opponent could win horizontally center, block with center-right
                            return availableMoves[5];
                    }
                    else if (this.board[1, 2] != 0 && this.board[1, 2] != this.symbol) // opponent has center-right
                    {
                        if (this.board[1, 0] == 0)
                            return availableMoves[3]; // opponent could win horizontally center, block with center-left
                    }
                    else if (this.board[0, 0] != 0 && this.board[0, 0] != this.symbol) // opponent has top-left
                    {
                        if (this.board[2, 2] == 0)
                            return availableMoves[8]; // opponent could win diagonally tl-br, block with bottom-right
                    }
                    else if (this.board[2, 2] != 0 && this.board[2, 2] != this.symbol) // opponent has bottom-right
                    {
                        if (this.board[0, 0] == 0)
                            return availableMoves[0]; // opponent could win diagonally tl-br, block with top-left
                    }
                    else if (this.board[0, 2] != 0 && this.board[0, 2] != this.symbol) // opponent has top-right
                    {
                        if (this.board[2, 0] == 0)
                            return availableMoves[8]; // opponent could win diagonally tr-bl, block with bottom-left
                    }
                    else if (this.board[2, 0] != 0 && this.board[2, 0] != this.symbol) // opponent has bottom-left
                    {
                        if (this.board[0, 2] == 0)
                            return availableMoves[0]; // opponent could win diagonally tl-br, block with top-right
                    }
                }                 
                else if (this.board[1, 1] == 0) // OPPONENT DOES NOT HAVE CENTER
                {
                    if ((this.board[1, 0] != 0 && this.board[1, 0] != this.symbol)
                        && (this.board[1, 2] != 0 && this.board[1, 2] != this.symbol)) // opponent could win center horizontal, block
                        return availableMoves[4];
                    else if ((this.board[0, 1] != 0 && this.board[0, 1] != this.symbol)
                        && (this.board[2, 1] != 0 && this.board[2, 1] != this.symbol)) // opponent could win center vertical, block
                        return availableMoves[4];
                }
                else if (this.board[0, 0] == this.symbol) // ALL CLEAR - first symbol top-left
                {
                    if (this.board[0, 2] == this.symbol) // second symbol top-right
                    {
                        if (this.board[0, 1] == 0) // spot between is free, win game
                            return availableMoves[1];
                        else if (this.board[2, 2] == 0) // bottom-left corner is free
                            return availableMoves[6];
                        else // bottom-right corner is free
                            return availableMoves[8];
                    }
                    else if (this.board[2, 0] == this.symbol) // second symbol bottom-left
                    {
                        if (this.board[1, 0] == 0) //middle-left spot is free, win game
                            return availableMoves[3];
                        else if (this.board[0, 2] == 0) // top-right spot is free
                            return availableMoves[2];
                        else // bottom-right spot is free
                            return availableMoves[8];
                    }
                    else // second symbol bottom-right
                    {
                        if (this.board[1, 1] == 0) // center spot is free, win game
                            return availableMoves[4];
                        else if (this.board[2, 0] == 0) // bottom-left spot is free
                            return availableMoves[6];
                        else // top-right spot is free
                            return availableMoves[2];
                    }
                }
                else if (this.board[0,2] == this.symbol) // first symbol top-right
                {
                    if (this.board[2, 2] == this.symbol) // second symbol bottom-right
                    {
                        if (this.board[2, 1] == 0)
                            return availableMoves[5]; // center-right is free, win game
                        else if (this.board[0, 2] == 0)
                            return availableMoves[6]; // bottom-left is free
                        else
                            return availableMoves[0]; // top-left is free
                    }
                    else if (this.board[2, 0] == this.symbol) // second symbol bottom-left
                    {
                        if (this.board[1, 1] == 0)
                            return availableMoves[4]; // center is free, win game
                        else if (this.board[2, 2] == 0)
                            return availableMoves[8]; // bottom-left is free
                        else
                            return availableMoves[0]; // top-right is free
                    }
                }
                else if (this.board[2,0] == this.symbol) // first symbol bottom-left
                {
                    if (this.board[2, 2] == this.symbol) // second symbol bottom-right
                    {
                        if (this.board[2, 1] == 0)
                            return availableMoves[7]; // bottom-center is free, win game
                        else if (this.board[0, 2] == 0)
                            return availableMoves[2]; // top-right is free
                        else
                            return availableMoves[0]; // top-left is free
                    }
                }
                else // first symbol bottom-right
                {

                }
            } // END OF THIRD TURN
            #endregion
            // https://www.wikihow.com/Win-at-Tic-Tac-Toe#Never_Losing_when_Playing_Second_sub

            return availableMoves[0]; // CHANGE THIS! SILENCING ERROR!
        }
    }
}
