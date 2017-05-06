using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CBZN_TestTool
{
    public partial class DistanceRegister : Form
    {
        public static bool IsShow;
        private static DistanceRegister _instance;

        private int _lockindex;
        private CardInfo _mViceCard;
        private System.Timers.Timer _timer;

        private DistanceRegister()
        {
            InitializeComponent();
        }

        public delegate void ViceCardUpdateHandler(int rowindex, CardInfo info);

        private delegate void DefaultShow();

        public event ViceCardUpdateHandler ViceCardUpdate;

        public static DistanceRegister Instance
        {
            get { return _instance ?? (_instance = new DistanceRegister()); }
        }

        /// <summary>
        /// 卡片信息
        /// </summary>
        public CardInfo _mCardInfo { get; set; }

        public PortHelper _mPort { get; set; }

        /// <summary>
        /// 副卡列表
        /// </summary>
        public Dictionary<int, CardInfo> _mViceCardInfo { get; set; }

        /// <summary>
        /// 捆绑添加
        /// </summary>
        private Dictionary<int, CardInfo> _mBoundAdd { get; set; }

        /// <summary>
        /// 捆绑移除
        /// </summary>
        private List<CardInfo> _mBoundDel { get; set; }

        /// <summary>
        /// 已捆绑列表
        /// </summary>
        private Dictionary<int, CardInfo> _mBundledCardinfo { get; set; }

        public void PortDataReceived(DistanceParameter parameter)
        {
            if (_mViceCard == null)
            {
                if (parameter.AuxiliaryCommand != 0)
                {
                    DefaultShow ds = delegate
                    {
                        btn_Enter.Enabled = true;
                        MessageBox.Show(@"定距卡发行失败，请将定距卡放置在多功能操作平台上。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    };
                    Invoke(ds);
                    return;
                }
                else
                {
                    if (parameter.CardNumber == _mCardInfo.CardNumber)
                        this.Tag = _mCardInfo;
                }
            }

            if (_mCardInfo.CardType == 1)//组合卡
            {
                //解锁副卡
                foreach (KeyValuePair<int, CardInfo> item in _mBundledCardinfo)
                {
                    if (_mViceCard != null && item.Value == _mViceCard)
                    {
                        if (item.Value.CardNumber.Equals(parameter.CardNumber))
                        {
                            if (parameter.AuxiliaryCommand == 0)
                            {
                                item.Value.CardLock = 0;
                                Dal.DbHelper.Db.Update<CardInfo>(item.Value);
                                OnViceCardUpdate(item.Key, item.Value);
                                dgv_BundledList.Rows[_lockindex].Cells["c_LockState"].Value = item.Value.CardLock;
                            }
                        }
                        _mViceCard = null;
                        continue;
                    }
                    if (_mViceCard != null) continue;
                    _lockindex++;
                    if (item.Value.CardLock != 1) continue;
                    _mViceCard = item.Value;
                    TypeParameter typeparameter = new TypeParameter()
                    {
                        Lock = 0,
                        Distance = 0
                    };
                    DistanceParameterContent distanceparameter = new DistanceParameterContent()
                    {
                        CardNumber = item.Value.CardNumber,
                        Type = typeparameter,
                        Function = null,
                        Count = 0
                    };
                    SingleCardData? singlecarddata = null;
                    byte[] by = DataCombination.CombinationDistanceCard(distanceparameter, singlecarddata);
                    if (_mPort.IsOpen)
                        _mPort.Write(@by);
                    return;
                }
            }

            btn_Enter.Enabled = true;
            Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (_mBoundAdd.Count + _mBundledCardinfo.Count >= 4)
            {
                MessageBox.Show(@"最多只能捆绑 4 张副卡", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            for (int i = 0; i < clb_BundledSelected.Items.Count; i++)
            {
                bool isadd = false;
                if (!clb_BundledSelected.GetItemChecked(i)) continue;
                string cardnumber = clb_BundledSelected.Items[i].ToString();
                CardInfo info = null;
                int index = 0;
                //对比副卡列表找出选择的信息
                foreach (KeyValuePair<int, CardInfo> item in _mViceCardInfo)
                {
                    if (item.Value.CardNumber != cardnumber) continue;
                    index = item.Key;
                    info = item.Value;
                    break;
                }
                if (info == null)
                    continue;
                if (_mBundledCardinfo.ContainsValue(info))
                {
                    MessageBox.Show(@"副卡 " + cardnumber + @" 已经捆绑致定距卡中 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (_mBoundAdd.ContainsValue(info))
                {
                    MessageBox.Show(@"副卡 " + cardnumber + @" 已经捆绑致定距卡中 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //验证选择的信息是存在删除的信息中
                if (_mBoundDel.Contains(info))
                {
                    _mBundledCardinfo.Add(-1, info);
                    _mBoundDel.Remove(info);
                    dgv_BundledList.Rows.Add(new object[] { false, false, info.CardNumber, info.CardTime, info.ParkingRestrictions });
                    isadd = true;
                    break;
                }

                if (isadd) continue;
                _mBoundAdd.Add(index, info);
                dgv_BundledList.Rows.Add(new object[] { false, false, info.CardNumber, info.CardTime, info.ParkingRestrictions });
            }
        }

        private void btn_Canel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Enter.Enabled = false;
                _mViceCard = null;

                UpdateDistanceData();

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
                byte[] by;
                switch (_mCardInfo.CardType)
                {
                    case 0:
                        SingleCardData singlecarddata = new SingleCardData()
                        {
                            Time = _mCardInfo.CardTime,
                            Partition = _mCardInfo.CardPartition
                        };
                        by = DataCombination.CombinationDistanceCard(distancecontent, singlecarddata);
                        break;

                    case 1:
                        List<ViceCardData> vicecarddatas = new List<ViceCardData>();
                        foreach (KeyValuePair<int, CardInfo> item in _mBundledCardinfo)
                        {
                            ViceCardData vicecard = new ViceCardData()
                            {
                                ViceNumber = item.Value.CardNumber,
                                Time = item.Value.CardTime,
                                Partition = item.Value.CardPartition,
                                Count = item.Value.CardCount
                            };
                            vicecarddatas.Add(vicecard);
                        }
                        by = DataCombination.CombinationDistanceCard(distancecontent, vicecarddatas);
                        break;

                    default:
                        List<PlateCardData> platecarddatas = new List<PlateCardData>();
                        foreach (KeyValuePair<int, CardInfo> item in _mBundledCardinfo)
                        {
                            PlateCardData platecarddata = new PlateCardData()
                            {
                                Plate = item.Value.CardNumber,
                                Time = item.Value.CardTime,
                                Partition = item.Value.CardPartition
                            };
                            platecarddatas.Add(platecarddata);
                        }
                        by = DataCombination.CombinationDistanceCard(distancecontent, platecarddatas);
                        break;
                }
                if (_mPort.IsOpen)
                    _mPort.Write(by);
                _lockindex = 0;
            }
            catch (Exception ex)
            {
                btn_Enter.Enabled = true;
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_PlateAdd_Click(object sender, EventArgs e)
        {
            if (_mBoundAdd.Count + _mBundledCardinfo.Count >= 4)
            {
                MessageBox.Show(@"最多只能捆绑 4 张车牌号码", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string plate = tb_Plate.Text.Trim();
            if (!IsContainsPlateProvinces(plate))
            {
                MessageBox.Show(@"输入的车牌号码无效，输入的车牌内不得出现字母O、i或无效的汉字，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tb_Plate.Focus();
                return;
            }
            foreach (KeyValuePair<int, CardInfo> item in _mBundledCardinfo)
            {
                if (plate != item.Value.CardNumber) continue;
                MessageBox.Show(@"车牌号码 " + item.Value.CardNumber + @" 已经捆绑致定距卡中 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (KeyValuePair<int, CardInfo> item in _mBoundAdd)
            {
                if (plate != item.Value.CardNumber) continue;
                MessageBox.Show(@"车牌号码 " + item.Value.CardNumber + @" 已经捆绑致定距卡中 ", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (CardInfo item in _mBoundDel)
            {
                if (plate != item.CardNumber) continue;
                dgv_BundledList.Rows.Add(new object[] { false, Properties.Resources.block, item.CardNumber, item.CardTime, item.ParkingRestrictions });
                return;
            }
            CardInfo info = new CardInfo()
            {
                CardNumber = plate,
                CardTime = DateTime.Now,
                ParkingRestrictions = 0,
                CardType = -1
            };
            _mBoundAdd.Add(-1, info);
            dgv_BundledList.Rows.Add(new object[] { false, Properties.Resources.block, info.CardNumber, info.CardTime, info.ParkingRestrictions });
            tb_Plate.Text = string.Empty;
            tb_Plate.Focus();
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            for (int i = dgv_BundledList.RowCount - 1; i >= 0; i--)
            {
                if (!(bool)dgv_BundledList.Rows[i].Cells["c_selected"].Value) continue;
                string number = dgv_BundledList.Rows[i].Cells["c_Number"].Value.ToString();
                foreach (KeyValuePair<int, CardInfo> item in _mBundledCardinfo)
                {
                    if (number != item.Value.CardNumber) continue;
                    _mBoundDel.Add(item.Value);
                    dgv_BundledList.Rows.RemoveAt(i);
                    if (!_mViceCardInfo.ContainsValue(item.Value))
                    {
                        _mViceCardInfo.Add(-1, item.Value);
                        clb_BundledSelected.Items.Add(item.Value.CardNumber);
                    }
                    _mBundledCardinfo.Remove(item.Key);
                    break;
                }

                foreach (KeyValuePair<int, CardInfo> item in _mBoundAdd)
                {
                    if (number != item.Value.CardNumber) continue;
                    _mBoundAdd.Remove(item.Key);
                    dgv_BundledList.Rows.RemoveAt(i);
                    break;
                }
            }
            btn_Remove.Enabled = false;
        }

        private void cb_AllSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelected.Tag == null)
            {
                bool result = cb_AllSelected.Checked;
                foreach (Control item in p_CardPartition.Controls)
                {
                    if (!(item is CheckBox)) continue;
                    if (item == cb_AllSelected) continue;
                    CheckBox cb = item as CheckBox;
                    cb.Checked = result;
                }
            }
            else
            {
                cb_AllSelected.Tag = null;
            }
        }

        private void cb_AllSelectedBundled_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelectedBundled.Tag == null)
            {
                bool result = cb_AllSelectedBundled.Checked;
                for (int i = 0; i < dgv_BundledList.RowCount; i++)
                {
                    dgv_BundledList.Rows[i].Cells["c_selected"].Value = result;
                }
            }
            else
            {
                cb_AllSelectedBundled.Tag = null;
            }
        }

        private void cb_CardPartition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_timer != null) return;
            _timer = new System.Timers.Timer(5) { AutoReset = true };
            _timer.Elapsed += ShowEffect;

            if (cb_CardPartition.SelectedIndex == 0)
            {
                p_CardPartition.Visible = false;
            }
            _timer.Start();
        }

        private void cb_CardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_CardType.SelectedIndex != _mCardInfo.CardType)
            {
                if (_mBundledCardinfo.Count > 0)
                    _mBoundDel.AddRange(_mBundledCardinfo.Values);
                _mBundledCardinfo.Clear();
                _mBoundAdd.Clear();
                dgv_BundledList.Rows.Clear();
            }
            else
            {
                if (_mBoundDel.Count > 0)
                    foreach (CardInfo item in _mBoundDel)
                    {
                        _mBundledCardinfo.Add(-1, item);
                    }
                _mBoundDel.Clear();
                _mBoundAdd.Clear();
                ShowViceCardInfo();
            }

            if (_timer != null) return;
            _timer = new System.Timers.Timer(5) { AutoReset = true };
            _timer.Elapsed += ShowEffect;

            p_CardPartition.Visible = false;
            if (cb_CardType.SelectedIndex == 0)
            {
                p_Bundled.Visible = false;
                cb_CardPartition.Enabled = true;
                cb_ParkingRestrictions.Enabled = false;
            }
            else
            {
                cb_ParkingRestrictions.Enabled = true;
                cb_CardPartition.SelectedIndex = 0;
                cb_CardPartition.Enabled = false;
                p_Plate.Visible = false;
                btn_Add.Visible = false;
                clb_BundledSelected.Visible = false;
                p_Provinces.Visible = false;
            }
            _timer.Start();
        }

        private void cb_ShowProvinces_CheckedChanged(object sender, EventArgs e)
        {
            p_Provinces.Visible = cb_ShowProvinces.Checked;
            if (_timer != null) return;
            _timer = new System.Timers.Timer(5) { AutoReset = true };
            _timer.Elapsed += ShowEffect;
            _timer.Start();
        }

        private void clb_BundledSelected_VisibleChanged(object sender, EventArgs e)
        {
            btn_Add.Visible = clb_BundledSelected.Visible;
            if (!clb_BundledSelected.Visible || dgv_BundledList.RowCount != 0) return;
            foreach (KeyValuePair<int, CardInfo> item in _mViceCardInfo)
            {
                clb_BundledSelected.Items.Add(item.Value.CardNumber);
            }
        }

        private void CreateProvinces()
        {
            string[] strplate = Enum.GetNames(typeof(PlateProvinces.Provinces));
            int x = 0;
            int y = 0;
            for (int i = 0; i < strplate.Length; i++)
            {
                Button btn = new Button
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Top,
                    Location = new Point(x, y),
                    Size = new Size(30, 30),
                    Name = "Provinces" + i,
                    Text = strplate[i]
                };
                btn.Click += ProvincesClick;
                p_Provinces.Controls.Add(btn);
                x += btn.Width;
                if (btn.Width + x <= p_Provinces.Width) continue;
                x = 0;
                y += btn.Height;
            }
        }

        private void dgv_BundledList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    e.Value = e.Value.Equals(0) ? Properties.Resources.check : Properties.Resources.block;
                    break;

                case 4:
                    if (e.Value == null) return;
                    if (!Regex.IsMatch(e.Value.ToString(), @"^\d+$")) return;
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
                    break;
            }
        }

        private void dgv_BundledList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0) return;
            bool result = Convert.ToBoolean(dgv_BundledList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            if (cb_AllSelectedBundled.Checked)
            {
                if (!result)
                {
                    cb_AllSelectedBundled.Tag = false;
                    cb_AllSelectedBundled.Checked = false;
                }
            }
            if (result)
            {
                btn_Remove.Enabled = true;
            }
            else
            {
                for (int i = 0; i < dgv_BundledList.RowCount; i++)
                {
                    if (!(bool)dgv_BundledList.Rows[i].Cells[e.ColumnIndex].Value) continue;
                    btn_Remove.Enabled = true;
                    return;
                }
                btn_Remove.Enabled = false;
            }
        }

        private void dgv_BundledList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_BundledList.IsCurrentRowDirty)
            {
                dgv_BundledList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DistanceRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsShow = false;
            _instance = null;
            if (_mPort != null) _mPort.PortIsOpenChange -= PortOpenAndCloseChange;
        }

        private void DistanceRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btn_Enter.Enabled)
            {
                if (_mBoundDel.Count > 0 || _mBoundAdd.Count > 0)
                {
                    if (MessageBox.Show(@"当确认操作未成功，是否放弃操作。", @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void DistanceRegister_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void DistanceRegister_Load(object sender, EventArgs e)
        {
            IsShow = true;
            _mBundledCardinfo = new Dictionary<int, CardInfo>();
            _mBoundAdd = new Dictionary<int, CardInfo>();
            _mBoundDel = new List<CardInfo>();

            _mPort.PortIsOpenChange += PortOpenAndCloseChange;

            if (_mCardInfo == null) return;
            tb_CardNumber.Text = _mCardInfo.CardNumber;
            if (_mCardInfo.CardTime != DateTime.MinValue)
                t_CardTime.Value = _mCardInfo.CardTime;
            cb_CardType.SelectedIndex = _mCardInfo.CardType;
            cb_CardDistance.SelectedIndex = _mCardInfo.CardDistance;
            cb_ParkingRestrictions.SelectedIndex = _mCardInfo.ParkingRestrictions;
            if (cb_CardPartition.Enabled)
                cb_CardPartition.SelectedIndex = _mCardInfo.CardPartition > 0 ? 1 : 0;

            if (_mCardInfo.Cid <= 0) return;
            try
            {
                //显示捆绑的副卡
                if (cb_CardType.SelectedIndex == 0 || dgv_BundledList.RowCount != 0) return;
                List<CardInfo> vicecards = Dal.dal_CardInfo.SelectBound(_mCardInfo.Cid);
                foreach (CardInfo item in vicecards)
                {
                    _mBundledCardinfo.Add(-1, item);
                }
                ShowViceCardInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DistanceRegister_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 1), 0, 0, Width - 1, Height - 1);
            }
        }

        private void DistanceRegister_Resize(object sender, EventArgs e)
        {
            this.Invalidate(new Rectangle(0, cb_CardType.Bottom, this.Width, this.Height - cb_CardType.Bottom));
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

        private bool IsContainsPlateProvinces(string plate)
        {
            string[] strplate = Enum.GetNames(typeof(PlateProvinces.Provinces));
            foreach (string item in strplate)
            {
                if (plate.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }

        private void OnViceCardUpdate(int rowindex, CardInfo info)
        {
            if (ViceCardUpdate == null) return;
            ViceCardUpdate(rowindex, info);
        }

        private void p_Bundled_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                int height = 5;
                int left = cb_CardType.Left - p_Bundled.Left;
                Point[] points = {
                                    new Point(0,height),
                                    new Point(left+(cb_CardType.Width/2-height),height),
                                    new Point(left+(cb_CardType.Width/2),0),
                                    new Point(left+(cb_CardType.Width/2+height),height),
                                    new Point(p_Bundled.Width-1,height),
                                    new Point(p_Bundled.Width-1,p_Bundled.Height-1),
                                    new Point(0,p_Bundled.Height-1),
                                    new Point(0,height)
                                 };
                g.DrawLines(new Pen(Brushes.Gray, 1), points);
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

        private void p_CardPartition_VisibleChanged(object sender, EventArgs e)
        {
            if (p_CardPartition.Visible)
            {
                if (_mCardInfo != null && _mCardInfo.CardPartition > 0)
                {
                    SelectedPartiion(_mCardInfo.CardPartition);
                }
            }
        }

        private void p_Plate_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                Rectangle rect = new Rectangle(0, 0, p_Plate.Width - 1, p_Plate.Height - 1);
                g.DrawRectangle(new Pen(Brushes.Gray, 1), rect);
            }
        }

        private void p_Plate_Resize(object sender, EventArgs e)
        {
            p_Plate.Invalidate(new Rectangle(0, 0, p_Plate.Width, p_Plate.Height));
        }

        private void p_Provinces_VisibleChanged(object sender, EventArgs e)
        {
            if (!p_Provinces.Visible) return;
            if (p_Provinces.Controls.Count == 0)
            {
                CreateProvinces();
            }
        }

        private void p_Title_MouseDown(object sender, MouseEventArgs e)
        {
            WinApi.ReleaseCapture();
            WinApi.SendMessage(Handle, WinApi.WM_SYSCOMMAND, WinApi.SC_MOVE + WinApi.HTCAPTION, 0);
        }

        private void PartitionCheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb != null && cb.Checked) return;
            if (!cb_AllSelected.Checked) return;
            cb_AllSelected.Tag = true;
            cb_AllSelected.Checked = false;
            cb_AllSelected.Tag = null;
        }

        private void PortOpenAndCloseChange(object e, bool value)
        {
            btn_Enter.Enabled = value;
        }

        private void ProvincesClick(object sender, EventArgs e)
        {
            if (tb_Plate.Text.Length <= 9)
            {
                Button btn = sender as Button;
                if (btn != null) tb_Plate.Text += btn.Text;
            }
            tb_Plate.Focus();
            tb_Plate.Select(tb_Plate.TextLength, 0);
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

        private void SetRowCell(int index)
        {
            DataGridViewRow row = dgv_BundledList.Rows[index];
            for (int i = 0; i < dgv_BundledList.Columns.Count; i++)
            {
                string columnname = dgv_BundledList.Columns[i].Name;
                row.Cells[columnname].ValueType = row.Cells[columnname].Value.GetType();
            }
        }

        private void ShowEffect(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (cb_CardType.SelectedIndex == 0)
            {
                if (cb_CardPartition.SelectedIndex == 0)
                {
                    if (Height <= 250)
                    {
                        StopTimer();
                        Height = 250;
                        return;
                    }
                    Height -= 20;
                }
                else
                {
                    if (Height >= 410)
                    {
                        StopTimer();
                        Height = 410;
                        p_CardPartition.Visible = true;
                        return;
                    }
                    Height += 20;
                }
            }
            else if (cb_CardType.SelectedIndex == 1)
            {
                if (Height >= 540 && Height <= 560)
                {
                    StopTimer();
                    Height = 550;
                    p_Bundled.Height = 297;
                    p_Bundled.Visible = true;
                    clb_BundledSelected.Visible = true;
                    return;
                }
                if (Height < 550)
                {
                    Height += 20;
                    p_Bundled.Height += 20;
                }
                else
                {
                    Height -= 20;
                    p_Bundled.Height -= 20;
                }
            }
            else
            {
                if (!cb_ShowProvinces.Checked)
                {
                    if (Height >= 490 && Height <= 510)
                    {
                        StopTimer();
                        Height = 500;
                        p_Bundled.Height = 235;
                        p_Plate.Visible = true;
                        p_Bundled.Visible = true;
                        return;
                    }
                    if (Height < 500)
                    {
                        Height += 20;
                        p_Bundled.Height += 20;
                    }
                    else
                    {
                        Height -= 20;
                        p_Bundled.Height -= 20;
                    }
                }
                else
                {
                    if (Height >= 600)
                    {
                        StopTimer();
                        Height = 600;
                        p_Bundled.Height = 340;
                        p_Bundled.Visible = true;
                        p_Plate.Visible = true;
                        p_Provinces.Visible = true;
                        return;
                    }
                    Height += 20;
                    p_Bundled.Height += 20;
                }
            }
        }

        private void ShowViceCardInfo()
        {
            dgv_BundledList.Rows.Clear();
            foreach (KeyValuePair<int, CardInfo> item in _mBundledCardinfo)
            {
                int rowindex = dgv_BundledList.Rows.Add(new object[] { false, item.Value.CardLock, item.Value.CardNumber, item.Value.CardTime, item.Value.ParkingRestrictions });
                SetRowCell(rowindex);
            }
        }

        private void StopTimer()
        {
            _timer.Stop();
            _timer.Dispose();
            _timer = null;
        }

        private void tb_Plate_Enter(object sender, EventArgs e)
        {
            AcceptButton = null;
        }

        private void tb_Plate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btn_PlateAdd.Enabled)
                    btn_PlateAdd_Click(null, null);
            }
        }

        private void tb_Plate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Back)
            //    e.Handled = false;
            //else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            //    e.Handled = false;
            //else if (e.KeyChar >= 65 && e.KeyChar <= 90)
            //    e.Handled = false;
            //else if (e.KeyChar >= 97 && e.KeyChar <= 122)
            //    e.Handled = false;
            //else
            //    e.Handled = true;
        }

        private void tb_Plate_Leave(object sender, EventArgs e)
        {
            AcceptButton = btn_Enter;
        }

        private void tb_Plate_TextChanged(object sender, EventArgs e)
        {
            btn_PlateAdd.Enabled = tb_Plate.TextLength >= 7;
        }

        private void UpdateDistanceData()
        {
            //删除移除捆绑的数据
            if (_mBoundDel.Count > 0)
            {
                StringBuilder sbwhere = new StringBuilder(" and ( ");
                StringBuilder sbdel = new StringBuilder(" and ( ");
                foreach (CardInfo item in _mBoundDel)
                {
                    sbwhere.AppendFormat(" ( Cid={0} and ViceCardNumber='{1}' ) or", item.Cid, item.CardNumber);
                    sbdel.AppendFormat(" Cid={0} or", item.Cid);
                }

                sbwhere = sbwhere.Replace("or", " ) ", sbwhere.Length - 2, 2);
                Dal.DbHelper.Db.Del<BundledInfo>(sbwhere.ToString());

                if (_mCardInfo.CardType == 2)
                {
                    sbdel = sbdel.Replace("or", ")", sbdel.Length - 2, 2);
                    Dal.DbHelper.Db.Del<CardInfo>(sbdel.ToString());
                }
                _mBoundDel.Clear();
            }

            if (_mCardInfo.CardReportLoss == 1)
            {
                _mCardInfo.Synchronous = _mCardInfo.Synchronous == 0 ? 1 : 0;
                _mCardInfo.CardReportLoss = 0;
            }
            _mCardInfo.CardLock = 0;
            _mCardInfo.CardTime = t_CardTime.Value;
            _mCardInfo.CardType = cb_CardType.SelectedIndex;
            _mCardInfo.CardDistance = cb_CardDistance.SelectedIndex;
            _mCardInfo.ParkingRestrictions = cb_ParkingRestrictions.SelectedIndex;
            _mCardInfo.CardPartition = cb_CardPartition.SelectedIndex == 0 ? 0 : GetSelectedPartition();
            _mCardInfo.CardCount = DataCombination.SetCount(_mCardInfo.CardCount);
            _mCardInfo.ViceCardCount = _mBoundAdd.Count + _mBundledCardinfo.Count;

            //更新或插入数据
            if (_mCardInfo.Cid > 0)
            {
                Dal.DbHelper.Db.Update<CardInfo>(_mCardInfo);
            }
            else
            {
                _mCardInfo.Cid = Dal.DbHelper.Db.Insert<CardInfo>(_mCardInfo);
            }

            //添加捆绑的数据
            if (_mBoundAdd.Count <= 0) return;
            List<CardInfo> vicecardadd = new List<CardInfo>();
            List<CardInfo> vicecardupdate = new List<CardInfo>();
            List<BundledInfo> bundledinfos = new List<BundledInfo>();
            foreach (KeyValuePair<int, CardInfo> item in _mBoundAdd)
            {
                item.Value.CardCount = DataCombination.SetCount(item.Value.CardCount);
                if (item.Value.Cid == 0)
                {
                    vicecardadd.Add(item.Value);
                }
                else
                {
                    vicecardupdate.Add(item.Value);
                }
                _mBundledCardinfo.Add(item.Key, item.Value);
            }
            _mBoundAdd.Clear();

            if (vicecardadd.Count > 0)
                Dal.DbHelper.Db.Insert<CardInfo>(vicecardadd);
            if (vicecardupdate.Count > 0)
                Dal.DbHelper.Db.Update<CardInfo>(vicecardupdate);
            foreach (CardInfo item in vicecardadd)
            {
                bundledinfos.Add(new BundledInfo()
                {
                    Cid = _mCardInfo.Cid,
                    Vid = item.Cid,
                    HostCardNumber = _mCardInfo.CardNumber,
                    ViceCardNumber = item.CardNumber,
                });
            }
            Dal.DbHelper.Db.Insert<BundledInfo>(bundledinfos);
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

        private void clb_BundledSelected_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int count = 0;
            for (int i = 0; i < clb_BundledSelected.Items.Count; i++)
            {
                if (i == e.Index)
                {
                    if (e.NewValue == CheckState.Checked)
                        count++;
                }
                else
                {
                    if (clb_BundledSelected.GetItemChecked(i))
                    {
                        count++;
                    }
                }
            }
            btn_Add.Enabled = count != 0;
        }
    }
}