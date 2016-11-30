using System;
using System.Text;

namespace Bll
{
    public struct ParsingParameter
    {
        public byte FunctionAddress;
        public byte DeviceAddress;
        public byte Command;
        public byte[] DataContent;
    }

    public struct DistanceParameter
    {
        public int Command;
        public int AuxiliaryCommand;
        public string CardNumber;
        public int Type;
        public DistanceTypeParameter TypeParameter;
    }

    public struct DistanceTypeParameter
    {
        public int Lock;
        public int Distance;
        public int Battry;
        public CardType CardType;
    }

    public enum CardType
    {
        /// <summary>
        /// 单卡
        /// </summary>
        SingleCard = 0,
        /// <summary>
        /// 组合卡
        /// </summary>
        CombinationCard = 1,
        /// <summary>
        /// 车牌识别卡
        /// </summary>
        LPRCard = 2,
        /// <summary>
        /// 副卡
        /// </summary>
        ViceCard = 3,
        /// <summary>
        /// 注销卡
        /// </summary>
        CancellationCard = 8,
        /// <summary>
        /// 卡片密码错误
        /// </summary>
        PasswordMistake = 15,
    }

    public struct DistanceDataParameter
    {
        public int FunctionByte;
        public FunctionByteParameter FunctionByteParameter;
        public int Count;
    }

    public struct FunctionByteParameter
    {
        public int Loss;
        public int Synchronous;
        public CardType RegistrationType;
        public int ParkingRestrictions;
        public int ViceCardCount;
        public int InOutState;
    }

    public struct IcCardParameter
    {
        public string IcNumber;
        public string Plate;
        public string Time;
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
                Array.Copy(by, 6, newby, 0, newby.Length);
            parameter.DataContent = newby;
            return parameter;
        }

        public static DistanceParameter DistanceParsingContent(byte[] by)
        {
            DistanceParameter parameter = new DistanceParameter();
            parameter.Command = HexadecimalConversion.HexToInt(by[0], by[1]);
            parameter.AuxiliaryCommand = HexadecimalConversion.HexToInt(by[2], by[3]);
            if (parameter.AuxiliaryCommand != 8)
            {
                if (parameter.Command == 10 || parameter.Command == 11 || parameter.Command == 13 || parameter.Command == 26 || parameter.Command == 27)
                {
                    parameter.CardNumber = Encoding.ASCII.GetString(by, 4, 6);
                    if (parameter.Command == 10 || parameter.Command == 26)
                    {
                        parameter.Type = HexadecimalConversion.HexToInt(by[10], by[11]);
                        parameter.TypeParameter = DistanceType(parameter.Type);
                    }
                }
            }
            return parameter;
        }

        public static DistanceTypeParameter DistanceType(int type)
        {
            DistanceTypeParameter parameter = new DistanceTypeParameter();
            parameter.Battry = BinaryHelper.GetIntegerSomeBit(type, 3);
            int cardtype = BinaryHelper.GetBitToInt(type, 0, 3);
            if (cardtype == 0)
            {
                cardtype = BinaryHelper.GetBitToInt(type, 4, 4);
                parameter.CardType = (CardType)(cardtype += 1);
            }
            else
            {
                if (cardtype == 1 || cardtype == 5)
                    parameter.CardType = (CardType)0;
                else if (cardtype == 2)
                    parameter.CardType = (CardType)1;
                else if (cardtype == 3 || cardtype == 7)
                    parameter.CardType = (CardType)3;
            }
            parameter.Lock = BinaryHelper.GetIntegerSomeBit(type, 7);
            parameter.Distance = BinaryHelper.GetIntegerSomeBit(type, 6);
            if (parameter.Distance == 1)
            {
                parameter.Distance = BinaryHelper.GetBitToInt(type, 4, 2);
                parameter.Distance += 1;
            }
            return parameter;
        }

        public static DistanceDataParameter DistanceData(byte[] by)
        {
            DistanceDataParameter parameter = new DistanceDataParameter();
            parameter.FunctionByte = HexadecimalConversion.HexToInt(by[18], by[19]);
            parameter.FunctionByteParameter = DistanceFunctionByte(parameter.FunctionByte);
            parameter.Count = HexadecimalConversion.HexToInt(by[20], by[21], by[22], by[23]);
            return parameter;
        }

        public static FunctionByteParameter DistanceFunctionByte(int functionbyte)
        {
            FunctionByteParameter parameter = new FunctionByteParameter();
            parameter.Loss = BinaryHelper.GetIntegerSomeBit(functionbyte, 7);
            parameter.Synchronous = BinaryHelper.GetIntegerSomeBit(functionbyte, 6);
            int registrationtype = BinaryHelper.GetIntegerSomeBit(functionbyte, 5);
            if (registrationtype == 0)
            {
                parameter.RegistrationType = BinaryHelper.GetIntegerSomeBit(functionbyte, 1) == 1 ? CardType.LPRCard : CardType.CombinationCard;
            }
            else
            {
                parameter.RegistrationType = CardType.SingleCard;
            }
            parameter.ParkingRestrictions = BinaryHelper.GetIntegerSomeBit(functionbyte, 4);
            parameter.ViceCardCount = BinaryHelper.GetBitToInt(functionbyte, 2, 2);
            parameter.InOutState = BinaryHelper.GetIntegerSomeBit(functionbyte, 0);
            return parameter;
        }

        public static long TemporaryContent(byte[] by)
        {
            if (by.Length == 1 || by.Length == 3)
                return by[0];
            if (@by.Length == 2)
                return HexadecimalConversion.HexToInt(@by[0], @by[1]);
            if (@by.Length == 15)
                return HexadecimalConversion.HexToInt(@by[11], @by[12]);
            if (@by.Length == 22)
            {
                string str = Encoding.ASCII.GetString(@by);
                int index = str.LastIndexOf("0x", StringComparison.Ordinal);
                str = str.Substring(index + 4, 8);
                return Convert.ToInt32(str, 16);
            }
            return -1;
        }

        public static IcCardParameter TemporaryIcCardContent(byte[] by)
        {
            IcCardParameter parameter = new IcCardParameter();
            if (by.Length < 30) return parameter;
            parameter.IcNumber = Encoding.ASCII.GetString(by, 0, 8);
            string plate = Encoding.Default.GetString(by, 8, 10);
            parameter.Plate = CRegex.IsPlate(plate) ? plate : GetHexStr(@by, 8, 10);
            string time = Encoding.Default.GetString(by, 18, 12);
            parameter.Time = CRegex.IsTime(time) ? DateTime.ParseExact(time, "yyMMddHHmmss", System.Globalization.CultureInfo.InstalledUICulture).ToString() : GetHexStr(@by, 18, 12);
            return parameter;
        }

        private static string GetHexStr(byte[] by, int index, int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.AppendFormat("{0:X2}", by[index + i]);
            }
            return sb.ToString();
        }
    }
}