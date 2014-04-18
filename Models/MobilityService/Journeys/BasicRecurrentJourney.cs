using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.Journeys
{
  public class BasicRecurrentJourney
  {
    [JsonProperty("clientId")]
    public int ClientId { get; set; }

    [JsonProperty("data")]
    public RecurrentJourney Data { get; set; }

    [JsonProperty("monitor")]
    public bool Monitor { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
  }
}
