using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Models.MobilityService.PublicTransport;
using System.Threading.Tasks;
using Models.MobilityService;
using System.Collections.Generic;
using Models.MobilityService.RealTime;
using System.Net.Http;


namespace MobilityServiceLibrary
{
  /// <summary>
  ///  Class that wraps the the public transport APIs in an easy to use way
  /// </summary>
  public class PublicTransportLibrary
  {
    HttpClient httpCli;
    string accessToken;


    /// <summary>
    /// Constructor for the PublicTransportLibrary class, to use only after an access token is available
    /// </summary>
    /// <param name="accessToken">The SmartCampus-issued access token</param>        
    public PublicTransportLibrary(string accessToken)
    {
      this.accessToken = accessToken;
      httpCli = new HttpClient();
    }

    /// <summary>
    /// Asyncronous method that requests all the routes for a specific public transport provider to the SmartCampus server
    /// </summary>
    /// <param name="agency">An AgencyType corresponding to the transport service provider</param>
    /// <returns>List of Routes</returns>
    public async Task<List<Route>> GetRoutes(AgencyType agency)
    {
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(PublicTransportUriHelper.GetRoutesUri(agency));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Route>>(JSONResult);
    }

    /// <summary>
    /// Asyncronous method that requests the available stops for the given route ID and public transport provider to the SmartCampus server
    /// </summary>
    /// <param name="agency">An AgencyType corresponding to the transport service provider</param>
    /// <param name="routeId">A string corresponding to the route ID</param>
    /// /// <returns></returns>
    public async Task<List<Stop>> GetStops(AgencyType agency, string routeId)
    {
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(PublicTransportUriHelper.GetStopsUri(agency, routeId));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Stop>>(JSONResult);
    }

    /// <summary>
    /// Asyncronous method that requests the specific timetable for the given stop ID, route ID and public transport provider to the SmartCampus server
    /// </summary>
    /// <param name="agency">An AgencyType corresponding to the transport service provider</param>
    /// <param name="routeId">A string corresponding to the route ID</param>
    /// <param name="stopId">A string corresponding to the stop ID</param>
    /// <returns></returns>
    public async Task<List<StopTime>> GetTimetable(AgencyType agency, string routeId, string stopId)
    {
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(PublicTransportUriHelper.GetTimetableUri(agency, routeId, stopId));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<List<StopTime>>(JSONResult);
    }

    /// <summary>
    /// Asyncronous method that requests a limited timetable for the given stop ID, route ID and public transport provider
    /// with the specified maximum number of result to the SmartCampus server
    /// </summary>
    /// <param name="agency">An AgencyType corresponding to the transport service provider</param>
    /// <param name="stopId">A string corresponding to the stop ID</param>
    /// <param name="numberOfResult">An integer corresponding to the maximum number of result</param>
    /// <returns></returns>
    public async Task<List<TripData>> GetLimitedTimetable(AgencyType agency, string stopId, int numberOfResult)
    {
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(PublicTransportUriHelper.GetLimitedTimetableUri(agency, stopId, numberOfResult));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<List<TripData>>(JSONResult);
    }

    /// <summary>
    /// Asyncronous method that requests available transit times for the given route ID between a starting time and ending time to the SmartCampus server
    /// </summary>
    /// <param name="routeId">A string corresponding to the route ID</param>
    /// <param name="timeFrom">The timestamp corresponding to the start time</param>
    /// <param name="timeTo">The timestamp corresponding to the end time</param>
    /// <returns></returns>
    public async Task<TimeTable> GetTransitTimes(string routeId, int timeFrom, int timeTo)
    {
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(PublicTransportUriHelper.GetTransitTimesUri(routeId, timeFrom, timeTo));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<TimeTable>(JSONResult);
    }

    /// <summary>
    /// Asyncronous method that requests available transit delays for the given route ID between a starting time and ending time to the SmartCampus server
    /// </summary>
    /// <param name="routeId">A string corresponding to the route ID</param>
    /// <param name="timeFrom">The timestamp corresponding to the start time</param>
    /// <param name="timeTo">The timestamp corresponding to the end time</param>
    /// <returns></returns>
    public async Task<TimeTable> GetTransitDelays(string routeId, int timeFrom, int timeTo)
    {
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(PublicTransportUriHelper.GetTransitDelaysUri(routeId, timeFrom, timeTo));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<TimeTable>(JSONResult);
    }

    /// <summary>
    /// Asyncronous method that requests all the parkings info for a specific public transport provider to the SmartCampus server
    /// </summary>
    /// <param name="agency">An AgencyType corresponding to the transport service provider</param>
    /// <returns></returns>
    public async Task<List<Parking>> GetParkingsByAgency(AgencyType agency)
    {
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(PublicTransportUriHelper.GetParkingsByAgencyUri(agency));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Parking>>(JSONResult);
    }

    /// <summary>
    /// Asyncronous method that requests all the road alert info for the given route ID between a starting time and ending time to the SmartCampus server
    /// </summary>
    /// <param name="routeId">A string corresponding to the route ID</param>
    /// <param name="timeFrom">The timestamp corresponding to the start time</param>
    /// <param name="timeTo">The timestamp corresponding to the end time</param>
    /// <returns></returns>
    public async Task<List<AlertRoad>> GetRoadInfoByAgency(AgencyType agency, int timeFrom, int timeTo)
    {
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(PublicTransportUriHelper.GetRoadInfoByAgencyUri(agency, timeFrom, timeTo));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<List<AlertRoad>>(JSONResult);
    }
  }
}
