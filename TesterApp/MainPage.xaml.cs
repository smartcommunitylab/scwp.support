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
    RoutePlanningLibrary rpl;
    ProfileLibrary proLib;
    TerritoryInformationLibrary til;
    UserRouteLibrary url;
    Token toMo;
    EventObject eventObj, userDefinedEo;
    POIObject poiObj;
    StoryObject storyObj;
    SingleJourney sj;
    Position fromPos, toPos;
    Itinerary iti;

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
        //pivotGrande.Items.RemoveAt(0);
        //pivotGrande.Items.RemoveAt(0);
        InitializeLibs();
      }
      fromPos = new Position(){ Latitude = "46.066799", Longitude = "11.151796"};
      toPos = new Position() { Latitude = "46.066695", Longitude = "11.11889" };
    }

    private void InitializeLibs()
    {
      proLib = new ProfileServiceLibrary.ProfileLibrary(toMo.AccessToken, "https://vas-dev.smartcampuslab.it/");
      ptl = new PublicTransportLibrary(toMo.AccessToken, "https://vas-dev.smartcampuslab.it/");
      url = new UserRouteLibrary(toMo.AccessToken, "https://vas-dev.smartcampuslab.it/");
      til = new TerritoryInformationLibrary(toMo.AccessToken, "https://vas-dev.smartcampuslab.it/");
      rpl = new RoutePlanningLibrary(toMo.AccessToken, "https://vas-dev.smartcampuslab.it/");
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
      }
    }

    private async void btngetAllPlannedJourneys_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await url.ReadAllSingleJourneys();
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
    }           

    private async void getSingleJourney_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await url.ReadAllSingleJourneys();
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
    }

    private async void getDeleteSingleJourney_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await url.ReadAllSingleJourneys();
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
    }

    private async void getSaveRecurrentJourney_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await url.ReadAllSingleJourneys();
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
    }

    private async void getAllRecurrentJourneys_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await url.ReadAllSingleJourneys();
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
    }

    private async void getRecurrentJourney_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await url.ReadAllSingleJourneys();
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
    }

    private async void getDeleteRecurrentJourney_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var resp = await url.ReadAllSingleJourneys();
      MessageBox.Show(resp.Count > 0 ? resp[0].ToString() : "no results!");
    }

    #endregion

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



  }
}