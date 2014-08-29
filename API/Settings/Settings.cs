using System.Collections.Generic;
using System.Linq;
using AntViewer.API.Alert;

namespace AntViewer.API.Settings
{
    public class Settings
    {
        public string SmptServer { get; set; }
        public string SmptServerPort { get; set; }
        public bool UseSsl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public List<AbstractAlert> Alerts { get; set; }

        public bool HasAlert<T>() where T : IAlert
        {
            return Alerts.OfType<T>().Any();
        }

        public void RemoveAlert<T>() where T : AbstractAlert
        {
            foreach (var a in Alerts.ToArray().OfType<T>())
                Alerts.Remove(a);
        }

        public Settings()
        {
            Alerts = new List<AbstractAlert>();
        }
    }
}
