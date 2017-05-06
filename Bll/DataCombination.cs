using System.Text;
using System;
using System.Collections.Generic;
using Model;

namespace Bll
{
    public struct DistanceParameterContent
    {
        public string CardNumber;
        public TypeParameter? Type;
        public FunctionByteParameter? Function;
        public int Count;
    }

    public struct TypeParameter
    {
        public int Lock;
        public int Distance;
    }

    public struct CardDataParameter
    {
        public string ViceCard;
        public DateTime Time;
        public int Partition;
        public int Count;
    }

    public struct SingleCardData
    {
        public DateTime Time;
        public int Partition;
    }

    public struct ViceCardData
    {
        public string ViceNumber;
        public DateTime Time;
        public int Partition;
        public int Count;
    }

    public struct PlateCardData
    {
        public string Plate;
        public DateTime Time;
        public int Partition;
    }

    public struct LossParameter
    {
        public string CardNumber;
        public DateTime Time;
        public FunctionByteParameter? Function;
    }

    public class DataCombination
    {

        public static byte[] CombinationDistanceCard(DistanceParameterContent parameter, SingleCardData? data)
        {

            int start = 0;
            int type = SetTypeParameter(parameter, data);
            int function = SetFunctionParameeter(parameter.Function.Value);

            StringBuilder sb = new StringBuilder();
            if (function != -1)
                sb.AppendFormat("{0:X2}", function);
            else
                start = 1;
            sb.AppendFormat("{0:X4}", parameter.Count);
            if (data != null)
            {
                sb.AppendFormat("{0:yyMMdd}", data.Value.Time);
                sb.AppendFormat("{0:X4}", data.Value.Partition);
            }
            return PortAgreement.GetDistanceContent(parameter.CardNumber, type, start, sb.ToString());
        }

        public static byte[] CombinationDistanceCard(DistanceParameterContent parameter, List<ViceCardData> data)
        {
            int start = 0;
            int type = SetTypeParameter(parameter, data);
            int function = SetFunctionParameeter(parameter.Function.Value);

            StringBuilder sb = new StringBuilder();
            if (function != -1)
                sb.AppendFormat("{0:X2}", function);
            else
                start = 1;
            sb.AppendFormat("{0:X4}", parameter.Count);
            if (data != null)
            {
                if (data.Count > 0)
                {
                    foreach (ViceCardData item in data)
                    {
                        sb.AppendFormat("{0:yyMMdd}", item.Time);
                        sb.AppendFormat("{0:X4}", item.Partition);
                        sb.AppendFormat("{0:X4}", item.Count);
                        sb.Append(item.ViceNumber);
                    }
                }
                else
                {
                    sb.Append("FFFFFFFFFFFFFFFFFFFFFFFFFF");
                }
            }
            return PortAgreement.GetDistanceContent(parameter.CardNumber, type, start, sb.ToString());
        }

        public static byte[] CombinationDistanceCard(DistanceParameterContent parameter, List<PlateCardData> data)
        {
            int start = 0;
            int type = SetTypeParameter(parameter, data);
            int function = SetFunctionParameeter(parameter.Function.Value);

            StringBuilder sb = new StringBuilder();
            if (function != -1)
                sb.AppendFormat("{0:X2}", function);
            else
                start = 1;
            sb.AppendFormat("{0:X4}", parameter.Count);
            if (data != null)
            {
                if (data.Count > 0)
                {
                    foreach (PlateCardData item in data)
                    {
                        sb.AppendFormat("{0:yyMMdd}", item.Time);
                        sb.AppendFormat("{0:X4}", item.Partition);
                        sb.Append(GetLprNumber(item.Plate));
                    }
                }
                else
                {
                    sb.Append("FFFFFFFFFFFFFFFFFFFFFFFFFF");
                }
            }
            return PortAgreement.GetDistanceContent(parameter.CardNumber, type, start, sb.ToString());
        }


