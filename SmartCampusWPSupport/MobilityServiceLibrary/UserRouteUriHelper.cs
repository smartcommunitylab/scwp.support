using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilityServiceLibrary
{
  public static class UserRouteUriHelper
  {
    static string baseUrl = "https://vas-dev.smartcampuslab.it/core.mobility";
    static string itineraryUrl = "itinerary";
    static string recurrentUrl = "recurrent";

    #region Single journey

    public static Uri GetSaveSingleJourneyUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, itineraryUrl));
      return ub.Uri;
    }

    public static Uri GetReadSingleJourneyUri(int journeyId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, itineraryUrl, journeyId));
      return ub.Uri;
    }

    public static Uri GetReadAllSingleJourneysUri()
    {
      return GetSaveSingleJourneyUri();
    }

    public static Uri GetMonitorSingleJourneyUri(int journeyId, bool monitor)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/monitor/{3}", baseUrl, itineraryUrl, journeyId, monitor));
      return ub.Uri;
    }

    public static Uri GetDeleteSingleJourneyUri(int journeyId)
    {
      return GetReadSingleJourneyUri(journeyId);
    }

    #endregion

    #region Recurrent Journey

    public static Uri GetSaveRecurrentJourneyUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, recurrentUrl));
      return ub.Uri;
    }

    public static Uri GetReadRecurrentJourneyUri(int journeyId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, recurrentUrl, journeyId));
      return ub.Uri;
    }

    public static Uri GetReadAllRecurrentJourneysUri()
    {
      return GetSaveRecurrentJourneyUri();
    }

    public static Uri GetMonitorReccurrentJourneyUri(int journeyId, bool monitor)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/monitor/{3}", baseUrl, recurrentUrl, journeyId, monitor));
      return ub.Uri;
    }

    public static Uri GetUpdateRecurrentJourneyUri(int journeyId)
    {
      return GetReadRecurrentJourneyUri(journeyId);
    }

    public static Uri GetDeleteRecurrentJourneyUri(int journeyId)
    {
      return GetReadRecurrentJourneyUri(journeyId);
    }

    #endregion
  }
}
