using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace PhoneApp1
{
  public partial class MainPage : PhoneApplicationPage
  {
    string secret, clientid, redirectUrl, baseUrl;
    string code;
    // Constructor
    public MainPage()
    {
      InitializeComponent();
      secret = "f3ea5378-43ba-42c3-b2bf-5f7cd10b6e6e";
      clientid = "52482826-891e-4ee0-9f79-9153a638d6e4";
      redirectUrl = "http://localhost/";
      baseUrl = "https://vas-dev.smartcampuslab.it/";
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      //string url = baseUrl + "aac/eauth/authorize?client_id=" + clientid + "&response_type=code&redirect_uri=" + redirectUrl;
      //banana.Navigate(new Uri(url));

      //      GET /aac/basicprofile/me HTTPS/1.1
      //Host: vas-dev.smartcampuslab.it
      //Accept: application/json
      //Authorization: Bearer 025a90d4-d4dd-4d90-8354-779415c0c6d8
      
      string url = baseUrl + "aac/basicprofile/me";
      CookieAwareWebClient wc = new CookieAwareWebClient();
      wc.DownloadStringCompleted += wc_DownloadStringCompleted;
      wc.Headers["Accept"] = "application/json";
	  
	  // #########################
	  // ##                     ##
	  // ## IL TOKEN SCADE!!!!! ##
	  // ##                     ##
	  // #########################
	  
      wc.Headers["Authorization"] = "Bearer bb435c41-2a40-4e1d-9aac-9812d5972dc6";
      wc.DownloadStringAsync(new Uri(url));
    }

    void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
      try
      {
        MessageBox.Show(e.Result);
      }catch(WebException wex){
        
      }
      
    }

    private void banana_Navigating(object sender, NavigatingEventArgs e)
    {
      if (e.Uri.Host.ToString() == "localhost")
      {
        code = e.Uri.Query.Split('=')[1];
        //        POST /aac/oauth/token HTTPS/1.1
        //Host: vas-dev.smartcampuslab.it
        //Content-Type: application/x-www-form-urlencoded

        //client_id=23123121sdsdfasdf3242&
        //client_secret=3rwrwsdgs4sergfdsgfsaf&
        //code=DS324
        //redirect_uri=http://www.example.com/&
        //grant_type=authorization_code

        string url = baseUrl + "aac/oauth/token";
        string postData = Uri.EscapeUriString("client_id=" + clientid + "&client_secret=" + secret + "&code=" + code + "&redirect_uri=" + redirectUrl + "&grant_type=authorization_code");
        
        WebClient wc = new WebClient();
        wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";
        wc.UploadStringCompleted += wc_UploadStringCompleted;
        wc.UploadStringAsync(new Uri(url), postData);
      }
    }

    void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
    {
      try
      {
        MessageBox.Show(e.Result);
        string a = e.Result;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

  }
}

public class CookieAwareWebClient : WebClient
{
  [System.Security.SecuritySafeCritical]
  public CookieAwareWebClient()
    : base()
  {
  }
  public CookieContainer m_container = new CookieContainer();

  protected override WebRequest GetWebRequest(Uri address)
  {
    WebRequest request = base.GetWebRequest(address);

    if (request is HttpWebRequest)
    {
      (request as HttpWebRequest).AllowAutoRedirect = false;
      (request as HttpWebRequest).CookieContainer = m_container;
    }
    return request;
  }

}