using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using AntViewer.DataService.Settings;

namespace AntViewer.Communication.Email
{
    public static class EmailService
    {
        private static string _toAddress;
        private static SmtpClient _smtpClient;
        private static BackgroundWorker _sendEmailBackgroundWorker = new BackgroundWorker();
        
        static void InitSettings()
        {
            var settings = SettingsService.GetSettings();

            _toAddress = settings.Email.ToAddress;
            _smtpClient = new SmtpClient(settings.Email.SmptServer, settings.Email.SmptServerPort)
            {
                UseDefaultCredentials = false,
                EnableSsl = settings.Email.UseSsl
            };

            _smtpClient.Credentials = new NetworkCredential(settings.Email.Username, settings.Email.Password);
        }

        static void _sendEmailBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var m = e.Argument as MailMessage;
            if (m == null) return;

            _smtpClient.Send(m);
        }

        public static void SendEmail(IEnumerable<string> toAddresses, string subject, string body)
        {
            InitSettings();

            var m = new MailMessage();
            foreach (var a in toAddresses)
                m.To.Add(new MailAddress(a));
            m.Subject = subject;
            m.Body = body;
            m.IsBodyHtml = true;
            m.From = new MailAddress("alerts@santviewer.com");

            _sendEmailBackgroundWorker = new BackgroundWorker();
            _sendEmailBackgroundWorker.DoWork += _sendEmailBackgroundWorker_DoWork;
            _sendEmailBackgroundWorker.RunWorkerAsync(m);
        }

        public static void SendEmail(string toAddress, string subject, string body)
        {
            InitSettings();

            var m = new MailMessage();
            m.To.Add(toAddress);
            m.Subject = subject;
            m.Body = body;
            m.IsBodyHtml = true;
            m.From = new MailAddress("alerts@santviewer.com");

            _sendEmailBackgroundWorker = new BackgroundWorker();
            _sendEmailBackgroundWorker.DoWork += _sendEmailBackgroundWorker_DoWork;
            _sendEmailBackgroundWorker.RunWorkerAsync(m);
        }

        public static void SendAlertEmail(string subject, string body)
        {
            try
            {
                InitSettings();

                var m = new MailMessage();
                m.To.Add(_toAddress);
                m.Subject = subject;
                m.Body = body;
                m.IsBodyHtml = true;
                m.From = new MailAddress("alerts@santviewer.com");

                _sendEmailBackgroundWorker = new BackgroundWorker();
                _sendEmailBackgroundWorker.DoWork += _sendEmailBackgroundWorker_DoWork;
                _sendEmailBackgroundWorker.RunWorkerAsync(m);
            }
            catch (Exception)
            {
                
            }
        }
    }
}
