using System;
using MultiMiner.MobileMiner.Data;

namespace AntViewer.API.Antminer
{
    public class AntminerStatus
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string Status { get; set; }
        public double Ghs5S { get; set; }
        public double GhsAv { get; set; }
        public string Blocks { get; set; }
        public double HardwareErrorPercentage { get; set; }
        public double RejectPercentage { get; set; }
        public double StalePercentage { get; set; }
        public double BestShare { get; set; }
        public string Fans { get; set; }
        public string Temps { get; set; }
        public int FanSpeed { get; set; }
        public double WorkUtility { get; set; }

        public int HighestTemp
        {
            get
            {
                try
                {
                    var temps = Temps.Replace(" ", string.Empty).Split(new[] { ',' });
                    var temp1 = Convert.ToInt32(temps[0]);
                    var temp2 = Convert.ToInt32(temps[1]);

                    return temp1 > temp2 ? temp1 : temp2;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public string Freq { get; set; }
        public string AsicStatus { get; set; }
        public MiningStatistics MobileMinerMiningStatistics { get; set; }
    }
}
