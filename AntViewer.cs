using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Timers;
using System.Windows.Forms;
using AntViewer.API.Antminer;
using AntViewer.Communication.Antminer;
using AntViewer.DataService.Antminer;
using AntViewer.Forms.Alerts;
using AntViewer.Forms.Antminer;
using AntViewer.Forms.Common;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Timer = System.Timers.Timer;

namespace AntViewer
{
    public partial class AntViewer : RadForm
    {
        public Timer RefreshTimer = new Timer(1000);
        public Timer StatsTimer = new Timer(1000);
        public Timer CountdownTimer = new Timer(1000);

        private DateTime _lastRefreshed;
        private int _rowCount = 1;
        
        public AntViewer()
        {
            InitializeComponent();
        }

        private void AntViewer_Load(object sender, System.EventArgs e)
        {
            ThemeResolutionService.ApplicationThemeName = "Windows8";

            #region Antminers Grid

            #region Context Menu

            var contextMenu = new ContextMenu();
            
            var details = new MenuItem("View Details");
            details.Click += details_Click;
            contextMenu.MenuItems.Add(details);

            var restart = new MenuItem("Restart");
            restart.Click += restart_Click;
            contextMenu.MenuItems.Add(restart);

            #endregion

            grdAntminers.AutoGenerateColumns = false;
            grdAntminers.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdAntminers.AllowAddNewRow = false;
            grdAntminers.EnableGrouping = false;
            grdAntminers.AllowCellContextMenu = false;
            grdAntminers.AllowAutoSizeColumns = true;
            grdAntminers.ContextMenu = contextMenu;
            
            grdAntminers.Columns.Add("Id", "Id", "Id");
            grdAntminers.Columns.Add("Number", "#", "Number");
            grdAntminers.Columns.Add("LastUpdated", "Last Updated", "LastUpdated");
            grdAntminers.Columns.Add("IpAddress", "Ip Address", "IpAddress");
            grdAntminers.Columns.Add("Name", "Name", "Name");
            grdAntminers.Columns.Add("Status", "Status", "Status");
            grdAntminers.Columns.Add("Ghs5s", "GH/S (5s)", "Ghs5s");
            grdAntminers.Columns.Add("GhsAv", "GH/S Av", "GhsAv");
            grdAntminers.Columns.Add("Block", "Blocks", "Blocks");
            grdAntminers.Columns.Add("HardwareErrorPercentage", "Hardware Error %", "HardwareErrorPercentage");
            grdAntminers.Columns.Add("RejectPercentage", "Reject %", "RejectPercentage");
            grdAntminers.Columns.Add("StalePercentage", "Stale %", "StalePercentage");
            grdAntminers.Columns.Add("BestShare", "Best Share", "BestShare");
            grdAntminers.Columns.Add("Fans", "Fans", "Fans");
            grdAntminers.Columns.Add("Temps", "Temps", "Temps");
            grdAntminers.Columns.Add("Freq", "Freq", "Freq");
            grdAntminers.Columns.Add("AsicStatus", "ASIC Status", "Asic Status");

            grdAntminers.Columns[0].IsVisible = false;
            grdAntminers.Columns[1].Width = 25;
            grdAntminers.Columns[2].Width = 100;
            grdAntminers.Columns[3].Width = 100;
            grdAntminers.Columns[4].Width = 100;
            grdAntminers.Columns[5].Width = 50;
            grdAntminers.Columns[6].Width = 50;
            grdAntminers.Columns[7].Width = 50;
            grdAntminers.Columns[8].Width = 50;
            grdAntminers.Columns[9].Width = 100;
            grdAntminers.Columns[10].Width = 100;
            grdAntminers.Columns[11].Width = 100;
            grdAntminers.Columns[12].Width = 75;
            grdAntminers.Columns[13].Width = 60;
            grdAntminers.Columns[14].Width = 60;
            grdAntminers.Columns[15].Width = 60;
            grdAntminers.Columns[16].Width = 350;

            #endregion

            RefreshTimer.Elapsed += RefreshTimer_Elapsed;
            RefreshTimer.AutoReset = true;
            RefreshTimer.Start();

            StatsTimer.Elapsed += StatsTimer_Elapsed;
            StatsTimer.AutoReset = true;
            StatsTimer.Enabled = false;

            CountdownTimer.Elapsed += CountdownTimer_Elapsed;
            CountdownTimer.AutoReset = true;
            CountdownTimer.Enabled = false;
        }

        #region Context Menu Events

        void restart_Click(object sender, EventArgs e)
        {
            var id = Guid.Parse(grdAntminers.CurrentRow.Cells[0].Value.ToString());
            var antminer = AntminerService.GetAntminerById(id);
            if (antminer == null) return;

            try
            {
                AntminerConnector.Restart(IPAddress.Parse(antminer.IpAddress));
            }
            catch (Exception ex)
            {
                new ErrorDialog {ErrorMessage = ex.Message, ErrorSubject = "Error restarting miner"}.ShowDialog();
            }
        }

