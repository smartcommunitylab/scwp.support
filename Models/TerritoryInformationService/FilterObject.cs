using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TerritoryInformationService
{
  public class FilterObject
  {
    [JsonProperty("myObjects", NullValueHandling=NullValueHandling.Ignore)]
    public bool personalizedObjectsOnly { get; set; }
    
    [JsonProperty("center", NullValueHandling=NullValueHandling.Ignore)]
    public double[] Coordinates{ get; set; }

    [JsonProperty("radius", NullValueHandling = NullValueHandling.Ignore)]
    public double Radius{ get; set; }

    [JsonProperty("types", NullValueHandling = NullValueHandling.Ignore)]
    public List<String> Categories{ get; set; }

    [JsonProperty("fromTime", NullValueHandling = NullValueHandling.Ignore)]
	  public long FromTime{ get; set; }

    [JsonProperty("toTime", NullValueHandling = NullValueHandling.Ignore)]
    public long ToTime{ get; set; }

    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
	  public int NumberOfResults{ get; set; }

    [JsonProperty("skip", NullValueHandling = NullValueHandling.Ignore)]
    public int SkipFirstElements{ get; set; }

    [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
	  public String SearchString{ get; set; }
    
    [JsonProperty("criteria", NullValueHandling = NullValueHandling.Ignore)]
	  public Dictionary<String,Object> MongoFilters{ get; set; }

    [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
    public SortedDictionary<String, int> SortFields { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var proper in typeof(FilterObject).GetProperties())
      {
        sb.AppendFormat("{0}: {1}\n", proper.Name, proper.GetValue(this));
      }
      return sb.ToString();
    }
  }
}
