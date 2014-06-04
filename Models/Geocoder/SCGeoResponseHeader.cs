using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Geocoder
{
  public class SCGeoResponseHeader
  {
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("qTime")]
    public int QTime { get; set; }
    
    [JsonProperty("params")]
    public SCGeoParameters Parameters { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(SCGeoResponseHeader).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
