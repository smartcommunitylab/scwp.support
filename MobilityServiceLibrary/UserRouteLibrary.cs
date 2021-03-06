﻿using Models.MobilityService.Journeys;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobilityServiceLibrary
{
  /// <summary>
  /// Class that wraps the User Route APIs in an easy to use way
  /// </summary>
  public class UserRouteLibrary
  {
    HttpClient httpCli;
    string accessToken;

    /// <summary>
    /// Constructor for the UserRouteLibrary class, to use only after an access token is available
    /// </summary>
    /// <param name="accessToken">The SmartCampus-issued access token</param>  
    /// <param name="serverUrl">The SmartCampus server address where all requests will be executed (must include trailing /) </param>
    public UserRouteLibrary(string accessToken, string serverUrl)
    {
      UserRouteUriHelper.SetBaseUrl(serverUrl);
      this.accessToken = accessToken;
      httpCli = new HttpClient();
    }

    #region Single journey

    /// <summary>
    /// Asyncronous method that allows the user to store a single journey
    /// </summary>
    /// <param name="basIti">The instance of an object representing the journey to store</param>
    /// <returns>An instance of the stored journey, as stored on the server</returns>
    public async Task<BasicItinerary> SaveSingleJourney(BasicItinerary basIti)
    {

      //string toPost = JsonConvert.SerializeObject(basIti, Formatting.Indented);
      string toPost = JsonConvert.SerializeObject(basIti);
      httpCli.DefaultRequestHeaders.Clear();

      StringContent sc = new StringContent(toPost, Encoding.UTF8, "application/json");
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var res = await httpCli.PostAsync(UserRouteUriHelper.GetSaveSingleJourneyUri(), sc);
      return JsonConvert.DeserializeObject<BasicItinerary>(await res.Content.ReadAsStringAsync());

    }

    /// <summary>
    /// Asyncronous method that allows the user to read a single journey stored by the user
    /// </summary>
    /// <param name="journeyId">The unique identifier for the desired journey</param>
    /// <returns>An instance of the desired stored journey</returns>
    public async Task<BasicItinerary> ReadSingleJourney(string journeyId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var res = await httpCli.GetStringAsync(UserRouteUriHelper.GetReadSingleJourneyUri(journeyId));

      return JsonConvert.DeserializeObject<BasicItinerary>(res);
    }

    /// <summary>
    /// Asyncronous method that allows the user to read all single journeys stored by the user
    /// </summary>
    /// <returns>A list containing the instances of all the stored journeys</returns>
    public async Task<List<BasicItinerary>> ReadAllSingleJourneys()
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var res = await httpCli.GetStringAsync(UserRouteUriHelper.GetReadAllSingleJourneysUri());

      return JsonConvert.DeserializeObject<List<BasicItinerary>>(res);
    }

    /// <summary>
    /// Asyncronous method that allows the user to switch journey monitoring on or off.
    /// </summary>
    /// <param name="journeyId">The unique identifier for the desired journey</param>
    /// <param name="monitor">The status to which monitoring will be set</param>
    /// <returns>The updated monitoring status</returns>
    public async Task<bool> SetMonitorSingleJourney(string journeyId, bool monitor)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var res = await httpCli.GetStringAsync(UserRouteUriHelper.GetMonitorSingleJourneyUri(journeyId, monitor));

      return Convert.ToBoolean(res);
    }

    /// <summary>
    /// Asyncronous method that allows the user to delete a stored journey
    /// </summary>
    /// <param name="journeyId">The unique identifier for the desired journey</param>
    /// <returns>The result of the deleting operation</returns>
    public async Task<bool> DeleteSingleJourney(string journeyId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var res = await httpCli.DeleteAsync(UserRouteUriHelper.GetDeleteSingleJourneyUri(journeyId));

      return Convert.ToBoolean(await res.Content.ReadAsStringAsync());
    }


    #endregion

    #region Recurent journey

    /// <summary>
    /// Asyncronous method that allows the user to store a recurrent journey
    /// </summary>
    /// <param name="basIti">The instance of an object representing the journey to store</param>
    /// <returns>An instance of the stored recurrent journey, as stored on the server</returns>
    public async Task<BasicRecurrentJourney> SaveRecurrentJourney(BasicRecurrentJourney basIti)
    {
      string toPost = JsonConvert.SerializeObject(basIti);

      StringContent sc = new StringContent(toPost, Encoding.UTF8, "application/json");
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var res = await httpCli.PostAsync(UserRouteUriHelper.GetSaveRecurrentJourneyUri(), sc);

      return JsonConvert.DeserializeObject<BasicRecurrentJourney>(await res.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// Asyncronous method that allows the user to read a recurrent journey stored by the user
    /// </summary>
    /// <param name="journeyId">The unique identifier for the desired journey</param>
    /// <returns>An instance of the desired stored recurrent journey</returns>
    public async Task<BasicRecurrentJourney> ReadRecurrentJourney(string journeyId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var res = await httpCli.GetStringAsync(UserRouteUriHelper.GetReadRecurrentJourneyUri(journeyId));

      return JsonConvert.DeserializeObject<BasicRecurrentJourney>(res);
    }

    /// <summary>
    /// Asyncronous method that allows the user to read all recurrent journeys stored by the user
    /// </summary>
    /// <returns>A list containing the instances of all the stored recurrent journeys</returns>
    public async Task<List<BasicRecurrentJourney>> ReadAllRecurrentJourneys()
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var res = await httpCli.GetStringAsync(UserRouteUriHelper.GetReadAllRecurrentJourneysUri());

      return JsonConvert.DeserializeObject<List<BasicRecurrentJourney>>(res);
    }

    /// <summary>
    /// Asyncronous method that allows the user to switch journey monitoring on or off.
    /// </summary>
    /// <param name="journeyId">The unique identifier for the desired recurrent journey</param>
    /// <param name="monitor">The status to which monitoring will be set</param>
    /// <returns>The updated monitoring status</returns>
    public async Task<bool> SetMonitorRecurrentJourney(string journeyId, bool monitor)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var res = await httpCli.GetStringAsync(UserRouteUriHelper.GetMonitorReccurrentJourneyUri(journeyId, monitor));

      return Convert.ToBoolean(res);
    }

    /// <summary>
    /// Asyncronous method that allows the user to switch journey monitoring on or off.
    /// </summary>
    /// <param name="journeyId">The unique identifier for the desired recurrent journey</param>
    /// <param name="basIti">The instance the updated journey to store</param>
    /// <returns>The result of the update operation</returns>
    public async Task<bool> UpdateRecurrentJourney(string journeyId, BasicRecurrentJourney basIti)
    {
      string toPost = JsonConvert.SerializeObject(basIti);
      StringContent sc = new StringContent(toPost, Encoding.UTF8, "application/json");
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var res = await httpCli.PutAsync(UserRouteUriHelper.GetUpdateRecurrentJourneyUri(journeyId), sc);

      return Convert.ToBoolean(await res.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// Asyncronous method that allows the user to delete a stored recurrent journey
    /// </summary>
    /// <param name="journeyId">The unique identifier for the desired journey</param>
    /// <returns>The result of the deleting operation</returns>
    public async Task<bool> DeleteRecurrentJourney(string journeyId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var res = await httpCli.DeleteAsync(UserRouteUriHelper.GetDeleteRecurrentJourneyUri(journeyId));

      return Convert.ToBoolean(await res.Content.ReadAsStringAsync());
    }


    #endregion
  }
}
