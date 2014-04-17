﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.Journeys
{
  public class RecurrentJourneyParameters
  {
    [JsonProperty("recurrence")]
    public int[] Recurrences { get; set; }

    [JsonProperty("from")]
    public Position From { get; set; }

    [JsonProperty("to")]
    public Position To { get; set; }

    [JsonProperty("fromDate")]
    public int fromDate { get; set; }

    [JsonProperty("toDate")]
    public int toDate { get; set; }

    [JsonProperty("interval")]
    public int Interval { get; set; }

    [JsonProperty("transportTypes")]
    public TransportType[] TransportTypes { get; set; }

    [JsonProperty("routeType")]
    public RouteType[] RouteTypes { get; set; }

    [JsonProperty("resultsNumber")]
    public int ResultsNumber { get; set; }
  }
}