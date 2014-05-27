using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GoogleMapsAPI
{
  public class AddressComponent
  {
    [JsonProperty("long_name")]
    public string LongName { get; set; }

    [JsonProperty("short_name")]
    public string ShortName { get; set; }

    [JsonProperty("types")]
    public string[] AddressType { get; set; }

  }

}
