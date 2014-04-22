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


namespace ProfileServiceLibrary
{
  /// <summary>
  /// Helper class for the profile library, contains static functions that 
  /// generate already-formatted URIs for using within the profile library
  /// </summary>
  public static class ProfileUriHelper
  {
    static string baseUrl = "https://vas-dev.smartcampuslab.it";
    static string basicProfileUrl = "aac/basicprofile";
    static string basicAccountProfileUrl = "aac/accountprofile";
    static string extendedProfilesUrl = "core.profile/extprofile";
    static string currentProfileId = "me";

    #region Basic

    /// <summary>
    /// Creates a formatted URI to use for basic profile retrieval
    /// </summary>
    /// <returns>A ready to use URI to which a WebClient must be pointed in order to obtain basic profile informations</returns>
    public static Uri GetBasicProfileUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}",baseUrl,basicProfileUrl, currentProfileId));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to use for basic account retrieval
    /// </summary>
    /// <returns>A ready to use URI to which a WebClient must be pointed in order to obtain basic account informations</returns>
    public static Uri GetBasicAccountUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, basicAccountProfileUrl, currentProfileId));
      return ub.Uri;
    }

    #endregion

    #region Extended

    /// <summary>
    /// Creates a formatted URI to use for extended profile retrieval
    /// </summary>
    /// <returns>A ready to use URI to which a WebClient must be pointed in order to obtain extended profile informations</returns>
    public static Uri GetExtendedProfilesUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, extendedProfilesUrl, currentProfileId));
      return ub.Uri;
    }

    #endregion

  }
}
