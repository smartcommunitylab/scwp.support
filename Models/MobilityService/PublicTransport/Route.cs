using Models.MobilityService;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.PublicTransport
{
  public class Route : IComparable<Route>
  {
    [JsonProperty("id")]
    public RouteId RouteId { get; set; }

    [JsonProperty("routeLongName")]
    public string RouteLongName { get; set; }

    [JsonProperty("routeShortName")]
    public string RouteShortName { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(Route).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }


    public int CompareTo(Route obj)
    {
      int thisRes, thatRes;
      bool thisBool = Int32.TryParse(this.RouteShortName, out thisRes);
      bool thatBool = Int32.TryParse(obj.RouteShortName, out thatRes);

      if (thisBool)
      {
        if (thatBool)
          return thisRes.CompareTo(thatRes);
        else
          return 1;
      }
      else
      {
        if (thatBool)
          return -1;
        else
          return this.RouteShortName.CompareTo(obj.RouteShortName);
      }
    }

  }

  public class RouteId
  {
    [JsonProperty("agency")]
    [JsonConverter(typeof(StringEnumConverter))]
    public AgencyType AgencyId { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(RouteId).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }

}
