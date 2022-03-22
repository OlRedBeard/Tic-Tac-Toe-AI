using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// Add these
using System.Reflection;
using System.IO;
using TicTacToeBasePlayer;
using TicTacToe;

namespace TicTacToeClassTournament
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ITicTacToePlayer winner = null;
        List<ITicTacToePlayer> TicTacToePlayers = new List<ITicTacToePlayer>();
        Dictionary<string, Tuple<int, int, int>> track = new Dictionary<string, Tuple<int, int, int>>();

        public void TrackGames(ITicTacToePlayer p1, ITicTacToePlayer p2)
        {
            if (winner == null)
            {

            }
            else if (winner.Symbol() == p1.Symbol())
            {

            }
            else if (winner.Symbol() == p2.Symbol())
            {

            }
        }

        public void AddToTracker(string item, Tuple<int, int, int> winTieLose)
        {
            if (!track.ContainsKey(item))
            {
                // First time adding player to dictionary
                track[item] = winTieLose;
            }
            else
            {
                Tuple<int, int, int> tmp = new Tuple<int, int, int>(
                    track[item].Item1 + winTieLose.Item1,
                    track[item].Item2 + winTieLose.Item2,
                    track[item].Item3 + winTieLose.Item3
                    );

                track[item] = tmp;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            // Grab all dll files from the specified directory
            List<string> lstFiles = Directory.GetFiles(txtAssemblies.Text).Where(x => x.Contains(".dll")).ToList();
            // Iterate each dll file
            foreach(string f in lstFiles)
            {
                // Ignore the baseplayer dll
                if (f.Contains("TicTacToeBasePlayer.dll"))
                    continue;

                // Ignore if it not a dll file
                if (!f.Contains(".dll"))
                    continue;

                // Load the dll files into a class
                Assembly dll = Assembly.LoadFrom(f);
                // Get all types
                Type[] t = dll.GetTypes();
                // Instantiate the class, start it both as 1 and -1
                ITicTacToePlayer instanceX = (ITicTacToePlayer)Activator.CreateInstance(t[0], 1);
                ITicTacToePlayer instanceY = (ITicTacToePlayer)Activator.CreateInstance(t[0], -1);
                // Add both of those players to the list
                TicTacToePlayers.Add(instanceX);
                TicTacToePlayers.Add(instanceY);
                // Add the AssemblyInfo custom class (the one we created)
                AssemblyInfo i1 = new AssemblyInfo(instanceX, this);
                AssemblyInfo i2 = new AssemblyInfo(instanceY, this);
                // Add them to the form so they appear
                this.playerControls.Children.Add(i1);
                this.playerControls.Children.Add(i2);
            }
        }

        private void btnTournament_Click(object sender, RoutedEventArgs e)
        {
            int numGames = int.Parse(txtGames.Text);

            foreach(ITicTacToePlayer p1 in TicTacToePlayers)
            {
                foreach(ITicTacToePlayer p2 in TicTacToePlayers)
                {
                    if(p1.Symbol() != p2.Symbol())
                    {
                        for (int i = 0; i < numGames; i++)
                        {
                            // Set up the game state with 2 players
                            GameState g = new GameState(p1, p2);
                            // Hook into the win event
                            g.WinnerIs += G_WinnerIs;
                            // Play the game
                            g.Play();
                            // Check for winner
                            if(winner == null)
                            {
                                // Tie
                                AddToTracker(p1.Name(), new Tuple<int, int, int>(0, 1, 0));
                                AddToTracker(p2.Name(), new Tuple<int, int, int>(0, 1, 0));
                            }
                            else if (winner.Symbol() == p1.Symbol())
                            {
                                AddToTracker(p1.Name(), new Tuple<int, int, int>(1, 0, 0));
                                AddToTracker(p2.Name(), new Tuple<int, int, int>(0, 0, 1));
                            }
                            else if (winner.Symbol() == p2.Symbol())
                            {
                                AddToTracker(p1.Name(), new Tuple<int, int, int>(0, 0, 1));
                                AddToTracker(p2.Name(), new Tuple<int, int, int>(1, 0, 0));
                            }
                            // Reset the winner to null
                            winner = null;
                        }
                    }
                }
            }

            lstResults.Items.Clear();
            foreach(KeyValuePair<string, Tuple<int,int,int>> kvp in track)
            {
                TicTacToePlayerControl ctrl = new TicTacToePlayerControl(kvp.Key, kvp.Value);
                lstResults.Items.Add(ctrl.PlayerScore);
            }
        }

        private void G_WinnerIs(ITicTacToePlayer p)
        {
            this.winner = p;
        }
    }
}
