using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CommunicatorService
{
  public class AppSignature
  {
    [JsonProperty("appId")]
    public string AppId { get; set; }

    [JsonProperty("publicKey")]
    public Dictionary<string, object> PublicKey { get; set; }

    [JsonProperty("privateKey")]
    public Dictionary<string, object> PrivateKey { get; set; }

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
