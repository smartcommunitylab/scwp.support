using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.RealTime
{
  public class BaseAlert
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("creatorId")]
    public string CreatorId { get; set; }

    [JsonProperty("creatorType")]
    [JsonConverter(typeof(StringEnumConverter))]
    public CreatorType CreatorType { get; set; }

    [JsonProperty("from")]
    public long ValidFrom { get; set; }

    [JsonProperty("to")]
    public long ValidUntil { get; set; }

    [JsonProperty("effect")]
    public string Effect { get; set; }

    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public AlertType? Type { get; set; }

    [JsonProperty("note")]
    public string Note { get; set; }

    [JsonProperty("entity")]
    public string Entity { get; set; }
  }
}
