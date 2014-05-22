using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.Journeys
{
  public class RecurrentJourney
  {
    [JsonProperty("parameters")]
    public RecurrentJourneyParameters Parameters { get; set; }

    [JsonProperty("legs")]
    public List<SimpleLeg> Legs { get; set; }

    [JsonProperty("monitorLegs")]
    public Dictionary<string, bool> MonitorLegs { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(RecurrentJourney).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
