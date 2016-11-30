using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Bll
{
    public class HexadecimalConversion
    {
        public static string IntToHex(int dec)
        {
            if (dec < 0)
                throw new ArgumentOutOfRangeException(@"value值超于数值范围。");
            return string.Format("{0:X2}", dec);
        }

        public static string BinaryToHex(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException();
            }
            if (!CRegex.IsBinary(str))
            {
                throw new ArgumentException();
            }
            return string.Format("{0:X2}", Convert.ToInt32(str, 2));
        }

        public static string IntToBinary(int dec)
        {
            if (dec < 0)
                throw new ArgumentOutOfRangeException(@"value值超于数值范围。");
            return Convert.ToString(dec, 2).PadLeft(8, '0');
        }

        public static string HexToBinary(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException();
            }
            if (!CRegex.IsHex(str))
            {
                throw new ArgumentException();
            }
            int value = Convert.ToInt32(str, 16);
            return Convert.ToString(value, 2).PadLeft(8, '0');
        }

        public static int StrToInt(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException();
            }
            if (!CRegex.IsDecimal(str))
            {
                throw new ArgumentException();
            }
            return Convert.ToInt32(str);
        }

        public static int ObjToInt(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            return StrToInt(obj.ToString());
        }

        public static int HexToInt(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException();
            }
            if (!CRegex.IsHex(str))
            {
                throw new ArgumentException();
            }
            return Convert.ToInt32(str, 16);
        }

        public static int BinaryToInt(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException();
            }
            if (!CRegex.IsBinary(str))
            {
                throw new ArgumentException();
            }
            return Convert.ToInt32(str, 2);
        }

        public static byte[] IntToAscii(int dec)
        {
            byte[] by = new byte[2];
            int division = dec / 16;
            int mod = dec % 16;
            by[0] = (byte)GetAscii(division);
            by[1] = (byte)GetAscii(mod);
            return by;
        }

        private static int GetAscii(int dec)
        {
            if (dec <= 9)
                dec += 48;
            else if (dec <= 15)
                dec += 55;
            return dec;
        }

        public static int AsciiToInt(int ascii)
        {
            if (ascii >= 48 && ascii <= 57)
            {
                ascii -= 48;
            }
            else if (ascii >= 65 && ascii <= 90)
            {
                ascii -= 55;
            }
            else if (ascii >= 97 && ascii <= 122)
            {
                ascii -= 87;
            }
            return ascii;
        }

        public static int HexToInt(int hex1, int hex2)
        {
            hex1 = AsciiToInt(hex1);
            hex2 = AsciiToInt(hex2);
            int division = hex1 * 16;
            int mod = hex2 % 16;
            return division + mod;
        }

        public static int HexToInt(int hex1, int hex2, int hex3, int hex4)
        {
            int value1 = HexToInt(hex1, hex2);
            int value2 = HexToInt(hex3, hex4);
            return (value1 * 256) + (value2 % 256);
        }
    }
}
