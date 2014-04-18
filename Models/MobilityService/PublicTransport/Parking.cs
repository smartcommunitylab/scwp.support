using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.PublicTransport
{
    public class Parking
    {
        [JsonProperty("name")]
        public RouteId Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("position")]
        public int[] Position { get; set; }

        [JsonProperty("monitored")]
        public bool Monitored { get; set; }

        [JsonProperty("slotsTotal")]
        public int SlotsTotal { get; set; }

        [JsonProperty("slotsAvailable")]
        public int SlotsAvailable { get; set; }

    }
}
