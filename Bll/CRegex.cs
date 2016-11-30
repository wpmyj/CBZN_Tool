using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;

namespace Bll
{
    public class CRegex
    {
        public static bool IsDecimal(object obj)
        {
            return obj != null && IsDecimal(obj.ToString());
        }

        public static bool IsDecimal(string str)
        {
            return Regex.IsMatch(str, @"^\d$");
        }

        public static bool IsHex(object obj)
        {
            return obj != null && IsHex(obj.ToString());
        }

        public static bool IsHex(string str)
        {
            return Regex.IsMatch(str, @"^\d[A-F][a-f]$");
        }

        public static bool IsBinary(object obj)
        {
            return obj != null && IsBinary(obj.ToString());
        }

        public static bool IsBinary(string str)
        {
            return Regex.IsMatch(str, @"^[0-1]$");
        }
    }
}