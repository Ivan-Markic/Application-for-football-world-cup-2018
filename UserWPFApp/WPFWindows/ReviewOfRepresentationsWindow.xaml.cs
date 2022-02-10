using Data_Layer.Model;
using Data_Layer.Repo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace UserWPFApp.WPFWindows
{
    /// <summary>
    /// Interaction logic for ReviewOfRepresentationsWindow.xaml
    /// </summary>
    public partial class ReviewOfRepresentationsWindow : Window
    {

        bool currentChampionship = PreferencesRepo.ReadChampionship();
        List<Match> matches;
        List<Team> teams = new List<Team>();
        List<Country> countries = new List<Country>();
        Dictionary<string , string> results = new Dictionary<string, string>();
        public ReviewOfRepresentationsWindow()
        {
            if (PreferencesRepo.ReadLanguage())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("hr");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr");
            }
            InitializeComponent();
            btnSettingsImageSource.Source = new BitmapImage(new Uri(PreferencesRepo.GetSolutionFileDir(@"\settings.png")));
        }
        private void SetUpComboBox()
        {
            FillHomeTeamComboBox();

            FillAwayTeamComboBox();
        }

        private void FillHomeTeamComboBox()
        {
            foreach (Match match in matches)
            {
                if (!teams.Contains(match.home_team))
                {
                    teams.Add(match.home_team);
                }

                else if (!teams.Contains(match.away_team))
                {
                    teams.Add(match.away_team);
                }
            }
            teams.Sort();

            teams.ForEach(c => cbHomeTeam.Items.Add(c.ToString()));

            string mainCountry = PreferencesRepo.ReadMainCountry();

            if (mainCountry == String.Empty)
            {
                cbHomeTeam.SelectedItem = cbHomeTeam.Items[0];
                mainCountry = cbHomeTeam.Items[0].ToString();
            }
            else
            {
                cbHomeTeam.SelectedItem = teams.First(c => c.Name == PreferencesRepo.ReadMainCountry()).ToString();
            }
        }

        private void FillAwayTeamComboBox()
        {
            results.Clear();
            cbAwayTeam.Items.Clear();

            string selectedCountry = cbHomeTeam.SelectedItem.ToString().Substring(0, cbHomeTeam.SelectedItem.ToString().IndexOf('('));

            FillResults(selectedCountry);
            

            cbAwayTeam.SelectedItem = cbAwayTeam.Items[0];

            lblInfo.Content = results.First((result) => cbAwayTeam.SelectedItem.ToString().Contains(result.Key)).Value;
        }

        private void FillResults(string selectedCountry)
        {
            foreach (Match match in matches)
            {
                if (match.homeTeamStatistics.Country == selectedCountry)
                {
                    SetDataResults(match.home_team, match.away_team);
                    
                }
                else if (match.awayTeamStatistics.Country == selectedCountry)
                {
                    SetDataResults(match.away_team, match.home_team);
                }
            }
            foreach (var teamResult in results)
            {
                
            }
        }

        private void SetDataResults(Team home_team, Team away_team)
        {
            
            if (results.ContainsKey(away_team.Name))
            {
                string scor = results.First(result => result.Key == away_team.Name).Value;
                results.Remove(away_team.Name);
                
                results.Add(away_team.Name, $" {scor} \n {home_team.Goals}:{away_team.Goals}");
            }
            else
            {
                results.Add(away_team.Name, $"{home_team.Goals}:{away_team.Goals}");
                cbAwayTeam.Items.Add(away_team);
            }
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                SetWindow();
                Task.Factory.StartNew(() => LoadData());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void LoadData()
        {
            IRepo repo = MakeCustomRepo("matches.json");

            matches = repo.GetMatches();

            cbHomeTeam.Dispatcher.Invoke(SetUpComboBox);

            repo = MakeCustomRepo("results.json");

            countries = repo.GetCountries();
        }

        private IRepo MakeCustomRepo(string NameOfRepoType)
        {
            if (PreferencesRepo.ReadChampionship())
            {
               return RepoFactory.GetRepo(PreferencesRepo.GetResourceFileDir(String.Concat(@"men\",NameOfRepoType)));
            }
            return RepoFactory.GetRepo(PreferencesRepo.GetResourceFileDir(String.Concat(@"women\", NameOfRepoType)));

        }

        private void cbHomeTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillAwayTeamComboBox();
        }

        private void cbAwayTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (results.Count!=0)
            {
                lblInfo.Content = results.First((result) => cbAwayTeam.SelectedItem.ToString().Contains(result.Key)).Value; 
            }
            
        }

        private void FillDetailsOfTheTeam(DetailsOfTheTeam detailsOfTheTeam, Button button)
        {
            if (button == btnHomeTeam)
            {
                FillDataOfTheTeams(detailsOfTheTeam, cbHomeTeam);
            }
            else
            {
                FillDataOfTheTeams(detailsOfTheTeam, cbAwayTeam);
            }
        }

        private void FillDataOfTheTeams(DetailsOfTheTeam detailsOfTheTeam, ComboBox cbTeam)
        {
            string countryName = cbTeam.SelectedItem.ToString();
            Country country = countries.Find(c => c.ToString() == countryName);

            detailsOfTheTeam.lblNameValue.Content = country.Name;
            detailsOfTheTeam.lblCodeValue.Content = country.Code;
            detailsOfTheTeam.lblWinsValue.Content = country.Wins;
            detailsOfTheTeam.lblDrawValue.Content = country.Draws;
            detailsOfTheTeam.lblDefeatValue.Content = country.Losses;
            detailsOfTheTeam.lblScoredValue.Content = country.GoalsFor;
            detailsOfTheTeam.lblReceivedValue.Content = country.GoalsAgainst;
            detailsOfTheTeam.lblDifferenceValue.Content = country.GoalDifferential;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string text = "Do you really want to exit the app?";
            string title = "Confirm exit";

            if (Thread.CurrentThread.CurrentCulture.ToString() == "hr")
            {
                text = "Želite li stvarno izaći iz aplikacije?";
                title = "Potvrda izlaska";
            }
            if (MessageBox.Show(this, text, title, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (currentChampionship == PreferencesRepo.ReadChampionship())
                {
                    if (PreferencesRepo.ReadMainCountry() != cbHomeTeam.SelectedItem.ToString().Substring(0, cbHomeTeam.SelectedItem.ToString().IndexOf('(')))
                    {
                        DeleteFiles();
                    }
                    PreferencesRepo.WriteData(PreferencesRepo.nameOfMainCountryFile, new string[] { cbHomeTeam.SelectedItem.ToString() }); 
                }
                else
                {
                    DeleteFiles();
                    PreferencesRepo.DeleteFile(PreferencesRepo.nameOfMainCountryFile);
                }
                return;
            }
            e.Cancel = true;
        }

        private static void DeleteFiles()
        {
            PreferencesRepo.DeleteFile(PreferencesRepo.nameOfMainPlayersFile);
            PreferencesRepo.DeleteFile(PreferencesRepo.nameOfPicturePlayerFile);
        }

        private void btnOpenField_Click(object sender, RoutedEventArgs e)
        {
            Match match = matches.Find(m => (cbHomeTeam.SelectedItem.ToString().Contains(m.home_team.Name) 
            && cbAwayTeam.SelectedItem.ToString().Contains(m.away_team.Name))
            || (cbHomeTeam.SelectedItem.ToString().Contains(m.away_team.Name)
            && cbAwayTeam.SelectedItem.ToString().Contains(m.home_team.Name)));

            ShowTerrainWindow terrainWindow = new ShowTerrainWindow(match);
            terrainWindow.ShowDialog();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            PreferencesWindow preferencesWindow = new PreferencesWindow();
            preferencesWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            preferencesWindow.ShowDialog();
            SetWindow();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            DetailsOfTheTeam detailsOfTheTeam = new DetailsOfTheTeam();
            FillDetailsOfTheTeam(detailsOfTheTeam, button);
            detailsOfTheTeam.ShowDialog();
        }
    }
}
