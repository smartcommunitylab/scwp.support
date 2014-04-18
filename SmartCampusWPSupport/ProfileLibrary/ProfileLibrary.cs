using Models.ProfileService;
using Newtonsoft.Json;
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

namespace ProfileServiceLibrary
{
  /// <summary>
  ///  Class that wraps the the profile APIs in an easy to use way
  /// </summary>
  public class ProfileLibrary
  {
    WebClient webCli;
    string accessToken;

    /// <summary>
    /// Main constructor, to use always
    /// </summary>
    /// <param name="accessToken">The SmartCampus-issued access token</param>
    public ProfileLibrary(string accessToken)
    {
      this.accessToken = accessToken;
      webCli = new WebClient();
    }

    /// <summary>
    /// Asyncronous method that requests a basic profile for the current user to the SmartCampus server
    /// </summary>
    /// <returns>An instance of a BasicProfile object, containing the current user profile</returns>
    public async Task<BasicProfile> GetBasicProfile()
    {
      webCli.Headers["Authorization"] = string.Format("Bearer {0}", accessToken);
      webCli.Headers["Accept"] = "application/json";
      string JSONResult = await webCli.DownloadStringTaskAsync(ProfileUriHelper.GetBasicProfileUri());

      return JsonConvert.DeserializeObject<BasicProfile>(JSONResult);
    }

    /// <summary>
    /// Asyncronous method that requests a basic account for the current user to the SmartCampus server
    /// </summary>
    /// <returns>An instance of an AccountProfile object, containing the current user account</returns>
    public async Task<AccountProfile> GetBasicAccount()
    {
      webCli.Headers["Accept"] = "application/json";
      webCli.Headers["Authorization"] = string.Format("Bearer {0}", accessToken);
      string JSONResult = await webCli.DownloadStringTaskAsync(ProfileUriHelper.GetBasicAccountUri());

      return JsonConvert.DeserializeObject<AccountProfile>(JSONResult);
    }

    /// <summary>
    /// Asyncronous method that requests the full list of existing profiles for the current user to the SmartCampus server
    /// </summary>
    /// <returns>A list of ExtendedProfile objects containing all the extended profiles for the current user</returns>
    public async Task<List<ExtendedProfile>> GetExtendedProfiles()
    {
      webCli.Headers["Accept"] = "application/json";
      webCli.Headers["Authorization"] = string.Format("Bearer {0}", accessToken);
      string JSONResult = await webCli.DownloadStringTaskAsync(ProfileUriHelper.GetExtendedProfilesUri());

      return JsonConvert.DeserializeObject<List<ExtendedProfile>>(JSONResult);
    }
  }
}
