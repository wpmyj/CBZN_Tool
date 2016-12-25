using Bll;
using Dal;
using Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CBZN_TestTool
{
    public partial class DeviceEdit : Form
    {
        private long did;
        private DeviceInfo dinfo;

        public DeviceEdit()
        {
            InitializeComponent();
        }

        public DeviceEdit(long did)
        {
            InitializeComponent();
            this.did = did;
        }

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
                dinfo.IOMouth = cb_IOMouth.SelectedIndex;
                dinfo.CameraDetection = cb_CameraDetection.SelectedIndex;
                dinfo.WirelessNumber = (int)ud_WirelessNumber.Value;
                dinfo.FrequencyOffset = (int)ud_FrequencyOffset.Value;
                dinfo.Partition = cb_Partition.SelectedIndex;
                dinfo.SAPBF = cb_SAPBF.SelectedIndex;
                dinfo.CardReadDistance = cb_CardReadDistance.SelectedIndex;
                dinfo.DeviceBrand = cb_DeviceBrand.SelectedIndex;
                dinfo.BrakeNumber = (int)ud_BrakeNumber.Value;
                dinfo.OpenModel = cb_OpenModel.SelectedIndex;
                dinfo.ReadCardDelay = cb_ReadCardDelay.SelectedIndex;
                dinfo.Detection = cb_Detection.SelectedIndex;
                dinfo.Language = cb_Language.SelectedIndex;
                DbHelper.Db.Update<DeviceInfo>(dinfo);
                Tag = dinfo;
                Close();
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
            try
            {
                dinfo = DbHelper.Db.FirstDefault<DeviceInfo>(did);
                if (dinfo == null)
                {
                    Close();
                    return;
                }
                ud_HostNumber.Value = dinfo.HostNumber;
                cb_CardReadDistance.SelectedIndex = dinfo.CardReadDistance;
                cb_IOMouth.SelectedIndex = dinfo.IOMouth;
                cb_DeviceBrand.SelectedIndex = dinfo.DeviceBrand;
                cb_CameraDetection.SelectedIndex = dinfo.CameraDetection;
                ud_BrakeNumber.Value = dinfo.BrakeNumber;
                ud_WirelessNumber.Value = dinfo.WirelessNumber;
                cb_OpenModel.SelectedIndex = dinfo.OpenModel;
                ud_FrequencyOffset.Value = dinfo.FrequencyOffset;
                cb_ReadCardDelay.SelectedIndex = dinfo.ReadCardDelay;
                cb_Partition.SelectedIndex = dinfo.Partition;
                cb_Detection.SelectedIndex = dinfo.Detection;
                cb_SAPBF.SelectedIndex = dinfo.SAPBF;
                cb_Language.SelectedIndex = dinfo.Language;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeviceEdit_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1));
            g.DrawRectangle(new Pen(Brushes.Black, 1), rect);
            g.Dispose();
        }

        private void l_Title_MouseDown(object sender, MouseEventArgs e)
        {
            PcommApi.ReleaseCapture();
            PcommApi.SendMessage(this.Handle, PcommApi.WM_SYSCOMMAND, PcommApi.SC_MOVE + PcommApi.HTCAPTION, 0);
        }
    }
}