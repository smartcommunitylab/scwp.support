using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.PublicTransport
{
  public class LimitedTimeTable
  {
    [JsonProperty("delays")]
    public Dictionary<string, Delay> Delays { get; set; }

    [JsonProperty("name")]
    public string RouteName { get; set; }

    [JsonProperty("route")]
    public string RouteShortName { get; set; }

    [JsonProperty("times")]
    public List<Time> Times { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(LimitedTimeTable).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }

  }

  public class Time
  {
    [JsonProperty("time")]
    public long TimeInfo { get; set; }

    [JsonProperty("trip")]
    public Trip TripInfo { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(Time).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }

  }
}