        public static byte[] CombinationLoss(List<LossParameter> lossparams)
        {
            int index = 0;
            int losstype = 87381;
            StringBuilder sb = new StringBuilder();
            foreach (LossParameter item in lossparams)
            {
                losstype = BinaryHelper.SetIntegeSomeBit(losstype, index, true);
                index += 2;
                sb.Append(item.CardNumber);
                sb.AppendFormat("{0:X2}", SetFunctionParameeter(item.Function));
                sb.AppendFormat("{0:yyMM}", item.Time.AddDays(1));
            }
            string content = string.Format("{0:X2}{1:X6}{2}", lossparams.Count, losstype, sb.ToString());
            return PortAgreement.GetLossContent("797979", content);
        }

        /// <summary>
        /// 将车牌号的汉字转成编号
        /// </summary>
        /// <param name="lprnumber"></param>
        private static string GetLprNumber(string lprnumber)
        {
            StringBuilder sb = new StringBuilder();
            int index = 0;
            lprnumber = lprnumber.PadRight(8, '~');
            if (lprnumber[0] == 'W' && lprnumber[1] == 'J')
            {
                if (lprnumber.Length != 7)
                {
                    sb.AppendFormat("{0:X2}", 36);
                    index = 2;
                }
            }
            for (int a = index; a < lprnumber.Length; a++)
            {
                if (CRegex.GetChinese(lprnumber[a].ToString()))
                {
                    PlateProvinces.Provinces lpr = (PlateProvinces.Provinces)Enum.Parse(typeof(PlateProvinces.Provinces), lprnumber[a].ToString());
                    int str = (int)lpr;
                    sb.AppendFormat("{0:X2}", str);
                }
                else
                {
                    sb.AppendFormat("{0:X2}", Encoding.ASCII.GetBytes(lprnumber[a].ToString())[0]);
                }
            }
            return sb.ToString();
        }

        private static int SetFunctionParameeter(FunctionByteParameter? parameter)
        {
            int functionbyte = 0;
            if (parameter == null) return -1;
            functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 7, parameter.Value.Loss != 0);
            functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 6, parameter.Value.Synchronous != 0);
            if (parameter.Value.RegistrationType == CardType.SingleCard)
            {
                functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 5, true);
                functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 1, false);
            }
            else if (parameter.Value.RegistrationType == CardType.CombinationCard)
            {
                functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 5, false);
                functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 1, false);
            }
            else
            {
                functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 1, true);
                functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 5, false);
            }
            functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 4, parameter.Value.ParkingRestrictions != 0);
            for (int i = 0; i < 2; i++)
            {
                int vicecountbinary = BinaryHelper.GetIntegerSomeBit(parameter.Value.ViceCardCount - 1, i);
                functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 3 - i, vicecountbinary != 0);
            }
            functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 0, parameter.Value.InOutState != 0);
            return functionbyte;
        }

        private static int SetTypeParameter(DistanceParameterContent parameter, object obj)
        {
            int type = 0;
            if (parameter.Type != null)
            {
                type = 1;
                if (parameter.Function != null || obj != null)
                    type = 2;
                type = BinaryHelper.SetIntegeSomeBit(type, 7, parameter.Type.Value.Lock != 0);
                if (parameter.Type.Value.Distance > 0)
                {
                    type = BinaryHelper.SetIntegeSomeBit(type, 6, true);
                    for (int i = 0; i < 2; i++)
                    {
                        int distancebinary = BinaryHelper.GetIntegerSomeBit(parameter.Type.Value.Distance - 1, i);
                        type = BinaryHelper.SetIntegeSomeBit(type, 5 - i, distancebinary != 0);
                    }
                }
                else
                {
                    type = BinaryHelper.SetIntegeSomeBit(type, 6, false);
                }

            }
            return type;
        }

        public static int SetCount(int count)
        {
            int newcount = count;
            if (count > 65530)
            {
                newcount = 2;
            }
            if (count < 2)
            {
                newcount = 2;
            }
            return ++newcount;
        }
    }
}