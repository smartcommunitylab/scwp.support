using System;
using System.Linq;
using System.Runtime.Serialization;


namespace CommonHelpers
{
  /// <summary>
  /// Class that allow to convert an enumerator value to a string and vice-versa
  /// </summary>
  public static class EnumConverter
  {
    /// <summary>
    /// Retrieve the string corresponding to the enum value for the given type
    /// </summary>
    /// <typeparam name="T">Enumerator's type</typeparam>
    /// <param name="type">Enumerator's value</param>
    /// <returns></returns>
    public static string ToEnumString<T>(T type)
    {
      var enumType = typeof(T);
      var name = Enum.GetName(enumType, type);
      var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
      return enumMemberAttribute.Value;
    }

    /// <summary>
    /// Retrieve the enumerator value corresponding to the specified string for the given type
    /// </summary>
    /// <typeparam name="T">Enumerator's type</typeparam>
    /// <param name="str">String corresponding to an enumerator value</param>
    /// <returns></returns>
    public static T ToEnum<T>(string str)
    {
      var enumType = typeof(T);
      foreach (var name in Enum.GetNames(enumType))
      {
        var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
        if (enumMemberAttribute.Value == str) return (T)Enum.Parse(enumType, name);
      }
      return default(T);
    }
  }
}
