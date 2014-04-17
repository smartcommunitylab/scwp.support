using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Models.MobilityService.PublicTransport;
using System.Threading.Tasks;


namespace MobilityServiceLibrary
{
    public class MobilityLibrary
    {
        WebClient WebCli;
    string AccessToken;

    public MobilityLibrary(string accessToken)
    {
      this.AccessToken = accessToken;
      WebCli = new WebClient();
    }

    /*public async Task<Route> GetBasicProfile()
    {
      WebCli.Headers["Authorization"] = string.Format("Bearer {0}", AccessToken);
      WebCli.Headers["Accept"] = "application/json";
    string JSONResult = await WebCli.DownloadStringTaskAsync(ProfileUriHelper.BuildUriForBasicProfile());

      return Newtonsoft.Json.JsonConvert.DeserializeObject<BasicProfile>(JSONResult);
    }*/
    }
}
