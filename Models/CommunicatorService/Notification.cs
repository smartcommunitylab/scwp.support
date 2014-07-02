using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CommunicatorService
{
  public class Notification
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("updateTime")]
    public long UpdateTime { get; set; }

    [JsonProperty("version")]
    public long Version { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("user")]
    public string User { get; set; }

    [JsonProperty("content")]
    public Dictionary<string, object> Content { get; set; }

    [JsonProperty("timestamp")]
    public long Timestamp { get; set; }

    [JsonProperty("starred")]
    public bool Starred { get; set; }

    [JsonProperty("labelIds")]
    public List<string> LabelIds { get; set; }

    [JsonProperty("channelIds")]
    public List<string> ChannelIds { get; set; }

    [JsonProperty("entities")]
    public List<EntityObject> Entities { get; set; }

    [JsonProperty("author")]
    public NotificationAuthor Author { get; set; }

    [JsonProperty("readed")]
    public bool Readed { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(Notification).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
