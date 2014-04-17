using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationLibrary
{
  public class AuthLibrary
  {
    string ClientId;
    string ClientSecret;
    string RedirectUrl;
    string AccessToken;
    string RefreshToken;
    string Code;


    public AuthLibrary(string clientId, string clientSecret, string redirectUrl)
    {
      this.ClientId = clientId;
      this.ClientSecret = clientSecret;
      this.RedirectUrl = redirectUrl;
    }

    public AuthLibrary(string clientId, string clientSecret, string redirectUrl, string accessToken, string refreshToken)
    {
      this.ClientId = clientId;
      this.ClientSecret = clientSecret;
      this.RedirectUrl = redirectUrl;
      this.AccessToken = accessToken;
      this.RefreshToken = refreshToken;      
    }

    public async Task<string>
  }
}
