using Data_Layer.Repo;
using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace UserWPFApp.WPFWindows
{
    /// <summary>
    /// Interaction logic for PlayerStatisticsWindow.xaml
    /// </summary>
    public partial class PlayerStatisticsWindow : Window
    {
        public PlayerStatisticsWindow()
        {
            InitializeComponent();

            imgLeftStar.Source = new BitmapImage(new Uri(PreferencesRepo.GetSolutionFileDir(@"\Star.jpg")));
            imgRightStar.Source = new BitmapImage(new Uri(PreferencesRepo.GetSolutionFileDir(@"\Star.jpg")));

            imgLeftStar.Visibility = Visibility.Hidden;
            imgRightStar.Visibility = Visibility.Hidden;
        }
    }
}
