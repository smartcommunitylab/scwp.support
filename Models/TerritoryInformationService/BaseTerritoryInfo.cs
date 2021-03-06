﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TerritoryInformationService
{
  public class BaseTerritoryInfo
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("source")]
    public string Source { get; set; }

    [JsonProperty("entityId")]
    public string Entityid { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("location")]
    public double[] Location { get; set; }

    [JsonProperty("fromTime")]
    public long? FromTime { get; set; }

    [JsonProperty("toTime")]
    public long? ToTime { get; set; }

    [JsonProperty("timing")]
    public string Timing { get; set; }

    [JsonProperty("customData")]
    public Dictionary<string, object> CustomData { get; set; }

    [JsonProperty("communityData")]
    public CommunityData CommunityDataInfo { get; set; }

    [JsonProperty("creatorId")]
    public string CreatorId { get; set; }

    [JsonProperty("creatorName")]
    public string CreatorName { get; set; }

    [JsonProperty("updateTime")]
    public long Updatetime { get; set; }

    [JsonProperty("version")]
    public int Version { get; set; }

    [JsonProperty("domainType")]
    public string DomainType { get; set; }

    [JsonProperty("domainId")]
    public string DomainId { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(BaseTerritoryInfo).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }

  public class CommunityData
  {
    [JsonProperty("tags")]
    public List<Tag> Tags { get; set; }

    [JsonProperty("averageRating")]
    public double AverageRating { get; set; }

    [JsonProperty("rating")]
    public object RatingMap { get; set; }

    [JsonProperty("following")]
    public object Following { get; set; }

    [JsonProperty("ratingsCount")]
    public int RatingsCount { get; set; }

    [JsonProperty("followsCount")]
    public string FollowsCount { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(CommunityData).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }

  }
}
