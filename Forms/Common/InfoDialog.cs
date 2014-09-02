using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace AntViewer.Forms.Common
{
    public partial class InfoDialog : RadForm
    {
        public string InfoSubject { get; set; }
        public string InfoMessage { get; set; }

        public InfoDialog()
        {
            InitializeComponent();
        }

        private void InfoDialog_Load(object sender, System.EventArgs e)
        {
            ThemeResolutionService.ApplicationThemeName = "Windows8";

            Text = InfoSubject;
            lblInfoMessage.Text = InfoMessage;
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
