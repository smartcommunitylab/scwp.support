using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.Journeys
{
    public class Position
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("stopId")]
        public StopId StopIdInfo { get; set; }

        [JsonProperty("stopCode")]
        public string StopCode { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }

    public class StopId
    {
        [JsonProperty("id")]
        public string StopId { get; set; }

        [JsonProperty("agencyId")]
        public string Name { get; set; }
    }
}
