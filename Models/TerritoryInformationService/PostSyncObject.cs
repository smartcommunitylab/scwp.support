using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TerritoryInformationService
{
  public class PostSyncObject
  {
    [JsonProperty("exclude")]
    public Dictionary<string, string> Exclude { get; set; }

    [JsonProperty("include")]
    public Dictionary<string, string> Include { get; set; }

    [JsonProperty("version")]
    public long Version { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(PostSyncObject).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
