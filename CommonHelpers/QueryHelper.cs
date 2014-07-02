using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelpers
{
  /// <summary>
  /// Helper class that allows to convert data from a dictionary to a querystring and vice-versa
  /// </summary>
  public static class QueryHelper
  {
    /// <summary>
    /// Converts a dictionary into an already formatted POST string
    /// </summary>
    /// <param name="dict">The dictionary containing the required POST parameters</param>
    /// <returns>A string to be used as data in a POST operation</returns>
    public static string DictionaryToPostData(Dictionary<string, string> dict)
    {
      StringBuilder queryBuilder = new StringBuilder();

      foreach (var Param in dict)
      {
        queryBuilder.Append((string.Format("{0}={1}&", Param.Key, Param.Value)));
      }

      return queryBuilder.ToString();      
    }

    /// <summary>
    /// Converts a dictionary into an already formatted GET query string
    /// </summary>
    /// <param name="dict">The dictionary containing the required GET parameters</param>
    /// <returns>An already escaped string, redy to be used as a GET querystring</returns>
    public static string DictionaryToQuery(Dictionary<string, string> dict)
    {
      if (dict.Count == 0)
        return "";

      StringBuilder queryBuilder = new StringBuilder();

      foreach (var Param in dict)
      {
        queryBuilder.Append(Uri.EscapeUriString(string.Format("{0}={1}&", Param.Key, Param.Value)));
      }

      return  queryBuilder.ToString();
    }

    /// <summary>
    /// Converts a querystring into a dictionary, allowing for direct access to querystring data.
    /// </summary>
    /// <param name="queryString">The GET querystring, beginning with either '?' or directly with the first parameter</param>
    /// <returns></returns>
    public static Dictionary<string, string> QueryToDictionary(string queryString)
    {
      if (queryString == "")
        return null;

      queryString = queryString.StartsWith("?") ? queryString.Remove(0, 1) : queryString;

      Dictionary<string, string> queryDict = new Dictionary<string, string>();
      string[] queryTmpArray = queryString.Split('&');
      foreach (string Param in queryTmpArray)
      {
        string[] KeyValStr = Param.Split('=');
        KeyValuePair<string, string> ParamForDict = new KeyValuePair<string, string>(KeyValStr[0], KeyValStr[1]);
      }
      return queryDict;
    }
  }
}
