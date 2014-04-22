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
  public class Itinerary
  {
    [JsonProperty("from")]
    public Position From { get; set; }

    [JsonProperty("to")]
    public Position To { get; set; }

    [JsonProperty("startTime")]
    public int StartTime { get; set; }

    [JsonProperty("endTime")]
    public int EndTime { get; set; }

    [JsonProperty("duration")]
    public int Duration { get; set; }

    [JsonProperty("walkingDuration")]
    public int WalkingDuration { get; set; }

    [JsonProperty("leg")]
    public List<Leg> Legs { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(Itinerary).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
