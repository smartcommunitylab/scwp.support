using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService
{
    public class Route
    {
        [JsonProperty("routeId")]
        public RouteId RouteId { get; set; }

        [JsonProperty("routeLongName")]
        public string RouteLongName { get; set; }

        [JsonProperty("routeShortName")]
        public string RouteShortName { get; set; }
    }

    protected class RouteId
    {
        [JsonProperty("agency")]
        public string AgencyId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

}
