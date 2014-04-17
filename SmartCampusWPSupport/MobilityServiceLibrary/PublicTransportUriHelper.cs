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
        static string BaseUrl = "https://vas-dev.smartcampuslab.it/core.mobility/";
        static string GetRoutes = "getroutes";
        static string GetStops = "getstops";
        static string GetTimetable = "gettimetable";
        


        public static Uri GetRoutesUri(string agencyId)
        {
            UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", BaseUrl, GetRoutes, agencyId));
            return ub.Uri;
        }

        public static Uri GetStopsUri(string agencyId, string routeId)
        {
            UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", BaseUrl, GetStops, agencyId, routeId));
            return ub.Uri;
        }

        public static Uri GetTimetableUri(string agencyId, string routeId, string stopId)
        {
            UriBuilder ub = new UriBuilder(string.Format("{0}/{1}/{2}", BaseUrl, GetTimetable, agencyId, routeId, stopId));
            return ub.Uri;
        }


    }
}
