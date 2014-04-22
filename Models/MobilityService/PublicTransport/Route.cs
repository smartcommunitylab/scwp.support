﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.PublicTransport
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

    public class RouteId
    {
        [JsonProperty("agency")]
        public AgencyType AgencyId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

}