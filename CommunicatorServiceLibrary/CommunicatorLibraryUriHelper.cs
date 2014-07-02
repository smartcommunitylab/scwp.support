
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
    static string byPublic = "public";
    static string notification = "notification";
    static string sync = "sync";
    static string register = "register";
    static string unregister = "unregister";
    static string send = "send";
    static string configuration = "configuration";
    //static string REGISTRATIONID_HEADER = "REGISTRATIONID";
    //static string GCM_SENDER_API_KEY = "GCM_SENDER_API_KEY";
    //static string GCM_SENDER_ID = "GCM_SENDER_ID";
    //static string GCM_REGISTRATION_ID_USER = "GCM_REGISTRATION_ID_USER";

    /*
     *  Methods that generate URIs to use for reading and managing notifications related 
     *  to the application itself, that do not require an user identifier
     */
    #region App

    /// <summary>
    /// Creates a formatted URI to read all the application related notifications
    /// </summary>
    /// <param name="since">since date, in milliseconds (use 0 to get all notifications from begin of time)</param>
    /// <param name="position">position in the result set</param>
    /// <param name="count">number of desired results (use -1 to get all notifications)</param>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>A ready to use URI to use in order to read all application related notifications on the server</returns>
    public static Uri GetNotificationsByAppUri(long since, int position, int count, string appId)
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
    /// Creates a formatted URI to update an application related notification
    /// </summary>
    /// <param name="id">the unique identifier for the notification</param>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>A ready to use URI to use for updating an application related notification on the server</returns>
    public static Uri GetUpdateNotificationByAppUri(string id, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}", baseUrl, byApp, appId, notification, id));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to delete an application related notification
    /// </summary>
    /// <param name="id">the unique identifier for the notification</param>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>A ready to use URI to use for deleting an application related notification from the server</returns>
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
    #region User

    /// <summary>
    /// Creates a formatted URI to read all the user related notifications
    /// </summary>
    /// <param name="since">since date, in milliseconds (use 0 to get all notifications from begin of time)</param>
    /// <param name="position">position in the result set</param>
    /// <param name="count">number of desired results (use -1 to get all notifications)</param>
    /// <returns>A ready to use URI to use in order to read all user related notifications on the server</returns>
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

    /// <summary>
    /// Creates a formatted URI to read a single user related notification
    /// </summary>
    /// <param name="id">the unique identifier for the notification</param>
    /// <returns>A ready to use URI to use in order to read a specific user related notification</returns>
    public static Uri GetNotificationByUserUri(string id)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, byUser, notification, id));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to syncronize user related notifications 
    /// </summary>
    /// <param name="version">the version of the current SyncData object</param>
    /// <returns>A ready to use URI for syncronizing the the user related notifications</returns>
    public static Uri GetSyncNotificationsByUserUri(long version)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}?since={4}", baseUrl, byUser, notification, sync, version));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to update a user related notification
    /// </summary>
    /// <param name="id">the unique identifier for the notification</param>
    /// <returns>A ready to use URI to use for updating a user related notification on the server</returns>
    public static Uri GetUpdateNotificationByUserUri(string id)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, byUser, notification, id));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to delete a user related notification
    /// </summary>
    /// <param name="id">the unique identifier for the notification</param>
    /// <returns>A ready to use URI to use for deleting a user related notification from the server</returns>
    public static Uri GetDeleteNotificationByUserUri(string id)
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
    /// Actually creates the URI used to register for push notification
    /// </summary>
    /// <param name="byWho">the service who wants to subscribe</param>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>the proper registration URI</returns>
    private static Uri GetRegisterUri(string byWho, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, register, byWho, appId));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to register the application for push notifications
    /// </summary>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>A ready to use URI for registering the application to the push notification service</returns>
    public static Uri GetRegisterAppToPushUri(string appId)
    {
      return GetRegisterUri(byApp, appId);
    }

    /// <summary>
    /// Creates a formatted URI to register the user for push notifications 
    /// </summary>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>A ready to use URI for registering the user to the push notification service</returns>
    public static Uri GetRegisterUserToPushUri(string appId)
    {
      return GetRegisterUri(byUser, appId);
    }

    /// <summary>
    /// Actually creates the URI used to unregister from push notification
    /// </summary>
    /// <param name="byWho">the service who wants to unsubscribe</param>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>the proper unregistration URI</returns>
    private static Uri GetUnregisterUri(string byWho, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, unregister, byWho, appId));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to unregister the application from push notifications 
    /// </summary>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>A ready to use URI for unregistering the application from the push notification service</returns>
    public static Uri GetUnregisterAppToPushUri(string appId)
    {
      return GetUnregisterUri(byApp, appId);
    }

    /// <summary>
    /// Creates a formatted URI to unregister the user from push notifications 
    /// </summary>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>A ready to use URI for unregistering the user from the push notification service</returns>
    public static Uri GetUnregisterUserToPushUri(string appId)
    {
      return GetUnregisterUri(byUser, appId);
    }

    /// <summary>
    /// Creates a formatted URI to send a notification
    /// </summary>
    /// <param name="users">a list of users to whom the notification will be sent</param>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>A ready to use URI to use for sending a notification from the application</returns>
    public static Uri GetSendAppNotificationUri(List<string> users, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}", baseUrl, send, byApp, appId, String.Join(",", users)));
      return ub.Uri;
    }

    /// <summary>
    /// Actually creates a formatted URI to use for requesting the configuration to the server
    /// </summary>
    /// <param name="byWho">the service who wants to know</param>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>the proper URI for requesting the config</returns>
    private static Uri GetRequestConfigurationToPushUri(string byWho, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, configuration, byWho, appId));
      return ub.Uri;
    }

    /// <summary>
    /// Creates a formatted URI to use for requesting the application configuration to the server
    /// </summary>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>A ready to use URI for requesting the app configuration to the Comms Service</returns>
    public static Uri GetRequestAppConfigurationToPushUri(string appId)
    {
      return GetRequestConfigurationToPushUri(byApp, appId);
    }

    /// <summary>
    /// Creates a formatted URI to use for requesting the user configuration to the server
    /// </summary>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>A ready to use URI for requesting the user configuration to the Comms Service</returns>
    public static Uri GetRequestUserConfigurationToPushUri(string appId)
    {
      return GetRequestConfigurationToPushUri(byUser, appId);
    }

    /// <summary>
    /// Creates a formatted URI to use for requesting the public configuration to the server
    /// </summary>
    /// <param name="appId">the unique identifier for the application</param>
    /// <returns>A ready to use URI for requesting the public configuration to the Comms Service</returns>
    public static Uri GetRequestPublicConfigurationToPushUri(string appId)
    {
      return GetRequestConfigurationToPushUri(byPublic, appId);
    }

    #endregion

  }
}
