﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.RealTime
{
    public class Transport
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("agencyId")]
        public string AgencyId { get; set; }

        [JsonProperty("routeId")]
        public string RouteId { get; set; }

        [JsonProperty("routeShortName")]
        public string RouteShortName { get; set; }

        [JsonProperty("tripId")]
        public string TripId { get; set; }

    }
}
