using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Dal;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Text;

namespace CBZN_TestTool
{
    public partial class ViceCardDelay : Form
    {
        private int _mouseEnterIndex = -1;
        private bool _isDown;
        public static bool IsShow;
        private static ViceCardDelay _instance;

        public static ViceCardDelay Instance
        {
            get { return _instance ?? (_instance = new ViceCardDelay()); }
        }

        public delegate void DelayDataChangeHandler(CardInfo hostcardinfo, List<CardInfo> vicecard);

        public event DelayDataChangeHandler DelayDataChange;

        private void OnDelayDataChange(CardInfo hostcardinfo, List<CardInfo> vicecard)
        {
            if (DelayDataChange != null)
            {
                DelayDataChange(hostcardinfo, vicecard);
            }
        }

        private ViceCardDelay()
        {
            InitializeComponent();
        }

        public List<CardInfo> _mBundledViceCard { get; set; }

        public CardInfo _mCardInfo { get; set; }

        public PortHelper _mPort { get; set; }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void PortDataReceived(DistanceParameter param)
        {
            if (param.AuxiliaryCommand == 0)
            {
                DbHelper.Db.Update<CardInfo>(_mBundledViceCard);
                DbHelper.Db.Update<CardInfo>(_mCardInfo);
                OnDelayDataChange(_mCardInfo, _mBundledViceCard);
                Close();
            }
            else
            {
                MessageBox.Show("请确认定距卡是否放置在读卡区域内", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_BundledList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 4) return;
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

        private void dgv_BundledList_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawLine(new Pen(Brushes.Gray), 0, dgv_BundledList.Height - 1, dgv_BundledList.Width - 1, dgv_BundledList.Height - 1);
            }
        }

        private void DistanceDelay_Load(object sender, EventArgs e)
        {
            IsShow = true;
            if (_mPort != null)
            {
                _mPort.PortIsOpenChange += PortOpenAndCloseChange;
                btn_Enter.Enabled = _mPort.IsOpen;
            }
            if (_mCardInfo != null)
            {
                _mBundledViceCard = dal_CardInfo.SelectBound(_mCardInfo.Cid);
                foreach (CardInfo item in _mBundledViceCard)
                {
                    dgv_BundledList.Rows.Add(new object[] { false, item.CardNumber, item.CardTime, DateTime.MinValue, item.CardPartition });
                }
            }
        }

        private void ViceCardDelay_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsShow = false;
            _instance = null;
            if (_mPort != null)
            {
                _mPort.PortIsOpenChange -= PortOpenAndCloseChange;
            }
        }

        private void ViceCardDelay_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void PortOpenAndCloseChange(object e, bool flag)
        {
            btn_Enter.Enabled = flag;
        }

