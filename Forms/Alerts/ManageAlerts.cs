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

            grdAlerts.Columns.Add("EnabledAlerts", "Enabled Alerts", "EnabledAlerts");

            PopulateAlertsGrid();

            #endregion
        }
        
        private void ddlAlertType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            pnlAlertEditor.Controls.Clear();
            if (ddlAlertType.SelectedItem.Text.Equals(Utilities.GetEnumDescription(AlertType.MinerDown)))
            {
                var ctrl = new MinerDown();
                ctrl.Finished += ctrl_Finished;
                pnlAlertEditor.Controls.Add(ctrl);
            }
            else if (ddlAlertType.SelectedItem.Text.Equals(Utilities.GetEnumDescription(AlertType.MinerOverTempature)))
            {
                var ctrl = new MinerOverTempature();
                ctrl.Finished += ctrl_Finished;
                pnlAlertEditor.Controls.Add(ctrl);
            }
            else if (ddlAlertType.SelectedItem.Text.Equals(Utilities.GetEnumDescription(AlertType.MinerAsicStatus)))
            {
                var ctrl = new MinerAsicStatus();
                ctrl.Finished += ctrl_Finished;
                pnlAlertEditor.Controls.Add(ctrl);
            }
        }

        void ctrl_Finished(object source)
        {
            ddlAlertType.SelectedIndex = 0;
            PopulateAlertsGrid();
        }

        private void PopulateAlertsGrid()
        {
            var settings = SettingsService.GetSettings();

            grdAlerts.Rows.Clear();
            foreach (var a in settings.Alerts.Where(x => x.Enabled).Select(x => Utilities.GetEnumDescription(x.Type)))
                grdAlerts.Rows.Add(a);
        }
    }
}
