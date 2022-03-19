using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Game State
using TicTacToe;
using MyTicTacToeTournament;
// Game Player
using TicTacToeBasePlayer;
using GerritEasyPlayer;
using GerritModeratePlayer;
using GerritDifficultPlayer;

namespace MyTicTacToeTournament
{
    public partial class Form1 : Form
    {
        ITicTacToePlayer winner = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            winner = null;
            TicTacToeEasy p1 = new TicTacToeEasy(1);
            TicTacToeDifficult p2 = new TicTacToeDifficult(-1);
            GameState g = new GameState(p1, p2);
            g.WinnerIs += G_WinnerIs;
            g.Play();
            if(winner == null)
                MessageBox.Show("Tie");
            else
                MessageBox.Show(winner.Name() + " won the game!");
        }

        private void G_WinnerIs(TicTacToeBasePlayer.ITicTacToePlayer p)
        {
            this.winner = p;
        }
    }
}
