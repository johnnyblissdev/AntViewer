namespace AntViewer.UserControls.Alert
{
    partial class MinerDown
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
            this.btnEnable = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEnable)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDesc
            // 
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(4, 4);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(279, 21);
            this.lblDesc.TabIndex = 0;
            this.lblDesc.Text = "Send email alert when dead miner is detected.";
            this.lblDesc.ThemeName = "Windows8";
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(4, 58);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(110, 24);
            this.btnEnable.TabIndex = 1;
            this.btnEnable.Text = "Enable";
            this.btnEnable.ThemeName = "Windows8";
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // MinerDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEnable);
            this.Controls.Add(this.lblDesc);
            this.Name = "MinerDown";
            this.Size = new System.Drawing.Size(583, 85);
            this.Load += new System.EventHandler(this.MinerDown_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEnable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblDesc;
        private Telerik.WinControls.UI.RadButton btnEnable;
    }
}
