using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.PublicTransport
{
    public class Delay
    {
        [JsonProperty("user")]
        public int delayFromUser { get; set; }

        [JsonProperty("service")]
        public int delayFromService { get; set; }

    }
}
