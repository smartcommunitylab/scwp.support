using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.RealTime
{
  public class AlertDelay : BaseAlert
  {
    [JsonProperty("position")]
    public Journeys.Position PositionInfo { get; set; }

    [JsonProperty("transport")]
    public Transport TransportInfo { get; set; }

    [JsonProperty("road")]
    public Road RoadInfo { get; set; }

    [JsonProperty("delay")]
    public int Delay { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(AlertDelay).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
