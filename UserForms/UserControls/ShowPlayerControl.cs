using Data_Layer.Repo;
using System.Drawing;
using System.Windows.Forms;

namespace UserForms.UserControls
{
    public partial class ShowPlayerControl : UserControl
    {
        public ShowPlayerControl()
        {
            InitializeComponent();
            
            InitializePictures();
        }

        private void InitializePictures()
        {

            pbPlayer.Image = new Bitmap(PreferencesRepo.GetSolutionFileDir(@"\BasicPicture.png"));
            pbMainPlayer.ImageLocation = PreferencesRepo.GetSolutionFileDir(@"\Star.jpg");
        }
    }
}
