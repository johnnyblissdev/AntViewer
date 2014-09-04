using System;
using AntViewer.API.Alert;
using AntViewer.API.Settings;
using AntViewer.DataService.Settings;
using Telerik.WinControls;

namespace AntViewer.UserControls.Alert
{
    public partial class MinerDown : BaseUserControl
    {
        private Settings _settings;

        public MinerDown()
        {
            InitializeComponent();
        }

        private void MinerDown_Load(object sender, EventArgs e)
        {
            ThemeResolutionService.ApplicationThemeName = "Windows8";

            _settings = SettingsService.GetSettings();

            var alert = _settings.GetAlert<MinerDownAlert>();
            if (alert == null) return;

            SetButton(alert.Enabled);
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            var alert = new MinerDownAlert
            {
                Enabled = btnEnable.Text.Equals("Enable")
            };

            _settings.RemoveAlert<MinerDownAlert>();
            _settings.Alerts.Add(alert);

            SetButton(alert.Enabled);

            SettingsService.SaveSettings(_settings);

            CloseUserControl();
        }

        private void SetButton(bool enabled)
        {
            btnEnable.Text = enabled ? "Disable" : "Enable";
        }
    }
}
