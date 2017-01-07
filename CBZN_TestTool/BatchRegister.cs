using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Dal;

namespace CBZN_TestTool
{
    public partial class BatchRegister : Form
    {
        public RegisterParam? RegisterParam { get; set; }

        public delegate void RegisterCompleteHandler(int index, CardInfo info);
        public event RegisterCompleteHandler Registercomplete;

        private void OnRegisterComplete(int index, CardInfo info)
        {
            if (Registercomplete == null) return;
            Registercomplete(index, info);
        }

        public PortHelper Port { get; set; }

        public Dictionary<int, CardInfo> DicRegisterList;

        private int _rowIndex = 0;

        public static bool IsShow { get; set; }

        private static BatchRegister _currentForm;

        public static BatchRegister CurrentForm
        {
            get
            {
                if (_currentForm == null)
                    _currentForm = new BatchRegister();
                return _currentForm;
            }
        }

        private BatchRegister()
        {
            InitializeComponent();
            this.FormClosing += BatchRegister_FormClosing;
        }

        private void BatchRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!btn_Enter.Enabled)
            {
                MessageBox.Show(@"正在批量发行定距卡，无法退出操作，请稍后。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        public void PortDataReceived(DistanceParameter param)
        {
            RegisterCards(param.CardNumber, param.AuxiliaryCommand);
        }

        private void BatchRegister_Load(object sender, EventArgs e)
        {
            Port.PortIsOpenChange += PortOpenAndCloseChange;

            foreach (KeyValuePair<int, CardInfo> item in DicRegisterList)
            {
                dgv_RegisterList.Rows.Add(Properties.Resources.block, item.Value.CardNumber);
            }
        }

        private void PortOpenAndCloseChange(object e, bool flag)
        {
            btn_Enter.Enabled = flag;
        }

        private void BatchRegister_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 1), new Rectangle(0, 0, Width - 1, Height - 1));
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_RegisterList_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                Point[] p = new Point[]
                {
                    new Point(0,0),
                    new Point(0,dgv_RegisterList.Height-1),
                    new Point(dgv_RegisterList.Width-1,dgv_RegisterList.Height-1),
                    new Point(dgv_RegisterList.Width-1,0),
                };
                g.DrawLines(new Pen(Brushes.Gray, 1), p);
            }
        }

        private void l_Title_MouseDown(object sender, MouseEventArgs e)
        {
            WinApi.ReleaseCapture();
            WinApi.SendMessage(Handle, WinApi.WM_SYSCOMMAND, WinApi.SC_MOVE + WinApi.HTCAPTION, 0);
        }

        private void BatchRegister_Shown(object sender, EventArgs e)
        {
            IsShow = true;
            if (RegisterParam == null)
            {
                SetReisterParam();
            }
            else
            {
                if (MessageBox.Show(@"是否使用已保存的批量参数进行批量发行操作。", @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    SetReisterParam();
                }
            }
        }

        private void SetReisterParam()
        {
            using (RegisterParameter rp = new RegisterParameter())
            {
                rp.ShowDialog();
                if (rp.Tag != null)
                {
                    RegisterParam param = (RegisterParam)rp.Tag;
                    RegisterParam = param;
                    this.Tag = param;
                }
            }
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            btn_Enter.Enabled = false;
            btn_Param.Enabled = false;
            _rowIndex = 0;
            foreach (KeyValuePair<int, CardInfo> item in DicRegisterList)
            {
                if (item.Value.Cid == 0)
                {
                    item.Value.CardLock = 0;
                    item.Value.CardReportLoss = 0;
                    item.Value.CardType = 0;
                    item.Value.ParkingRestrictions = 0;
                    item.Value.CardDistance = RegisterParam.Value.Distance;
                    item.Value.CardPartition = RegisterParam.Value.Paratition;
                    item.Value.CardTime = RegisterParam.Value.Time;
                    item.Value.CardCount = DataCombination.SetCount(item.Value.CardCount);
                }
            }
            RegisterCards(string.Empty, -1);
        }

        private void RegisterCards(string cardnumber, int auxiliarycommand)
        {
            int index = -1;
            foreach (KeyValuePair<int, CardInfo> item in DicRegisterList)
            {
                index++;
                if (!string.IsNullOrEmpty(cardnumber) && cardnumber == item.Value.CardNumber)
                {
                    if (auxiliarycommand == 0)
                    {
                        item.Value.Cid = DbHelper.Db.Insert<CardInfo>(item.Value);
                        OnRegisterComplete(item.Key, item.Value);
                        dgv_RegisterList.Rows[_rowIndex].Cells["c_State"].Value = Properties.Resources.check;
                    }
                    cardnumber = string.Empty;
                    continue;
                }

                if (!string.IsNullOrEmpty(cardnumber)) continue;
                if (item.Value.Cid > 0) continue;

                _rowIndex = index;
                TypeParameter typeparam = new TypeParameter()
                {
                    Lock = item.Value.CardLock,
                    Distance = item.Value.CardDistance
                };

                FunctionByteParameter functionparam = new FunctionByteParameter()
                {
                    Loss = item.Value.CardReportLoss,
                    InOutState = item.Value.InOutState,
                    ParkingRestrictions = item.Value.ParkingRestrictions,
                    RegistrationType = (CardType)item.Value.CardType,
                    Synchronous = item.Value.Synchronous,
                    ViceCardCount = 0
                };

                DistanceParameterContent parameter = new DistanceParameterContent()
                {
                    CardNumber = item.Value.CardNumber,
                    Count = item.Value.CardCount,
                    Function = functionparam,
                    Type = typeparam
                };

                SingleCardData singlecard = new SingleCardData()
                {
                    Partition = item.Value.CardPartition,
                    Time = item.Value.CardTime
                };

                byte[] by = DataCombination.CombinationDistanceCard(parameter, singlecard);
                if (Port.IsOpen)
                {
                    Port.Write(by);
                    return;
                }
            }


            btn_Enter.Enabled = true;
            btn_Param.Enabled = true;
            if (GetIsCompleteRegister())
            {
                Close();
            }
        }

        private bool GetIsCompleteRegister()
        {
            foreach (KeyValuePair<int, CardInfo> item in DicRegisterList)
            {
                if (item.Value.Cid == 0)
                    return false;
            }
            return true;
        }

        private void btn_Canel_Click(object sender, EventArgs e)
        {
            btn_Enter.Enabled = true;
            Close();
        }

        private void btn_Param_Click(object sender, EventArgs e)
        {
            SetReisterParam();
        }

        private void BatchRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            _currentForm = null;
            IsShow = false;
            Port.PortIsOpenChange -= PortOpenAndCloseChange;
        }

        private void dgv_RegisterList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }


    }
}