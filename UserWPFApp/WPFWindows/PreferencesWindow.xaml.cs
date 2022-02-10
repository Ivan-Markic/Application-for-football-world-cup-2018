using Data_Layer.Repo;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace UserWPFApp.WPFWindows
{
    /// <summary>
    /// Interaction logic for PreferencesWindow.xaml
    /// </summary>
    public partial class PreferencesWindow : Window
    {
        WindowCollection windows = Application.Current.Windows;
        public PreferencesWindow()
        {
            if (LanguageExists())
            {

                Thread.CurrentThread.CurrentCulture = new CultureInfo("hr");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr");
            }

            InitializeComponent();

            if (windows.Count == 0)
            {
                try
                {
                    if (File.Exists(PreferencesRepo.GetResourceFileDir(PreferencesRepo.nameOfSettingsFile))
                            && PreferencesRepo.ReadResolution()[0] != 0)
                    {
                        new ReviewOfRepresentationsWindow().Show();
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private static bool LanguageExists()
        {
            return File.Exists(PreferencesRepo.GetResourceFileDir(PreferencesRepo.nameOfSettingsFile)) && PreferencesRepo.ReadLanguage();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (windows.Count == 0)
            {
                try
                {
                    SaveData();
                    new ReviewOfRepresentationsWindow().Show();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                string text = "Do you want to save this settings";
                string title = "Settings";
                if (Thread.CurrentThread.CurrentCulture.ToString() == "hr")
                {
                    text = "Želiš li spremiti ove postavke?";
                    title = "Postavke";
                }
                if (MessageBox.Show(this, text, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        SaveData();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void SaveData()
        {
            string[] text = { cbChampionship.Text, cbLanguage.Text, cbResolution.Text };
            PreferencesRepo.WriteData(PreferencesRepo.nameOfSettingsFile, text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetUpComboBox();
        }

        private void SetUpComboBox()
        {
            FillComboBox();
            cbLanguage.SelectedItem = cbLanguage.Items[1];
            cbChampionship.SelectedItem = cbChampionship.Items[1];
            cbResolution.SelectedItem = cbResolution.Items[0];

            if (LanguageExists())
            {
                cbLanguage.SelectedItem = cbLanguage.Items[0];
            }

            if (File.Exists(PreferencesRepo.GetResourceFileDir(PreferencesRepo.nameOfSettingsFile))
                && PreferencesRepo.ReadChampionship())
            {
                cbChampionship.SelectedItem = cbChampionship.Items[0];
            }

            if (File.Exists(PreferencesRepo.GetResourceFileDir(PreferencesRepo.nameOfSettingsFile))
                && PreferencesRepo.ReadResolution()[0]!=0)
            {
                foreach (string item in cbResolution.Items)
                {
                    if (item.Contains(PreferencesRepo.ReadResolution()[0].ToString()))
                    {
                        cbResolution.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void FillComboBox()
        {
            cbLanguage.Items.Add("Hrvatski");
            cbLanguage.Items.Add("English");
            cbChampionship.Items.Add("Man");
            cbChampionship.Items.Add("Women");
            cbResolution.Items.Add("640x320");
            cbResolution.Items.Add("1280x1024");
            cbResolution.Items.Add("1920x1080");
        }

        private void cbResolution_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbResolution.SelectedItem.ToString() == "640x320")
            {
                SetWindow(640, 320);
            }
            else if (cbResolution.SelectedItem.ToString() == "1280x1024")
            {
                SetWindow(1280, 1024);
            }

            else if (cbResolution.SelectedItem.ToString() == "1920x1080")
            {
                SetWindow(1920, 1080);
            }
        }

        private void SetWindow(int windowWidth, int windowHeight)
        {
            Width = windowWidth;
            Height = windowHeight;

            Left = (SystemParameters.PrimaryScreenWidth - windowWidth) / 2;
            Top = (SystemParameters.PrimaryScreenHeight - windowHeight) / 2;

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
    }
}
