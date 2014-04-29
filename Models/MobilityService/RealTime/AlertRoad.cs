using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.RealTime
{
  public class AlertRoad : BaseAlert
  {
    [JsonProperty("agencyId")]
    [JsonConverter(typeof(StringEnumConverter))]
    public AgencyType AgencyId { get; set; }

    [JsonProperty("changeTypes", ItemConverterType = typeof(StringEnumConverter))]
    public List<ChangeType> ChangeTypes { get; set; }

    [JsonProperty("road")]
    public Road RoadInfo { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(AlertRoad).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }

  public class Road
  {
    [JsonProperty("lat")]
    public string Latitude { get; set; }

    [JsonProperty("lon")]
    public string Longitude { get; set; }

    [JsonProperty("streetCode")]
    public string StreetCode { get; set; }

    [JsonProperty("street")]
    public string Street { get; set; }

    [JsonProperty("fromNumber")]
    public string FromNumber { get; set; }

    [JsonProperty("toNumber")]
    public string ToNumber { get; set; }

    [JsonProperty("fromIntersection")]
    public string FromIntersection { get; set; }

    [JsonProperty("toIntersection")]
    public string ToIntersection { get; set; }

    [JsonProperty("note")]
    public string Note { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(Road).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
