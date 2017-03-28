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
                dinfo.BrakeNumber = (int)ud_BrakeNumber.Value;
                dinfo.OpenModel = cb_OpenModel.SelectedIndex;
                dinfo.ReadCardDelay = cb_ReadCardDelay.SelectedIndex;
                dinfo.Detection = cb_Detection.SelectedIndex;
                dinfo.Language = cb_Language.SelectedIndex;
                dinfo.FuzzyQuery = cb_FuzzyQuery.SelectedIndex;
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
                cb_FuzzyQuery.SelectedIndex = dinfo.FuzzyQuery;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeviceEdit_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Black, 1), 0, 0, Width - 1, Height - 1);
            }
        }

        private void p_Title_MouseDown(object sender, MouseEventArgs e)
        {
            WinApi.ReleaseCapture();
            WinApi.SendMessage(this.Handle, WinApi.WM_SYSCOMMAND, WinApi.SC_MOVE + WinApi.HTCAPTION, 0);
        }

        private void p_Title_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g=e.Graphics)
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