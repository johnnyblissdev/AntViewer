namespace AntViewer.Forms.Performance
{
    partial class PerformanceSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerformanceSettings));
            this.lblRefreshInterval = new Telerik.WinControls.UI.RadLabel();
            this.lblRefreshThreadCount = new Telerik.WinControls.UI.RadLabel();
            this.tckRefreshThreadCount = new Telerik.WinControls.UI.RadTrackBar();
            this.tckRefreshInterval = new Telerik.WinControls.UI.RadTrackBar();
            this.txtRefreshInterval = new Telerik.WinControls.UI.RadTextBox();
            this.txtRefreshThreadCount = new Telerik.WinControls.UI.RadTextBox();
            this.lblRefreshThreadCountDesc = new Telerik.WinControls.UI.RadLabel();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblRefreshInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRefreshThreadCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tckRefreshThreadCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tckRefreshInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefreshInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefreshThreadCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRefreshThreadCountDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRefreshInterval
            // 
            this.lblRefreshInterval.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefreshInterval.Location = new System.Drawing.Point(6, 12);
            this.lblRefreshInterval.Name = "lblRefreshInterval";
            this.lblRefreshInterval.Size = new System.Drawing.Size(199, 25);
            this.lblRefreshInterval.TabIndex = 3;
            this.lblRefreshInterval.Text = "Refresh Interval (Seconds):";
            this.lblRefreshInterval.ThemeName = "Windows8";
            // 
            // lblRefreshThreadCount
            // 
            this.lblRefreshThreadCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefreshThreadCount.Location = new System.Drawing.Point(36, 79);
            this.lblRefreshThreadCount.Name = "lblRefreshThreadCount";
            this.lblRefreshThreadCount.Size = new System.Drawing.Size(169, 25);
            this.lblRefreshThreadCount.TabIndex = 5;
            this.lblRefreshThreadCount.Text = "Refresh Thread Count:";
            this.lblRefreshThreadCount.ThemeName = "Windows8";
            // 
            // tckRefreshThreadCount
            // 
            this.tckRefreshThreadCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tckRefreshThreadCount.Location = new System.Drawing.Point(269, 79);
            this.tckRefreshThreadCount.Name = "tckRefreshThreadCount";
            this.tckRefreshThreadCount.Size = new System.Drawing.Size(304, 37);
            this.tckRefreshThreadCount.TabIndex = 8;
            // 
            // tckRefreshInterval
            // 
            this.tckRefreshInterval.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tckRefreshInterval.Location = new System.Drawing.Point(269, 12);
            this.tckRefreshInterval.Name = "tckRefreshInterval";
            this.tckRefreshInterval.Size = new System.Drawing.Size(304, 37);
            this.tckRefreshInterval.TabIndex = 9;
            // 
            // txtRefreshInterval
            // 
            this.txtRefreshInterval.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefreshInterval.Location = new System.Drawing.Point(208, 12);
            this.txtRefreshInterval.Name = "txtRefreshInterval";
            this.txtRefreshInterval.Size = new System.Drawing.Size(55, 27);
            this.txtRefreshInterval.TabIndex = 10;
            this.txtRefreshInterval.ThemeName = "Windows8";
            // 
            // txtRefreshThreadCount
            // 
            this.txtRefreshThreadCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefreshThreadCount.Location = new System.Drawing.Point(208, 79);
            this.txtRefreshThreadCount.Name = "txtRefreshThreadCount";
            this.txtRefreshThreadCount.Size = new System.Drawing.Size(55, 27);
            this.txtRefreshThreadCount.TabIndex = 11;
            this.txtRefreshThreadCount.ThemeName = "Windows8";
            // 
            // lblRefreshThreadCountDesc
            // 
            this.lblRefreshThreadCountDesc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefreshThreadCountDesc.Location = new System.Drawing.Point(269, 141);
            this.lblRefreshThreadCountDesc.Name = "lblRefreshThreadCountDesc";
            this.lblRefreshThreadCountDesc.Size = new System.Drawing.Size(192, 18);
            this.lblRefreshThreadCountDesc.TabIndex = 6;
            this.lblRefreshThreadCountDesc.Text = "Number of Ants to refresh at a time...";
            this.lblRefreshThreadCountDesc.ThemeName = "Windows8";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(463, 174);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.ThemeName = "Windows8";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(347, 174);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.ThemeName = "Windows8";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // PerformanceSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 214);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblRefreshThreadCountDesc);
            this.Controls.Add(this.txtRefreshThreadCount);
            this.Controls.Add(this.txtRefreshInterval);
            this.Controls.Add(this.tckRefreshInterval);
            this.Controls.Add(this.tckRefreshThreadCount);
            this.Controls.Add(this.lblRefreshThreadCount);
            this.Controls.Add(this.lblRefreshInterval);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PerformanceSettings";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Performance Settings";
            this.ThemeName = "Windows8";
            this.Load += new System.EventHandler(this.PerformanceSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblRefreshInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRefreshThreadCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tckRefreshThreadCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tckRefreshInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefreshInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefreshThreadCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRefreshThreadCountDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblRefreshInterval;
        private Telerik.WinControls.UI.RadLabel lblRefreshThreadCount;
        private Telerik.WinControls.UI.RadTrackBar tckRefreshThreadCount;
        private Telerik.WinControls.UI.RadTrackBar tckRefreshInterval;
        private Telerik.WinControls.UI.RadTextBox txtRefreshInterval;
        private Telerik.WinControls.UI.RadTextBox txtRefreshThreadCount;
        private Telerik.WinControls.UI.RadLabel lblRefreshThreadCountDesc;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnSave;
    }
}