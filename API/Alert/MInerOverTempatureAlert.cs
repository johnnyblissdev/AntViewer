using System;
using System.Collections.Generic;
using System.Linq;
using AntViewer.API.Antminer;
using AntViewer.Communication.Email;

namespace AntViewer.API.Alert
{
    public class MinerOverTempatureAlert : AbstractAlert
    {
        private const string EmailSubject = "Miner {0}/{1} is over tempature!";
        private const string EmailMessage = "Miner {0}/{1} is running at {2} at {3}!";

        public int OverTempature { get; set; }

        public MinerOverTempatureAlert()
        {
            Type = AlertType.MinerOverTempature;
        }

        public override void Run(List<AntminerStatus> antminerStatuses)
        {
            foreach (var ant in antminerStatuses.Where(x => !AlertedAntIds.Contains(x.Id) && x.HighestTemp > OverTempature))
            {
                EmailService.SendAlertEmail(string.Format(EmailSubject, ant.Name, ant.IpAddress), string.Format(EmailMessage, ant.Name, ant.IpAddress, ant.HighestTemp, DateTime.Now.ToString("h:mm:ss tt")));
                AlertedAntIds.Add(ant.Id);
            }

            foreach (var id in (from antId in AlertedAntIds
                let ant = antminerStatuses.SingleOrDefault(x => x.Id.Equals(antId))
                where ant != null
                where ant.HighestTemp <= OverTempature
                select antId).ToList())
            {
                AlertedAntIds.Remove(id);
            }
        }
    }
}
