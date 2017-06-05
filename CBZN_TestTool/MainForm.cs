using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Bll;
using Dal;
using Model;

namespace CBZN_TestTool
{
    public partial class MainForm : Form
    {
        #region 变量

        /// <summary>
        /// 将读取到的定距卡添加致集合中,判断是否已经读取过
        /// </summary>
        private readonly Dictionary<string, int> _dicDataList = new Dictionary<string, int>();

        /// <summary>
        /// 设置模块参数
        /// </summary>
        private bool _isModuleSet;
        /// <summary>
        /// 是否读取临时IC卡
        /// </summary>
        private bool _isReadCard;
        /// <summary>
        /// 卡片管理总页数
        /// </summary>
        private int _pageCount;
        /// <summary>
        /// 卡片管理当前页数
        /// </summary>
        private int _currentPage;
        /// <summary>
        /// 卡片管理当前页数
        /// </summary>
        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                btn_Previous.Enabled = btn_First.Enabled = _currentPage > 0;
                btn_Next.Enabled = btn_Last.Enabled = _currentPage != _pageCount - 1;
                tb_Page.Text = (_currentPage + 1).ToString();
                try
                {
                    string where = GetSearchWhere();
                    DataTable dt = DbHelper.Db.ToTable<CardInfo>(_currentPage * 30, 30, where);
                    dgv_DataList.DataSource = dt;
                    dgv_DataList.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        /// <summary>
        /// 设备信息总页数
        /// </summary>
        private int _devicePageCount;
        /// <summary>
        /// 设备信息当前页数
        /// </summary>
        private int _deviceCurrentPage;
        /// <summary>
        /// 设备信息当前页数
        /// </summary>
        public int DeviceCurrentPage
        {
            get { return _deviceCurrentPage; }
            set
            {
                _deviceCurrentPage = value;
                btn_DevicePrevious.Enabled = btn_DeviceFirst.Enabled = _deviceCurrentPage > 0;
                btn_DeviceNext.Enabled = btn_DeviceLast.Enabled = _deviceCurrentPage != _devicePageCount - 1;
                tb_DevicePage.Text = (_deviceCurrentPage + 1).ToString();
                try
                {
                    DataTable dt = DbHelper.Db.ToTable<DeviceInfo>(_deviceCurrentPage * 30, 30);
                    dgv_Device.DataSource = dt;
                    dgv_DataList.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        /// <summary>
        /// 端口
        /// </summary>
        private ComPortHelper _mComPort;
        private Mutex _mMutex;
        private PortHelper _mPort;
        /// <summary>
        /// 批量注册参数
        /// </summary>
        public static RegisterParam? Rparam;
        /// <summary>
        /// 定时器连接端口
        /// </summary>
        private System.Timers.Timer _tiConnectionPort;
        /// <summary>
        /// 挂失集合
        /// </summary>
        public static List<CardInfo> _lossCards;
        /// <summary>
        /// 线程用于延期显示刷新按键
        /// </summary>
        private Thread _tTimeOutThread;
        /// <summary>
        /// 线程用于无线模式搜索频率
        /// </summary>
        private Thread _tSearchFrequency;

        #endregion 变量

        #region 窗体事件

        public MainForm()
        {
            InitializeComponent();
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_Tap1_MouseDown(object sender, MouseEventArgs e)
        {
            AcceptButton = btn_Read;
            ShowHideTap(sender as Button);
        }

        private void btn_Tap2_MouseDown(object sender, MouseEventArgs e)
        {
            AcceptButton = btn_TemporaryDevicePwdEnter;
            ShowHideTap(sender as Button);
        }

        private void btn_Tap3_MouseDown(object sender, MouseEventArgs e)
        {
            AcceptButton = null;
            ShowHideTap(sender as Button);
            if (dgv_Device.DataSource as DataTable == null)
            {
                System.Timers.Timer ti_DelayShowDeviceRecord = new System.Timers.Timer(100);
                ti_DelayShowDeviceRecord.AutoReset = false;
                ti_DelayShowDeviceRecord.Elapsed += new System.Timers.ElapsedEventHandler(ti_DelayShowDeviceRecord_Elapsed);
                ti_DelayShowDeviceRecord.Start();
            }
        }

        private void btn_Tap4_MouseDown(object sender, MouseEventArgs e)
        {
            AcceptButton = null;
            ShowHideTap(sender as Button);
        }

        void ti_DelayShowDeviceRecord_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            dgv_Device.Invoke(new EventHandler(delegate { btn_ShowDeviceRecord_Click(null, null); }));
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 1), new Rectangle(0, 0, Width - 1, Height - 1));
            }
        }

        private void DrawBtnPaint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (!btn.Enabled)
            {
                Graphics g = e.Graphics;
                StringFormat sf = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
                g.FillRectangle(new SolidBrush(btn.BackColor), rect);
                g.DrawString(btn.Text, btn.Font, new SolidBrush(btn.ForeColor), rect, sf);
                g.FillPolygon(Brushes.White, new Point[]
                {
                    new Point(btn.Width , btn.Height / 2 - 8),
                    new Point(btn.Width - 8 , btn.Height / 2),
                    new Point(btn.Width , btn.Height / 2 + 8)
                });
            }
        }

        private void BtnEnabledChanged(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = btn.Enabled ? Color.Transparent : btn.FlatAppearance.MouseDownBackColor;
        }

