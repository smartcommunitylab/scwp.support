using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilityServiceLibrary
{
  public static class RealTimeUpdateUriHelper
  {
    /// <summary>
    /// Sets the base url, used to build all the others
    /// </summary>
    /// <param name="serverUrl">the server address, in the http://yourserverhere/ form, including trailing slash</param>
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
