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

namespace TicTacToeClassTournament
{
    /// <summary>
    /// Interaction logic for TicTacToePlayerControl.xaml
    /// </summary>
    public partial class TicTacToePlayerControl : UserControl
    {
        public string PlayerScore {
            get
            {
                return lblPlayerName.Content + ": " + lblWin.Content + " / " + lblTie.Content + " / " + lblLose.Content;
            }
        }

        public TicTacToePlayerControl(string playername, Tuple<int,int,int> score)
        {
            InitializeComponent();
            lblPlayerName.Content = playername;
            lblWin.Content = score.Item1;
            lblTie.Content = score.Item2;
            lblLose.Content = score.Item3;
        }
    }
}
