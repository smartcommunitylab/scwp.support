using Models.MobilityService.RealTime;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MobilityServiceLibrary
{
  public class RealTimeUpdateLibrary
  {
    WebClient WebCli;
    string AccessToken;

    public RealTimeUpdateLibrary(string accessToken)
    {
      this.AccessToken = accessToken;
      WebCli = new WebClient();
    }

    public void SignalAlert<GenAlertType>( GenAlertType baAlert)
    {
      string toPost = JsonConvert.SerializeObject(baAlert);

      WebCli.Headers["Authorization"] = string.Format("Bearer {0}", AccessToken);
      WebCli.Headers["Accept"] = "application/json";

      WebCli.UploadStringAsync(RealTimeUpdateUriHelper.GetSignalUri(), toPost);
    }

  }
}
