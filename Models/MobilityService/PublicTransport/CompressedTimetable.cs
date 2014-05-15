using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.PublicTransport
{
  public class CompressedTimetable
  {
    [JsonProperty("stops")]
    public List<string> Stops { get; set; }

    [JsonProperty("stopsId")]
    public List<string> StopIds { get; set; }

    [JsonProperty("tripIds")]
    public List<string> TripIds { get; set; }

    [JsonProperty("compressedTimes")]
    public string CompressedTimes { get; set; }


    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(StopTime).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
