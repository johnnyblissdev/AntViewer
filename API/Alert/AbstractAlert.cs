using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;
using AntViewer.API.Antminer;

namespace AntViewer.API.Alert
{
    [XmlInclude(typeof(MinerDownAlert))]
    [XmlInclude(typeof(MinerOverTempatureAlert))]
    public abstract class AbstractAlert : IAlert
    {
        public bool Enabled { get; set; }
        public AlertType Type { get; set; }
        public List<Guid> AlertedAntIds { get; set; }

        protected NotifyIcon AlertNotify;

        public virtual void Run(List<AntminerStatus> antminerStatuses)
        {
            throw new NotImplementedException();
        }
    }
}
