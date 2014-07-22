using System;
using System.Linq;
using System.Windows;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Controls;

using Models.ProfileService;
using Models.MobilityService;
using Models.AuthorizationService;
using Models.TerritoryInformationService;

using ProfileServiceLibrary;
using AuthenticationLibrary;
using MobilityServiceLibrary;
using TerritoryInformationServiceLibrary;
using System.Collections;
using Models.MobilityService.Journeys;
using Newtonsoft.Json;
using Models.MobilityService.PublicTransport;
using System.IO;
using Windows.Storage;
using System.Threading;
using System.Windows.Controls;
using Microsoft.Phone.Maps.Services;
using System.Device.Location;
using CommunicatorServiceLibrary;




namespace TesterApp
{
  public partial class MainPage : PhoneApplicationPage
  {
    #region Initialization

    IsolatedStorageSettings iss;
    string DB_PATH = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "sample.sqlite"));
    string secret = "f3ea5378-43ba-42c3-b2bf-5f7cd10b6e6e";
    string clientid = "52482826-891e-4ee0-9f79-9153a638d6e4";
    string redirectUrl = "http://localhost";
    string code;
    GeoCoordinate GPSPos;
    AuthLibrary authLib;
    PublicTransportLibrary ptl;
    RoutePlanningLibrary rpl;
    ProfileLibrary proLib;
    TerritoryInformationLibrary til;
    UserRouteLibrary url;
    CommunicatorLibrary comml;
    Token toMo;
    EventObject eventObj, userDefinedEo;
    POIObject poiObj;
    StoryObject storyObj;
    SingleJourney sj;
    RecurrentJourneyParameters rjp;
    Position fromPos, toPos;
    Itinerary iti;
    RecurrentJourney rIti;
    BasicItinerary globalBasiIti;
    BasicRecurrentJourney globalRITI;

    public MainPage()
    {
      InitializeComponent();
      iss = IsolatedStorageSettings.ApplicationSettings;
      authLib = new AuthLibrary(clientid, secret, redirectUrl, "https://vas-dev.smartcampuslab.it/");
    }

    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
      if (iss.Contains("token"))
      {
        toMo = iss["token"] as Token;
        pivotGrande.Items.RemoveAt(0);
        pivotGrande.Items.RemoveAt(0);       
        InitializeLibs();

      }
      fromPos = new Position() { Latitude = "46.3686", Longitude = "11.0306" };
      toPos = new Position() { Latitude = "46.066695", Longitude = "11.11889" };
      LaunchGPS();
    }

    private void InitializeLibs()
    {
      proLib = new ProfileServiceLibrary.ProfileLibrary(toMo.AccessToken, "https://vas-dev.smartcampuslab.it/");
      ptl = new PublicTransportLibrary(toMo.AccessToken, "https://vas-dev.smartcampuslab.it/");
      url = new UserRouteLibrary(toMo.AccessToken, "https://vas-dev.smartcampuslab.it/");
      til = new TerritoryInformationLibrary(toMo.AccessToken, "https://vas-dev.smartcampuslab.it/");
      rpl = new RoutePlanningLibrary(toMo.AccessToken, "https://vas-dev.smartcampuslab.it/");
      comml = new CommunicatorLibrary(toMo.AccessToken, "https://vas-dev.smartcampuslab.it/", "core.mobility");
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
      InitializeLibs();
      
      iss["token"] = toMo;
      iss.Save();
      MessageBox.Show("Ho un token: " + toMo.AccessToken);
    }

    #endregion

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

    #region MobilityService.PublicTransport
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

    #region TerritoryInformationService
    private async void btnReadEvents_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.ReadEvents();

      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
      if (resp.Count > 0)
      {
        EventObject eventToRate = resp.Find(x => x.Id == "134808885118048636529365400384921579313930057380949600640755079184396898141722430144645782472404440250412733094054572552042642823880677429621015167729836101489995968707132452629768876840219577255621559343517892101654577696837951680920349582117477636054071779878341980208");
        if (eventToRate != null)
          eventObj = eventToRate;
        else
          eventToRate = resp[0];
        btnReadSingleEvent.IsEnabled = true;
        btnRateObject.IsEnabled = true;
        btnAddToMyEvents.IsEnabled = true;
        btnFollowEvent.IsEnabled = true;
      }
    }

    private async void btnReadSingleEvent_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.ReadSingleEvent(eventObj.Id);
      MessageBox.Show(resp.ToString());
    }

    private async void btnReadPlaces_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.ReadPlaces();
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
      if (resp.Count > 0)
      {
        poiObj = resp.Count > 1 ? resp[1] : resp[0];
        btnReadSinglePlace.IsEnabled = true;
        btnFollowPlace.IsEnabled = true;

      }
    }

    private async void btnReadSinglePlace_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.ReadSinglePlace(poiObj.Id);     
      MessageBox.Show(resp.ToString());
    }

    private async void btnReadStories_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.ReadStories();
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
      if (resp.Count > 0)
      {
        storyObj = resp.Count > 1 ? resp[1] : resp[0];
        btnReadSingleStories.IsEnabled = true;
        btnAddToMyStories.IsEnabled = true;
      }
    }

    private async void btnReadSingleStories_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.ReadSingleStory(storyObj.Id);
      MessageBox.Show(resp.ToString());
    }

    private async void btnSync_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      Dictionary<string, string> include = new Dictionary<string, string>();
      include.Add("type", "Museums");
      var resp = await til.Sync(include);
      MessageBox.Show(resp.ToString());
    }

    private async void btnRateObject_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.RateObject(eventObj.Id, 2);
      MessageBox.Show("prima: " + eventObj.CommunityDataInfo.AverageRating + " dopo: " + resp.ToString());
    }

    private async void btnAddToMyStories_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.AddToMyStories(storyObj.Id);
      MessageBox.Show(resp.ToString());
      btnRemoveFromMyStories.IsEnabled = true;
    }

    private async void btnAddToMyEvents_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.AddToMyEvents(eventObj.Id);
      MessageBox.Show(resp.ToString());
      btnRemoveFromMyEvents.IsEnabled = true;
    }

    private async void btnRemoveFromMyStories_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.RemoveFromMyStories(storyObj.Id);
      MessageBox.Show(resp.ToString());
      btnRemoveFromMyEvents.IsEnabled = false;
    }

    private async void btnRemoveFromMyEvents_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.RemoveFromMyEvents(eventObj.Id);
      MessageBox.Show(resp.ToString());
      btnRemoveFromMyEvents.IsEnabled = false;
    }

    private async void btnFollowEvent_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.FollowEvent(eventObj.Id);
      MessageBox.Show(resp.ToString());
      btnUnfollowEvent.IsEnabled = true;
    }

    private async void btnUnfollowEvent_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.UnFollowEvent(eventObj.Id);
      MessageBox.Show(resp.ToString());
    }
    private async void btnFollowPlace_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.FollowPlace(poiObj.Id);
      MessageBox.Show(resp.ToString());
      btnUnfollowPlace.IsEnabled = true;
    }

    private async void btnUnfollowPlace_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.UnFollowPlace(poiObj.Id);
      MessageBox.Show(resp.ToString());
    }
    private async void btnFollowStory_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.FollowStory(storyObj.Id);
      MessageBox.Show(resp.ToString());
      btnUnfollowStory.IsEnabled = true;
    }

    private async void btnUnfollowStory_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await til.UnFollowStory(storyObj.Id);
      MessageBox.Show(resp.ToString());
    }

    #endregion

    #region TerritoryInformationService.UserDefinedObjects
    private async void btnCreateEvent_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var respPlaces = await til.ReadPlaces();
      poiObj = respPlaces.Count > 0 ? respPlaces[0] : null;

      TimeSpan ts = new TimeSpan(1, 0, 0, 0);
      userDefinedEo = new EventObject();
      userDefinedEo.Description = "Some test description";
      userDefinedEo.Title = "test title";
      userDefinedEo.Type = "Party";
      userDefinedEo.POIId = poiObj.Poi.Id;
      userDefinedEo.Location = new double[] { poiObj.Poi.Latitude, poiObj.Poi.Longitude };
      userDefinedEo.FromTime = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssffff"));
      userDefinedEo.ToTime = Int64.Parse((DateTime.Now + ts).ToString("yyyyMMddHHmmssffff"));
      userDefinedEo.Timing = "All day all night";

      var resp = await til.CreateUserDefinedEvent(userDefinedEo);
      MessageBox.Show(resp.ToString());
      btnUpdateEvent.IsEnabled = true;
      btnDeleteEvent.IsEnabled = true;
    }

    private async void btnUpdateEvent_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      userDefinedEo.Title = userDefinedEo.Title + " UPDATED";
      var resp = await til.UpdateUserDefinedEvent(userDefinedEo);
      MessageBox.Show(resp.ToString());
    }

    private void btnDeleteEvent_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      try
      {
        til.DeleteUserDefinedEvent(userDefinedEo.Id);
        MessageBox.Show("deleted");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
    #endregion

    #region MobilityService.RoutePlanning

    #region Single journey

    private async void getPlanJourney_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      sj = new SingleJourney();
      sj.Date = DateTime.Now.ToString("MM/dd/yyyy");
      sj.DepartureTime = DateTime.Now.ToString("HH:mm");
      sj.From = fromPos;
      sj.To = toPos;
      sj.ResultsNumber = 3;
      sj.RouteType = RouteType.Fastest;
      sj.TransportTypes = new TransportType[] { TransportType.Transit, TransportType.Bicycle };
      List<Itinerary> resp = await rpl.PlanSingleJourney(sj);
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
      iti = resp.Count > 0 ? resp[0] : null;
    }

    private async void getSaveSingleJourney_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {      
      if (iti != null)
      {
        BasicItinerary basIti = new BasicItinerary();
        basIti.Data = iti;
        basIti.Monitor = true;
        basIti.Name = "io sono un test";
        basIti.OriginalFrom = fromPos;
        basIti.OriginalTo = toPos;

        var resp = await url.SaveSingleJourney(basIti);
        MessageBox.Show(resp != null? resp.ToString() : "no results!");
        globalBasiIti = basIti;
      }
    }

    private async void btngetAllPlannedJourneys_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await url.ReadAllSingleJourneys();
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
    }           

    private async void getSingleJourney_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await url.ReadSingleJourney(globalBasiIti.ClientId);
      MessageBox.Show(resp != null ? resp.ToString() : "no results!");
    }

    private async void getDeleteSingleJourney_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await url.DeleteSingleJourney(globalBasiIti.ClientId);
      MessageBox.Show(resp.ToString());
    }

    #endregion

    #region Recurrent journey

    private async void getPlanRecurrentJourney_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {

      rjp = new RecurrentJourneyParameters();
      rjp.Time = "16:30";
      rjp.FromDate = Convert.ToInt64(DateTimeToEpoch(DateTime.Now));
      rjp.ToDate = Convert.ToInt64(DateTimeToEpoch((DateTime.Now + new TimeSpan(14, 0, 0, 0)).ToUniversalTime() ));
      rjp.Interval = Convert.ToInt64(1.5 * 60 * 60 * 1000);
      rjp.From = fromPos;
      rjp.To = toPos;
      rjp.Recurrences = new int[] { 1, 2, 3, 4 };
      rjp.ResultsNumber = 3;
      rjp.RouteType = RouteType.Fastest;
      rjp.TransportTypes = new TransportType[] { TransportType.Transit, TransportType.Bicycle, TransportType.Car, TransportType.Walk };
      RecurrentJourney rec = await rpl.PlanRecurrentJourney(rjp);
      MessageBox.Show(rec != null ? rec.ToString() : "no results!");
      rIti =rec != null? rec : null;
    }

    private async void getSaveRecurrentJourney_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      BasicRecurrentJourney biEreJay = new BasicRecurrentJourney()
      {
        Data = rIti,
        Monitor = true,
        Name = "Tamavvo"
      };
      var resp = await url.SaveRecurrentJourney(biEreJay);
      MessageBox.Show(resp!= null ? resp.ToString() : "no results!");
      globalRITI = resp;
    }

    private async void getAllRecurrentJourneys_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await url.ReadAllRecurrentJourneys();
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
      globalRITI = resp[0];
    }

    private async void getRecurrentJourney_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await url.ReadRecurrentJourney(globalRITI.ClientId);
      MessageBox.Show(resp != null ? resp.ToString() : "no results!");
    }

    private async void getUpdateRecurrentJourney_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      globalRITI.Name = "uauauau";
      var resp = await url.UpdateRecurrentJourney(globalRITI.ClientId, globalRITI);
      MessageBox.Show(resp.ToString());

    }

    private async void getDeleteRecurrentJourney_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await url.DeleteRecurrentJourney(globalRITI.ClientId);
      MessageBox.Show(resp.ToString());
    }

    #endregion

    private double DateTimeToEpoch(DateTime dt)
    {
      TimeSpan span = (dt.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
      return span.TotalMilliseconds;
    }


    #endregion

    #region  Geocoding & Location-aware stuff

    private void btnThread_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      Thread t = new Thread(Tama);
      t.Start();
    }

    public void Tama()
    {
      Button btEn = new Button();
      btEn.Content = "Banana";
      Dispatcher.BeginInvoke(delegate
      {
        //threadStack.Children.Add(btEn);
      });
    }

    private void btnPlaceStr_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {

      GeocodeQuery gq = new GeocodeQuery();
      
      gq.SearchTerm = txtsearch.Text;
      gq.GeoCoordinate = GPSPos;
      //gq.GeoCoordinate = new GeoCoordinate(0, 0);
      gq.MaxResultCount = 10;
      gq.QueryCompleted += gq_QueryCompleted;
      gq.QueryAsync();
      
    }

    bool SearchCheat(string search, string word)
    {
      return true;
    }

    private string MapAddressToString(MapAddress mapa)
    {
      string result = string.Format("{0}, {1}, {2}, {4}, {5}", mapa.BuildingName, mapa.Street, mapa.HouseNumber, mapa.City, mapa.PostalCode, mapa.Country);
      return result.StartsWith(",") ? result.Substring(2) : result;
    }

    void gq_QueryCompleted(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
    {

      foreach (var item in e.Result)
      {
        MessageBox.Show(MapAddressToString(item.Information.Address), item.Information.Name + " " + item.Information.Description, MessageBoxButton.OK);
      }
    }

    #region GPS

    private void LaunchGPS()
    {
      GeoCoordinateWatcher geolocator = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
      geolocator.StatusChanged += geolocator_StatusChanged;
      geolocator.Start();
    }

    void geolocator_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
    {
      if (e.Status == GeoPositionStatus.Ready)
      {
        GPSPos = (sender as GeoCoordinateWatcher).Position.Location;
        (sender as GeoCoordinateWatcher).Stop();
        geoCose.IsEnabled = true;
      }
    }

    #endregion

    private void btnTellSelected_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      MessageBox.Show(gacb.Tag.ToString());
    }

    private async void getStopsForRouteByLocation_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var res = await ptl.GetStopsForRouteByLocation(AgencyType.TrentoCityBus, "05A", 46.0697, 11.1211, 0.01);
      MessageBox.Show(res.Count.ToString());
    }

    private async void getStopsByLocation_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var res = await ptl.GetStopsByLocation(AgencyType.TrentoCityBus, 46.0697, 11.1211, 0.01, 0, 100);
      MessageBox.Show(res.Count.ToString());
    }

    #endregion

    #region CommunicatorServiceLibrary

    private async void btnPubConf_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      //Dictionary<string, object> config = await comml.RequestPublicConfigurationToPush();
     
    }

    private void btnsubNot_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      
    }

    #endregion

    private void btnStartNavigate_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      // Coordinates foar Piazza S. Gottardo, Mezzocorona
      Windows.System.Launcher.LaunchUriAsync(new System.Uri("smartcampuslab:NavigateTowards?lat=46.2153444&lng=11.1199183"));
    }
  }
}