using Data_Layer.Model;
using Data_Layer.Repo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserForms.Events;
using UserForms.UserControls;

namespace UserForms.Forms
{
    public partial class FavouritePlayersForm : Form
    {

        IList<Player> players = new List<Player>();
        IDictionary<string, string> PlayerPicture = new Dictionary<string, string>();

        IList<ShowPlayerControl> playersToMove = new List<ShowPlayerControl>();

        private delegate void Delegate();

        public FavouritePlayersForm()
        {
            FormEventManager.setCulture(this);
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        

        private void FavouritePlayersForm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => LoadData());

            if (PreferencesRepo.ReadLanguage())
            {
                lblLoadingText.Text = "Tvoji igrači se učitavaju";
            }
        }

        private void FillPlayers()
        {

            foreach (Player player in players)
            {
                ShowPlayerControl playerControl = new ShowPlayerControl();
                playerControl.MIMovePlayer.Click += MIMovePlayer_Click;
                playerControl.pbPlayer.DoubleClick += PbPlayer_DoubleClick;
                playerControl.BackColor = Color.Red;
                playerControl.MouseDown += dragStart;
                playerControl.lblData.Text = $"{player.Name.ToLower()} {player.ShirtNumber} {player.Position.ToLower()}";

                progressBar.Value++;

                tlpOtherPlayers.Controls.Add(playerControl);

            }
            progressBar.Value = progressBar.Maximum;
            string text = "Done :)";
            if (PreferencesRepo.ReadLanguage())
            {
                text = "Gotov :)";
            }
            lblLoadingText.Text = text;
        }

        private void MIMovePlayer_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            var contextMenuStrip = (ContextMenuStrip)menuItem.Owner;
            ShowPlayerControl playerControl = (ShowPlayerControl)contextMenuStrip.SourceControl;

            CheckWhichPanelIsOwner(playerControl);
        }

        private void PbPlayer_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            ShowPlayerControl playerControl = (ShowPlayerControl)pictureBox.Parent;

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
                    pictureBox.Load(picturePath);

                    if (PlayerPicture.ContainsKey(playerControl.lblData.Text))
                    {

                        PlayerPicture[playerControl.lblData.Text] = picturePath;
                    }
                    else
                    {
                        PlayerPicture.Add(playerControl.lblData.Text, picturePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadData()
        {
            progressBar.Value = 25;
            
            IRepo repo;
            if (PreferencesRepo.ReadChampionship())
            {
                repo = RepoFactory.GetRepo("men/matches.json");
            }
            else
            {
                repo = RepoFactory.GetRepo("women/matches.json");
            }
            try
            {
                players = repo.GetPlayers();
                progressBar.Value = 75;
                tlpOtherPlayers.Invoke(new Delegate(FillPlayers));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void dragStart(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowPlayerControl playerControl = (ShowPlayerControl)sender;


                if (!playersToMove.Contains(playerControl))
                {
                    playerControl.BackColor = Color.Blue;

                    if (playersToMove.Count != 0 && playerControl.Parent != playersToMove[0].Parent)
                    {
                        foreach (ShowPlayerControl player in playersToMove)
                        {
                            player.BackColor = Color.Red;
                        }
                        playersToMove.Clear();
                    }
                    playersToMove.Add(playerControl);

                }
                else
                {
                    playerControl.BackColor = Color.Red;
                    playersToMove.Remove(playerControl);
                }
                playerControl.DoDragDrop(playerControl, DragDropEffects.Move);
            }

        }

        private void dragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dragDrop(object sender, DragEventArgs e)
        {

            playersToMove.ToList().ForEach(p => p.BackColor = Color.Red);

            foreach (ShowPlayerControl player in playersToMove)
            {
                if (tlpMainPlayers.Controls.Count == 3 && player.Parent == tlpOtherPlayers)
                {
                    MessageBox.Show("You  can have only 3 main players");
                    break;
                }
                else
                {
                    CheckWhichPanelIsOwner(player);
                }
            }
            playersToMove.Clear();
        }

        private void CheckWhichPanelIsOwner(ShowPlayerControl playerControl)
        {
            if (tlpMainPlayers.Controls.Contains(playerControl))
            {
                MovePlayers(tlpMainPlayers, tlpOtherPlayers, playerControl);
            }
            else
            {
                if (tlpMainPlayers.Controls.Count < 3)
                {
                    MovePlayers(tlpOtherPlayers, tlpMainPlayers, playerControl);
                }
                else
                {
                    MessageBox.Show("You  can have only 3 main players");
                }
            }
        }

        private void MovePlayers(TableLayoutPanel tlpToRemovePlayer, TableLayoutPanel tlpToAddPlayer, ShowPlayerControl playerControl)
        {
            playerControl.pbMainPlayer.Visible = !playerControl.pbMainPlayer.Visible;
            tlpToAddPlayer.Controls.Add(playerControl);
            tlpToRemovePlayer.Controls.Remove(playerControl);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tlpMainPlayers.Controls.Count == 3)
            {
                StringBuilder stringBuilder = new StringBuilder();

                foreach (ShowPlayerControl player in tlpMainPlayers.Controls)
                {
                    stringBuilder.Append($"{player.lblData.Text} \n {player.pbPlayer.ImageLocation} \n");
                }

                string[] lines = stringBuilder.ToString().Split(Environment.NewLine.ToCharArray());

                PreferencesRepo.WriteData(PreferencesRepo.nameOfMainPlayersFile, lines);


                PreferencesRepo.SavePictures(PlayerPicture);

                Hide();
            }
            else
            {
                MessageBox.Show("You need to pick 3 main players");
            }
        }

        private void FavouritePlayersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.None)
            {
                if (new ConfirmForm().ShowDialog() != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
