using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TerritoryInformationServiceLibrary
{
  public class TerritoryInformationLibrary
  {
    HttpClient httpCli;
    string accessToken;

    public TerritoryInformationLibrary(string accessToken)
    {
      this.accessToken = accessToken;
      httpCli = new HttpClient();
    }
  }
}
