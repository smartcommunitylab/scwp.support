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
    public Dictionary<int, bool> MonitorLegs { get; set; }
  }
}
