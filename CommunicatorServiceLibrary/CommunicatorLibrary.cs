using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
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
  ///  Class that wraps the the profile APIs in an easy to use way
  /// </summary>
  public class CommunicatorLibrary
  {
    HttpClient httpCli;
    string accessToken;

    /// <summary>
    /// Main constructor, to use always
    /// </summary>
    /// <param name="accessToken">The SmartCampus-issued access token</param>
    /// <param name="accessToken">The SmartCampus server address where all requests will be executed (must include trailing /) </param>
    public CommunicatorLibrary(string accessToken, string serverUrl)
    {
      //ProfileUriHelper.SetBaseUrl(serverUrl);
      //this.accessToken = accessToken;
      //httpCli = new HttpClient();
    }
  }
}
