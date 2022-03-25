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
            cboOpp.SelectedIndex = 0;
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
            if (chkEasy.Checked != true && chkModerate.Checked != true && chkDifficult.Checked != true)
                MessageBox.Show("Select at Least One Player");            
            else
            {
                Tournament t = new Tournament();
                t.MatchResult += T_MatchResult;
                if (chkEasy.Checked)
                {
                    t.AddPlayer(new TicTacToeEasy(1));
                    t.AddPlayer(new TicTacToeEasy(-1));
                }
                if (chkModerate.Checked)
                {
                    t.AddPlayer(new TicTacToeModerate(1));
                    t.AddPlayer(new TicTacToeModerate(-1));
                }
                if (chkDifficult.Checked)
                {
                    t.AddPlayer(new TicTacToeDifficult(1));
                    t.AddPlayer(new TicTacToeDifficult(-1));
                }

                t.Play((int)numMatches.Value);
            }
            
        }

        private void T_MatchResult(Dictionary<string, Tuple<int, int, int>> d, Dictionary<string, int> w)
        {
            lstMatchResults.Items.Clear();
            lstWinRecords.Items.Clear();

            foreach(KeyValuePair<string, Tuple<int, int, int>> kvp in d)
            {
                string tmp = kvp.Key + "= P1: " + kvp.Value.Item1 + ", P2: " + kvp.Value.Item2 + ", Tie: " + kvp.Value.Item3;
                lstMatchResults.Items.Add(tmp);
            }

            foreach(KeyValuePair<string, int> kvp in w)
            {
                string tmp = kvp.Key + " Wins: " + kvp.Value;
                lstWinRecords.Items.Add(tmp);
            }
        }

        private void lstMatchResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if(!rdoX.Checked && !rdoO.Checked)
                MessageBox.Show("Select X or O");
            else
            {
                HumanPlayer hp;
                if (rdoX.Checked)
                    hp = new HumanPlayer("X", cboOpp.Text);
                else
                    hp = new HumanPlayer("O", cboOpp.Text);

                this.Hide();
                hp.ShowDialog();
                this.Show();
            }
        }
    }
}
