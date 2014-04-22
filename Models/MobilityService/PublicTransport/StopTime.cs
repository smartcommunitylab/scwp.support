using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.PublicTransport
{
  public class StopTime
  {
    [JsonProperty("time")]
    public int Time { get; set; }

    [JsonProperty("trip")]
    public Trip Trip { get; set; }


    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(StopTime).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }

  }

  public class Trip
  {
    [JsonProperty("agency")]
    public AgencyType AgencyId { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }


    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(Trip).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
