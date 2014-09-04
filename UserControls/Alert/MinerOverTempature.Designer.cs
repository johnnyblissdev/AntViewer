namespace AntViewer.UserControls.Alert
{
    partial class MinerOverTempature
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDesc = new Telerik.WinControls.UI.RadLabel();
            this.txtOverTempature = new Telerik.WinControls.UI.RadTextBoxControl();
            this.btnEnable = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOverTempature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEnable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDesc
            // 
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(4, 4);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(222, 21);
            this.lblDesc.TabIndex = 1;
            this.lblDesc.Text = "Alert when miner is over tempature: ";
            this.lblDesc.ThemeName = "Windows8";
            // 
            // txtOverTempature
            // 
            this.txtOverTempature.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtOverTempature.Location = new System.Drawing.Point(232, 5);
            this.txtOverTempature.Name = "txtOverTempature";
            this.txtOverTempature.Size = new System.Drawing.Size(49, 20);
            this.txtOverTempature.TabIndex = 2;
            this.txtOverTempature.ThemeName = "Windows8";
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(4, 58);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(110, 24);
            this.btnEnable.TabIndex = 3;
            this.btnEnable.Text = "Enable";
            this.btnEnable.ThemeName = "Windows8";
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(120, 58);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.ThemeName = "Windows8";
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MinerOverTempature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEnable);
            this.Controls.Add(this.txtOverTempature);
            this.Controls.Add(this.lblDesc);
            this.Name = "MinerOverTempature";
            this.Size = new System.Drawing.Size(583, 85);
            this.Load += new System.EventHandler(this.MinerOverTempature_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOverTempature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEnable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblDesc;
        private Telerik.WinControls.UI.RadTextBoxControl txtOverTempature;
        private Telerik.WinControls.UI.RadButton btnEnable;
        private Telerik.WinControls.UI.RadButton btnSave;
    }
}
