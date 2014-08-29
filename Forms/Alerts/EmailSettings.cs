using System;
using System.Collections.Generic;
using System.Linq;
using AntViewer.API.Settings;
using AntViewer.DataService.Settings;
using AntViewer.Forms.Common;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace AntViewer.Forms.Alerts
{
    public partial class EmailSettings : RadForm
    {
        public EmailSettings()
        {
            InitializeComponent();
        }

        private void EmailSettings_Load(object sender, EventArgs e)
        {
            ThemeResolutionService.ApplicationThemeName = "Windows8";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateEmailSettings()) return;

            var settings = new Settings
            {
                SmptServer = txtEmaiLSmtpServer.Text,
                SmptServerPort = txtEmailSmtpServerPort.Text,
                UseSsl = chkEmailSsl.IsChecked,
                Username = txtEmailUsername.Text,
                Password = txtEmailPassword.Text,
                FromAddress = txtEmailFromAddress.Text,
                FromName = txtEmailFromName.Text
            };

            SettingsService.SaveSettings(settings);
        }

        private bool ValidateEmailSettings()
        {
            var errors = new List<string>();
            if(string.IsNullOrEmpty(txtEmaiLSmtpServer.Text))
                errors.Add("Please enter a Smtp Server Address.");
            if(string.IsNullOrEmpty(txtEmailSmtpServerPort.Text))
                errors.Add("Please enter a Smtp Server Port.");
            if(string.IsNullOrEmpty(txtEmailUsername.Text))
                errors.Add("Please enter a Smtp Username.");
            if(string.IsNullOrEmpty(txtEmailPassword.Text))
                errors.Add("Please enter a Smtp Password.");
            if(string.IsNullOrEmpty(txtEmailFromAddress.Text))
                errors.Add("Please enter a From Address.");
            if (string.IsNullOrEmpty(txtEmailFromName.Text))
                errors.Add("Please enter a From Name.");

            if (errors.Count > 0)
            {
                new ErrorDialog
                {
                    ErrorMessage = errors.Aggregate((w, j) => string.Format("{0}\r\n{1}", w, j)),
                    ErrorSubject = "Error saving Email Settings"
                }.ShowDialog();

                return false;
            }

            return true;
        }
    }
}
