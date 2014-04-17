using CommonHelpers;
using Models.MobilityService;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;


namespace MobilityServiceLibrary
{
    public static class PublicTransportUriHelper
    {
        static string BaseUrl = "https://vas-dev.smartcampuslab.it/core.mobility";
        static string GetRoutes = "getroutes";
        static string GetStops = "getstops";
        static string GetTimetable = "gettimetable";
        static string GetLimitedTimetable = "getlimitedtimetable";
        static string GetTransitTimes = "gettransittimes";
        static string GetTransitDelays = "gettransitdelays";
        static string GetParkingsByAgency = "getparkingsbyagency";
        static string GetRoadInfoByAgency = "getroadinfobyagency";



        public static Uri GetRoutesUri(AgencyType agencyId)
        {
            UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", BaseUrl, GetRoutes, EnumConverter.ToEnumString<AgencyType>(agencyId)));
            return ub.Uri;
        }

        public static Uri GetStopsUri(AgencyType agencyId, string routeId)
        {
            UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}", BaseUrl, GetStops, EnumConverter.ToEnumString<AgencyType>(agencyId), routeId));
            return ub.Uri;
        }

        public static Uri GetTimetableUri(AgencyType agencyId, string routeId, string stopId)
        {
            UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}", BaseUrl, GetTimetable, EnumConverter.ToEnumString<AgencyType>(agencyId), routeId, stopId));
            return ub.Uri;
        }

        public static Uri GetLimitedTimetableUri(AgencyType agencyId, string stopId, int numberOfResult)
        {
            UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}", BaseUrl, GetLimitedTimetable, EnumConverter.ToEnumString<AgencyType>(agencyId), stopId, numberOfResult));
            return ub.Uri;
        }

        public static Uri GetTransitTimesUri(string routeId, int timeFrom, int timeTo)
        {
            UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}", BaseUrl, GetTransitTimes, routeId, timeFrom, timeTo));
            return ub.Uri;
        }
        public static Uri GetTransitDelaysUri(string routeId, int timeFrom, int timeTo)
        {
            UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}/{3}/{4}", BaseUrl, GetTransitDelays, routeId, timeFrom, timeTo));
            return ub.Uri;
        }

        public static Uri GetParkingsByAgencyUri(AgencyType agencyId)
        {
            UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", BaseUrl, GetParkingsByAgency, EnumConverter.ToEnumString<AgencyType>(agencyId)));
            return ub.Uri;
        }

        //not sure about this one
        public static Uri GetRoadInfoByAgencyUri(AgencyType agencyId, int timeFrom)
        {
            UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", BaseUrl, GetRoadInfoByAgency, EnumConverter.ToEnumString<AgencyType>(agencyId), timeFrom));
            return ub.Uri;
        }

    }
}
