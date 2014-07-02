using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GeocoderService
{
  public class SCGeoParameters
  {
    [JsonProperty("omitHeader")]
    public string OmitHeader { get; set; }
    
    [JsonProperty("bq")]
    public string Bq { get; set; }
    
    [JsonProperty("start")]
    public string Start { get; set; }
    
    [JsonProperty("q")]
    public string Q { get; set; }
    
    [JsonProperty("wt")]
    public string Wt { get; set; }
    
    [JsonProperty("rows")]
    public string Rows { get; set; }
    
    [JsonProperty("defType")]
    public string DefType { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(SCGeoParameters).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
