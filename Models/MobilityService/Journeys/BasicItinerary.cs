using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.Journeys
{
  public class BasicItinerary
  {
    [JsonProperty("clientId")]
    public int ClientId { get; set; }

    [JsonProperty("data")]
    public Itinerary Data { get; set; }

    [JsonProperty("monitor")]
    public bool Monitor { get; set; }

    [JsonProperty("originalFrom")]
    public Position OriginalFrom { get; set; }

    [JsonProperty("originalTo")]
    public Position OriginalTo { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(BasicItinerary).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
