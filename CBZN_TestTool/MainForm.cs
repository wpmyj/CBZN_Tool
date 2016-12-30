using Bll;
using Dal;
using Model;
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

namespace CBZN_TestTool
{
    public partial class MainForm : Form
    {
        #region 变量

        private readonly Dictionary<string, int> _dicDataList = new Dictionary<string, int>();

        private bool _isLossMouseDown;
        private bool _isLossMouseEnter;
        private Point _LossMousePoint;
        private bool _isModuleSet;
        private bool _isMouseDown1;
        private bool _isMouseDown2;
        private bool _isMouseDown3;
        private bool _isMouseDown4;
        private bool _isMouseDown5;
        private bool _isMouseDown6;
        private bool _isMouseEnter1;
        private bool _isMouseEnter2;
        private bool _isMouseEnter3;
        private bool _isMouseEnter4;
        private bool _isMouseEnter5;
        private bool _isMouseEnter6;
        private bool _isReadCard;
        private bool _isThreadClose;
        private int _lossCount = 0;
        private ComPortHelper _mComPort;
        private Mutex _mMutex;
        private PortHelper _mPort;
        private RegisterParam? _registerParam;
        private string _strSearchWhere;
        private System.Timers.Timer _tiConnectionPort;
        private List<CardInfo> _lossCards;

        private delegate void DefaultShow();

        #endregion 变量

        #region 窗体事件

        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_Tap1_Click(object sender, EventArgs e)
        {
            AcceptButton = btn_Read;
            ShowHideTap(btn_Tap1);
        }

        private void btn_Tap1_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown1 = true;
        }

