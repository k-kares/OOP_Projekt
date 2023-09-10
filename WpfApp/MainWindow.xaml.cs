using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
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
using Utilities;
using Utilities.QuickType;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string PATH = "data.txt";
        private const string PATH_REP = "repdata.txt";
        private const char SEPERATOR = ' ';

        public string language = "hr";
        private string championship = "male";
        private bool screen = false;
        private ChoosingWindow cw;

        private string URL_matches = "";
        private string URL_country = "";
        private string URL_teams = "";
        private string URL_results = "";
        private string URL_groupResults = "";

        private string favouriteRep = "";
        private string favouriteRepCode = "";
        private string opponent = "";
        //private Repke[]? repData;
        private List<GameStats> gameStatistics = new List<GameStats>();
        private List<GameStats> kopija = new List<GameStats>();
        private List<Countries> allCountries = new List<Countries>();
        bool firstPass = true;

        public Countries countryStats { get; set; }

        public MainWindow()
        {
            FillLanguageAndChampionship();
            SetCulture();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillLanguageAndChampionship();
            SetCulture();
            SetURLs();

            LoadFavouriteRepDta();
            LoadDataForRepke();

            LoadDataForCountriesAsync();

            if (favouriteRep != "")
            {
                LoadDataForGameStats();
            }
            firstPass = false;
        }

        private async Task LoadDataForCountriesAsync()
        {
            try
            {
                RestResponse<Countries> restResponse = await JsonConversions.GetDataCountryResults(URL_results);
                allCountries = JsonConversions.DeserializeResponse(restResponse);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDataForOpponentTeam()
        {
            try
            {
                foreach (var item in gameStatistics)
                {
                    kopija.Add(item);
                    if (item.HomeTeamCountry == favouriteRep)
                    {
                        cbOpponents.Items.Add(item.AwayTeam.ToString());
                    }
                    else if (item.AwayTeamCountry == favouriteRep)
                    {
                        cbOpponents.Items.Add(item.HomeTeam.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void LoadDataForGameStats()
        {
            try
            {
                RestResponse<GameStats> restResponse = await JsonConversions.GetDataGameStats(URL_matches);
                gameStatistics = JsonConversions.DeserializeResponse(restResponse);
                LoadDataForOpponentTeam();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void LoadDataForRepke()
        {
            try
            {
                RestResponse<Repke> restResponse = await JsonConversions.GetDataRepke(URL_teams);
                Repke[]? repDatas = JsonConversions.DeserializeResponseList(restResponse);

                //repData = repDatas;
                foreach (var item in repDatas)
                {
                    cbFavRep.Items.Add(item.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void LoadFavouriteRepDta()
        {
            try
            {
                if (System.IO.File.Exists(PATH_REP))
                {
                    List<string> list = FileUtil.LoadFileData(PATH_REP);
                    if (list.Count > 2)
                    {
                        favouriteRep = $"{list[0]} {list[1]}";
                        favouriteRepCode = list[2];
                    }
                    else
                    {
                        favouriteRep = list[0];
                        favouriteRepCode = list[1];
                    }
                    cbFavRep.SelectedItem = $"{favouriteRep} {favouriteRepCode}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetURLs()
        {
            if (championship == "male")
            {
                URL_matches = "https://worldcup-vua.nullbit.hr/men/matches";
                URL_country = "https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code=";
                URL_teams = "https://worldcup-vua.nullbit.hr/men/teams";
                URL_results = "https://worldcup-vua.nullbit.hr/men/teams/results";
                URL_groupResults = "https://worldcup-vua.nullbit.hr/men/teams/group_results";
            }
            else
            {
                URL_matches = "https://worldcup-vua.nullbit.hr/women/matches";
                URL_country = "https://worldcup-vua.nullbit.hr/women/matches/country?fifa_code=";
                URL_teams = "https://worldcup-vua.nullbit.hr/women/teams";
                URL_results = "https://worldcup-vua.nullbit.hr/women/teams/results";
                URL_groupResults = "https://worldcup-vua.nullbit.hr/women/teams/group_results";
            }
        }

        private void SetCulture()
        {
            var culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            InitializeComponent();
        }

        private void FillLanguageAndChampionship()
        {
            if (File.Exists(PATH))
            {
                try
                {
                    List<string> list = FileUtil.LoadFileData(PATH);
                        championship = list[0];
                        language = list[1];
                        screen = bool.Parse(list[2]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {
                cw = new ChoosingWindow();
                cw.ShowDialog();
                try
                {
                    List<string> list = FileUtil.LoadFileData(PATH);
                    championship = list[0];
                    language = list[1];
                    screen = bool.Parse(list[2]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            if (screen == true)
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cbFavRep.SelectedIndex > -1)
            {
                favouriteRep = cbFavRep.SelectedItem.ToString();

                try
                {
                    FileUtil.SaveRepData(favouriteRep);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (MessageBox.Show("Are you sure to exit?", "Exit", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void cbOpponents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (favouriteRep == "" || cbOpponents.SelectedItem == null)
            {
                return;
            }
            do
            {
                for (int i = 0; i < gridPitch.Children.Count; i++)
                {
                    if (gridPitch.Children[i] is PlayerControl)
                    {
                        gridPitch.Children.Remove(gridPitch.Children[i]);
                    }
                }
            } while (gridPitch.Children.Count > 1);


            List<Player> favTeamStarters = new List<Player>();
            List<Player> opponentTeamStarters = new List<Player>();
            int favRepGoals;
            int opponentGoals;

            opponent = cbOpponents.SelectedItem.ToString();
            opponent = opponent.Substring(0, opponent.Length - 6);
            foreach (var item in kopija)
            {
                if (item.HomeTeamCountry == favouriteRep && item.AwayTeamCountry == opponent)
                {
                    favTeamStarters = item.HomeTeamStatistics.StartingEleven;
                    opponentTeamStarters = item.AwayTeamStatistics.StartingEleven;
                    lblScore.Content = $"{item.HomeTeam.Goals} : {item.AwayTeam.Goals}";
                }
                else if (item.AwayTeamCountry == favouriteRep && item.HomeTeamCountry == opponent)
                {
                    favTeamStarters = item.AwayTeamStatistics.StartingEleven;
                    opponentTeamStarters = item.HomeTeamStatistics.StartingEleven;
                    lblScore.Content = $"{item.AwayTeam.Goals} : {item.HomeTeam.Goals}";
                }
            }
            firstPass = false;
            GoalsAndCards(ref favTeamStarters);
            GoalsAndCards(ref opponentTeamStarters);
            FillGrid(favTeamStarters, opponentTeamStarters);
        }

        private void GoalsAndCards( ref List<Player> players)
        {
            foreach (var item in kopija)
            {
                if (item.HomeTeamCountry == favouriteRep && item.AwayTeamCountry == opponent)
                {
                    foreach (var itt in item.HomeTeamEvents)
                    {
                        if (itt.TypeOfEvent == TypeOfEvent.YellowCard)
                        {
                            foreach (var player in players)
                            {
                                if (itt.Player == player.Name)
                                {
                                    player.YellowCards++;
                                }
                            }
                        }
                        else if (itt.TypeOfEvent == TypeOfEvent.Goal)
                        {
                            foreach (var player in players)
                            {
                                if (itt.Player == player.Name)
                                {
                                    player.Goals++;
                                }
                            }
                        }
                    }
                }
                if (item.AwayTeamCountry == favouriteRep && item.AwayTeamCountry == opponent)
                {
                    foreach (var itt in item.AwayTeamEvents)
                    {
                        if (itt.TypeOfEvent == TypeOfEvent.YellowCard)
                        {
                            foreach (var player in players)
                            {
                                if (itt.Player == player.Name)
                                {
                                    player.YellowCards++;
                                }
                            }
                        }
                        else if (itt.TypeOfEvent == TypeOfEvent.Goal)
                        {
                            foreach (var player in players)
                            {
                                if (itt.Player == player.Name)
                                {
                                    player.Goals++;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void FillGrid(List<Player> favTeamStarters, List<Player> opponentTeamStarters)
        {
            int goalie = 2;
            int defenders = 0;
            int midfielders = 0;
            int forwards = 0;

            foreach (var item in favTeamStarters)
            {
                if (item.Position == Position.Goalie)
                {
                    MakePlayerControl(item, 0, ref goalie);
                }
                else if (item.Position == Position.Defender)
                {
                    MakePlayerControl(item, 1, ref defenders);
                }
                else if (item.Position == Position.Midfield)
                {
                    MakePlayerControl(item, 2, ref midfielders);
                }
                else {
                    MakePlayerControl(item, 3, ref forwards);
                }
            }

            goalie = 2;
            defenders = 0;
            midfielders = 0;
            forwards = 0;

            foreach (var item in opponentTeamStarters)
            {
                if (item.Position == Position.Goalie)
                {
                    MakePlayerControl(item, 8, ref goalie);
                }
                else if (item.Position == Position.Defender)
                {
                    MakePlayerControl(item, 7, ref defenders);
                }
                else if (item.Position == Position.Midfield)
                {
                    MakePlayerControl(item, 6, ref midfielders);
                }
                else
                {
                    MakePlayerControl(item, 5, ref forwards);
                }
            }
        }
        public void MakePlayerControl(Player p, int column, ref int row)
        {
            PlayerControl pc = new PlayerControl();
            pc.SetPlayer(p);
            Grid.SetColumn(pc, column);
            Grid.SetRow(pc, row++);
            gridPitch.Children.Add(pc);
        }
  
        private void btnFavTeamStats(object sender, RoutedEventArgs e)
        {
            if (favouriteRep == "")
            {
                return;
            }

            foreach (var item in allCountries) 
            {
                if (item.Country == favouriteRep)
                {
                    countryStats = item;
                    CountryView cv = new CountryView(this);
                    cv.Show();
                }
            }
        }

        private void btnOpponentTeamStats_Click(object sender, RoutedEventArgs e)
        {
            if (opponent == "")
            {
                return;
            }

            foreach (var item in allCountries)
            {
                if (item.Country == opponent)
                {
                    countryStats = item;
                    CountryView cv = new CountryView(this);
                    cv.Show();
                    
                }
            }
        }

        private void cbFavRep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (firstPass)
            {
                return;
            }
            string? tekst = cbFavRep.SelectedItem.ToString();
            favouriteRep = tekst.Substring(0, tekst.Length - 6);

            kopija.Clear();
            cbOpponents.Items.Clear();

            LoadDataForGameStats();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow sw = new SettingsWindow();
            sw.Show();
            firstPass = true;
            cbFavRep.Items.Clear();
            cbOpponents.Items.Clear();

            FillLanguageAndChampionship();
            SetCulture();
            SetURLs();

            LoadFavouriteRepDta();
            LoadDataForRepke();

            LoadDataForCountriesAsync();

            if (favouriteRep != "")
            {
                LoadDataForGameStats();
            }
            firstPass = false;
        }
    }
}
