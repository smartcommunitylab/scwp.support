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
    [JsonProperty("legId")]
    public int LegId { get; set; }

    [JsonProperty("startTime")]
    public int StartTime { get; set; }
    
    [JsonProperty("endTime")]
    public int EndTime { get; set; }

    [JsonProperty("duration")]
    public int Duration { get; set; }

    [JsonProperty("from")]
    public Position From { get; set; }

    [JsonProperty("to")]
    public Position To { get; set; }
    
    [JsonProperty("transport")]
    public Transport TransportInfo { get; set; }

    [JsonProperty("legGeometry")]
    public LegGeometry LegGeometryInfo {get; set;}

    [JsonProperty("alertStrikeList")]
    public List<AlertStrike> AlertStrikeList {get; set;}

    [JsonProperty("alertDelayList")]
    public List<AlertDelay> AlertDelays {get; set;}


    [JsonProperty("alertParkingList")]
    public List<AlertParking> AlertParkings {get; set;}


    [JsonProperty("alertRoadList")]
    public List<AlertRoad> AlertRoads {get; set;}
    
    [JsonProperty("alertAccidentList")]
    public List<AlertAccident> AlertAccidents {get; set;}
    
  }

  public class LegGeometry
  {
    [JsonProperty("length")]
    public int Length { get; set; }

    [JsonProperty("points")]
    public string Points { get; set; }

    [JsonProperty("levels")]
    public string Levels { get; set; }
  }
}
