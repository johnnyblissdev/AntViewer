using System;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace AntViewer.Forms.Common
{
    public partial class ConfirmDialog : RadForm
    {
        public string ConfirmSubject { get; set; }
        public string ConfirmMessage { get; set; }

        public ConfirmDialog()
        {
            InitializeComponent();
        }

        private void ConfirmDialog_Load(object sender, EventArgs e)
        {
            ThemeResolutionService.ApplicationThemeName = "Windows8";

            Text = ConfirmSubject;
            lblInfoMessage.Text = ConfirmMessage;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
