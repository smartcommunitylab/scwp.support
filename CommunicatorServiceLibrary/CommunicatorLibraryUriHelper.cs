
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
  /// Helper class for the territory information library, contains static functions that 
  /// generate already-formatted URIs for using within the territory information library
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

    #region Actions by APP
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

    public static Uri GetNotificationByAppUri(string id, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, byApp, notification, id));
      return ub.Uri;
    }

    public static Uri GetSyncNotificationsByAppUri(long version, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}?since={5}", baseUrl, byApp, appId, notification, sync, version));
      return ub.Uri;
    }

    public static Uri GetUpdateNotificationByAppUri(string id, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}", baseUrl, byApp, appId, notification, id));
      return ub.Uri;
    }

    public static Uri GetDeleteNotificationByAppUri(string id, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}", baseUrl, byApp, appId, notification, id));
      return ub.Uri;
    }
    #endregion

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

    public static Uri GetDeleteNotificationByUserUri(string id, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, byUser, notification, id));
      return ub.Uri;
    }
    #endregion

    #region Other
    private static Uri GetRegisterUri(string byWho, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, register, byWho, appId));
      return ub.Uri;
    }

    public static Uri GetRegisterAppToPushUri(string appId)
    {
      return GetRegisterUri(byApp, appId);
    }

    public static Uri GetRegisterUserToPushUri(string appId)
    {
      return GetRegisterUri(byUser, appId);
    }


    private static Uri GetUnregisterUri(string byWho, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, unregister, byWho, appId));
      return ub.Uri;
    }

    public static Uri GetUnregisterAppToPushUri(string appId)
    {
      return GetUnregisterUri(byApp, appId);
    }

    public static Uri GetUnregisterUserToPushUri(string appId)
    {
      return GetUnregisterUri(byUser, appId);
    }


    public static Uri GetSendAppNotificationUri(List<string> users, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}", baseUrl, send, byApp, appId, String.Join(",", users)));
      return ub.Uri;
    }



    private static Uri GetRequestConfigurationToPushUri(string byWho, string appId)
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", baseUrl, configuration, byWho, appId));
      return ub.Uri;
    }

    public static Uri GetRequestAppConfigurationToPushUri(string byWho, string appId)
    {
      return GetRequestConfigurationToPushUri(byApp, appId);
    }

    public static Uri GetRequestUserConfigurationToPushUri(string byWho, string appId)
    {
      return GetRequestConfigurationToPushUri(byUser, appId);
    }

    public static Uri GetRequestPublicConfigurationToPushUri(string byWho, string appId)
    {
      return GetRequestConfigurationToPushUri(byPublic, appId);
    }
    #endregion

  }
}
