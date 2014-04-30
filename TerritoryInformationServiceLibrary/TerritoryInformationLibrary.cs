using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Models.TerritoryInformationService;
using Newtonsoft.Json;

namespace TerritoryInformationServiceLibrary
{
  public class TerritoryInformationLibrary
  {
    HttpClient httpCli;
    string accessToken;

    public TerritoryInformationLibrary(string accessToken)
    {
      this.accessToken = accessToken;
      httpCli = new HttpClient();
    }

    #region Reading functions

    public async Task<List<EventObject>> ReadEvents(FilterObject filterData = null)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var JSONResult = await httpCli.GetStringAsync(TerritoryInformationUriHelper.GetReadEventsUri(JsonConvert.SerializeObject(filterData)));

      return JsonConvert.DeserializeObject<List<EventObject>>(JSONResult);
    }

    public async Task<EventObject> ReadSingleEvent(string eventId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var JSONResult = await httpCli.GetStringAsync(TerritoryInformationUriHelper.GetReadSingleEventUri(eventId));

      return JsonConvert.DeserializeObject<EventObject>(JSONResult);
    }

    public async Task<List<POIObject>> ReadPlaces(FilterObject filterData = null)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var JSONResult = await httpCli.GetStringAsync(TerritoryInformationUriHelper.GetReadPlacesUri(JsonConvert.SerializeObject(filterData)));

