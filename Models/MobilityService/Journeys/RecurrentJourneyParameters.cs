using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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

    [JsonProperty("time")]
    public string Time { get; set; }

    [JsonProperty("fromDate")]
    public long FromDate { get; set; }

    [JsonProperty("toDate")]
    public long ToDate { get; set; }

    [JsonProperty("interval")]
    public long Interval { get; set; }

    [JsonProperty("transportTypes", ItemConverterType = typeof(StringEnumConverter))]
    public TransportType[] TransportTypes { get; set; }

    [JsonProperty("routeType", ItemConverterType = typeof(StringEnumConverter))]
    public RouteType RouteType { get; set; }

    [JsonProperty("resultsNumber")]
    public int ResultsNumber { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(RecurrentJourneyParameters).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
