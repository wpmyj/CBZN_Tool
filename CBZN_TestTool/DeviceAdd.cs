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
                    DeviceBrand = cb_DeviceBrand.SelectedIndex,
                    BrakeNumber = (int)ud_BrakeNumber.Value,
                    OpenModel = cb_OpenModel.SelectedIndex,
                    ReadCardDelay = cb_ReadCardDelay.SelectedIndex,
                    Detection = cb_Detection.SelectedIndex,
                    Language = cb_Language.SelectedIndex
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

        private void cb_DeviceBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_OpenModel.Items.Clear();
            if (cb_DeviceBrand.SelectedIndex == 0)
            {
                this.cb_OpenModel.Items.AddRange(new object[] {
                    "继电器开闸",
                    "串口开闸",
                    "无线开闸"
                });
                ud_BrakeNumber.Enabled = true;
            }
            else
            {
                this.cb_OpenModel.Items.AddRange(new object[]
                {
                    "继电器开闸",
                    "学习遥控器开闸"
                });
                ud_BrakeNumber.Enabled = false;
            }
            cb_OpenModel.SelectedIndex = 0;
        }

        private void cb_OpenModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_DeviceBrand.SelectedIndex == 0)
            {
                if (cb_OpenModel.SelectedIndex == 0)
                {
                    ud_BrakeNumber.Enabled = false;
                }
                else
                {
                    ud_BrakeNumber.Enabled = true;
                }
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
            cb_DeviceBrand.SelectedIndex = 0;
            cb_CameraDetection.SelectedIndex = 1;
            cb_Partition.SelectedIndex = 0;
            cb_SAPBF.SelectedIndex = 0;
            cb_ReadCardDelay.SelectedIndex = 1;
            cb_Detection.SelectedIndex = 0;
            cb_Language.SelectedIndex = 0;
            GetHostNumber();
        }

        private void DeviceAdd_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1));
            g.DrawRectangle(new Pen(Brushes.Black, 1), rect);
            g.Dispose();
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
        }

        private void l_Title_MouseDown(object sender, MouseEventArgs e)
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
    }
}