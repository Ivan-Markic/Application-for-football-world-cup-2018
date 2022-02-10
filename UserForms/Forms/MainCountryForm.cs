using Data_Layer.Model;
using Data_Layer.Repo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserForms.Events;

namespace UserForms.Forms
{
    public partial class MainCountryForm : Form
    {
        private delegate void ChangeValueDelegate(int percentage);
        public MainCountryForm()
        {
            FormEventManager.setCulture(this);
            InitializeComponent();
            
        }



        private void MainCountryForm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => LoadData());
            
        }

        private void LoadData()
        {
            try
            {
                //Creating repo
                progressBar.Invoke(new ChangeValueDelegate(ChangeValue), 0);
                IRepo repo;
                if (PreferencesRepo.ReadChampionship())
                {
                    repo = RepoFactory.GetRepo("men/teams.json");
                }
                else
                {
                    repo = RepoFactory.GetRepo("women/teams.json");
                }
                List<Country> countries = new List<Country>();
                progressBar.Invoke(new ChangeValueDelegate(ChangeValue), 25);

                //Getting countries
                countries = repo.GetCountries();

                progressBar.Invoke(new ChangeValueDelegate(ChangeValue), 75);

                //Sorting and Filling cb with countries
                cbMainCountry.Sorted = true;

                countries.ForEach(c => cbMainCountry.Items.Add(c));

                cbMainCountry.Text = cbMainCountry.Items[0].ToString();
                progressBar.Invoke(new ChangeValueDelegate(ChangeValue), 100);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangeValue(int percentage)
        {
            progressBar.Value = percentage;
            
        }

        private void cbMainCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbMainCountry.Text = cbMainCountry.SelectedItem.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //1. Saving data
            PreferencesRepo.WriteData(PreferencesRepo.nameOfMainCountryFile, new string[] { tbMainCountry.Text });

           Hide();
        }

        private void MainCountryForm_FormClosing(object sender, FormClosingEventArgs e)
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
