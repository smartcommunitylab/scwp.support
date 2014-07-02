
using CommonHelpers;
using Models.CommunicatorService;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CommunicatorServiceLibrary
{
  /// <summary>
  /// Helper class for the communicator service library, contains static functions that 
  /// generate already-formatted URIs for using within the  communicator service library
  /// </summary>
  public static class CommunicatorLibraryUriHelper
  {
    public static void SetBaseUrl(string serverUrl)
    {
      baseUrl = serverUrl + "core.communicator";
    }
    static string baseUrl;
    static string byUser = "user";
    static string byApp = "app";
    static string notification = "notification";
    static string sync = "sync";
    static string register = "register";
    //static string REGISTRATIONID_HEADER = "REGISTRATIONID";
    //static string GCM_SENDER_API_KEY = "GCM_SENDER_API_KEY";
    //static string GCM_SENDER_ID = "GCM_SENDER_ID";
    //static string GCM_REGISTRATION_ID_USER = "GCM_REGISTRATION_ID_USER";

    /*
     *  Methods that generate URIs to use for reading and managing notifications related 
     *  to the application itself, that do not require an user identifier
     */

    #region Actions by APP

    /// <summary>
    /// Creates a formatted URI to read all the application related notifications
    /// </summary>
    /// <param name="since">since date, in milliseconds (use 0 to get all notifications from begin of time)</param>
    /// <param name="position">position in the result set</param>
    /// <param name="count">number of desired results (use -1 to get all notifications)</param>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>A ready to use URI to use in order to read all application related notifications on the server</returns>
    public static Uri GetNotificationsByApp(long since, int position, int count, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, byApp, appId, notification));

      Dictionary<string, string> stringQuery = new Dictionary<string, string>();
      stringQuery["since"] = since.ToString();
      stringQuery["position"] = position.ToString();
      stringQuery["count"] = count.ToString();
      ub.Query = QueryHelper.DictionaryToQuery(stringQuery);

      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to read a single application related notification
    /// </summary>
    /// <param name="id">the unique identifier for the notification</param>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>A ready to use URI to use in order to read a specific application related notification</returns>
    public static Uri GetNotificationByAppUri(string id, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, byApp, notification, id));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to syncronize application related notifications 
    /// </summary>
    /// <param name="version">the version of the current SyncData object</param>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>A ready to use URI for syncronizing the the application related notifications</returns>
    public static Uri GetSyncNotificationsByAppUri(long version, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}?since={5}", baseUrl, byApp, appId, notification, sync, version));
      return ub.Uri;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns></returns>
    public static Uri GetUpdateNotificationByAppUri(string id, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}", baseUrl, byApp, appId, notification, id));
      return ub.Uri;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns></returns>
    public static Uri GetDeleteNotificationByAppUri(string id, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}", baseUrl, byApp, appId, notification, id));
      return ub.Uri;
    }

    #endregion


    /*
     *  Methods that generate URIs to use for reading and managing notifications related 
     *  to the user itself, that do require an user identifier (i.e. the token)
     */

    #region Actions by USER

    public static Uri GetNotificationsByUserUri(long since, int position, int count)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", baseUrl, byUser, notification));

      Dictionary<string, string> stringQuery = new Dictionary<string, string>();
      stringQuery["since"] = since.ToString();
      stringQuery["position"] = position.ToString();
      stringQuery["count"] = count.ToString();
      ub.Query = QueryHelper.DictionaryToQuery(stringQuery);

      return ub.Uri;
    }

    public static Uri GetNotificationByUserUri(string id)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, byUser, notification, id));
      return ub.Uri;
    }

    public static Uri GetSyncNotificationsByUserUri(long version)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}?since={4}", baseUrl, byUser, notification, sync, version));
      return ub.Uri;
    }

    public static Uri GetUpdateNotificationByUserUri(string id)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, byUser, notification, id));
      return ub.Uri;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns></returns>
    public static Uri GetDeleteNotificationByUserUri(string id, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, byUser, notification, id));
      return ub.Uri;
    }
    #endregion


    /*
     *  Other support functions 
     */

    #region Other

    /// <summary>
    /// 
    /// </summary>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns></returns>
    public static Uri GetRegisterAppUri(string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, register, byApp, appId));
      return ub.Uri;
    }

    #endregion

  }
}
