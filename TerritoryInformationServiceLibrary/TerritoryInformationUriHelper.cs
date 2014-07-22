
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
  /// <summary>
  /// Helper class for the territory information library, contains static functions that 
  /// generate already-formatted URIs for using within the territory information library
  /// </summary>
  public static class TerritoryInformationUriHelper
  {
    /// <summary>
    /// Sets the base url, used to build all the others
    /// </summary>
    /// <param name="serverUrl">the server address, in the http://yourserverhere/ form, including trailing slash</param>
    public static void SetBaseUrl(string serverUrl)
    {
      baseUrl = serverUrl + "core.territory";
    }
    static string baseUrl;
    static string eventUrl = "events";
    static string placeUrl = "pois";
    static string storyUrl = "stories";
    static string syncUrl = "sync";
    static string rateUrl = "rate";
    static string objectUrl = "objects";

    /* 
     * Methods that provide URIs for reading all objects from a specific category
     * (i.e. Events, Places)
     */
    #region Reading URIs

    public static Uri GetReadEventsUri(string filterData)
    {
      UriBuilder ub;
      if (filterData == "null")
        ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, eventUrl));
      else
        ub = new UriBuilder(string.Format("{0}/{1}?filter={2}", baseUrl, eventUrl, filterData));
      return ub.Uri;
    }

    public static Uri GetReadSingleEventUri(string eventId)
    {

      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, eventUrl, eventId));
      return ub.Uri;
    }

    public static Uri GetReadPlacesUri(string filterData)
    {
      UriBuilder ub;
      if (filterData == "null")
        ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, placeUrl));
      else
        ub = new UriBuilder(string.Format("{0}/{1}?filter={2}", baseUrl, placeUrl, filterData));
      return ub.Uri;
    }

    public static Uri GetReadSinglePlaceUri(string placeId)
    {

      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, placeUrl, placeId));
      return ub.Uri;
    }

    public static Uri GetReadStoriesUri(string filterData)
    {
      UriBuilder ub;
      if (filterData == "null")
        ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, storyUrl));
      else
        ub = new UriBuilder(string.Format("{0}/{1}?filter={2}", baseUrl, storyUrl, filterData));
      return ub.Uri;
    }

    public static Uri GetReadSingleStoryUri(string storyId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, storyUrl, storyId));
      return ub.Uri;
    }

    #endregion

    /* 
     * Methods that provide URIs to start or stop following objects
     * or adding them to the list of personal objects
     */
    #region Following objects

    public static Uri GetAddToMyObjectsUri(string objectId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/attend", baseUrl, objectUrl, objectId));
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
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/unfollow", baseUrl, objectUrl, objectId));
      return ub.Uri;
    }

    #endregion


    /* 
     * Methods that provide URIs to create, edit and delete
     * user-created events
     */
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


    /* 
     * Methods that provide URIs to create, edit and delete
     * user-created Points Of Interest
     */
    #region User defined POI

    public static Uri GetCreateUserDefinedPlaceUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", baseUrl, placeUrl));
      return ub.Uri;
    }

    public static Uri GetUpdateUserDefinedPlaceUri(string placeId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, placeUrl, placeId));
      return ub.Uri;
    }

    public static Uri GetDeleteUserDefinedPlaceUri(string palceId)
    {
      return GetUpdateUserDefinedPlaceUri(placeUrl);
    }

    #endregion


    /* 
     * Methods that provide URIs to create, edit and delete
     * user-created stories
     */
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

    public static Uri GetDeleteUserDefinedStoryUri(string storyId)
    {
      return GetUpdateUserDefinedPlaceUri(placeUrl);
    }

    #endregion


    #region Others

    public static Uri GetSyncUri(long since = 0)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}?since={2}", baseUrl, syncUrl, since));
      return ub.Uri;
    }

    public static Uri GetRateObjUri(string objectId, int rating)
    {
      if (rating > 5 || rating < 0)
        throw new FormatException("rating must be between 0 and 5");

      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}?rating={4}", baseUrl, objectUrl, objectId, rateUrl, rating));
      return ub.Uri;
    }

    #endregion

  }
}
