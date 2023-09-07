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
using Utilities;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for CountryView.xaml
    /// </summary>
    public partial class CountryView : Window
    {
        public MainWindow mainWindow;
        public Countries country { get; set; }
        public CountryView(MainWindow _mainWindow)
        {
            this.mainWindow = _mainWindow;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblCountryName.Content = this.mainWindow.countryStats.Country;
            lblCode.Content = this.mainWindow.countryStats.FifaCode;
            lblGoalsMade.Content = this.mainWindow.countryStats.GoalsFor;
            lblGoalsTaken.Content = this.mainWindow.countryStats.GoalsAgainst;
            lblDifference.Content = this.mainWindow.countryStats.GoalDifferential;
            lblGamesPlayed.Content = this.mainWindow.countryStats.GamesPlayed;
            lblWins.Content = this.mainWindow.countryStats.Wins;
            lblLosses.Content = this.mainWindow.countryStats.Losses;
            lblDraws.Content = this.mainWindow.countryStats.Draws;
        }

    }
}
