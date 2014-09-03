using AntViewer.API.Settings;
using AntViewer.DataService.Settings;
using AntViewer.Forms.Common;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace AntViewer.Forms.MobileMiner
{
    public partial class MobileMiner : RadForm
    {
        private Settings _settings;

        public MobileMiner()
        {
            InitializeComponent();
        }

        private void MultiMiner_Load(object sender, System.EventArgs e)
        {
            ThemeResolutionService.ApplicationThemeName = "Windows8";

            _settings = SettingsService.GetSettings();
            txtEmailAddress.Text = _settings.MobileMiner.EmailAddress;
            txtApplicationKey.Text = _settings.MobileMiner.ApplicationKey;
            chkEnabled.IsChecked = _settings.MobileMiner.Enabled;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!ValidateSettings()) return;

            _settings.MobileMiner = new API.Settings.MobileMiner
            {
                EmailAddress = txtEmailAddress.Text,
                ApplicationKey = txtApplicationKey.Text,
                Enabled = chkEnabled.IsChecked
            };

            SettingsService.SaveSettings(_settings);

            Close();
        }

        private bool ValidateSettings()
        {
            if (!string.IsNullOrEmpty(txtEmailAddress.Text) && !string.IsNullOrEmpty(txtApplicationKey.Text))
                return true;

            new ErrorDialog { ErrorSubject = "Error saving settings", ErrorMessage = "Please enter an email address and application key." }.ShowDialog();
            return false;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
