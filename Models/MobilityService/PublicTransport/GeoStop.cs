using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.PublicTransport
{
  public class GeoStop
  {
    [JsonProperty("id")]
    public string StopId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("coordinates")]
    public List<double> Coordinates { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(GeoStop).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
