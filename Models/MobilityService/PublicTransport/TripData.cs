using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
    public long Time { get; set; }

    [JsonProperty("agencyId")]
    [JsonConverter(typeof(StringEnumConverter))]
    public AgencyType AgencyId { get; set; }

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

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(TripData).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
