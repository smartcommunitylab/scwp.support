using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.RealTime
{
    public class AlertDelay : BaseAlert
    {
        [JsonProperty("position")]
        public Position PositionInfo { get; set; }

        [JsonProperty("transport")]
        public Transport TransportInfo { get; set; }

        [JsonProperty("road")]
        public Road RoadInfo { get; set; }
        
        [JsonProperty("delay")]
        public int Delay { get; set; }
    }
}
