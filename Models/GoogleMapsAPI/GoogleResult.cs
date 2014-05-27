using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GoogleMapsAPI
{
  public class Result
  {
    [JsonProperty("address_components")]
    public List<AddressComponent> AddressComponents { get; set; }

    [JsonProperty("formatted_address")]
    public string FormattedAddress { get; set; }

    [JsonProperty("geometry")]
    public GoogleGeometry Geometry { get; set; }

    [JsonProperty("partial_match")]
    public bool PartialMatch { get; set; }

    [JsonProperty("types")]
    public List<string> Types { get; set; }
  }
}
