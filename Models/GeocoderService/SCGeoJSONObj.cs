using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GeocoderService
{
  public class SCGeoJSONObj
  {
    [JsonProperty("responseHeader")]
    public SCGeoResponseHeader ResponseHeader { get; set; }
   
    [JsonProperty("response")]
    public SCGeoResponse Response { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(SCGeoJSONObj).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
