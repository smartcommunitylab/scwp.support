using Newtonsoft.Json;
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
    [JsonProperty("type", Order=3)]
    [JsonConverter(typeof(StringEnumConverter))]
    public TransportType Type { get; set; }

    [JsonProperty("agencyId", Order=4)]
    [JsonConverter(typeof(StringEnumConverter))]
    public AgencyType? AgencyId { get; set; }

    [JsonProperty("routeId", Order=2)]
    public string RouteId { get; set; }

    [JsonProperty("routeShortName", Order=1)]
    public string RouteShortName { get; set; }

    [JsonProperty("tripId", Order=0)]
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
