using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeBasePlayer;
using GerritEasyPlayer;
using GerritModeratePlayer;
using GerritDifficultPlayer;

namespace TicTacToe
{
    public class Tournament
    {
        private List<ITicTacToePlayer> competitors = new List<ITicTacToePlayer>();
        ITicTacToePlayer one;
        ITicTacToePlayer two;

        Dictionary<string, int> p1score = new Dictionary<string, int>();
        Dictionary<string, int> p2score = new Dictionary<string, int>();
        Dictionary<string, Tuple<int, int, int>> matchRecord = new Dictionary<string, Tuple<int, int, int>>();
        int p1wins;
        int p2wins;
        int ties;

        public delegate void ReportMatch(Dictionary<string, Tuple<int, int, int>> d);
        public event ReportMatch MatchResult;

        public Tournament()
        {

        }

        public void Play(int numMatches)
        {
            int rounds = numMatches;

            for (int j = 0; j < competitors.Count - 1; j++)
            {
                p1wins = 0;
                p2wins = 0;
                ties = 0;

                one = competitors[j];
                two = competitors[j + 1];
                

                if (one is TicTacToeEasy)
                    one = new TicTacToeEasy(1);
                else if (one is TicTacToeModerate)
                    one = new TicTacToeModerate(1);
                else
                    one = new TicTacToeDifficult(1);

                if (two is TicTacToeEasy)
                    two = new TicTacToeEasy(-1);
                else if (two is TicTacToeModerate)
                    two = new TicTacToeModerate(-1);
                else
                    two = new TicTacToeDifficult(-1);

                
                p1score.Add(one.Name(), 0);
                p2score.Add(two.Name(), 0);
                GameState g = new GameState(one, two);
                g.WinnerIs += G_WinnerIs;

                for (int i = 0; i < rounds; i++)
                {
                    g.Play();
                }

                Tuple<int, int, int> scoreBoard = new Tuple<int, int, int>(p1wins, p2wins, ties);
                matchRecord.Add(one.Name() + " vs. " + two.Name(), scoreBoard);
                MatchResult(matchRecord);
            }
        }

        private void G_WinnerIs(ITicTacToePlayer p)
        {
            if (p == one)
            {
                p1score[one.Name()] += 1;
                p1wins += 1;
            }                
            else if (p == two)
            {
                p2score[two.Name()] += 1;
                p2wins += 1;
            }                
            else if (p == null)
                ties += 1;
            else
                throw new Exception("Players not initialized correctly.");
        }

        public void AddPlayer(ITicTacToePlayer player)
        {
            competitors.Add(player);
        }

        public List<ITicTacToePlayer> CheckPlayers()
        {
            // for testing
            return competitors;
        }
    }
}
