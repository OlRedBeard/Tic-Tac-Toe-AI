using System;
using TicTacToeBasePlayer;

namespace GerritDifficultPlayer
{
    public class TicTacToeDifficult : TicTacToeBase
    {
        public TicTacToeDifficult(int symbol) : base(symbol)
        {
            this.playername = "Matthew Broderic";
        }

        public override Tuple<int, int> MakeMove()
        {
            Tuple<int, int> theMove = null;
            // THIS PLAYER GOES FIRST
            #region goingfirst            
            if (availableMoves.Count == 9) // FIRST TURN
            {
                int corner = rnd.Next(1, 5); // Take a corner spot

                if (corner == 1)
                    theMove = new Tuple<int, int>(0, 0);
                else if (corner == 2)
                    theMove = new Tuple<int, int>(0, 2);
                else if (corner == 3)
                    theMove = new Tuple<int, int>(2, 0);
                else
                    theMove = new Tuple<int, int>(2, 2);
            } // END OF FIRST TURN            
            else if (availableMoves.Count == 7) // SECOND TURN
            {
                if (this.board[1, 1] == 0) // If the opposing player didn't take center space
                {
                    // Top left corner
                    if (this.board[0, 0] == this.symbol)
                    {
                        if ((this.board[0, 1] != 0 && this.board[0, 1] != this.symbol) || 
                            (this.board[0, 2] != 0 && this.board[0, 2] != this.symbol))
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                theMove = new Tuple<int, int>(2,0);
                            else
                                theMove = new Tuple<int, int>(2, 2);
                        }
                        else if ((this.board[1, 0] != 0 && this.board[1, 0] != this.symbol) || 
                            (this.board[2, 0] != 0 && this.board[2, 0] != this.symbol))
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                theMove = new Tuple<int, int>(0, 1);
                            else
                                theMove = new Tuple<int, int>(2, 2);
                        }
                        else
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                theMove = new Tuple<int, int>(0, 1);
                            else
                                theMove = new Tuple<int, int>(2, 0);
                        }
                    } // Top right corner
                    else if (this.board[0, 2] == this.symbol)
                    {
                        if ((this.board[1, 2] != 0 && this.board[1, 2] != this.symbol) || 
                            (this.board[2, 2] != 0 && this.board[2, 2] != this.symbol))
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                theMove = new Tuple<int, int>(0, 0);
                            else
                                theMove = new Tuple<int, int>(2, 0);
                        }
                        else if ((this.board[0, 0] != 0 && this.board[0, 0] != this.symbol) || 
                            (this.board[0, 1] != 0 && this.board[0, 1] != this.symbol))
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                theMove = new Tuple<int, int>(2, 0);
                            else
                                theMove = new Tuple<int, int>(2, 2);
                        }
                        else
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                theMove = new Tuple<int, int>(0, 0);
                            else
                                theMove = new Tuple<int, int>(2, 2);
                        }
                    } // Bottom left corner 
                    else if (this.board[2, 0] == this.symbol)
                    {
                        if ((this.board[2, 1] != 0 && this.board[2, 1] != this.symbol) || 
                            (this.board[2, 2] != 0 && this.board[2, 2] != this.symbol))
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                theMove = new Tuple<int, int>(0, 0);
                            else
                                theMove = new Tuple<int, int>(0, 2);
                        }
                        else if ((this.board[0, 0] != 0 && this.board[0, 0] != this.symbol) || 
                            (this.board[1, 0] != 0 && this.board[1, 0] != this.symbol))
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                theMove = new Tuple<int, int>(0, 2);
                            else
                                theMove = new Tuple<int, int>(2, 2);
                        }
                        else
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                theMove = new Tuple<int, int>(0, 0);
                            else
                                theMove = new Tuple<int, int>(2, 2);
                        }
                    } // Bottom right corner
                    else
                    {
                        if ((this.board[2, 0] != 0 && this.board[2, 0] != this.symbol) || 
                            (this.board[2, 1] != 0 && this.board[2, 1] != this.symbol))
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                theMove = new Tuple<int, int>(0, 0);
                            else
                                theMove = new Tuple<int, int>(0, 2);
                        }
                        else if ((this.board[0, 2] != 0 && this.board[0, 2] != this.symbol) || (this.board[0, 1] != 0 && this.board[0, 1] != this.symbol))
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                theMove = new Tuple<int, int>(0, 0);
                            else
                                theMove = new Tuple<int, int>(2, 0);
                        }
                        else
                        {
                            int coin = rnd.Next(0, 1);
                            if (coin == 0)
                                theMove = new Tuple<int, int>(0, 2);
                            else
                                theMove = new Tuple<int, int>(2, 0);
                        }
                    }
                } // If opposing player took the center space
                else
                {                    
                    if (this.board[0, 0] == this.symbol) // Top left corner
                        theMove = new Tuple<int, int>(2, 2); 
                    else if (this.board[0, 2] == this.symbol) // Top right corner
                        theMove = new Tuple<int, int>(2, 0); 
                    else if (this.board[2, 0] == this.symbol) // Bottom left corner 
                        theMove = new Tuple<int, int>(0, 2);
                    else // Bottom right corner
                        theMove = new Tuple<int, int>(0, 0); 
                }

                return theMove;
            } // END OF SECOND TURN - NEEDS REVISION
            // THIRD TURN
            else if (availableMoves.Count == 5) 
            {
                // CHECK FOR WINS
                theMove = CheckForWin();
                if (theMove == null)
                {
                    // CHECK FOR BLOCKS
                    theMove = CheckForBlock();
                    if (theMove == null)
                    {
                        // SET UP TWO WINS
                        // including upper left corner
                        if (this.board[0,0] == this.symbol && this.board[0,2] == this.symbol)
                        {
                            if (this.board[2,0] == 0 && this.board[1,0] == 0)
                                theMove = new Tuple<int, int>(2, 0);
                            else
                                theMove = new Tuple<int, int>(2, 2);
                        }
                        else if (this.board[0, 0] == this.symbol && this.board[2, 0] == this.symbol)
                        {
                            if (this.board[2, 2] == 0 && this.board[2, 1] == 0)
                                theMove = new Tuple<int, int>(2, 2);
                            else
                                theMove = new Tuple<int, int>(0, 2);
                        }
                        // no upper left corner
                        else if (this.board[0, 2] == this.symbol && this.board[2, 2] == this.symbol)
                        {
                            if (this.board[0, 0] == 0 && this.board[0, 1] == 0)
                                theMove = new Tuple<int, int>(0, 0);
                            else
                                theMove = new Tuple<int, int>(2, 0);
                        }
                        else
                        {
                            if (this.board[0, 0] == 0 && this.board[0, 1] == 0)
                                theMove = new Tuple<int, int>(0, 0);
                            else
                                theMove = new Tuple<int, int>(0, 2);
                        }
                    }
                }                
                
                return theMove;
            }

            // THIS PLAYER GOES FIRST - SUBSEQUENT TURNS
            else if (availableMoves.Count % 2 != 0)
            {
                // CHECK FOR WINS
                theMove = CheckForWin();

                if (theMove == null)
                {
                    // CHECK FOR BLOCKS
                    theMove = CheckForBlock();
                    if (theMove == null)
                    {
                        // TRY FOR CORNER
                        if (this.board[0, 0] == 0)
                            return new Tuple<int, int>(0, 0);
                        else if (this.board[0, 2] == 0)
                            return new Tuple<int, int>(0, 2);
                        else if (this.board[2, 2] == 0)
                            return new Tuple<int, int>(2, 2);
                        else if (this.board[2, 0] == 0)
                            return new Tuple<int, int>(2, 0);
                        else
                        {
                            // NO CORNERS, PICK RANDOM SPOT
                            int a = rnd.Next(0, availableMoves.Count);
                            theMove = availableMoves[a];
                        }
                    }
                }

                return theMove;
            }
            #endregion

            // THIS PLAYER GOES SECOND
            #region goingsecond
            else if (availableMoves.Count == 8) // FIRST TURN
            {
                // logic for if the opponent takes a corner
                if ((this.board[0, 0] != 0 && this.board[0, 0] != this.symbol) ||
                    (this.board[0, 2] != 0 && this.board[0, 2] != this.symbol) ||
                    (this.board[2, 0] != 0 && this.board[2, 0] != this.symbol) ||
                    (this.board[2, 2] != 0 && this.board[2, 2] != this.symbol))
                    theMove = new Tuple<int, int>(1, 1);
                // logic for if the opponent takes the center
                else if (this.board[1,1] != 0 && this.board[1,1] != this.symbol)
                {
                    int corner = rnd.Next(0, 3);
                    if (corner == 0)
                        theMove = new Tuple<int, int>(0, 0);
                    else if (corner == 1)
                        theMove = new Tuple<int, int>(0, 2);
                    else if (corner == 2)
                        theMove = new Tuple<int, int>(2, 0);
                    else
                        theMove = new Tuple<int, int>(2, 2);
                }                    
                // logic for if the opponent takes an edge
                else
                    theMove = new Tuple<int, int>(1, 1);

                return theMove;
            }
            else if (availableMoves.Count == 6) // SECOND TURN
            {
                // check for blocks
                theMove = CheckForBlock();
                // logic for spot to take
                if (theMove == null)
                {
                    if (this.board[0, 0] == 0)
                        theMove = new Tuple<int, int>(0, 0);
                    else if (this.board[0, 2] == 0)
                        theMove = new Tuple<int, int>(0, 2);
                    else if (this.board[2, 2] == 0)
                        theMove = new Tuple<int, int>(2, 2);
                    else if (this.board[2, 0] == 0)
                        theMove = new Tuple<int, int>(2, 0);
                    else
                    {
                        int spot = rnd.Next(0, availableMoves.Count);
                        theMove = availableMoves[spot];
                    }
                }

                return theMove;
            } 
            else if (availableMoves.Count %2 == 0 && availableMoves.Count != 0)
            {
                
                // CHECK FOR WINS
                theMove = CheckForWin();

                if (theMove == null)
                {
                    // NO POSSIBLE WINS - CHECK FOR BLOCKS
                    theMove = CheckForBlock();
                    if (theMove == null)
                    {
                        // NO BLOCKS NEEDED
                        if (this.board[0, 0] == 0)
                            theMove = new Tuple<int, int>(0, 0);
                        else if (this.board[0, 2] == 0)
                            theMove = new Tuple<int, int>(0, 2);
                        else if (this.board[2, 2] == 0)
                            theMove = new Tuple<int, int>(2, 2);
                        else if (this.board[2, 0] == 0)
                            theMove = new Tuple<int, int>(2, 0);
                        else
                        {
                            int a = rnd.Next(0, availableMoves.Count);
                            theMove = availableMoves[a];
                        }
                    }
                }

                return theMove;
            }
            #endregion
            // https://www.wikihow.com/Win-at-Tic-Tac-Toe#Never_Losing_when_Playing_Second_sub
            return theMove;
        }
        public Tuple<int, int> CheckForWin()
        {
            // horizontal on top row
            if (this.board[0, 0] == this.symbol && this.board[0, 1] == this.symbol && this.board[0, 2] == 0)
                return new Tuple<int, int>(0, 2);
            else if (this.board[0, 0] == this.symbol && this.board[0, 2] == this.symbol && this.board[0, 1] == 0)
                return new Tuple<int, int>(0, 1);
            else if (this.board[0, 1] == this.symbol && this.board[0, 2] == this.symbol && this.board[0, 0] == 0)
                return new Tuple<int, int>(0, 0);
            // horizontal on center row
            else if (this.board[1, 0] == this.symbol && this.board[1, 1] == this.symbol && this.board[1, 2] == 0)
                return new Tuple<int, int>(1, 2);
            else if (this.board[1, 0] == this.symbol && this.board[1, 2] == this.symbol && this.board[1, 1] == 0)
                return new Tuple<int, int>(1, 1);
            else if (this.board[1, 1] == this.symbol && this.board[1, 2] == this.symbol && this.board[1, 0] == 0)
                return new Tuple<int, int>(1, 0);
            // horizontal on bottom row
            else if (this.board[2, 0] == this.symbol && this.board[2, 1] == this.symbol && this.board[2, 2] == 0)
                return new Tuple<int, int>(2, 2);
            else if (this.board[2, 0] == this.symbol && this.board[2, 2] == this.symbol && this.board[2, 1] == 0)
                return new Tuple<int, int>(2, 1);
            else if (this.board[2, 1] == this.symbol && this.board[2, 2] == this.symbol && this.board[2, 0] == 0)
                return new Tuple<int, int>(2, 0);
            // vertical on left column
            else if (this.board[0, 0] == this.symbol && this.board[1, 0] == this.symbol && this.board[2, 0] == 0)
                return new Tuple<int, int>(2, 0);
            else if (this.board[0, 0] == this.symbol && this.board[2, 0] == this.symbol && this.board[1, 0] == 0)
                return new Tuple<int, int>(1, 0);
            else if (this.board[1, 0] == this.symbol && this.board[2, 0] == this.symbol && this.board[0, 0] == 0)
                return new Tuple<int, int>(0, 0);
            // veritcal on center column
            else if (this.board[0, 1] == this.symbol && this.board[1, 1] == this.symbol && this.board[2, 1] == 0)
                return new Tuple<int, int>(2, 1);
            else if (this.board[0, 1] == this.symbol && this.board[2, 1] == this.symbol && this.board[1, 1] == 0)
                return new Tuple<int, int>(1, 1);
            else if (this.board[1, 1] == this.symbol && this.board[2, 1] == this.symbol && this.board[0, 1] == 0)
                return new Tuple<int, int>(0, 1);
            // vertical on right column
            else if (this.board[0, 2] == this.symbol && this.board[1, 2] == this.symbol && this.board[2, 2] == 0)
                return new Tuple<int, int>(2, 2);
            else if (this.board[0, 2] == this.symbol && this.board[2, 2] == this.symbol && this.board[1, 2] == 0)
                return new Tuple<int, int>(1, 2);
            else if (this.board[1, 2] == this.symbol && this.board[2, 2] == this.symbol && this.board[0, 2] == 0)
                return new Tuple<int, int>(0, 2);
            // vertical down right
            else if (this.board[0, 0] == this.symbol && this.board[1, 1] == this.symbol && this.board[2, 2] == 0)
                return new Tuple<int, int>(2, 2);
            else if (this.board[0, 0] == this.symbol && this.board[2, 2] == this.symbol && this.board[1, 1] == 0)
                return new Tuple<int, int>(1, 1);
            else if (this.board[1, 1] == this.symbol && this.board[2, 2] == this.symbol && this.board[0, 0] == 0)
                return new Tuple<int, int>(0, 0);
            // vertical up right
            else if (this.board[2, 0] == this.symbol && this.board[1, 1] == this.symbol && this.board[0, 2] == 0)
                return new Tuple<int, int>(0, 2);
            else if (this.board[2, 0] == this.symbol && this.board[0, 2] == this.symbol && this.board[1, 1] == 0)
                return new Tuple<int, int>(1, 1);
            else if (this.board[1, 1] == this.symbol && this.board[2, 0] == this.symbol && this.board[2, 0] == 0)
                return new Tuple<int, int>(2, 0);
            else
                return null;
        }
        public Tuple<int, int> CheckForBlock()
        {
            // horizontal top row
            if ((this.board[0, 0] != 0 && this.board[0, 0] != this.symbol) &&
                (this.board[0, 1] != 0 && this.board[0, 1] != this.symbol))
                return new Tuple<int, int>(0, 2);
            else if ((this.board[0, 0] != 0 && this.board[0, 0] != this.symbol) &&
                (this.board[0, 2] != 0 && this.board[0, 2] != this.symbol))
                return new Tuple<int, int>(0, 1);
            else if ((this.board[0, 2] != 0 && this.board[0, 2] != this.symbol) &&
                (this.board[0, 1] != 0 && this.board[0, 1] != this.symbol))
                return new Tuple<int, int>(0, 0);
            // horizontal center row
            else if ((this.board[1, 0] != 0 && this.board[1, 0] != this.symbol) &&
                (this.board[1, 1] != 0 && this.board[1, 1] != this.symbol))
                return new Tuple<int, int>(1, 2);
            else if ((this.board[1, 0] != 0 && this.board[1, 0] != this.symbol) &&
                (this.board[1, 2] != 0 && this.board[1, 2] != this.symbol))
                return new Tuple<int, int>(1, 1);
            else if ((this.board[1, 2] != 0 && this.board[1, 2] != this.symbol) &&
                (this.board[1, 1] != 0 && this.board[1, 1] != this.symbol))
                return new Tuple<int, int>(1, 0);
            // horizontal bottom row
            else if ((this.board[2, 0] != 0 && this.board[2, 0] != this.symbol) &&
                (this.board[2, 1] != 0 && this.board[2, 1] != this.symbol))
                return new Tuple<int, int>(2, 2);
            else if ((this.board[2, 0] != 0 && this.board[2, 0] != this.symbol) &&
                (this.board[2, 2] != 0 && this.board[2, 2] != this.symbol))
                return new Tuple<int, int>(2, 1);
            else if ((this.board[2, 2] != 0 && this.board[2, 2] != this.symbol) &&
                (this.board[2, 1] != 0 && this.board[2, 1] != this.symbol))
                return new Tuple<int, int>(2, 0);
            // vertical left column
            else if ((this.board[0, 0] != 0 && this.board[0, 0] != this.symbol) &&
                (this.board[1, 0] != 0 && this.board[1, 0] != this.symbol))
                return new Tuple<int, int>(2, 0);
            else if ((this.board[0, 0] != 0 && this.board[0, 0] != this.symbol) &&
                (this.board[2, 0] != 0 && this.board[2, 0] != this.symbol))
                return new Tuple<int, int>(1, 0);
            else if ((this.board[2, 0] != 0 && this.board[2, 0] != this.symbol) &&
                (this.board[1, 0] != 0 && this.board[1, 0] != this.symbol))
                return new Tuple<int, int>(0, 0);
            // vertical middle column
            else if ((this.board[0, 1] != 0 && this.board[0, 1] != this.symbol) &&
                (this.board[1, 1] != 0 && this.board[1, 1] != this.symbol))
                return new Tuple<int, int>(2, 1);
            else if ((this.board[0, 1] != 0 && this.board[0, 1] != this.symbol) &&
                (this.board[2, 1] != 0 && this.board[2, 1] != this.symbol))
                return new Tuple<int, int>(1, 1);
            else if ((this.board[2, 1] != 0 && this.board[2, 1] != this.symbol) &&
                (this.board[1, 1] != 0 && this.board[1, 1] != this.symbol))
                return new Tuple<int, int>(0, 1);
            // vertical right column
            else if ((this.board[0, 2] != 0 && this.board[0, 2] != this.symbol) &&
                (this.board[1, 2] != 0 && this.board[1, 2] != this.symbol))
                return new Tuple<int, int>(2, 2);
            else if ((this.board[0, 2] != 0 && this.board[0, 2] != this.symbol) &&
                (this.board[2, 2] != 0 && this.board[2, 2] != this.symbol))
                return new Tuple<int, int>(1, 2);
            else if ((this.board[2, 2] != 0 && this.board[2, 2] != this.symbol) &&
                (this.board[1, 2] != 0 && this.board[1, 2] != this.symbol))
                return new Tuple<int, int>(0, 2);
            // diagonal down right
            else if ((this.board[0, 0] != 0 && this.board[0, 0] != this.symbol) &&
                (this.board[1, 1] != 0 && this.board[1, 1] != this.symbol))
                return new Tuple<int, int>(2, 2);
            else if ((this.board[0, 0] != 0 && this.board[0, 0] != this.symbol) &&
                (this.board[2, 2] != 0 && this.board[2, 2] != this.symbol))
                return new Tuple<int, int>(1, 1);
            else if ((this.board[2, 2] != 0 && this.board[2, 2] != this.symbol) &&
                (this.board[1, 1] != 0 && this.board[1, 1] != this.symbol))
                return new Tuple<int, int>(0, 0);
            // diagonal up right
            else if ((this.board[0, 2] != 0 && this.board[0, 2] != this.symbol) &&
                (this.board[1, 1] != 0 && this.board[1, 1] != this.symbol))
                return new Tuple<int, int>(2, 0);
            else if ((this.board[0, 2] != 0 && this.board[0, 2] != this.symbol) &&
                (this.board[2, 0] != 0 && this.board[2, 0] != this.symbol))
                return new Tuple<int, int>(1, 1);
            else if ((this.board[2, 0] != 0 && this.board[2, 0] != this.symbol) &&
                (this.board[1, 1] != 0 && this.board[1, 1] != this.symbol))
                return new Tuple<int, int>(0, 2);
            else
                return null;
        }
    }
}
