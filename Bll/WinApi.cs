using System;
using System.Runtime.InteropServices;


namespace Bll
{
    public class WinApi
    {
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        /// <summary>
        /// 波特率
        /// </summary>
        public enum BaudRate
        {
            BaudRate9600 = 0x0C,
            BaudRate19200 = 0x0D,
            BaudRate38400 = 0x0E
        }

        /// <summary>
        /// 停止位
        /// </summary>
        public enum StopBit
        {
            StopBit0 = 0x00,
        }

        /// <summary>
        /// 数据位
        /// </summary>
        public enum DataBit
        {
            DataBit8 = 0x03,
        }

        /// <summary>
        /// 检验位
        /// </summary>
        public enum Parity
        {
            ParityN = 0x00,
            ParityE = 0x18,
        }

        /// <summary>
        /// 错误枚举
        /// </summary>
        public enum ErrorCode
        {
            /// <summary>
            /// 正确
            /// </summary>
            SIO_OK = 0,
            /// <summary>
            /// 没有此端口或端口未打开
            /// </summary>
            SIO_BADPORT = -1,
            /// <summary>
            /// 无法控制此板
            /// </summary>
            SIO_OUTCONTROL = -2,
            /// <summary>
            /// 没有数据代读取或没有缓冲区供写
            /// </summary>
            SIO_NODATA = -4,
            /// <summary>
            /// 没有此端口或端口已打开
            /// </summary>
            SIO_OPENFAIL = -5,
            /// <summary>
            /// 因为H/W流量控制而不能设置
            /// </summary>
            SIO_RTS_BY_HW = -6,
            /// <summary>
            /// 无效参数
            /// </summary>
            SIO_BADPARM = -7,
            /// <summary>
            /// 调用win32函数失败请调用GetLastError函数以获取错误代码
            /// </summary>
            SIO_WIN32FAIL = -8,
            /// <summary>
            /// 此版本不支持这个函数
            /// </summary>
            SIO_BOARDNOTSUPPORT = -9,
            /// <summary>
            /// PCOMM函数运行结果失败
            /// </summary>
            SIO_FAIL = -10,
            /// <summary>
            /// 写入已被锁定，用户已放弃写入
            /// </summary>
            SIO_ABORT_WRITE = -11,
            /// <summary>
            /// 已发生写入超时
            /// </summary>
            SIO_WRITETIMEOUT = -12,
        }


        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        /// <summary>
        /// 打开端口
        /// </summary>
        /// <param name="portname">端口的编号（1 2 3）</param>
        /// <returns></returns>
        [DllImport("pcomm.dll")]
        public static extern int sio_open(int portname);

        /// <summary>
        /// 设置 波特率 数据位 停止位 模式
        /// </summary>
        /// <param name="portname">端口的编号</param>
        /// <param name="baudrate">波特率</param>
        /// <param name="mode">数据位 停止位 模式</param>
        /// <returns></returns>
        [DllImport("pcomm.dll")]
        public static extern int sio_ioctl(int portname, int baudrate, int mode);
        /// <summary>
        /// 关闭端口
        /// </summary>
        /// <param name="portname">端口的编号</param>
        /// <returns></returns>
        [DllImport("pcomm.dll")]
        public static extern int sio_close(int portname);
        /// <summary>
        /// 读取缓冲区的数据
        /// </summary>
        /// <param name="portname">端口的编号</param>
        /// <param name="data">数据集</param>
        /// <param name="len">数据集长度</param>
        /// <returns></returns>
        [DllImport("pcomm.dll")]
        public static extern int sio_read(int portname, byte[] data, int len);
        /// <summary>
        /// 清除缓冲区的数据
        /// </summary>
        /// <param name="portname">端口的编号</param>
        /// <param name="index">2 清除读写缓冲区的数据</param>
        /// <returns></returns>
        [DllImport("pcomm.dll")]
        public static extern int sio_flush(int portname, int index);
        /// <summary>
        /// 向缓冲区写入数据
        /// </summary>
        /// <param name="portname">端口的编号</param>
        /// <param name="by">数据集</param>
        /// <param name="len">数据集长度</param>
        /// <returns></returns>
        [DllImport("pcomm.dll")]
        public static extern int sio_write(int portname, byte[] by, int len);
        /// <summary>
        /// 获取缓冲区的数据长度
        /// </summary>
        /// <param name="portname">端口的编号</param>
        /// <returns></returns>
        [DllImport("pcomm.dll")]
        public static extern int sio_iqueue(int portname);

        /// <summary>
        /// 设置串口写操作的超时
        /// </summary>
        /// <param name="port">端口的编号</param>
        /// <param name="TotalTimeouts">超时时间</param>
        /// <returns></returns>
        [DllImport("pcomm.dll")]
        public static extern int sio_SetWriteTimeouts(int port, int TotalTimeouts);

        /// <summary>
        /// 当端口接收到一个字体的数据时的回调方法
        /// </summary>
        /// <param name="portname">端口的编号</param>
        /// <param name="function">回调方法</param>
        /// <param name="count">1</param>
        /// <returns></returns>
        [DllImport("pcomm.dll")]
        public static extern int sio_cnt_irq(int portname, DataReceivedHandler function, int count);

        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="portname"></param>
        public delegate void DataReceivedHandler(int port);

    }
}