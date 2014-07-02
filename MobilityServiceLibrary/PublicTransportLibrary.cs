using System;
using System.Net;
using System.Windows;
using System.Linq;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CommonHelpers;
using System.Text;

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
    /// <param name="serverUrl">The SmartCampus server address where all requests will be executed (must include trailing /) </param>
    public PublicTransportLibrary(string accessToken, string serverUrl)
    {
      PublicTransportUriHelper.SetBaseUrl(serverUrl);
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
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r")); 
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
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(PublicTransportUriHelper.GetStopsUri(agency, routeId));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Stop>>(JSONResult);
    }

    /// <summary>
    /// Asyncronous method that requests the available stops that fall in a certain range for the given route ID and public transport provider to the SmartCampus server
    /// </summary>
    /// <param name="agency">An AgencyType corresponding to the transport service provider</param>
    /// <param name="routeId">A string corresponding to the route ID</param>
    /// <param name="latitude">A double corresponding to the latitude</param>
    /// <param name="longitude">A string corresponding to the longitude</param>
    /// <param name="radius">A double corresponding to the area to evaualte (radius of 1 ~ 100km)</param>
    /// /// <returns></returns>
    public async Task<List<Stop>> GetStopsByLocation(AgencyType agency, string route, double latitude, double longitude, double radius)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(PublicTransportUriHelper.GetStopsUriByLocation(agency, route, latitude, longitude, radius));

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
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
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
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
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
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
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
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
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
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
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
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(PublicTransportUriHelper.GetRoadInfoByAgencyUri(agency, timeFrom, timeTo));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<List<AlertRoad>>(JSONResult);
    }

    /// <summary>
    /// Asyncronous method that requests all the timetable updates for the given agencies to the SmartCampus server
    /// </summary>
    /// <param name="agencies">A dictionary where the keys correspond to an AgencyType while the values correspond to the version</param>
    /// <returns></returns>
    public async Task<Dictionary<string, TimetableCacheUpdate>> GetReadTimetableCacheUpdates(Dictionary<AgencyType, string> agencies)
    {
      Dictionary<string, string> toPostDict = new Dictionary<string, string>();
      foreach (var item in agencies)
        toPostDict.Add(EnumConverter.ToEnumString<AgencyType>(item.Key), item.Value);

      string toPost = JsonConvert.SerializeObject(toPostDict);
      StringContent sc = new StringContent(toPost, Encoding.UTF8, "application/json");

      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PostAsync(PublicTransportUriHelper.GetReadTimetableCacheUpdatesUri(), sc);

      var res =  Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, TimetableCacheUpdate>>(await JSONResult.Content.ReadAsStringAsync());

      foreach (var item in res)
      {
        foreach (var item2 in item.Value.Calendars)
        {
          foreach (var item3 in new List<string>(item2.Value.Entries.Keys))
          {
            res[item.Key].Calendars[item2.Key].Entries[item3] = item2.Value.Mapping[item2.Value.Entries[item3]];
          }
        }
      }
      return res;
    }

    /// <summary>
    /// Asyncronous method that requests a single timetable updates for the given file to the SmartCampus server
    /// </summary>
    /// <param name="agency">An AgencyType corresponding to the transport service provider</param>
    /// <param name="fileId">A string corresponding to the fileId</param>
    /// <returns></returns>
    public async Task<CompressedTimetable> GetReadSingleTimetableCacheUpdates(AgencyType agency, string fileId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(PublicTransportUriHelper.GetReadSingleTimetableCacheUpdatesUri(agency, fileId));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<CompressedTimetable>(JSONResult);
    }

  }
}
