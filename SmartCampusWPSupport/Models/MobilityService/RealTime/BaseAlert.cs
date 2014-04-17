using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.RealTime
{
    public class BaseAlert
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("creatorId")]
        public string CreatorId { get; set; }

        [JsonProperty("creatorType")]
        public string CreatorType { get; set; }

        [JsonProperty("from")]
        public int ValidFrom { get; set; }

        [JsonProperty("to")]
        public int ValidUntil { get; set; }

        [JsonProperty("effect")]
        public string Effect { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("entity")]
        public string Entity { get; set; }
    }
}
