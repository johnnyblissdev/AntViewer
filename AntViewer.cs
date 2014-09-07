using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Timers;
using System.Windows.Forms;
using AntViewer.API.Antminer;
using AntViewer.API.Settings;
using AntViewer.Communication.Antminer;
using AntViewer.Communication.BTC;
using AntViewer.DataService.Antminer;
using AntViewer.DataService.Settings;
using AntViewer.Forms.Alerts;
using AntViewer.Forms.Antminer;
using AntViewer.Forms.Common;
using AntViewer.Forms.Email;
using AntViewer.Forms.Performance;
using MultiMiner.MobileMiner;
using MultiMiner.MobileMiner.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using MobileMiner = AntViewer.Forms.MobileMiner.MobileMiner;
using Timer = System.Timers.Timer;

namespace AntViewer
{
    public partial class AntViewer : RadForm
    {
        private readonly Timer _refreshTimer = new Timer(1000);
        private readonly Timer _statsTimer = new Timer(2000);
        private readonly Timer _countdownTimer = new Timer(1000);
        private readonly Timer _btcTimer = new Timer(1000);
        private readonly Timer _dataDispatchTimer = new Timer(100);
        
        private DateTime _lastRefreshed;
        private int _rowCount = 1;
        private int _dataDispatchedCount;
        private int _inProgressCount;

        private Antminers _antminers = new Antminers();
        private List<AntminerStatus> _antminerStatuses = new List<AntminerStatus>();

        private readonly string _mobileMinerUrl = ConfigurationManager.AppSettings["MobileMiner.Url"] ?? "https://api.mobileminerapp.com";
        private const string MobileMinerApiKey = "";

        private readonly NotifyIcon _notifyIcon = new NotifyIcon();

        private Settings _settings;

        private DateTime _startRefreshtTime;

        public AntViewer()
        {
            InitializeComponent();
        }

        private void AntViewer_Load(object sender, System.EventArgs e)
        {
            Text = string.Format("Spiceminer's Ant Viewer - v{0}", FileVersionInfo.GetVersionInfo(typeof(AntViewer).Assembly.Location).FileVersion);

            ThemeResolutionService.ApplicationThemeName = "Windows8";

            WindowState = FormWindowState.Maximized;

            _settings = SettingsService.GetSettings();

            #region Data Dispatch Timer

            _dataDispatchTimer.Enabled = false;
            _dataDispatchTimer.AutoReset = true;
            _dataDispatchTimer.Elapsed += _dataDispatchTimer_Elapsed;

            #endregion

            #region BTC Timer

            _btcTimer.Enabled = true;
            _btcTimer.AutoReset = true;
            _btcTimer.Elapsed += _btcTimer_Elapsed;
            _btcTimer.Start();

            #endregion
            
            #region Notify Icon

            _notifyIcon.Icon = Icon;
            _notifyIcon.BalloonTipTitle = "SAntViewer Minimized to tray";
            _notifyIcon.BalloonTipText = "SAntViewer has been minimized to tray, click to open.";
            _notifyIcon.DoubleClick += _notifyIcon_DoubleClick;
            _notifyIcon.Click += _notifyIcon_DoubleClick;

            #endregion

            #region Antminers Grid

            #region Context Menu

            var contextMenu = new ContextMenu();
            
            var details = new MenuItem("View Details");
            details.Click += details_Click;
            contextMenu.MenuItems.Add(details);

            var restart = new MenuItem("Restart");
            restart.Click += restart_Click;
            contextMenu.MenuItems.Add(restart);

            var openInBrowser = new MenuItem("Open in browser");
            openInBrowser.Click += openInBrowser_Click;
            contextMenu.MenuItems.Add(openInBrowser);

            #endregion

            grdAntminers.AutoGenerateColumns = false;
            grdAntminers.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdAntminers.AllowAddNewRow = false;
            grdAntminers.EnableGrouping = true;
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

            _antminers = AntminerService.GetAntminers();

            if (grdAntminers.Rows.Count == 0)
            {
                PopulateGrid(_antminers);
                BeginMonitoring();
            }
            else
                BeginMonitoring();
        }

        #region Context Menu Events

        void openInBrowser_Click(object sender, EventArgs e)
        {
            var id = (Guid)grdAntminers.CurrentRow.Tag;
            var antminer = _antminers.Antminer.SingleOrDefault(x => x.Id.Equals(id));
            if (antminer == null) return;

            try
            {
                var url = antminer.IpAddress;
                if (!url.Contains("http://"))
                    url = string.Format("http://{0}", url);

                var pInfo = new ProcessStartInfo(url);
                Process.Start(pInfo);
            }
            catch (Exception ex)
            {
                new ErrorDialog
                {
                    ErrorSubject = "Unable to open browser",
                    ErrorMessage = "Unable to open browser to Antminer."
                }.ShowDialog();
            }
        }

