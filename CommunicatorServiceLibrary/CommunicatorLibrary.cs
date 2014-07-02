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
    /// <param name="accessToken">The SmartCampus server address where all requests will be executed (must include trailing /) </param>
    public CommunicatorLibrary(string accessToken, string serverUrl, string appId)
    {
      CommunicatorLibraryUriHelper.SetBaseUrl(serverUrl);
      this.accessToken = accessToken;
      this.appId = appId;
      httpCli = new HttpClient();
    }

    #region App

    public async Task<List<Notification>> GetNotificationsByApp(long since, int position, int count)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(CommunicatorLibraryUriHelper.GetNotificationsByAppUri(since, position, count, this.appId));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Notification>>(JSONResult);
    }

    public async Task<Notification> GetNotificationByApp(string id)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(CommunicatorLibraryUriHelper.GetNotificationByAppUri(id, this.appId));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<Notification>(JSONResult);
    }

    public async Task<SyncData> SyncNotificationsByApp(SyncData syncData)
    {
      string toPost = JsonConvert.SerializeObject(syncData);
      StringContent sc = new StringContent(toPost, Encoding.UTF8, "application/json");

      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      var JSONResult = await httpCli.PostAsync(CommunicatorLibraryUriHelper.GetSyncNotificationsByAppUri(syncData.Version, this.appId), sc);

      return JsonConvert.DeserializeObject<SyncData>(await JSONResult.Content.ReadAsStringAsync());
    }

    public async Task<Notification> UpdateNotificatioByApp(Notification notification, string id)
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

    public async Task<List<Notification>> GetNotificationsByUser(long since, int position, int count)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(CommunicatorLibraryUriHelper.GetNotificationsByUserUri(since, position, count));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Notification>>(JSONResult);
    }

    public async Task<Notification> GetNotificationByUser(string id)
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(CommunicatorLibraryUriHelper.GetNotificationByUserUri(id));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<Notification>(JSONResult);
    }

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

    public async void UnregisterAppToPush()
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      await httpCli.DeleteAsync(CommunicatorLibraryUriHelper.GetUnregisterAppToPushUri(this.appId));
    }

    public async void UnregisterUserToPush()
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      await httpCli.DeleteAsync(CommunicatorLibraryUriHelper.GetUnregisterUserToPushUri(this.appId));
    }

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

    public async Task<AppSignature> RequestAppConfigurationToPush()
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(CommunicatorLibraryUriHelper.GetRequestAppConfigurationToPushUri(this.appId));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<AppSignature>(JSONResult);
    }

    public async Task<Dictionary<string, object>> RequestUserConfigurationToPush()
    {
      httpCli.DefaultRequestHeaders.Clear();
      httpCli.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.Now.ToString("r"));
      httpCli.DefaultRequestHeaders.Add("Accept", "application/json");
      httpCli.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

      string JSONResult = await httpCli.GetStringAsync(CommunicatorLibraryUriHelper.GetRequestUserConfigurationToPushUri(this.appId));

      return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(JSONResult);
    }

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
