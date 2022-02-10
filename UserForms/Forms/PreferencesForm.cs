using Data_Layer.Repo;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using UserForms.Forms;

namespace UserForms
{
    public partial class PreferencesForm : Form
    {
        public PreferencesForm()
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
            InitializeComponent();
        }

        private void PreferencesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            cbLanguage.Items.AddRange(new object[] { "Hrvatski", "English" });
            cbChampionship.Items.AddRange(new object[] { "Man", "Women" });

            if (File.Exists(PreferencesRepo.nameOfSettingsFile))
            {
                cbLanguage.Text = PreferencesRepo.ReadLanguage() ? cbLanguage.Items[0].ToString():cbLanguage.Items[1].ToString();
                cbChampionship.Text = PreferencesRepo.ReadChampionship() ? cbChampionship.Items[0].ToString() : cbChampionship.Items[1].ToString();
            }

            else
            {
                

                cbLanguage.Text = cbLanguage.Items[0].ToString();
                cbChampionship.Text = cbChampionship.Items[0].ToString(); 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (File.Exists(PreferencesRepo.nameOfSettingsFile))
            {
                ConfirmForm confirmForm = new ConfirmForm();
                confirmForm.lblText.Text = "Do you want to save this settings?";
                confirmForm.lblText.Location = new Point(10, confirmForm.lblText.Location.Y);
                confirmForm.StartPosition = FormStartPosition.CenterParent;

                if (confirmForm.ShowDialog() == DialogResult.OK)
                {

                    string textInFile = String.Concat(PreferencesRepo.ReadLanguage() ? "Hrvatski" : "English", PreferencesRepo.ReadChampionship() ? "Men" : "Women");

                    if (textInFile != $"{cbChampionship.Text}{cbLanguage.Text}")
                    {
                        File.Delete(PreferencesRepo.nameOfMainCountryFile);
                        File.Delete(PreferencesRepo.nameOfMainPlayersFile);
                        File.Delete(PreferencesRepo.nameOfPicturePlayerFile);
                        SaveData();
                    }
                    else
                    {
                        Close();
                    }

                }

                else
                {
                    Close();
                }
            }

            else
            {
                SaveData();
            }
        }

        private void SaveData()
        {
            string[] text = { cbChampionship.Text, cbLanguage.Text };
            PreferencesRepo.WriteData(PreferencesRepo.nameOfSettingsFile, text);
            Close();
        }
    }
}
