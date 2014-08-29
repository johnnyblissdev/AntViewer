using System;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace AntViewer.Forms.Common
{
    public partial class ErrorDialog : RadForm
    {
        public string ErrorSubject { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorDialog()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ErrorDialog_Load(object sender, EventArgs e)
        {
            Text = ErrorSubject;
            lblErrorMessage.Text = ErrorMessage;

            ThemeResolutionService.ApplicationThemeName = "Windows8";
        }
    }
}
