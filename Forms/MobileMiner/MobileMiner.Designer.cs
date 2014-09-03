namespace AntViewer.Forms.MobileMiner
{
    partial class MobileMiner
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
            this.txtApplicationKey = new Telerik.WinControls.UI.RadTextBox();
            this.lblApplicationKey = new Telerik.WinControls.UI.RadLabel();
            this.txtEmailAddress = new Telerik.WinControls.UI.RadTextBox();
            this.lblEmailAddress = new Telerik.WinControls.UI.RadLabel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.chkEnabled = new Telerik.WinControls.UI.RadCheckBox();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtApplicationKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblApplicationKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmailAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtApplicationKey
            // 
            this.txtApplicationKey.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicationKey.Location = new System.Drawing.Point(165, 45);
            this.txtApplicationKey.Name = "txtApplicationKey";
            this.txtApplicationKey.Size = new System.Drawing.Size(271, 27);
            this.txtApplicationKey.TabIndex = 9;
            this.txtApplicationKey.ThemeName = "Windows8";
            // 
            // lblApplicationKey
            // 
            this.lblApplicationKey.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationKey.Location = new System.Drawing.Point(34, 43);
            this.lblApplicationKey.Name = "lblApplicationKey";
            this.lblApplicationKey.Size = new System.Drawing.Size(125, 25);
            this.lblApplicationKey.TabIndex = 8;
            this.lblApplicationKey.Text = "Application Key:";
            this.lblApplicationKey.ThemeName = "Windows8";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailAddress.Location = new System.Drawing.Point(165, 12);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(271, 27);
            this.txtEmailAddress.TabIndex = 7;
            this.txtEmailAddress.ThemeName = "Windows8";
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailAddress.Location = new System.Drawing.Point(46, 12);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(113, 25);
            this.lblEmailAddress.TabIndex = 5;
            this.lblEmailAddress.Text = "Email Address:";
            this.lblEmailAddress.ThemeName = "Windows8";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(210, 102);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.ThemeName = "Windows8";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(90, 74);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(69, 25);
            this.radLabel1.TabIndex = 9;
            this.radLabel1.Text = "Enabled:";
            this.radLabel1.ThemeName = "Windows8";
            // 
            // chkEnabled
            // 
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(165, 78);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(15, 15);
            this.chkEnabled.TabIndex = 14;
            this.chkEnabled.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(326, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.ThemeName = "Windows8";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MobileMiner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 147);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtApplicationKey);
            this.Controls.Add(this.lblApplicationKey);
            this.Controls.Add(this.txtEmailAddress);
            this.Controls.Add(this.lblEmailAddress);
            this.Name = "MobileMiner";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MultiMiner";
            this.ThemeName = "Windows8";
            this.Load += new System.EventHandler(this.MultiMiner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtApplicationKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblApplicationKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmailAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtApplicationKey;
        private Telerik.WinControls.UI.RadLabel lblApplicationKey;
        private Telerik.WinControls.UI.RadTextBox txtEmailAddress;
        private Telerik.WinControls.UI.RadLabel lblEmailAddress;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadCheckBox chkEnabled;
        private Telerik.WinControls.UI.RadButton btnCancel;


    }
}