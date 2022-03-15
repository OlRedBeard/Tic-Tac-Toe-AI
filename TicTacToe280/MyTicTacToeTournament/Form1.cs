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

namespace MyTicTacToeTournament
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TicTacToeEasy p1 = new TicTacToeEasy(1);
            TicTacToeBase p2 = new TicTacToeBase(-1);
            GameState g = new GameState(p1, p2);
            g.WinnerIs += G_WinnerIs;
            g.Play();
        }

        private void G_WinnerIs(TicTacToeBasePlayer.ITicTacToePlayer p)
        {
            MessageBox.Show(p.Name() + " won the game!");
        }
    }
}
