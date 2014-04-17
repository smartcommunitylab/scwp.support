using Models.ProfileService;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ProfileLibrary
{
  public class ProfileLibrary
  {
    WebClient WebCli;
    string AccessToken;

    public ProfileLibrary(string accessToken)
    {
      this.AccessToken = accessToken;
      WebCli = new WebClient();
    }

    public async Task<BasicProfile> GetBasicProfile()
    {
      WebCli.Headers["Authorization"] = string.Format("Bearer {0}", AccessToken);
      string JSONResult = await WebCli.DownloadStringTaskAsync(ProfileUriHelper.BuildUriForBasicProfile());

      return Newtonsoft.Json.JsonConvert.DeserializeObject<BasicProfile>(JSONResult);
    }

    public async Task<BasicProfile> GetBasicAccount()
    {
      WebCli.Headers["Authorization"] = string.Format("Bearer {0}", AccessToken);
      string JSONResult = await WebCli.DownloadStringTaskAsync(ProfileUriHelper.BuildUriForBasicAccount());

      return Newtonsoft.Json.JsonConvert.DeserializeObject<BasicProfile>(JSONResult);
    }

    public async Task<List<ExtendedProfile>> GetBasicProfile(string code)
    {
      WebCli.Headers["Authorization"] = string.Format("Bearer {0}", AccessToken);
      string JSONResult = await WebCli.DownloadStringTaskAsync(ProfileUriHelper.BuildUriForBasicProfile());

      return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExtendedProfile>>(JSONResult);
    }
  }
}
