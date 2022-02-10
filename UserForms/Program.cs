using Data_Layer.Repo;
using System;
using System.IO;
using System.Windows.Forms;
using UserForms.Forms;

namespace UserForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                LoadingForms();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private static void LoadingForms()
        {

            if (!File.Exists(PreferencesRepo.nameOfSettingsFile))
            {
                new PreferencesForm().ShowDialog();
            }
            if (File.Exists(PreferencesRepo.nameOfSettingsFile)
                && !File.Exists(PreferencesRepo.nameOfMainCountryFile))
            {
                new MainCountryForm().ShowDialog();
            }

            if (File.Exists(PreferencesRepo.nameOfMainCountryFile)
                && !File.Exists(PreferencesRepo.nameOfMainPlayersFile))
            {
                new FavouritePlayersForm().ShowDialog();
            }

            if (File.Exists(PreferencesRepo.nameOfPicturePlayerFile)
                && File.Exists(PreferencesRepo.nameOfMainPlayersFile))
            {
                new RangListForm().ShowDialog();
            }

        }
    }
}
