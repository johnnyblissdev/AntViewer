using System;
using System.Collections.Generic;
using System.Linq;
using AntViewer.API.Antminer;
using AntViewer.Communication.Email;

namespace AntViewer.API.Alert
{
    public class MinerDownAlert : AbstractAlert
    {
        private const string EmailSubject = "Miner {0}/{1} is dead!";
        private const string EmailMessage = "Miner {0}/{1} has gone down at {2}!";
        private const string UpEmailSubject = "Miner {0}/{1} is back up!";
        private const string UpEmailMessage = "Miner {0}/{1} has came back up at {2}!"; 
        
        public MinerDownAlert()
        {
            Type = AlertType.MinerDown;
        }

        public override void Run(List<AntminerStatus> antminerStatuses)
        {
            foreach (var ant in antminerStatuses.Where(ant => !AlertedAntIds.Contains(ant.Id) && !ant.Status.Equals("Alive")))
            {
                EmailService.SendAlertEmail(string.Format(EmailSubject, ant.Name, ant.IpAddress), string.Format(EmailMessage, ant.Name, ant.IpAddress, DateTime.Now.ToString("h:mm:ss tt")));
                AlertedAntIds.Add(ant.Id);
            }

            foreach (var ant in (from antId in AlertedAntIds
                let ant = antminerStatuses.SingleOrDefault(x => x.Id.Equals(antId))
                where ant != null
                where ant.Status.Equals("Alive")
                select ant).ToList())
            {
                EmailService.SendAlertEmail(string.Format(UpEmailSubject, ant.Name, ant.IpAddress), string.Format(UpEmailMessage, ant.Name, ant.IpAddress, DateTime.Now.ToString("h:mm:ss tt")));
                AlertedAntIds.Remove(ant.Id);
            }
        }
    }
}
