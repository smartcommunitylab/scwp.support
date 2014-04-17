using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.RealTime
{
    public class AlertStrike : BaseAlert
    {
        [JsonProperty("stopId")]
        public string StopId { get; set; }

        [JsonProperty("transport")]
        public Transport TransportInfo { get; set; }
    }
}
