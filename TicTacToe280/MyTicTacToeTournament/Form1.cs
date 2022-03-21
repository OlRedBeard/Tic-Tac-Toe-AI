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

        private void btnTournament_Click(object sender, EventArgs e)
        {
            int numPlayers = 0;

            if (chkEasy.Checked)
                numPlayers++;
            if (chkModerate.Checked)
                numPlayers++;
            if (chkDifficult.Checked)
                numPlayers++;

            if (chkEasy.Checked != true && chkModerate.Checked != true && chkDifficult.Checked != true)
                MessageBox.Show("Select at Least One Player");            
            else
            {
                Tournament t = new Tournament();
                t.MatchResult += T_MatchResult;
                if (chkEasy.Checked)
                {
                    t.AddPlayer(new TicTacToeEasy(1));
                    if (numPlayers == 1)
                        t.AddPlayer(new TicTacToeEasy(-1));
                }
                if (chkModerate.Checked)
                {
                    t.AddPlayer(new TicTacToeModerate(1));
                    if (numPlayers == 1)
                        t.AddPlayer(new TicTacToeModerate(-1));
                }
                if (chkDifficult.Checked)
                {
                    t.AddPlayer(new TicTacToeDifficult(1));
                    if (numPlayers == 1)
                        t.AddPlayer(new TicTacToeDifficult(-1));
                }

                t.Play((int)numMatches.Value);
            }
            
        }

        private void T_MatchResult(Dictionary<string, Tuple<int, int, int>> d)
        {
            lstMatchResults.DataSource = d.ToList();
        }
    }
}
