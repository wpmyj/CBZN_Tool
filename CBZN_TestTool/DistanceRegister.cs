using Bll;
using Model;
using Dal;
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

        public static DistanceRegister Instance
        {
            get { return _instance ?? (_instance = new DistanceRegister()); }
        }

        /// <summary>
        /// 卡片信息
        /// </summary>
        public CardInfo _mCardInfo { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public PortHelper _mPort { get; set; }

        /// <summary>
        /// 副卡列表
        /// </summary>
        public List<CardInfo> _mViceCardInfo { get; set; }

        /// <summary>
        /// 捆绑添加
        /// </summary>
        private List<CardInfo> _mBoundAdd { get; set; }

        /// <summary>
        /// 捆绑移除
        /// </summary>
        private List<CardInfo> _mBoundDel { get; set; }

        /// <summary>
        /// 已捆绑列表
        /// </summary>
        public List<CardInfo> _mBundledCardinfo { get; set; }

        /// <summary>
        /// 端口数据接收方法
        /// </summary>
        /// <param name="parameter"></param>
        public void PortDataReceived(DistanceParameter parameter)
        {
            if (_mViceCard == null)
            {
                if (parameter.AuxiliaryCommand != 0) //主卡发行失败提示下面内容
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        btn_Enter.Enabled = true;
                        MessageBox.Show(@"定距卡发行失败，请将定距卡放置在多功能操作平台上。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }));
                    return;
                }
                else //主卡发行成功
                {
                    if (parameter.CardNumber == _mCardInfo.CardNumber)
                    {
                        //更新数据库数据
                        UpdateDistanceData();
                        this.Tag = _mCardInfo;
                    }
                }
            }

            if (_mCardInfo.CardType == 1)//组合卡
            {
                //解锁副卡
                foreach (CardInfo item in _mBundledCardinfo)
                {
                    if (_mViceCard != null && item == _mViceCard)
                    {
                        if (item.CardNumber.Equals(parameter.CardNumber))
                        {
                            if (parameter.AuxiliaryCommand == 0)
                            {
                                item.CardLock = 0;
                                Dal.DbHelper.Db.Update<CardInfo>(item);
                                dgv_BundledList["c_LockState", _lockindex].Value = Properties.Resources.check;
                                //dgv_BundledList.Rows[_lockindex].DefaultCellStyle.ForeColor = Color.Green;
                            }
                            else
                            {
                                dgv_BundledList["c_LockState", _lockindex].Value = Properties.Resources.block;
                                //dgv_BundledList.Rows[_lockindex].DefaultCellStyle.ForeColor = Color.Red;
                            }
                        }
                        _mViceCard = null;
                        continue;
                    }
                    if (_mViceCard != null) continue;
                    _lockindex++;
                    if (item.CardLock != 1) continue;
                    _mViceCard = item;
                    TypeParameter typeparameter = new TypeParameter()
                    {
                        Lock = 0,
                        Distance = 0
                    };
                    DistanceParameterContent distanceparameter = new DistanceParameterContent()
                    {
                        CardNumber = item.CardNumber,
                        Type = typeparameter,
                        Function = null,
                        Count = 0
                    };
                    SingleCardData? singlecarddata = null;
                    byte[] by = DataCombination.CombinationDistanceCard(distanceparameter, singlecarddata);
                    if (_mPort.IsOpen)
                        _mPort.Write(by);
                    return;
                }
            }

            btn_Enter.Enabled = true;
            Close();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Canel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Enter_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Enter.Enabled = false;
                _mViceCard = null;

                //判断定距卡是否挂失
                if (_mCardInfo.CardReportLoss == 1)
                {
                    //定距卡解挂必须修改定距卡的同步位数据
                    _mCardInfo.Synchronous = _mCardInfo.Synchronous == 0 ? 1 : 0;
                    _mCardInfo.CardReportLoss = 0;
                }
                //解锁
                _mCardInfo.CardLock = 0;
                //定距卡时间
                _mCardInfo.CardTime = cb_CardType.SelectedIndex == 0 ? t_CardTime.Value : GetViceMaxTime();
                //定距卡类型
                _mCardInfo.CardType = cb_CardType.SelectedIndex;
                //定距卡距离
                _mCardInfo.CardDistance = cb_CardDistance.SelectedIndex;
                //定距卡车位限制
                _mCardInfo.ParkingRestrictions = cb_ParkingRestrictions.SelectedIndex;
                //定距卡车场分区
                _mCardInfo.CardPartition = cb_CardPartition.SelectedIndex == 0 ? 0 : GetSelectedPartition();
                //定距卡计数
                _mCardInfo.CardCount = DataCombination.SetCount(_mCardInfo.CardCount);
                //定距卡副卡数量
                _mCardInfo.ViceCardCount = _mBoundAdd.Count + _mBundledCardinfo.Count;

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
                        foreach (CardInfo item in _mBundledCardinfo)
                        {
                            ViceCardData vicecard = new ViceCardData()
                            {
                                ViceNumber = item.CardNumber,
                                Time = item.CardTime,
                                Partition = item.CardPartition,
                                Count = item.CardCount
                            };
                            vicecarddatas.Add(vicecard);
                        }
                        by = DataCombination.CombinationDistanceCard(distancecontent, vicecarddatas);
                        break;

                    default:
                        List<PlateCardData> platecarddatas = new List<PlateCardData>();
                        foreach (CardInfo item in _mBundledCardinfo)
                        {
                            PlateCardData platecarddata = new PlateCardData()
                            {
                                Plate = item.CardNumber,
                                Time = item.CardTime,
                                Partition = item.CardPartition
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

        /// <summary>
        /// 获取副卡中最大的时间
        /// </summary>
        /// <returns></returns>
        private DateTime GetViceMaxTime()
        {
            DateTime now = DateTime.MinValue;
            foreach (CardInfo item in _mBundledCardinfo)
            {
                if (item.CardTime.Date > now.Date)
                    now = item.CardTime;
            }
            foreach (CardInfo item in _mBoundAdd)
            {
                if (item.CardTime.Date > now.Date)
                    now = item.CardTime;
            }
            return now;
        }

        /// <summary>
        /// 全选 车场分区 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_AllSelected_MouseDown(object sender, MouseEventArgs e)
        {
            cb_AllSelected.ThreeState = false;
        }

        /// <summary>
        /// 全选 车场分区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_AllSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelected.CheckState == CheckState.Indeterminate) return;
            cb_AllSelected.Tag = cb_AllSelected.Checked;
            foreach (Control item in cb_AllSelected.Parent.Controls)
            {
                if (!(item is CheckBox)) continue;
                if (item == cb_AllSelected) continue;
                ((CheckBox)item).Checked = cb_AllSelected.Checked;
            }
            cb_AllSelected.Tag = null;
        }

        /// <summary>
        /// 车场分区选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PartitionCheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelected.Tag != null) return;
            Control c = sender as Control;
            int count = 0;
            foreach (Control item in c.Parent.Controls)
            {
                if (!(item is CheckBox)) continue;
                if (item == cb_AllSelected) continue;
                CheckBox cb = item as CheckBox;
                if (cb.Checked)
                    count++;
            }
            cb_AllSelected.ThreeState = true;
            if (count == 0)
                cb_AllSelected.CheckState = CheckState.Unchecked;
            else if (count == 16)
                cb_AllSelected.CheckState = CheckState.Checked;
            else
                cb_AllSelected.CheckState = CheckState.Indeterminate;
        }

        /// <summary>
        /// 全选 已捆绑副卡 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_AllSelectedBundled_MouseDown(object sender, MouseEventArgs e)
        {
            cb_AllSelectedBundled.ThreeState = false;
        }

        /// <summary>
        /// 全选 已捆绑副卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_AllSelectedBundled_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelectedBundled.CheckState == CheckState.Indeterminate) return;
            cb_AllSelectedBundled.Tag = cb_AllSelectedBundled.Checked;
            for (int i = 0; i < dgv_BundledList.RowCount; i++)
            {
                dgv_BundledList["c_selected", i].Value = cb_AllSelectedBundled.Checked;
            }
            if (dgv_BundledList.RowCount > 0)
                btn_Remove.Enabled = cb_AllSelectedBundled.Checked;
            cb_AllSelectedBundled.Tag = null;
        }

        /// <summary>
        /// DGV 列表单元格值变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_BundledList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (cb_AllSelectedBundled.Tag != null) return;
            int count = 0;
            for (int i = 0; i < dgv_BundledList.RowCount; i++)
            {
                bool flag = Convert.ToBoolean(dgv_BundledList["c_selected", i].Value);
                if (flag)
                    count++;
            }
            cb_AllSelectedBundled.ThreeState = true;
            if (count == 0)
                cb_AllSelectedBundled.CheckState = CheckState.Unchecked;
            else if (count == dgv_BundledList.RowCount)
                cb_AllSelectedBundled.CheckState = CheckState.Checked;
            else
                cb_AllSelectedBundled.CheckState = CheckState.Indeterminate;
            btn_Remove.Enabled = count > 0;
        }

        /// <summary>
        /// DGV 列表单元状态因其内容更改而更改的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_BundledList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_BundledList.IsCurrentRowDirty)
            {
                dgv_BundledList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// 车牌分区选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_CardPartition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer = null;
            }
            _timer = new System.Timers.Timer(5) { AutoReset = true };
            _timer.Elapsed += ShowEffect;

            if (cb_CardPartition.SelectedIndex == 0)
            {
                p_CardPartition.Visible = false;
            }
            _timer.Start();
        }

        /// <summary>
        /// 定距卡类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_CardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_CardType.SelectedIndex != _mCardInfo.CardType)
            {
                //将副卡集合中的数据添加到删除副卡集合中
                if (_mBundledCardinfo.Count > 0)
                {
                    _mBoundDel.AddRange(_mBundledCardinfo.ToArray());
                    //清空副卡集合
                    _mBundledCardinfo.Clear();
                }
                //清空添加集合
                _mBoundAdd.Clear();
                //清空列表
                dgv_BundledList.Rows.Clear();
            }
            else if (_mCardInfo.CardType > 0)
            {
                //清空删除集合
                _mBoundDel.Clear();
                //清空添加集合
                _mBoundAdd.Clear();
                //获取捆绑的副卡集合
                GetViceCardInfo();
            }

            if (_timer != null)
            {
                _timer.Stop();
                _timer = null;
            }
            _timer = new System.Timers.Timer(5) { AutoReset = true };
            _timer.Elapsed += ShowEffect;

            if (cb_CardType.SelectedIndex == 0)//单卡模式
            {
                //启用时间
                t_CardTime.Enabled = true;
                //隐藏副卡容器
                p_Bundled.Visible = false;
                //显示场分区容器
                cb_CardPartition.Enabled = true;
                //关闭车位限制
                cb_ParkingRestrictions.Enabled = false;
            }
            else//组合卡或车牌识别卡
            {
                //不启用时间
                t_CardTime.Enabled = false;
                //隐藏场分区容器
                p_CardPartition.Visible = false;
                //开启车位限制
                cb_ParkingRestrictions.Enabled = true;
                //关闭场分区
                cb_CardPartition.SelectedIndex = 0;
                //不启用场分区
                cb_CardPartition.Enabled = false;
            }

            _timer.Start();
        }

        /// <summary>
        /// DGV 列表格式变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 窗体关闭后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsShow = false;
            _mViceCardInfo = null;
            _instance = null;
            //清除端口事件
            if (_mPort != null) _mPort.PortIsOpenChange -= PortOpenAndCloseChange;
        }

        /// <summary>
        /// 窗体关闭前事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            //确认当前操作是否完成,没有完成提示以下内容
            if (btn_Enter.Enabled)
            {
                if (_mBoundDel.Count > 0 || _mBoundAdd.Count > 0)
                {
                    if (MessageBox.Show(@"当确认操作未成功，是否放弃操作。", @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
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

        /// <summary>
        /// 窗体键盘弹起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceRegister_KeyUp(object sender, KeyEventArgs e)
        {
            //键盘按下ESC关闭窗体
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceRegister_Load(object sender, EventArgs e)
        {
            IsShow = true;
            //初始化添加副卡集合
            _mBoundAdd = new List<CardInfo>();
            //初始化删除副卡集合
            _mBoundDel = new List<CardInfo>();
            //初始化副卡捆绑集合
            _mBundledCardinfo = new List<CardInfo>();
            //添加端口事件
            _mPort.PortIsOpenChange += PortOpenAndCloseChange;

            //显示主卡卡号
            tb_CardNumber.Text = _mCardInfo.CardNumber;
            //显示主卡时间
            if (_mCardInfo.CardTime != DateTime.MinValue)
                t_CardTime.Value = _mCardInfo.CardTime;
            //显示主卡类型
            cb_CardType.SelectedIndex = _mCardInfo.CardType;
            //显示主卡距离
            cb_CardDistance.SelectedIndex = _mCardInfo.CardDistance;
            //显示主卡停车限制
            cb_ParkingRestrictions.SelectedIndex = _mCardInfo.ParkingRestrictions;
            //显示主卡车场分区
            if (cb_CardPartition.Enabled)
                cb_CardPartition.SelectedIndex = _mCardInfo.CardPartition > 0 ? 1 : 0;
        }

        /// <summary>
        /// 窗体重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceRegister_Paint(object sender, PaintEventArgs e)
        {
            //绘制边框
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 1), 0, 0, Width - 1, Height - 1);
            }
        }

        /// <summary>
        /// 窗体大小变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceRegister_Resize(object sender, EventArgs e)
        {
            //窗体大小变化时让窗体重新绘制边框
            this.Invalidate(new Rectangle(0, cb_CardType.Bottom, this.Width, this.Height - cb_CardType.Bottom));
        }

        /// <summary>
        /// 获取车场分区的值
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 副卡容器重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 车场分区容器重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 车场分区容器隐藏或显示变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void p_CardPartition_VisibleChanged(object sender, EventArgs e)
        {
            //显示容器时重新显示车场分区的内容
            if (p_CardPartition.Visible)
            {
                if (_mCardInfo != null && _mCardInfo.CardPartition > 0)
                {
                    SelectedPartiion(_mCardInfo.CardPartition);
                }
            }
        }

        /// <summary>
        /// 标题窗体鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void p_Title_MouseDown(object sender, MouseEventArgs e)
        {
            //使用以下两个方法移动窗体
            WinApi.ReleaseCapture();
            WinApi.SendMessage(Handle, WinApi.WM_SYSCOMMAND, WinApi.SC_MOVE + WinApi.HTCAPTION, 0);
        }

        /// <summary>
        /// 端口变化事件
        /// </summary>
        /// <param name="e"></param>
        /// <param name="value"></param>
        private void PortOpenAndCloseChange(object e, bool value)
        {
            btn_Enter.Enabled = value;
        }

        /// <summary>
        /// 显示车场分区的内容
        /// </summary>
        /// <param name="partition"></param>
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

        /// <summary>
        /// 显示动画效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowEffect(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                if (cb_CardType.SelectedIndex == 0)//显示单卡时的动画效果
                {
                    if (cb_CardPartition.SelectedIndex == 0)//场分区关闭的时的动画效果
                    {
                        if (Height <= 250)
                        {
                            StopTimer();
                            Height = 250;
                            return;
                        }
                        Height -= 20;
                    }
                    else //场分区开启时的动画效果
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
                else //组合卡或车牌识别卡时的动画效果
                {
                    if (Height >= 495)
                    {
                        StopTimer();
                        Height = 495;
                        p_Bundled.Visible = true;
                        return;
                    }
                    Height += 20;
                }
            }));
        }

        /// <summary>
        /// 获取副卡集合并显示
        /// </summary>
        private void GetViceCardInfo()
        {
            try
            {
                //获取副卡集合
                _mBundledCardinfo = Dal.dal_CardInfo.SelectBound(_mCardInfo.Cid);
                //显示副卡集合内容
                dgv_BundledList.Rows.Clear();
                foreach (CardInfo item in _mBundledCardinfo)
                {
                    int rowindex = dgv_BundledList.Rows.Add(new object[] { false, item.CardLock, item.CardNumber, item.CardTime, item.ParkingRestrictions });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 停止动画效果显示
        /// </summary>
        private void StopTimer()
        {
            _timer.Stop();
            _timer.Dispose();
            _timer = null;
        }

        /// <summary>
        /// 更新定距卡数据内容
        /// </summary>
        private void UpdateDistanceData()
        {
            //删除移除捆绑的数据
            if (_mBoundDel.Count > 0)
            {
                StringBuilder sbwhere = new StringBuilder(" and ( ");
                foreach (CardInfo item in _mBoundDel)
                {
                    sbwhere.AppendFormat(" ( Cid={0} and Vid={1} ) or", _mCardInfo.Cid, item.Cid);
                }
                sbwhere = sbwhere.Replace("or", " ) ", sbwhere.Length - 2, 2);
                Dal.DbHelper.Db.Del<BundledInfo>(sbwhere.ToString());
                _mBoundDel.Clear();
            }

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
            foreach (CardInfo item in _mBoundAdd)
            {
                item.CardCount = DataCombination.SetCount(item.CardCount);
                if (item.Cid == 0)//添加副卡记录
                {
                    vicecardadd.Add(item);
                }
                else //更新副卡记录
                {
                    vicecardupdate.Add(item);
                }
                //添加到副卡集合
                _mBundledCardinfo.Add(item);
            }
            _mBoundAdd.Clear();

            //数据库添加副卡信息
            if (vicecardadd.Count > 0)
                Dal.DbHelper.Db.Insert<CardInfo>(vicecardadd);
            //数据库更新副卡信息
            if (vicecardupdate.Count > 0)
                Dal.DbHelper.Db.Update<CardInfo>(vicecardupdate);

            //组合新副卡集合
            List<BundledInfo> bundledinfos = new List<BundledInfo>();
            foreach (CardInfo item in vicecardadd)
            {
                bundledinfos.Add(new BundledInfo()
                {
                    Cid = _mCardInfo.Cid,
                    Vid = item.Cid,
                    HostCardNumber = _mCardInfo.CardNumber,
                    ViceCardNumber = item.CardNumber
                });
            }
            foreach (CardInfo item in vicecardupdate)
            {
                bundledinfos.Add(new BundledInfo()
                {
                    Cid = _mCardInfo.Cid,
                    Vid = item.Cid,
                    HostCardNumber = _mCardInfo.CardNumber,
                    ViceCardNumber = item.CardNumber
                });
            }
            //新副卡集合添加致数据库
            Dal.DbHelper.Db.Insert<BundledInfo>(bundledinfos);
        }

        /// <summary>
        /// panel 标题重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void p_Title_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                StringFormat sf = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(Text, p_Title.Font, Brushes.White, new Rectangle(0, 0, p_Title.Width, p_Title.Height), sf);//绘制标题
            }
        }

        /// <summary>
        /// 移除副卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            for (int i = dgv_BundledList.RowCount - 1; i >= 0; i--)
            {
                bool check = Convert.ToBoolean(dgv_BundledList["c_selected", i].Value);
                if (!check) continue;
                string vicecardnumber = dgv_BundledList["c_Number", i].Value.ToString();
                RemoveBoundledViceCard(vicecardnumber);
                dgv_BundledList.Rows.RemoveAt(i);
            }
            btn_Remove.Enabled = false;
            cb_AllSelectedBundled.CheckState = CheckState.Unchecked;
        }

        /// <summary>
        /// 移除捆绑的副卡
        /// </summary>
        /// <param name="cardnumber"></param>
        private void RemoveBoundledViceCard(string cardnumber)
        {
            //移除已绑定的副卡
            foreach (CardInfo item in _mBundledCardinfo)
            {
                if (!item.CardNumber.Equals(cardnumber)) continue;
                _mBoundDel.Add(item);
                _mBundledCardinfo.Remove(item);
                return;
            }
            //移除等待绑定的副卡
            foreach (CardInfo item in _mBoundAdd)
            {
                if (!item.CardNumber.Equals(cardnumber)) continue;
                _mBoundAdd.Remove(item);
                return;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (cb_CardType.SelectedIndex == 1)
            {
                List<CardInfo> newvicecardinfo = new List<CardInfo>();
                newvicecardinfo.AddRange(_mBundledCardinfo);
                newvicecardinfo.AddRange(_mBoundAdd);
                using (ViceCardBundled vicecardbundled = new ViceCardBundled(newvicecardinfo))
                {
                    if (vicecardbundled.ShowDialog() != DialogResult.OK) return;
                    newvicecardinfo = vicecardbundled.Tag as List<CardInfo>;
                    _mBoundAdd.AddRange(newvicecardinfo);
                    foreach (CardInfo item in newvicecardinfo)
                    {
                        dgv_BundledList.Rows.Add(new object[] { false, item.CardLock, item.CardNumber, item.CardTime, item.CardPartition });
                    }
                }
            }
            else
            {
                using (InputLicensePlate inputlicenseplate = new InputLicensePlate())
                {
                    if (inputlicenseplate.ShowDialog() != DialogResult.OK) return;
                    string licenseplate = inputlicenseplate.Tag as string;
                    CardInfo info = DbHelper.Db.FirstDefault<CardInfo>($" and CardNumber='{licenseplate}' ");
                    if (info == null)
                    {
                        info = new CardInfo()
                        {
                            CardNumber = licenseplate,
                            CardType = -1,
                            CardTime = DateTime.Now,
                            CardDistance = 4,
                            CardLock = 0,
                            CardPartition = 0,
                            CardReportLoss = 0,
                        };
                    }
                    _mBoundAdd.Add(info);
                    dgv_BundledList.Rows.Add(new object[] { false, info.CardLock, info.CardNumber, info.CardTime, info.CardPartition });
                }
            }
        }
    }
}