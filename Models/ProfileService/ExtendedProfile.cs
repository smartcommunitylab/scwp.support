using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProfileService
{
    public class ExtendedProfile
    {
        [JsonProperty("profileId")]
        public string ProfileId { get; set; }

        [JsonProperty("content")]
        public Dictionary<string, string> Content { get; set; }

        [JsonProperty("socialId")]
        public string SocialId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
