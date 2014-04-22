using Models.MobilityService.Journeys;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.Journeys
{
  public class SingleJourney
  {
    [JsonProperty("from")]
    public Position From { get; set; }

    [JsonProperty("to")]
    public Position To { get; set; }

    [JsonProperty("date")]
    public string Date { get; set; }

    [JsonProperty("departureTime")]
    public string DepartureTime { get; set; }

    [JsonProperty("transportTypes")]
    public TransportType[] TransportTypes { get; set; }

    [JsonProperty("routeType")]
    public RouteType[] RouteTypes { get; set; }

    [JsonProperty("resultsNumber")]
    public int ResultsNumber { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(SingleJourney).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
