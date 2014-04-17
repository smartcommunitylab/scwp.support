using Models.MobilityService.Journeys;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MobilityServiceLibrary
{
  public class RoutePlanningLibrary
  {
    WebClient WebCli;
    string AccessToken;

    public RoutePlanningLibrary(string accessToken)
    {
      this.AccessToken = accessToken;
      WebCli = new WebClient();
    }

    public async Task<List<Itinerary>> PlanSingleJourney(SingleJourney sj)
    {
      string toPost = JsonConvert.SerializeObject(sj);

      WebCli.Headers["Authorization"] = string.Format("Bearer {0}", AccessToken);
      WebCli.Headers["Accept"] = "application/json";
      var res = await WebCli.UploadStringTaskAsync(RoutePlanningUriHelper.GetSingleJourneyUri(), toPost);

      return JsonConvert.DeserializeObject <List<Itinerary>>(res);
    }

    public async Task<RecurrentJourney> PlanRecurrentJourney(RecurrentJourneyParameters rjp)
    {
      string toPost = JsonConvert.SerializeObject(rjp);
      
      WebCli.Headers["Authorization"] = string.Format("Bearer {0}", AccessToken);
      WebCli.Headers["Accept"] = "application/json";
      var res = await WebCli.UploadStringTaskAsync(RoutePlanningUriHelper.GetRecurrentJourneyUri(), toPost);

      return JsonConvert.DeserializeObject<RecurrentJourney>(res);
    }
  }
}
