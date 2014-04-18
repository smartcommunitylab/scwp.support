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
    WebClient webCli;
    string accessToken;

    public RealTimeUpdateLibrary(string accessToken)
    {
      this.accessToken = accessToken;
      webCli = new WebClient();
    }

    public void SignalAlert<GenAlertType>( GenAlertType baAlert)
    {
      string toPost = JsonConvert.SerializeObject(baAlert);

      webCli.Headers["Authorization"] = string.Format("Bearer {0}", accessToken);
      webCli.Headers["Accept"] = "application/json";

      webCli.UploadStringAsync(RealTimeUpdateUriHelper.GetSignalUri(), toPost);
    }

  }
}
