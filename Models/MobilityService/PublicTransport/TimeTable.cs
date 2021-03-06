﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService.PublicTransport
{
  public class TimeTable
  {
    [JsonProperty("tripIds")]
    public List<List<string>> TripsId { get; set; }

    [JsonProperty("stops")]
    public List<string> Stops { get; set; }

    [JsonProperty("stopsId")]
    public List<string> StopsId { get; set; }
   
    [JsonProperty("times")]
    public List<List<string>> Times { get; set; }

    [JsonProperty("delays")]
    public List<List<Delay>> Delays { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(TimeTable).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }

  }
}
