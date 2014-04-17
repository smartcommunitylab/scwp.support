using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models.MobilityService
{
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
