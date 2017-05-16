using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Bll
{
    public class WinApi
    {
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        /// <summary>
        /// 应用程序可以使用SetParent函数来设置弹出式窗口，层叠窗口或子窗口的父窗口。新的窗口与窗口必须属于同一应用程序。
        /// </summary>
        /// <param name="hWndChild">子窗口句柄。</param>
        /// <param name="hWndNewParent">新的父窗口句柄。如果该参数是NULL，则桌面窗口就成为新的父窗口。在WindowsNT5.0中，如果参数为HWND_MESSAGE,则子窗口成为消息窗口。</param>
        /// <returns></returns>
        [DllImport("user32 ")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    }
}