        private void DistanceDelay_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 1), new Rectangle(0, 0, Width - 1, Height - 1));
            }
        }

        private void p_Title_MouseDown(object sender, MouseEventArgs e)
        {
            WinApi.ReleaseCapture();
            WinApi.SendMessage(Handle, WinApi.WM_SYSCOMMAND, WinApi.SC_MOVE + WinApi.HTCAPTION, 0);
        }

        private void dgv_BundledList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!(dgv_BundledList.Columns[e.ColumnIndex] is DataGridViewButtonColumn)) return;
            Graphics g = e.Graphics;
            e.PaintBackground(e.CellBounds, true);
            Color background = Color.White;
            Color forecolor = dgv_BundledList.DefaultCellStyle.ForeColor;
            Color bordercolor = Color.Gray;
            if (dgv_BundledList.Enabled)
            {
                if (e.RowIndex == _mouseEnterIndex && _isDown)
                {
                    background = Color.FromArgb(240, 88, 35);
                    forecolor = Color.White;
                    bordercolor = background;
                }
                else if (e.RowIndex == _mouseEnterIndex)
                {
                    background = Color.FromArgb(255, 106, 49);
                    bordercolor = background;
                    forecolor = Color.White;
                }
            }
            else
            {
                background = Color.Gray;
                forecolor = Color.White;
                bordercolor = Color.Gray;
            }
            DrawButton(g, e.CellBounds, background, forecolor, bordercolor);
            e.Handled = true;
        }

        private void DrawButton(Graphics g, Rectangle rect, Color background, Color forecolor, Color linecolor)
        {
            DataGridViewButtonColumn buttoncolumn = dgv_BundledList.Columns[5] as DataGridViewButtonColumn;
            StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X + 5, rect.Y + 3, 10, 10, 180, 90);
            path.AddArc(rect.Right - 15, rect.Y + 3, 10, 10, 270, 90);
            path.AddArc(rect.Right - 15, rect.Bottom - 15, 10, 10, 360, 90);
            path.AddArc(rect.X + 5, rect.Bottom - 15, 10, 10, 90, 90);
            path.AddLine(rect.X + 5, rect.Y + 8, rect.X + 5, rect.Bottom - 15);
            g.FillPath(new SolidBrush(background), path);
            g.DrawPath(new Pen(new SolidBrush(linecolor), 1), path);
            g.DrawString(buttoncolumn.Text, dgv_BundledList.DefaultCellStyle.Font, new SolidBrush(forecolor), rect, sf);
        }

        private void dgv_BundledList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 5) return;
            _mouseEnterIndex = e.RowIndex;
            Rectangle rect = GetCellRectangle(e.RowIndex, e.ColumnIndex);
            dgv_BundledList.Invalidate(rect);
        }

        private void dgv_BundledList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 5) return;
            _mouseEnterIndex = -1;
            Rectangle rect = GetCellRectangle(e.RowIndex, e.ColumnIndex);
            dgv_BundledList.Invalidate(rect);
        }

        private Rectangle GetCellRectangle(int rowindex, int columnindex)
        {
            Rectangle rect = dgv_BundledList.GetCellDisplayRectangle(columnindex, rowindex, true);
            return rect;
        }

        private void dgv_BundledList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 5) return;
            if (_mouseEnterIndex == e.RowIndex)
                _isDown = true;
        }

        private void dgv_BundledList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_isDown)
                _isDown = false;
        }

        private void dgv_BundledList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!(dgv_BundledList.Columns[e.ColumnIndex] is DataGridViewButtonColumn)) return;
            using (DelayParam dp = DelayParam.Instance)
            {
                dp.ShowDialog();
                if (dp.Tag == null) return;
                DelayParamValue param = (DelayParamValue)dp.Tag;
                CardInfo mcardinfo = _mBundledViceCard[e.RowIndex];
                dgv_BundledList.Rows[e.RowIndex].Cells[3].Value = param.DelayTime != mcardinfo.CardTime ? param.DelayTime : DateTime.MinValue;
                dgv_BundledList.Rows[e.RowIndex].Cells[4].Value = param.Partition != mcardinfo.CardPartition ? param.Partition : mcardinfo.CardPartition;

                mcardinfo.CardTime = param.DelayTime;
                mcardinfo.CardPartition = param.Partition;
            }
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
                g.DrawString(Text, new Font("微软雅黑", 10.5F), Brushes.White, new Rectangle(0, 0, p_Title.Width, p_Title.Height), sf);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {

            if (_mBundledViceCard.Count > 0)
            {
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

                byte[] by = null;
                switch (_mCardInfo.CardType)
                {
                    case 1:
                        List<ViceCardData> vicecarddatas = new List<ViceCardData>();
                        foreach (CardInfo item in _mBundledViceCard)
                        {
                            ViceCardData vicecarddata = new ViceCardData()
                            {
                                ViceNumber = item.CardNumber,
                                Time = item.CardTime,
                                Partition = item.ParkingRestrictions,
                                Count = ++item.CardCount
                            };
                            vicecarddatas.Add(vicecarddata);
                        }
                        by = DataCombination.CombinationDistanceCard(distancecontent, vicecarddatas);
                        break;
                    case 2:
                        List<PlateCardData> platecarddatas = new List<PlateCardData>();
                        foreach (CardInfo item in _mBundledViceCard)
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
                {
                    _mPort.Write(by);
                }
            }
            else
            {
                Close();
            }
        }

        private void btn_BatchDelay_Click(object sender, EventArgs e)
        {
            using (DelayParam dp = DelayParam.Instance)
            {
                dp.ShowDialog();
                if (dp.Tag == null) return;
                DelayParamValue param = (DelayParamValue)dp.Tag;
                for (int i = 0; i < dgv_BundledList.RowCount; i++)
                {
                    if ((bool)dgv_BundledList.Rows[i].Cells["cSelected"].Value)
                    {
                        CardInfo mcardinfo = _mBundledViceCard[i];
                        dgv_BundledList.Rows[i].Cells[3].Value = param.DelayTime != mcardinfo.CardTime ? param.DelayTime : DateTime.MinValue;
                        dgv_BundledList.Rows[i].Cells[4].Value = param.Partition != mcardinfo.CardPartition ? param.Partition : mcardinfo.CardPartition;
                        mcardinfo.CardTime = param.DelayTime;
                        mcardinfo.CardPartition = param.Partition;
                    }
                }
            }
        }

        private void btn_BatchDelay_Paint(object sender, PaintEventArgs e)
        {
            if (btn_BatchDelay.Enabled) return;
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(new Point(0, 0), btn_BatchDelay.Size);
            StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.FillRectangle(Brushes.Gray, rect);
            g.DrawRectangle(new Pen(Brushes.White, 1), rect);
            g.DrawString(btn_BatchDelay.Text, btn_BatchDelay.Font, Brushes.White, rect, sf);
        }

        private void cb_Select_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Select.CheckState == CheckState.Indeterminate) return;
            for (int i = 0; i < dgv_BundledList.RowCount; i++)
            {
                dgv_BundledList.Rows[i].Cells[0].Value = cb_Select.Checked;
            }
        }

        private void dgv_BundledList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_BundledList.IsCurrentCellDirty)
                dgv_BundledList.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgv_BundledList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0) return;
            object obj = dgv_BundledList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            bool flag = Convert.ToBoolean(obj);
            if (flag != cb_Select.Checked)
                cb_Select.CheckState = CheckState.Indeterminate;
            btn_BatchDelay.Enabled = GetChecked();
        }

        private bool GetChecked()
        {
            for (int i = 0; i < dgv_BundledList.RowCount; i++)
            {
                object obj = dgv_BundledList.Rows[i].Cells[0].Value;
                bool check = Convert.ToBoolean(obj);
                if (check)
                    return true;
            }
            return false;
        }

    }
}