﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
    [JsonConverter(typeof(StringEnumConverter))]
    public TransportType Type { get; set; }

    [JsonProperty("agencyId")]
    [JsonConverter(typeof(StringEnumConverter))]
    public AgencyType? AgencyId { get; set; }

    [JsonProperty("routeId")]
    public string RouteId { get; set; }

    [JsonProperty("routeShortName")]
    public string RouteShortName { get; set; }

    [JsonProperty("tripId")]
    public string TripId { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(Transport).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }

  }
}
