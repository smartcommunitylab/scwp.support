using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.PublicTransport
{
  public class TimetableCacheUpdate
  {
    [JsonProperty("added")]
    public List<string> Added { get; set; }

    [JsonProperty("removed")]
    public List<string> Removed { get; set; }

    [JsonProperty("version")]
    public int Version { get; set; }

    [JsonProperty("calendars")]
    public Dictionary<string, TimeTableCacheUpdateCalendar> Calendars { get; set; }


    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(TimetableCacheUpdate).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }

  public class TimeTableCacheUpdateCalendar
  {
    [JsonProperty("entries")]
    public Dictionary<string, string> Entries { get; set; }

    [JsonProperty("mapping")]
    public Dictionary<string, string> Mapping { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(TimeTableCacheUpdateCalendar).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }

}
