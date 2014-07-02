using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GeocoderService
{
  public class SCGeoAddress
  {
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("coordinate")]
    public string Coordinate { get; set; }

    [JsonProperty("osm_id")]
    public long OsmId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("osm_key")]
    public string OsmKey { get; set; }

    [JsonProperty("osm_value")]
    public string OsmValue { get; set; }

    [JsonProperty("street")]
    public string Street { get; set; }

    [JsonProperty("postcode")]
    public string Postcode { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("country_de")]
    public string CountryDe { get; set; }

    [JsonProperty("country_en")]
    public string CountryEn { get; set; }

    [JsonProperty("country_fr")]
    public string CountryFr { get; set; }

    [JsonProperty("country_it")]
    public string CountryIt { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("city_it")]
    public string CityIt { get; set; }

    [JsonProperty("places")]
    public string Places { get; set; }

    [JsonProperty("ranking")]
    public int Ranking { get; set; }

    [JsonProperty("name_it")]
    public string NameIt { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder(Name + ", ");
      sb.Append(City != null ? City + ", " : "");
      sb.Append(Postcode != null ? Postcode + ", " : "");
      sb.Append(Country != null ? Country + ", " : "");
      sb.Remove(sb.Length - 2, 2);
      return sb.ToString();
    }
  }
}
