using System;
using System.Windows;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Controls;

using Models.ProfileService;
using Models.MobilityService;
using Models.AuthorizationService;

using ProfileServiceLibrary;
using AuthenticationLibrary;
using MobilityServiceLibrary;
using System.Collections;
using Models.MobilityService.RealTime;



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

      /*Road r = new Road();
      r.FromIntersection = "a";
      r.ToIntersection = "b";
      r.Latitude = "123";
      r.Longitude = "123";
      r.Note = "note";
      r.Street = "via abc";
      r.StreetCode = "1";
      r.ToNumber = "12";
      r.FromNumber = "23";

      AlertRoad ar = new AlertRoad();
      ar.AgencyId = AgencyType.BikeSharingRovereto;
      ar.ChangeTypes = new List<ChangeType> { ChangeType.DriveChange, ChangeType.ParkingBlock };
      ar.CreatorId = "andrea";
      ar.CreatorType = CreatorType.User;
      ar.Description = "description";
      ar.Effect = "effect";
      ar.Entity = "entity";
      ar.Id = "";
      ar.Note = "note";
      ar.Type = AlertType.Custom;
      ar.ValidFrom = 1;
      ar.ValidUntil = 3;
      ar.RoadInfo = r;

      string a = Newtonsoft.Json.JsonConvert.SerializeObject(ar);*/
      
    }

    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
      if (iss.Contains("token"))
      {
        toMo = iss["token"] as Token;
        pivotGrande.Items.RemoveAt(0);
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
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
    }

    private async void btnGetStopsUrl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await ptl.GetStops(AgencyType.TrentoCityBus, "05A");
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
    }

    private async void btnGetTimetableUrl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await ptl.GetTimetable(AgencyType.TrentoCityBus, "05A", "247_12");
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
    }

    private async void btnGetLimitedTimetableUrl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await ptl.GetLimitedTimetable(AgencyType.TrentoCityBus, "247_12", 10);
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
    }

    private async void btnGetTransitTimesUrl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      TimeSpan ts = new TimeSpan(1, 0, 0, 0);
      var resp = await ptl.GetTransitTimes("05A", Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssffff")), Int64.Parse((DateTime.Now + ts).ToString("yyyyMMddHHmmssffff")));
      MessageBox.Show(resp.ToString());
    }

    private async void btnGetTransitDelaysUrl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      TimeSpan ts = new TimeSpan(1, 0, 0, 0);
      var resp = await ptl.GetTransitDelays("05A", Int64.Parse(DateTime.Now.ToString("yyyyMMddHHmmssffff")), Int64.Parse((DateTime.Now + ts).ToString("yyyyMMddHHmmssffff")));
      MessageBox.Show(resp.ToString());
    }

    private async void btnGetParkingsByAgencyUrl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await ptl.GetParkingsByAgency(AgencyType.ComuneDiTrento);
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
    }

    private async void btnGetRoadInfoByAgencyUrl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      TimeSpan ts = new TimeSpan(1, 0, 0, 0);
      
      var resp = await ptl.GetRoadInfoByAgency(AgencyType.TrentinoIntercityBus, Int64.Parse(DateTime.Now.ToString("yyyyMMddHHmmssffff")), Int64.Parse((DateTime.Now + ts).ToString("yyyyMMddHHmmssffff")));
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");

    }
    #endregion



  }
}