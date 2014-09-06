using System;
using AntViewer.API.Settings;
using AntViewer.DataService.Settings;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace AntViewer.Forms.Performance
{
    public partial class PerformanceSettings : RadForm
    {
        private Settings _settings;

        public PerformanceSettings()
        {
            InitializeComponent();
        }

        private void PerformanceSettings_Load(object sender, EventArgs e)
        {
            ThemeResolutionService.ApplicationThemeName = "Windows8";

            _settings = SettingsService.GetSettings();

            #region Refresh Interval

            tckRefreshInterval.Minimum = 30;
            tckRefreshInterval.Maximum = 280;
            tckRefreshInterval.SmallTickFrequency = 30;
            tckRefreshInterval.LargeTickFrequency = 30;
            tckRefreshInterval.LargeChange = 30;
            tckRefreshInterval.SnapMode = TrackBarSnapModes.SnapToTicks;
            tckRefreshInterval.LabelStyle = TrackBarLabelStyle.TopLeft;
            tckRefreshInterval.ValueChanged += tckRefreshInterval_ValueChanged;
            txtRefreshInterval.Text = tckRefreshInterval.Value.ToString();
            tckRefreshInterval.Value = _settings.Performance.RefreshInterval == 0 ? 60 : _settings.Performance.RefreshInterval/1000;

            #endregion

            #region Refresh Thread Count

            tckRefreshThreadCount.Minimum = 1;
            tckRefreshThreadCount.Maximum = 25;
            tckRefreshThreadCount.SmallTickFrequency = 1;
            tckRefreshThreadCount.LargeTickFrequency = 5;
            tckRefreshThreadCount.LargeChange = 5;
            tckRefreshThreadCount.SnapMode = TrackBarSnapModes.SnapToTicks;
            tckRefreshThreadCount.LabelStyle = TrackBarLabelStyle.TopLeft;
            tckRefreshThreadCount.ValueChanged += tckRefreshThreadCount_ValueChanged;
            txtRefreshThreadCount.Text = tckRefreshThreadCount.Value.ToString();
            tckRefreshThreadCount.Value = _settings.Performance.RefreshThreadCount == 0 ? 10 : _settings.Performance.RefreshThreadCount;

            #endregion
        }

        #region Events

        void tckRefreshThreadCount_ValueChanged(object sender, EventArgs e)
        {
            txtRefreshThreadCount.Text = tckRefreshThreadCount.Value.ToString();
        }

        void tckRefreshInterval_ValueChanged(object sender, EventArgs e)
        {
            txtRefreshInterval.Text = tckRefreshInterval.Value.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _settings.Performance.RefreshInterval = (int) tckRefreshInterval.Value*1000;
            _settings.Performance.RefreshThreadCount = (int) tckRefreshThreadCount.Value;

            SettingsService.SaveSettings(_settings);

            Close();
        }

        #endregion
    }
}
