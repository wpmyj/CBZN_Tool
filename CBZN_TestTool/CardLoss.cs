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
        public delegate void LossCountChangeDelegate(int count);
        public event LossCountChangeDelegate LossCountChange;

        private void OnLossCountChange(int count)
        {
            if (LossCountChange == null) return;
            LossCountChange(count);
        }

        private static CardLoss _currentForm;

        public static CardLoss CurrentForm
        {
            get
            {
                return _currentForm ?? new CardLoss();
            }
        }


        private CardLoss()
        {
            InitializeComponent();
        }

        public void AddLossInfo(CardInfo info)
        {

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
            if (dataGridView1.RowCount == 0)
                _currentForm = null;
        }
    }
}
