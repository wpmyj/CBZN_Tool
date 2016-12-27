using System;
using System.Collections.Generic;
using System.Text;

namespace Bll
{
    public class PortAgreement
    {

        public static byte[] GetDistanceEncryption(string pwd)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 65,
                Command = 0
            };
            byte[] by = Encoding.ASCII.GetBytes(string.Format("A000010000009887{0}", pwd));
            return dh.Integration(by);
        }

        public static byte[] GetDistanceCardEncryption(string pwd)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 65,
                Command = 0
            };
            byte[] by = Encoding.ASCII.GetBytes(string.Format("0D0000000000010000{0}", pwd));
            return dh.Integration(by);
        }

        public static byte[] GetReadAllCard()
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 65,
                Command = 0
            };
            byte[] by = Encoding.ASCII.GetBytes("0A8000000000010003");
            return dh.Integration(by);
        }

        public static byte[] GetReadSomeCard(string cardnumber)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 65,
                Command = 0
            };
            byte[] by = Encoding.ASCII.GetBytes("1A00" + cardnumber + "00010003");
            return dh.Integration(by);
        }

        public static byte[] GetDistanceContent(string cardnumber, int type, int start, string data)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 65,
                Command = 0
            };
            byte[] by = Encoding.ASCII.GetBytes(string.Format("1B00{0}{1:X2}01{2:X2}{3:X2}{4}", cardnumber, type, start, data.Length / 2, data));
            return dh.Integration(by);
        }

        public static byte[] GetLossContent(string cardnumber, string content)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 65,
                Command = 0
            };
            byte[] by = Encoding.ASCII.GetBytes(string.Format("1B00{0}000100{1:X2}{2}", cardnumber, content.Length / 2, content));
            return dh.Integration(by);
        }

        public static byte[] GetTemporaryEncryption(string pwd)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 66,
                Command = 221
            };
            byte[] by = Encoding.ASCII.GetBytes("FFFF" + pwd);
            return dh.Integration(by);
        }

        public static byte[] GetTemporaryICEncryption(string pwd)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 66,
                Command = 204
            };
            byte[] by = Encoding.ASCII.GetBytes("FFFF" + pwd);
            return dh.Integration(by);
        }

        public static byte[] GetReadTemporaryIC()
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                FunctionAddress = 66,
                DeviceAddress = 0,
                Command = 9
            };
            return dh.Integration();
        }

        public static byte[] GetOpenModule()
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 67,
                Command = 209
            };
            return dh.Integration();
        }

        public static byte[] GetCloseModule()
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 67,
                Command = 210
            };
            return dh.Integration();
        }

        public static byte[] GetSetModule(string content)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                FunctionAddress = 67,
                DeviceAddress = 0,
                Command = 208
            };
            byte[] by = Encoding.ASCII.GetBytes(content);
            return dh.Integration(by);
        }

        public static byte[] GetOpenDoor(string content)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 67,
                Command = 17
            };
            byte[] by = Encoding.Default.GetBytes(content);
            return dh.Integration(by);
        }

        public static byte[] GetClientNumber(int number)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 1,
                FunctionAddress = 51,
                Command = 160
            };
            byte[] by = Encoding.Default.GetBytes("123456" + number.ToString().PadLeft(4, '0'));
            return dh.Integration(by);
        }

        public static byte[] GetSearchHost(int number)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                FunctionAddress = 49,
                DeviceAddress = number,
                Command = 0
            };
            return dh.Integration();
        }
    }
}
