using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.RealTime
{
    public class AlertDelay : BaseAlert
    {
        [JsonProperty("stopId")]
        public string StopId { get; set; }

        [JsonProperty("placesAvailable")]
        public string PlacesAvailable { get; set; }

        [JsonProperty("noOfveichle")]
        public string NoOfVeichle { get; set; }

    }
}
