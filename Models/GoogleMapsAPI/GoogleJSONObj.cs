using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GoogleMapsAPI
{
  public class GoogleJSONObj
  {
    [JsonProperty("results")]
    public List<Result> Results { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }
  }
}
