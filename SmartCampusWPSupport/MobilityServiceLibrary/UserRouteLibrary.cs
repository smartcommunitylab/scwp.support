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
    HttpClient webCli;
    string accessToken;

    public UserRouteLibrary(string accessToken)
    {
      this.accessToken = accessToken;
      webCli = new HttpClient();
    }

    #region Single journey

    public async Task<BasicItinerary> SaveSingleJourney(BasicItinerary basIti)
    {
      string toPost = JsonConvert.SerializeObject(basIti);

      StringContent sc = new StringContent(toPost);
      sc.Headers.Add("Accept", "application/json");
      sc.Headers.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var res = await webCli.PostAsync(UserRouteUriHelper.GetSaveSingleJourneyUri(), sc);

      return JsonConvert.DeserializeObject<BasicItinerary>(await res.Content.ReadAsStringAsync());
    }
    /*
    public async Task<BasicItinerary> ReadSingleJourney(int journeyId)
    {
      webCli.Headers["Authorization"] = string.Format("Bearer {0}", accessToken);
      webCli.Headers["Accept"] = "application/json";
      var res = await webCli.DownloadStringTaskAsync(UserRouteUriHelper.GetReadSingleJourneyUri(journeyId));

      return JsonConvert.DeserializeObject<BasicItinerary>(res);
    }

    public async Task<List<BasicItinerary>> ReadAllSingleJourneys()
    {
      webCli.Headers["Authorization"] = string.Format("Bearer {0}", accessToken);
      webCli.Headers["Accept"] = "application/json";
      var res = await webCli.DownloadStringTaskAsync(UserRouteUriHelper.GetReadAllSingleJourneysUri());

      return JsonConvert.DeserializeObject<List<BasicItinerary>>(res);
    }

    public async Task<bool> SetMonitorSingleJourney(int journeyId, bool monitor)
    {
      webCli.Headers["Authorization"] = string.Format("Bearer {0}", accessToken);
      webCli.Headers["Accept"] = "application/json";
      var res = await webCli.DownloadStringTaskAsync(UserRouteUriHelper.GetReadAllSingleJourneysUri());

      return Convert.ToBoolean(res);
    }
    */
    //public async Task<bool> DeleteSingleJourney(int journeyId)
    //{
    //  webCli.Headers["Authorization"] = string.Format("Bearer {0}", accessToken);
    //  webCli.Headers["Accept"] = "application/json";
    //  var res = await webCli.UploadStringTaskAsync( DownloadStringTaskAsync(UserRouteUriHelper.GetReadAllSingleJourneysUri(), );

    //  return Convert.ToBoolean(res);
    //}
       

    #endregion
  }
}
