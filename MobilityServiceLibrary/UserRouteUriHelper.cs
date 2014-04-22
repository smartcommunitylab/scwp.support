using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilityServiceLibrary
{
  /// <summary>
  /// Helper class for the User Route library, contains static functions that 
  /// generate already-formatted URIs for using within the User Route library
  /// </summary>
  public static class UserRouteUriHelper
  {
    static string baseUrl = "https://vas-dev.smartcampuslab.it/core.mobility";
    static string itineraryUrl = "itinerary";
    static string recurrentUrl = "recurrent";

    #region Single journey

    /// <summary>
    /// Creates a formatted URI to store a planned journey
    /// </summary>
    /// <returns>A ready to use URI to use in order to store a planned journey to the server</returns>
    public static Uri GetSaveSingleJourneyUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, itineraryUrl));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to retrieve a planned journey
    /// </summary>
    /// <param name="journeyId">The unique identifier for the desired journey</param>
    /// <returns>A ready to use URI for retrieving a specific journey from the server</returns>
    public static Uri GetReadSingleJourneyUri(int journeyId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, itineraryUrl, journeyId));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to retrieve all planned journeys
    /// </summary>
    /// <returns>A ready to use URI for retrieving all journeys from the server</returns>
    public static Uri GetReadAllSingleJourneysUri()
    {
      return GetSaveSingleJourneyUri();
    }

    /// <summary>
    /// Creates a formatted URI to set the monitoring status on a specific journey
    /// </summary>
    /// <param name="journeyId">The unique identifier for the desired journey</param>
    /// <param name="monitor">The value indicating whether to start or stop monitoring the journey</param>
    /// <returns>A ready to use URI for setting the monitoring status on a specific journey</returns>
    public static Uri GetMonitorSingleJourneyUri(int journeyId, bool monitor)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/monitor/{3}", baseUrl, itineraryUrl, journeyId, monitor));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to delete a specific journey
    /// </summary>
    /// <param name="journeyId">The unique identifier for the desired journey</param>
    /// <returns>A ready to use URI for deleting a specific journey</returns>
    public static Uri GetDeleteSingleJourneyUri(int journeyId)
    {
      return GetReadSingleJourneyUri(journeyId);
    }

    #endregion

    #region Recurrent Journey

    /// <summary>
    /// Creates a formatted URI to store a planned recurrent journey
    /// </summary>
    /// <returns>A ready to use URI to use in order to store a planned recurrent journey to the server</returns>
    public static Uri GetSaveRecurrentJourneyUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, recurrentUrl));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to retrieve a planned recurrent journey
    /// </summary>
    /// <param name="journeyId">The unique identifier for the desired recurrent journey</param>
    /// <returns>A ready to use URI for retrieving a specific recurrent journey from the server</returns>
    public static Uri GetReadRecurrentJourneyUri(int journeyId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, recurrentUrl, journeyId));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to retrieve all planned recurrent journeys
    /// </summary>
    /// <returns>A ready to use URI for retrieving all journeys from the server</returns>
    public static Uri GetReadAllRecurrentJourneysUri()
    {
      return GetSaveRecurrentJourneyUri();
    }

    /// <summary>
    /// Creates a formatted URI to set the monitoring status on a specific recurrent journey
    /// </summary>
    /// <param name="journeyId">The unique identifier for the desired recurrent journey</param>
    /// <param name="monitor">The value indicating whether to start or stop monitoring the recurrent journey</param>
    /// <returns>A ready to use URI for setting the monitoring status on a specific recurrent journey</returns>
    public static Uri GetMonitorReccurrentJourneyUri(int journeyId, bool monitor)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/monitor/{3}", baseUrl, recurrentUrl, journeyId, monitor));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to update a specific recurrent journey already stored to the server
    /// </summary>
    /// <param name="journeyId">The unique identifier for the desired journey</param>
    /// <returns>A ready to use URI for updating a specific recurrent journey</returns>
    public static Uri GetUpdateRecurrentJourneyUri(int journeyId)
    {
      return GetReadRecurrentJourneyUri(journeyId);
    }

    /// <summary>
    /// Creates a formatted URI to delete a specific recurrent journey
    /// </summary>
    /// <param name="journeyId">The unique identifier for the desired recurrent journey</param>
    /// <returns>A ready to use URI for deleting a specific recurrent journey</returns>
    public static Uri GetDeleteRecurrentJourneyUri(int journeyId)
    {
      return GetReadRecurrentJourneyUri(journeyId);
    }

    #endregion
  }
}
