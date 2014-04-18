using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.AuthorizationService;
using Newtonsoft.Json;
using System.Net;

namespace AuthenticationLibrary
{

  /// <summary>
  /// Class that wraps the authentication and token management APIs in an easy to use way
  /// </summary>
  public class AuthLibrary
  {
    WebClient webCli;
    string clientId;
    string clientSecret;
    string redirectUrl;
    string accessToken;
    string refreshToken;

    /// <summary>
    /// Main constructor, to use only when an access token is nor already available
    /// </summary>
    /// <param name="clientId">The application client ID</param>
    /// <param name="clientSecret">The application client secret</param>
    /// <param name="redirectUrl">The address at which the user's browser will be redirected after the required permissions are accepted by the user</param>
    public AuthLibrary(string clientId, string clientSecret, string redirectUrl)
    {
      this.clientId = clientId;
      this.clientSecret = clientSecret;
      this.redirectUrl = redirectUrl;
      webCli = new WebClient();
    }

    /// <summary>
    /// Constructor for the AuthLibrary class, to use only after an access token is available
    /// </summary>
    /// <param name="clientId">The application client ID</param>
    /// <param name="clientSecret">The application client secret</param>
    /// <param name="redirectUrl">The address at which the user's browser will be redirected after the required permissions are accepted by the user</param>
    /// <param name="accessToken">The SmartCampus-issued access token</param>
    /// <param name="refreshToken">The SmartCampus-issued refresh token</param>
    public AuthLibrary(string clientId, string clientSecret, string redirectUrl, string accessToken, string refreshToken)
      : this(clientId, clientSecret, redirectUrl)
    {
      this.accessToken = accessToken;
      this.refreshToken = refreshToken;
    }

    /// <summary>
    /// Asyncronous method that requests an access token to the SmartCampus server
    /// </summary>
    /// <param name="code">The one-time code provided by the SmartCampus server after obtaining user's permissions</param>
    /// <returns>The instance of a Token object containing the actual access token and other token-related fields</returns>
    public async Task<Token> GetAccessToken(string code)
    {
      Dictionary<string, string> StringPost = new Dictionary<string, string>();

      StringPost["client_id"] = clientId;
      StringPost["client_secret"] = clientSecret;
      StringPost["code"] = code;
      StringPost["redirect_uri"] = redirectUrl;
      StringPost["grant_type"] = "authorization_code";

      webCli.Headers["Content-Type"] = "application/x-www-form-urlencoded";
      string JSONResult = await webCli.UploadStringTaskAsync(AuthUriHelper.GetTokenUri(), QueryHelper.DictionaryToPostData(StringPost));

      return JsonConvert.DeserializeObject<Token>(JSONResult);
    }

    /// <summary>
    /// Asyncronous method that requests a new access token when the old one is expired
    /// </summary>
    /// <returns>The instance of a new Token object, containing the new access token and other token-related fields</returns>
    public async Task<Token> RefreshAccessToken()
    {
      Dictionary<string, string> StringPost = new Dictionary<string, string>();

      StringPost["client_id"] = clientId;
      StringPost["client_secret"] = clientSecret;
      StringPost["refresh_token"] = refreshToken;
      StringPost["grant_type"] = "refresh_token";

      webCli.Headers["Content-Type"] = "application/x-www-form-urlencoded";
      string JSONResult = await webCli.UploadStringTaskAsync(AuthUriHelper.GetTokenUri(), QueryHelper.DictionaryToPostData(StringPost));

      return JsonConvert.DeserializeObject<Token>(JSONResult);
    }

    /// <summary>
    /// Method that revokes an access token, forcing the user to re-authorize the application
    /// </summary>
    public void RevokeAccessToken()
    {
      webCli.DownloadStringAsync(AuthUriHelper.GetRevokeTokenUri(accessToken));
    }

  }
}
