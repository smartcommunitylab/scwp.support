using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.Journeys
{
  public class Position
  {
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("stopId")]
    public StopId Stop { get; set; }

    [JsonProperty("stopCode")]
    public string StopCode { get; set; }

    [JsonProperty("lat")]
    public double Latitude { get; set; }

    [JsonProperty("lon")]
    public double Longitude { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(Position).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }

  }

  public class StopId
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("agencyId")]
    public AgencyType Agency { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(StopId).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
