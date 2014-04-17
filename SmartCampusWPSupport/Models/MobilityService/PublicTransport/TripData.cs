using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.PublicTransport
{
    public class TripData
    {
        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("agencyId")]
        public string AgencyId { get; set; }
        
        [JsonProperty("routeId")]
        public string RouteId { get; set; }

        [JsonProperty("tripId")]
        public string TripId { get; set; }

        [JsonProperty("routeName")]
        public string RouteName { get; set; }

        [JsonProperty("routeShortName")]
        public string RouteShortName { get; set; }

        [JsonProperty("delay")]
        public Delay DelayInfo { get; set; }

    }
}
