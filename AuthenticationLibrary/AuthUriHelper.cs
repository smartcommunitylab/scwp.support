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


namespace AuthenticationLibrary
{
  /// <summary>
  /// Helper class for the authentication library, contains static functions that 
  /// generate already-formatted URIs for using within the authentication library
  /// </summary>
  public static class AuthUriHelper
  {
    static string baseUrl = "https://vas-dev.smartcampuslab.it/";
    static string getCodeUrl = "aac/eauth/authorize";
    static string getTokenUrl = "aac/oauth/token";
    static string revokeTokenUrl = "aac/eauth/revoke";

    /// <summary>
    /// Creates a formatted URI to use in the application authentication process
    /// </summary>
    /// <param name="clientId">The application client ID</param>
    /// <param name="redirectUrl">The address at which the user's browser will be redirected after the required permissions are accepted by the user</param>
    /// <returns>A ready to use URI to which the user's browser must navigate in order to begin OAuth authentication</returns>
    public static Uri GetCodeUri(string clientId, string redirectUrl)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}{1}",baseUrl,getCodeUrl));
      
      Dictionary<string, string> stringQuery = new Dictionary<string, string>();
      stringQuery["client_id"] = clientId;
      stringQuery["response_type"] = "code";
      stringQuery["redirect_uri"] = redirectUrl;
      ub.Query = QueryHelper.DictionaryToQuery(stringQuery);

      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to use in the token generation process
    /// </summary>
    /// <returns>A ready to use URI to which a WebClient must be pointed in order to obtain the access token</returns>
    public static Uri GetTokenUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}{1}", baseUrl, getTokenUrl));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to use in the token refreshing process
    /// </summary>    
    /// <param name="refreshToken">The refresh token provided by the SmartCampus authorization server</param>
    /// <param name="clientSecret">The application client secret</param>
    /// <param name="clientId">The application client ID</param>
    /// <returns>A ready to use URI to which a WebClient must be pointed to in order to refresh the access token</returns>
    public static Uri GetRefreshTokenUri(string refreshToken, string clientSecret, string clientId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}{1}", baseUrl, getTokenUrl));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to use in the token revoking process
    /// </summary>
    /// <param name="accessToken">The access token provided by the SmartCampus</param>
    /// <returns>A ready to use URI to which a WebClient must be pointed to in order to revoke the access token</returns>
    public static Uri GetRevokeTokenUri(string accessToken)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}{1}/{2}", baseUrl, revokeTokenUrl, accessToken));
      return ub.Uri;
    }
  }
}
