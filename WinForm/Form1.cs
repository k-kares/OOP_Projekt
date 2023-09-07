using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Runtime;
using System.Windows.Forms;
using System.Xml.Linq;
using Utilities;
using Utilities.QuickType;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace WinForm
{
    public partial class Form1 : Form
    {
        private const string PATH = "data.txt";
        private const string PATH_REP = "repdata.txt";
        private const string PATH_PLAYERS = "playerdata.txt";
        private const char SEPERATOR = ' ';

        private ChoosingForm cf = new ChoosingForm();
        private Postavke postavke = new Postavke();
        private string language = "hr";
        private string championship = "male";

        private string URL_matches = "";
        private string URL_country = "";
        private string URL_teams = "";
        private string URL_results = "";
        private string URL_groupResults = "";

        private string favouriteRep = "";
        private string repCode = "";
        private Repke[]? repData;
        private List<GameStats> gameStatistics;
        private List<GameStats> SortedGames = new List<GameStats>();

        private HashSet<Player> players = new HashSet<Player>();
        private Control? controlStartedDnD;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillLanguageAndChampionship();

            SetCulture();
            SetURLs();
            //LoadFavouriteRepDta();

            LoadFavouritePlayers();
            LoadFavouriteRepDta();
            LoadDataForRepke();

            if (System.IO.File.Exists(PATH_REP))
            {
                URL_country += $"{repCode}";
                LoadDataForGameStats();
            }

        }

        private void LoadDataForRankListGames()
        {
            foreach (var item in gameStatistics)
            {
                if (item.HomeTeamCountry == favouriteRep || item.AwayTeamCountry == favouriteRep)
                {
                    SortedGames.Add(item);
                }
            }
            SortedGames = SortedGames.OrderByDescending(o => o.Attendance).ToList();
            foreach (var item in SortedGames)
            {
                lbRankGames.Items.Add(item.ToString());
            }
        }

        private void LoadFavouritePlayers()
        {
            try
            {
                if (System.IO.File.Exists(PATH_PLAYERS))
                {
                    List<string> list = FileUtil.LoadFileData(PATH_PLAYERS);

                    if (list.Count > 0)
                    {
                        playerControl1.SetName($"{list[0]} {list[1]}");
                        playerControl1.SetNumber(long.Parse(list[2]));
                        Position myEnum = (Position)Enum.Parse(typeof(Position), list[3]);
                        playerControl1.SetPosition(myEnum);
                        playerControl1.Setcaptain(bool.Parse(list[4]));
                        playerControl1.SetFavourite();
                    }
                    if (list.Count > 6)
                    {
                        playerControl2.SetName($"{list[5]} {list[6]}");
                        playerControl2.SetNumber(long.Parse(list[7]));
                        Position myEnum = (Position)Enum.Parse(typeof(Position), list[8]);
                        playerControl2.SetPosition(myEnum);
                        playerControl2.Setcaptain(bool.Parse(list[9]));
                        playerControl2.SetFavourite();
                    }
                    if (list.Count > 11)
                    {
                        playerControl3.SetName($"{list[10]} {list[11]}");
                        playerControl3.SetNumber(long.Parse(list[12]));
                        Position myEnum = (Position)Enum.Parse(typeof(Position), list[13]);
                        playerControl3.SetPosition(myEnum);
                        playerControl3.Setcaptain(bool.Parse(list[14]));
                        playerControl3.SetFavourite();
                    }
                    favouriteRep = list[0];
                    repCode = list[1];
                    repCode = repCode.Substring(1, repCode.Length - 2);
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
                LoadDataForRankListGames();
                SplitPlayerData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SplitPlayerData()
        {
            foreach (var item in gameStatistics)
            {
                if (item.AwayTeamStatistics.Country == favouriteRep)
                {
                    foreach (var itt in item.AwayTeamStatistics.Substitutes)
                    {
                        players.Add(itt);
                    }
                    foreach (var itt in item.AwayTeamStatistics.StartingEleven)
                    {
                        players.Add(itt);

                    }

                }
                if (item.HomeTeamStatistics.Country == favouriteRep)
                {
                    foreach (var itt in item.HomeTeamStatistics.Substitutes)
                    {
                        players.Add(itt);
                    }
                    foreach (var itt in item.HomeTeamStatistics.StartingEleven)
                    {
                        players.Add(itt);
                    }

                }

            }

            foreach (var item in players)
            {
                MakeUserPlayer(item);
            }
            LoadDataForRankLists();
        }

        private void LoadDataForRankLists()
        {
            foreach (var item in SortedGames)
            {
                if (item.HomeTeamCountry == favouriteRep)
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
                if (item.AwayTeamCountry == favouriteRep)
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
            players = players.OrderByDescending(o => o.YellowCards).ToHashSet();
            foreach (var player in players)
            {
                lbRankCards.Items.Add(player.ToString());
            }

            players = players.OrderByDescending(o => o.Goals).ToHashSet();
            foreach (var player in players)
            {
                lbRankGoals.Items.Add($"{player.Name}, {player.Goals}");
            }
        }

        private void MakeUserPlayer(Player itt)
        {
            PlayerControl p = new PlayerControl();
            p.SetName(itt.Name);
            p.SetNumber(itt.ShirtNumber);
            p.Setcaptain(itt.Captain);
            p.SetPosition(itt.Position);
            p.ContextMenuStrip = contextMenuStripAdd;

            p.MouseDown += AddedUC_MouseDown;
            p.DragEnter += AddedUC_DragEnter;
            p.DragDrop += AddedUC_DragDrop;
            p.AllowDrop = true;

            flpAllPlayers.Controls.Add(p);


        }

        private void AddedUC_DragDrop(object? sender, DragEventArgs e)
        {
            var us = (PlayerControl)e.Data.GetData(typeof(PlayerControl));
            us.SetValuesDefault();
        }

        private void AddedUC_DragEnter(object? sender, DragEventArgs e)
        {
            PlayerControl? userControl = sender as PlayerControl;

            if (userControl is null || userControl == controlStartedDnD)
            {
                return;
            }

            e.Effect = DragDropEffects.Move;
        }

        private void AddedUC_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            StartDnDForAllPlayers(sender as PlayerControl);
        }

        private void StartDnDForAllPlayers(PlayerControl? playerControl)
        {
            if (playerControl is null)
            {
                return;
            }
            controlStartedDnD = playerControl;
            playerControl.DoDragDrop(playerControl, DragDropEffects.Move);
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
                        repCode = list[2];
                        repCode = repCode.Substring(1, repCode.Length - 2);
                    }
                    else
                    {
                        favouriteRep = list[0];
                        repCode = list[1];
                        repCode = repCode.Substring(1, repCode.Length - 2);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void LoadDataForRepke()
        {
            //JsonConversions.GetDataRepke(URL_teams);

            try
            {
                RestResponse<Repke> restResponse = await JsonConversions.GetDataRepke(URL_teams);
                Repke[]? repDatas = JsonConversions.DeserializeResponseList(restResponse);

                repData = repDatas;
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

            this.Controls.Clear();
            InitializeComponent();
        }

        private void FillLanguageAndChampionship()
        {
            bool fileExists = true;
            try
            {
                List<string> list = FileUtil.LoadFileData(PATH);
                if (list.Count == 0) { fileExists = false; }
                else
                {
                    championship = list[0];
                    language = list[1];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            if (!fileExists)
            {
                if (cf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    language = cf.ReturnLang();
                    championship = cf.ReturnChamp();
                }
            }

            try
            {
                FileUtil.SaveData(championship, language);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSetRep_Click(object sender, EventArgs e)
        {
            if (cbFavRep.SelectedItem is null)
            {
                return;
            }
            string line = cbFavRep.SelectedItem.ToString();

            try
            {
                FileUtil.SaveRepData(line);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string[] details = line.Split(SEPERATOR);
            if (details.Count() > 2)
            {
                favouriteRep = $"{details[0]} {details[1]}";
                repCode = details[2];
                repCode = repCode.Substring(1, repCode.Length - 2);
            }
            else
            {
                favouriteRep = details[0];
                repCode = details[1];
                repCode = repCode.Substring(1, repCode.Length - 2);
            }

            flpAllPlayers.Controls.Clear();

            try
            {
                LoadDataForGameStats();
                System.Windows.Forms.Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PlayerControl1_DragDrop(object sender, DragEventArgs e)
        {
            PlayerControl? playerControl = sender as PlayerControl;
            if (playerControl is null) { return; }

            PlayerControl? ucData = e.Data.GetData(typeof(PlayerControl)) as PlayerControl;
            if (ucData is null) { return; }

            string pc1name = playerControl1.lblPlayerName.Text;
            string pc2name = playerControl2.lblPlayerName.Text;
            string pc3name = playerControl3.lblPlayerName.Text;

            if (pc1name.Substring(5) == ucData.FullName || pc2name.Substring(5) == ucData.FullName || pc3name.Substring(5) == ucData.FullName)
            {
                return;
            }

            playerControl.SetValuesDefault();
            playerControl.SetName(ucData.FullName);
            playerControl.lblNumber.Text = ucData.lblNumber.Text;
            playerControl.lblCaptain.Text = ucData.lblCaptain.Text;
            playerControl.SetFavourite();
            playerControl.lblPosition.Text = ucData.lblPosition.Text;
        }

        private void PlayerControl1_DragEnter(object sender, DragEventArgs e)
        {
            PlayerControl playerControl = sender as PlayerControl;
            if (playerControl == controlStartedDnD)
            {
                return;
            }
            e.Effect |= DragDropEffects.Move;
        }

        private void StartRemoveDnD(PlayerControl? playerControl)
        {
            if (playerControl is null)
            {
                return;
            }
            controlStartedDnD = playerControl;
            playerControl.DoDragDrop(playerControl, DragDropEffects.Move);
        }

        private void PlayerControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            StartRemoveDnD(sender as PlayerControl);
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem? playerControl = sender as ToolStripItem;
            PlayerControl sourceControl = (PlayerControl)((ContextMenuStrip)(((ToolStripMenuItem)sender).Owner)).SourceControl;
            if (playerControl is null)
            {
                return;
            }

            string pc1name = playerControl1.lblPlayerName.Text;
            string pc2name = playerControl2.lblPlayerName.Text;
            string pc3name = playerControl3.lblPlayerName.Text;

            if (pc1name.Substring(5) == sourceControl.FullName || pc2name.Substring(5) == sourceControl.FullName || pc3name.Substring(5) == sourceControl.FullName)
            {
                return;
            }

            if (pc1name.Length < 10)
            {
                playerControl1.CopyPlayerControl(sourceControl);
            }
            else if (pc2name.Length < 10)
            {
                playerControl2.CopyPlayerControl(sourceControl);
            }
            else if (pc3name.Length < 10)
            {
                playerControl3.CopyPlayerControl(sourceControl);
            }
            else { return; }
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem? toolStripItem = sender as ToolStripItem;
            PlayerControl sourceControl = (PlayerControl)((ContextMenuStrip)(((ToolStripMenuItem)sender).Owner)).SourceControl;

            if (toolStripItem == null) { return; }
            sourceControl.pictureBox1.Image = System.Drawing.Image.FromFile(@".\DefaultPlayerPic.jpg");
            sourceControl.SetValuesDefault();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (playerControl1.FullName == "" && playerControl2.FullName == "" && playerControl3.FullName == "")
            {
                return;
            }

            try
            {
                FileUtil.SavePlayerData(playerControl1.FullName, playerControl1.Number, playerControl1.positition, playerControl1.captain,
                        playerControl2.FullName, playerControl2.Number, playerControl2.positition, playerControl2.captain,
                        playerControl3.FullName, playerControl3.Number, playerControl3.positition, playerControl3.captain);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void AddImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripItem? toolStripItem = sender as ToolStripItem;
            PlayerControl sourceControl = (PlayerControl)((ContextMenuStrip)(((ToolStripMenuItem)sender).Owner)).SourceControl;
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Images|*.bmp;*.png;*.jpg"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sourceControl.pictureBox1.ImageLocation = openFileDialog.FileName;
            }
        }

        private void AddImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem? toolStripItem = sender as ToolStripItem;
            PlayerControl sourceControl = (PlayerControl)((ContextMenuStrip)(((ToolStripMenuItem)sender).Owner)).SourceControl;
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Images|*.bmp;*.png;*.jpg"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sourceControl.pictureBox1.ImageLocation = openFileDialog.FileName;
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            if (postavke.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                language = postavke.ReturnLang();
                championship = postavke.ReturnChamp();

                try
                {
                    FileUtil.SaveData(championship, language);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                System.Windows.Forms.Application.Restart();
                //Environment.Exit(0);
            }
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ListBox lball = new ListBox();

            lball.Items.Add($"Goals: ");
            foreach (var item in lbRankGoals.Items)
            {
                lball.Items.Add(item);
            }

            lball.Items.Add("");
            lball.Items.Add("Cards: ");
            foreach (var item in lbRankCards.Items)
            {
                lball.Items.Add(item);
            }

            lball.Items.Add("");
            lball.Items.Add("Games:");
            foreach (var item in lbRankGames.Items)
            {
                lball.Items.Add(item);
            }
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            int leading = 5;
            int leftMargin = 25;
            int topMargin = 4;


            using (Font font = new Font("Arial Narrow", 12f))
            {
                SizeF sz = e.Graphics.MeasureString("_|", Font);
                float h = sz.Height + leading;

                for (int i = 0; i < lball.Items.Count; i++)
                    e.Graphics.DrawString(lball.Items[i].ToString(), font, Brushes.Black,
                                          leftMargin, topMargin * i);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }
    }
}