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
      httpCli.DefaultRequestHeaders.Clear();
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
      httpCli.DefaultRequestHeaders.Clear();
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
      httpCli.DefaultRequestHeaders.Clear();
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
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(PublicTransportUriHelper.GetLimitedTimetableUri(agency, stopId, numberOfResult));

      Dictionary<string, LimitedTimeTable> limitedTTs = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, LimitedTimeTable>>(JSONResult);
      List<TripData> tripsData = new List<TripData>();
      TripData td;
      foreach (var limitedTT in limitedTTs)
      {
        foreach (var time in limitedTT.Value.Times)
        {
          td = new TripData();
          td.AgencyId = time.TripInfo.AgencyId;
          td.RouteId = limitedTT.Key;
          td.RouteName = limitedTT.Value.RouteName;
          td.RouteShortName = limitedTT.Value.RouteShortName;
          td.Time = time.TimeInfo;
          td.TripId = time.TripInfo.Id;
          if (limitedTT.Value.Delays.ContainsKey(td.TripId))
          {
            td.DelayInfo = limitedTT.Value.Delays[td.TripId];
          }
          tripsData.Add(td);
        }
      }
      return tripsData;
    }

    /// <summary>
    /// Asyncronous method that requests available transit times for the given route ID between a starting time and ending time to the SmartCampus server
    /// </summary>
    /// <param name="routeId">A string corresponding to the route ID</param>
    /// <param name="timeFrom">The timestamp corresponding to the start time</param>
    /// <param name="timeTo">The timestamp corresponding to the end time</param>
    /// <returns></returns>
    public async Task<TimeTable> GetTransitTimes(string routeId, long timeFrom, long timeTo)
    {
      httpCli.DefaultRequestHeaders.Clear();
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
    public async Task<TimeTable> GetTransitDelays(string routeId, long timeFrom, long timeTo)
    {
      httpCli.DefaultRequestHeaders.Clear();
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
      httpCli.DefaultRequestHeaders.Clear();
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
    public async Task<List<AlertRoad>> GetRoadInfoByAgency(AgencyType agency, long timeFrom, long timeTo)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(PublicTransportUriHelper.GetRoadInfoByAgencyUri(agency, timeFrom, timeTo));
      //string JSONResult = "[{\"agencyId\":\"COMUNE_DI_ROVERETO\",\"road\":{\"note\":\"\",\"lat\":\"45.894037\",\"lon\":\"11.043587\",\"streetCode\":\"290\",\"street\":\"CORSOBETTINIA.\",\"fromNumber\":\"\",\"toNumber\":\"\",\"fromIntersection\":\"\",\"toIntersection\":\"\"},\"changeTypes\":[\"PARKING_BLOCK\",\"ROAD_BLOCK\"],\"id\":\"612005_290\",\"type\":null,\"entity\":null,\"description\":\"UFFICIOATTIVITA\'PRODUTTIVE:DIVIETODITRANSITOEDISOSTACONRIMOZIONECOATTAINCORSOBETTINI,INVIALETRENTOENELLESTRADELIMITROFEAROVERETOPERLOSVOLGIMENTODELMERCATOSETTIMANALEDELMARTEDI\'.\",\"from\":1372543200000,\"to\":1378764000000,\"creatorId\":\"default\",\"creatorType\":\"SERVICE\",\"effect\":\"Temporanea\",\"note\":null},]";

      return Newtonsoft.Json.JsonConvert.DeserializeObject<List<AlertRoad>>(JSONResult);
    }
  }
}
