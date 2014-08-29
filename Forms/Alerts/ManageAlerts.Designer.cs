namespace AntViewer.Forms.Alerts
{
    partial class ManageAlerts
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEmailSettings = new Telerik.WinControls.UI.RadButton();
            this.pnlAlertType = new System.Windows.Forms.Panel();
            this.pnlAlertEditor = new System.Windows.Forms.Panel();
            this.lblAlertType = new Telerik.WinControls.UI.RadLabel();
            this.ddlAlertType = new Telerik.WinControls.UI.RadDropDownList();
            this.grdAlerts = new Telerik.WinControls.UI.RadGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmailSettings)).BeginInit();
            this.pnlAlertType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAlertType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAlertType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAlerts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAlerts.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlAlertType, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grdAlerts, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(342, 437);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEmailSettings);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 33);
            this.panel2.TabIndex = 4;
            // 
            // btnEmailSettings
            // 
            this.btnEmailSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailSettings.Location = new System.Drawing.Point(0, 0);
            this.btnEmailSettings.Name = "btnEmailSettings";
            this.btnEmailSettings.Size = new System.Drawing.Size(155, 32);
            this.btnEmailSettings.TabIndex = 2;
            this.btnEmailSettings.Text = "Email Settings";
            this.btnEmailSettings.ThemeName = "Windows8";
            this.btnEmailSettings.Click += new System.EventHandler(this.btnEmailSettings_Click);
            // 
            // pnlAlertType
            // 
            this.pnlAlertType.Controls.Add(this.pnlAlertEditor);
            this.pnlAlertType.Controls.Add(this.lblAlertType);
            this.pnlAlertType.Controls.Add(this.ddlAlertType);
            this.pnlAlertType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAlertType.Location = new System.Drawing.Point(3, 42);
            this.pnlAlertType.Name = "pnlAlertType";
            this.pnlAlertType.Size = new System.Drawing.Size(336, 146);
            this.pnlAlertType.TabIndex = 5;
            // 
            // pnlAlertEditor
            // 
            this.pnlAlertEditor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlertEditor.Location = new System.Drawing.Point(0, 34);
            this.pnlAlertEditor.Name = "pnlAlertEditor";
            this.pnlAlertEditor.Size = new System.Drawing.Size(336, 112);
            this.pnlAlertEditor.TabIndex = 3;
            // 
            // lblAlertType
            // 
            this.lblAlertType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertType.Location = new System.Drawing.Point(3, 3);
            this.lblAlertType.Name = "lblAlertType";
            this.lblAlertType.Size = new System.Drawing.Size(85, 25);
            this.lblAlertType.TabIndex = 2;
            this.lblAlertType.Text = "Alert Type:";
            this.lblAlertType.ThemeName = "Windows8";
            // 
            // ddlAlertType
            // 
            this.ddlAlertType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlAlertType.Location = new System.Drawing.Point(94, 3);
            this.ddlAlertType.Name = "ddlAlertType";
            this.ddlAlertType.Size = new System.Drawing.Size(236, 27);
            this.ddlAlertType.TabIndex = 0;
            this.ddlAlertType.ThemeName = "Windows8";
            this.ddlAlertType.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlAlertType_SelectedIndexChanged);
            // 
            // grdAlerts
            // 
            this.grdAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAlerts.Location = new System.Drawing.Point(3, 194);
            this.grdAlerts.Name = "grdAlerts";
            this.grdAlerts.Size = new System.Drawing.Size(336, 240);
            this.grdAlerts.TabIndex = 6;
            this.grdAlerts.Text = "radGridView1";
            this.grdAlerts.ThemeName = "Windows8";
            // 
            // ManageAlerts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 437);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ManageAlerts";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Alerts";
            this.ThemeName = "Windows8";
            this.Load += new System.EventHandler(this.ManageAlerts_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnEmailSettings)).EndInit();
            this.pnlAlertType.ResumeLayout(false);
            this.pnlAlertType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAlertType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAlertType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAlerts.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAlerts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadButton btnEmailSettings;
        private System.Windows.Forms.Panel pnlAlertType;
        private Telerik.WinControls.UI.RadDropDownList ddlAlertType;
        private Telerik.WinControls.UI.RadLabel lblAlertType;
        private System.Windows.Forms.Panel pnlAlertEditor;
        private Telerik.WinControls.UI.RadGridView grdAlerts;
    }
}