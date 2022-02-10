using System.Windows.Forms;
using UserForms.Events;

namespace UserForms.Forms
{
    public partial class ConfirmForm : Form
    {
        public ConfirmForm()
        {
            FormEventManager.setCulture(this);
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }
    }
}