        void details_Click(object sender, EventArgs e)
        {
            var id = Guid.Parse(grdAntminers.CurrentRow.Cells[0].Value.ToString());
            var frm = new AntminerDetails {AntminerId = id};
            frm.ShowDialog();
        }

        #endregion

        #region Timer Events

        void CountdownTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var timeLeft = DateTime.Now.Subtract(_lastRefreshed).Seconds;
            btnRefresh.Invoke(new MethodInvoker(() => btnRefresh.Text = string.Format("Refresh ({0})", 60 - timeLeft)));
        }

        void StatsTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lblHashRate.Invoke(new MethodInvoker(() => lblHashRate.Text = string.Format("Hash Rate: {0}", GetFormattedHashRate())));
            lblHighestTemp.Invoke(new MethodInvoker(() => lblHighestTemp.Text = string.Format("Highest Temp: {0}", GetFormattedHighestTemp())));
            lblHighestHwe.Invoke(new MethodInvoker(() => lblHighestHwe.Text = string.Format("Highest HWE: {0}", GetFormattedHighestHardwareErrorCount())));
        }

        void RefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _lastRefreshed = DateTime.Now;

            var antminers = AntminerService.GetAntminers();

            var antminerStatusBackgroundWorker = new BackgroundWorker();
            antminerStatusBackgroundWorker.DoWork += antminerStatusBackgroundWorker_DoWork;
            antminerStatusBackgroundWorker.RunWorkerCompleted += antminerStatusBackgroundWorker_RunWorkerCompleted;
            antminerStatusBackgroundWorker.RunWorkerAsync(antminers);
            
            RefreshTimer.Interval = 60000;

            if (!StatsTimer.Enabled)
            {
                StatsTimer.Enabled = true;
                StatsTimer.Start();
            }

            if (!CountdownTimer.Enabled)
            {
                CountdownTimer.Enabled = true;
                CountdownTimer.Start();
            }
        }

        #endregion

        #region Antminer Status Background Worker

        void antminerStatusBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var antminers = e.Argument as Antminers;
            if (antminers == null || antminers.Antminer.Count == 0) return;

            var statuses = new List<AntminerStatus>();
            foreach (var ant in antminers.Antminer)
            {
                var status = new AntminerStatus
                {
                    Id = ant.Id,
                    IpAddress = ant.IpAddress,
                    Name = ant.Name
                };

                try
                {
                    var updatingRow = grdAntminers.Rows.SingleOrDefault(x => x.Tag.Equals(status.Id));
                    updatingRow.Cells[2].Value = "-------------";
                }
                catch (Exception)
                {
                    
                }

                try
                {
                    var summary = AntminerConnector.GetSummary(IPAddress.Parse(ant.IpAddress));
                    var stats = AntminerConnector.GetStats(IPAddress.Parse(ant.IpAddress));

                    var hwError = Convert.ToInt32(summary["Hardware Errors"].ToString());
                    var diffA = Convert.ToDouble(summary["Difficulty Accepted"].ToString());
                    var diffR = Convert.ToDouble(summary["Difficulty Rejected"].ToString());

                    var rejects = Convert.ToDouble(summary["Rejected"].ToString());
                    var accepted = Convert.ToDouble(summary["Accepted"].ToString());
                    var stale = Convert.ToDouble(summary["Stale"].ToString());

                    status.Status = "Alive";
                    status.Ghs5S = Convert.ToDouble(summary["GHS 5s"].ToString());
                    status.GhsAv = Convert.ToDouble(summary["GHS av"].ToString());
                    status.Blocks = summary["Found Blocks"].ToString();
                    status.HardwareErrorPercentage = Math.Round(hwError / (diffA + diffR) * 100, 2);
                    status.RejectPercentage = (Math.Round(rejects / accepted) * 100);
                    status.StalePercentage = (Math.Round(stale / accepted) * 100);
                    status.BestShare = Convert.ToDouble(summary["Best Share"].ToString());
                    status.Fans = string.Format("{0}, {1}", stats["fan1"], stats["fan2"]);
                    status.Temps = string.Format("{0}, {1}", stats["temp1"], stats["temp2"]);
                    status.Freq = stats["frequency"].ToString();
                    status.AsicStatus = string.Format("{0} - {1}", stats["chain_acs1"], stats["chain_acs2"]);
                }
                catch (Exception ex)
                {
                    status.Status = "Dead";
                    status.Ghs5S = 0;
                    status.GhsAv = 0;
                    status.Blocks = "-";
                    status.HardwareErrorPercentage = 0;
                    status.RejectPercentage = 0;
                    status.StalePercentage = 0;
                    status.Fans = "-";
                    status.Temps = "-";
                    status.Freq = "-";
                    status.AsicStatus = "-";
                }

                var row = grdAntminers.Rows.SingleOrDefault(x => x.Tag.Equals(status.Id));
                if (row == null)
                {
                    var rowInfo = new GridViewDataRowInfo(grdAntminers.MasterView) { Tag = status.Id };

                    rowInfo.Cells[0].Value = status.Id;
                    rowInfo.Cells[1].Value = _rowCount++;
                    rowInfo.Cells[2].Value = DateTime.Now.ToString("h:mm:ss tt");
                    rowInfo.Cells[3].Value = status.IpAddress;
                    rowInfo.Cells[4].Value = status.Name;
                    rowInfo.Cells[5].Value = status.Status;
                    rowInfo.Cells[6].Value = status.Ghs5S;
                    rowInfo.Cells[7].Value = status.GhsAv;
                    rowInfo.Cells[8].Value = status.Blocks;
                    rowInfo.Cells[9].Value = status.HardwareErrorPercentage;
                    rowInfo.Cells[10].Value = status.RejectPercentage;
                    rowInfo.Cells[11].Value = status.StalePercentage;
                    rowInfo.Cells[12].Value = status.BestShare;
                    rowInfo.Cells[13].Value = status.Fans;
                    rowInfo.Cells[14].Value = status.Temps;
                    rowInfo.Cells[15].Value = status.Freq;
                    rowInfo.Cells[16].Value = status.AsicStatus;

                    if (grdAntminers.InvokeRequired)
                        grdAntminers.Invoke(new MethodInvoker(() => grdAntminers.Rows.Add(rowInfo)));
                    else
                        grdAntminers.Rows.Add(rowInfo);
                }
                else
                {
                    row.Cells[0].Value = status.Id;
                    row.Cells[2].Value = DateTime.Now.ToString("h:mm:ss tt");
                    row.Cells[3].Value = status.IpAddress;
                    row.Cells[4].Value = status.Name;
                    row.Cells[5].Value = status.Status;
                    row.Cells[6].Value = status.Ghs5S;
                    row.Cells[7].Value = status.GhsAv;
                    row.Cells[8].Value = status.Blocks;
                    row.Cells[9].Value = status.HardwareErrorPercentage;
                    row.Cells[10].Value = status.RejectPercentage;
                    row.Cells[11].Value = status.StalePercentage;
                    row.Cells[12].Value = status.BestShare;
                    row.Cells[13].Value = status.Fans;
                    row.Cells[14].Value = status.Temps;
                    row.Cells[15].Value = status.Freq;
                    row.Cells[16].Value = status.AsicStatus;
                }
            }

            e.Result = statuses;
        }

        void antminerStatusBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        #endregion

        #region Button Clicks

        private void btnManageAntminers_Click(object sender, System.EventArgs e)
        {
            new ManageAntminers().ShowDialog();

            _rowCount = 1;
            grdAntminers.Rows.Clear();
            RefreshTimer.Interval = 1000;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTimer.Interval = 100;
        }

        #endregion

        #region Helpers

        public string GetFormattedHashRateAverage()
        {
            var hashRate = grdAntminers.Rows.Average(r => Convert.ToDouble(r.Cells[6].Value));
            return hashRate > 1000 ? string.Format("{0}TH", Math.Round(hashRate / 1000, 3)) : string.Format("{0}GH", Math.Round(hashRate, 3));
        }

        public string GetFormattedHashRate()
        {
            try
            {
                var hashRate = grdAntminers.Rows.Sum(r => Convert.ToDouble(r.Cells[6].Value));
                var hashRateAv = grdAntminers.Rows.Average(r => Convert.ToDouble(r.Cells[6].Value));
                var formattedHashRate = hashRate > 1000 ? string.Format("{0}TH", Math.Round(hashRate / 1000, 3)) : string.Format("{0}GH", Math.Round(hashRate, 3));
                var formattedHashRateAv = hashRateAv > 1000 ? string.Format("{0}TH", Math.Round(hashRateAv / 1000, 3)) : string.Format("{0}GH", Math.Round(hashRateAv, 3));
                return string.Format("{0} ({1} Av)", formattedHashRate, formattedHashRateAv);
            }
            catch (Exception)
            {
                return "0GH (0GH Av)";
            }
        }
        
        public string GetFormattedHighestTemp()
        {
            var allTemps = new List<int>();
            foreach (var r in grdAntminers.Rows)
            {
                try
                {
                    var temps = r.Cells[14].Value.ToString().Replace(" ", string.Empty).Split(new[] {','});
                    var temp1 = Convert.ToInt32(temps[0]);
                    var temp2 = Convert.ToInt32(temps[1]);

                    allTemps.Add(temp1);
                    allTemps.Add(temp2);
                }
                catch (Exception)
                {
                    
                }
            }

            return allTemps.Count < 1 ? "-" : string.Format("{0}c", allTemps.Max());
        }

        public string GetFormattedHighestHardwareErrorCount()
        {
            if (grdAntminers.RowCount < 1) return "-";
            return string.Format("{0}%", grdAntminers.Rows.Max(r => Convert.ToDouble(r.Cells[9].Value)));
        }
        
        #endregion

        #region Menu Events

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void emailSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ManageAlerts().ShowDialog();
        }

        #endregion
    }
}
