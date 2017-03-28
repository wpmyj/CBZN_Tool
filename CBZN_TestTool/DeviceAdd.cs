using Bll;
using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CBZN_TestTool
{
    public partial class DeviceAdd : Form
    {
        public DeviceAdd()
        {
            InitializeComponent();
        }

        public delegate void AddHandler(DeviceInfo dinfo);

        public event AddHandler AddDevice;

        private void btn_Cancel_Click(object sender, EventArgs e)
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
                DeviceInfo dinfo = new DeviceInfo()
                {
                    HostNumber = (int)ud_HostNumber.Value,
                    IOMouth = cb_IOMouth.SelectedIndex,
                    CameraDetection = cb_CameraDetection.SelectedIndex,
                    WirelessNumber = (int)ud_WirelessNumber.Value,
                    FrequencyOffset = (int)ud_FrequencyOffset.Value,
                    Partition = cb_Partition.SelectedIndex,
                    SAPBF = cb_SAPBF.SelectedIndex,
                    CardReadDistance = cb_CardReadDistance.SelectedIndex,
                    BrakeNumber = (int)ud_BrakeNumber.Value,
                    OpenModel = cb_OpenModel.SelectedIndex,
                    ReadCardDelay = cb_ReadCardDelay.SelectedIndex,
                    Detection = cb_Detection.SelectedIndex,
                    Language = cb_Language.SelectedIndex,
                    FuzzyQuery = cb_FuzzyQuery.SelectedIndex
                };
                dinfo.Did = DbHelper.Db.Insert<DeviceInfo>(dinfo);
                OnAddDevice(dinfo);
                if (!cb_Adds.Checked)
                {
                    Close();
                }
                else
                {
                    GetHostNumber();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_CameraDetection_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool result = cb_CameraDetection.SelectedIndex != 0;
            ud_WirelessNumber.Enabled = result;
            ud_FrequencyOffset.Enabled = result;
        }

        private void cb_OpenModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_OpenModel.SelectedIndex >= 2)
            {
                ud_BrakeNumber.Enabled = false;
            }
            else
            {
                ud_BrakeNumber.Enabled = true;
            }
        }

        private void DeviceAdd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void DeviceAdd_Load(object sender, EventArgs e)
        {
            cb_IOMouth.SelectedIndex = 0;
            cb_CardReadDistance.SelectedIndex = 3;
            cb_CameraDetection.SelectedIndex = 1;
            cb_OpenModel.SelectedIndex = 3;
            cb_Partition.SelectedIndex = 0;
            cb_SAPBF.SelectedIndex = 0;
            cb_ReadCardDelay.SelectedIndex = 1;
            cb_Detection.SelectedIndex = 0;
            cb_Language.SelectedIndex = 0;
            cb_FuzzyQuery.SelectedIndex = 0;
            GetHostNumber();
        }

        private void DeviceAdd_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Black, 1), 0, 0, Width - 1, Height - 1);
            }
        }

        private void GetHostNumber()
        {
            int number = 1;
            List<DeviceInfo> dinfos = DbHelper.Db.ToList<DeviceInfo>(true);
            foreach (DeviceInfo item in dinfos)
            {
                if (item.HostNumber == number)
                {
                    number++;
                }
                if (number > ud_HostNumber.Maximum)
                {
                    number = 1;
                }
            }
            ud_HostNumber.Value = number;
            cb_IOMouth.SelectedIndex = number % 2;
        }

        private void p_Title_MouseDown(object sender, MouseEventArgs e)
        {
            WinApi.ReleaseCapture();
            WinApi.SendMessage(this.Handle, WinApi.WM_SYSCOMMAND, WinApi.SC_MOVE + WinApi.HTCAPTION, 0);
        }

        private void OnAddDevice(DeviceInfo dinfo)
        {
            if (AddDevice != null)
            {
                AddDevice(dinfo);
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
                g.DrawString(Text, p_Title.Font, Brushes.White, new Rectangle(0, 0, p_Title.Width, p_Title.Height), sf);
            }
        }
    }
}