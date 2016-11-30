using System;
namespace Bll
{
    public class BinaryHelper
    {
        /// <summary>
        /// 取整数的某一位
        /// </summary>
        /// <param name="num">整数</param>
        /// <param name="mask">要取的位置索引，自右至左为0-7</param>
        /// <returns></returns>
        public static int GetIntegerSomeBit(int num, int mask)
        {
            return num >> mask & 1;
        }

        /// <summary>
        /// 将整数的某位置为0或1
        /// </summary>
        /// <param name="num">整数</param>
        /// <param name="mask">整数的某位</param>
        /// <param name="flag">是否置1，True表示置1，Flase表示置0</param>
        public static int SetIntegeSomeBit(int num, int mask, bool flag)
        {
            if (flag)
            {
                num |= (0x1 << mask);
            }
            else
            {
                num &= ~(0x1 << mask);
            }
            return num;
        }

        public static int GetBitToInt(int num, int index, int count)
        {
            int value = 0;
            for (int i = 0; i < count; i++)
            {
                value += (GetIntegerSomeBit(num, index + i) * (int)Math.Pow(2, i));
            }
            return value;
        }
    }
}