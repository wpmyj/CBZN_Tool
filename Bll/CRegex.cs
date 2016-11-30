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
            return Regex.IsMatch(str, @"^\d+$");
        }

        public static bool IsHex(object obj)
        {
            return obj != null && IsHex(obj.ToString());
        }

        public static bool IsHex(string str)
        {
            return Regex.IsMatch(str, @"^\d[A-F][a-f]+$");
        }

        public static bool IsBinary(object obj)
        {
            return obj != null && IsBinary(obj.ToString());
        }

        public static bool IsBinary(string str)
        {
            return Regex.IsMatch(str, @"^[0-1]+$");
        }

        /// <summary>
        /// 验证时间
        /// </summary>
        /// <param name="str">yyMMddHHmmss</param>
        /// <returns></returns>
        public static bool IsTime(string str)
        {
            return Regex.IsMatch(str, @"^\d{2}(0[1-9]|1[0-2])(0[1-9]|1\d|2\d|3[0-1])(0[0-9]|1\d|2[0-3])([0-5]\d)([0-5]\d)$");
        }

        public static bool IsPlate(string str)
        {
            return Regex.IsMatch(str, @"^[\u4e00-\u9fa50-9a-zA-Z]{7,10}$");
        }

        public static bool GetChinese(string value)
        {
            return Regex.IsMatch(value, @"[\u4e00-\u9fa5]");
        }
    }
}