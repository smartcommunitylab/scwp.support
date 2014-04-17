using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AuthorizationService
{
  class TokenModel
  {
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("token_type")]
    public string AccessToken { get; set; }

    [JsonProperty("refresh_token")]
    public string AccessToken { get; set; }

    [JsonProperty("expires_in")]
    public int AccessToken { get; set; }

    [JsonProperty("scope")]
    public string AccessToken { get; set; }
  }
}
