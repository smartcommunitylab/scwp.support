using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.AuthorizationService;
using System.Net;

namespace AuthenticationLibrary
{
  public class AuthLibrary
  {
    WebClient WebCli;
    string ClientId;
    string ClientSecret;
    string RedirectUrl;
    string AccessToken;
    string RefreshToken;


    public AuthLibrary(string clientId, string clientSecret, string redirectUrl)
    {
      this.ClientId = clientId;
      this.ClientSecret = clientSecret;
      this.RedirectUrl = redirectUrl;
      WebCli = new WebClient();
    }

    public AuthLibrary(string clientId, string clientSecret, string redirectUrl, string accessToken, string refreshToken)
      : this(clientId, clientSecret, redirectUrl)
    {
      this.AccessToken = accessToken;
      this.RefreshToken = refreshToken;
    }

    public async Task<TokenModel> GetAccessToken(string code)
    {
      Dictionary<string, string> StringPost = new Dictionary<string, string>();

      StringPost["client_id"] = ClientId;
      StringPost["client_secret"] = ClientSecret;
      StringPost["code"] = code;
      StringPost["redirect_uri"] = RedirectUrl;
      StringPost["grant_type"] = "authorization_code";

      WebCli.Headers["Content-Type"] = "application/x-www-form-urlencoded";
      string JSONResult = await WebCli.UploadStringTaskAsync(AuthUriHelper.BuildUriForToken(), QueryHelper.DictionaryToPostData(StringPost));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<TokenModel>(JSONResult);
    }

    public async Task<TokenModel> RefreshAccessToken(string code)
    {
      Dictionary<string, string> StringPost = new Dictionary<string, string>();

      StringPost["client_id"] = ClientId;
      StringPost["client_secret"] = ClientSecret;
      StringPost["refresh_token"] = RefreshToken;
      StringPost["grant_type"] = "refresh_token";

      WebCli.Headers["Content-Type"] = "application/x-www-form-urlencoded";
      string JSONResult = await WebCli.UploadStringTaskAsync(AuthUriHelper.BuildUriForToken(), QueryHelper.DictionaryToPostData(StringPost));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<TokenModel>(JSONResult);
    }

    public void RevokeAccessToken()
    {
      WebCli.DownloadStringAsync(AuthUriHelper.BuildUriForRevokeToken(AccessToken));
    }

  }
}
