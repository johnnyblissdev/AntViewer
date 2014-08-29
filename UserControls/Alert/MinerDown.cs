using System;
using System.Windows.Forms;
using AntViewer.API.Alert;
using AntViewer.API.Settings;
using AntViewer.DataService.Settings;
using Telerik.WinControls;

namespace AntViewer.UserControls.Alert
{
    public partial class MinerDown : UserControl
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

            if (_settings.HasAlert<MinerDownAlert>())
                btnEnable.Text = "Disable";
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if(btnEnable.Text.Equals("Disable"))
                _settings.RemoveAlert<MinerDownAlert>();
            else
                _settings.Alerts.Add(new MinerDownAlert());

            SettingsService.SaveSettings(_settings);
        }
    }
}
