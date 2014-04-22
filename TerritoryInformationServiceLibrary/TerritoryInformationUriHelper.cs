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

namespace TerritoryInformationServiceLibrary
{
  public static class TerritoryInformationUriHelper
  {
    static string baseUrl = "https://vas-dev.smartcampuslab.it/core.territory";
    static string eventUrl = "events";
    static string placeUrl = "pois";
    static string storyUrl = "stories";
    static string syncUrl = "sync";
    static string rateUrl = "rate";
    static string objectUrl = "objects";

    
    #region Reading URIs

    public static Uri GetReadEventsUri(string filterData = "")
    {
      UriBuilder ub;
      if (filterData == "")
        ub = new UriBuilder(string.Format("{0}/{1}", eventUrl, storyUrl));
      else
        ub = new UriBuilder(string.Format("{0}/{1}?{2}", baseUrl, eventUrl, filterData));
      return ub.Uri;
    }

    public static Uri GetReadSingleEventUri(string eventId)
    {
      
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, eventUrl, eventId));
      return ub.Uri;
    }
    
    public static Uri GetReadPlacesUri(string filterData = "")
    {
      UriBuilder ub;
      if (filterData == "")
        ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, placeUrl));
      else
        ub = new UriBuilder(string.Format("{0}/{1}?{2}", baseUrl, placeUrl, filterData));
      return ub.Uri;
    }

    public static Uri GetReadSinglePlaceUri(string placeId)
    {

      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, placeUrl, placeId));
      return ub.Uri;
    }

    public static Uri GetReadStoriesUri(string filterData = "")
    {
      UriBuilder ub;
      if(filterData=="")
        ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, storyUrl));
      else
        ub = new UriBuilder(string.Format("{0}/{1}?{2}", baseUrl, storyUrl, filterData));
      return ub.Uri;
    }

    public static Uri GetReadSingleStoryUri(string storyId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, storyUrl, storyId));
      return ub.Uri;
    }

    #endregion

    #region Following objects

    public static Uri GetAddToMyObjectsUri(string objectId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/attend", baseUrl, objectUrl, objectId ));
      return ub.Uri;
    }

    public static Uri GetRemoveFromMyObjectsUri(string objectId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/notAttend", baseUrl, objectUrl, objectId));
      return ub.Uri;
    }

    public static Uri GetFollowObjectUri(string objectId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/follow", baseUrl, objectUrl, objectId));
      return ub.Uri;
    }

    public static Uri GetUnFollowObjectUri(string objectId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/unFollow", baseUrl, objectUrl, objectId));
      return ub.Uri;
    }

    #endregion

    #region User defined event

    public static Uri GetCreateUserDefinedEventUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, eventUrl));
      return ub.Uri;
    }

    public static Uri GetUpdateUserDefinedEventUri(string eventId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, eventUrl, eventId));
      return ub.Uri;
    }

    public static Uri GetDeleteUserDefinedEventUri(string eventId)
    {
      return GetUpdateUserDefinedEventUri(eventId);
    }

    #endregion

    #region User defined POI

    public static Uri GetCreateUserDefinedPOIUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, placeUrl));
      return ub.Uri;
    }

    public static Uri GetUpdateUserDefinedPOIUri(string placeId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, placeUrl, placeId));
      return ub.Uri;
    }

    public static Uri DeleteUserDefinedPOIUri(string palceId)
    {
      return GetUpdateUserDefinedPOIUri(placeUrl);
    }

    #endregion

    #region User defined story

    public static Uri GetCreateUserDefinedStoryUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, storyUrl));
      return ub.Uri;
    }

    public static Uri GetUpdateUserDefinedStoryUri(string storyId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, storyUrl, storyId));
      return ub.Uri;
    }

    public static Uri DeleteUserDefinedStoryUri(string storyId)
    {
      return GetUpdateUserDefinedPOIUri(placeUrl);
    }

    #endregion

    #region Others

    public static Uri GetSyncUri(int since = 0)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}?{2}", baseUrl, eventUrl, since));
      return ub.Uri;
    }

    public static Uri GetRateObjUri(string objectId, int rating)
    {
      if (rating > 5 || rating < 0)
        throw new FormatException("rating must be between 0 and 5");

      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}?{2}", baseUrl, eventUrl, rating));
      return ub.Uri;
    }

    #endregion

  }
}
