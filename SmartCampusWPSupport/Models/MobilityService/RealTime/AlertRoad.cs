using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.RealTime
{
    public class AlertRoad : BaseAlert
    {
        [JsonProperty("agencyId")]
        public AgencyType AgencyId { get; set; }

        [JsonProperty("changeTypes")]
        public ChangeType[] ChangeTypes { get; set; }

        [JsonProperty("road")]
        public Road RoadInfo { get; set; }
    }

    public class Road
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("streetCode")]
        public string StreetCode { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("fromNumber")]
        public string FromNumber { get; set; }

        [JsonProperty("toNumber")]
        public string ToNumber { get; set; }

        [JsonProperty("fromIntersection")]
        public string FromIntersection { get; set; }

        [JsonProperty("toIntersection")]
        public string ToIntersection { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }
    }
}
