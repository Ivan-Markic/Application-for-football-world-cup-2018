using Data_Layer.Model;
using Data_Layer.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using UserWPFApp.WPFUsers;

namespace UserWPFApp.WPFWindows
{
    /// <summary>
    /// Interaction logic for ShowTerrainWindow.xaml
    /// </summary>
    public partial class ShowTerrainWindow : Window
    {
        Match match;
        Dictionary<ShowPlayerControl, Player> showPlayerControls = new Dictionary<ShowPlayerControl, Player>();
        public ShowTerrainWindow(Match matche)
        {
            InitializeComponent();
            backgroundImage.ImageSource = new BitmapImage(new Uri(PreferencesRepo.GetSolutionFileDir(@"\Soccer_field.png")));
            match = matche;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetWindow();
            LoadData();
        }

        private void SetWindow()
        {
            int[] resolution = PreferencesRepo.ReadResolution();
            Width = resolution[0];
            Height = resolution[1];

            Left = (SystemParameters.PrimaryScreenWidth - resolution[0]) / 2;
            Top = (SystemParameters.PrimaryScreenHeight - resolution[1]) / 2;

            if (Left < 0 && Top < 0)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
            if (Top < 0)
            {
                Top = 0;
            }
        }

        private void LoadData()
        {
            SetPlayers();
        }

        private void SetPlayers()
        {
            FillTeam(match.homeTeamStatistics.StartingEleven);
            FillTeam(match.awayTeamStatistics.StartingEleven);
        }

        private void FillTeam(List<Player> startingEleven)
        {

            #region Variables
            int defenderRow = 1;
            int midfieldRow = 1;
            int forwardRow = 1;

            int goalieColumn = showPlayerControls.Count == 0 ? 0 : 7;
            int defenderColumn = showPlayerControls.Count == 0 ? 1 : 6;
            int midfieldColumn = showPlayerControls.Count == 0 ? 2 : 5;
            int forwardColumn = showPlayerControls.Count == 0 ? 3 : 4; 
            #endregion

            foreach (Player player in startingEleven)
            {
                try
                {
                    foreach (string playerImage in PreferencesRepo.ReadPictureData())
                    {
                        if (playerImage.Contains(player.ToString().ToLower()))
                        {
                            MessageBox.Show("Sadrzi");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ShowPlayerControl showPlayer = new ShowPlayerControl
                {
                    Width = 80,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                showPlayer.MouseDoubleClick += ShowPlayer_MouseDoubleClick;
                showPlayer.tbName.Text = player.Name.Substring(0, player.Name.IndexOf(" ")).ToLower();
                showPlayer.tbSurname.Text = player.Name.Substring(player.Name.IndexOf(" ")).ToLower();
                showPlayer.tbNumber.Text = player.ShirtNumber.ToString();

                if (PreferencesRepo.ReadPictureData().Length > 0 && PreferencesRepo.ReadPictureData()[startingEleven.IndexOf(player)].Contains(string.Concat(player.ToString().Where(c => !Char.IsWhiteSpace(c))).ToLower()))
                {
                    string pathOfPicture = PreferencesRepo.ReadPictureData()[startingEleven.IndexOf(player)];

                    BitmapImage bitmapImage = new BitmapImage(new Uri(pathOfPicture.Substring(pathOfPicture.IndexOf(" "))));

                    showPlayer.imgPicture.Source = bitmapImage;
                }

                showPlayerControls.Add(showPlayer, player);

                switch (player.Position)
                {
                    case "Goalie":
                        Grid.SetColumn(showPlayer, goalieColumn);
                        Grid.SetRow(showPlayer, 1);
                        Grid.SetRowSpan(showPlayer, 2);

                        break;

                    case "Defender":
                        Grid.SetColumn(showPlayer, defenderColumn);
                        Grid.SetRow(showPlayer, defenderRow);

                        defenderRow = defenderRow == 1 ? 2 : (defenderRow == 2 ? 3 : (defenderRow == 3 ? 0 : 1)) ;
                        if (defenderRow == 1 && defenderColumn < 5)
                        {
                            defenderColumn++;
                            defenderRow = 0;
                        }
                        else if (defenderRow == 1)
                        {
                            defenderColumn--;
                            defenderRow = 0;
                        }
                        break;

                    case "Midfield":
                        Grid.SetColumn(showPlayer, midfieldColumn);
                        Grid.SetRow(showPlayer, midfieldRow);

                        midfieldRow = midfieldRow == 1 ? 2 : (midfieldRow == 2 ? 3 : (defenderRow == 3 ? 0 : 1));
                        if (midfieldRow == 1 && midfieldColumn < 5)
                        {
                            midfieldColumn++;
                            midfieldRow = 0;
                        }
                        else if (midfieldRow == 1)
                        {
                            midfieldColumn--;
                            midfieldRow = 0;
                        }
                        break;

                    case "Forward":
                        Grid.SetColumn(showPlayer, forwardColumn);
                        Grid.SetRow(showPlayer, forwardRow);

                        forwardRow = forwardRow == 1 ? 2 : (forwardRow == 2 ? 3 : 0);
                        break;

                    default:
                        MessageBox.Show("There is bug in reading player position");
                        Close();
                        break;
                }
                grid.Children.Add(showPlayer);
            }
        }

        private void ShowPlayer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {


            ShowPlayerControl showPlayer = sender as ShowPlayerControl;
            ShowPlayerControl key =  showPlayerControls.Keys.First(control => control == showPlayer);

            Player player = showPlayerControls[key];

            ImageSource imageSource = key.imgPicture.Source;

            List<TeamEvent> teamEvents = new List<TeamEvent>();

            if (match.homeTeamStatistics.StartingEleven.Contains(player))
            {
                teamEvents = match.homeTeamEvent;
            }
            else
            {
                teamEvents = match.awayTeamEvent;
            }

            int goals = 0;
            int yellow_cards = 0;

            foreach (TeamEvent teamEvent in teamEvents)
            {
                if (teamEvent.Player.ToLower() == player.Name.ToLower())
                {
                    if (teamEvent.TypeOfEvent.Contains("goal"))
                    {
                        goals++;
                    }

                    else if (teamEvent.TypeOfEvent == "yellow-card")
                    {
                        yellow_cards++;
                    }
                }
            }

            setStatisticsWindow(player, goals, yellow_cards, imageSource);
        }

        private void setStatisticsWindow(Player player, int goals, int yellow_cards, ImageSource imageSource)
        {
            PlayerStatisticsWindow statisticsWindow = new PlayerStatisticsWindow
            {
                Title = $"{player.Name.ToLower()}"
            };

            

            statisticsWindow.tbNameValue.Text = player.Name.ToLower();
            statisticsWindow.tbNumberValue.Text = player.ShirtNumber.ToString();
            statisticsWindow.tbPositionValue.Text = player.Position;
            statisticsWindow.tbGoalsValue.Text = goals.ToString();
            statisticsWindow.tbYellowCardsValue.Text = yellow_cards.ToString();

            statisticsWindow.imgPicture.Source = imageSource;

            if (player.Captain)
            {
                statisticsWindow.imgLeftStar.Visibility = Visibility.Visible;
                statisticsWindow.imgRightStar.Visibility = Visibility.Visible;
            }

            statisticsWindow.ShowDialog();

        }
    }
}
