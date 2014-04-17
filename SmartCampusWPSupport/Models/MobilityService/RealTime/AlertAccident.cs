using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.RealTime
{
    public class AlertAccident : BaseAlert
    {
        [JsonProperty("position")]
        public Position PositionInfo { get; set; }

        [JsonProperty("severity")]
        public string Severity { get; set; }

    }
}
