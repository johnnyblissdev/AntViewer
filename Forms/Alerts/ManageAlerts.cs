using System;
using System.Linq;
using AntViewer.API.Alert;
using AntViewer.DataService.Settings;
using AntViewer.UserControls.Alert;
using D.Common;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace AntViewer.Forms.Alerts
{
    public partial class ManageAlerts : RadForm
    {
        public ManageAlerts()
        {
            InitializeComponent();
        }

        private void ManageAlerts_Load(object sender, EventArgs e)
        {
            ThemeResolutionService.ApplicationThemeName = "Windows8";

            var items = Utilities.GetAllEnumValues<AlertType>().Select(x => new RadListDataItem(Utilities.GetEnumDescription(x), x)).ToList();
            items.Insert(0, new RadListDataItem("Select an Alert..."));

            ddlAlertType.DataSource = items;
            ddlAlertType.SelectedIndex = 0;

            #region Load Alerts

            grdAlerts.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdAlerts.AllowAddNewRow = false;
            grdAlerts.EnableGrouping = false;
            grdAlerts.AllowDeleteRow = false;
            grdAlerts.AllowEditRow = false;
            grdAlerts.AllowCellContextMenu = false;

            var settings = SettingsService.GetSettings();
            grdAlerts.Columns.Add("EnabledAlerts", "Enabled Alerts", "EnabledAlerts");
            foreach (var a in settings.Alerts.Select(x => Utilities.GetEnumDescription(x.Type)))
            {
                grdAlerts.Rows.Add(a);
            }

            #endregion
        }

        private void btnEmailSettings_Click(object sender, EventArgs e)
        {
            new EmailSettings().ShowDialog();
        }

        private void ddlAlertType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            pnlAlertEditor.Controls.Clear();
            if (ddlAlertType.SelectedItem.Text.Equals(Utilities.GetEnumDescription(AlertType.MinerDown)))
            {   
                pnlAlertEditor.Controls.Add(new MinerDown());
            }
        }
    }
}
