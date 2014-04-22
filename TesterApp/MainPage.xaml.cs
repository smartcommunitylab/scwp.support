using Microsoft.Phone.Controls;
using System.Windows;
using System.Collections.Generic;

using Models.ProfileService;
using Models.MobilityService;
using Models.AuthorizationService;

using ProfileServiceLibrary;
using AuthenticationLibrary;
using MobilityServiceLibrary;
using System.IO.IsolatedStorage;
using System;


namespace TesterApp
{
  public partial class MainPage : PhoneApplicationPage
  {
    IsolatedStorageSettings iss;
    string secret = "f3ea5378-43ba-42c3-b2bf-5f7cd10b6e6e";
    string clientid = "52482826-891e-4ee0-9f79-9153a638d6e4";
    string redirectUrl = "http://localhost";
    string code;
    AuthLibrary authLib;
    PublicTransportLibrary ptl;
    ProfileLibrary proLib;
    Token toMo;

    public MainPage()
    {
      InitializeComponent();
      iss = IsolatedStorageSettings.ApplicationSettings;
      authLib = new AuthLibrary(clientid, secret, redirectUrl);

    }

    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
      if (iss.Contains("token"))
      {
        toMo = iss["token"] as Token;
        pivotGrande.Items.RemoveAt(0);
        pivotGrande.Items.RemoveAt(0);
        proLib = new ProfileServiceLibrary.ProfileLibrary(toMo.AccessToken);
        ptl = new PublicTransportLibrary(toMo.AccessToken);
      }
    }

    private void Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      banana.Navigate(AuthUriHelper.GetCodeUri(clientid, redirectUrl));
    }

    private void banana_Navigating(object sender, NavigatingEventArgs e)
    {
      if (e.Uri.Host.ToString() == "localhost")
      {
        code = e.Uri.Query.Split('=')[1];
        MessageBox.Show("Ho un code: " + code);

      }
    }

    private async void btnGetToken_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      toMo = await authLib.GetAccessToken(code);
      proLib = new ProfileServiceLibrary.ProfileLibrary(toMo.AccessToken);
      iss["token"] = toMo;
      iss.Save();
      MessageBox.Show("Ho un token: " + toMo.AccessToken);
    }

    #region ProfileService
    private async void GetBasicProfile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      BasicProfile ap = await proLib.GetBasicProfile();
      MessageBox.Show(ap.ToString());
    }
    private async void GetBasicAccount_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      AccountProfile ap = await proLib.GetBasicAccount();
      MessageBox.Show(ap.ToString());
    }

    private async void GetExtendedProfile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      List<ExtendedProfile> ap = await proLib.GetExtendedProfiles();
      MessageBox.Show(ap[0].ToString());
    }


    #endregion

    #region MobilityService


    private async void bteGetRoutesUrl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await ptl.GetRoutes(AgencyType.TrentoCityBus);
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : resp.ToString());
    }

    private async void btnGetStopsUrl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await ptl.GetStops(AgencyType.TrentoCityBus, "05A");
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : resp.ToString());
    }

    private async void btnGetTimetableUrl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await ptl.GetTimetable(AgencyType.TrentoCityBus, "05A", "247_12");
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : resp.ToString());
    }
    private async void btnGetLimitedTimetableUrl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await ptl.GetLimitedTimetable(AgencyType.TrentoCityBus, "247_12", 10);
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : resp.ToString());
    }
    private async void btnGetTransitTimesUrl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      TimeSpan ts = new TimeSpan(0, 1, 0, 0, 0);
      var resp = await ptl.GetTransitTimes("05A", Int32.Parse(DateTime.Now.ToString("yyyyMMddHHmmssffff")), Int32.Parse((DateTime.Now + ts).ToString("yyyyMMddHHmmssffff")));
      MessageBox.Show(resp.ToString());
    }

    private async void btnGetTransitDelaysUrl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      TimeSpan ts = new TimeSpan(0, 1, 0, 0, 0);
      var resp = await ptl.GetTransitDelays("05A", Int32.Parse(DateTime.Now.ToString("yyyyMMddHHmmssffff")), Int32.Parse((DateTime.Now + ts).ToString("yyyyMMddHHmmssffff")));
      MessageBox.Show(resp.ToString());
    }

    private async void btnGetParkingsByAgencyUrl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await ptl.GetParkingsByAgency(AgencyType.TrentoCityBus);
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : resp.ToString());
    }

    private async void btnGetRoadInfoByAgencyUrl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      TimeSpan ts = new TimeSpan(0, 1, 0, 0, 0);
      var resp = await ptl.GetRoadInfoByAgency(AgencyType.TrentoCityBus, Int32.Parse(DateTime.Now.ToString("yyyyMMddHHmmssffff")), Int32.Parse((DateTime.Now + ts).ToString("yyyyMMddHHmmssffff")));
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : resp.ToString());

    }
    #endregion



  }
}