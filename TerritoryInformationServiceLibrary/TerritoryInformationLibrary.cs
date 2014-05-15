using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Models.TerritoryInformationService;
using Newtonsoft.Json;
using System.Net;

namespace TerritoryInformationServiceLibrary
{
  /// <summary>
  /// Class that wraps the Territory Information API in an easy to use way
  /// </summary>
  public class TerritoryInformationLibrary
  {
    HttpClient httpCli;
    string accessToken;

    /// <summary>
    /// Main constructor, to use always
    /// </summary>
    /// <param name="accessToken">The SmartCampus-issued access token</param>
    /// <param name="accessToken">The SmartCampus server address where all requests will be executed (must include trailing /) </param>
    public TerritoryInformationLibrary(string accessToken, string serverUrl)
    {
      TerritoryInformationUriHelper.SetBaseUrl(serverUrl);
      this.accessToken = accessToken;
      httpCli = new HttpClient();
    }

    /*
     *  Series of functions that provide reading access to various territory related resources,
     *  such as Events, Stories and Point of interes 
     */
    #region Reading functions


    /// <summary>
    ///  Asyncronous method that retrieves a list of all available events
    /// </summary>
    /// <param name="filterData">Instance of a FilterObject object that will be used as a search filter for the events</param>
    /// <returns>A list containing the required events, up to a maximum of 100 results</returns>
    public async Task<List<EventObject>> ReadEvents(FilterObject filterData = null)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var JSONResult = await httpCli.GetStringAsync(TerritoryInformationUriHelper.GetReadEventsUri(JsonConvert.SerializeObject(filterData)));

      return JsonConvert.DeserializeObject<List<EventObject>>(JSONResult);
    }

    /// <summary>
    /// Asyncronous method that retrieves a single event
    /// </summary>
    /// <param name="eventId">The unique identifier for the required event</param>
    /// <returns>An instance of an event containing the required event</returns>
    public async Task<EventObject> ReadSingleEvent(string eventId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      HttpResponseMessage JSONResult = await httpCli.GetAsync(TerritoryInformationUriHelper.GetReadSingleEventUri(eventId));

      /*
       * If no event with the specified id exists, an http 420 status code is returned.
       * If status code is 420 and throw a WebException, if status code isn't 200 throw the corresponding
       * exception, otherwise return the parsed results
      */
      if ((int)JSONResult.StatusCode == 420)
        throw new WebException("Object not found");
      else
        JSONResult.EnsureSuccessStatusCode();

      return JsonConvert.DeserializeObject<EventObject>(await JSONResult.Content.ReadAsStringAsync());

    }

    /// <summary>
    ///  Asyncronous method that retrieves a list of all available POIs
    /// </summary>
    /// <param name="filterData">Instance of a FilterObject object that will be used as a search filter for the POIs</param>
    /// <returns>A list containing the required POIs, up to a maximum of 100 results</returns>
    public async Task<List<POIObject>> ReadPlaces(FilterObject filterData = null)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var JSONResult = await httpCli.GetStringAsync(TerritoryInformationUriHelper.GetReadPlacesUri(JsonConvert.SerializeObject(filterData)));

