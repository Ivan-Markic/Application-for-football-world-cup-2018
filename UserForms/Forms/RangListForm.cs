using Data_Layer.Model;
using Data_Layer.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserForms.Events;
using UserForms.UserControls;

namespace UserForms.Forms
{
    public partial class RangListForm : Form
    {
        private int IsFirstTime = 0;
        private readonly string[] PicturePlayer = PreferencesRepo.ReadPictureData();
        IDictionary<string, string> PlayerPicture = new Dictionary<string, string>();
        private delegate void DelegateForPlayers(Player player, int goals, int yellow_cards);
        private delegate void DelegateForMatches(string location, int attendance, string homeTeam, string awayTeam);

        public RangListForm()
        {
            FormEventManager.setCulture(this);
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            btnSettings.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void RangListForm_Resize(object sender, EventArgs e)
        {
            SetSizeOfDataGridView(Width, Height);
        }

        private void RangListForm_Load(object sender, EventArgs e)
        {
            SetSizeOfDataGridView(Width, Height);
            Task.Factory.StartNew(LoadData);
            string path = PreferencesRepo.GetSolutionFileDir("settings.png");
            btnSettings.BackgroundImage = new Bitmap(PreferencesRepo.GetSolutionFileDir(@"\settings.png"));
            lblData.Text = "Vaši podatci se učitavaju, molimo vas pričekajte";
        }

        private void LoadData()
        {

            IRepo repo;
            if (PreferencesRepo.ReadChampionship())
            {
                repo = RepoFactory.GetRepo("men/matches.json");
            }
            else
            {
                repo = RepoFactory.GetRepo("women/matches.json");
            }
            progressBar.Value = 33;
            lblPercentage.Text = $"{progressBar.Value}%";
            lblPercentage2.Text = $"{progressBar.Value}%";
            List<Match> matches = repo.GetSpecificMatches();

            List<Player> players = repo.GetPlayers(matches);
            
            progressBar.Value = 66;
            lblPercentage.Text = $"{progressBar.Value}%";
            lblPercentage2.Text = $"{progressBar.Value}%";

            int yellow_cards = 0;
            int goals = 0;
            bool firstCircle = true;

            foreach (Player player in players)
            {
                foreach (Match match in matches)
                {
                    List<TeamEvent> teamEvents = match.awayTeamStatistics.Country == PreferencesRepo.ReadMainCountry() ? match.awayTeamEvent : match.homeTeamEvent;
                    foreach (TeamEvent teamEvent in teamEvents)
                    {
                        if (teamEvent.Player.ToLower() == player.Name.ToLower())
                        {
                            if (teamEvent.TypeOfEvent == "goal")
                            {
                                goals++;
                            }

                            else if (teamEvent.TypeOfEvent == "yellow-card")
                            {
                                yellow_cards++;
                            }
                        }
                    }

                    if (firstCircle)
                    {
                        dgvMatches.Invoke(new DelegateForMatches(FillMathces), match.Location, match.Attendance, match.homeTeamStatistics.Country, match.awayTeamStatistics.Country);

                    }
                }

                firstCircle = false;
                dgvPlayers.Invoke(new DelegateForPlayers(FillPlayers), player, goals, yellow_cards);
                yellow_cards = 0;
                goals = 0;
            }
            progressBar.Value = progressBar.Maximum;
            lblPercentage.Text = $"{progressBar.Value}%";
            lblPercentage2.Text = $"{progressBar.Value}%";
            string text = "Now you can watch your players :)";
            if (PreferencesRepo.ReadLanguage())
            {
                text = "Sada možeš gledati svoje igrače :)";
            }
            lblData.Text = text;
        }

        private void FillMathces(string location, int attendance, string homeTeam, string awayTeam)
        {
            dgvMatches.Rows.Add(location, attendance, homeTeam, awayTeam);
        }

        private void FillPlayers(Player player, int goals, int yellow_cards)
        {
            var playerControl = new ShowPlayerControl();
            playerControl.lblData.Text = player.Name;
            player.Name = string.Concat(player.Name.Where(c => !Char.IsWhiteSpace(c)));
            Image imageToSet = new Bitmap(80, 32);

            foreach (var playerPicture in PicturePlayer)
            {
                if (playerPicture.Contains(player.Name.ToLower()))
                {
                    try
                    {
                        imageToSet = new Bitmap(playerPicture.Substring(playerPicture.IndexOf(" ")));
                        imageToSet = new Bitmap(imageToSet, 80, 32);
                        if (!PlayerPicture.ContainsKey(player.ToString().ToLower()))
                        {
                            PlayerPicture.Add(player.ToString().ToLower(), playerPicture.Substring(playerPicture.IndexOf(" ")));
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        imageToSet = new Bitmap(playerControl.pbPlayer.Image, 80, 32);
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            
            if (!PlayerPicture.ContainsKey(player.ToString().ToLower()))
            {
                imageToSet = new Bitmap(playerControl.pbPlayer.Image, 80, 32);
                PlayerPicture.Add(player.ToString().ToLower(), PreferencesRepo.GetSolutionFileDir(@"\BasicPicture.png"));
            }
            
            dgvPlayers.Rows.Add(imageToSet, playerControl.lblData.Text.ToLower(), goals, yellow_cards);

            if (dgvPlayers.Rows.Count == 23)
            {
                btnPrint.Visible = true;
                btnPreview.Visible = true;
            }
        }

        private void SetSizeOfDataGridView(int width, int height)
        {

            dgvPlayers.Size = new Size(width / 2 - 5, height - 39);
            dgvMatches.Location = new Point(width / 2, dgvMatches.Location.Y);
            dgvMatches.Size = new Size(width / 2 - 15, height / 2);

            SetLocationOfButton();

            SizeOfColumns(dgvPlayers);
            SizeOfColumns(dgvMatches);
        }

        private void SetLocationOfButton()
        {
            //btnPreviewButton
            int x = dgvMatches.Location.X;
            int y = dgvMatches.Size.Height;
            btnPreview.Location = new Point(x, y);

            //btnPrint
            x += (btnPreview.Size.Width + 20);
            btnPrint.Location = new Point(x, y);

            //btnSettings
            x -= (btnSettings.Size.Width / 2 + 20);
            y += 50;
            btnSettings.Location = new Point(x, y);

            //ProgressBar
            x -= (btnSettings.Size.Width / 2 + 20);
            y += 50;
            progressBar.Location = new Point(x, y);

            //lblData
            y += 50;
            lblData.Location = new Point(x, y);

            //lblPercentage
            x = (btnSettings.Location.X - 60);
            y -= 100;
            lblPercentage.Location = new Point(x, y);

            //lblPercentage2
            x = (btnSettings.Location.X + 130);
            lblPercentage2.Location = new Point(x, y);


        }

        private void SizeOfColumns(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.Width = (int)(dataGridView.Width * 0.25);
                if (IsFirstTime < 2)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
            }
            IsFirstTime++;
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGrid = sender as DataGridView;
            dataGrid.ClearSelection();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocument.Print();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            SetSizeOfDataGridView(1552, 840);
            Bitmap bm = new Bitmap(dgvPlayers.Width, dgvPlayers.Height);
            dgvPlayers.DrawToBitmap(bm, new Rectangle(0, 0, dgvPlayers.Width, dgvPlayers.Height));
            e.Graphics.DrawImage(bm, 0, 0);

            Bitmap bmMatch = new Bitmap(dgvMatches.Width, dgvMatches.Height);
            dgvMatches.DrawToBitmap(bmMatch, new Rectangle(0, 0, dgvMatches.Width, dgvPlayers.Height));
            e.Graphics.DrawImage(bmMatch, 0, dgvPlayers.Height + 30);

            SetSizeOfDataGridView(Width, Height);

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            PreferencesForm settings = new PreferencesForm
            {
                Text = "Settings"
            };
            settings.ShowDialog();
        }


        private void RangListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (new ConfirmForm().ShowDialog() != DialogResult.OK)
            {
                e.Cancel = true;
            }
            PreferencesRepo.SavePictures(PlayerPicture);
        }

        private void dgvPlayers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    OpenFileDialog fileDialog = new OpenFileDialog
                    {
                        Filter = "Pictures|*.jpeg;*.jpg;*.png;|All files|*.*",
                        Title = "Load picture...",
                        InitialDirectory = Application.StartupPath
                    };

                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string picturePath = fileDialog.FileName;
                        Bitmap bitmap = new Bitmap(picturePath);
                        bitmap = new Bitmap(bitmap, 80, 32);
                        dgvPlayers[e.ColumnIndex, e.RowIndex].Value = bitmap;
                        string nameOfPlayer = string.Concat(dgvPlayers[e.ColumnIndex + 1, e.RowIndex].Value.ToString().ToLower().Where(c => !Char.IsWhiteSpace(c)));
                        
                        string key = PlayerPicture.First((kv) => kv.Key.Contains(nameOfPlayer)).Key;

                        if (PlayerPicture.ContainsKey(key))
                        {

                            PlayerPicture[key] = picturePath;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
