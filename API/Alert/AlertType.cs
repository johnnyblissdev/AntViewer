using System.ComponentModel;

namespace AntViewer.API.Alert
{
    public enum AlertType
    {
        [Description("Miner Down")]
        MinerDown = 0,
        [Description("Miner Over Tempature")]
        MinerOverTempature = 1,
        [Description("Miner ASIC Status")]
        MinerAsicStatus = 2
    }
}
