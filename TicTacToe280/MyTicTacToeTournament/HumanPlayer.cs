using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeBasePlayer;
using GerritEasyPlayer;
using GerritModeratePlayer;
using GerritDifficultPlayer;

namespace MyTicTacToeTournament
{
    public partial class HumanPlayer : Form
    {
        public int playerSymbol = 0;
        public string player = "";
        public bool yourTurn = true;
        public bool gameOver = false;

        public ITicTacToePlayer opp;
        int[,] board = new int[3, 3];
        List<Tuple<int, int>> AvailableMoves = new List<Tuple<int, int>>();

        public HumanPlayer(string symbol, string opponent)
        {
            InitializeComponent();

            player = symbol;

            if (symbol == "X")
                playerSymbol = 1;                
            else
                playerSymbol = -1;

            if (opponent == "Easy")
                opp = new TicTacToeEasy(playerSymbol * -1);
            else if (opponent == "Moderate")
                opp = new TicTacToeModerate(playerSymbol * -1);
            else
                opp = new TicTacToeDifficult(playerSymbol * -1);

            for (int i = 0; i < 3; i++)
            {
                Tuple<int, int> m1 = new Tuple<int, int>(i, 0);
                Tuple<int, int> m2 = new Tuple<int, int>(i, 1);
                Tuple<int, int> m3 = new Tuple<int, int>(i, 2);
                AvailableMoves.Add(m1);
                AvailableMoves.Add(m2);
                AvailableMoves.Add(m3);
            }

            gameOver = false;
        }

        private void HumanPlayer_Load(object sender, EventArgs e)
        {
            // X goes first, 
            if (player != "X")
            {
                yourTurn = false;
                CompMove();
            }
        }

        private void Click(object sender, EventArgs e)
        {
            Button x = (Button)sender;

            if (x.Text == "" && yourTurn)
            {
                x.Text = player;
                switch (x.Name)
                {
                    case ("btn00"):
                        board[0, 0] = playerSymbol;
                        AvailableMoves.Remove(new Tuple<int, int>(0, 0));
                        break;
                    case ("btn01"):
                        board[0, 1] = playerSymbol;
                        AvailableMoves.Remove(new Tuple<int, int>(0, 1));
                        break;
                    case ("btn02"):
                        board[0, 2] = playerSymbol;
                        AvailableMoves.Remove(new Tuple<int, int>(0, 2));
                        break;
                    case ("btn10"):
                        board[1, 0] = playerSymbol;
                        AvailableMoves.Remove(new Tuple<int, int>(1, 0));
                        break;
                    case ("btn11"):
                        board[1,1] = playerSymbol;
                        AvailableMoves.Remove(new Tuple<int, int>(1,1));
                        break;
                    case ("btn12"):
                        board[1,2] = playerSymbol;
                        AvailableMoves.Remove(new Tuple<int, int>(1,2));
                        break;
                    case ("btn20"):
                        board[2, 0] = playerSymbol;
                        AvailableMoves.Remove(new Tuple<int, int>(2, 0));
                        break;
                    case ("btn21"):
                        board[2,1] = playerSymbol;
                        AvailableMoves.Remove(new Tuple<int, int>(2,1));
                        break;
                    case ("btn22"):
                        board[2,2] = playerSymbol;
                        AvailableMoves.Remove(new Tuple<int, int>(2,2));
                        break;
                }

                yourTurn = false;
                CheckForWin();

                if (!gameOver)
                {
                    opp.GameChanged(board.Clone() as int[,], AvailableMoves);
                    CompMove();
                }
            }
        }

