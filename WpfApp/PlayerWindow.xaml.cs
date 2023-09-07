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
using System.Windows.Shapes;
using Utilities.QuickType;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        public PlayerWindow(Player player)
        {
            InitializeComponent();
            SetValues(player);
        }

        private void SetValues(Player player)
        {
            playerName.Text = $"{player.Name} {player.ShirtNumber}";
            lblPosition.Content = $"{player.Position}";
            lblCaptain.Content = $"{player.Captain}";
            lblGoals.Content = $"{player.Goals}";
            lblYellowCards.Content = $"{player.YellowCards}";
        }
    }
}
