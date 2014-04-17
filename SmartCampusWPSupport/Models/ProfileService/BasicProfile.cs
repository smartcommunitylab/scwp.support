using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProfileService
{
    public class BasicProfile
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("socialId")]
        public string SocialId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
