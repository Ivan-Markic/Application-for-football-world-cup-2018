using Data_Layer.Repo;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace UserForms.Events
{
    public static class FormEventManager
    {
        internal static void setCulture(Form formToSetCulture)
        {
            if (PreferencesRepo.ReadLanguage())
            {
                CultureInfo culture = new CultureInfo("hr");
                Thread.CurrentThread.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = culture;
            }
        }
    }
}
