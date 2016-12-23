using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CBZN_TestTool
{
    public partial class BatchRegister : Form
    {
        private Dictionary<int, CardInfo> _dicRegisterList;

        public BatchRegister()
        {
            InitializeComponent();
        }

        public BatchRegister(Dictionary<int, CardInfo> registerlist)
        {
            InitializeComponent();
            _dicRegisterList = registerlist;
        }

        private void BatchRegister_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<int, CardInfo> item in _dicRegisterList)
            {
                dgv_RegisterList.Rows.Add(false, item.Value.CardNumber);
            }
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
            PcommApi.ReleaseCapture();
            PcommApi.SendMessage(Handle, PcommApi.WM_SYSCOMMAND, PcommApi.SC_MOVE + PcommApi.HTCAPTION, 0);
        }

        private void BatchRegister_Shown(object sender, EventArgs e)
        {
            using (RegisterParameter rp = new RegisterParameter())
            {
                rp.ShowDialog();
            }
        }
    }
}