      return JsonConvert.DeserializeObject<List<POIObject>>(JSONResult);
    }

    public async Task<POIObject> ReadSinglePlace(string placeId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var JSONResult = await httpCli.GetStringAsync(TerritoryInformationUriHelper.GetReadSinglePlaceUri(placeId));

      return JsonConvert.DeserializeObject<POIObject>(JSONResult);
    }

    public async Task<List<StoryObject>> ReadStories(FilterObject filterData = null)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var JSONResult = await httpCli.GetStringAsync(TerritoryInformationUriHelper.GetReadStoriesUri(JsonConvert.SerializeObject(filterData)));

      return JsonConvert.DeserializeObject<List<StoryObject>>(JSONResult);
    }

    public async Task<StoryObject> ReadSingleStory(string storyId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var JSONResult = await httpCli.GetStringAsync(TerritoryInformationUriHelper.GetReadSingleStoryUri(storyId));

      return JsonConvert.DeserializeObject<StoryObject>(JSONResult);
    }

    #endregion

    #region Favourite object management

    private async Task<T> AddToMyObjects<T>(string objectId)
    {

      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PutAsync(TerritoryInformationUriHelper.GetAddToMyObjectsUri(objectId), null);

      return JsonConvert.DeserializeObject<T>(await JSONResult.Content.ReadAsStringAsync());
    }

    public async Task<StoryObject> AddToMyStories(string storyId)
    {
      return await AddToMyObjects<StoryObject>(storyId);
    }

    public async Task<EventObject> AddToMyEvents(string eventId)
    {
      return await AddToMyObjects<EventObject>(eventId);
    }

    private async Task<T> RemoveFromMyObjects<T>(string objectId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PutAsync(TerritoryInformationUriHelper.GetRemoveFromMyObjectsUri(objectId), null);

      return JsonConvert.DeserializeObject<T>(await JSONResult.Content.ReadAsStringAsync());
    }

    public async Task<StoryObject> RemoveFromMyStories(string storyId)
    {
      return await RemoveFromMyObjects<StoryObject>(storyId);
    }

    public async Task<EventObject> RemoveFromMyEvents(string eventId)
    {
      return await RemoveFromMyObjects<EventObject>(eventId);
    }

    #endregion

    #region Follow/Unfollow object

    private async Task<T> FollowObject<T>(string objectId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PutAsync(TerritoryInformationUriHelper.GetFollowObjectUri(objectId), null);

      return JsonConvert.DeserializeObject<T>(await JSONResult.Content.ReadAsStringAsync());
    }

    public async Task<EventObject> FollowEvent(string eventId)
    {
      return await FollowObject<EventObject>(eventId);
    }

    public async Task<POIObject> FollowPlace(string placeId)
    {
      return await FollowObject<POIObject>(placeId);
    }

    public async Task<StoryObject> FollowStory(string storyId)
    {
      return await FollowObject<StoryObject>(storyId);
    }

    private async Task<T> UnFollowObject<T>(string objectId)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PutAsync(TerritoryInformationUriHelper.GetUnFollowObjectUri(objectId), null);

      return JsonConvert.DeserializeObject<T>(await JSONResult.Content.ReadAsStringAsync());
    }

    public async Task<EventObject> UnFollowEvent(string eventId)
    {
      return await UnFollowObject<EventObject>(eventId);
    }

    public async Task<POIObject> UnFollowPlace(string placeId)
    {
      return await UnFollowObject<POIObject>(placeId);
    }

    public async Task<StoryObject> UnFollowStory(string storyId)
    {
      return await UnFollowObject<StoryObject>(storyId);
    }

    #endregion

    #region User defined objects

    #region generic functions

    private async Task<GenObject> CreateUserDefinedObject<GenObject>(GenObject go, Uri url)
    {
      StringContent sc = new StringContent(JsonConvert.SerializeObject(go), Encoding.UTF8, "application/json");

      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PostAsync(url, sc);
      return JsonConvert.DeserializeObject<GenObject>(await JSONResult.Content.ReadAsStringAsync());
    }

    private async Task<GenObject> UpdateUserDefinedObject<GenObject>(GenObject go, Uri url)
    {
      StringContent sc = new StringContent(JsonConvert.SerializeObject(go), Encoding.UTF8, "application/json");

      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PutAsync(url, sc);
      return JsonConvert.DeserializeObject<GenObject>(await JSONResult.Content.ReadAsStringAsync());
    }

    private void DeleteUserDefinedObject(Uri url)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      httpCli.DeleteAsync(url);

    }


    #endregion

    #region User defined event

    public async Task<EventObject> CreateUserDefinedEvent(EventObject eo)
    {
      return await CreateUserDefinedObject<EventObject>(eo, TerritoryInformationUriHelper.GetCreateUserDefinedEventUri());
    }

    public async Task<EventObject> UpdateUserDefinedEvent(EventObject eo)
    {
      return await UpdateUserDefinedObject<EventObject>(eo, TerritoryInformationUriHelper.GetUpdateUserDefinedEventUri(eo.Id));
    }

    public void DeleteUserDefinedEvent(string eventId)
    {
      DeleteUserDefinedObject(TerritoryInformationUriHelper.GetDeleteUserDefinedEventUri(eventId));
    }

    #endregion

    #region User defined POI

    public async Task<POIObject> CreateUserDefinedPlace(POIObject poiO)
    {
      return await CreateUserDefinedObject<POIObject>(poiO, TerritoryInformationUriHelper.GetCreateUserDefinedPlaceUri());
    }

    public async Task<POIObject> UpdateUserDefinedPlace(POIObject poiO)
    {
      return await UpdateUserDefinedObject<POIObject>(poiO, TerritoryInformationUriHelper.GetUpdateUserDefinedPlaceUri(poiO.Id));
    }

    public void DeleteUserDefinedPlace(string placeId)
    {
      DeleteUserDefinedObject(TerritoryInformationUriHelper.GetDeleteUserDefinedPlaceUri(placeId));
    }

    #endregion

    #region User defined story

    public async Task<StoryObject> CreateUserDefinedStory(StoryObject so)
    {
      return await CreateUserDefinedObject<StoryObject>(so, TerritoryInformationUriHelper.GetCreateUserDefinedStoryUri());
    }

    public async Task<StoryObject> UpdateUserDefinedStory(StoryObject so)
    {
      return await UpdateUserDefinedObject<StoryObject>(so, TerritoryInformationUriHelper.GetUpdateUserDefinedStoryUri(so.Id));
    }

    public void DeleteUserDefinedStory(string storyId)
    {
      DeleteUserDefinedObject(TerritoryInformationUriHelper.GetDeleteUserDefinedStoryUri(storyId));
    }

    #endregion

    #endregion

    #region Other

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

  public class PostSyncObject
  {
    [JsonProperty("exclude")]
    public Dictionary<string, string> Exclude { get; set; }

    [JsonProperty("include")]
    public Dictionary<string, string> Include { get; set; }

    [JsonProperty("version")]
    public long Version { get; set; }
  }
}
