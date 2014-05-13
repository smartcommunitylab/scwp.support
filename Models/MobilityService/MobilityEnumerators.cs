using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService
{
  public enum AgencyType
  {
    [EnumMember(Value="")]
    Null,
    [EnumMember(Value = "null")]
    FakeNull,
    [EnumMember(Value = "12")]
    TrentoCityBus,
    [EnumMember(Value = "10")]
    TrentoMaleRailway,
    [EnumMember(Value = "5")]
    BolzanoVeronaRailway,
    [EnumMember(Value = "6")]
    TrentoBassanoDelGrappaRailway,
    [EnumMember(Value = "16")]
    RoveretoCityBus,
    [EnumMember(Value = "17")]
    TrentinoIntercityBus,
    [EnumMember(Value = "COMUNE_DI_TRENTO")]
    ComuneDiTrento,
    [EnumMember(Value = "COMUNE_DI_ROVERETO")]
    ComuneDiRovereto,
    [EnumMember(Value = "BIKE_SHARING_TRENTO")]
    BikeSharingTrento,
    [EnumMember(Value = "BIKE_SHARING_ROVERETO")]
    BikeSharingRovereto,
    [EnumMember(Value = "CAR_SHARING_SERVICE")]
    CarSharingService,

  };

  public enum RouteType
  {
    [EnumMember(Value = "fastest")]
    Fastest,
    [EnumMember(Value = "healthy")]
    Healthy,
    [EnumMember(Value = "leastWalking")]
    LeastWalking,
    [EnumMember(Value = "leastChanges")]
    LeastChanges,
    [EnumMember(Value = "greenest")]
    Greenest,
    [EnumMember(Value = "safest")]
    Safest
  };

  public enum TransportType
  {
    [EnumMember(Value = "CAR")]
    Car,
    [EnumMember(Value = "BICYCLE")]
    Bicycle,
    [EnumMember(Value = "TRANSIT")]
    Transit,
    [EnumMember(Value = "SHAREDBIKE")]
    SharedBike,
    [EnumMember(Value = "SHAREDBIKE_WITHOUT_STATION")]
    SharedBikeWithoutStation,
    [EnumMember(Value = "CARWITHPARKING")]
    CarWithParking,
    [EnumMember(Value = "SHAREDCAR")]
    SharedCar,
    [EnumMember(Value = "SHAREDCAR_WITHOUT_STATION")]
    SharedCarWithoutStation,
    [EnumMember(Value = "BUS")]
    Bus,
    [EnumMember(Value = "TRAIN")]
    Train,
    [EnumMember(Value = "WALK")]
    Walk,
    [EnumMember(Value = "SHUTTLE")]
    Shuttle,
    [EnumMember(Value = "GONDOLA")]
    Gondola
  };

  public enum ChangeType
  {
    [EnumMember(Value = "ROAD_BLOCK")]
    RoadBlock,
    [EnumMember(Value = "PARKING_BLOCK")]
    ParkingBlock,
    [EnumMember(Value = "DRIVE_CHANGE")]
    DriveChange,
    [EnumMember(Value = "OTHER")]
    Other
  };
  public enum AlertType
  {
    [EnumMember(Value = "DELAY")]
    Delay,
    [EnumMember(Value = "ACCIDENT")]
    Accident,
    [EnumMember(Value = "ROAD")]
    Road,
    [EnumMember(Value = "STRIKE")]
    Strike,
    [EnumMember(Value = "PARKING")]
    Parking,
    [EnumMember(Value = "CUSTOM")]
    Custom
  };
  public enum CreatorType
  {
    [EnumMember(Value = "USER")]
    User,
    [EnumMember(Value = "SERVICE")]
    Service
  };


}
