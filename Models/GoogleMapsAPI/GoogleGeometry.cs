using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GoogleMapsAPI
{
  public class GoogleGeometry
  {
    [JsonProperty("bounds")]
    public Dictionary<string, GooglePos> Bounds{ get; set; }

    [JsonProperty("location")]
    public GooglePos Location { get; set; }

    [JsonProperty("location:type")]
    public string LocationType { get; set; }

    [JsonProperty("viewport")]
    public Dictionary<string, GooglePos> Viewport { get; set; }
  }
}
