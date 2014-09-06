using System.Collections.Generic;
using System.Linq;
using AntViewer.API.Alert;

namespace AntViewer.API.Settings
{
    public class Settings
    {
        public Email Email { get; set; }
        public Performance Performance { get; set; }
        public MobileMiner MobileMiner { get; set; }
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

        public IAlert GetAlert<T>() where T : AbstractAlert
        {
            return Alerts.OfType<T>().SingleOrDefault();
        }

        public Settings()
        {
            Alerts = new List<AbstractAlert>();
            MobileMiner = new MobileMiner {Enabled = false};
            Email = new Email();
            Performance = new Performance();
        }
    }
}
