using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilityServiceLibrary
{
  public static class RoutePlanningUriHelper
  {
    static string baseUrl = "https://vas-dev.smartcampuslab.it/core.mobility";
    static string singleJourneryUrl = "plansinglejourney";
    static string recurrentJourneyUrl = "planrecurrent";

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
