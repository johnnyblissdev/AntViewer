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
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdAntminers = new Telerik.WinControls.UI.RadGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHighestHwe = new Telerik.WinControls.UI.RadLabel();
            this.lblHighestTemp = new Telerik.WinControls.UI.RadLabel();
            this.lblHashRate = new Telerik.WinControls.UI.RadLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.btnManageAntminers = new Telerik.WinControls.UI.RadButton();
            this.txtDonate = new Telerik.WinControls.UI.RadTextBox();
            this.lblDonate = new Telerik.WinControls.UI.RadLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAntminers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAntminers.MasterTemplate)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblHighestHwe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHighestTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHashRate)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnManageAntminers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDonate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 637F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 418F));
            this.tableLayoutPanel1.Controls.Add(this.grdAntminers, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 626F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1122, 664);
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
            this.grdAntminers.Size = new System.Drawing.Size(1116, 620);
            this.grdAntminers.TabIndex = 0;
            this.grdAntminers.Text = "radGridView1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblHighestHwe);
            this.panel1.Controls.Add(this.lblHighestTemp);
            this.panel1.Controls.Add(this.lblHashRate);
            this.panel1.Location = new System.Drawing.Point(640, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 32);
            this.panel1.TabIndex = 2;
            // 
            // lblHighestHwe
            // 
            this.lblHighestHwe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighestHwe.Location = new System.Drawing.Point(331, 3);
            this.lblHighestHwe.Name = "lblHighestHwe";
            this.lblHighestHwe.Size = new System.Drawing.Size(112, 25);
            this.lblHighestHwe.TabIndex = 2;
            this.lblHighestHwe.Text = "Highest HWE: ";
            this.lblHighestHwe.ThemeName = "Windows8";
            // 
            // lblHighestTemp
            // 
            this.lblHighestTemp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighestTemp.Location = new System.Drawing.Point(170, 4);
            this.lblHighestTemp.Name = "lblHighestTemp";
            this.lblHighestTemp.Size = new System.Drawing.Size(113, 25);
            this.lblHighestTemp.TabIndex = 1;
            this.lblHighestTemp.Text = "Highest Temp:";
            // 
            // lblHashRate
            // 
            this.lblHashRate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHashRate.Location = new System.Drawing.Point(4, 4);
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
            this.panel2.Size = new System.Drawing.Size(631, 32);
            this.panel2.TabIndex = 3;
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
            // lblDonate
            // 
            this.lblDonate.Location = new System.Drawing.Point(322, 7);
            this.lblDonate.Name = "lblDonate";
            this.lblDonate.Size = new System.Drawing.Size(45, 18);
            this.lblDonate.TabIndex = 5;
            this.lblDonate.Text = "Donate:";
            // 
            // AntViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 664);
            this.Controls.Add(this.tableLayoutPanel1);
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
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnManageAntminers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDonate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

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


    }
}