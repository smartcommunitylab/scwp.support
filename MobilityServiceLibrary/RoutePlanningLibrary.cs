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
  public class RoutePlanningLibrary
  {
    HttpClient httpCli;
    string accessToken;

    public RoutePlanningLibrary(string accessToken)
    {
      this.accessToken = accessToken;
      httpCli = new HttpClient();
    }

    public async Task<List<Itinerary>> PlanSingleJourney(SingleJourney sj)
    {
      string toPost = JsonConvert.SerializeObject(sj);
      StringContent sc = new StringContent(toPost);
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var res = await httpCli.PostAsync(RoutePlanningUriHelper.GetSingleJourneyUri(), sc);

      return JsonConvert.DeserializeObject<List<Itinerary>>(await res.Content.ReadAsStringAsync());
    }

    public async Task<RecurrentJourney> PlanRecurrentJourney(RecurrentJourneyParameters rjp)
    {
      string toPost = JsonConvert.SerializeObject(rjp);

      StringContent sc = new StringContent(toPost);
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var res = await httpCli.PostAsync(RoutePlanningUriHelper.GetRecurrentJourneyUri(), sc);

      return JsonConvert.DeserializeObject<RecurrentJourney>(await res.Content.ReadAsStringAsync());
    }
  }
}
