using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AntViewer.API.Antminer;
using AntViewer.Communication.Antminer;
using AntViewer.Communication.Email;

namespace AntViewer.API.Alert
{
    public class MinerAsicStatusAlert : AbstractAlert
    {
        private const string EmailSubject = "Miner {0}/{1} has a X in ASIC Status!";
        private const string EmailMessage = "Miner {0}/{1} has a X in ASIC Status at {2}!\r\n\r\n{3}";
        private const string UpEmailSubject = "Miner {0}/{1} has cleared Xs in ASIC Status!";
        private const string UpEmailMessage = "Miner {0}/{1} has came back up at {2} and has cleared all Xs in ASIC Status!"; 

        public MinerAsicStatusAlert()
        {
            Type = AlertType.MinerAsicStatus;
        }

        public override void Run(List<AntminerStatus> antminerStatuses)
        {
            foreach (var ant in antminerStatuses.Where(x => x.Status.Equals("Alive") && x.AsicStatus.Contains("x") && !AlertedAntIds.Contains(x.Id)))
            {
                var restartMessage = "Miner was successfully restarted. You will be notified if restart removes Xs.";
                try
                {
                    AntminerConnector.Restart(IPAddress.Parse(ant.IpAddress));
                }
                catch (Exception ex)
                {
                    restartMessage = string.Format("An error occured while attempting to restart miner: {0}", ex.Message);
                }

                EmailService.SendAlertEmail(string.Format(EmailSubject, ant.Name, ant.IpAddress), 
                    string.Format(EmailMessage, ant.Name, ant.IpAddress, DateTime.Now.ToString("h:mm:ss tt"), restartMessage));
                AlertedAntIds.Add(ant.Id);
            }

            foreach (var ant in antminerStatuses.Where(ant => ant.Status.Equals("Alive") && AlertedAntIds.Contains(ant.Id) && !ant.AsicStatus.Contains("x")))
            {
                EmailService.SendAlertEmail(string.Format(UpEmailSubject, ant.Name, ant.IpAddress), string.Format(UpEmailMessage, ant.Name, ant.IpAddress, DateTime.Now.ToString("h:mm:ss tt")));
                AlertedAntIds.Remove(ant.Id);
            }
        }
    }
}
