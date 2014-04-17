using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService
{
    class StopTime
    {
        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("trip")]
        public Trip Trip { get; set; }

    }

    protected class Trip
    {
        [JsonProperty("agency")]
        public string AgencyId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
