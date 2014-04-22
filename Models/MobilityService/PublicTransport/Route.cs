using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.PublicTransport
{
  public class Route
  {
    [JsonProperty("id")]
    public RouteId RouteId { get; set; }

    [JsonProperty("routeLongName")]
    public string RouteLongName { get; set; }

    [JsonProperty("routeShortName")]
    public string RouteShortName { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(Route).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }

  public class RouteId
  {
    [JsonProperty("agency")]
    public AgencyType AgencyId { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(RouteId).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }

}
