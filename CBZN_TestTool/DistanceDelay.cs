using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CBZN_TestTool
{
    public partial class DistanceDelay : Form
    {
        public DistanceDelay()
        {
            InitializeComponent();
        }

        public DistanceDelay(CardInfo mcardinfo)
        {
            InitializeComponent();
            this._mCardInfo = mcardinfo;
        }

        public List<CardInfo> _mBundledViceCard { get; set; }

        public CardInfo _mCardInfo { get; set; }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_BundledList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {

            }
        }

        private void dgv_BundledList_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                Point[] p = {
                    new Point(0,0),
                    new Point(0,dgv_BundledList.Height-1),
                    new Point(dgv_BundledList.Width-1,dgv_BundledList.Height-1),
                    new Point(dgv_BundledList.Width-1,0)
                };
                g.DrawLines(new Pen(Brushes.Gray), p);
            }
        }

        private void DistanceDelay_Load(object sender, EventArgs e)
        {
            dgv_BundledList.Rows.Add(4);

            _mBundledViceCard = Dal.dal_CardInfo.SelectBound(_mCardInfo.Cid);
            foreach (CardInfo item in _mBundledViceCard)
            {
                dgv_BundledList.Rows.Add(new object[] { item.CardNumber, item.CardTime, item.CardPartition });
            }
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
            WinApi.SendMessage(this.Handle, WinApi.WM_SYSCOMMAND, WinApi.SC_MOVE + WinApi.HTCAPTION, 0);
        }

        private void cb_DelaySelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_DelaySelected.SelectedIndex)
            {
                case 0:
                    l_DelayValueTitle.Text = "延期天数";
                    break;
                case 1:
                    l_DelayValueTitle.Text = "延期月数";
                    break;
                case 2:
                    l_DelayValueTitle.Text = "延期季数";
                    break;
                case 3:
                    l_DelayValueTitle.Text = "延期年数";
                    break;
            }

            bool result = cb_DelaySelected.SelectedIndex > 3;
            t_NewTime.Enabled = !result;
            ud_DelayValue.Enabled = result;
        }
    }
}