using System;

namespace Bll
{
    public struct ParsingParameter
    {
        public byte FunctionAddress;
        public byte DeviceAddress;
        public byte Command;
        public byte[] DataContent;
    }

    public class DataParsing
    {
        public static ParsingParameter ParsingContent(byte[] by)
        {
            ParsingParameter parameter = new ParsingParameter();
            parameter.FunctionAddress = by[1];
            parameter.DeviceAddress = (byte)HexadecimalConversion.HexToInt(by[2], by[3]);
            parameter.Command = (byte)HexadecimalConversion.HexToInt(by[4], by[5]);
            byte[] newby = new byte[by.Length - 9];
            if (newby.Length > 0)
                Array.Copy(by, 6, newby, 0, by.Length - 3);
            parameter.DataContent = newby;
            return parameter;
        }
    }
}