using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TerritoryInformationService
{
  public class SyncObject
  {
    [JsonProperty("version")]
    public long Version { get; set; }

    [JsonProperty("updated")]
    public UpdatedObjects Updates { get; set; }

    [JsonProperty("deleted")]
    public DeletedObjects Deleted { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(SyncObject).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
  public class UpdatedObjects
  {
    [JsonProperty("eu.trentorise.smartcampus.dt.model.POIObject")]
    public List<POIObject> PoiUpdates { get; set; }

    [JsonProperty("eu.trentorise.smartcampus.dt.model.EventObject")]
    public List<EventObject> EventUpdates { get; set; }

    [JsonProperty("eu.trentorise.smartcampus.dt.model.StoryObject")]
    public List<StoryObject> StoryUpdates { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(UpdatedObjects).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
  public class DeletedObjects
  {
    [JsonProperty("eu.trentorise.smartcampus.dt.model.POIObject")]
    public List<string> PoiDeleted { get; set; }

    [JsonProperty("eu.trentorise.smartcampus.dt.model.EventObject")]
    public List<string> EventDeleted { get; set; }

    [JsonProperty("eu.trentorise.smartcampus.dt.model.StoryObject")]
    public List<string> StoryDeleted { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(DeletedObjects).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
