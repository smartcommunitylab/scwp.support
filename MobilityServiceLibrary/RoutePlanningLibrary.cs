using Models.MobilityService.Journeys;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobilityServiceLibrary
{
  /// <summary>
  /// Class that wraps the Route Planning APIs in an easy to use way
  /// </summary>
  public class RoutePlanningLibrary
  {
    HttpClient httpCli;
    string accessToken;

    /// <summary>
    /// Constructor for the RoutePlanningUriHelper class, to use only after an access token is available
    /// </summary>
    /// <param name="accessToken">The SmartCampus-issued access token</param>  
    /// <param name="serverUrl">The SmartCampus server address where all requests will be executed (must include trailing /) </param>
    public RoutePlanningLibrary(string accessToken, string serverUrl)
    {
      RoutePlanningUriHelper.SetBaseUrl(serverUrl);
      this.accessToken = accessToken;
      httpCli = new HttpClient();
    }

    /// <summary>
    /// Asyncronous method that allows the user to query the SmartCampus server for a list of possible trips (one time)
    /// </summary>
    /// <param name="sj">An instance of a SingleJourney object, containing the parameters for the requested trip</param>
    /// <returns>An array of possible itineraries that match the provided parameters</returns>
    public async Task<List<Itinerary>> PlanSingleJourney(SingleJourney sj)
    {
      string toPost = JsonConvert.SerializeObject(sj);
      StringContent sc = new StringContent(toPost, Encoding.UTF8, "application/json");
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var res = await httpCli.PostAsync(RoutePlanningUriHelper.GetSingleJourneyUri(), sc);

      return JsonConvert.DeserializeObject<List<Itinerary>>(await res.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// Asyncronous method that allows the user to query the SmartCampus server for a list of possible trips (recurrent)
    /// </summary>
    /// <param name="rjp">An instance of a RecurrentJourneyParameters object, containing the parameters for the requested trip</param>
    /// <returns>An object containing a list of all available transports for the provided parameters </returns>
    public async Task<RecurrentJourney> PlanRecurrentJourney(RecurrentJourneyParameters rjp)
    {
      string toPost = JsonConvert.SerializeObject(rjp);

      StringContent sc = new StringContent(toPost, Encoding.UTF8, "application/json");
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var res = await httpCli.PostAsync(RoutePlanningUriHelper.GetRecurrentJourneyUri(), sc);
      var utile = await res.Content.ReadAsStringAsync();

      return JsonConvert.DeserializeObject<RecurrentJourney>(utile);
    }


  }
}
