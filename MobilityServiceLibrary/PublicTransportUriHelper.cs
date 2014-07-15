using CommonHelpers;
using Models.MobilityService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;


namespace MobilityServiceLibrary
{
  /// <summary>
  /// Helper class for the public transport library, contains static functions that 
  /// generate already-formatted URIs for using within the public transport library
  /// </summary>
  public static class PublicTransportUriHelper
  {
    public static void SetBaseUrl(string serverUrl)
    {
      baseUrl = serverUrl + "core.mobility";
    }
    static string baseUrl;
    static string getRoutesUrl = "getroutes";
    static string getStopsUrl = "getstops";
    static string geoStopsUrl = "geostops";
    static string getTimetableUrl = "gettimetable";
    static string getLimitedTimetableUrl = "getlimitedtimetable";
    static string getTransitTimesUrl = "gettransittimes";
    static string getTransitDelaysUrl = "gettransitdelays";
    static string getParkingsByAgencyUrl = "getparkingsbyagency";
    static string getRoadInfoByAgencyUrl = "getroadinfobyagency";
    static string getReadTimetableCacheUpdatesUrl = "cachestatus";
    static string getReadCacheTimetableUrl = "getcacheupdate";


    /// <summary>
    /// Creates a formatted URI to use for routes retrieval
    /// </summary>
    /// <param name="agencyId">An AgencyType corresponding to the transport service provider</param>
    /// <returns>A ready to use URI for retrieving available routes for the given transport service provider</returns>
    public static Uri GetRoutesUri(AgencyType agencyId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, getRoutesUrl, EnumConverter.ToEnumString<AgencyType>(agencyId)));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to use for stops retrieval
    /// </summary>
    /// <param name="agencyId">An AgencyType corresponding to the transport service provider</param>
    /// <param name="routeId">A string corresponding to the route ID</param>
    /// <returns>A ready to use URI for retrieving available stops for the given transport service provider and route</returns>
    public static Uri GetStopsUri(AgencyType agencyId, string routeId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, getStopsUrl, EnumConverter.ToEnumString<AgencyType>(agencyId), routeId));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to use for retrieve all the stops, filtered by agency and route, which fall in a certain radius
    /// </summary>
    /// <param name="agencyId">An AgencyType corresponding to the transport service provider</param>
    /// <param name="routeId">A string corresponding to the route ID</param>
    /// <param name="latitude">A double corresponding to the latitude</param>
    /// <param name="longitude">A string corresponding to the longitude</param>
    /// <param name="radius">A double corresponding to the area to evaualte (radius of 1 ~ 100km)</param>
    /// <returns>A ready to use URI for retrieving available stops for the given transport service provider and route</returns>
    public static Uri GetStopsUriForRouteByLocation(AgencyType agencyId, string routeId, double latitude, double longitude, double radius)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}", baseUrl, getStopsUrl, EnumConverter.ToEnumString<AgencyType>(agencyId), routeId,
        latitude.ToString().Replace(',', '.'), longitude.ToString().Replace(',', '.'), radius.ToString().Replace(',', '.')));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to use for retrieve all the stops, filtered by agency, which fall in a certain radius
    /// </summary>
    /// <param name="agencyId">An AgencyType corresponding to the transport service provider</param>
    /// <param name="latitude">A double corresponding to the latitude</param>
    /// <param name="longitude">A string corresponding to the longitude</param>
    /// <param name="radius">A double corresponding to the area to evaualte (radius of 1 ~ 100km)</param>
    /// <returns>A ready to use URI for retrieving available stops for the given transport service provider and route</returns>
    public static Uri GetStopsUriByLocation(AgencyType agencyId, double latitude, double longitude, double radius, int page, int count)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}?lat={3}&lng={4}&radius={5}&page={6}&count={7}", baseUrl, geoStopsUrl, EnumConverter.ToEnumString<AgencyType>(agencyId),
        latitude.ToString().Replace(',', '.'), longitude.ToString().Replace(',', '.'), radius.ToString().Replace(',', '.'), page, count));
      return ub.Uri;
    }


    /// <summary>
    /// Creates a formatted URI to use for timetable retrieval
    /// </summary>
    /// <param name="agencyId">An AgencyType corresponding to the transport service provider</param>
    /// <param name="routeId">A string corresponding to the route ID</param>
    /// <param name="stopId">A string corresponding to the stop ID</param>
    /// <returns>A ready to use URI for retrieving the timetable for the given transport service provider, route ID and stop ID</returns>
    public static Uri GetTimetableUri(AgencyType agencyId, string routeId, string stopId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}", baseUrl, getTimetableUrl, EnumConverter.ToEnumString<AgencyType>(agencyId), routeId, stopId));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to use for limited timetable retrieval
    /// </summary>
    /// <param name="agencyId">An AgencyType corresponding to the transport service provider</param>
    /// <param name="stopId">A string corresponding to the stop ID</param>
    /// <param name="numberOfResult">An integer corresponding to the maximum number of results needed</param>
    /// <returns>A ready to use URI for retrieving a timetable for the given transport service provider and stop ID with the specified maximum number of result</returns>
    public static Uri GetLimitedTimetableUri(AgencyType agencyId, string stopId, int numberOfResult)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}", baseUrl, getLimitedTimetableUrl, EnumConverter.ToEnumString<AgencyType>(agencyId), stopId, numberOfResult));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to use for transit times retrieval
    /// </summary>
    /// <param name="routeId">A string corresponding to the route ID</param>
    /// <param name="timeFrom">The timestamp corresponding to the start time</param>
    /// <param name="timeTo">The timestamp corresponding to the end time</param>
    /// <returns>A ready to use URI for retrieving available transit times for the given route ID between a starting time and ending time</returns>
    public static Uri GetTransitTimesUri(string routeId, long timeFrom, long timeTo)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}", baseUrl, getTransitTimesUrl, routeId, timeFrom, timeTo));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to use for transit delays retrieval
    /// </summary>
    /// <param name="routeId">A string corresponding to the route ID</param>
    /// <param name="timeFrom">The timestamp corresponding to the start time</param>
    /// <param name="timeTo">The timestamp corresponding to the end time</param>
    /// <returns>A ready to use URI for retrieving available transit delays for the given route ID between a starting time and ending time</returns>
    public static Uri GetTransitDelaysUri(string routeId, long timeFrom, long timeTo)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}", baseUrl, getTransitDelaysUrl, routeId, timeFrom, timeTo));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to use for parkings info retrieval
    /// </summary>
    /// <param name="agencyId">An AgencyType corresponding to the transport service provider</param>
    /// <returns>A ready to use URI for retrieving available parking info for the given transport service provider</returns>
    public static Uri GetParkingsByAgencyUri(AgencyType agencyId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, getParkingsByAgencyUrl, EnumConverter.ToEnumString<AgencyType>(agencyId)));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to use for road info retrieval
    /// </summary>
    /// <param name="agencyId">An AgencyType corresponding to the transport service provider</param>
    /// <param name="timeFrom">The timestamp corresponding to the start time</param>
    /// <param name="timeTo">The timestamp corresponding to the end time</param>
    /// <returns>A ready to use URI for retrieving available road info for the given route ID between a starting time and ending time</returns>
    public static Uri GetRoadInfoByAgencyUri(AgencyType agencyId, long timeFrom, long timeTo)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}", baseUrl, getRoadInfoByAgencyUrl, EnumConverter.ToEnumString<AgencyType>(agencyId), timeFrom, timeTo));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to use for timetable cache updates retrieval
    /// </summary>
    /// <returns>A ready to use URI for retrieving timetable cache updates</returns>
    public static Uri GetReadTimetableCacheUpdatesUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, getReadTimetableCacheUpdatesUrl));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to use for single timetable cache retrieval
    /// </summary>
    /// <param name="agencyId">An AgencyType corresponding to the transport service provider</param>
    /// <param name="fileId">A string corresponding to the file id</param>
    /// <returns>A ready to use URI for retrieving timetable cache</returns>
    public static Uri GetReadSingleTimetableCacheUpdatesUri(AgencyType agencyId, string fileId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, getReadCacheTimetableUrl, EnumConverter.ToEnumString<AgencyType>(agencyId), fileId));
      return ub.Uri;
    }

  }
}
