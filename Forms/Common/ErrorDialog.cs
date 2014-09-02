using System;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace AntViewer.Forms.Common
{
    public partial class ErrorDialog : RadForm
    {
        public string ErrorSubject { get; set; }
        public string ErrorMessage { get; set; }
        public string LongErrorMessage { get; set; }

        private RadToolTip _longErrorTooltip { get; set; }

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

            if (!string.IsNullOrEmpty(LongErrorMessage))
            {
                lblErrorMessage.MouseEnter += lblErrorMessage_MouseEnter;
                lblErrorMessage.MouseLeave += lblErrorMessage_MouseLeave;
            }
        }

        void lblErrorMessage_MouseLeave(object sender, EventArgs e)
        {
            if(_longErrorTooltip != null)
                _longErrorTooltip.Hide();
        }

        void lblErrorMessage_MouseEnter(object sender, EventArgs e)
        {
            _longErrorTooltip = new RadToolTip();
            _longErrorTooltip.Show(LongErrorMessage);
        }
    }
}
