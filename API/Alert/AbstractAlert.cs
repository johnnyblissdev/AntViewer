using System;
using System.Xml.Serialization;

namespace AntViewer.API.Alert
{
    [XmlInclude(typeof(MinerDownAlert))]
    public abstract class AbstractAlert : IAlert
    {
        public AlertType Type { get; set; }

        public virtual void Run()
        {
            throw new NotImplementedException();
        }
    }
}
