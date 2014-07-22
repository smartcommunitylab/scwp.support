using Models.CommunicatorService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
  /// Class that wraps the the profile APIs in an easy to use way
  /// </summary>
  public class CommunicatorLibrary
  {
    HttpClient httpCli;
    string accessToken, appId;

    /// <summary>
    /// Main constructor, to use always
    /// </summary>
    /// <param name="accessToken">The SmartCampus-issued access token</param>
    /// <param name="serverUrl">The SmartCampus server address where all requests will be executed (must include trailing /) </param>
    /// <param name="appId">The SmartCampus identifier for the service that should provide notifications (i.e. core.mobility) </param>
    public CommunicatorLibrary(string accessToken, string serverUrl, string appId)
    {
      CommunicatorLibraryUriHelper.SetBaseUrl(serverUrl);
      this.accessToken = accessToken;
      this.appId = appId;
      httpCli = new HttpClient();
    }

    #region App

    /// <summary>
    /// Retrieves the notifications for the initially selected app
    /// </summary>
    /// <param name="since">unix timestamp of initial time from which to recover notifications</param>
    /// <param name="position">i don't know what this is</param>
    /// <param name="count">how many notifications are desired</param>
    /// <returns>A list of notifiaction objects</returns>
    public async Task<List<Notification>> GetNotificationsByApp(long since, int position, int count)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(CommunicatorLibraryUriHelper.GetNotificationsByAppUri(since, position, count, this.appId));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Notification>>(JSONResult);
    }

    /// <summary>
    /// Retrieves a single notification from the server, for the initially selected app
    /// </summary>
    /// <param name="id">The unique identifier of the desired notification</param>
    /// <returns>An instance of the requested notification </returns>
    public async Task<Notification> GetNotificationByApp(string id)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(CommunicatorLibraryUriHelper.GetNotificationByAppUri(id, this.appId));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<Notification>(JSONResult);
    }   

    /// <summary>
    /// syncs notification data
    /// </summary>
    /// <param name="syncData">a syncdata object containing the data to sync</param>
    /// <returns>a syncdata object containing the synced data</returns>
    public async Task<SyncData> SyncNotificationsByApp(SyncData syncData)
    { 
      /*
       * I DO NOT REMEMBER WHAT THIS FUNCTION DOES, PLEASE EDIT ONCE  
       * MORE INFORMATION IS AVAILABLE ON THIS FUNCTION
       * 
       */
      string toPost = JsonConvert.SerializeObject(syncData);
      StringContent sc = new StringContent(toPost, Encoding.UTF8, "application/json");

      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PostAsync(CommunicatorLibraryUriHelper.GetSyncNotificationsByAppUri(syncData.Version, this.appId), sc);

      return JsonConvert.DeserializeObject<SyncData>(await JSONResult.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// Updates a single notification, setting its values to the ones specified in the object, for the initially selected app
    /// </summary>
    /// <param name="notification">The edited notification</param>
    /// <param name="id">The unique identifier of the notification to update</param>
    /// <returns>An instance of the updated Notification item</returns>
    public async Task<Notification> UpdateNotificatioByApp(Notification notification, string id) //string id seems useless and redundant, please remove
    {
      string toPost = JsonConvert.SerializeObject(notification);
      StringContent sc = new StringContent(toPost, Encoding.UTF8, "application/json");

      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PutAsync(CommunicatorLibraryUriHelper.GetUpdateNotificationByAppUri(id, this.appId), sc);

      return JsonConvert.DeserializeObject<Notification>(await JSONResult.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// Deletes a stored notification for the initially selected app
    /// </summary>
    /// <param name="id">The unique identifier for the notification</param>
    /// <returns>a boolean value, indicating weather the delete operation was a success or not</returns>
    public async Task<bool> DeleteNotificatioByApp(string id)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.DeleteAsync(CommunicatorLibraryUriHelper.GetDeleteNotificationByAppUri(id, this.appId));

      return Convert.ToBoolean(await JSONResult.Content.ReadAsStringAsync());
    }

    #endregion

    #region User

    /// <summary>
    /// Retrieves the notifications for the current user
    /// </summary>
    /// <param name="since">unix timestamp of initial time from which to recover notifications</param>
    /// <param name="position">i don't know what this is</param>
    /// <param name="count">how many notifications are desired</param>
    /// <returns>A list of notifiaction objects</returns>
    public async Task<List<Notification>> GetNotificationsByUser(long since, int position, int count)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(CommunicatorLibraryUriHelper.GetNotificationsByUserUri(since, position, count));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Notification>>(JSONResult);
    }

    /// <summary>
    /// Retrieves a single notification from the server for the current user
    /// </summary>
    /// <param name="id">The unique identifier of the desired notification</param>
    /// <returns>An instance of the requested notification </returns>
    public async Task<Notification> GetNotificationByUser(string id)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(CommunicatorLibraryUriHelper.GetNotificationByUserUri(id));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<Notification>(JSONResult);
    }

    /// <summary>
    /// syncs notification data
    /// </summary>
    /// <param name="syncData">a syncdata object containing the data to sync</param>
    /// <returns>a syncdata object containing the synced data</returns>
    public async Task<SyncData> SyncNotificationsByUser(SyncData syncData)
    {
      string toPost = JsonConvert.SerializeObject(syncData);
      StringContent sc = new StringContent(toPost, Encoding.UTF8, "application/json");

      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PostAsync(CommunicatorLibraryUriHelper.GetSyncNotificationsByUserUri(syncData.Version), sc);

      return JsonConvert.DeserializeObject<SyncData>(await JSONResult.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// Updates a single notification, setting its values to the ones specified in the object, for the current user
    /// </summary>
    /// <param name="notification">The edited notification</param>
    /// <param name="id">The unique identifier of the notification to update</param>
    /// <returns>An instance of the updated Notification item</returns>
    public async Task<Notification> UpdateNotificatioByUser(Notification notification, string id)
    {
      string toPost = JsonConvert.SerializeObject(notification);
      StringContent sc = new StringContent(toPost, Encoding.UTF8, "application/json");

      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PutAsync(CommunicatorLibraryUriHelper.GetUpdateNotificationByUserUri(id), sc);

      return JsonConvert.DeserializeObject<Notification>(await JSONResult.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// Deletes a stored notification for the current user
    /// </summary>
    /// <param name="id">The unique identifier for the notification</param>
    /// <returns>a boolean value, indicating weather the delete operation was a success or not</returns>
    public async Task<bool> DeleteNotificatioByUser(string id)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.DeleteAsync(CommunicatorLibraryUriHelper.GetDeleteNotificationByUserUri(id));

      return Convert.ToBoolean(await JSONResult.Content.ReadAsStringAsync());
    }

    #endregion

    #region Other

    /// <summary>
    /// registers the application to push notification service as application
    /// </summary>
    /// <param name="appSignature">the unique identifier for the app</param>
    /// <returns>a boolean value, indicating weather the delete operation was a success or not</returns>
    public async Task<bool> RegisterAppToPush(AppSignature appSignature)
    {
      string toPost = JsonConvert.SerializeObject(appSignature);
      StringContent sc = new StringContent(toPost, Encoding.UTF8, "application/json");

      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PostAsync(CommunicatorLibraryUriHelper.GetRegisterAppToPushUri(appId), sc);
      return true;
    }

    /// <summary>
    /// registers the application to push notification service as the current user
    /// </summary>
    /// <param name="userSignature">the unique identifier for the user</param>
    /// <returns>a boolean value, indicating weather the delete operation was a success or not</returns>
    public async Task<bool> RegisterUserToPush(UserSignature userSignature)
    {
      string toPost = JsonConvert.SerializeObject(userSignature);
      StringContent sc = new StringContent(toPost, Encoding.UTF8, "application/json");

      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PostAsync(CommunicatorLibraryUriHelper.GetRegisterUserToPushUri(appId), sc);
      return true;
    }

    /// <summary>
    /// Unregisters the application from the push notification service
    /// </summary>
    public async void UnregisterAppToPush()
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      await httpCli.DeleteAsync(CommunicatorLibraryUriHelper.GetUnregisterAppToPushUri(this.appId));
    }

    /// <summary>
    /// Unregisters the user from the push notification service
    /// </summary>
    public async void UnregisterUserToPush()
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      await httpCli.DeleteAsync(CommunicatorLibraryUriHelper.GetUnregisterUserToPushUri(this.appId));
    }

    /// <summary>
    /// As the app, sends a notification to the users which subscribed to the app
    /// </summary>
    /// <param name="notification">the notification object to send</param>
    /// <param name="users">a list of users who must receive the notification</param>
    public async void SendAppNotification(Notification notification, List<string> users)
    {
      string toPost = JsonConvert.SerializeObject(notification);
      StringContent sc = new StringContent(toPost, Encoding.UTF8, "application/json");

      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PostAsync(CommunicatorLibraryUriHelper.GetSendAppNotificationUri(users,this.appId), sc);
     }

    /// <summary>
    /// Gets the unique identifier of the application for the notification service
    /// </summary>
    /// <returns>The unique application identifier</returns>
    public async Task<AppSignature> RequestAppConfigurationToPush()
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(CommunicatorLibraryUriHelper.GetRequestAppConfigurationToPushUri(this.appId));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<AppSignature>(JSONResult);
    }

    /// <summary>
    /// Gets the unique identifier of the user for the notification service
    /// </summary>
    /// <returns>The unique user identifier</returns>
    public async Task<Dictionary<string, object>> RequestUserConfigurationToPush()
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(CommunicatorLibraryUriHelper.GetRequestUserConfigurationToPushUri(this.appId));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(JSONResult);
    }

    /// <summary>
    /// Gets an identifier for the notification service
    /// </summary>
    /// <returns>the identifier, in dictionary form</returns>
    public async Task<Dictionary<string, object>> RequestPublicConfigurationToPush()
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(CommunicatorLibraryUriHelper.GetRequestPublicConfigurationToPushUri(this.appId));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(JSONResult);
    }

    #endregion
  }
}
