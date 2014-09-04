namespace AntViewer.Forms.Antminer
{
    partial class ManageAntminers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageAntminers));
            this.lblName = new Telerik.WinControls.UI.RadLabel();
            this.txtName = new Telerik.WinControls.UI.RadTextBox();
            this.txtIpAddress = new Telerik.WinControls.UI.RadTextBox();
            this.lblIpAddress = new Telerik.WinControls.UI.RadLabel();
            this.txtSshUsername = new Telerik.WinControls.UI.RadTextBox();
            this.lblSshUsername = new Telerik.WinControls.UI.RadLabel();
            this.txtSshPassword = new Telerik.WinControls.UI.RadTextBox();
            this.lblSshPassword = new Telerik.WinControls.UI.RadLabel();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.grdAntminers = new Telerik.WinControls.UI.RadGridView();
            this.btnScan = new Telerik.WinControls.UI.RadButton();
            this.ddlScanIpRange = new Telerik.WinControls.UI.RadDropDownList();
            this.pgbScan = new Telerik.WinControls.UI.RadProgressBar();
            this.btnScanDone = new Telerik.WinControls.UI.RadButton();
            this.btnDeleteAll = new Telerik.WinControls.UI.RadButton();
            this.btnDone = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIpAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIpAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSshUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSshUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSshPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSshPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAntminers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAntminers.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnScan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlScanIpRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgbScan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnScanDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(67, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 25);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            this.lblName.ThemeName = "Windows8";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(128, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(371, 27);
            this.txtName.TabIndex = 1;
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIpAddress.Location = new System.Drawing.Point(128, 46);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(371, 27);
            this.txtIpAddress.TabIndex = 3;
            // 
            // lblIpAddress
            // 
            this.lblIpAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpAddress.Location = new System.Drawing.Point(34, 46);
            this.lblIpAddress.Name = "lblIpAddress";
            this.lblIpAddress.Size = new System.Drawing.Size(88, 25);
            this.lblIpAddress.TabIndex = 2;
            this.lblIpAddress.Text = "Ip Address:";
            this.lblIpAddress.ThemeName = "Windows8";
            // 
            // txtSshUsername
            // 
            this.txtSshUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSshUsername.Location = new System.Drawing.Point(128, 79);
            this.txtSshUsername.Name = "txtSshUsername";
            this.txtSshUsername.Size = new System.Drawing.Size(371, 27);
            this.txtSshUsername.TabIndex = 5;
            // 
            // lblSshUsername
            // 
            this.lblSshUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSshUsername.Location = new System.Drawing.Point(8, 77);
            this.lblSshUsername.Name = "lblSshUsername";
            this.lblSshUsername.Size = new System.Drawing.Size(114, 25);
            this.lblSshUsername.TabIndex = 4;
            this.lblSshUsername.Text = "Ssh Username:";
            this.lblSshUsername.ThemeName = "Windows8";
            // 
            // txtSshPassword
            // 
            this.txtSshPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSshPassword.Location = new System.Drawing.Point(128, 112);
            this.txtSshPassword.Name = "txtSshPassword";
            this.txtSshPassword.Size = new System.Drawing.Size(371, 27);
            this.txtSshPassword.TabIndex = 7;
            // 
            // lblSshPassword
            // 
            this.lblSshPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSshPassword.Location = new System.Drawing.Point(12, 112);
            this.lblSshPassword.Name = "lblSshPassword";
            this.lblSshPassword.Size = new System.Drawing.Size(110, 25);
            this.lblSshPassword.TabIndex = 6;
            this.lblSshPassword.Text = "Ssh Password:";
            this.lblSshPassword.ThemeName = "Windows8";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(157, 145);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 24);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.ThemeName = "Windows8";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grdAntminers
            // 
            this.grdAntminers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAntminers.Location = new System.Drawing.Point(-2, 175);
            this.grdAntminers.Name = "grdAntminers";
            this.grdAntminers.Size = new System.Drawing.Size(829, 427);
            this.grdAntminers.TabIndex = 9;
            this.grdAntminers.Text = "radGridView1";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(505, 13);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(110, 24);
            this.btnScan.TabIndex = 9;
            this.btnScan.Text = "Scan";
            this.btnScan.ThemeName = "Windows8";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // ddlScanIpRange
            // 
            this.ddlScanIpRange.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ddlScanIpRange.Location = new System.Drawing.Point(621, 13);
            this.ddlScanIpRange.Name = "ddlScanIpRange";
            this.ddlScanIpRange.Size = new System.Drawing.Size(160, 27);
            this.ddlScanIpRange.TabIndex = 10;
            this.ddlScanIpRange.ThemeName = "Windows8";
            // 
            // pgbScan
            // 
            this.pgbScan.Location = new System.Drawing.Point(505, 44);
            this.pgbScan.Name = "pgbScan";
            this.pgbScan.Size = new System.Drawing.Size(160, 24);
            this.pgbScan.TabIndex = 11;
            this.pgbScan.ThemeName = "Windows8";
            this.pgbScan.Visible = false;
            // 
            // btnScanDone
            // 
            this.btnScanDone.Location = new System.Drawing.Point(671, 44);
            this.btnScanDone.Name = "btnScanDone";
            this.btnScanDone.Size = new System.Drawing.Size(110, 24);
            this.btnScanDone.TabIndex = 12;
            this.btnScanDone.Text = "Done";
            this.btnScanDone.ThemeName = "Windows8";
            this.btnScanDone.Visible = false;
            this.btnScanDone.Click += new System.EventHandler(this.btnScanDone_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(273, 145);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(110, 24);
            this.btnDeleteAll.TabIndex = 13;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.ThemeName = "Windows8";
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(389, 145);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(110, 24);
            this.btnDone.TabIndex = 14;
            this.btnDone.Text = "Done";
            this.btnDone.ThemeName = "Windows8";
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // ManageAntminers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 600);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnScanDone);
            this.Controls.Add(this.pgbScan);
            this.Controls.Add(this.ddlScanIpRange);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.grdAntminers);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSshPassword);
            this.Controls.Add(this.lblSshPassword);
            this.Controls.Add(this.txtSshUsername);
            this.Controls.Add(this.lblSshUsername);
            this.Controls.Add(this.txtIpAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblIpAddress);
            this.Controls.Add(this.lblName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageAntminers";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Antminers";
            this.ThemeName = "Windows8";
            this.Load += new System.EventHandler(this.ManageAntminers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIpAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIpAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSshUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSshUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSshPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSshPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAntminers.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAntminers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnScan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlScanIpRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgbScan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnScanDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblName;
        private Telerik.WinControls.UI.RadTextBox txtName;
        private Telerik.WinControls.UI.RadTextBox txtIpAddress;
        private Telerik.WinControls.UI.RadLabel lblIpAddress;
        private Telerik.WinControls.UI.RadTextBox txtSshUsername;
        private Telerik.WinControls.UI.RadLabel lblSshUsername;
        private Telerik.WinControls.UI.RadTextBox txtSshPassword;
        private Telerik.WinControls.UI.RadLabel lblSshPassword;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadGridView grdAntminers;
        private Telerik.WinControls.UI.RadButton btnScan;
        private Telerik.WinControls.UI.RadDropDownList ddlScanIpRange;
        private Telerik.WinControls.UI.RadProgressBar pgbScan;
        private Telerik.WinControls.UI.RadButton btnScanDone;
        private Telerik.WinControls.UI.RadButton btnDeleteAll;
        private Telerik.WinControls.UI.RadButton btnDone;
    }
}