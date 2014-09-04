using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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

            var settings = SettingsService.GetSettings();
            txtEmailSmtpServer.Text = settings.Email.SmptServer;
            txtEmailSmtpServerPort.Text = settings.Email.SmptServerPort.ToString();
            txtEmailUsername.Text = settings.Email.Username;
            txtEmailPassword.Text = settings.Email.Password;
            txtEmailFromName.Text = settings.Email.FromName;
            txtToAddress.Text = settings.Email.ToAddress;
            chkEmailSsl.IsChecked = settings.Email.UseSsl;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateEmailSettings()) return;

            var settings = SettingsService.GetSettings();

            settings.Email = new Email
            {
                SmptServer = txtEmailSmtpServer.Text,
                SmptServerPort = Convert.ToInt32(txtEmailSmtpServerPort.Text),
                UseSsl = chkEmailSsl.IsChecked,
                Username = txtEmailUsername.Text,
                Password = txtEmailPassword.Text,
                FromName = txtEmailFromName.Text,
                ToAddress = txtToAddress.Text
            };

            SettingsService.SaveSettings(settings);

            Close();
        }

        private bool ValidateEmailSettings()
        {
            var errors = new List<string>();
            if(string.IsNullOrEmpty(txtEmailSmtpServer.Text))
                errors.Add("Please enter a Smtp Server Address.");
            if(string.IsNullOrEmpty(txtEmailSmtpServerPort.Text))
                errors.Add("Please enter a Smtp Server Port.");
            if(string.IsNullOrEmpty(txtEmailUsername.Text))
                errors.Add("Please enter a Smtp Username.");
            if(string.IsNullOrEmpty(txtEmailPassword.Text))
                errors.Add("Please enter a Smtp Password.");
            if (string.IsNullOrEmpty(txtEmailFromName.Text))
                errors.Add("Please enter a From Name.");
            if(string.IsNullOrEmpty(txtToAddress.Text))
                errors.Add("Plesae enter a To Address");
            int port;
            if(!int.TryParse(txtEmailSmtpServerPort.Text, out port))
                errors.Add("Please enter a valid port.");

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
