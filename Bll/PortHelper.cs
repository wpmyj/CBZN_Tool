using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.Devices;
using System.Threading;

namespace Bll
{
    public class PortHelper
    {
        public delegate void PortIsOpenChangeHandler(object e, bool value);

        public PortHelper()
        {
        }

        /// <summary>
        /// 端口编号
        /// </summary>
        private int PortIndex = -1;

        private string _portname;
        /// <summary>
        /// 端口号
        /// </summary>
        public string PortName
        {
            get { return _portname; }
            set
            {
                if (_portname != value)
                {
                    _portname = value;
                    PortIndex = Convert.ToInt32(_portname.Replace("COM", ""));
                }
            }
        }

        private PcommApi.BaudRate baudrate = PcommApi.BaudRate.BaudRate19200;
        /// <summary>
        /// 波特率
        /// </summary>
        public PcommApi.BaudRate BaudRate
        {
            get { return baudrate; }
            set { baudrate = value; }
        }

        private PcommApi.DataBit databit = PcommApi.DataBit.DataBit8;
        /// <summary>
        /// 数据位
        /// </summary>
        public PcommApi.DataBit DataBit
        {
            get { return databit; }
            set { databit = value; }
        }

        private PcommApi.StopBit stopbit = PcommApi.StopBit.StopBit0;
        /// <summary>
        /// 停止位
        /// </summary>
        public PcommApi.StopBit StopBit
        {
            get { return stopbit; }
            set { stopbit = value; }
        }

        private PcommApi.Parity parity = PcommApi.Parity.ParityN;
        /// <summary>
        /// 检验位
        /// </summary>
        public PcommApi.Parity Parity
        {
            get { return parity; }
            set { parity = value; }
        }

        private bool isopen;
        /// <summary>
        /// 是否打开端口
        /// </summary>
        public bool IsOpen
        {
            get { return isopen; }
            set
            {
                if (isopen != value)
                {
                    isopen = value;
                    if (PortIsOpenChange != null)
                        PortIsOpenChange(this, isopen);
                }
            }
        }

        private PcommApi.DataReceivedHandler portdatareceived;
        /// <summary>
        /// 接收端口数据的回调方法
        /// </summary>
        public PcommApi.DataReceivedHandler PortDataReceived
        {
            get { return portdatareceived; }
            set { portdatareceived = value; }
        }

        private PortIsOpenChangeHandler portisopenchange;
        /// <summary>
        /// 打开关闭端口发生变化事件
        /// </summary>
        public PortIsOpenChangeHandler PortIsOpenChange
        {
            get { return portisopenchange; }
            set { portisopenchange = value; }
        }

        /// <summary>
        /// 获取缓冲区数据的长度
        /// </summary>
        /// <returns></returns>
        public int GetBytesToRead()
        {
            return PcommApi.sio_iqueue(PortIndex);
        }

        /// <summary>
        /// 打开端口
        /// </summary>
        public void Open()
        {
            try
            {
                if (PortIndex < 0 || PortIndex > 255)
                {
                    throw new ArgumentOutOfRangeException("PortIndex");
                }
                int result = PcommApi.sio_open(PortIndex);
                GetErrorCode(result);
                SetIoctl();
                //result = WinApi.sio_SetWriteTimeouts(PortIndex, 100);
                //GetErrorCode(result);
                if (portdatareceived != null)
                    PcommApi.sio_cnt_irq(PortIndex, portdatareceived, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 读取缓冲区的数据
        /// </summary>
        /// <param name="by">读取的集合</param>
        /// <param name="len">读取的长度</param>
        public void Read(byte[] by, int len)
        {
            try
            {
                int result = PcommApi.sio_read(PortIndex, by, len);
                GetErrorCode(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 写入缓冲区的数据
        /// </summary>
        /// <param name="deal"></param>
        public void Write(string deal)
        {
            try
            {
                byte[] by = new byte[deal.Length / 2];
                int len = 0;
                for (int i = 0; i < by.Length; i++, len += 2)
                {
                    by[i] = Convert.ToByte(deal.Substring(len, 2), 16);
                }
                Write(by, by.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Write(byte[] by)
        {
            Write(by, by.Length);
        }

        /// <summary>
        /// 写入缓冲的数据
        /// </summary>
        /// <param name="by">数组集合</param>
        /// <param name="len">写入的长度</param>
        public void Write(byte[] by, int len)
        {
            try
            {
                int result = PcommApi.sio_write(PortIndex, by, len);
                GetErrorCode(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 关闭端口
        /// </summary>
        public void Close()
        {
            try
            {
                if (PortIndex == -1) return;
                int result = PcommApi.sio_close(PortIndex);
                GetErrorCode(result);
                PortIndex = -1;
                _portname = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 设置端口的参数
        /// </summary>
        public void SetIoctl()
        {
            try
            {
                int result = PcommApi.sio_ioctl(PortIndex, (int)baudrate, (int)databit | (int)stopbit | (int)parity);
                GetErrorCode(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 清空缓冲区数据
        /// </summary>
        /// <param name="func">0清空输入,1清空输出,2清空输入输出</param>
        public void ClearBuffer(int func)
        {
            try
            {
                int result = PcommApi.sio_flush(PortIndex, func);
                GetErrorCode(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 返回错误
        /// </summary>
        /// <param name="value"></param>
        private void GetErrorCode(int value)
        {
            switch ((PcommApi.ErrorCode)value)
            {
                case PcommApi.ErrorCode.SIO_OK:
                    break;
                case PcommApi.ErrorCode.SIO_BADPORT:
                    throw new ArgumentException("没有此端口或端口未打开");
                case PcommApi.ErrorCode.SIO_OUTCONTROL:
                    throw new ArgumentException("无法控制此板");
                case PcommApi.ErrorCode.SIO_NODATA:
                    throw new ArgumentException("没有数据代读取或没有缓冲区供写");
                case PcommApi.ErrorCode.SIO_OPENFAIL:
                    throw new ArgumentException("没有此端口或端口已打开");
                case PcommApi.ErrorCode.SIO_RTS_BY_HW:
                    throw new ArgumentException("因为H/W流量控制而不能设置");
                case PcommApi.ErrorCode.SIO_BADPARM:
                    throw new ArgumentException("无效参数");
                case PcommApi.ErrorCode.SIO_WIN32FAIL:
                    throw new ArgumentException("调用win32函数失败请调用GetLastError函数以获取错误代码");
                case PcommApi.ErrorCode.SIO_BOARDNOTSUPPORT:
                    throw new ArgumentException("此版本不支持这个函数");
                case PcommApi.ErrorCode.SIO_FAIL:
                    throw new ArgumentException("PCOMM函数运行结果失败");
                case PcommApi.ErrorCode.SIO_ABORT_WRITE:
                    throw new ArgumentException("写入已被锁定，用户已放弃写入");
                case PcommApi.ErrorCode.SIO_WRITETIMEOUT:
                    throw new ArgumentException("已发生写入超时");
            }
        }

    }
}
