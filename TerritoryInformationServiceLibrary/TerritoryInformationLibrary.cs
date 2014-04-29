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

    public async Task<List<EventObject>> ReadEvents(string filterData = "")
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var JSONResult = await httpCli.GetStringAsync(TerritoryInformationUriHelper.GetReadEventsUri(filterData));

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

    public async Task<List<POIObject>> ReadPlaces(string filterData = "")
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var JSONResult = await httpCli.GetStringAsync(TerritoryInformationUriHelper.GetReadPlacesUri(filterData));

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

    public async Task<List<StoryObject>> ReadStories(string filterData = "")
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
      var JSONResult = await httpCli.GetStringAsync(TerritoryInformationUriHelper.GetReadStoriesUri(filterData));

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
  }
}
