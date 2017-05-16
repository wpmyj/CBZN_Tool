using Dal;
using System;
using System.Drawing;
using System.Windows.Forms;
using Bll;
using Model;
namespace CBZN_TestTool
{
    public partial class DelayParam : Form
    {

        public PortHelper _mPort { get; set; }
        public CardInfo _mCardInfo { get; set; }

        public static bool IsShow;
        private static DelayParam _instance;

        public static DelayParam Instance
        {
            get { return _instance ?? (_instance = new DelayParam()); }
        }

        private System.Timers.Timer _tiEffect;

        private DelayParam()
        {
            InitializeComponent();
        }

        private void PortOpenAndCloseChange(object e, bool flag)
        {
            btn_Enter.Enabled = flag;
        }

        public void PortDataReceived(DistanceParameter param)
        {
            if (param.AuxiliaryCommand == 0)
            {
                DbHelper.Db.Update<CardInfo>(_mCardInfo);
                this.Tag = _mCardInfo;
                Close();
            }
            else
            {
                MessageBox.Show("请确认定距卡是否放置在读写区域内", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DelayParam_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void DelayParam_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsShow = false;
            if (_mPort != null)
            {
                _mPort.PortIsOpenChange -= PortOpenAndCloseChange;
            }
            _instance = null;
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
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
                g.DrawString(Text, new Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))), Brushes.White, new Rectangle(p_Title.Location, p_Title.Size), sf);
            }
        }

        private void SingleCardDelay_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 1), 0, 0, Width - 1, Height - 1);
            }
        }

        private void cb_DelaySelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_DelaySelected.SelectedIndex)
            {
                case 0:
                    l_DelayValueTitle.Text = @"延期天数";
                    break;

                case 1:
                    l_DelayValueTitle.Text = @"延期月数";
                    break;

                case 2:
                    l_DelayValueTitle.Text = @"延期季数";
                    break;

                case 3:
                    l_DelayValueTitle.Text = @"延期年数";
                    break;
            }
            SetDelayTime();
        }

        private void SetDelayTime()
        {
            int count = (int)ud_DelayValue.Value;
            switch (cb_DelaySelected.SelectedIndex)
            {
                case 0:
                    t_NewTime.Value = t_OldTime.Value.AddDays(count);
                    break;
                case 1:
                    t_NewTime.Value = t_OldTime.Value.AddMonths(count);
                    break;
                case 2:
                    t_NewTime.Value = t_OldTime.Value.AddMonths(count * 3);
                    break;
                case 3:
                    t_NewTime.Value = t_OldTime.Value.AddYears(count);
                    break;
            }
        }

        private void DelayParam_Load(object sender, EventArgs e)
        {
            IsShow = true;
            if (_mPort != null)
            {
                _mPort.PortIsOpenChange += PortOpenAndCloseChange;
                btn_Enter.Enabled = _mPort.IsOpen;
            }
            if (_mCardInfo != null)
            {
                t_OldTime.Value = _mCardInfo.CardTime;
                SelectedPartiion(_mCardInfo.CardPartition);
            }
            t_NewTime.Value = t_OldTime.Value;
            cb_DelaySelected.SelectedIndex = 1;
            cb_CardPartition.SelectedIndex = 1;
        }

        private void SelectedPartiion(int partition)
        {
            for (int i = 0; i < 16; i++)
            {
                int check = BinaryHelper.GetIntegerSomeBit(partition, i);
                Control[] findcontrol = p_CardPartition.Controls.Find("cb_Partition" + (i + 1), false);
                foreach (Control item in findcontrol)
                {
                    if (check != 1) continue;
                    CheckBox cb = item as CheckBox;
                    if (cb != null)
                        cb.Checked = true;
                }
            }
        }

        private int GetSelectedPartition()
        {
            int partition = 0;
            for (int i = 0; i < 16; i++)
            {
                Control[] findcontrol = p_CardPartition.Controls.Find("cb_Partition" + (i + 1), true);
                foreach (Control item in findcontrol)
                {
                    CheckBox cb = item as CheckBox;
                    partition = BinaryHelper.SetIntegeSomeBit(partition, i, cb != null && cb.Checked);
                }
            }
            return partition;
        }

        private void ud_DelayValue_ValueChanged(object sender, EventArgs e)
        {
            SetDelayTime();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            DateTime newtime = t_NewTime.Value;
            int partition = GetSelectedPartition();
            if (_mCardInfo != null)
            {
                _mCardInfo.CardTime = newtime;
                _mCardInfo.CardPartition = partition;
                TypeParameter typeparameter = new TypeParameter()
                {
                    Lock = _mCardInfo.CardLock,
                    Distance = _mCardInfo.CardDistance
                };

                FunctionByteParameter functionbyteparameter = new FunctionByteParameter()
                {
                    Loss = _mCardInfo.CardReportLoss,
                    Synchronous = _mCardInfo.Synchronous,
                    RegistrationType = (CardType)_mCardInfo.CardType,
                    ViceCardCount = _mCardInfo.ViceCardCount,
                    ParkingRestrictions = _mCardInfo.ParkingRestrictions,
                    InOutState = _mCardInfo.InOutState
                };

                DistanceParameterContent distancecontent = new DistanceParameterContent()
                {
                    CardNumber = _mCardInfo.CardNumber,
                    Type = typeparameter,
                    Function = functionbyteparameter,
                    Count = ++_mCardInfo.CardCount
                };
                SingleCardData singlecarddata = new SingleCardData()
                {
                    Time = _mCardInfo.CardTime,
                    Partition = _mCardInfo.CardPartition
                };
                byte[] by = DataCombination.CombinationDistanceCard(distancecontent, singlecarddata);
                if (_mPort.IsOpen)
                {
                    _mPort.Write(by);
                }
            }
            else
            {
                DelayParamValue param = new DelayParamValue()
                {
                    DelayTime = newtime,
                    Partition = partition
                };
                this.Tag = param;
                Close();
            }
        }

        private void p_CardPartition_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                int height = 5;
                int left = cb_CardPartition.Left - p_CardPartition.Left;
                Point[] points = {
                             new Point(0 , height),
                             new Point(left + (cb_CardPartition.Width / 2 - height) , height),
                             new Point(left + (cb_CardPartition.Width / 2) , 0),
                             new Point(left + (cb_CardPartition.Width / 2 + height), height),
                             new Point(p_CardPartition.Width - 1, height),
                             new Point(p_CardPartition.Width - 1, p_CardPartition.Height - 1),
                             new Point(0 , p_CardPartition.Height - 1),
                             new Point(0 , height)
                             };
                g.DrawLines(new Pen(Brushes.Gray, 1), points);
            }
        }

        private void cb_CardPartition_SelectedIndexChanged(object sender, EventArgs e)
        {
            p_CardPartition.Visible = false;
            if (_tiEffect == null)
            {
                _tiEffect = new System.Timers.Timer(1);
                _tiEffect.AutoReset = true;
                _tiEffect.Elapsed += _tiEffect_Elapsed;
            }
            _tiEffect.Start();
        }

        void _tiEffect_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                if (cb_CardPartition.SelectedIndex == 0)
                {
                    if (Height <= 185)
                    {
                        Height = 185;
                        CloseEffect();
                        return;
                    }
                    Height -= 15;
                }
                else
                {
                    if (Height >= 395)
                    {
                        Height = 395;
                        p_CardPartition.Visible = true;
                        CloseEffect();
                        return;
                    }
                    Height += 15;
                }
            }));
        }

        private void CloseEffect()
        {
            if (_tiEffect != null)
            {
                _tiEffect.Stop();
                _tiEffect.Dispose();
                _tiEffect = null;
            }
        }

        private void cb_AllSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelected.CheckState == CheckState.Indeterminate) return;
            bool flag = cb_AllSelected.Checked;
            foreach (Control item in p_CardPartition.Controls)
            {
                if (item is CheckBox && item != cb_AllSelected)
                {
                    CheckBox cb = item as CheckBox;
                    if (cb == null) continue;
                    cb.Checked = flag;
                }
            }
        }

        private void PartitionSelected(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb == null) return;
            if (cb.Checked != cb_AllSelected.Checked)
                cb_AllSelected.CheckState = CheckState.Indeterminate;
        }

        private void DelayParam_Resize(object sender, EventArgs e)
        {
            Invalidate(new Rectangle(0, cb_CardPartition.Bottom, Width - 1, Height - 1));
        }

        private void DelayParam_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }

    public struct DelayParamValue
    {
        public DateTime DelayTime;
        public int Partition;
    }
}
