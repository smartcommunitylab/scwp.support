using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GeocoderService
{
  public class SCGeoResponse
  {
    [JsonProperty("numFound")]
    public int NumberOfResults { get; set; }
  
    [JsonProperty("start")]
    public int Start { get; set; }
    
    [JsonProperty("docs")]
    public List<SCGeoAddress> Places { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(SCGeoResponse).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
