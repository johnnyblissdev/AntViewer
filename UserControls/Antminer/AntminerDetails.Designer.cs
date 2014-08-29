namespace AntViewer.UserControls.Antminer
{
    partial class AntminerDetails
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
            this.pnlSummary = new System.Windows.Forms.GroupBox();
            this.grdSummary = new Telerik.WinControls.UI.RadGridView();
            this.pnlPools = new System.Windows.Forms.GroupBox();
            this.grdPools = new Telerik.WinControls.UI.RadGridView();
            this.pnlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAntminer = new System.Windows.Forms.GroupBox();
            this.grdAntMiner = new Telerik.WinControls.UI.RadGridView();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSummary.MasterTemplate)).BeginInit();
            this.pnlPools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPools.MasterTemplate)).BeginInit();
            this.pnlLayout.SuspendLayout();
            this.pnlAntminer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAntMiner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAntMiner.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSummary
            // 
            this.pnlSummary.Controls.Add(this.grdSummary);
            this.pnlSummary.Location = new System.Drawing.Point(3, 3);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(1093, 123);
            this.pnlSummary.TabIndex = 0;
            this.pnlSummary.TabStop = false;
            this.pnlSummary.Text = "Summary";
            // 
            // grdSummary
            // 
            this.grdSummary.Location = new System.Drawing.Point(7, 20);
            this.grdSummary.Name = "grdSummary";
            this.grdSummary.Size = new System.Drawing.Size(1077, 97);
            this.grdSummary.TabIndex = 0;
            this.grdSummary.Text = "radGridView1";
            // 
            // pnlPools
            // 
            this.pnlPools.Controls.Add(this.grdPools);
            this.pnlPools.Location = new System.Drawing.Point(3, 136);
            this.pnlPools.Name = "pnlPools";
            this.pnlPools.Size = new System.Drawing.Size(1090, 150);
            this.pnlPools.TabIndex = 1;
            this.pnlPools.TabStop = false;
            this.pnlPools.Text = "Pools";
            // 
            // grdPools
            // 
            this.grdPools.Location = new System.Drawing.Point(7, 20);
            this.grdPools.Name = "grdPools";
            this.grdPools.Size = new System.Drawing.Size(1077, 122);
            this.grdPools.TabIndex = 0;
            this.grdPools.Text = "radGridView1";
            // 
            // pnlLayout
            // 
            this.pnlLayout.ColumnCount = 1;
            this.pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1099F));
            this.pnlLayout.Controls.Add(this.pnlAntminer, 0, 2);
            this.pnlLayout.Controls.Add(this.pnlSummary, 0, 0);
            this.pnlLayout.Controls.Add(this.pnlPools, 0, 1);
            this.pnlLayout.Location = new System.Drawing.Point(4, 4);
            this.pnlLayout.Name = "pnlLayout";
            this.pnlLayout.RowCount = 3;
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.pnlLayout.Size = new System.Drawing.Size(1099, 450);
            this.pnlLayout.TabIndex = 2;
            // 
            // pnlAntminer
            // 
            this.pnlAntminer.Controls.Add(this.grdAntMiner);
            this.pnlAntminer.Location = new System.Drawing.Point(3, 293);
            this.pnlAntminer.Name = "pnlAntminer";
            this.pnlAntminer.Size = new System.Drawing.Size(1090, 150);
            this.pnlAntminer.TabIndex = 2;
            this.pnlAntminer.TabStop = false;
            this.pnlAntminer.Text = "AntMiner";
            // 
            // grdAntMiner
            // 
            this.grdAntMiner.Location = new System.Drawing.Point(7, 20);
            this.grdAntMiner.Name = "grdAntMiner";
            this.grdAntMiner.Size = new System.Drawing.Size(1077, 122);
            this.grdAntMiner.TabIndex = 0;
            this.grdAntMiner.Text = "radGridView1";
            // 
            // AntminerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLayout);
            this.Name = "AntminerDetails";
            this.Size = new System.Drawing.Size(1106, 462);
            this.Load += new System.EventHandler(this.AntminerS1_Load);
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSummary.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSummary)).EndInit();
            this.pnlPools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPools.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPools)).EndInit();
            this.pnlLayout.ResumeLayout(false);
            this.pnlAntminer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAntMiner.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAntMiner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox pnlSummary;
        private Telerik.WinControls.UI.RadGridView grdSummary;
        private System.Windows.Forms.GroupBox pnlPools;
        private Telerik.WinControls.UI.RadGridView grdPools;
        private System.Windows.Forms.TableLayoutPanel pnlLayout;
        private System.Windows.Forms.GroupBox pnlAntminer;
        private Telerik.WinControls.UI.RadGridView grdAntMiner;

    }
}
