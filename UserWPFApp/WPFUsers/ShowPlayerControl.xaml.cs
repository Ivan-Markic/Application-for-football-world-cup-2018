using Data_Layer.Repo;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace UserWPFApp.WPFUsers
{
    /// <summary>
    /// Interaction logic for ShowPlayerControl.xaml
    /// </summary>
    public partial class ShowPlayerControl : UserControl
    {
        public ShowPlayerControl()
        {
            InitializeComponent();
            imgPicture.Source = new BitmapImage(new Uri(PreferencesRepo.GetSolutionFileDir(@"\BasicPicture.png")));
        }
    }
}
