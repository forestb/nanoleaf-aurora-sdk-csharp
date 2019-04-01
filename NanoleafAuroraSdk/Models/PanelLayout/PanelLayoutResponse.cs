using System;
using System.Collections.Generic;
using System.Text;

namespace NanoleafAuroraSdk.Models.PanelLayout
{
    public class PositionData
    {
        public int panelId { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int o { get; set; }
    }

    public class PanelLayoutResponse
    {
        public int numPanels { get; set; }
        public int sideLength { get; set; }
        public List<PositionData> positionData { get; set; }
    }
}
