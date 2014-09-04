namespace AntViewer
{
    partial class AntViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AntViewer));
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdAntminers = new Telerik.WinControls.UI.RadGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHighestHwe = new Telerik.WinControls.UI.RadLabel();
            this.lblHighestTemp = new Telerik.WinControls.UI.RadLabel();
            this.lblHashRate = new Telerik.WinControls.UI.RadLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDonate = new Telerik.WinControls.UI.RadLabel();
            this.txtDonate = new Telerik.WinControls.UI.RadTextBox();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.btnManageAntminers = new Telerik.WinControls.UI.RadButton();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alertsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailSettingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.emailSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massRebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mobileMinerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btcToolTipMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAntminers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAntminers.MasterTemplate)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblHighestHwe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHighestTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHashRate)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblDonate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnManageAntminers)).BeginInit();
            this.mnuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 615F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 687F));
            this.tableLayoutPanel1.Controls.Add(this.grdAntminers, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 654F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1302, 715);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grdAntminers
            // 
            this.grdAntminers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.grdAntminers, 2);
            this.grdAntminers.Location = new System.Drawing.Point(3, 41);
            this.grdAntminers.Name = "grdAntminers";
            this.grdAntminers.Size = new System.Drawing.Size(1296, 671);
            this.grdAntminers.TabIndex = 0;
            this.grdAntminers.Text = "radGridView1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.lblHighestHwe);
            this.panel1.Controls.Add(this.lblHighestTemp);
            this.panel1.Controls.Add(this.lblHashRate);
            this.panel1.Location = new System.Drawing.Point(618, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 32);
            this.panel1.TabIndex = 2;
            // 
            // lblHighestHwe
            // 
            this.lblHighestHwe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighestHwe.Location = new System.Drawing.Point(505, 4);
            this.lblHighestHwe.Name = "lblHighestHwe";
            this.lblHighestHwe.Size = new System.Drawing.Size(112, 25);
            this.lblHighestHwe.TabIndex = 2;
            this.lblHighestHwe.Text = "Highest HWE: ";
            this.lblHighestHwe.ThemeName = "Windows8";
            // 
            // lblHighestTemp
            // 
            this.lblHighestTemp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighestTemp.Location = new System.Drawing.Point(298, 4);
            this.lblHighestTemp.Name = "lblHighestTemp";
            this.lblHighestTemp.Size = new System.Drawing.Size(113, 25);
            this.lblHighestTemp.TabIndex = 1;
            this.lblHighestTemp.Text = "Highest Temp:";
            // 
            // lblHashRate
            // 
            this.lblHashRate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHashRate.Location = new System.Drawing.Point(3, 4);
            this.lblHashRate.Name = "lblHashRate";
            this.lblHashRate.Size = new System.Drawing.Size(76, 25);
            this.lblHashRate.TabIndex = 0;
            this.lblHashRate.Text = "Hashrate:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDonate);
            this.panel2.Controls.Add(this.txtDonate);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnManageAntminers);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(609, 32);
            this.panel2.TabIndex = 3;
            // 
            // lblDonate
            // 
            this.lblDonate.Location = new System.Drawing.Point(322, 7);
            this.lblDonate.Name = "lblDonate";
            this.lblDonate.Size = new System.Drawing.Size(45, 18);
            this.lblDonate.TabIndex = 5;
            this.lblDonate.Text = "Donate:";
            // 
            // txtDonate
            // 
            this.txtDonate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDonate.Location = new System.Drawing.Point(373, 7);
            this.txtDonate.Name = "txtDonate";
            this.txtDonate.ReadOnly = true;
            this.txtDonate.Size = new System.Drawing.Size(230, 20);
            this.txtDonate.TabIndex = 4;
            this.txtDonate.Text = "1635WqpWgwwJhS9txZB8Kg87Yt4RGtgaCC";
            this.txtDonate.ThemeName = "Windows8";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(161, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(155, 32);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.ThemeName = "Windows8";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnManageAntminers
            // 
            this.btnManageAntminers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageAntminers.Location = new System.Drawing.Point(0, 0);
            this.btnManageAntminers.Name = "btnManageAntminers";
            this.btnManageAntminers.Size = new System.Drawing.Size(155, 32);
            this.btnManageAntminers.TabIndex = 2;
            this.btnManageAntminers.Text = "Manage AntMiners";
            this.btnManageAntminers.ThemeName = "Windows8";
            this.btnManageAntminers.Click += new System.EventHandler(this.btnManageAntminers_Click);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.alertsToolStripMenuItem,
            this.massRebootToolStripMenuItem,
            this.mobileMinerToolStripMenuItem,
            this.btcToolTipMenu});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1302, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            this.mnuMain.Resize += new System.EventHandler(this.mnuMain_Resize);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // alertsToolStripMenuItem
            // 
            this.alertsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailSettingsToolStripMenuItem1,
            this.emailSettingsToolStripMenuItem});
            this.alertsToolStripMenuItem.Name = "alertsToolStripMenuItem";
            this.alertsToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.alertsToolStripMenuItem.Text = "Alerts";
            // 
            // emailSettingsToolStripMenuItem1
            // 
            this.emailSettingsToolStripMenuItem1.Name = "emailSettingsToolStripMenuItem1";
            this.emailSettingsToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.emailSettingsToolStripMenuItem1.Text = "Email Settings";
            this.emailSettingsToolStripMenuItem1.Click += new System.EventHandler(this.emailSettingsToolStripMenuItem1_Click);
            // 
            // emailSettingsToolStripMenuItem
            // 
            this.emailSettingsToolStripMenuItem.Name = "emailSettingsToolStripMenuItem";
            this.emailSettingsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.emailSettingsToolStripMenuItem.Text = "Alert Settings";
            this.emailSettingsToolStripMenuItem.Click += new System.EventHandler(this.emailSettingsToolStripMenuItem_Click);
            // 
            // massRebootToolStripMenuItem
            // 
            this.massRebootToolStripMenuItem.Name = "massRebootToolStripMenuItem";
            this.massRebootToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.massRebootToolStripMenuItem.Text = "Mass Restart";
            this.massRebootToolStripMenuItem.Click += new System.EventHandler(this.massRebootToolStripMenuItem_Click);
            // 
            // mobileMinerToolStripMenuItem
            // 
            this.mobileMinerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem,
            this.onlineStatsToolStripMenuItem});
            this.mobileMinerToolStripMenuItem.Name = "mobileMinerToolStripMenuItem";
            this.mobileMinerToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.mobileMinerToolStripMenuItem.Text = "MobileMiner";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.setupToolStripMenuItem.Text = "Setup";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
            // 
            // onlineStatsToolStripMenuItem
            // 
            this.onlineStatsToolStripMenuItem.Name = "onlineStatsToolStripMenuItem";
            this.onlineStatsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.onlineStatsToolStripMenuItem.Text = "View Online Stats";
            this.onlineStatsToolStripMenuItem.Click += new System.EventHandler(this.onlineStatsToolStripMenuItem_Click);
            // 
            // btcToolTipMenu
            // 
            this.btcToolTipMenu.Name = "btcToolTipMenu";
            this.btcToolTipMenu.Size = new System.Drawing.Size(62, 20);
            this.btcToolTipMenu.Text = "BTC: ---";
            // 
            // AntViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 739);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AntViewer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Spiceminer\'s Ant Viewer";
            this.ThemeName = "Windows8";
            this.Load += new System.EventHandler(this.AntViewer_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAntminers.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAntminers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblHighestHwe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHighestTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHashRate)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblDonate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnManageAntminers)).EndInit();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadGridView grdAntminers;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadLabel lblHighestHwe;
        private Telerik.WinControls.UI.RadLabel lblHighestTemp;
        private Telerik.WinControls.UI.RadLabel lblHashRate;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadButton btnRefresh;
        private Telerik.WinControls.UI.RadButton btnManageAntminers;
        private Telerik.WinControls.UI.RadTextBox txtDonate;
        private Telerik.WinControls.UI.RadLabel lblDonate;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alertsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massRebootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mobileMinerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlineStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailSettingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btcToolTipMenu;


    }
}