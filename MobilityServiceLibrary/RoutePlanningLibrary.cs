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
    WebClient webCli;
    string accessToken;

    public RoutePlanningLibrary(string accessToken)
    {
      this.accessToken = accessToken;
      webCli = new WebClient();
    }

    public async Task<List<Itinerary>> PlanSingleJourney(SingleJourney sj)
    {
      string toPost = JsonConvert.SerializeObject(sj);

      webCli.Headers["Authorization"] = string.Format("Bearer {0}", accessToken);
      webCli.Headers["Accept"] = "application/json";
      var res = await webCli.UploadStringTaskAsync(RoutePlanningUriHelper.GetSingleJourneyUri(), toPost);

      return JsonConvert.DeserializeObject <List<Itinerary>>(res);
    }

    public async Task<RecurrentJourney> PlanRecurrentJourney(RecurrentJourneyParameters rjp)
    {
      string toPost = JsonConvert.SerializeObject(rjp);
      
      webCli.Headers["Authorization"] = string.Format("Bearer {0}", accessToken);
      webCli.Headers["Accept"] = "application/json";
      var res = await webCli.UploadStringTaskAsync(RoutePlanningUriHelper.GetRecurrentJourneyUri(), toPost);

      return JsonConvert.DeserializeObject<RecurrentJourney>(res);
    }
  }
}
