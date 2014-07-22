using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilityServiceLibrary
{
  /// <summary>
  /// Helper class for the Real Time Update library, contains static functions that 
  /// generate already-formatted URIs for using within the Real Time Update library
  /// </summary>
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
    
    /// <summary>
    /// Creates a formatted URI to submit an alert
    /// </summary>
    /// <returns>A ready to use Uri to use in order to submit an alert for one of the available transit systems</returns>
    public static Uri GetSignalUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, userAlert));
      return ub.Uri;
    }
  }
}
