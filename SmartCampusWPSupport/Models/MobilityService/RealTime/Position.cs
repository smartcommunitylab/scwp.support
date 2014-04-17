using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.RealTime
{
    public class Position
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("stopId")]
        public string StopId { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }
}
