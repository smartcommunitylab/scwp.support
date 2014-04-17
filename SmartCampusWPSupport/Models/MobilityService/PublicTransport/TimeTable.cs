using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.PublicTransport
{
    public class TimeTable
    {
        [JsonProperty("tripIds")]
        public int[] TripsId { get; set; }

        [JsonProperty("stops")]
        public string[] Stops { get; set; }

        [JsonProperty("stopsId")]
        public int[] StopsId { get; set; }

        [JsonProperty("times")]
        public List<List<List<DateTime>>> Times { get; set; }

        [JsonProperty("delays")]
        public List<List<Delay>> Delays { get; set; }

    }
}
