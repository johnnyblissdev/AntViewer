using System.Collections.Generic;
using AntViewer.API.Antminer;

namespace AntViewer.API.Alert
{
    public interface IAlert
    {
        bool Enabled { get; set; }
        void Run(List<AntminerStatus> antminerStatuses);
    }
}
