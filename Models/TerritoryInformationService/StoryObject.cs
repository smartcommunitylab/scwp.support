using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TerritoryInformationService
{
  public class StoryObject : BaseTerritoryInfo
  {
    [JsonProperty("steps")]
    public List<Step> Steps { get; set; }

    [JsonProperty("attendees")]
    public int Attendees { get; set; }

    [JsonProperty("attending")]
    public List<string> Attending { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(StoryObject).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }

  public class Step
  {
    [JsonProperty("poiId")]
    public string PoiId { get; set; }

    [JsonProperty("note")]
    public string Notes { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(Step).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
