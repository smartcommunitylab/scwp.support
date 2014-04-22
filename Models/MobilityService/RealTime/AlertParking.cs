using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.RealTime
{
  public class AlertParking : BaseAlert
  {
    [JsonProperty("stopId")]
    public string StopId { get; set; }

    [JsonProperty("placesAvailable")]
    public string PlacesAvailable { get; set; }

    [JsonProperty("noOfveichle")]
    public string NoOfVeichle { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(AlertParking).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }

  }
}
