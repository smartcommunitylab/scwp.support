using Models.MobilityService.RealTime;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.Journeys
{
  public class Leg
  {
    [JsonProperty("legId", Order=10)]
    public string LegId { get; set; }

    [JsonProperty("startime", Order=4)]
    public long StartTime { get; set; }

    [JsonProperty("endtime", Order=1)]
    public long EndTime { get; set; }

    [JsonProperty("duration", Order=3)]
    public int Duration { get; set; }

    [JsonProperty("from", Order=8)]
    public Position From { get; set; }

    [JsonProperty("to", Order=0)]
    public Position To { get; set; }

    [JsonProperty("transport", Order=5)]
    public Transport TransportInfo { get; set; }

    [JsonProperty("legGeometry", Order=9, NullValueHandling=NullValueHandling.Ignore)]
    public LegGeometry LegGeometryInfo { get; set; }

    [JsonProperty("alertStrikeList", Order=7)]
    public List<AlertStrike> AlertStrikeList { get; set; }

    [JsonProperty("alertDelayList", Order=6)]
    public List<AlertDelay> AlertDelays { get; set; }

    [JsonProperty("alertParkingList", Order=2)]
    public List<AlertParking> AlertParkings { get; set; }

    //[JsonProperty("alertRoadList")]
    //public List<AlertRoad> AlertRoads { get; set; }

    //[JsonProperty("alertAccidentList")]
    //public List<AlertAccident> AlertAccidents { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(Leg).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }

  }

  public class LegGeometry
  {
    [JsonProperty("length")]
    public int Length { get; set; }

    [JsonProperty("points")]
    public string Points { get; set; }

    [JsonProperty("levels")]
    public string Levels { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(LegGeometry).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
