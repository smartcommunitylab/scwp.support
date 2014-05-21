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
  public class RealTimeUpdateLibrary
  {
    HttpClient httpCli;
    string accessToken;

    public RealTimeUpdateLibrary(string accessToken, string serverUrl)
    {
      RealTimeUpdateUriHelper.SetBaseUrl(serverUrl);
      this.accessToken = accessToken;
      httpCli = new HttpClient();
    }

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
