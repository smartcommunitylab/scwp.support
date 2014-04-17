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
        public Dictionary<string, Dictionary<string,string>> Accounts { get; set; }
    }
}
