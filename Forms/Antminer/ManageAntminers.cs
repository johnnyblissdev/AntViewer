using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using AntViewer.API;
using AntViewer.Communication.Antminer;
using AntViewer.DataService.Antminer;
using AntViewer.Forms.Common;
using Telerik.WinControls.UI;

namespace AntViewer.Forms.Antminer
{
    public partial class ManageAntminers : RadForm
    {
        public Antminers Antminers { get; set; } 

        private readonly BackgroundWorker _scanBackgroundWorker = new BackgroundWorker();

        public ManageAntminers()
        {
            InitializeComponent();
        }

        private void ManageAntminers_Load(object sender, System.EventArgs e)
        {
            Antminers = AntminerService.GetAntminers();

            txtIpAddress.KeyPress += txtIpAddress_KeyPress;

            ddlScanIpRange.Items.Add(new RadListDataItem("192.168.1.*", 1));
            ddlScanIpRange.Items.Add(new RadListDataItem("192.168.2.*", 2));
            ddlScanIpRange.SelectedIndex = 0;

            PopulateAntminers();

            #region Scan

            _scanBackgroundWorker.WorkerReportsProgress = true;
            _scanBackgroundWorker.DoWork += _scanBackgroundWorker_DoWork;
            _scanBackgroundWorker.RunWorkerCompleted += _scanBackgroundWorker_RunWorkerCompleted;
            _scanBackgroundWorker.ProgressChanged += _scanBackgroundWorker_ProgressChanged;

            #endregion

            #region Antminer Grid

            var contextMenu = new ContextMenu();
            var deleteMenuItem = new MenuItem("Delete");
            deleteMenuItem.Click += deleteMenuItem_Click;
            contextMenu.MenuItems.Add(deleteMenuItem);

            grdAntminers.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdAntminers.AllowAddNewRow = false;
            grdAntminers.EnableGrouping = false;
            grdAntminers.AllowDeleteRow = false;
            grdAntminers.AllowEditRow = false;
            grdAntminers.AllowCellContextMenu = false;
            grdAntminers.ContextMenu = contextMenu;

            #endregion
        }

        void _scanBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbScan.Value1 = e.ProgressPercentage;
            PopulateAntminers();
        }

        #region Scan background worker

        void _scanBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SaveAntminers();
        }

        void _scanBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var sn = ddlScanIpRange.SelectedItem.Value;

            for (var i = 1; i < 255; i++)
            {
                var ipAddress = IPAddress.Parse(string.Format("192.168.{0}.{1}", sn, i));

                pgbScan.Text = ipAddress.ToString();

                try
                {
                    if (AntminerConnector.Exists(ipAddress))
                    {
                        var antminer = new API.Antminer
                        {
                            Id = Guid.NewGuid(),
                            Name = ipAddress.ToString(),
                            IpAddress = ipAddress.ToString(),
                            SshUsername = txtSshUsername.Text,
                            SshPassword = txtSshPassword.Text
                        };

                        Antminers.Antminer.Add(antminer);
                    }
                }
                catch (Exception)
                {
                    
                }

                var progress = (((double) i)/255)*100;
                
                var backgroundWorker = sender as BackgroundWorker;
                if (backgroundWorker != null) backgroundWorker.ReportProgress((int)progress);
            }

            PopulateAntminers();
        }

        #endregion

        #region Events

        void txtIpAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!e.KeyChar.Equals((Char) 13)) return;

            btnAdd.PerformClick();
        }
        
        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            var antminer = new API.Antminer
            {
                Id = Guid.NewGuid(),
                Name = txtName.Text,
                IpAddress = txtIpAddress.Text,
                SshUsername = txtSshUsername.Text,
                SshPassword = txtSshPassword.Text
            };

            Antminers.Antminer.Add(antminer);
            
            SaveAntminers();
            PopulateAntminers();

            txtName.Text = "";
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSshUsername.Text) || string.IsNullOrEmpty(txtSshPassword.Text))
            {
                new ErrorDialog
                {
                    ErrorMessage = "Please enter a SSH Username and Password to be autopopulated when miners are found.",
                    ErrorSubject = "Error"
                }.ShowDialog();

                return;
            }

            pgbScan.Visible = true;
            btnScanDone.Visible = true;
            _scanBackgroundWorker.RunWorkerAsync();
        }

        #endregion

        private void SaveAntminers()
        {
            AntminerService.SaveAntminers(Antminers);
        }

        private void PopulateAntminers()
        {
            grdAntminers.DataSource = null;
            grdAntminers.DataSource = Antminers.Antminer;
            grdAntminers.Columns[0].IsVisible = false;
        }

        #region Context Menu Events

        void deleteMenuItem_Click(object sender, EventArgs e)
        {
            var id = (Guid)grdAntminers.CurrentRow.Cells[0].Value;
            Antminers.Antminer.Remove(Antminers.Antminer.SingleOrDefault(x => x.Id.Equals(id)));

            SaveAntminers();
            PopulateAntminers();
        }

        #endregion

        private void btnScanDone_Click(object sender, EventArgs e)
        {
            pgbScan.Visible = false;
            btnScanDone.Visible = false;

            SaveAntminers();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            Antminers.Antminer = new List<API.Antminer>();
            PopulateAntminers();
            SaveAntminers();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            SaveAntminers();
            Close();
        }
    }
}
