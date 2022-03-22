using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeBasePlayer;

namespace TicTacToe
{
    public class GameState
    {
        private ITicTacToePlayer winner;
        public delegate void DeclareWinner(ITicTacToePlayer p);
        public event DeclareWinner WinnerIs;

        // Board representation
        int[,] board = new int[3, 3];
        List<Tuple<int, int>> AvailableMoves = new List<Tuple<int, int>>();
        Queue<ITicTacToePlayer> players = new Queue<ITicTacToePlayer>();

        public GameState(ITicTacToePlayer p1, ITicTacToePlayer p2)
        {
            int[] tmp = { p1.Symbol(), p2.Symbol() };

            // Check and make sure the players are initialized with valid symbols
            if(!tmp.Contains(1) || !tmp.Contains(-1))
                throw new Exception("Players must be created with a 1 and -1");

            // Add players to Queue
            players.Enqueue(p1);
            players.Enqueue(p2);

            // Set up an event handler for the winnerIs
            WinnerIs += GameState_WinnerIs;

            // Set up collection of available moves
            for (int i = 0; i <=2; i++)
            {
                Tuple<int, int> m1 = new Tuple<int, int>(i, 0);
                Tuple<int, int> m2 = new Tuple<int, int>(i, 1);
                Tuple<int, int> m3 = new Tuple<int, int>(i, 2);
                AvailableMoves.Add(m1);
                AvailableMoves.Add(m2);
                AvailableMoves.Add(m3);
            }
        }

        public void Play()
        {
            UpdateBothPlayers();

            while(AvailableMoves.Count != 0 && winner == null)
            {
                // Create a variable to hold a move
                Tuple<int, int> move;

                // Get the current player's turn
                ITicTacToePlayer p = players.Dequeue();

                // Create a task where the class will come up with a move - Timeout of 5 seconds
                var task = Task.Run(() => p.MakeMove());

                // Player must submit a move within 5 seconds or the first available move will be made by default
                if (task.Wait(TimeSpan.FromSeconds(5)))
                    move = task.Result;
                else
                    move = AvailableMoves.FirstOrDefault();

                // Check if the player's move is valid
                if (AvailableMoves.Contains(move))
                {
                    // Actually make the move
                    board[move.Item1, move.Item2] = p.Symbol();
                    // Remove that move from the list
                    AvailableMoves.Remove(move);
                }
                else // If the move is not valid execute the default move
                {
                    move = AvailableMoves.FirstOrDefault();
                    board[move.Item1, move.Item2] = p.Symbol();
                    AvailableMoves.Remove(move);
                }

                // Add the player back to the queue to maintain turn order
                players.Enqueue(p);

                // Check if the game's been won
                CheckForWinner();

                // Update both players with most recent information
                UpdateBothPlayers();
            }
        }

        public void CheckForWinner()
        {
            for (int i = 0; i <= 2; i++)
            {
                // Check horizontal
                if (Math.Abs(board[i,0] + board[i,1] + board[i,2]) == 3)
                {
                    // Someone won horizontally
                    WinnerIs(players.Where(x => x.Symbol() == board[i, 0]).FirstOrDefault());
                }
                // Check vertical
                else if (Math.Abs(board[0,i] + board[1,i] + board[2,i]) == 3)
                {
                    // Someone won vertically
                    WinnerIs(players.Where(x => x.Symbol() == board[0, i]).FirstOrDefault());
                }             
            }

            // Check diagonal
            if (Math.Abs(board[0,0] + board[1,1] + board[2,2]) == 3)
            {
                // Someone won diagonally
                WinnerIs(players.Where(x => x.Symbol() == board[0, 0]).FirstOrDefault());
            }
            else if (Math.Abs(board[2,0] + board[1,1] + board [0,2]) == 3)
            {
                // Someone won diagonally
                WinnerIs(players.Where(x => x.Symbol() == board[2, 0]).FirstOrDefault());
            }

            if (AvailableMoves.Count == 0)
                WinnerIs(null);
        }

        public void UpdateBothPlayers()
        {
            ITicTacToePlayer p1 = players.Dequeue();
            ITicTacToePlayer p2 = players.Dequeue();

            p1.GameChanged(board.Clone() as int[,], AvailableMoves);
            p2.GameChanged(board.Clone() as int[,], AvailableMoves);

            players.Enqueue(p1);
            players.Enqueue(p2);
        }

        private void GameState_WinnerIs(ITicTacToePlayer p)
        {
            // Set a variable to hold the player who won
            this.winner = p;
        }
    }
}
