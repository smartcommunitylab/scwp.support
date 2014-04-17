using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationLibrary
{
  public static class QueryHelper
  {
    public static string DictionaryToPostData(Dictionary<string, string> dict)
    {
      StringBuilder QueryBuilder = new StringBuilder();

      foreach (var Param in dict)
      {
        QueryBuilder.Append((string.Format("{0}={1}&", Param.Key, Param.Value)));
      }

      return QueryBuilder.ToString();

      
    }


    public static string DictionaryToQuery(Dictionary<string, string> dict)
    {
      if (dict.Count == 0)
        return "";

      StringBuilder QueryBuilder = new StringBuilder();

      foreach (var Param in dict)
      {
        QueryBuilder.Append(Uri.EscapeUriString(string.Format("{0}={1}&", Param.Key, Param.Value)));
      }

      return  QueryBuilder.ToString();

    }

    public static Dictionary<string, string> QueryToDictionary(string queryString)
    {
      if (queryString == "")
        return null;

      queryString = queryString.StartsWith("?") ? queryString.Remove(0, 1) : queryString;

      Dictionary<string, string> QueryDict = new Dictionary<string, string>();
      string[] QueryTmpArray = queryString.Split('&');
      foreach (string Param in QueryTmpArray)
      {
        string[] KeyValStr = Param.Split('=');
        KeyValuePair<string, string> ParamForDict = new KeyValuePair<string, string>(KeyValStr[0], KeyValStr[1]);
      }
      return QueryDict;
    }
  }
}