        private void btn_Tap1_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnter1 = true;
        }

        private void btn_Tap1_MouseLeave(object sender, EventArgs e)
        {
            _isMouseEnter1 = false;
            _isMouseDown1 = false;
        }

        private void btn_Tap1_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown1 = false;
        }

        private void btn_Tap1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = DrawButton(g, btn_Tap1, _isMouseDown1, _isMouseEnter1);
            DrawRightSelect(g, rect, btn_Tap1.Enabled);
        }

        private void btn_Tap2_Click(object sender, EventArgs e)
        {
            AcceptButton = btn_TemporaryDevicePwdEnter;
            ShowHideTap(btn_Tap2);
        }

        private void btn_Tap2_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown2 = true;
        }

        private void btn_Tap2_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnter2 = true;
        }

        private void btn_Tap2_MouseLeave(object sender, EventArgs e)
        {
            _isMouseDown2 = false;
            _isMouseEnter2 = false;
        }

        private void btn_Tap2_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown2 = false;
        }

        private void btn_Tap2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = DrawButton(g, btn_Tap2, _isMouseDown2, _isMouseEnter2);
            DrawRightSelect(g, rect, btn_Tap2.Enabled);
        }

        private void btn_Tap3_Click(object sender, EventArgs e)
        {
            AcceptButton = null;
            ShowHideTap(btn_Tap3);
            if (dgv_Device.DataSource as DataTable == null)
            {
                btn_ShowDeviceRecord_Click(null, null);
            }
        }

        private void btn_Tap3_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown3 = true;
        }

        private void btn_Tap3_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnter3 = true;
        }

        private void btn_Tap3_MouseLeave(object sender, EventArgs e)
        {
            _isMouseEnter3 = false;
            _isMouseDown3 = false;
        }

        private void btn_Tap3_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown3 = false;
        }

        private void btn_Tap3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = DrawButton(g, btn_Tap3, _isMouseDown3, _isMouseEnter3);
            DrawRightSelect(g, rect, btn_Tap3.Enabled);
        }

        private void btn_Tap4_Click(object sender, EventArgs e)
        {
            AcceptButton = null;
            ShowHideTap(btn_Tap4);
        }

        private void btn_Tap4_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown4 = true;
        }

        private void btn_Tap4_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnter4 = true;
        }

        private void btn_Tap4_MouseLeave(object sender, EventArgs e)
        {
            _isMouseDown4 = false;
            _isMouseEnter4 = false;
        }

        private void btn_Tap4_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown4 = false;
        }

        private void btn_Tap4_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = DrawButton(g, btn_Tap4, _isMouseDown4, _isMouseEnter4);
            DrawRightSelect(g, rect, btn_Tap4.Enabled);
        }

        private void DrawBorderLine(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p == null) return;
            Graphics g = e.Graphics;
            Point[] ps = new Point[]{
                new Point(0 , p.Height - 1),
                new Point(p.Width - 1 , p.Height - 1),
                new Point(p.Width - 1 , 0)
            };
            g.DrawLines(new Pen(Brushes.Gray, 1), ps);
            g.Dispose();
        }

        private void DrawBottomSelect(Graphics g, Rectangle rect, bool enabled)
        {
            if (enabled) return;
            GraphicsPath path = new GraphicsPath();
            int width = rect.Width / 2;
            path.AddLines(new Point[]
            {
                new Point(width, rect.Height-5),
                new Point(width+5,rect.Height),
                new Point(width-5,rect.Height),
                new Point(width,rect.Height- 5)
            });
            g.FillPath(Brushes.White, path);
        }

        private Rectangle DrawButton(Graphics g, Button btn, bool isdown, bool isenter)
        {
            SolidBrush backcolor = new SolidBrush(btn.BackColor);
            if (isdown || !btn.Enabled)
            {
                backcolor = new SolidBrush(btn.FlatAppearance.MouseDownBackColor);
            }
            else if (isenter)
            {
                backcolor = new SolidBrush(btn.FlatAppearance.MouseOverBackColor);
            }

            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
            g.FillRectangle(backcolor, rect);

            StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString(btn.Text, btn.Font, new SolidBrush(btn.ForeColor), rect, sf);

            return rect;
        }

        private void DrawRightSelect(Graphics g, Rectangle rect, bool enabled)
        {
            if (enabled) return;
            GraphicsPath path = new GraphicsPath();
            int height = rect.Height / 2;
            path.AddLines(new Point[]
            {
                new Point(rect.Width-10,height),
                new Point(rect.Width,height-10),
                new Point(rect.Width,height+10),
                new Point(rect.Width-10,height)
            });
            g.FillPath(Brushes.White, path);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ShowHideTap(Button btn)
        {
            ShowSelectedEffect(btn);
            p_Tap1.Visible = btn == btn_Tap1;
            p_Tap2.Visible = btn == btn_Tap2;
            p_Tap3.Visible = btn == btn_Tap3;
            p_Tap4.Visible = btn == btn_Tap4;
        }

        private void ShowSelectedEffect(Button btn)
        {
            Color c = Color.Transparent;
            if (!btn_Tap1.Enabled)
            {
                btn_Tap1.Enabled = true;
            }
            if (!btn_Tap2.Enabled)
            {
                btn_Tap2.Enabled = true;
            }
            if (!btn_Tap3.Enabled)
            {
                btn_Tap3.Enabled = true;
            }
            if (!btn_Tap4.Enabled)
            {
                btn_Tap4.Enabled = true;
            }

            btn.Enabled = false;
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
                    _mPort.IsOpen = false;
                    try
                    {
                        _mPort.Close();
                    }
                    catch
                    {
                        // ignored
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
                                        DefaultShow ds = delegate
                                        {
                                            btn_Read.Enabled = true;
                                            dgv_DataList_SelectionChanged(null, null);
                                            l_RecordCount.Text = string.Format("总共 {0} 条记录", dgv_DataList.RowCount);
                                        };
                                        btn_Read.Invoke(ds);
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
                                        if (cardinfo.CardType != 8 || cardinfo.CardType != 15)
                                        {
                                            DistanceDataParameter dataparameter =
                                                    DataParsing.DistanceData(parameter.DataContent);
                                            if (cardinfo.CardReportLoss == 0)
                                                cardinfo.CardReportLoss = dataparameter.FunctionByteParameter.Loss;
                                            cardinfo.Synchronous = dataparameter.FunctionByteParameter.Synchronous;
                                            cardinfo.InOutState = dataparameter.FunctionByteParameter.InOutState;
                                            if (cardinfo.Cid > 0)
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
                                    else if (CardLoss.IsShow)
                                    {
                                        CardLoss cl = CardLoss.CurrentForm;
                                        cl.PortDataReceived(distanceparameter);
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

        private void PortOpenAndCloseChange(object e, bool value)
        {
            DefaultShow ds = delegate
            {
                if (value)
                {
                    dgv_DataList_SelectionChanged(null, null);
                }
                else
                {
                    btn_Register.Enabled = false;
                    btn_Registers.Enabled = false;
                    btn_ReportTheLossOf.Enabled = false;
                }
                btn_Read.Enabled = value;
                btn_DistanceDeviceEnter.Enabled = value;
                btn_TemporaryDevicePwdEnter.Enabled = value;
                btn_TemporaryReadCard.Enabled = value;
                btn_WirelessSet.Enabled = value;
                btn_FrequencySearch.Enabled = value;
                btn_Query.Enabled = value;
                btn_Test.Enabled = value;
            };
            btn_Read.Invoke(ds);
        }

        #endregion 端口事件

        #region 卡片操作

        private void br_Registercomplete(int index, CardInfo info)
        {
            if (index > -1 && index < dgv_DataList.RowCount)
            {
                UpdateRowData<CardInfo>(info, dgv_DataList.Rows[index]);
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            cb_Page.SelectedIndex += 1;
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            cb_Page.SelectedIndex -= 1;
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            //dgv_DataList.Rows.Clear();
            DataTable dt = dgv_DataList.DataSource as DataTable;
            if (dt != null)
                dt.Rows.Clear();
            _dicDataList.Clear();

            btn_Read.Enabled = false;
            cb_Page.Items.Clear();
            cb_Page.SelectedIndex = -1;
            try
            {
                byte[] by = PortAgreement.GetReadAllCard();
                _mPort.Write(by);
            }
            catch (Exception ex)
            {
                btn_Read.Enabled = true;
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (dgv_DataList.SelectedRows.Count == 0) return;
            int index = dgv_DataList.SelectedRows[0].Index;

            CardInfo info = GetDataInfo<CardInfo>(index, dgv_DataList);
            Dictionary<int, CardInfo> datalistinfo = GetDataInfo<CardInfo>(dgv_DataList);
            Dictionary<int, CardInfo> viceinfos = new Dictionary<int, CardInfo>();
            foreach (KeyValuePair<int, CardInfo> item in datalistinfo)
            {
                if (item.Value.CardType == 3)
                {
                    viceinfos.Add(item.Key, item.Value);
                }
            }

            using (DistanceRegister dr = DistanceRegister.Instance)
            {
                dr._mCardInfo = info;
                dr._mViceCardInfo = viceinfos;
                dr._mPort = _mPort;
                dr.ViceCardUpdate += Dr_ViceCardUpdate;
                dr.ShowDialog();
                if (dr.Tag == null) return;
                info = dr.Tag as CardInfo;
                UpdateRowData<CardInfo>(info, dgv_DataList.Rows[index]);
            }
        }

        private void btn_Registers_Click(object sender, EventArgs e)
        {
            Dictionary<int, CardInfo> datalistinfo = GetDataInfo<CardInfo>(dgv_DataList);
            Dictionary<int, CardInfo> registerlist = new Dictionary<int, CardInfo>();
            foreach (KeyValuePair<int, CardInfo> item in datalistinfo)
            {
                if (item.Value.Cid > 0) continue;
                if (item.Value.CardType > 4) continue;
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
                    if (br.Tag == null) return;
                    RegisterParam rp = (RegisterParam)br.Tag;
                    _registerParam = rp;
                }
            }
            else
            {
                MessageBox.Show(@"列表中无需注册的定距卡", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_ReportTheLossOf_Click(object sender, EventArgs e)
        {
            int height = btn_ReportTheLossOf.Height;
            Rectangle leftrect = new Rectangle(0, 0, 100, height);
            Rectangle rightrect = new Rectangle(100, 0, 50, height);
            if (_lossCards == null)
                _lossCards = new List<CardInfo>();
            if (leftrect.Contains(_LossMousePoint))
            {
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
                _lossCount++;
            }
            else if (rightrect.Contains(_LossMousePoint))
            {
                Point screenpoint = this.PointToScreen(btn_ReportTheLossOf.Location);
                CardLoss cl = CardLoss.CurrentForm;
                cl.LossComplete += cl_LossComplete;
                cl.Port = _mPort;
                cl.LossCards = _lossCards;
                cl.LossCountChange += cl_LossCountChange;
                cl.Show();
                cl.Location = new Point(screenpoint.X + 160, screenpoint.Y + 80);
            }
        }

        private void cl_LossCountChange(int count)
        {
            _lossCount = count;
            btn_ReportTheLossOf.Invalidate();
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

        private void cl_LossComplete()
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

        private void btn_ReportTheLossOf_MouseDown(object sender, MouseEventArgs e)
        {
            _isLossMouseDown = true;
        }

        private void btn_ReportTheLossOf_MouseEnter(object sender, EventArgs e)
        {
            _isLossMouseEnter = true;
        }

        private void btn_ReportTheLossOf_MouseLeave(object sender, EventArgs e)
        {
            _isLossMouseDown = false;
            _isLossMouseEnter = false;
        }

        private void btn_ReportTheLossOf_MouseMove(object sender, MouseEventArgs e)
        {
            _LossMousePoint = e.Location;

            btn_ReportTheLossOf.Invalidate();
        }

        private void btn_ReportTheLossOf_MouseUp(object sender, MouseEventArgs e)
        {
            _isLossMouseDown = false;
        }

        private void btn_ReportTheLossOf_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            Color leftcolor = btn_ReportTheLossOf.BackColor;
            Color rightcolor = btn_ReportTheLossOf.BackColor;

            int height = btn_ReportTheLossOf.Height;

            Rectangle leftrect = new Rectangle(0, 0, 100, height);
            Rectangle rightrect = new Rectangle(100, 0, 50, height);

            if (!btn_ReportTheLossOf.Enabled)
            {
                leftcolor = Color.FromArgb(160, 160, 160);
                rightcolor = leftcolor;
            }
            else
            {
                if (_isLossMouseDown)
                {
                    leftcolor = btn_ReportTheLossOf.FlatAppearance.MouseDownBackColor;
                    rightcolor = leftcolor;
                }
                else if (_isLossMouseEnter)
                {
                    leftcolor = btn_ReportTheLossOf.FlatAppearance.MouseOverBackColor;
                    rightcolor = leftcolor;
                }

                if (leftrect.Contains(_LossMousePoint))
                {
                    rightcolor = btn_ReportTheLossOf.BackColor;
                }
                else if (rightrect.Contains(_LossMousePoint))
                {
                    leftcolor = btn_ReportTheLossOf.BackColor;
                }
            }

            g.FillRectangle(new SolidBrush(leftcolor), leftrect);
            g.FillRectangle(new SolidBrush(rightcolor), rightrect);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            g.DrawString(btn_ReportTheLossOf.Text, btn_ReportTheLossOf.Font, new SolidBrush(btn_ReportTheLossOf.ForeColor), leftrect, sf);

            g.DrawLine(new Pen(Color.Gray, 1), 100, 0, 100, leftrect.Height);

            leftcolor = _lossCount > 0 ? Color.FromArgb(240, 60, 0) : Color.FromArgb(160, 160, 160);

            g.FillPie(new SolidBrush(leftcolor), new Rectangle(leftrect.Width + rightrect.Width / 2 - 12, height / 2 - 12, 24, 24), 0, 360);

            g.DrawString(_lossCount.ToString(), btn_ReportTheLossOf.Font, new SolidBrush(btn_ReportTheLossOf.ForeColor), rightrect, sf);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string searchcontent = tb_Search.Text.Trim();
            if (searchcontent.Length == 0)
                return;
            string strwhere = string.Format(" and CardNumber='%{0}%' ", searchcontent);
            ShowRecord(strwhere);
        }

        private void btn_ShowRecord_Click(object sender, EventArgs e)
        {
            ShowRecord(string.Empty);
        }

        private void cb_Page_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cb_Page.SelectedIndex;

            btn_Previous.Enabled = index != 0;
            btn_Next.Enabled = index != cb_Page.Items.Count - 1;

            try
            {
                if (index > -1)
                {
                    //dgv_DataList.Rows.Clear();
                    //List<CardInfo> cardinfos = DbHelper.Db.ToList<CardInfo>(index * 30, 30, _strSearchWhere);
                    DataTable dt = DbHelper.Db.ToTable<CardInfo>(index * 30, 30, _strSearchWhere);
                    //AddRange(cardinfos, dgv_DataList);
                    dgv_DataList.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                btn_ReportTheLossOf.Enabled = true;
                if (dgv_DataList.SelectedRows.Count > 0)
                {
                    int index = dgv_DataList.SelectedRows[0].Index;
                    CardInfo info = GetDataInfo<CardInfo>(index, dgv_DataList);
                    btn_Register.Enabled = info.CardType < 3;
                    //btn_ReportTheLossOf.Enabled = info.Cid != 0 && (info.CardReportLoss == 0);
                }
            }
        }

        private void Dr_ViceCardUpdate(int rowindex, CardInfo info)
        {
            if (rowindex > -1 && rowindex < dgv_DataList.RowCount)
            {
                UpdateRowData<CardInfo>(info, dgv_DataList.Rows[rowindex]);
            }
        }

        private void ShowReadCardInfo(CardInfo info)
        {
            DefaultShow ds = delegate
            {
                if (_dicDataList.ContainsKey(info.CardNumber)) return;
                DataTable dt = dgv_DataList.DataSource as DataTable ?? GetDataTableHead<CardInfo>(dgv_DataList);
                dt.Rows.Add();
                DataRow dr = dt.Rows[dt.Rows.Count - 1];
                UpdateRowData<CardInfo>(info, dr);
                _dicDataList.Add(info.CardNumber, info.CardType);
            };
            dgv_DataList.BeginInvoke(ds);
        }

        private void ShowRecord(string where)
        {
            try
            {
                _strSearchWhere = " and Cid > 0 " + where;
                int count = DbHelper.Db.GetCount<CardInfo>(_strSearchWhere);
                ShowPage(count, cb_Page, l_RecordCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tb_Search_KeyDown(object sender, KeyEventArgs e)
        {
            btn_Search_Click(null, null);
        }

        #endregion 卡片操作

        #region 加密操作

        private void btn_TapDistanceEncryption_Click(object sender, EventArgs e)
        {
            ShowHideEncryptionTap(btn_TapDistanceEncryption);
            AcceptButton = btn_DistanceDeviceEnter;
        }

        private void btn_TapDistanceEncryption_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _isMouseDown5 = true;
        }

        private void btn_TapDistanceEncryption_MouseEnter(object sender, System.EventArgs e)
        {
            _isMouseEnter5 = true;
        }

        private void btn_TapDistanceEncryption_MouseLeave(object sender, System.EventArgs e)
        {
            _isMouseDown5 = false;
            _isMouseEnter5 = false;
        }

        private void btn_TapDistanceEncryption_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _isMouseDown5 = false;
        }

        private void btn_TapDistanceEncryption_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = DrawButton(g, btn_TapDistanceEncryption, _isMouseDown5, _isMouseEnter5);
            DrawBottomSelect(g, rect, btn_TapDistanceEncryption.Enabled);
        }

        private void btn_TapTemporaryEncryption_Click(object sender, EventArgs e)
        {
            ShowHideEncryptionTap(btn_TapTemporaryEncryption);
            AcceptButton = btn_TemporaryDevicePwdEnter;
        }

        private void btn_TapTemporaryEncryption_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _isMouseDown6 = true;
        }

        private void btn_TapTemporaryEncryption_MouseEnter(object sender, System.EventArgs e)
        {
            _isMouseEnter6 = true;
        }

        private void btn_TapTemporaryEncryption_MouseLeave(object sender, System.EventArgs e)
        {
            _isMouseDown6 = false;
            _isMouseEnter6 = false;
        }

        private void btn_TapTemporaryEncryption_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _isMouseDown6 = false;
        }

        private void btn_TapTemporaryEncryption_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = DrawButton(g, btn_TapTemporaryEncryption, _isMouseDown6, _isMouseEnter6);
            DrawBottomSelect(g, rect, btn_TapTemporaryEncryption.Enabled);
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
            DefaultShow ds = delegate
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
            };
            this.Invoke(ds);
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

        private void btn_DistanceDeviceEnter_Click(object sender, EventArgs e)
        {
            string oldpwd = string.Empty;
            string pwd = tb_DistancePwd.Text;
            string confirm = tb_ConfirmDistancePwd.Text;

            #region 验证输入

            if (tb_DistanceOldPwd.Enabled)
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
            tb_DistanceOldPwd.Enabled = result;
            cb_DefaultDistanOldPwd.Enabled = result;
            gb_Distance.Text = result ? "定距卡加密" : "定距发卡器加密";
        }

        private void DistanceCardEncryptionResult(DistanceParameter parameter)
        {
            switch (parameter.AuxiliaryCommand)
            {
                case 0:
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

        private void btn_TemporaryDevicePwdEnter_Click(object sender, EventArgs e)
        {
            string oldpwd = string.Empty;
            string pwd = tb_TemporaryPwd.Text;
            string confirm = tb_ConfirmTemporaryPwd.Text;

            #region 输入验证

            if (tb_TemporaryOldPwd.Enabled)
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
            tb_TemporaryOldPwd.Enabled = result;
            cb_DefaultTemporaryOldPwd.Enabled = result;
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

        private void btn_DeviceNext_Click(object sender, EventArgs e)
        {
            cb_DevicePage.SelectedIndex += 1;
        }

        private void btn_DevicePrevious_Click(object sender, EventArgs e)
        {
            cb_DevicePage.SelectedIndex -= 1;
        }

        private void btn_ShowDeviceRecord_Click(object sender, EventArgs e)
        {
            try
            {
                int count = DbHelper.Db.GetCount<DeviceInfo>();
                ShowPage(count, cb_DevicePage, l_DeviceRecordCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cb_AllSelected_CheckedChanged(object sender, EventArgs e)
        {
            bool check = cb_AllSelected.Checked;
            for (int i = 0; i < dgv_Device.RowCount; i++)
            {
                dgv_Device.Rows[i].Cells["c_Selected"].Value = check;
            }
        }

        private void cb_DevicePage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cb_DevicePage.SelectedIndex;

            btn_DevicePrevious.Enabled = index != 0;
            btn_DeviceNext.Enabled = index != cb_DevicePage.Items.Count - 1;

            try
            {
                DataTable dt = DbHelper.Db.ToTable<DeviceInfo>(index * 30, 30);
                dgv_Device.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                            e.Value = "学习控制器开闸";
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
            }
        }

        private void dgv_Device_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0) return;
            bool check = Convert.ToBoolean(dgv_Device.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            if (check)
            {
                btn_DeviceExport.Enabled = true;
            }
            else
            {
                foreach (DataGridViewRow row in dgv_Device.Rows)
                {
                    object obj = row.Cells[e.ColumnIndex].Value;
                    if (!(obj is bool)) continue;
                    if ((bool)obj)
                    {
                        btn_DeviceExport.Enabled = true;
                        return;
                    }
                }
                btn_DeviceExport.Enabled = false;
            }
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
                Thread thread = new Thread(ThreadSearchFrequency) { Name = "frequencysearch" };
                thread.Start();
                btn_FrequencySearch.Text = @"终 止";
                btn_FrequencySearch.Tag = true;
                _isReadCard = false;
            }
            else
            {
                _isThreadClose = true;

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
            DefaultShow ds = delegate
            {
                frequncy = 64 - (frequncy / 2);
                ShowWirelessMessage(string.Format("查询模块频率为:{0} 组", frequncy));
            };
            dgv_WirelessDescription.Invoke(ds);
        }

        private void QueryWireless(long id)
        {
            DefaultShow ds = delegate
            {
                ShowWirelessMessage(string.Format("查询模块ID为:{0:X8}", id));
            };
            dgv_WirelessDescription.Invoke(ds);
        }

        private void ShowIcCardContent(IcCardParameter info)
        {
            DefaultShow ds = delegate
            {
                string message = string.Format("IC卡号：{0} 车牌号码：{1} 时间：{2}", info.IcNumber, info.Plate, info.Time);
                WirelessAddRow(message);
            };
            dgv_WirelessDescription.Invoke(ds);
        }

        private void ShowWirelessMessage(string message)
        {
            DefaultShow ds = delegate
            {
                WirelessAddRow(message);
            };
            dgv_WirelessDescription.Invoke(ds);
        }

        private void ThreadSearchFrequency()
        {
            bool isend;
            int frequency = 0;
            bool isback = false;
            DefaultShow ds;
            for (int i = 1; i <= 64; i++)
            {
                isend = false;

                if (_isThreadClose)
                {
                    break;
                }
                ds = delegate
               {
                   pb_FrequencySearch.PerformStep();
               };
                pb_FrequencySearch.Invoke(ds);

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

            ds = delegate
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
           };
            pb_FrequencySearch.Invoke(ds);
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
                DefaultShow ds = delegate
                {
                    btn_WirelessSet.Enabled = true;
                    btn_FrequencySearch.Enabled = true;
                    btn_Test.Enabled = true;
                    btn_Query.Enabled = true;
                    btn_TemporaryReadCard.Enabled = true;

                    btn_WirelessSet.Image = !isend ? Properties.Resources.check : Properties.Resources.block;
                };
                btn_WirelessSet.Invoke(ds);
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

        private void ShowPage(int count, ComboBox cbBox, Label lcount)
        {
            cbBox.Items.Clear();
            int page = count / 30;
            if (page % 30 > 0)
                page++;
            if (page > 0)
            {
                for (int i = 0; i < page; i++)
                {
                    cbBox.Items.Add(string.Format("{0}页", i));
                }
            }
            else
            {
                cbBox.Items.Add("1页");
            }
            cbBox.SelectedIndex = 0;
            lcount.Text = string.Format("总共 {0} 条记录", count);
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