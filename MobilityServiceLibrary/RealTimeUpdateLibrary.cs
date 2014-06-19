using Models.MobilityService.RealTime;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MobilityServiceLibrary
{
  /// <summary>
  ///  Class that wraps the the real time update API in an easy to use way
  /// </summary>
  public class RealTimeUpdateLibrary
  {
    HttpClient httpCli;
    string accessToken;


    /// <summary>
    /// Constructor for the RealTimeUpdateLibrary class, to use only after an access token is available
    /// </summary>
    /// <param name="accessToken">The SmartCampus-issued access token</param>  
    /// <param name="accessToken">The SmartCampus server address where all requests will be executed (must include trailing /) </param>
    public RealTimeUpdateLibrary(string accessToken, string serverUrl)
    {
      RealTimeUpdateUriHelper.SetBaseUrl(serverUrl);
      this.accessToken = accessToken;
      httpCli = new HttpClient();
    }

    /// <summary>
    /// Asyncronous non-awaitable method that posts a new Alert to the SmartCampus server
    /// </summary>
    /// <typeparam name="GenAlertType">An alert type, can be any kind of alert, as long as it's derived from the BaseAlert class in Models.MobilityService.RealTime</typeparam>
    /// <param name="baAlert">an Alert object of the appropriate type, containing informations about the alert to signal</param>
    public void SignalAlert<GenAlertType>(GenAlertType baAlert)
    {
      string toPost = JsonConvert.SerializeObject(baAlert);
      
      StringContent sc = new StringContent(toPost);
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r")); 
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      httpCli.PostAsync(RealTimeUpdateUriHelper.GetSignalUri(), sc);
    }
  }
}
