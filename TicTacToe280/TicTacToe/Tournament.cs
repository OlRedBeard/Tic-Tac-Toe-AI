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
        ITicTacToePlayer winner = null;
        List<ITicTacToePlayer> competitors = new List<ITicTacToePlayer>();
        Dictionary<string, Tuple<int, int, int>> matchRecord = new Dictionary<string, Tuple<int, int, int>>();
        Dictionary<string, int> winRecord = new Dictionary<string, int>();

        public delegate void ReportMatch(Dictionary<string, Tuple<int, int, int>> d, Dictionary<string, int> w);
        public event ReportMatch MatchResult;

        public Tournament()
        {
            
        }

        public void Play(int numMatches)
        {
            int rounds = numMatches;

            foreach (ITicTacToePlayer p1 in competitors)
            {
                foreach (ITicTacToePlayer p2 in competitors)
                {
                    if (p1.Symbol() != p2.Symbol())
                    {
                        for (int i = 0; i < rounds; i++)
                        {
                            // Set up the game state with 2 players
                            GameState g = new GameState(p1, p2);
                            // Hook into the win event
                            g.WinnerIs += G_WinnerIs;
                            // Play the game
                            g.Play();
                            // Check for winner
                            if (winner == null)
                            {
                                // Tie
                                AddToTracker(p1.Name() + " vs. " + p2.Name(), new Tuple<int, int, int>(0, 0, 1));
                                
                            }
                            else if (winner.Symbol() == p1.Symbol())
                            {
                                AddToTracker(p1.Name() + " vs. " + p2.Name(), new Tuple<int, int, int>(1, 0, 0));
                                AddToRecord(p1.Name(), 1);
                            }
                            else if (winner.Symbol() == p2.Symbol())
                            {
                                AddToTracker(p1.Name() + " vs. " + p2.Name(), new Tuple<int, int, int>(0, 1, 0));
                                AddToRecord(p2.Name(), 1);
                            }
                            // Reset the winner to null
                            winner = null;
                        }
                    }
                }
            }

            MatchResult(matchRecord, winRecord);
        }

        public void AddToRecord(string item, int wins)
        {
            if (!winRecord.ContainsKey(item))
            {
                // First time adding player to dictionary
                winRecord[item] = wins;
            }
            else
            {
                int tmp = winRecord[item] + wins;
                winRecord[item] = tmp;
            }
        }

        public void AddToTracker(string item, Tuple<int, int, int> p1p2tie)
        {
            if (!matchRecord.ContainsKey(item))
            {
                // First time adding player to dictionary
                matchRecord[item] = p1p2tie;
            }
            else
            {
                Tuple<int, int, int> tmp = new Tuple<int, int, int>(
                    matchRecord[item].Item1 + p1p2tie.Item1,
                    matchRecord[item].Item2 + p1p2tie.Item2,
                    matchRecord[item].Item3 + p1p2tie.Item3
                    );

                matchRecord[item] = tmp;
            }
        }

        private void G_WinnerIs(ITicTacToePlayer p)
        {
            this.winner = p;
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
