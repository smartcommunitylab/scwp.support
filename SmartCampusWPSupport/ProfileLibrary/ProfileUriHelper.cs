using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
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
  public static class ProfileUriHelper
  {
    static string BaseUrl = "https://vas-dev.smartcampuslab.it/";
    static string BasicProfileUrl = "aac/basicprofile";
    static string BasicAccountProfileUrl = "/aac/accountprofile";
    static string ExtendedProfilesUrl = "/core.profile/extprofile";
    static string CurrentProfileId = "me";

    #region Basic

    public static Uri BuildUriForBasicProfile()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}{1}/{2}",BaseUrl,BasicProfileUrl, CurrentProfileId));
      return ub.Uri;
    }

    public static Uri BuildUriForBasicAccount()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}{1}/{2}", BaseUrl, BasicAccountProfileUrl, CurrentProfileId));
      return ub.Uri;
    }

    #endregion

    #region Extended

    public static Uri BuildUriForExtendedProfiles()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}{1}/{2}", BaseUrl, ExtendedProfilesUrl, CurrentProfileId));
      return ub.Uri;
    }

    #endregion

  }
}