        void massRebootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = new ConfirmDialog { ConfirmSubject = "Mass Restart", ConfirmMessage = "Are you sure you want to restart all miners?" }.ShowDialog();
            if (!result.Equals(DialogResult.OK)) return;

            var errors = new List<string>();
            _antminers = AntminerService.GetAntminers();
            foreach (var ant in _antminers.Antminer)
            {
                try
                {
                    AntminerConnector.Restart(IPAddress.Parse(ant.IpAddress));
                }
                catch (Exception ex)
                {
                    errors.Add(string.Format("{0}: {1}", ant.IpAddress, ex.Message));
                }
            }

            if (errors.Count > 0)
            {
                new ErrorDialog
                {
                    ErrorSubject = "Error restarting miner(s)",
                    ErrorMessage = "Some miners error when trying to restart. Hover to see error messages.",
                    LongErrorMessage = errors.Aggregate((w, j) => string.Format("{0}\r\n{1}", w, j))
                }.ShowDialog();
            }
        }

        void restart_Click(object sender, EventArgs e)
        {
            var id = (Guid)grdAntminers.CurrentRow.Tag;
            var antminer = _antminers.Antminer.SingleOrDefault(x => x.Id.Equals(id));
            if (antminer == null) return;

            try
            {
                AntminerConnector.Restart(IPAddress.Parse(antminer.IpAddress));
                new InfoDialog { InfoSubject = "Restarting...", InfoMessage = "Restart Successful" }.ShowDialog();
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

        void _dataDispatchTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var ant in _antminers.Antminer.Skip(_dataDispatchedCount).Take(_settings.Performance.RefreshThreadCount - _inProgressCount))
            {
                _dataDispatchedCount++;

                var antminerStatusBackgroundWorker = new BackgroundWorker();
                antminerStatusBackgroundWorker.DoWork += antminerStatusBackgroundWorker_DoWork;
                antminerStatusBackgroundWorker.RunWorkerCompleted += antminerStatusBackgroundWorker_RunWorkerCompleted;
                antminerStatusBackgroundWorker.RunWorkerAsync(ant);
            }

            if (!_dataDispatchedCount.Equals(_antminerStatuses.Count)) return;

            var refreshTime = DateTime.Now.Subtract(_startRefreshtTime);
            refreshTimeToolStripMenuItem.Text = string.Format("Refresh Time: {0}.{1} seconds", refreshTime.Seconds, refreshTime.Milliseconds);
            _dataDispatchTimer.Stop();

            _refreshTimer.Interval = _settings.Performance.RefreshInterval;
            _refreshTimer.Start();

            _statsTimer.Enabled = true;
            _statsTimer.Start();

            _lastRefreshed = DateTime.Now;

            _countdownTimer.Enabled = true;
            _countdownTimer.Start();

            RunAlerts(_settings);

            if (_settings.MobileMiner.Enabled)
            {
                var mobileMinerBackgroundWorker = new BackgroundWorker();
                mobileMinerBackgroundWorker.DoWork += mobileMinerBackgroundWorker_DoWork;
                mobileMinerBackgroundWorker.RunWorkerCompleted += mobileMinerBackgroundWorker_RunWorkerCompleted;
                mobileMinerBackgroundWorker.RunWorkerAsync();
            }
        }

