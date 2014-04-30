using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProfileService
{
  public class AccountProfile
  {
    [JsonProperty("accounts")]
    public Dictionary<string, Dictionary<string, string>> Accounts { get; set; }

    private string DictionaryToString(Dictionary<string, string> dict)
    {
      StringBuilder sb = new StringBuilder();
      foreach (var item in dict)
        sb.AppendFormat("{0}: {1}\n", item.Key, item.Value);
      return sb.ToString();

    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();

      foreach (var item in Accounts)
        sb.AppendFormat("{0}: {1}\n", item.Key, DictionaryToString(item.Value));

      return sb.ToString();
    }
  }
}
