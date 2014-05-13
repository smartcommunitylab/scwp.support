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
    [JsonProperty("from", Order=6)]
    public Position From { get; set; }

    [JsonProperty("to", Order=0)]
    public Position To { get; set; }

    [JsonProperty("startime", Order=4)]
    public long StartTime { get; set; }

    [JsonProperty("endtime", Order=1)]
    public long EndTime { get; set; }

    [JsonProperty("duration", Order=3)]
    public int Duration { get; set; }

    [JsonProperty("walkingDuration", Order=5)]
    public int WalkingDuration { get; set; }

    [JsonProperty("leg", Order=2)]
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