        void CountdownTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var timeLeft = DateTime.Now.Subtract(_lastRefreshed).Seconds;
            btnRefresh.Invoke(new MethodInvoker(() => btnRefresh.Text = string.Format("Refresh ({0})", (_settings.Performance.RefreshInterval/1000) - timeLeft)));
        }

        void StatsTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lblHashRate.Invoke(new MethodInvoker(() => lblHashRate.Text = string.Format("Hash Rate: {0}", GetFormattedHashRate())));
            lblHighestTemp.Invoke(new MethodInvoker(() => lblHighestTemp.Text = string.Format("Highest Temp: {0}", GetFormattedHighestTemp())));
            lblHighestHwe.Invoke(new MethodInvoker(() => lblHighestHwe.Text = string.Format("Highest HWE: {0}", GetFormattedHighestHardwareErrorCount())));
        }

        void RefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _antminers = AntminerService.GetAntminers();

            _antminerStatuses = new List<AntminerStatus>();

            if (grdAntminers.Rows.Count == 0)
                PopulateGrid(_antminers);

            _statsTimer.Enabled = true;
            _statsTimer.Stop();

            _countdownTimer.Enabled = false;
            _countdownTimer.Stop();
            
            _dataDispatchedCount = 0;
            _inProgressCount = 0;
            _startRefreshtTime = DateTime.Now;
            _dataDispatchTimer.Start(); 
        }

        #endregion

        #region Antminer Status Background Worker

        void antminerStatusBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var ant = e.Argument as Antminer;
            if (ant == null) return;

            _inProgressCount++;

            var status = new AntminerStatus
            {
                Id = ant.Id,
                IpAddress = ant.IpAddress,
                Name = ant.Name
            };

            var updatingRow = grdAntminers.Rows.SingleOrDefault(x => x.Tag.Equals(status.Id));
            if (updatingRow != null)
            {
                grdAntminers.Invoke(new MethodInvoker(() =>
                {
                    updatingRow.Cells[2].Value = "-------------";
                }));
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
                status.FanSpeed = Convert.ToInt32(stats["fan1"]);
                status.Temps = string.Format("{0}, {1}", stats["temp1"], stats["temp2"]);
                status.Freq = stats["frequency"].ToString();
                status.AsicStatus = string.Format("{0} - {1}", stats["chain_acs1"], stats["chain_acs2"]);
                status.WorkUtility = Convert.ToDouble(summary["Work Utility"]);
            }
            catch (Exception)
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

            e.Result = status;
        }

        void antminerStatusBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var status = e.Result as AntminerStatus;
            if (status == null) return;

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
                grdAntminers.Invoke(new MethodInvoker(() =>
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
                }));
            }
            
            _antminerStatuses.Add(status);

            _inProgressCount--;
        }

        #endregion

        #region Mobileminer Background Worker

        void mobileMinerBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var mobileMinerStatus = e.Result as List<MiningStatistics>;
            if (mobileMinerStatus == null || mobileMinerStatus.Count == 0) return;

            try
            {
                ApiContext.SubmitMiningStatistics(_mobileMinerUrl,
                    MobileMinerApiKey,
                    _settings.MobileMiner.EmailAddress,
                    _settings.MobileMiner.ApplicationKey,
                    mobileMinerStatus);
            }
            catch (Exception)
            {

            }
        }

        void mobileMinerBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var mobileMinerStatus = (from status in _antminerStatuses
                let pools = AntminerConnector.GetPools(IPAddress.Parse(status.IpAddress))
                let devs = AntminerConnector.GetDev(IPAddress.Parse(status.IpAddress))
                select new MiningStatistics
                {
                    Index = 0, 
                    DeviceID = Convert.ToInt32(devs["ID"]), 
                    AcceptedShares = Convert.ToInt32(devs["Accepted"]),
                    Algorithm = "SHA-256", Kind = "ASC", 
                    Appliance = false,
                    AverageHashrate = Convert.ToDouble(devs["MHS av"]), 
                    CurrentHashrate = Convert.ToDouble(devs["MHS 5s"]), 
                    Enabled = true, 
                    FanSpeed = status.FanSpeed,
                    FullName = status.Name,
                    HardwareErrors = Convert.ToInt32(devs["Hardware Errors"]), 
                    HardwareErrorsPercent = status.HardwareErrorPercentage,
                    MachineName = status.Name, 
                    MinerName = "Spiceminer's Ant Viewer", 
                    Name = status.Name,
                    RejectedShares = Convert.ToInt32(devs["Rejected"]), 
                    RejectedSharesPercent = status.RejectPercentage, 
                    Status = status.Status,
                    Temperature = GetHighestTemp(status.Temps),
                    Utility = status.WorkUtility, 
                    FanPercent = 0, 
                    GpuActivity = 0, 
                    GpuClock = 0, 
                    GpuVoltage = 0,
                    Intensity = "0", 
                    MemoryClock = 0, 
                    PoolIndex = 0, 
                    PoolName = pools[0]["URL"].ToString(), 
                    PowerTune = 0,
                }).ToList();

            e.Result = mobileMinerStatus;
        }

        #endregion

        #region BTC Price Background Worker

        void _btcTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var btcBackgroundWorker = new BackgroundWorker();
            btcBackgroundWorker.DoWork += btcBackgroundWorker_DoWork;
            btcBackgroundWorker.RunWorkerCompleted += btcBackgroundWorker_RunWorkerCompleted;
            btcBackgroundWorker.RunWorkerAsync();

            _btcTimer.Interval = 30000;
        }

        void btcBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            double btcPrice;
            double.TryParse(e.Result.ToString(), out btcPrice);
            btcToolTipMenu.Text = double.TryParse(e.Result.ToString(), out btcPrice) ? string.Format("BTC: ${0}", btcPrice) : "BTC: ---";
        }

        void btcBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = BtcPriceService.GetBtcPrice();
        }

        #endregion

        #region Button Clicks

        private void btnManageAntminers_Click(object sender, System.EventArgs e)
        {
            new ManageAntminers().ShowDialog();

            _rowCount = 1;
            grdAntminers.Rows.Clear();
            _refreshTimer.Interval = 1000;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _refreshTimer.Interval = 100;
        }

        #endregion

        #region Helpers

        public void BeginMonitoring()
        {
            _refreshTimer.Elapsed += RefreshTimer_Elapsed;
            _refreshTimer.AutoReset = false;
            _refreshTimer.Start();

            _statsTimer.Elapsed += StatsTimer_Elapsed;
            _statsTimer.AutoReset = true;
            _statsTimer.Enabled = false;

            _countdownTimer.Elapsed += CountdownTimer_Elapsed;
            _countdownTimer.AutoReset = true;
            _countdownTimer.Enabled = false;
        }

        public void PopulateGrid(Antminers ants)
        {
            var rows = new List<GridViewRowInfo>();
            foreach (var ant in ants.Antminer)
            {
                var rowInfo = new GridViewRowInfo(grdAntminers.MasterView) { Tag = ant.Id };

                rowInfo.Cells[0].Value = ant.Id;
                rowInfo.Cells[1].Value = _rowCount++;
                rowInfo.Cells[2].Value = DateTime.Now.ToString("h:mm:ss tt");
                rowInfo.Cells[3].Value = ant.IpAddress;
                rowInfo.Cells[4].Value = ant.Name;
                rowInfo.Cells[5].Value = "-------------";
                rowInfo.Cells[6].Value = 0;
                rowInfo.Cells[7].Value = 0;
                rowInfo.Cells[8].Value = 0;
                rowInfo.Cells[9].Value = "-";
                rowInfo.Cells[10].Value = 0;
                rowInfo.Cells[11].Value = 0;
                rowInfo.Cells[12].Value = 0;
                rowInfo.Cells[13].Value = "-";
                rowInfo.Cells[14].Value = "-";
                rowInfo.Cells[15].Value = "-";
                rowInfo.Cells[16].Value = "-";
                
                rows.Add(rowInfo);
            }

            if (grdAntminers.InvokeRequired)
                grdAntminers.Invoke(new MethodInvoker(() => grdAntminers.Rows.AddRange(rows.ToArray())));
            else
                grdAntminers.Rows.AddRange(rows.ToArray());
        }

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

        public double GetHighestTemp(string temps)
        {
            try
            {
                var allTemps = temps.Replace(" ", string.Empty).Split(new[] { ',' });
                var temp1 = Convert.ToInt32(allTemps[0]);
                var temp2 = Convert.ToInt32(allTemps[1]);

                return temp1 > temp2 ? temp1 : temp2;
            }
            catch (Exception)
            {
                
            }

            return 0;
        }

        public string GetFormattedHighestHardwareErrorCount()
        {
            if (grdAntminers.RowCount < 1) return "-";
            return string.Format("{0}%", grdAntminers.Rows.Max(r => Convert.ToDouble(r.Cells[9].Value)));
        }
        
        #endregion

        #region Menu Events

        private void performanceSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PerformanceSettings().ShowDialog();
            _settings = SettingsService.GetSettings();
            _rowCount = 1;
            grdAntminers.Rows.Clear();
            _countdownTimer.Stop();
            _refreshTimer.Interval = 1000;
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EmailSettings().ShowDialog();
            _settings = SettingsService.GetSettings();
        }

        private void emailSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ManageAlerts().ShowDialog();
            _settings = SettingsService.GetSettings();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MobileMiner().ShowDialog();
            _settings = SettingsService.GetSettings();
        }

        private void onlineStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var url = ConfigurationManager.AppSettings["MobileMiner.DashboardUrl"] ?? "http://web.mobileminerapp.com/";
                var pInfo = new ProcessStartInfo(url);
                Process.Start(pInfo);
            }
            catch (Exception)
            {
                new ErrorDialog
                {
                    ErrorSubject = "Unable to open browser",
                    ErrorMessage = "Unable to open browser to mobileminer web dashboard."
                }.ShowDialog();
            }
        }

        #endregion

        #region Notify Events

        private void mnuMain_Resize(object sender, EventArgs e)
        {
            if (!WindowState.Equals(FormWindowState.Minimized)) return;

            Hide();
            _notifyIcon.Visible = true;
            _notifyIcon.ShowBalloonTip(3000);
        }

        void _notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            _notifyIcon.Visible = false;
            WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region Alerts

        private void RunAlerts(Settings settings)
        {
            var errors = new List<string>();
            foreach (var a in settings.Alerts.Where(a => a.Enabled))
            {
                try
                {
                    a.Run(_antminerStatuses);
                }
                catch (Exception ex)
                {
                    errors.Add(ex.Message);
                }
            }

            if (errors.Count > 0)
                new ErrorDialog
                {
                    ErrorSubject = "Error running alerts",
                    ErrorMessage = "Error running alerts, hover to see all errors.",
                    LongErrorMessage = errors.Aggregate((w, j) => string.Format("{0}\r\n{1}", w, j))
                }.ShowDialog();

            SettingsService.SaveSettings(settings);
        }

        #endregion
    }
}
