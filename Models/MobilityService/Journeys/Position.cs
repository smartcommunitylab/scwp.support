using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
    public string Latitude { get; set; }

    [JsonProperty("lon")]
    public string Longitude { get; set; }

    public override string ToString()
    {
      return Name;
    }

  }

  public class StopId
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    private AgencyType AgencyID;

    [JsonProperty("agencyId")]
    [JsonConverter(typeof(StringEnumConverter))]
    public AgencyType? Agency 
    { get { return AgencyID; } 
      set
      {
        if(value == null)
          AgencyID = AgencyType.Null;
        else
          AgencyID = (AgencyType)value;
      } 
    }

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
