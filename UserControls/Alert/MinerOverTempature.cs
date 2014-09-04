using System;
using AntViewer.API.Alert;
using AntViewer.API.Settings;
using AntViewer.DataService.Settings;
using AntViewer.Forms.Common;
using Telerik.WinControls;

namespace AntViewer.UserControls.Alert
{
    public partial class MinerOverTempature : BaseUserControl
    {
        private Settings _settings;

        public MinerOverTempature()
        {
            InitializeComponent();
        }

        private void MinerOverTempature_Load(object sender, EventArgs e)
        {
            ThemeResolutionService.ApplicationThemeName = "Windows8";

            _settings = SettingsService.GetSettings();

            var alert = (MinerOverTempatureAlert)_settings.GetAlert<MinerOverTempatureAlert>();
            if (alert == null) return;

            SetButton(alert.Enabled);
            txtOverTempature.Text = alert.OverTempature == 0 ? "" : alert.OverTempature.ToString();
        }

        private void SetButton(bool enabled)
        {
            btnEnable.Text = enabled ? "Disable" : "Enable";
            btnSave.Visible = enabled;
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            var alert = new MinerOverTempatureAlert
            {
                Enabled = btnEnable.Text.Equals("Enable")
            };

            if (alert.Enabled)
            {
                int overTemp;
                if (!int.TryParse(txtOverTempature.Text, out overTemp))
                {
                    new ErrorDialog { ErrorSubject = "Error saving alert.", ErrorMessage = "Please enter a valid tempature in celsius." }.ShowDialog();
                    return;
                }

                alert.OverTempature = overTemp;
            }

            _settings.RemoveAlert<MinerOverTempatureAlert>();
            _settings.Alerts.Add(alert);

            SetButton(alert.Enabled);

            SettingsService.SaveSettings(_settings);

            CloseUserControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var alert = (MinerOverTempatureAlert)_settings.GetAlert<MinerOverTempatureAlert>();
            if (alert == null) return;
            
            if (alert.Enabled)
            {
                int overTemp;
                if (!int.TryParse(txtOverTempature.Text, out overTemp))
                {
                    new ErrorDialog { ErrorSubject = "Error saving alert.", ErrorMessage = "Please enter a valid tempature in celsius." }.ShowDialog();
                    return;
                }

                alert.OverTempature = overTemp;
            }

            _settings.RemoveAlert<MinerOverTempatureAlert>();
            _settings.Alerts.Add(alert);

            SetButton(alert.Enabled);

            SettingsService.SaveSettings(_settings);

            CloseUserControl();
        }
    }
}
