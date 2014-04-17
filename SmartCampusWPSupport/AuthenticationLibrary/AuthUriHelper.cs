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
  public static class AuthUriHelper
  {
    static string BaseUrl = "https://vas-dev.smartcampuslab.it/";
    static string GetCodeUrl = "aac/eauth/authorize";
    static string GetTokenUrl = "aac/oauth/token";
    static string RevokeTokenUrl = "aac/eauth/revoke";

    public static Uri BuildUriForCode(string clientId, string redirectUrl)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}{1}",BaseUrl,GetCodeUrl));
      
      Dictionary<string, string> StringQuery = new Dictionary<string, string>();
      StringQuery["client_id"] = clientId;
      StringQuery["response_type"] = "code";
      StringQuery["redirect_uri"] = redirectUrl;
      ub.Query = QueryHelper.DictionaryToQuery(StringQuery);

      return ub.Uri;
    }

    public static Uri BuildUriForToken()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}{1}", BaseUrl, GetTokenUrl));
      return ub.Uri;
    }

    public static Uri BuildUriForRefreshToken(string refreshToken, string clientSecret, string clientId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}{1}", BaseUrl, GetTokenUrl));
      return ub.Uri;
    }

    public static Uri BuildUriForRevokeToken(string accessToken)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}{1}/{2}", BaseUrl, RevokeTokenUrl, accessToken));
      return ub.Uri;
    }
  }
}