      return JsonConvert.DeserializeObject<List<POIObject>>(JSONResult);
    }

    /// <summary>
    /// Asyncronous method that retrieves a single POI
    /// </summary>
    /// <param name="placeId">The unique identifier for the required POI</param>
    /// <returns>An instance of an event containing the required POI</returns>
    public async Task<POIObject> ReadSinglePlace(string placeId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      HttpResponseMessage JSONResult = await httpCli.GetAsync(TerritoryInformationUriHelper.GetReadSinglePlaceUri(placeId));

      /*
       * If no event with the specified id exists, an http 420 status code is returned.
       * If status code is 420 and throw a WebException, if status code isn't 200 throw the corresponding
       * exception, otherwise return the parsed results
      */
      if ((int)JSONResult.StatusCode == 420)
        throw new WebException("Object not found");
      else
        JSONResult.EnsureSuccessStatusCode();

      return JsonConvert.DeserializeObject<POIObject>(await JSONResult.Content.ReadAsStringAsync());
    }

    /// <summary>
    ///  Asyncronous method that retrieves a list of all available stories
    /// </summary>
    /// <param name="filterData">Instance of a FilterObject object that will be used as a search filter for the stories</param>
    /// <returns>A list containing the required stories, up to a maximum of 100 results</returns>
    public async Task<List<StoryObject>> ReadStories(FilterObject filterData = null)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var JSONResult = await httpCli.GetStringAsync(TerritoryInformationUriHelper.GetReadStoriesUri(JsonConvert.SerializeObject(filterData)));

      return JsonConvert.DeserializeObject<List<StoryObject>>(JSONResult);
    }

    /// <summary>
    /// Asyncronous method that retrieves a single story
    /// </summary>
    /// <param name="storyId">The unique identifier for the required POI</param>
    /// <returns>An instance of an event containing the required POI</returns>
    public async Task<StoryObject> ReadSingleStory(string storyId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      HttpResponseMessage JSONResult = await httpCli.GetAsync(TerritoryInformationUriHelper.GetReadSingleStoryUri(storyId));

      /*
       * If no event with the specified id exists, an http 420 status code is returned.
       * If status code is 420 and throw a WebException, if status code isn't 200 throw the corresponding
       * exception, otherwise return the parsed results
      */
      if ((int)JSONResult.StatusCode == 420)
        throw new WebException("Object not found");
      else
        JSONResult.EnsureSuccessStatusCode();

      return JsonConvert.DeserializeObject<StoryObject>(await JSONResult.Content.ReadAsStringAsync());
    }

    #endregion

    /*
     *  Series of functions that allow for the management of personalized (favourite) resources,
     *  such as Events, Stories and Point of interes 
     */
    #region Favourite object management

    /// <summary>
    /// Actually performs the network add operation and json deserialization
    /// </summary>
    /// <typeparam name="T">The object type to use</typeparam>
    /// <param name="objectId">the unique identifier for the required resource</param>
    /// <returns>an instance of the specified object type</returns>
    private async Task<T> AddToMyObjects<T>(string objectId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PutAsync(TerritoryInformationUriHelper.GetAddToMyObjectsUri(objectId), null);

      return JsonConvert.DeserializeObject<T>(await JSONResult.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// Asyncronous method that allows to add a specific story to the ones
    /// one wants to add as favourite
    /// </summary>
    /// <param name="storyId">the unique identifier for the required story</param>
    /// <returns>an instance of the requested story</returns>
    public async Task<StoryObject> AddToMyStories(string storyId)
    {
      return await AddToMyObjects<StoryObject>(storyId);
    }

    /// <summary>
    /// Asyncronous method that allows to add a specific event to the ones
    /// one wants to add as favourite
    /// </summary>
    /// <param name="storyId">the unique identifier for the required event</param>
    /// <returns>an instance of the requested event</returns>
    public async Task<EventObject> AddToMyEvents(string eventId)
    {
      return await AddToMyObjects<EventObject>(eventId);
    }

    /// <summary>
    /// Actually performs the network remove operation and json deserialization
    /// </summary>
    /// <typeparam name="T">The object type to use</typeparam>
    /// <param name="objectId">the unique identifier for the required resource</param>
    /// <returns>an instance of the removed object type</returns>
    private async Task<T> RemoveFromMyObjects<T>(string objectId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PutAsync(TerritoryInformationUriHelper.GetRemoveFromMyObjectsUri(objectId), null);

      return JsonConvert.DeserializeObject<T>(await JSONResult.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// Asyncronous method that allows to remove a specific story to the ones
    /// one has as favourites
    /// </summary>
    /// <param name="storyId">the unique identifier for the required story</param>
    /// <returns>an instance of the removed story</returns>
    public async Task<StoryObject> RemoveFromMyStories(string storyId)
    {
      return await RemoveFromMyObjects<StoryObject>(storyId);
    }

    /// <summary>
    /// Asyncronous method that allows to remove a specific event to the ones
    /// one has as favourites
    /// </summary>
    /// <param name="storyId">the unique identifier for the required event</param>
    /// <returns>an instance of the removed event</returns>
    public async Task<EventObject> RemoveFromMyEvents(string eventId)
    {
      return await RemoveFromMyObjects<EventObject>(eventId);
    }

    #endregion

    /*
     *  Series of functions that provide a way to follow or unfollow specific resources,
     *  such as Events, Stories and Point of interes, in order to recieve notifications 
     */
    #region Follow/Unfollow object

    /// <summary>
    /// Actually performs the network following operation and json deserialization
    /// </summary>
    /// <typeparam name="T">The object type to use</typeparam>
    /// <param name="objectId">the unique identifier for the required resource</param>
    /// <returns>an instance of the specified object type</returns>
    private async Task<T> FollowObject<T>(string objectId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PutAsync(TerritoryInformationUriHelper.GetFollowObjectUri(objectId), null);

      return JsonConvert.DeserializeObject<T>(await JSONResult.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// Asyncronous method that allows to start following a specific event, 
    /// and thus enables notifications for said event
    /// </summary>
    /// <param name="storyId">the unique identifier for the required event</param>
    /// <returns>an instance of the requested event</returns>
    public async Task<EventObject> FollowEvent(string eventId)
    {
      return await FollowObject<EventObject>(eventId);
    }

    /// <summary>
    /// Asyncronous method that allows to start following a specific POI, 
    /// and thus enables notifications for said POI
    /// </summary>
    /// <param name="storyId">the unique identifier for the required POI</param>
    /// <returns>an instance of the requested POI</returns>
    public async Task<POIObject> FollowPlace(string placeId)
    {
      return await FollowObject<POIObject>(placeId);
    }

    /// <summary>
    /// Asyncronous method that allows to start following a specific story, 
    /// and thus enables notifications for said story
    /// </summary>
    /// <param name="storyId">the unique identifier for the required story</param>
    /// <returns>an instance of the requested story</returns>
    public async Task<StoryObject> FollowStory(string storyId)
    {
      return await FollowObject<StoryObject>(storyId);
    }

    /// <summary>
    /// Actually performs the network unfollow operation and json deserialization
    /// </summary>
    /// <typeparam name="T">The object type to use</typeparam>
    /// <param name="objectId">the unique identifier for the required resource</param>
    /// <returns>an instance of the specified object type</returns>
    private async Task<T> UnFollowObject<T>(string objectId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PutAsync(TerritoryInformationUriHelper.GetUnFollowObjectUri(objectId), null);

      return JsonConvert.DeserializeObject<T>(await JSONResult.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// Asyncronous method that allows to stop following a specific event, 
    /// and thus disables notifications for said event
    /// </summary>
    /// <param name="storyId">the unique identifier for the required event</param>
    /// <returns>an instance of the requested event</returns>
    public async Task<EventObject> UnFollowEvent(string eventId)
    {
      return await UnFollowObject<EventObject>(eventId);
    }

    /// <summary>
    /// Asyncronous method that allows to stop following a specific POI, 
    /// and thus disables notifications for said POI
    /// </summary>
    /// <param name="storyId">the unique identifier for the required POI</param>
    /// <returns>an instance of the requested POI</returns>
    public async Task<POIObject> UnFollowPlace(string placeId)
    {
      return await UnFollowObject<POIObject>(placeId);
    }

    /// <summary>
    /// Asyncronous method that allows to stop following a specific story, 
    /// and thus disables notifications for said story
    /// </summary>
    /// <param name="storyId">the unique identifier for the required story</param>
    /// <returns>an instance of the requested story</returns>
    public async Task<StoryObject> UnFollowStory(string storyId)
    {
      return await UnFollowObject<StoryObject>(storyId);
    }

    #endregion

    /*
     *  Series of functions that provide a way to create, edit or delete custom resources,
     *  such as Events, Stories and Point of interes, created by the current user
     */
    #region User defined objects

    #region generic functions

    /// <summary>
    /// Actually performs the network creation operation and json deserialization 
    /// </summary>
    /// <typeparam name="GenObject">The object type to use</typeparam>
    /// <param name="go">An instance of a GenObject object</param>
    /// <param name="url">The URI at which the operation will be performed</param>
    /// <returns>an instance of the created object</returns>
    private async Task<GenObject> CreateUserDefinedObject<GenObject>(GenObject go, Uri url)
    {
      StringContent sc = new StringContent(JsonConvert.SerializeObject(go), Encoding.UTF8, "application/json");

      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PostAsync(url, sc);
      return JsonConvert.DeserializeObject<GenObject>(await JSONResult.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// Actually performs the network update operation and json deserialization 
    /// </summary>
    /// <typeparam name="GenObject">The object type to use</typeparam>
    /// <param name="go">An instance of a GenObject object</param>
    /// <param name="url">The URI at which the operation will be performed</param>
    /// <returns>an instance of the updated object</returns>
    private async Task<GenObject> UpdateUserDefinedObject<GenObject>(GenObject go, Uri url)
    {
      StringContent sc = new StringContent(JsonConvert.SerializeObject(go), Encoding.UTF8, "application/json");

      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PutAsync(url, sc);
      return JsonConvert.DeserializeObject<GenObject>(await JSONResult.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// Actually performs the network deletion operation. no return, no wait
    /// </summary>
    /// <param name="url">The URI at which the operation will be performed</param>
    private void DeleteUserDefinedObject(Uri url)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      httpCli.DeleteAsync(url);

    }


    #endregion

    #region User defined event

    /// <summary>
    /// Asyncronous method that creates an user defined event
    /// </summary>
    /// <param name="eo">The instance of the event to create</param>
    /// <returns>an instance of the created event</returns>
    public async Task<EventObject> CreateUserDefinedEvent(EventObject eo)
    {
      return await CreateUserDefinedObject<EventObject>(eo, TerritoryInformationUriHelper.GetCreateUserDefinedEventUri());
    }

    /// <summary>
    /// Asyncronous method that updates an user defined event
    /// </summary>
    /// <param name="eo">The instance of the event to update</param>
    /// <returns>an instance of the updated event</returns>
    public async Task<EventObject> UpdateUserDefinedEvent(EventObject eo)
    {
      return await UpdateUserDefinedObject<EventObject>(eo, TerritoryInformationUriHelper.GetUpdateUserDefinedEventUri(eo.Id));
    }

    /// <summary>
    /// Asyncronous method that deletes an user defined event
    /// </summary>
    /// <param name="eventId">The unique identidier for the event to remove</param>
    public void DeleteUserDefinedEvent(string eventId)
    {
      DeleteUserDefinedObject(TerritoryInformationUriHelper.GetDeleteUserDefinedEventUri(eventId));
    }

    #endregion

    #region User defined POI

    /// <summary>
    /// Asyncronous method that creates an user defined place
    /// </summary>
    /// <param name="eo">The instance of the place to create</param>
    /// <returns>an instance of the created place</returns>
    public async Task<POIObject> CreateUserDefinedPlace(POIObject poiO)
    {
      return await CreateUserDefinedObject<POIObject>(poiO, TerritoryInformationUriHelper.GetCreateUserDefinedPlaceUri());
    }

    /// <summary>
    /// Asyncronous method that updates an user defined place
    /// </summary>
    /// <param name="eo">The instance of the place to update</param>
    /// <returns>an instance of the updated place</returns>
    public async Task<POIObject> UpdateUserDefinedPlace(POIObject poiO)
    {
      return await UpdateUserDefinedObject<POIObject>(poiO, TerritoryInformationUriHelper.GetUpdateUserDefinedPlaceUri(poiO.Id));
    }

    /// <summary>
    /// Asyncronous method that deletes an user defined place
    /// </summary>
    /// <param name="eventId">The unique identidier for the place to remove</param>
    public void DeleteUserDefinedPlace(string placeId)
    {
      DeleteUserDefinedObject(TerritoryInformationUriHelper.GetDeleteUserDefinedPlaceUri(placeId));
    }

    #endregion

    #region User defined story

    /// <summary>
    /// Asyncronous method that creates an user defined story
    /// </summary>
    /// <param name="eo">The instance of the story to create</param>
    /// <returns>an instance of the created place</returns>
    public async Task<StoryObject> CreateUserDefinedStory(StoryObject so)
    {
      return await CreateUserDefinedObject<StoryObject>(so, TerritoryInformationUriHelper.GetCreateUserDefinedStoryUri());
    }

    /// <summary>
    /// Asyncronous method that updates an user defined story
    /// </summary>
    /// <param name="eo">The instance of the story to update</param>
    /// <returns>an instance of the updated story</returns>
    public async Task<StoryObject> UpdateUserDefinedStory(StoryObject so)
    {
      return await UpdateUserDefinedObject<StoryObject>(so, TerritoryInformationUriHelper.GetUpdateUserDefinedStoryUri(so.Id));
    }

    /// <summary>
    /// Asyncronous method that deletes an user defined story
    /// </summary>
    /// <param name="eventId">The unique identidier for the story to remove</param>
    public void DeleteUserDefinedStory(string storyId)
    {
      DeleteUserDefinedObject(TerritoryInformationUriHelper.GetDeleteUserDefinedStoryUri(storyId));
    }

    #endregion

    #endregion

    #region Other

    /// <summary>
    /// Asyncronous method that obtaines all changes in the various objects since the given timestamp
    /// </summary>
    /// <param name="include">The contents to include in the updates list</param>
    /// <param name="exclude">The contents to exclude from the updates list</param>
    /// <param name="version">The required timestamp version of the update (usually left blank)</param>
    /// <param name="since">The timestamp from the last update. Leave blank (0) for a full update</param>
    /// <returns></returns>
    public async Task<SyncObject> Sync(Dictionary<string, string> include = null, Dictionary<string, string> exclude = null, long version = 0, long since = 0)
    {
      PostSyncObject pso = new PostSyncObject() { Exclude = exclude, Include = include, Version = version };
      string toPost = JsonConvert.SerializeObject(pso, new JsonSerializerSettings()
      {
        NullValueHandling = NullValueHandling.Ignore,
      });
      StringContent sc = new StringContent(toPost, Encoding.UTF8, "application/json");
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PostAsync(TerritoryInformationUriHelper.GetSyncUri(since), sc);

      return JsonConvert.DeserializeObject<SyncObject>(await JSONResult.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// Asyncronous method that allows to rate a specific resource
    /// </summary>
    /// <param name="objectId">the unique identifier for the requested resource</param>
    /// <param name="rating">the rating the user wants to give to the resource</param>
    /// <returns>a floating point number, indicating the average rating for the resource</returns>
    public async Task<double> RateObject(string objectId, int rating)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PutAsync(TerritoryInformationUriHelper.GetRateObjUri(objectId, rating), null);

      return Convert.ToDouble(await JSONResult.Content.ReadAsStringAsync());
    }

    #endregion
  }
}
