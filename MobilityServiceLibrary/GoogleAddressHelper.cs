using Models.GoogleMapsAPI;
using Models.MobilityService.Journeys;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobilityServiceLibrary
{
  public class GoogleAddressLibrary
  {
    string baseUrl = "http://maps.googleapis.com/maps/api/geocode/json?address=";
    HttpClient httpCli;

    public GoogleAddressLibrary()
    {
      httpCli = new HttpClient();
    }

    public async Task<List<Position>> GetPositionsForAutocomplete(string query)
    {
      List<Position> l = new List<Position>();
      var gRes = JsonConvert.DeserializeObject<GoogleJSONObj>( await httpCli.GetStringAsync(baseUrl + Uri.EscapeUriString(query)));
      l = gRes.Results.Select(x => new Position()
                                   { 
                                     Name = x.FormattedAddress, 
                                     Latitude = x.Geometry.Location.Latitude.ToString(), 
                                     Longitude = x.Geometry.Location.Longitude.ToString()
                                   }).ToList();

      return l;
    }
  }
}
