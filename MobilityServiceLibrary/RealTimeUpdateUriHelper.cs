using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilityServiceLibrary
{
  public static class RealTimeUpdateUriHelper
  {
    public static void SetBaseUrl(string serverUrl)
    {
      baseUrl = serverUrl + "core.mobility";
    }
    static string baseUrl;

    static string userAlert = "alert/user";
    
    public static Uri GetSignalUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, userAlert));
      return ub.Uri;
    }
  }
}
