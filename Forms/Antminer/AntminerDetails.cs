using System;
using System.Net;
using System.Windows.Forms;
using AntViewer.DataService.Antminer;
using AntViewer.UserControls.Antminer;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace AntViewer.Forms.Antminer
{
    public partial class AntminerDetails : RadForm
    {
        public Guid AntminerId { get; set; }

        public AntminerDetails()
        {
            InitializeComponent();
        }

        private void AntminerDetails_Load(object sender, System.EventArgs e)
        {
            ThemeResolutionService.ApplicationThemeName = "Windows8";

            var antminer = AntminerService.GetAntminerById(AntminerId);
            if (antminer == null)
            {
                Close();
                return;
            }

            var details = new UserControls.Antminer.AntminerDetails
            {
                Ip = IPAddress.Parse(antminer.IpAddress),
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            pnlDetails.Controls.Add(details);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