        private void CompMove()
        {
            Tuple<int, int> move;

            // Create a task where the class will come up with a move - Timeout of 5 seconds
            var task = Task.Run(() => opp.MakeMove());

            // Player must submit a move within 5 seconds or the first available move will be made by default
            if (task.Wait(TimeSpan.FromSeconds(5)))
                move = task.Result;
            else
                move = AvailableMoves.FirstOrDefault();

            // Check if the player's move is valid
            if (AvailableMoves.Contains(move))
            {
                // Mark the board
                if (move.Item1 == 0)
                {
                    if (move.Item2 == 0)
                    {
                        if (player == "X")
                            btn00.Text = "O";
                        else
                            btn00.Text = "X";
                    }                        
                    else if (move.Item2 == 1)
                    {
                        if (player == "X")
                            btn01.Text = "O";
                        else
                            btn01.Text = "X";
                    }                        
                    else
                    {
                        if (player == "X")
                            btn02.Text = "O";
                        else
                            btn02.Text = "X";
                    }                        
                }
                else if (move.Item1 == 1)
                {
                    if (move.Item2 == 0)
                    {
                        if (player == "X")
                            btn10.Text = "O";
                        else
                            btn10.Text = "X";
                    }
                    else if (move.Item2 == 1)
                    {
                        if (player == "X")
                            btn11.Text = "O";
                        else
                            btn11.Text = "X";
                    }
                    else
                    {
                        if (player == "X")
                            btn12.Text = "O";
                        else
                            btn12.Text = "X";
                    }
                }
                else
                {
                    if (move.Item2 == 0)
                    {
                        if (player == "X")
                            btn20.Text = "O";
                        else
                            btn20.Text = "X";
                    }
                    else if (move.Item2 == 1)
                    {
                        if (player == "X")
                            btn21.Text = "O";
                        else
                            btn21.Text = "X";
                    }
                    else
                    {
                        if (player == "X")
                            btn22.Text = "O";
                        else
                            btn22.Text = "X";
                    }
                }
                // Actually make the move
                board[move.Item1, move.Item2] = opp.Symbol();
                // Remove that move from the list
                AvailableMoves.Remove(move);
            }
            else // If the move is not valid execute the default move
            {               
                move = AvailableMoves.FirstOrDefault();
                // Mark the board
                if (move.Item1 == 0)
                {
                    if (move.Item2 == 0)
                    {
                        if (player == "X")
                            btn00.Text = "O";
                        else
                            btn00.Text = "X";
                    }
                    else if (move.Item2 == 1)
                    {
                        if (player == "X")
                            btn01.Text = "O";
                        else
                            btn01.Text = "X";
                    }
                    else
                    {
                        if (player == "X")
                            btn02.Text = "O";
                        else
                            btn02.Text = "X";
                    }
                }
                else if (move.Item1 == 1)
                {
                    if (move.Item2 == 0)
                    {
                        if (player == "X")
                            btn10.Text = "O";
                        else
                            btn10.Text = "X";
                    }
                    else if (move.Item2 == 1)
                    {
                        if (player == "X")
                            btn11.Text = "O";
                        else
                            btn11.Text = "X";
                    }
                    else
                    {
                        if (player == "X")
                            btn12.Text = "O";
                        else
                            btn12.Text = "X";
                    }
                }
                else
                {
                    if (move.Item2 == 0)
                    {
                        if (player == "X")
                            btn20.Text = "O";
                        else
                            btn20.Text = "X";
                    }
                    else if (move.Item2 == 1)
                    {
                        if (player == "X")
                            btn21.Text = "O";
                        else
                            btn21.Text = "X";
                    }
                    else
                    {
                        if (player == "X")
                            btn22.Text = "O";
                        else
                            btn22.Text = "X";
                    }
                }
                // Make the move and remove the item
                board[move.Item1, move.Item2] = opp.Symbol();
                AvailableMoves.Remove(move);
            }
            CheckForWin();
            if (!gameOver)
            {
                opp.GameChanged(board.Clone() as int[,], AvailableMoves);
                yourTurn = true;
            }            
        }

        public void CheckForWin()
        {
            for (int i = 0; i <= 2; i++)
            {
                // Check horizontal
                if (Math.Abs(board[i, 0] + board[i, 1] + board[i, 2]) == 3)
                {
                    // Someone won horizontally
                    if (board[i, 0] == playerSymbol)
                    {
                        MessageBox.Show("You Win!");
                        gameOver = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("You Lose!");
                        gameOver = true;
                        this.Close();
                    }
                }
                // Check vertical
                else if (Math.Abs(board[0, i] + board[1, i] + board[2, i]) == 3)
                {
                    // Someone won vertically
                    if (board[0, i] == playerSymbol)
                    {
                        MessageBox.Show("You Win!");
                        gameOver = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("You Lose!");
                        gameOver = true;
                        this.Close();
                    }
                }
            }

            // Check diagonal
            if (Math.Abs(board[0, 0] + board[1, 1] + board[2, 2]) == 3)
            {
                // Someone won diagonally
                if (board[0, 0] == playerSymbol)
                {
                    MessageBox.Show("You Win!");
                    gameOver = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You Lose!");
                    gameOver = true;
                    this.Close();
                }
            }
            else if (Math.Abs(board[2, 0] + board[1, 1] + board[0, 2]) == 3)
            {
                // Someone won diagonally
                if (board[2, 0] == playerSymbol)
                {
                    MessageBox.Show("You Win!");
                    gameOver = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You Lose!");
                    gameOver = true;
                    this.Close();
                }
            }

            if (AvailableMoves.Count == 0)
            {
                MessageBox.Show("Tie!");
                gameOver = true;
                this.Close();
            }
        }
    }
}