        private void BtnEnabledChanged2(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = btn.Enabled ? Color.FromArgb(4, 71, 124) : btn.FlatAppearance.MouseDownBackColor;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            p_Tap4_VisibleChanged(null, null);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            p_Tap2.Visible = false;
            p_Tap3.Visible = false;
            p_Tap4.Visible = false;

            DataValidation.IsProtocol = true;
            DataValidation.ProtocolHead = 2;
            DataValidation.ProtocolEnd = 3;
            DataValidation.IsValidation = true;

            string path = Environment.CurrentDirectory + "\\Data.db";
            try
            {
                DbHelper.LoadDb(path);

                string xmlpath = string.Format("{0}\\SystemSettings.xml", Application.StartupPath);
                XmlHelper xh = new XmlHelper(xmlpath);
                if (!xh.Load())
                {
                    xh.Create("1.0", "UTF-8", "Settings");
                }
                SystemSettings syssetting = xh.Read<SystemSettings>();
                if (syssetting == null)
                {
                    syssetting = new SystemSettings() { Version = Application.ProductVersion };
                    xh.Add<SystemSettings>(syssetting);
                    UpdateSystem();
                }
                else if (syssetting.Version != Application.ProductVersion)
                {
                    syssetting.Version = Application.ProductVersion;
                    xh.Update<SystemSettings>(syssetting);
                    UpdateSystem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSystem()
        {
            string cmdtext = " select sql from sqlite_master where name='DeviceInfo' ";
            object obj = DbHelper.Db.ExecuteScalar(cmdtext);
            if (obj != DBNull.Value)
            {
                if (!obj.ToString().Contains("FuzzyQuery"))
                {
                    cmdtext = " alter table DeviceInfo add column FuzzyQuery int default(0) ";
                    DbHelper.Db.ExecuteNonQuery(cmdtext);
                }
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            _mPort = new PortHelper
            {
                PortIsOpenChange = PortOpenAndCloseChange,
                PortDataReceived = PortDataReceived
            };

            _mComPort = new ComPortHelper();
            _mComPort.CountChange += MComPortCountChange;
            _mComPort.Start();
        }

        private void p_Title_MouseDown(object sender, MouseEventArgs e)
        {
            WinApi.ReleaseCapture();
            WinApi.SendMessage(Handle, WinApi.WM_SYSCOMMAND, WinApi.SC_MOVE + WinApi.HTCAPTION, 0);
        }

        private void p_Title_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                StringFormat sf = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(Text, p_Title.Font, Brushes.White, new Rectangle(0, 0, p_Title.Width, p_Title.Height), sf);
            }
        }

        private void ShowHideTap(Button btn)
        {
            ShowSelectedEffect(btn);
            if (btn == btn_Tap1)
                p_Tap1.Visible = true;
            if (btn == btn_Tap2)
                p_Tap2.Visible = true;
            if (btn == btn_Tap3)
                p_Tap3.Visible = true;
            if (btn == btn_Tap4)
                p_Tap4.Visible = true;
            p_Tap1.Visible = btn == btn_Tap1;
            p_Tap2.Visible = btn == btn_Tap2;
            p_Tap3.Visible = btn == btn_Tap3;
            p_Tap4.Visible = btn == btn_Tap4;
        }

        private void ShowSelectedEffect(Button btn)
        {
            btn_Tap1.Enabled = btn != btn_Tap1;
            btn_Tap2.Enabled = btn != btn_Tap2;
            btn_Tap3.Enabled = btn != btn_Tap3;
            btn_Tap4.Enabled = btn != btn_Tap4;
        }

        #endregion 窗体事件

        #region 端口事件

        private void _tiConnectionPort_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _mMutex.WaitOne();
            if (!_mPort.IsOpen)
            {
                foreach (string item in _mComPort.PortNames)
                {
                    _mPort.PortName = item;
                    try
                    {
                        _mPort.Open();
                        _mPort.SetIoctl();
                        byte[] by = PortAgreement.GetDistanceEncryption("766554");
                        _mPort.Write(by);
                        Thread.Sleep(550);
                        if (_mPort.IsOpen)
                        {
                            _tiConnectionPort.Stop();
                            _tiConnectionPort.Dispose();
                            _tiConnectionPort = null;
                            break;
                        }
                        _mPort.Close();
                        _mPort.IsOpen = false;
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }
            _mMutex.ReleaseMutex();
        }

        private void MComPortCountChange(List<string> portnames)
        {
            if (_mPort.IsOpen)
            {
                if (!portnames.Contains(_mPort.PortName))
                {
                    try
                    {
                        _mPort.Close();
                    }
                    catch
                    {
                        // ignored
                    }
                    finally
                    {
                        _mPort.IsOpen = false;
                    }
                }
            }
            if (!_mPort.IsOpen)
            {
                if (_tiConnectionPort == null)
                {
                    _mMutex = new Mutex();
                    _tiConnectionPort = new System.Timers.Timer(250) { AutoReset = true };
                    _tiConnectionPort.Elapsed += _tiConnectionPort_Elapsed;
                }
                _tiConnectionPort.Start();
            }
        }

        private void PortDataReceived(int port)
        {
            try
            {
                Thread.Sleep(30);
                int len = _mPort.GetBytesToRead();
                if (len < 3) return;
                byte[] by = new byte[len];
                _mPort.Read(by, len);
                List<byte[]> bylist = DataValidation.Validation(by);
                foreach (byte[] item in bylist)
                {
                    ParsingParameter parameter = DataParsing.ParsingContent(item);
                    switch (parameter.FunctionAddress)
                    {
                        case 65://0x41 定距卡操作

                            #region 定距卡操作

                            DistanceParameter distanceparameter = DataParsing.DistanceParsingContent(parameter.DataContent);
                            switch (distanceparameter.Command)
                            {
                                case 10://0x0A 读所有卡的flash

                                    #region 读所有卡的flash

                                    if (distanceparameter.AuxiliaryCommand == 8)
                                    {
                                        btn_Read.Invoke(new EventHandler(delegate
                                        {
                                            StopTimeOutThread();
                                            btn_Read.Enabled = true;
                                            dgv_DataList_SelectionChanged(null, null);
                                            l_RecordCount.Text = string.Format("总共 {0} 条记录", dgv_DataList.RowCount);
                                        }));
                                    }
                                    else
                                    {
                                        //查询卡号
                                        CardInfo cardinfo = DbHelper.Db.FirstDefault<CardInfo>(string.Format(" and CardNumber='{0}' ", distanceparameter.CardNumber));
                                        if (cardinfo == null)
                                        {
                                            cardinfo = new CardInfo();
                                        }
                                        cardinfo.CardNumber = distanceparameter.CardNumber;
                                        cardinfo.CardType = (int)distanceparameter.TypeParameter.CardType;
                                        cardinfo.CardLock = distanceparameter.TypeParameter.Lock;
                                        cardinfo.CardDistance = distanceparameter.TypeParameter.Distance;
                                        cardinfo.Electricity = distanceparameter.TypeParameter.Battry;
                                        if (cardinfo.CardType != 8 && cardinfo.CardType != 15)
                                        {
                                            DistanceDataParameter dataparameter =
                                                    DataParsing.DistanceData(parameter.DataContent);
                                            if (cardinfo.CardReportLoss == 0)
                                                cardinfo.CardReportLoss = dataparameter.FunctionByteParameter.Loss;
                                            cardinfo.Synchronous = dataparameter.FunctionByteParameter.Synchronous;
                                            cardinfo.InOutState = dataparameter.FunctionByteParameter.InOutState;
                                            if (cardinfo.Cid > 0 && cardinfo.CardType < 3)
                                            {
                                                cardinfo.CardType = (int)dataparameter.FunctionByteParameter.RegistrationType;
                                                if (cardinfo.CardType == 1)
                                                {
                                                    cardinfo.ParkingRestrictions =
                                                        dataparameter.FunctionByteParameter.ParkingRestrictions;
                                                }
                                                cardinfo.ViceCardCount = dataparameter.FunctionByteParameter.ViceCardCount;
                                            }
                                            if (cardinfo.CardCount < dataparameter.Count)
                                            {
                                                cardinfo.CardCount = dataparameter.Count;
                                            }
                                        }
                                        ShowReadCardInfo(cardinfo);
                                        CreateTimeOutThread();
                                    }

                                    #endregion 读所有卡的flash

                                    break;

                                case 11://0x0B 写入所有卡的flash

                                    break;

                                case 13://0x0D 修改全部卡密码
                                    DistanceCardEncryptionResult(distanceparameter);
                                    break;

                                case 26://0x1A 读某张卡片的flash

                                    break;

                                case 27://0x1B 写某张卡片的flash
                                    if (DistanceRegister.IsShow)
                                    {
                                        DistanceRegister dr = DistanceRegister.Instance;
                                        dr.PortDataReceived(distanceparameter);
                                    }
                                    else if (BatchRegister.IsShow)
                                    {
                                        BatchRegister br = BatchRegister.CurrentForm;
                                        br.PortDataReceived(distanceparameter);
                                    }
                                    else if (ViceCardDelay.IsShow)
                                    {
                                        ViceCardDelay vcd = ViceCardDelay.Instance;
                                        vcd.PortDataReceived(distanceparameter);
                                    }
                                    else if (DelayParam.IsShow)
                                    {
                                        DelayParam dp = DelayParam.Instance;
                                        dp.PortDataReceived(distanceparameter);
                                    }
                                    else if (p_ReportTheLossOf.Visible)
                                    {
                                        if (distanceparameter.AuxiliaryCommand == 0)//挂失完成
                                        {
                                            //启用一个线程更新列表中的显示
                                            Thread tUpdateLossContent = new Thread(UpdateLossContent);
                                            tUpdateLossContent.IsBackground = true;
                                            tUpdateLossContent.Start();
                                            dgv_LossList.Rows.Clear();
                                            btn_Enter.Enabled = true;
                                            cb_AllSelected.Enabled = true;
                                            p_ReportTheLossOf.Visible = false;
                                        }
                                        else //挂失失败
                                        {
                                            btn_Enter.Enabled = true;
                                            cb_AllSelected.Enabled = true;
                                            if (cb_AllSelected.CheckState != CheckState.Unchecked)
                                                btn_Remove.Enabled = true;
                                            MessageBox.Show("定距卡挂失失败，请确认挂失卡是否放置在发行器上。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    break;

                                case 160://0xA0 初始化主机参数
                                    DistanceEncryptionResult(distanceparameter);
                                    break;
                            }

                            #endregion 定距卡操作

                            break;

                        case 66://0x42 IC操作

                            #region IC 卡片操作

                            switch (parameter.Command)
                            {
                                case 9://读取 IC 卡内容
                                    IcCardParameter iccardparameter = DataParsing.TemporaryIcCardContent(parameter.DataContent);
                                    ShowIcCardContent(iccardparameter);
                                    break;

                                case 204://0x43 0x43 IC卡加密
                                    TemporaryIcEncryptionResult(parameter);
                                    break;

                                case 221://0x44 0x44 IC设备加密
                                    TemporaryEncryptionResult(parameter);
                                    break;
                            }

                            #endregion IC 卡片操作

                            break;

                        case 67://0x43 模块操作

                            #region 模块操作

                            switch (parameter.Command)
                            {
                                case 9:
                                    //0x46 F 失败  0x53 S 成功
                                    _isModuleSet = DataParsing.TemporaryContent(parameter.DataContent) == 83;
                                    break;

                                case 208://0x44 0x30 设置参数
                                    if (parameter.DataContent.Length == 15)
                                    {
                                        //查询频率
                                        int frequency = (int)DataParsing.TemporaryContent(parameter.DataContent);
                                        QueryFrequncy(frequency);
                                    }
                                    else if (parameter.DataContent.Length == 22)
                                    {
                                        //查询无线ID
                                        long wirelessiid = DataParsing.TemporaryContent(parameter.DataContent);
                                        QueryWireless(wirelessiid);
                                    }
                                    else
                                    {
                                        //0x59 Y 设置成功  0x4E N 设置失败
                                        _isModuleSet = DataParsing.TemporaryContent(parameter.DataContent) == 89;
                                    }
                                    break;
                            }

                            #endregion 模块操作

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PortOpenAndCloseChange(object e, bool flag)
        {
            this.Invoke(new EventHandler(delegate
            {
                btn_Read.Enabled = flag;
                btn_DistanceDeviceEnter.Enabled = flag;
                btn_TemporaryDevicePwdEnter.Enabled = flag;
                btn_TemporaryReadCard.Enabled = flag;
                btn_WirelessSet.Enabled = flag;
                btn_FrequencySearch.Enabled = flag;
                btn_Query.Enabled = flag;
                btn_Test.Enabled = flag;
                btn_Enter.Enabled = flag;
                if (flag)
                {
                    dgv_DataList_SelectionChanged(null, null);
                }
                else
                {
                    btn_Register.Enabled = false;
                    btn_Registers.Enabled = false;
                    btn_ReportTheLossOf.Enabled = false;
                    btn_Delay.Enabled = false;
                }
                if (flag)
                {
                    l_PortConnectionState.Text = _mPort.PortName;
                    l_PortConnectionState.ForeColor = Color.Lime;
                }
                else
                {
                    l_PortConnectionState.Text = "未连接";
                    l_PortConnectionState.ForeColor = Color.Red;
                }
            }));
        }

        #endregion 端口事件

        #region 卡片管理

        private void btn_Delay_Click(object sender, EventArgs e)
        {
            if (dgv_DataList.SelectedRows.Count == 0) return;
            int index = dgv_DataList.SelectedRows[0].Index;
            CardInfo info = GetDataInfo<CardInfo>(index, dgv_DataList);
            if (info.CardType > 0)
            {
                using (ViceCardDelay vcd = ViceCardDelay.Instance)
                {
                    vcd._mCardInfo = info;
                    vcd._mPort = _mPort;
                    vcd.DelayDataChange += Vcd_DelayDataChange;
                    vcd.ShowDialog();
                }
            }
            else
            {
                using (DelayParam dp = DelayParam.Instance)
                {
                    dp._mPort = _mPort;
                    dp._mCardInfo = info;
                    dp.ShowDialog();
                    if (dp.Tag == null) return;
                    UpdateRowData<CardInfo>(dp.Tag as CardInfo, dgv_DataList.Rows[index]);
                }
            }
        }

        private void Vcd_DelayDataChange(CardInfo hostcardinfo, List<CardInfo> vicecard)
        {
            int index = dgv_DataList.SelectedRows[0].Index;
            UpdateRowData<CardInfo>(hostcardinfo, dgv_DataList.Rows[index]);
            if (hostcardinfo.CardType == 1)
            {
                foreach (CardInfo item in vicecard)
                {
                    for (int i = 0; i < dgv_DataList.RowCount; i++)
                    {
                        if (dgv_DataList.Rows[i].Cells["CardNumber"].Value.Equals(item.CardNumber))
                        {
                            UpdateRowData<CardInfo>(item, dgv_DataList.Rows[i]);
                            break;
                        }
                    }
                }
            }
        }

        private void br_Registercomplete(int index, CardInfo info)
        {
            if (index > -1 && index < dgv_DataList.RowCount)
            {
                UpdateRowData<CardInfo>(info, dgv_DataList.Rows[index]);
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
        }

        private void btn_First_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
        }

        private void btn_Last_Click(object sender, EventArgs e)
        {
            CurrentPage = _pageCount - 1;
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            DataTable dt = dgv_DataList.DataSource as DataTable;
            if (dt != null)
                dt.Rows.Clear();
            _dicDataList.Clear();

            btn_Read.Enabled = false;
            try
            {
                byte[] by = PortAgreement.GetReadAllCard();
                _mPort.Write(by);

                CreateTimeOutThread();
            }
            catch (Exception ex)
            {
                btn_Read.Enabled = true;
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopTimeOutThread()
        {
            if (_tTimeOutThread != null)
            {
                _tTimeOutThread.Abort();
            }
        }

        private void CreateTimeOutThread()
        {
            StopTimeOutThread();
            _tTimeOutThread = new Thread(TimeOutWait);
            _tTimeOutThread.IsBackground = true;
            _tTimeOutThread.Start();
        }

        private void TimeOutWait()
        {
            try
            {
                Thread.Sleep(5000);

                btn_Read.Enabled = _mPort.IsOpen;
            }
            finally
            {
                _tTimeOutThread = null;
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (dgv_DataList.SelectedRows.Count == 0) return;
            int index = dgv_DataList.SelectedRows[0].Index;

            CardInfo info = GetDataInfo<CardInfo>(index, dgv_DataList);
            Dictionary<int, CardInfo> datalistinfo = GetDataInfo<CardInfo>(dgv_DataList);
            List<CardInfo> vicecardinfo = new List<CardInfo>();
            foreach (KeyValuePair<int, CardInfo> item in datalistinfo)
            {
                if (item.Value.CardType == 3)
                {
                    vicecardinfo.Add(item.Value);
                }
            }

            using (DistanceRegister dr = DistanceRegister.Instance)
            {
                dr._mViceCardInfo = vicecardinfo;
                dr._mCardInfo = info;
                dr._mPort = _mPort;
                dr.ShowDialog();
                if (dr.Tag == null) return;
                info = dr.Tag as CardInfo;
                UpdateRowData<CardInfo>(info, dgv_DataList.Rows[index]);
                btn_Delay.Enabled = true;
            }

        }

        private void btn_Registers_Click(object sender, EventArgs e)
        {
            Dictionary<int, CardInfo> datalistinfo = GetDataInfo<CardInfo>(dgv_DataList);
            Dictionary<int, CardInfo> registerlist = new Dictionary<int, CardInfo>();
            foreach (KeyValuePair<int, CardInfo> item in datalistinfo)
            {
                if (item.Value.Cid > 0) continue;
                if (item.Value.CardType > 2) continue;
                if (item.Value.ParkingRestrictions == 1) continue;
                registerlist.Add(item.Key, item.Value);
            }
            if (registerlist.Count > 0)
            {
                using (BatchRegister br = BatchRegister.CurrentForm)
                {
                    br.DicRegisterList = registerlist;
                    br.Port = _mPort;
                    br.Registercomplete += br_Registercomplete;
                    br.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show(@"列表中无需注册的定距卡", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_ReportTheLossOf_Click(object sender, EventArgs e)
        {
            if (_lossCards == null)
                _lossCards = new List<CardInfo>();
            int index = dgv_DataList.SelectedRows[0].Index;
            CardInfo info = GetDataInfo<CardInfo>(index, dgv_DataList);
            if (info.CardType > 2)
            {
                MessageBox.Show("副卡、注销卡、密码错误无法进行挂失操作。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (info.Cid == 0)
            {
                MessageBox.Show("定距卡未注册，无法进行挂失操作。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (info.CardReportLoss == 1)
            {
                MessageBox.Show("当前定距卡已经挂失，无法重复进行挂失操作。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IsExist(info))
            {
                MessageBox.Show(string.Format("定距卡:{0}已经存在挂失列表中，不得重复挂失。", info.CardNumber), "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            _lossCards.Add(info);
            if (p_ReportTheLossOf.Visible)
            {
                dgv_LossList.Rows.Add(new object[] { false, info.CardNumber, info.CardType, info.CardTime });
            }
            else
            {
                p_ReportTheLossOf.Visible = true;
            }
        }

        private bool IsExist(CardInfo info)
        {
            foreach (CardInfo item in _lossCards)
            {
                if (info.Cid == item.Cid)
                {
                    return true;
                }
            }
            return false;
        }

        private void UpdateLossContent()
        {
            DbHelper.Db.Update<CardInfo>(_lossCards);
            Dictionary<int, CardInfo> dic = GetDataInfo<CardInfo>(dgv_DataList);
            foreach (KeyValuePair<int, CardInfo> item in dic)
            {
                if (item.Value.Cid == 0 || item.Value.CardType > 2) continue;
                foreach (CardInfo lossitem in _lossCards)
                {
                    if (item.Value.Cid == lossitem.Cid)
                    {
                        UpdateRowData<CardInfo>(lossitem, dgv_DataList.Rows[item.Key]);
                        break;
                    }
                }
            }
            _lossCards = null;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            ShowRecord();
        }

        private void btn_ShowRecord_Click(object sender, EventArgs e)
        {
            ShowRecord();
        }

        private void dgv_DataList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Value = (long)e.Value == 0 ? Properties.Resources.block : Properties.Resources.check;
            }
            else if (e.ColumnIndex == 2)
            {
                int cardtype = Convert.ToInt32(e.Value);
                switch ((CardType)cardtype)
                {
                    case Bll.CardType.SingleCard:
                        e.Value = "单卡";
                        break;

                    case Bll.CardType.CombinationCard:
                        e.Value = "组合卡";
                        break;

                    case Bll.CardType.LPRCard:
                        e.Value = "车牌识别卡";
                        break;

                    case Bll.CardType.ViceCard:
                        e.Value = "副卡";
                        break;

                    case Bll.CardType.CancellationCard:
                        e.Value = "注销卡";
                        break;

                    case Bll.CardType.PasswordMistake:
                        e.Value = "卡片密码错误";
                        break;
                }
            }
            else if (e.ColumnIndex == 4)
            {
                if (Regex.IsMatch(e.Value.ToString(), @"^\d$"))
                {
                    int distance = HexadecimalConversion.ObjToInt(e.Value);
                    if (distance == 0)
                        e.Value = "读头调节距离";
                    else if (distance == 1)
                        e.Value = "1.2 米";
                    else if (distance == 2)
                        e.Value = "2.5 米";
                    else if (distance == 3)
                        e.Value = "3.8 米";
                    else if (distance == 4)
                        e.Value = "5 米";
                }
            }
            else if (e.ColumnIndex == 5)
            {
                e.Value = e.Value.Equals(0) ? Properties.Resources.OpenLock : Properties.Resources.Lock;
            }
            else if (e.ColumnIndex == 6)
            {
                e.Value = e.Value.Equals(0) ? Properties.Resources.block : Properties.Resources.check;
            }
            else if (e.ColumnIndex == 7)
            {
                e.Value = e.Value.Equals(0) ? Properties.Resources.block : Properties.Resources.check;
            }
            else if (e.ColumnIndex == 8)
            {
                if (e.Value.Equals(0))
                {
                    e.Value = "关闭";
                }
                else
                {
                    if (Regex.IsMatch(e.Value.ToString(), @"^\d+$"))
                    {
                        StringBuilder sb = new StringBuilder();
                        int partition = HexadecimalConversion.ObjToInt(e.Value);
                        for (int i = 0; i < 16; i++)
                        {
                            if (BinaryHelper.GetIntegerSomeBit(partition, i) == 1)
                            {
                                sb.AppendFormat(" {0} 分区", i + 1);
                            }
                        }
                        e.Value = sb.ToString();
                    }
                }
            }
            else if (e.ColumnIndex == 9)
            {
                e.Value = e.Value.Equals(0) ? Properties.Resources.Battery : Properties.Resources.LowPower;
            }
        }

        private void dgv_DataList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void dgv_DataList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgv_DataList.RowCount == 0)
            {
                btn_Register.Enabled = false;
                btn_Registers.Enabled = false;
                btn_Delay.Enabled = false;
                btn_ReportTheLossOf.Enabled = false;
            }
        }

        private void dgv_DataList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_DataList.RowCount == 0) return;
            if (!btn_Read.Enabled) return;
            if (_mPort != null && _mPort.IsOpen)
            {
                btn_Registers.Enabled = true;
                if (dgv_DataList.SelectedRows.Count > 0)
                {
                    int index = dgv_DataList.SelectedRows[0].Index;
                    CardInfo info = GetDataInfo<CardInfo>(index, dgv_DataList);
                    if (info.CardType < 3)
                    {
                        btn_Register.Enabled = true;
                        btn_Delay.Enabled = info.Cid > 0;
                        btn_ReportTheLossOf.Enabled = true;
                    }
                    else
                    {
                        btn_Register.Enabled = false;
                        btn_Delay.Enabled = false;
                        btn_ReportTheLossOf.Enabled = false;
                    }
                }
            }
        }

        private void ShowReadCardInfo(CardInfo info)
        {
            dgv_DataList.BeginInvoke(new EventHandler(delegate
            {
                if (_dicDataList.ContainsKey(info.CardNumber)) return;
                DataTable dt = dgv_DataList.DataSource as DataTable ?? GetDataTableHead<CardInfo>(dgv_DataList);
                dt.Rows.Add();
                DataRow dr = dt.Rows[dt.Rows.Count - 1];
                UpdateRowData<CardInfo>(info, dr);
                _dicDataList.Add(info.CardNumber, info.CardType);
            }));
        }

        private void tb_Page_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == 10)
            {
                int page = 0;
                if (tb_Page.TextLength > 0)
                    page = Convert.ToInt32(tb_Page.Text);
                page--;
                if (page <= 0)
                    page = 0;
                if (page >= _pageCount)
                    page = _pageCount - 1;
                CurrentPage = page;
            }
            else if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else if (e.KeyChar < 47 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }

        private string GetSearchWhere()
        {
            string searchcontent = tb_Search.Text.Trim();
            StringBuilder sbwhere = new StringBuilder(" and CardType > -1 ");
            if (searchcontent.Length != 0)
            {
                sbwhere.AppendFormat(" and CardNumber like '%{0}%' ", searchcontent);
            }
            return sbwhere.ToString();
        }

        private void ShowRecord()
        {
            try
            {
                string where = GetSearchWhere();
                int count = DbHelper.Db.GetCount<CardInfo>(where);
                GetShowPage(count, l_RecordCount);
                int page = GetShowPage(count, l_RecordCount);
                _pageCount = page;
                CurrentPage = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 挂失关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LossClose_Click(object sender, EventArgs e)
        {
            if (_mPort.IsOpen && _lossCards.Count > 0 && !btn_Enter.Enabled)
            {
                MessageBox.Show("当前挂失操作未完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (_lossCards.Count > 0)
                {
                    if (MessageBox.Show("确认是否关闭当前操作内容.", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        dgv_LossList.Rows.Clear();
                        _lossCards.Clear();
                    }
                    else
                    {
                        return;
                    }
                }
                p_ReportTheLossOf.Visible = false;
            }
        }

        /// <summary>
        /// 挂失容器标题重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void p_LossTitle_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                StringFormat sf = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString("挂失列表", p_LossTitle.Font, Brushes.White, new Rectangle(0, 0, p_LossTitle.Width, p_LossTitle.Height), sf);//绘制标题
            }
        }

        /// <summary>
        /// 挂失全选选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_Selected_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Selected.CheckState == CheckState.Indeterminate) return;
            cb_Selected.Tag = cb_Selected.Checked;
            for (int i = 0; i < dgv_LossList.RowCount; i++)
            {
                dgv_LossList["c_LossSelected", i].Value = cb_Selected.Checked;
            }
            if (dgv_LossList.RowCount > 0)
            {
                btn_Remove.Enabled = cb_Selected.Checked;
            }
            cb_Selected.Tag = null;
        }

        /// <summary>
        /// 挂失全选鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_Selected_MouseDown(object sender, MouseEventArgs e)
        {
            cb_Selected.ThreeState = false;
        }

        /// <summary>
        /// DGV 单元格内容发生变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_LossList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (cb_Selected.Tag != null) return;
            int count = 0;
            for (int i = 0; i < dgv_LossList.RowCount; i++)
            {
                bool check = Convert.ToBoolean(dgv_LossList["c_LossSelected", i].Value);
                if (check)
                    count++;
            }
            cb_Selected.ThreeState = true;
            if (count == 0)
                cb_Selected.CheckState = CheckState.Unchecked;
            else if (count == dgv_LossList.RowCount)
                cb_Selected.CheckState = CheckState.Checked;
            else
                cb_Selected.CheckState = CheckState.Indeterminate;
            btn_Remove.Enabled = count > 0;
        }

        /// <summary>
        /// DGV 单元格状态因其内容更改而更改时事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_LossList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_LossList.IsCurrentCellDirty)
            {
                dgv_LossList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// DGV 单元格格式发生变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_LossList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_LossList.Columns[e.ColumnIndex].Name == "c_LossCardType")
            {
                if (CRegex.IsDecimal(e.Value))//验证内容是否为十进制内容
                {
                    int cardtype = HexadecimalConversion.ObjToInt(e.Value);
                    switch ((CardType)cardtype)
                    {
                        case Bll.CardType.SingleCard:
                            e.Value = "单卡";
                            break;

                        case Bll.CardType.CombinationCard:
                            e.Value = "组合卡";
                            break;

                        case Bll.CardType.LPRCard:
                            e.Value = "车牌识别卡";
                            break;

                        case Bll.CardType.ViceCard:
                            e.Value = "副卡";
                            break;

                        case Bll.CardType.CancellationCard:
                            e.Value = "注销卡";
                            break;

                        case Bll.CardType.PasswordMistake:
                            e.Value = "卡片密码错误";
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// DGV 移除行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_LossList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgv_LossList.RowCount == 0)
            {
                btn_Enter.Enabled = false;
                cb_AllSelected.Enabled = false;
            }
        }

        /// <summary>
        /// DGV 添加行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_LossList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btn_Enter.Enabled = _mPort.IsOpen;
            cb_AllSelected.Enabled = true;
        }

        /// <summary>
        /// 挂失容器重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void p_ReportTheLossOf_Paint(object sender, PaintEventArgs e)
        {
            //绘制边框
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 1), 0, 0, Width - 1, Height - 1);
            }
        }

        /// <summary>
        /// 挂失容器隐藏或显示事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void p_ReportTheLossOf_VisibleChanged(object sender, EventArgs e)
        {
            if (p_ReportTheLossOf.Visible)
            {
                foreach (CardInfo item in _lossCards)
                {
                    dgv_LossList.Rows.Add(new object[] { false, item.CardNumber, item.CardType, item.CardTime });
                }
            }
        }

        /// <summary>
        /// 移除挂失
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            for (int i = dgv_LossList.RowCount - 1; i >= 0; i--)
            {
                bool check = Convert.ToBoolean(dgv_LossList["c_LossSelected", i].Value);
                if (!check) continue;
                MainForm._lossCards.RemoveAt(i);
                dgv_LossList.Rows.RemoveAt(i);
            }
            btn_Remove.Enabled = false;
            cb_Selected.CheckState = CheckState.Unchecked;
        }

        /// <summary>
        /// 确认挂失
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Enter_Click(object sender, EventArgs e)
        {
            btn_Enter.Enabled = false;
            cb_AllSelected.Enabled = false;
            btn_Remove.Enabled = false;
            try
            {
                List<LossParameter> lossparams = new List<LossParameter>();
                foreach (CardInfo item in _lossCards)
                {
                    item.CardCount = DataCombination.SetCount(item.CardCount);
                    item.CardReportLoss = 1;

                    FunctionByteParameter function = new FunctionByteParameter()
                    {
                        Loss = item.CardReportLoss,
                        InOutState = item.InOutState,
                        ParkingRestrictions = item.ParkingRestrictions,
                        RegistrationType = (CardType)item.CardType,
                        Synchronous = item.Synchronous,
                        ViceCardCount = item.ViceCardCount
                    };

                    LossParameter param = new LossParameter()
                    {
                        CardNumber = item.CardNumber,
                        Function = function,
                        Time = item.CardTime
                    };
                    lossparams.Add(param);
                }

                byte[] by = DataCombination.CombinationLoss(lossparams);
                _mPort.Write(by);
            }
            catch (Exception ex)
            {
                btn_Enter.Enabled = true;
                cb_AllSelected.Enabled = true;
                if (cb_AllSelected.CheckState != CheckState.Unchecked)
                    btn_Remove.Enabled = true;
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion 卡片操作

        #region 加密操作

        private void DrawBtnPaint2(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (!btn.Enabled)
            {
                Graphics g = e.Graphics;
                StringFormat sf = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
                g.FillRectangle(new SolidBrush(btn.BackColor), rect);
                g.DrawString(btn.Text, btn.Font, new SolidBrush(btn.ForeColor), rect, sf);
                g.FillPolygon(Brushes.White, new Point[]
                {
                    new Point(btn.Width / 2 , btn.Height  - 5),
                    new Point(btn.Width / 2 + 5 , btn.Height),
                    new Point(btn.Width / 2-5 , btn.Height)
                });
            }
        }

        private void btn_TapDistanceEncryption_Click(object sender, EventArgs e)
        {
            ShowHideEncryptionTap(btn_TapDistanceEncryption);
            AcceptButton = btn_DistanceDeviceEnter;
        }

        private void btn_TapTemporaryEncryption_Click(object sender, EventArgs e)
        {
            ShowHideEncryptionTap(btn_TapTemporaryEncryption);
            AcceptButton = btn_TemporaryDevicePwdEnter;
        }

        private void dgv_pwd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (AcceptButton == btn_DistanceDeviceEnter)
            {
                btn_DistanceDeviceEnter_Click(null, null);
            }
            else if (AcceptButton == btn_TemporaryDevicePwdEnter)
            {
                btn_TemporaryDevicePwdEnter_Click(null, null);
            }
            e.Handled = true;
        }

        private void dgv_pwd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgv_pwd.FirstDisplayedScrollingRowIndex = e.RowIndex;
        }

        private void DrawBorder(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;
            using (Graphics g = e.Graphics)
            {
                //int x = !btn_TapDistanceEncryption.Enabled ? btn_TapDistanceEncryption.Left : btn_TapTemporaryEncryption.Left;
                //int width = btn_TapDistanceEncryption.Width;
                //x += width / 2;
                //Point[] p =
                //{
                //    new Point(0,10),
                //    new Point(x-5,10),
                //    new Point(x,5),
                //    new Point(x+5,10),
                //    new Point(panel.Width,10),
                //    new Point(panel.Width - 1, 0),
                //    new Point(panel.Width - 1, panel.Height)
                //};
                //g.DrawLines(new Pen(Color.Gray), p);
                g.DrawLine(new Pen(Color.Gray), panel.Width - 1, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        private void ShowEncryptionMessage(string message, bool isend, int command)
        {
            this.Invoke(new EventHandler(delegate
            {
                if (dgv_pwd.RowCount >= 30)
                    dgv_pwd.Rows.RemoveAt(0);
                int index = dgv_pwd.Rows.Add(new object[] { message, DateTime.Now });
                switch (command)
                {
                    case 160:
                        if (cb_DistanceWay.Checked) //定距卡加密
                        {
                            string pwd = tb_DistancePwd.Text;
                            //发送修改卡片新密码
                            try
                            {
                                if (_mPort.IsOpen)
                                {
                                    byte[] by = PortAgreement.GetDistanceCardEncryption(pwd);
                                    _mPort.Write(@by);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else //定距发卡器加密
                        {
                            btn_DistanceDeviceEnter.Enabled = isend;
                        }
                        break;

                    case 13:
                        btn_DistanceDeviceEnter.Enabled = isend;
                        break;

                    case 204:
                        btn_TemporaryDevicePwdEnter.Enabled = isend;
                        break;

                    case 221:
                        if (cb_TemporaryWay.Checked)
                        {
                            string pwd = tb_TemporaryPwd.Text;
                            try
                            {
                                if (_mPort.IsOpen)
                                {
                                    byte[] by = PortAgreement.GetTemporaryICEncryption(pwd);
                                    _mPort.Write(@by);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            btn_TemporaryDevicePwdEnter.Enabled = isend;
                        }
                        break;
                }
            }));
        }

        private void ShowHideEncryptionTap(Button btn)
        {
            ShowSelectedEncryptionEffect(btn);
            p_DistanceInterface.Visible = btn == btn_TapDistanceEncryption;
            p_TemporaryInterface.Visible = btn == btn_TapTemporaryEncryption;
        }

        private void ShowSelectedEncryptionEffect(Button btn)
        {
            if (!btn_TapDistanceEncryption.Enabled)
            {
                btn_TapDistanceEncryption.Enabled = true;
            }
            if (!btn_TapTemporaryEncryption.Enabled)
            {
                btn_TapTemporaryEncryption.Enabled = true;
            }
            btn.Enabled = false;
        }

        private void TxtKeyProcess(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || (e.KeyChar >= 48 && e.KeyChar <= 57))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        #region 定距加密

        private void gb_Distance_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawLine(new Pen(Color.FromArgb(221, 221, 221)), 0, tb_DistanceOldPwd.Top + tb_DistanceOldPwd.Height + 20, gb_Distance.Width, tb_DistanceOldPwd.Top + tb_DistanceOldPwd.Height + 20);
            }
        }

        private void btn_DistanceDeviceEnter_Click(object sender, EventArgs e)
        {
            string oldpwd = string.Empty;
            string pwd = tb_DistancePwd.Text;
            string confirm = tb_ConfirmDistancePwd.Text;

            #region 验证输入

            if (cb_DistanceWay.Checked)
            {
                oldpwd = tb_DistanceOldPwd.Text;
                if (oldpwd.Length == 0)
                {
                    MessageBox.Show(@" 旧密码不能为空，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_DistanceOldPwd.Focus();
                    return;
                }
                if (oldpwd.Length < tb_DistanceOldPwd.MaxLength)
                {
                    MessageBox.Show(@" 旧密码长度不能小于 6 位，请重新输入。 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_DistanceOldPwd.Focus();
                    return;
                }
            }

            if (pwd.Length == 0)
            {
                MessageBox.Show(@" 新密码不能为空，请重新输入。 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tb_DistancePwd.Focus();
                return;
            }
            if (pwd.Length < tb_DistancePwd.MaxLength)
            {
                MessageBox.Show(@" 新密码长度不能小于 6 位，请重新输入。 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tb_DistancePwd.Focus();
                return;
            }

            if (confirm.Length == 0)
            {
                MessageBox.Show(@" 确认密码不能为空，请重新输入。 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tb_ConfirmDistancePwd.Focus();
                return;
            }
            if (confirm.Length < tb_ConfirmDistancePwd.MaxLength)
            {
                MessageBox.Show(@" 确认密码长度不能小于 6 位，请重新输入。 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tb_ConfirmDistancePwd.Focus();
                return;
            }
            if (pwd != confirm)
            {
                MessageBox.Show(@" 新密码与确认密码不一致，请重新输入。 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tb_ConfirmDistancePwd.Focus();
                return;
            }

            #endregion 验证输入

            btn_DistanceDeviceEnter.Enabled = false;
            try
            {
                byte[] by = PortAgreement.GetDistanceEncryption(!cb_DistanceWay.Checked ? pwd : oldpwd);
                _mPort.Write(by);
            }
            catch (Exception ex)
            {
                btn_DistanceDeviceEnter.Enabled = true;
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_DefaultDistanOldPwd_CheckedChanged(object sender, EventArgs e)
        {
            bool result = !cb_DefaultDistanOldPwd.Checked;
            tb_DistanceOldPwd.Enabled = result;
            if (!result)
            {
                tb_DistanceOldPwd.Text = @"766554";
            }
            else
            {
                tb_DistanceOldPwd.Text = string.Empty;
                tb_DistanceOldPwd.Focus();
            }
        }

        private void cb_DefaultDistanPwd_CheckedChanged(object sender, EventArgs e)
        {
            bool result = !cb_DefaultDistanPwd.Checked;
            tb_DistancePwd.Enabled = result;
            tb_ConfirmDistancePwd.Enabled = result;
            if (!result)
            {
                string pwd = "766554";
                tb_DistancePwd.Text = pwd;
                tb_ConfirmDistancePwd.Text = pwd;
                btn_DistanceDeviceEnter.Focus();
            }
            else
            {
                tb_DistancePwd.Text = string.Empty;
                tb_ConfirmDistancePwd.Text = string.Empty;
                tb_DistancePwd.Focus();
            }
        }

        private void cb_DistanceWay_CheckedChanged(object sender, EventArgs e)
        {
            bool result = cb_DistanceWay.Checked;
            cb_DefaultDistanOldPwd.Enabled = result;
            if (!cb_DefaultDistanOldPwd.Checked)
                tb_DistanceOldPwd.Enabled = result;
            gb_Distance.Text = result ? "定距卡加密" : "定距发卡器加密";
        }

        private void DistanceCardEncryptionResult(DistanceParameter parameter)
        {
            switch (parameter.AuxiliaryCommand)
            {
                case 0:
                    if (parameter.TypeParameter.CardType == Bll.CardType.PasswordMistake)
                        ShowEncryptionMessage("定距卡 " + parameter.CardNumber + " 加密失败", false, parameter.Command);
                    else
                        //显示成功
                        ShowEncryptionMessage("定距卡 " + parameter.CardNumber + " 加密成功。", false, parameter.Command);
                    break;

                case 8:
                    ShowEncryptionMessage("定距卡加密结束。", true, parameter.Command);
                    break;

                default:
                    ShowEncryptionMessage("定距卡加密失败，请将定距卡放置在读写区域内。", false, parameter.Command);
                    break;
            }
        }

        private void DistanceEncryptionResult(DistanceParameter parameter)
        {
            if (parameter.AuxiliaryCommand == 0)//成功
            {
                if (!_mPort.IsOpen)
                {
                    _mPort.IsOpen = true;
                    return;
                }
                //显示成功
                ShowEncryptionMessage("发卡器加密成功。", true, parameter.Command);
            }
            else//失败
            {
                //显示失败
                ShowEncryptionMessage("发卡器加密失败，请检测端口通信是否正常。", true, parameter.Command);
            }
        }

        private void DistancePwdKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (btn_DistanceDeviceEnter.Enabled)
                btn_DistanceDeviceEnter_Click(null, null);
        }

        private void p_DistanceInterface_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder(sender, e);
        }

        private void tb_ConfirmDistancePwd_KeyDown(object sender, KeyEventArgs e)
        {
            DistancePwdKeyDown(sender, e);
        }

        private void tb_DistancePwd_KeyDown(object sender, KeyEventArgs e)
        {
            DistancePwdKeyDown(sender, e);
        }

        #endregion 定距加密

        #region 临时加密

        private void gb_Temporary_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawLine(new Pen(Color.FromArgb(221, 221, 221)), 0, tb_TemporaryOldPwd.Top + tb_TemporaryOldPwd.Height + 20, gb_Temporary.Width, tb_TemporaryOldPwd.Top + tb_TemporaryOldPwd.Height + 20);
            }
        }

        private void btn_TemporaryDevicePwdEnter_Click(object sender, EventArgs e)
        {
            string oldpwd = string.Empty;
            string pwd = tb_TemporaryPwd.Text;
            string confirm = tb_ConfirmTemporaryPwd.Text;

            #region 输入验证

            if (cb_TemporaryWay.Checked)
            {
                oldpwd = tb_TemporaryOldPwd.Text;
                if (oldpwd.Length == 0)
                {
                    MessageBox.Show(@" 旧密码不能为空，请重新输入。 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_TemporaryOldPwd.Focus();
                    return;
                }
                if (oldpwd.Length < tb_TemporaryOldPwd.MaxLength)
                {
                    MessageBox.Show(@" 旧密码长度不能小于 8 位，请重新输入。 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_TemporaryOldPwd.Focus();
                    return;
                }
            }

            if (pwd.Length == 0)
            {
                MessageBox.Show(@" 新密码不能为空，请重新输入。 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tb_TemporaryPwd.Focus();
                return;
            }
            if (pwd.Length < tb_TemporaryPwd.MaxLength)
            {
                MessageBox.Show(@" 新密码长度不能小于 8 位，请重新输入。 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tb_TemporaryPwd.Focus();
                return;
            }

            if (confirm.Length == 0)
            {
                MessageBox.Show(@" 确认密码不能为空，请重新输入。 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tb_ConfirmTemporaryPwd.Focus();
                return;
            }
            if (confirm.Length < tb_ConfirmTemporaryPwd.MaxLength)
            {
                MessageBox.Show(@" 确认密码长度不能小于 8 位，请重新输入。 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tb_ConfirmTemporaryPwd.Focus();
                return;
            }
            if (pwd != confirm)
            {
                MessageBox.Show(@" 新密码与确认密码不一致，请重新输入。 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tb_ConfirmTemporaryPwd.Focus();
                return;
            }

            #endregion 输入验证

            btn_TemporaryDevicePwdEnter.Enabled = false;
            try
            {
                byte[] by = PortAgreement.GetTemporaryEncryption(!cb_TemporaryWay.Checked ? pwd : oldpwd);
                _mPort.Write(by);
            }
            catch (Exception ex)
            {
                btn_TemporaryDevicePwdEnter.Enabled = true;
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_DefaultTemporaryNewPwd_CheckedChanged(object sender, EventArgs e)
        {
            bool result = !cb_DefaultTemporaryNewPwd.Checked;
            tb_TemporaryPwd.Enabled = result;
            tb_ConfirmTemporaryPwd.Enabled = result;
            if (!result)
            {
                string pwd = "FFFFFFFF";
                tb_TemporaryPwd.Text = pwd;
                tb_ConfirmTemporaryPwd.Text = pwd;
                btn_TemporaryDevicePwdEnter.Focus();
            }
            else
            {
                tb_TemporaryPwd.Text = string.Empty;
                tb_ConfirmTemporaryPwd.Text = string.Empty;
                tb_TemporaryPwd.Focus();
            }
        }

        private void cb_DefaultTemporaryOldPwd_CheckedChanged(object sender, EventArgs e)
        {
            bool result = !cb_DefaultTemporaryOldPwd.Checked;
            tb_TemporaryOldPwd.Enabled = result;
            if (!result)
            {
                tb_TemporaryOldPwd.Text = @"FFFFFFFF";
            }
            else
            {
                tb_TemporaryOldPwd.Text = string.Empty;
                tb_TemporaryOldPwd.Focus();
            }
        }

        private void cb_TemporaryWay_CheckedChanged(object sender, EventArgs e)
        {
            bool result = cb_TemporaryWay.Checked;
            cb_DefaultTemporaryOldPwd.Enabled = result;
            if (!cb_DefaultTemporaryOldPwd.Checked)
                tb_TemporaryOldPwd.Enabled = result;
            gb_Temporary.Text = result ? "临时IC卡加密" : "临时IC发卡器加密";
        }

        private void p_TemporaryInterface_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder(sender, e);
        }

        private void tb_ConfirmTemporaryPwd_KeyDown(object sender, KeyEventArgs e)
        {
            TemporaryPwdKeyDown(sender, e);
        }

        private void tb_TemporaryPwd_KeyDown(object sender, KeyEventArgs e)
        {
            TemporaryPwdKeyDown(sender, e);
        }

        private void TemporaryEncryptionResult(ParsingParameter parameter)
        {
            long result = DataParsing.TemporaryContent(parameter.DataContent);
            if (result == 0)
            {
                ShowEncryptionMessage("临时 IC 设备加密成功。", true, parameter.Command);
            }
            else
            {
                ShowEncryptionMessage("临时 IC 设备加密失败，请确认设备之间的通信是否正常。", true, parameter.Command);
            }
        }

        private void TemporaryIcEncryptionResult(ParsingParameter parameter)
        {
            long result = DataParsing.TemporaryContent(parameter.DataContent);
            ShowEncryptionMessage(result == 0 ? "临时 IC 卡加密成功。" : "临时 IC 卡加密失败，请确认旧密码是否正确。", true, parameter.Command);
        }

        private void TemporaryPwdKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (btn_TemporaryDevicePwdEnter.Enabled)
                btn_TemporaryDevicePwdEnter_Click(null, null);
        }

        #endregion 临时加密

        #endregion 加密操作

        #region 参数编录

        private void AddDevice(DeviceInfo dinfo)
        {
            DataTable dt = dgv_Device.DataSource as DataTable ?? GetDataTableHead<DeviceInfo>(dgv_Device);
            dt.Rows.Add();
            DataRow dr = dt.Rows[dt.Rows.Count - 1];
            UpdateRowData<DeviceInfo>(dinfo, dr);
        }

        private void btn_DeviceAdd_Click(object sender, EventArgs e)
        {
            using (DeviceAdd da = new DeviceAdd())
            {
                da.AddDevice += AddDevice;
                da.ShowDialog();
            }
        }

        private void btn_DeviceDel_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgv_Device.SelectedRows[0].Index;
                Int64 did = HexadecimalConversion.ObjToInt(dgv_Device.Rows[index].Cells["Did"].Value);
                DeviceInfo dinfo = DbHelper.Db.FirstDefault<DeviceInfo>(did);
                if (dinfo == null) return;
                if (
                    MessageBox.Show(string.Format("确认删除 {0} 设备信息吗？", dinfo.Did), @"提示", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Asterisk) != DialogResult.OK) return;
                DbHelper.Db.Del<DeviceInfo>(did);
                dgv_Device.Rows.RemoveAt(index);
                GetListSelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_DeviceEdit_Click(object sender, EventArgs e)
        {
            int index = dgv_Device.SelectedRows[0].Index;
            Int64 did = HexadecimalConversion.ObjToInt(dgv_Device.Rows[index].Cells["Did"].Value);
            using (DeviceEdit de = new DeviceEdit(did))
            {
                de.ShowDialog();
                DeviceInfo dinfo = de.Tag as DeviceInfo;
                if (dinfo != null)
                {
                    UpdateRowData<DeviceInfo>(dinfo, dgv_Device.Rows[index]);
                }
            }
        }

        private void btn_DeviceExport_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(" and ( ");
            foreach (DataGridViewRow row in dgv_Device.Rows)
            {
                object obj = row.Cells["c_Selected"].Value;
                if (obj == null) continue;
                if (!Convert.ToBoolean(obj)) continue;
                int id = Convert.ToInt32(row.Cells["Did"].Value);
                sb.AppendFormat(" {0} or", id);
            }
            sb = sb.Replace("or", ")", sb.Length - 2, 2);
            using (DeviceExport de = new DeviceExport(sb.ToString()))
            {
                de.ShowDialog();
            }
        }

        private void btn_DeviceImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openfile = new OpenFileDialog())
            {
                openfile.Title = @"导入选择";
                openfile.Filter = @"（文本文件）|*.txt";
                openfile.Multiselect = true;
                if (openfile.ShowDialog() != DialogResult.OK) return;
                using (DeviceImport di = new DeviceImport(openfile.FileNames))
                {
                    di.ShowDialog();
                    btn_ShowDeviceRecord_Click(null, null);
                }
            }
        }

        private void btn_DeviceFirst_Click(object sender, EventArgs e)
        {
            DeviceCurrentPage = 0;
        }

        private void btn_DeviceLast_Click(object sender, EventArgs e)
        {
            DeviceCurrentPage = _deviceCurrentPage - 1;
        }

        private void btn_DeviceNext_Click(object sender, EventArgs e)
        {
            DeviceCurrentPage += 1;
        }

        private void btn_DevicePrevious_Click(object sender, EventArgs e)
        {
            DeviceCurrentPage -= 1;
        }

        private void btn_ShowDeviceRecord_Click(object sender, EventArgs e)
        {
            try
            {
                int count = DbHelper.Db.GetCount<DeviceInfo>();
                int page = GetShowPage(count, l_DeviceRecordCount);
                _deviceCurrentPage = page;
                _devicePageCount = page;
                DeviceCurrentPage = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cb_AllSelected_MouseDown(object sender, MouseEventArgs e)
        {
            cb_AllSelected.ThreeState = false;
        }

        private void cb_AllSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelected.CheckState == CheckState.Indeterminate) return;
            bool check = cb_AllSelected.Checked;
            cb_AllSelected.Tag = check;
            for (int i = 0; i < dgv_Device.RowCount; i++)
            {
                dgv_Device.Rows[i].Cells["c_Selected"].Value = check;
            }
            btn_DeviceExport.Enabled = check;
            cb_AllSelected.Tag = null;
        }

        private void dgv_Device_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                btn_DeviceEdit_Click(null, null);
            }
        }

        private void dgv_Device_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 3:
                    e.Value = e.Value.Equals(0) ? "入口" : "出口";
                    break;

                case 5:
                    int openmodel = HexadecimalConversion.ObjToInt(e.Value);
                    switch (openmodel)
                    {
                        case 0:
                            e.Value = "畅泊：串口开闸";
                            break;

                        case 1:
                            e.Value = "畅泊：无线开闸";
                            break;

                        case 2:
                            e.Value = "学习遥控器开闸";
                            break;
                        case 3:
                            e.Value = "继电器开闸";
                            break;
                    }
                    break;

                case 6:
                    if (CRegex.IsDecimal(e.Value))
                    {
                        int dicimal = HexadecimalConversion.ObjToInt(e.Value);
                        if (dicimal == 0)
                        {
                            e.Value = "关闭";
                        }
                        else
                        {
                            e.Value = dicimal + " 分区";
                        }
                    }
                    break;

                case 7:
                case 8:
                    e.Value = e.Value.Equals(0) ? "关闭" : "开启";
                    break;

                case 9:
                    if (CRegex.IsDecimal(e.Value))
                    {
                        int distance = HexadecimalConversion.ObjToInt(e.Value);
                        switch (distance)
                        {
                            case 0:
                                e.Value = "1.2 米";
                                break;

                            case 1:
                                e.Value = "2.5 米";
                                break;

                            case 2:
                                e.Value = "3.8 米";
                                break;

                            case 3:
                                e.Value = "5 米";
                                break;
                        }
                    }
                    break;

                case 10:
                    if (CRegex.IsDecimal(e.Value))
                    {
                        int delay = HexadecimalConversion.ObjToInt(e.Value);
                        switch (delay)
                        {
                            case 0:
                                e.Value = "1 秒";
                                break;

                            case 1:
                                e.Value = "5 秒";
                                break;

                            case 2:
                                e.Value = "10 秒";
                                break;

                            case 3:
                                e.Value = "20 秒";
                                break;

                            case 4:
                                e.Value = "40 秒";
                                break;

                            case 5:
                                e.Value = "80 秒";
                                break;

                            case 6:
                                e.Value = "160 秒";
                                break;

                            case 7:
                                e.Value = "320 秒";
                                break;
                        }
                    }
                    break;

                case 11:
                    e.Value = e.Value.Equals(0) ? "关闭" : "开启";
                    break;

                case 14:
                    if (CRegex.IsDecimal(e.Value))
                    {
                        int language = HexadecimalConversion.ObjToInt(e.Value);
                        switch (language)
                        {
                            case 0:
                                e.Value = "普通话";
                                break;

                            case 1:
                                e.Value = "东北话";
                                break;

                            case 2:
                                e.Value = "四川话";
                                break;

                            case 3:
                                e.Value = "湖南话";
                                break;

                            case 4:
                                e.Value = "陕西话";
                                break;
                        }
                    }
                    break;
                case 15:
                    if (CRegex.IsDecimal(e.Value))
                    {
                        int fuzzyquery = HexadecimalConversion.ObjToInt(e.Value);
                        if (fuzzyquery == 0)
                        {
                            e.Value = "关闭";
                        }
                    }
                    break;
            }
        }

        private void dgv_Device_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0) return;
            if (cb_AllSelected.Tag != null) return;

            GetListSelected();
        }

        private void GetListSelected()
        {
            int count = 0;
            for (int i = 0; i < dgv_Device.RowCount; i++)
            {
                if (Convert.ToBoolean(dgv_Device.Rows[i].Cells["c_Selected"].Value))
                {
                    count++;
                }
            }

            cb_AllSelected.ThreeState = true;
            if (count == 0)
                cb_AllSelected.CheckState = CheckState.Unchecked;
            else if (count >= dgv_Device.RowCount)
                cb_AllSelected.CheckState = CheckState.Checked;
            else
                cb_AllSelected.CheckState = CheckState.Indeterminate;
            btn_DeviceExport.Enabled = count > 0;
        }

        private void dgv_Device_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_Device.IsCurrentCellDirty)
            {
                dgv_Device.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgv_Device_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btn_DeviceDel_Click(null, null);
            }
        }

        private void dgv_Device_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btn_DeviceEdit.Enabled = true;
            btn_DeviceDel.Enabled = true;
            if (cb_AllSelected.CheckState != CheckState.Unchecked)
            {
                cb_AllSelected.CheckState = CheckState.Unchecked;
            }
            cb_AllSelected.Enabled = true;
        }

        private void dgv_Device_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgv_Device.RowCount == 0)
            {
                btn_DeviceDel.Enabled = false;
                btn_DeviceEdit.Enabled = false;
                btn_DeviceExport.Enabled = false;
                if (cb_AllSelected.Checked)
                    cb_AllSelected.Checked = false;
            }
        }

        private void dgv_Device_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                cb_AllSelected.Location = new Point(7 - e.NewValue, cb_AllSelected.Location.Y);
            }
        }

        private void dgv_Device_SelectionChanged(object sender, EventArgs e)
        {
            bool result = dgv_Device.SelectedRows.Count > 0;
            btn_DeviceDel.Enabled = result;
            btn_DeviceEdit.Enabled = result;
        }

        private void tb_DevicePage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == 10)
            {
                int page = 0;
                if (tb_DevicePage.TextLength > 0)
                    page = Convert.ToInt32(tb_DevicePage.Text);
                if (page <= 0)
                    page = 0;
                if (page >= _devicePageCount)
                    page = _devicePageCount - 1;
                DeviceCurrentPage = page;
            }
            else if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else if (e.KeyChar < 47 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }

        #endregion 参数编录

        #region 无线测试

        private void btn_FrequencySearch_Click(object sender, EventArgs e)
        {
            btn_FrequencySearch.Enabled = false;
            btn_WirelessSet.Enabled = false;
            btn_Test.Enabled = false;
            btn_Query.Enabled = false;
            btn_TemporaryReadCard.Enabled = false;

            pb_FrequencySearch.Value = 0;
            pb_FrequencySearch.Maximum = 64;

            if (btn_FrequencySearch.Tag == null)
            {
                _tSearchFrequency = new Thread(ThreadSearchFrequency) { Name = "frequencysearch" };
                _tSearchFrequency.Start();

                btn_FrequencySearch.Text = @"终 止";
                btn_FrequencySearch.Tag = true;
                _isReadCard = false;
            }
            else
            {
                if (_tSearchFrequency != null)
                {
                    _tSearchFrequency.Abort();
                }
                btn_FrequencySearch.Text = @"搜 索";
                btn_FrequencySearch.Tag = null;
            }

            System.Timers.Timer timer = new System.Timers.Timer(1500) { AutoReset = false };
            timer.Elapsed += ControlDelayShow;
            timer.Start();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            btn_Query.Enabled = false;
            _isReadCard = false;

            OpenModule();

            ShowWirelessMessage("关闭回传功能");
            ModuleSetComesBack(0);
            if (!_isModuleSet)
            {
                ModuleSetComesBack(0);
                if (!_isModuleSet)
                {
                    ModuleSetComesBack(0);
                }
            }

            CloseModule();

            string str = "AT+FREQ?";
            byte[] by = PortAgreement.GetSetModule(str);
            if (_mPort.IsOpen)
            {
                _mPort.Write(by);
                Thread.Sleep(200);
            }

            str = "AT+TID?";
            by = PortAgreement.GetSetModule(str);
            if (_mPort.IsOpen)
            {
                _mPort.Write(by);
                Thread.Sleep(200);
            }

            btn_Query.Enabled = true;
            btn_TemporaryReadCard.Enabled = true;
        }

        private void btn_TemporaryReadCard_Click(object sender, EventArgs e)
        {
            btn_TemporaryReadCard.Enabled = false;
            try
            {
                if (_mPort.IsOpen)
                {
                    byte[] by = PortAgreement.GetReadTemporaryIC();
                    _mPort.Write(by);
                    _isReadCard = true;
                }
            }
            catch (Exception ex)
            {
                btn_TemporaryReadCard.Enabled = true;
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            btn_Test.Enabled = false;
            _isReadCard = false;
            int frequency = (int)ud_WirelessFrequency.Value;
            try
            {
                string str = string.Format("093D2446福A0000000{0:yyMMddHHmmss}", DateTime.Now);
                byte[] by = PortAgreement.GetOpenDoor(str);
                if (_mPort.IsOpen)
                {
                    _mPort.Write(by);
                }
                btn_Test.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_WirelessSet_Click(object sender, EventArgs e)
        {
            btn_WirelessSet.Enabled = false;
            btn_FrequencySearch.Enabled = false;
            btn_Test.Enabled = false;
            btn_Query.Enabled = false;
            btn_TemporaryReadCard.Enabled = false;

            _isReadCard = false;
            Thread thread = new Thread(ThreadSetModule);
            thread.Start();
        }

        private void ud_WirelessId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btn_WirelessSet.Enabled)
                    btn_WirelessSet_Click(null, null);
            }
        }

        private void CloseModule()
        {
            ShowWirelessMessage("关闭模块设置");
            byte[] by = PortAgreement.GetCloseModule();
            if (_mPort.IsOpen)
            {
                _mPort.Write(by);
                Thread.Sleep(20);
            }
        }

        private void ControlDelayShow(object sender, System.Timers.ElapsedEventArgs e)
        {
            btn_FrequencySearch.Enabled = true;
        }

        private void dgv_WirelessDescription_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgv_WirelessDescription.FirstDisplayedScrollingRowIndex = e.RowIndex;
        }

        private void ModuleSetComesBack(int openonclose)
        {
            _isModuleSet = false;
            string str = "AT+BACK=" + openonclose;
            byte[] by = PortAgreement.GetSetModule(str);
            if (_mPort.IsOpen)
            {
                _mPort.Write(by);
                Thread.Sleep(200);
            }
        }

        private void ModuleSetFrequency(int frequency)
        {
            _isModuleSet = false;
            frequency = 127 - (frequency * 2 - 1);
            string str = string.Format("AT+FREQ={0:X2}", frequency);
            byte[] by = PortAgreement.GetSetModule(str);
            if (_mPort.IsOpen)
            {
                _mPort.Write(by);
                Thread.Sleep(200);
            }
        }

        private void ModuleSetRid()
        {
            _isModuleSet = false;
            decimal id = ud_WirelessId.Value;
            string str = string.Format("AT+RID=01{0}", id.ToString(CultureInfo.InvariantCulture).PadLeft(8, '0'));
            byte[] by = PortAgreement.GetSetModule(str);
            if (_mPort.IsOpen)
            {
                _mPort.Write(by);
                Thread.Sleep(200);
            }
        }

        private void ModuleSetTid()
        {
            _isModuleSet = false;
            decimal id = ud_WirelessId.Value;
            string str = string.Format("AT+TID=01{0}", id.ToString(CultureInfo.InvariantCulture).PadLeft(8, '0'));
            byte[] by = PortAgreement.GetSetModule(str);
            if (_mPort.IsOpen)
            {
                _mPort.Write(by);
                Thread.Sleep(200);
            }
        }

        private void ModuleTest()
        {
            _isModuleSet = false;
            byte[] by = PortAgreement.GetSetModule("ABCDEF");
            if (_mPort.IsOpen)
            {
                _mPort.Write(by);
                Thread.Sleep(200);
            }
        }

        private void OpenModule()
        {
            ShowWirelessMessage("打开模块设置");
            byte[] by = PortAgreement.GetOpenModule();
            if (_mPort.IsOpen)
            {
                _mPort.Write(by);
                Thread.Sleep(20);
            }
        }

        private void p_Tap4_VisibleChanged(object sender, EventArgs e)
        {
            if (_mPort == null || !_mPort.IsOpen) return;
            if (!_isReadCard) return;
            try
            {
                byte[] by = PortAgreement.GetCloseModule();
                _mPort.Write(@by);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_TemporaryReadCard.Enabled = true;
            }
        }

        private void p_Wireless_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(Brushes.Gray, 1), p_Wireless.Width - 1, 0, p_Wireless.Width - 1, p_Wireless.Height);
            g.Dispose();
        }

        private void QueryFrequncy(int frequncy)
        {
            dgv_WirelessDescription.Invoke(new EventHandler(delegate
            {
                frequncy = 64 - (frequncy / 2);
                ShowWirelessMessage(string.Format("查询模块频率为:{0} 组", frequncy));
            }));
        }

        private void QueryWireless(long id)
        {
            dgv_WirelessDescription.Invoke(new EventHandler(delegate
            {
                ShowWirelessMessage(string.Format("查询模块ID为:{0:X8}", id));
            }));
        }

        private void ShowIcCardContent(IcCardParameter info)
        {
            dgv_WirelessDescription.Invoke(new EventHandler(delegate
            {
                string message = string.Format("IC卡号：{0} 车牌号码：{1} 时间：{2}", info.IcNumber, info.Plate, info.Time);
                WirelessAddRow(message);
            }));
        }

        private void ShowWirelessMessage(string message)
        {
            dgv_WirelessDescription.Invoke(new EventHandler(delegate
            {
                WirelessAddRow(message);
            }));
        }

        private void ThreadSearchFrequency()
        {
            bool isend;
            int frequency = 0;
            bool isback = false;
            try
            {
                for (int i = 1; i <= 64; i++)
                {
                    isend = false;

                    dgv_WirelessDescription.Invoke(new EventHandler(delegate
                    {
                        pb_FrequencySearch.PerformStep();
                    }));

                    OpenModule();

                    #region 频率

                    ShowWirelessMessage(string.Format("设置模块第 {0} 组频率", i));
                    ModuleSetFrequency(i);
                    if (!_isModuleSet)
                    {
                        ShowWirelessMessage("第二次设置模块频率");
                        ModuleSetFrequency(i);
                        if (!_isModuleSet)
                        {
                            ShowWirelessMessage("第三次设置模块频率");
                            ModuleSetFrequency(i);
                            if (!_isModuleSet)
                            {
                                ShowWirelessMessage(string.Format("第 {0} 组频率设置失败，进行下一组设置", i));
                                isend = true;
                            }
                        }
                    }

                    #endregion 频率

                    #region 回传

                    if (!isend && !isback)
                    {
                        ModuleSetComesBack(1);
                        if (!_isModuleSet)
                        {
                            ShowWirelessMessage("第二次设置模块回传功能");
                            ModuleSetComesBack(1);
                            if (!_isModuleSet)
                            {
                                ShowWirelessMessage("第三次设置模块回传功能");
                                ModuleSetComesBack(1);
                                if (!_isModuleSet)
                                {
                                    ShowWirelessMessage("模块回传功能设置失败，退出设置");
                                    isend = true;
                                }
                                else
                                    isback = true;
                            }
                            else
                                isback = true;
                        }
                        else
                            isback = true;
                    }

                    #endregion 回传

                    CloseModule();

                    #region 测试

                    if (!isend)
                    {
                        ShowWirelessMessage("测试");
                        ModuleTest();
                        if (!_isModuleSet)
                        {
                            ShowWirelessMessage("第二次测试");
                            ModuleTest();
                            if (!_isModuleSet)
                            {
                                ShowWirelessMessage("第三次测试");
                                ModuleTest();
                                if (!_isModuleSet)
                                {
                                    ShowWirelessMessage("测试失败");
                                    isend = true;
                                }
                            }
                        }
                    }

                    #endregion 测试

                    if (!isend)
                    {
                        frequency = i;
                        break;
                    }
                }
            }
            finally
            {
                CloseModule();

                dgv_WirelessDescription.Invoke(new EventHandler(delegate
                {
                    if (frequency > 0)
                    {
                        btn_FrequencySearch.Text = @"搜 索";
                        btn_FrequencySearch.Tag = null;
                        ud_WirelessFrequency.Value = frequency;
                        ShowWirelessMessage(string.Format("频率搜索成功，当前使用第 {0} 组频率", frequency));
                    }
                    else
                    {
                        ShowWirelessMessage("频率搜索失败，请查看ID是否正确或连接设备是否打开。");
                    }
                    btn_Query.Enabled = true;
                    btn_WirelessSet.Enabled = true;
                    btn_Test.Enabled = true;
                    btn_TemporaryReadCard.Enabled = true;
                }));

                _tSearchFrequency = null;
            }
        }

        private void ThreadSetModule()
        {
            bool isend = false;
            try
            {
                OpenModule();

                #region 发送ID

                ShowWirelessMessage("设置模块发送ID");
                ModuleSetTid();
                if (!_isModuleSet)
                {
                    ShowWirelessMessage("第二次设置模块发送ID");
                    ModuleSetTid();
                    if (!_isModuleSet)
                    {
                        ShowWirelessMessage("第三次设置模块发送ID");
                        ModuleSetTid();
                        if (!_isModuleSet)
                        {
                            ShowWirelessMessage("模块发送ID设置失败，退出设置");
                            isend = true;
                        }
                    }
                }

                #endregion 发送ID

                #region 接收ID

                if (!isend)
                {
                    ShowWirelessMessage("设置模块接收ID");
                    ModuleSetRid();
                    if (!_isModuleSet)
                    {
                        ShowWirelessMessage("第二次设置模块接收ID");
                        ModuleSetRid();
                        if (!_isModuleSet)
                        {
                            ShowWirelessMessage("第三次设置模块接收ID");
                            ModuleSetRid();
                            if (!_isModuleSet)
                            {
                                ShowWirelessMessage("模块接收ID设置失败，退出设置");
                                isend = true;
                            }
                        }
                    }
                }

                #endregion 接收ID

                #region 频率

                if (!isend)
                {
                    int frequency = (int)ud_WirelessFrequency.Value;
                    ShowWirelessMessage(string.Format("设置模块第 {0} 组频率", frequency));
                    ModuleSetFrequency(frequency);
                    if (!_isModuleSet)
                    {
                        ShowWirelessMessage("第二次设置模块频率");
                        ModuleSetFrequency(frequency);
                        if (!_isModuleSet)
                        {
                            ShowWirelessMessage("第三次设置模块频率");
                            ModuleSetFrequency(frequency);
                            if (!_isModuleSet)
                            {
                                ShowWirelessMessage("模块频率设置失败，退出设置");
                                isend = true;
                            }
                        }
                    }
                }

                #endregion 频率

                #region 回传

                if (!isend)
                {
                    ShowWirelessMessage("设置模块回传功能");
                    ModuleSetComesBack(1);
                    if (!_isModuleSet)
                    {
                        ShowWirelessMessage("第二次设置模块回传功能");
                        ModuleSetComesBack(1);
                        if (!_isModuleSet)
                        {
                            ShowWirelessMessage("第三次设置模块回传功能");
                            ModuleSetComesBack(1);
                            if (!_isModuleSet)
                            {
                                ShowWirelessMessage("模块回传功能设置失败，退出设置");
                                isend = true;
                            }
                        }
                    }
                }

                #endregion 回传

                CloseModule();

                #region 发送数据测试

                if (!isend)
                {
                    ShowWirelessMessage("测试");
                    ModuleTest();
                    if (!_isModuleSet)
                    {
                        ShowWirelessMessage("第二次测试");
                        ModuleTest();
                        if (!_isModuleSet)
                        {
                            ShowWirelessMessage("第三次测试");
                            ModuleTest();
                            if (!_isModuleSet)
                            {
                                ShowWirelessMessage("测试失败");
                                isend = true;
                            }
                        }
                    }
                }

                #endregion 发送数据测试
            }
            catch (Exception ex)
            {
                ShowWirelessMessage(ex.Message);
            }
            finally
            {
                dgv_WirelessDescription.Invoke(new EventHandler(delegate
                {
                    btn_WirelessSet.Enabled = true;
                    btn_FrequencySearch.Enabled = true;
                    btn_Test.Enabled = true;
                    btn_Query.Enabled = true;
                    btn_TemporaryReadCard.Enabled = true;

                    btn_WirelessSet.Image = !isend ? Properties.Resources.check : Properties.Resources.block;
                }));
            }
        }

        private void WirelessAddRow(string message)
        {
            if (dgv_WirelessDescription.RowCount >= 30)
                dgv_WirelessDescription.Rows.RemoveAt(0);
            dgv_WirelessDescription.Rows.Add(new object[] { message });
        }

        #endregion 无线测试

        #region 公共方法

        private void AddRange<T>(List<T> cardinfos, DataGridView dgv)
        {
            int count = cardinfos.Count;
            if (count <= 0) return;
            DataTable dt = dgv.DataSource as DataTable;
            if (dt == null)
                dgv.Rows.Add(count);
            else
                dt.Rows.Add(count);
            PropertyInfo[] pis =
    typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            for (int i = 0; i < count; i++)
            {
                if (dt == null)
                {
                    DataGridViewRow dr = dgv.Rows[i];
                    foreach (PropertyInfo pi in pis)
                    {
                        dr.Cells[pi.Name].Value = pi.GetValue(cardinfos[i], null);
                    }
                }
                else
                {
                    DataRow dr = dt.Rows[i];
                    foreach (PropertyInfo pi in pis)
                    {
                        dr[pi.Name] = pi.GetValue(cardinfos[i], null);
                    }
                }
            }
        }

        private T GetDataInfo<T>(int index, DataGridView dgv)
        {
            DataTable dt = dgv.DataSource as DataTable;
            PropertyInfo[] pis = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            T t = Activator.CreateInstance<T>();
            foreach (PropertyInfo item in pis)
            {
                if (dt != null)
                {
                    object obj = dt.Rows[index][item.Name];
                    item.SetValue(t, obj, null);
                }
            }
            return t;
        }

        private Dictionary<int, T> GetDataInfo<T>(DataGridView dgv)
        {
            DataTable dt = dgv.DataSource as DataTable;
            PropertyInfo[] pis = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            Dictionary<int, T> dic = new Dictionary<int, T>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                T t = Activator.CreateInstance<T>();
                foreach (PropertyInfo item in pis)
                {
                    item.SetValue(t, row.Cells[item.Name].Value, null);
                }
                dic.Add(row.Index, t);
            }
            return dic;
        }

        private DataTable GetDataTableHead<T>(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] pis =
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (PropertyInfo item in pis)
            {
                dt.Columns.Add(item.Name, item.PropertyType);
            }
            dgv.DataSource = dt;
            return dt;
        }

        private int GetShowPage(int count, Label lcount)
        {
            int page = count / 30;
            if (count % 30 > 0)
                page++;
            lcount.Text = string.Format("共 {0} 条记录，共 {1} 页", count, page);
            return page;
        }

        private void UpdateRowData<T>(T info, DataGridViewRow dr)
        {
            PropertyInfo[] pis =
    typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (PropertyInfo item in pis)
            {
                dr.Cells[item.Name].Value = item.GetValue(info, null);
            }
        }

        private void UpdateRowData<T>(T info, DataRow dr)
        {
            PropertyInfo[] pis =
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (PropertyInfo item in pis)
            {
                dr[item.Name] = item.GetValue(info, null);
            }
        }

        #endregion 公共方法

    }
}