using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using AntViewer.Communication.Antminer;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace AntViewer.UserControls.Antminer
{
    public partial class AntminerDetails : UserControl
    {
        public IPAddress Ip { get; set; }

        private readonly BackgroundWorker _summaryBackgroundWorker = new BackgroundWorker();
        private readonly BackgroundWorker _poolBackgroundWorker = new BackgroundWorker();
        private readonly BackgroundWorker _antMinerBackgroundWorker = new BackgroundWorker();

        private IDictionary<string, object> _summaryData;
        private List<IDictionary<string, object>> _poolData;
        private IDictionary<string, object> _antMinerData; 

        public AntminerDetails()
        {
            InitializeComponent();
        }

        private void AntminerS1_Load(object sender, EventArgs e)
        {
            ThemeResolutionService.ApplicationThemeName = "Windows8";

            pnlLayout.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Dock = DockStyle.Fill;
            pnlSummary.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            pnlPools.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            pnlAntminer.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            #region Summary

            grdSummary.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            grdSummary.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdSummary.AllowAddNewRow = false;
            grdSummary.EnableGrouping = false;
            grdSummary.AllowCellContextMenu = false;

            //grdSummary.Columns.Add("Elapsed", "Elapsed", "Elapsed");
            grdSummary.Columns.Add("GHS5S", "GH/S (5s)", "GHS5S");
            grdSummary.Columns.Add("GHSAv", "GH/S Av", "GHSAv");
            grdSummary.Columns.Add("FoundBlocks", "Found Blocks", "FoundBlocks");
            grdSummary.Columns.Add("Getworks", "Get Works", "Getworks");
            grdSummary.Columns.Add("Accepted", "Accepted", "Accepted");
            grdSummary.Columns.Add("Rejected", "Rejected", "Rejected");
            grdSummary.Columns.Add("Hardware Errors", "HW", "HardwareErrors");
            grdSummary.Columns.Add("Utility", "Utility", "Utility");
            grdSummary.Columns.Add("Discarded", "Discarded", "Discarded");
            grdSummary.Columns.Add("Stale", "Stale", "Stale");
            grdSummary.Columns.Add("LocalWork", "Local Work", "LocalWork");
            grdSummary.Columns.Add("WorkUtility", "WU", "WorkUtility");
            grdSummary.Columns.Add("DifficultyAccepted", "DiffA", "DifficultyAccepted");
            grdSummary.Columns.Add("DifficultyRejected", "DiffR", "DifficultyRejected");
            grdSummary.Columns.Add("DifficultyStale", "DiffS", "DifficultyStale");
            grdSummary.Columns.Add("BestShare", "Best Share", "BestShare");

            _summaryBackgroundWorker.DoWork += _summaryBackgroundWorker_DoWork;
            _summaryBackgroundWorker.RunWorkerCompleted += _summaryBackgroundWorker_RunWorkerCompleted;
            _summaryBackgroundWorker.RunWorkerAsync();

            #endregion

            #region Pools

            grdPools.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            grdPools.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdPools.AllowAddNewRow = false;
            grdPools.EnableGrouping = false;
            grdPools.AllowCellContextMenu = false;

            grdPools.Columns.Add("Pool", "Pool", "Pool");
            grdPools.Columns.Add("URL", "URL", "URL");
            grdPools.Columns.Add("User", "User", "User");
            grdPools.Columns.Add("Status", "Status", "Status");
            grdPools.Columns.Add("Priority", "Priority", "Priority");
            grdPools.Columns.Add("GetWorks", "GetWorks", "GetWorks");
            grdPools.Columns.Add("Accepted", "Accepted", "Accepted");
            grdPools.Columns.Add("Rejected", "Rejected", "Rejected");
            grdPools.Columns.Add("Discarded", "Discarded", "Discarded");
            grdPools.Columns.Add("Stale", "Stale", "Stale");
            grdPools.Columns.Add("Diff", "Diff", "Diff");
            grdPools.Columns.Add("Diff1Number", "Diff1#", "Diff1Number");
            grdPools.Columns.Add("DiffANumber", "DiffA#", "DiffANumber");
            grdPools.Columns.Add("DiffRNumber", "DiffR#", "DiffRNumber");
            grdPools.Columns.Add("DiffSNumber", "DiffS#", "DiffSNumber");
            grdPools.Columns.Add("LSDiff", "LSDiff", "LSDiff");
            grdPools.Columns.Add("LSTime", "LSTime", "LSTime");

            _poolBackgroundWorker.DoWork += _poolBackgroundWorker_DoWork;
            _poolBackgroundWorker.RunWorkerCompleted += _poolBackgroundWorker_RunWorkerCompleted;
            _poolBackgroundWorker.RunWorkerAsync();

            #endregion

            #region AntMiner

            grdAntMiner.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            grdAntMiner.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdAntMiner.AllowAddNewRow = false;
            grdAntMiner.EnableGrouping = false;
            grdAntMiner.AllowCellContextMenu = false;
            
            grdAntMiner.Columns.Add("ChainNumber", "Chain#", "ChainNumber");
            grdAntMiner.Columns.Add("AsicNumber", "ASIC#", "AsicNumber");
            grdAntMiner.Columns.Add("Frequency", "Frequency", "Frequency");
            grdAntMiner.Columns.Add("Fan", "Fan", "Fan");
            grdAntMiner.Columns.Add("Temp", "Temp", "Temp");
            grdAntMiner.Columns.Add("AsicStatus", "ASIC Status", "AsicStatus");

            _antMinerBackgroundWorker.DoWork += _antMinerBackgroundWorker_DoWork;
            _antMinerBackgroundWorker.RunWorkerCompleted += _antMinerBackgroundWorker_RunWorkerCompleted;
            _antMinerBackgroundWorker.RunWorkerAsync();

            #endregion
        }

        #region Summary Background Worker

        void _summaryBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _summaryData = AntminerConnector.GetSummary(Ip);
            }
            catch (Exception)
            {
                
            }
        }

        void _summaryBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_summaryData == null || _summaryData.Count < 1) return;

            grdSummary.Rows.Clear();
            var data = new
            {
                //Elapsed = _summaryData["Elapsed"],
                GHS5S = _summaryData["GHS 5s"],
                GHSAv = _summaryData["GHS av"],
                FoundBlocks = _summaryData["Found Blocks"],
                GetWorks = _summaryData["Getworks"],
                Accepted = _summaryData["Accepted"],
                Rejected = _summaryData["Rejected"],
                HardwareErrors = _summaryData["Hardware Errors"],
                Utility = _summaryData["Utility"],
                Discarded = _summaryData["Discarded"],
                Stale = _summaryData["Stale"],
                LocalWork = _summaryData["Local Work"],
                WorkUtility = _summaryData["Work Utility"],
                DifficultyAccepted = _summaryData["Difficulty Accepted"],
                DifficultyRejected = _summaryData["Difficulty Rejected"],
                DifficultyStale = _summaryData["Difficulty Stale"],
                BestShare = _summaryData["Best Share"]
            };

            grdSummary.DataSource = new List<object> {data};
        }

        #endregion

        #region Pool Background Worker

        void _poolBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _poolData = AntminerConnector.GetPools(Ip);
            }
            catch (Exception)
            {
                
            }
        }

        void _poolBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            grdPools.Rows.Clear();

            if (_poolData == null || _poolData.Count < 1) return;

            var data = new List<object>();

            foreach (var p in _poolData)
            {
                data.Add(new
                {
                    Pool = p["POOL"],
                    URL = p["URL"],
                    User = p["User"],
                    Status = p["Status"],
                    Priority = p["Priority"],
                    GetWorks = p["Getworks"],
                    Accepted = p["Accepted"],
                    Rejected = p["Rejected"],
                    Discarded = p["Discarded"],
                    Stale = p["Stale"],
                    Diff = p["Diff"],
                    Diff1Number = p["Diff1 Shares"],
                    DiffANumber = p["Difficulty Accepted"],
                    DiffRNumber = p["Difficulty Rejected"],
                    DiffSNumber = p["Difficulty Stale"],
                    LSDiff = p["Last Share Difficulty"],
                    LSTime = p["Last Share Time"]
                });
            }

            grdPools.DataSource = data;
        }

        #endregion

        #region AntMiner Background Worker

        void _antMinerBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _antMinerData = AntminerConnector.GetStats(Ip);
            }
            catch (Exception)
            {
                
            }
        }

        void _antMinerBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            grdAntMiner.Rows.Clear();

            if (_antMinerData == null || _antMinerData.Count < 1) return;

            var data1 = new
            {
                ChainNumber = 1,
                AsicNumber = _antMinerData["chain_acn1"],
                Frequency = _antMinerData["frequency"],
                Fan = _antMinerData["fan1"],
                Temp = _antMinerData["temp1"],
                AsicStatus = _antMinerData["chain_acs1"]
            };

            var data2 = new
            {
                ChainNumber = 2,
                AsicNumber = _antMinerData["chain_acn2"],
                Frequency = _antMinerData["frequency"],
                Fan = _antMinerData["fan2"],
                Temp = _antMinerData["temp2"],
                AsicStatus = _antMinerData["chain_acs2"]
            };

            grdAntMiner.DataSource = new List<object> {data1, data2};
        }

        #endregion
    }
}
