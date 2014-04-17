using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilityServiceLibrary
{
  public class RealTimeUpdateUriHelper
  {
    static string BaseUrl = "https://vas-dev.smartcampuslab.it/core.mobility";
    static string UserAlert = "alert/user";
    
    public static Uri GetSignalUri()
    {
      UriBuilder ub = new UriBuilder(string.Format("{0}/{1}", BaseUrl, UserAlert));
      return ub.Uri;
    }
  }
}
