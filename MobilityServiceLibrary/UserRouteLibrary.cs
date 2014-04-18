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
  public class UserRouteLibrary
  {
    HttpClient httpCli;
    string accessToken;

    public UserRouteLibrary(string accessToken)
    {
      this.accessToken = accessToken;
      httpCli = new HttpClient();
    }

    #region Single journey

    public async Task<BasicItinerary> SaveSingleJourney(BasicItinerary basIti)
    {
      string toPost = JsonConvert.SerializeObject(basIti);

      StringContent sc = new StringContent(toPost);
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var res = await httpCli.PostAsync(UserRouteUriHelper.GetSaveSingleJourneyUri(), sc);

      return JsonConvert.DeserializeObject<BasicItinerary>(await res.Content.ReadAsStringAsync());
    }

    public async Task<BasicItinerary> ReadSingleJourney(int journeyId)
    {
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var res = await httpCli.GetStringAsync(UserRouteUriHelper.GetReadSingleJourneyUri(journeyId));

      return JsonConvert.DeserializeObject<BasicItinerary>(res);
    }

    public async Task<List<BasicItinerary>> ReadAllSingleJourneys()
    {
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var res = await httpCli.GetStringAsync(UserRouteUriHelper.GetReadAllSingleJourneysUri());

      return JsonConvert.DeserializeObject<List<BasicItinerary>>(res);
    }

    public async Task<bool> SetMonitorSingleJourney(int journeyId, bool monitor)
    {
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var res = await httpCli.GetStringAsync(UserRouteUriHelper.GetReadAllSingleJourneysUri());

      return Convert.ToBoolean(res);
    }

    public async Task<bool> DeleteSingleJourney(int journeyId)
    {
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var res = await httpCli.DeleteAsync(UserRouteUriHelper.GetReadAllSingleJourneysUri());

      return Convert.ToBoolean(await res.Content.ReadAsStringAsync());
    }


    #endregion
  }
}
