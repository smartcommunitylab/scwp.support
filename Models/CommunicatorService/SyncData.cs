using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CommunicatorService
{
  public class SyncData
  {
    [JsonProperty("version")]
    public long Version { get; set; }

    [JsonProperty("deleted")]
    public Dictionary<string,HashSet<string>> Deleted { get; set; }

    [JsonProperty("updated")]
    public Dictionary<string, HashSet<string>> Updated { get; set; }

    //[JsonProperty("exclude")]
    //public Dictionary<string,object> Exclude { get; set; }

    //[JsonProperty("include")]
    //public Dictionary<string, object> Include { get; set; }
  }
}
