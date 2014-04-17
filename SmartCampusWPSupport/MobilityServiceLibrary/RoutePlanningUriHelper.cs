using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilityServiceLibrary
{
  public class RoutePlanningUriHelper
  {
    static string BaseUrl = "https://vas-dev.smartcampuslab.it/core.mobility";
    static string SingleJourneryUrl = "plansinglejourney";
    static string RecurrentJourneyUrl = "planrecurrent";

    public static Uri GetSingleJourneyUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", BaseUrl, SingleJourneryUrl));
      return ub.Uri;
    }

    public static Uri GetRecurrentJourneyUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", BaseUrl, RecurrentJourneyUrl));
      return ub.Uri;
    }
  }
}
