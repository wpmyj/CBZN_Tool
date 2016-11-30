using System.Collections.Generic;

namespace Bll
{
    public class DealHandler
    {
        public int Head { get; set; }

        public int End { get; set; }

        public int FunctionAddress { get; set; }

        public int DeviceAddress { get; set; }

        public int Command { get; set; }

        public byte[] Integration()
        {
            return Integration(null);
        }

        public byte[] Integration(byte[] datacontent)
        {
            List<byte> bylist = new List<byte>();
            bylist.Add((byte)Head);
            bylist.Add((byte)FunctionAddress);
            bylist.AddRange(HexadecimalConversion.IntToAscii(DeviceAddress));
            bylist.AddRange(HexadecimalConversion.IntToAscii(Command));
            if (datacontent != null)
                bylist.AddRange(datacontent);
            int xor = DataValidation.Xor(bylist);
            bylist.AddRange(HexadecimalConversion.IntToAscii(xor));
            bylist.Add((byte)End);
            return bylist.ToArray();
        }
    }
}