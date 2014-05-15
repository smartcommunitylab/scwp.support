using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilityServiceLibrary
{
  /// <summary>
  /// Helper class for the Route Planning library, contains static functions that 
  /// generate already-formatted URIs for using within the Route Planning library
  /// </summary>
  public static class RoutePlanningUriHelper
  {

    public static void SetBaseUrl(string serverUrl)
    {
      baseUrl = serverUrl + "core.mobility";
    }
    static string baseUrl;
    
    static string singleJourneryUrl = "plansinglejourney";
    static string recurrentJourneyUrl = "planrecurrent";

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static Uri GetSingleJourneyUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, singleJourneryUrl));
      return ub.Uri;
    }

    public static Uri GetRecurrentJourneyUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, recurrentJourneyUrl));
      return ub.Uri;
    }
  }
}
