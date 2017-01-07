using Bll;
using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CBZN_TestTool
{
    public partial class CardLoss : Form
    {
        public PortHelper Port { get; set; }
        public List<CardInfo> LossCards { get; set; }
        public static bool IsShow;

        public delegate void LossCountChangeDelegate(int count);
        public event LossCountChangeDelegate LossCountChange;
        private void OnLossCountChange(int count)
        {
            if (LossCountChange == null) return;
            LossCountChange(count);
        }

        public delegate void LossCompleteDelegate();
        public event LossCompleteDelegate LossComplete;
        private void OnLossComplete()
        {
            if (LossComplete == null) return;
            LossComplete();
        }

        private static CardLoss _currentForm;

        public static CardLoss CurrentForm
        {
            get
            {
                if (_currentForm == null)
                    _currentForm = new CardLoss();
                return _currentForm;
            }
        }

        private CardLoss()
        {
            InitializeComponent();
            this.Load += CardLoss_Load;
            this.Shown += CardLoss_Shown;
            this.FormClosing += CardLoss_FormClosing;
        }

        void CardLoss_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!btn_Enter.Enabled && dgv_LossList.RowCount > 0)
            {
                MessageBox.Show("当前正在操作定距卡挂失，无法关闭窗体，请稍后。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        internal void PortDataReceived(DistanceParameter param)
        {
            if (param.AuxiliaryCommand == 0)
            {
                OnLossComplete();
                dgv_LossList.Rows.Clear();
                btn_Enter.Enabled = true;
                Close();
            }
            else
            {
                btn_Enter.Enabled = true;
                MessageBox.Show("定距卡挂失失败，请确认挂失卡是否放置在发行器上。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void CardLoss_Shown(object sender, EventArgs e)
        {
            Port.PortIsOpenChange += PortOpenAndCloseChange;
            IsShow = true;
        }

        private void PortOpenAndCloseChange(object e, bool value)
        {
            btn_Enter.Enabled = value;
        }

        void CardLoss_Load(object sender, EventArgs e)
        {
            foreach (CardInfo item in LossCards)
            {
                dgv_LossList.Rows.Add(new object[] { item.CardNumber, item.CardType, item.CardTime });
            }
        }

        private void CardLoss_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                int width = this.Width / 2, pading = 5;
                Point[] p = new Point[]
                {
                    new Point(0,pading),
                    new Point(width-pading,pading),
                    new Point(width,0),
                    new Point(width+pading,pading),
                    new Point(this.Width-1,pading),
                    new Point(this.Width-1,this.Height-1),
                    new Point(0,this.Height-1),
                    new Point(0,pading)
                };
                g.DrawLines(new Pen(Brushes.Black, 1), p);
            }
        }

        private void CardLoss_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void CardLoss_FormClosed(object sender, FormClosedEventArgs e)
        {
            _currentForm = null;
            Port.PortIsOpenChange -= PortOpenAndCloseChange;
            IsShow = false;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            btn_Enter.Enabled = false;
            try
            {
                List<LossParameter> lossparams = new List<LossParameter>();
                foreach (CardInfo item in LossCards)
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
                Port.Write(by);
            }
            catch (Exception ex)
            {
                btn_Enter.Enabled = true;
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_LossList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btn_Enter.Enabled = Port.IsOpen ? dgv_LossList.RowCount > 0 : false;
        }

        private void dgv_LossList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            btn_Enter.Enabled = Port.IsOpen ? dgv_LossList.RowCount > 0 : false;
            OnLossCountChange(dgv_LossList.RowCount);
        }

        private void dgv_LossList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int index = 0;
                foreach (CardInfo item in LossCards)
                {
                    if (index == e.RowIndex)
                    {
                        LossCards.Remove(item);
                        dgv_LossList.Rows.RemoveAt(e.RowIndex);
                        break;
                    }
                    index++;
                }
            }
        }

        private void dgv_LossList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (CRegex.IsDecimal(e.Value))
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


    }
}
