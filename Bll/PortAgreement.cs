﻿using System;
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

        public static byte[] GetDistanceWrite(string cardnumber, int type, int start, int count, string data)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 65,
                Command = 0
            };
            byte[] by = Encoding.ASCII.GetBytes(string.Format("1B00{0}{1:X2}01{2:X2}{3:X2}{4}", cardnumber, type, start, count, data));
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
                Command = 208
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
                Command = 207
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
                Command = 16
            };
            byte[] by = Encoding.Default.GetBytes(content);
            return dh.Integration(by);
        }

    }
}