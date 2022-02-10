using System.Windows;

namespace UserWPFApp.WPFWindows
{
    /// <summary>
    /// Interaction logic for DetailsOfTheTeam.xaml
    /// </summary>
    public partial class DetailsOfTheTeam : Window
    {
        public DetailsOfTheTeam()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
