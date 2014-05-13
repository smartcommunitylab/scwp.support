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
    [JsonProperty("name", Order=2)]
    public string Name { get; set; }

    [JsonProperty("stopId", Order=1)]
    public StopId Stop { get; set; }

    [JsonProperty("stopCode", Order=3)]
    public string StopCode { get; set; }

    [JsonProperty("lat", Order=4)]
    public string Latitude { get; set; }

    [JsonProperty("lon", Order=0)]
    public string Longitude { get; set; }

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
    [JsonProperty("id", Order=0)]
    public string Id { get; set; }

    private AgencyType AgencyID;

    [JsonProperty("agencyId", Order=1)]
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
