using Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;

namespace CBZN_TestTool
{
    public partial class RegisterParameter : Form
    {

        private System.Timers.Timer _effect;

        public RegisterParameter()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            Load += RegisterParameter_Load;
            Paint += RegisterParameter_Paint;
            Resize += RegisterParameter_Resize;
        }

        void RegisterParameter_Resize(object sender, EventArgs e)
        {
            this.Invalidate(new Rectangle(0, cb_CardPartition.Bottom, this.Width - 1, this.Height - cb_CardPartition.Bottom));
        }

        private void RegisterParameter_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 1), new Rectangle(0, 0, Width - 1, Height - 1));
            }
        }

        private void RegisterParameter_Load(object sender, EventArgs e)
        {
            cb_CardPartition.SelectedIndex = 1;
            cb_CardDistance.SelectedIndex = 4;
        }

        private void cb_CardPartition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_CardPartition.SelectedIndex == 0)
            {
                p_CardPartition.Visible = false;
            }

            if (_effect == null)
            {
                _effect = new System.Timers.Timer(1) { AutoReset = true };
                _effect.Elapsed += ShowEffect;
            }
            _effect.Start();
        }

        void ShowEffect(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (cb_CardPartition.SelectedIndex == 0)
            {
                if (this.Height <= 210)
                {
                    this.Height = 210;
                    _effect.Stop();
                    _effect.Dispose();
                    _effect = null;
                    return;
                }
                this.Height -= 15;
            }
            else
            {
                if (this.Height >= 370)
                {
                    this.Height = 370;
                    p_CardPartition.Visible = true;
                    _effect.Stop();
                    _effect.Dispose();
                    _effect = null;
                    return;
                }
                this.Height += 15;
            }
        }

        private void btn_Canel_Click(object sender, EventArgs e)
        {
            Close();
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

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void l_Title_MouseDown(object sender, MouseEventArgs e)
        {
            WinApi.ReleaseCapture();
            WinApi.SendMessage(Handle, WinApi.WM_SYSCOMMAND, WinApi.SC_MOVE + WinApi.HTCAPTION, 0);
        }

        private void cb_AllSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelected.Tag == null)
            {
                foreach (Control item in p_CardPartition.Controls)
                {
                    if (item is CheckBox && item != cb_AllSelected)
                    {
                        CheckBox itemcb = item as CheckBox;
                        itemcb.Checked = cb_AllSelected.Checked;
                    }
                }
            }
            else
            {
                cb_AllSelected.Tag = null;
            }
        }

        private void cb_Partition_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb != null && cb_AllSelected.Checked != cb.Checked)
            {
                cb_AllSelected.Tag = cb_AllSelected.Checked;
                cb_AllSelected.Checked = false;
                cb_AllSelected.Tag = null;
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

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            int paratition = cb_CardPartition.SelectedIndex == 0 ? 0 : GetSelectedPartition();
            int distance = cb_CardDistance.SelectedIndex;
            DateTime time = t_CardTime.Value;

            RegisterParam rp = new RegisterParam()
            {
                Paratition = paratition,
                Distance = distance,
                Time = time
            };

            this.Tag = rp;
            Close();
        }
    }

    public struct RegisterParam
    {
        public int Paratition;
        public int Distance;
        public DateTime Time;
    }
}
