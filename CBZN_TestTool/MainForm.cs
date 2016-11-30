using Bll;
using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Dal;
using Model;

namespace CBZN_TestTool
{
    public partial class MainForm : Form
    {
        #region 变量

        private ComPortHelper _mComPort;
        private PortHelper _mPort;
        private System.Timers.Timer _tiConnectionPort;
        private Mutex _mMutex;

        #endregion 变量

        #region 窗体事件

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            p_Tap2.Visible = false;
            p_Tap3.Visible = false;
            p_Tap4.Visible = false;

            DataValidation.IsProtocol = true;
            DataValidation.ProtocolHead = 2;
            DataValidation.ProtocolEnd = 3;
            DataValidation.IsValidation = true;

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            _mPort = new PortHelper
            {
                PortIsOpenChange = PortOpenAndCloseChange,
                PortDataReceived = PortDataReceived
            };

            _mComPort = new ComPortHelper();
            _mComPort.CountChange += MComPortCountChange;
        }

        private void p_Title_MouseDown(object sender, MouseEventArgs e)
        {
            WinApi.ReleaseCapture();
            WinApi.SendMessage(this.Handle, WinApi.WM_SYSCOMMAND, WinApi.SC_MOVE + WinApi.HTCAPTION, 0);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_Tap1_Click(object sender, EventArgs e)
        {
            AcceptButton = btn_Read;
            ShowHideTap(btn_Tap1);
        }

        private void btn_Tap2_Click(object sender, EventArgs e)
        {
            ShowHideTap(btn_Tap2);
        }

        private void btn_Tap3_Click(object sender, EventArgs e)
        {
            ShowHideTap(btn_Tap3);
        }

        private void btn_Tap4_Click(object sender, EventArgs e)
        {
            ShowHideTap(btn_Tap4);
        }

        private void ShowHideTap(SkinButton btn)
        {
            ShowSelectedEffect(btn);
            p_Tap1.Visible = btn == btn_Tap1;
            p_Tap2.Visible = btn == btn_Tap2;
            p_Tap3.Visible = btn == btn_Tap3;
            p_Tap4.Visible = btn == btn_Tap4;
        }

        private void ShowSelectedEffect(SkinButton btn)
        {
            Color c = Color.Transparent;
            if (!btn_Tap1.Enabled)
            {
                c = ToEnableThe(btn_Tap1);
            }
            if (!btn_Tap2.Enabled)
            {
                c = ToEnableThe(btn_Tap2);
            }
            if (!btn_Tap3.Enabled)
            {
                c = ToEnableThe(btn_Tap3);
            }
            if (!btn_Tap4.Enabled)
            {
                c = ToEnableThe(btn_Tap4);
            }

            btn.BaseColor = c;
            btn.Enabled = false;
        }

        private Color ToEnableThe(SkinButton btn)
        {
            Color c = btn.BaseColor;
            btn.BaseColor = Color.Transparent;
            btn.Enabled = true;
            return c;
        }

        #endregion 窗体事件

        #region 端口事件

        private void MComPortCountChange(List<string> portnames)
        {
            if (_mPort.IsOpen)
            {
                if (!portnames.Contains(_mPort.PortName))
                {
                    _mPort.IsOpen = false;
                    try
                    {
                        _mPort.Close();
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
            if (!_mPort.IsOpen)
            {
                if (_tiConnectionPort == null)
                {
                    _mMutex = new Mutex();
                    _tiConnectionPort = new System.Timers.Timer(250) {AutoReset = true};
                    _tiConnectionPort.Elapsed += _tiConnectionPort_Elapsed;
                }
                _tiConnectionPort.Start();
            }
        }

        private void _tiConnectionPort_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _mMutex.WaitOne();


            if (_mPort.IsOpen)
            {
                _tiConnectionPort.Stop();
                _tiConnectionPort.Dispose();
            }
            _mMutex.ReleaseMutex();
        }

        private void PortDataReceived(int port)
        {
            try
            {
                Thread.Sleep(30);
                int len = _mPort.GetBytesToRead();
                if (len < 3) return;
                byte[] by = new byte[len];
                _mPort.Read(by, len);
                List<byte[]> bylist = DataValidation.Validation(by);
                foreach (byte[] item in bylist)
                {
                    ParsingParameter parameter = DataParsing.ParsingContent(item);
                    switch (parameter.FunctionAddress)
                    {
                        case 0:

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PortOpenAndCloseChange(object e, bool value)
        {
            if (value)
            {
                btn_Read.Enabled = true;
                dgv_DataList_SelectionChanged(null, null);
            }
            else
            {
                btn_Read.Enabled = false;
                btn_Register.Enabled = false;
                btn_Registers.Enabled = false;
                btn_ReportTheLossOf.Enabled = false;
            }

            btn_DistanceDeviceEnter.Enabled = value;
            btn_DistanceCardPwdEnter.Enabled = value;
            btn_TemporaryCardPwdEnter.Enabled = value;
            btn_TemporaryDevicePwdEnter.Enabled = value;
        }

        #endregion 端口事件

        #region 卡片操作

        private void btn_Read_Click(object sender, EventArgs e)
        {
            dgv_DataList.Rows.Clear();
            btn_Read.Enabled = false;
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
        }

        private void btn_Registers_Click(object sender, EventArgs e)
        {
        }

        private void btn_ReportTheLossOf_Click(object sender, EventArgs e)
        {
        }

        private void btn_ShowRecord_Click(object sender, EventArgs e)
        {
            if (!btn_Read.Enabled)
            {
                MessageBox.Show(@"当前正在读取定距卡信息，无法显示注册信息。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                int count = DbHelper.Db.GetCount<CardInfo>();
                int page = count / 30;
                if (page % 30 > 0)
                    page++;
                if (page > 0)
                {
                    for (int i = 0; i < page; i++)
                    {
                        cb_Page.Items.Add(string.Format("{0}页", i));
                    }
                }
                else
                {
                    cb_Page.Items.Add("1页");
                }
                l_RecordCount.Text = string.Format("总共 {0} 条记录", count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv_DataList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void dgv_DataList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void dgv_DataList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgv_DataList.RowCount == 0)
            {
                btn_Register.Enabled = false;
                btn_Registers.Enabled = false;
                btn_ReportTheLossOf.Enabled = false;
            }
        }

        private void dgv_DataList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_DataList.RowCount == 0) return;
            if (btn_Read.Enabled)
                if (_mPort != null && _mPort.IsOpen)
                {
                    btn_Register.Enabled = true;
                    btn_Registers.Enabled = true;
                    btn_ReportTheLossOf.Enabled = true;
                }
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            cb_Page.SelectedIndex -= 1;
        }

        private void cb_Page_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cb_Page.SelectedIndex;

            btn_Previous.Enabled = index != 0;
            btn_Next.Enabled = index != cb_Page.Items.Count - 1;

            List<CardInfo> cardinfos = DbHelper.Db.ToList<CardInfo>(index * 30, 30);
            AddRange(cardinfos);
        }

        private void Add(CardInfo info)
        {
            PropertyInfo[] pis =
                typeof(CardInfo).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            DataGridViewRow dr = new DataGridViewRow();
            foreach (PropertyInfo item in pis)
            {
                dr.Cells[item.Name].Value = item.GetValue(info, null);
            }
            dgv_DataList.Rows.Add(dr); ;
        }

        private void AddRange(List<CardInfo> cardinfos)
        {
            PropertyInfo[] pis =
    typeof(CardInfo).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (CardInfo item in cardinfos)
            {
                DataGridViewRow dr = new DataGridViewRow();
                foreach (PropertyInfo pi in pis)
                {
                    dr.Cells[pi.Name].Value = pi.GetValue(item, null);
                }
                rows.Add(dr);
            }
            dgv_DataList.Rows.AddRange(rows.ToArray());
        }

        private void Edit(CardInfo info, int index)
        {
            PropertyInfo[] pis =
    typeof(CardInfo).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            DataGridViewRow dr = dgv_DataList.Rows[index];
            foreach (PropertyInfo item in pis)
            {
                dr.Cells[item.Name].Value = item.GetValue(info, null);
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            cb_Page.SelectedIndex += 1;
        }

        #endregion 卡片操作

        #region 加密操作

        private void btn_TapDistanceEncryption_Click(object sender, EventArgs e)
        {
            ShowHideEncryptionTap(btn_TapDistanceEncryption);
        }

        private void btn_TapTemporaryEncryption_Click(object sender, EventArgs e)
        {
            ShowHideEncryptionTap(btn_TapTemporaryEncryption);
        }

        private void DrawBorder(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(Color.Gray), panel.Width - 1, 0, panel.Width - 1, panel.Height);
        }

        private void ShowHideEncryptionTap(SkinButton btn)
        {
            ShowSelectedEncryptionEffect(btn);
            p_DistanceInterface.Visible = btn == btn_TapDistanceEncryption;
            p_TemporaryInterface.Visible = btn == btn_TapTemporaryEncryption;
        }

        private void ShowSelectedEncryptionEffect(SkinButton btn)
        {
            Color c = Color.Transparent;
            if (!btn_TapDistanceEncryption.Enabled)
            {
                c = ToEnableThe(btn_TapDistanceEncryption);
            }
            if (!btn_TapTemporaryEncryption.Enabled)
            {
                c = ToEnableThe(btn_TapTemporaryEncryption);
            }
            btn.BaseColor = c;
            btn.Enabled = false;
        }

        private void TxtKeyProcess(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || (e.KeyChar >= 48 && e.KeyChar <= 57))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void dgv_pwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void dgv_pwd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgv_pwd.FirstDisplayedScrollingRowIndex = e.RowIndex;
        }

        #region 定距加密

        private void btn_DistanceCardPwdEnter_Click(object sender, EventArgs e)
        {
            AcceptButton = btn_DistanceCardPwdEnter;
        }

        private void btn_DistanceDeviceEnter_Click(object sender, EventArgs e)
        {
            AcceptButton = btn_DistanceDeviceEnter;
        }

        private void cb_DefaultDistanceCardPwd_CheckedChanged(object sender, EventArgs e)
        {
            bool result = !cb_DefaultDistanceCardPwd.Checked;
            tb_DistanceCardpwd.Enabled = result;
            tb_ConfirmDistanceCardPwd.Enabled = result;
            if (!result)
            {
                string pwd = "766554";
                tb_DistanceCardpwd.Text = pwd;
                tb_ConfirmDistanceCardPwd.Text = pwd;
                btn_DistanceCardPwdEnter.Focus();
            }
            else
            {
                tb_DistanceCardpwd.Text = string.Empty;
                tb_ConfirmDistanceCardPwd.Text = string.Empty;
                tb_DistanceCardpwd.Focus();
            }
        }

        private void cb_DefaultDistanceDevicePwd_CheckedChanged(object sender, EventArgs e)
        {
            bool result = !cb_DefaultDistanceDevicePwd.Checked;
            tb_DistanceDevicePwd.Enabled = result;
            tb_ConfirmDistanceDevicePwd.Enabled = result;
            if (!result)
            {
                string pwd = "766554";
                tb_DistanceDevicePwd.Text = pwd;
                tb_ConfirmDistanceDevicePwd.Text = pwd;
                btn_DistanceDeviceEnter.Focus();
            }
            else
            {
                tb_DistanceDevicePwd.Text = string.Empty;
                tb_ConfirmDistanceDevicePwd.Text = string.Empty;
                tb_DistanceDevicePwd.Focus();
            }
        }

        private void tb_DistanceDevicePwd_KeyUp(object sender, KeyEventArgs e)
        {
            DevicePwdKeyUp(sender, e);
        }

        private void tb_ConfirmDistanceDevicePwd_KeyUp(object sender, KeyEventArgs e)
        {
            DevicePwdKeyUp(sender, e);
        }

        private void DevicePwdKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_DistanceDeviceEnter_Click(null, null);
            }
        }

        private void tb_DistanceCardpwd_KeyUp(object sender, KeyEventArgs e)
        {
            DistanceCardPwdKeyUp(sender, e);
        }

        private void tb_ConfirmDistanceCardPwd_KeyUp(object sender, KeyEventArgs e)
        {
            DistanceCardPwdKeyUp(sender, e);
        }

        private void DistanceCardPwdKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_DistanceCardPwdEnter_Click(null, null);
            }
        }

        private void p_DistanceInterface_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder(sender, e);
        }

        #endregion 定距加密

        #region 临时加密

        private void btn_TemporaryCardPwdEnter_Click(object sender, EventArgs e)
        {
            AcceptButton = btn_TemporaryCardPwdEnter;
        }

        private void btn_TemporaryDevicePwdEnter_Click(object sender, EventArgs e)
        {
            AcceptButton = btn_TemporaryDevicePwdEnter;
        }

        private void cb_DefaultTemporaryCardPwd_CheckedChanged(object sender, EventArgs e)
        {
            bool result = !cb_DefaultTemporaryCardPwd.Checked;
            tb_TemporaryCardPwd.Enabled = result;
            tb_ConfirmTemporaryCardPwd.Enabled = result;
            if (!result)
            {
                string pwd = "FFFFFF";
                tb_TemporaryCardPwd.Text = pwd;
                tb_ConfirmTemporaryCardPwd.Text = pwd;
                btn_TemporaryCardPwdEnter.Focus();
            }
            else
            {
                tb_TemporaryCardPwd.Text = string.Empty;
                tb_ConfirmTemporaryCardPwd.Text = string.Empty;
                tb_TemporaryCardPwd.Focus();
            }
        }

        private void tb_ConfirmTemporaryCardPwd_KeyUp(object sender, KeyEventArgs e)
        {
            TemporaryCardPwdKeyUp(sender, e);
        }

        private void tb_TemporaryCardPwd_KeyUp(object sender, KeyEventArgs e)
        {
            TemporaryCardPwdKeyUp(sender, e);
        }

        private void TemporaryCardPwdKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_TemporaryCardPwdEnter_Click(null, null);
            }
        }

        private void cb_DefaultTemporaryDevicePwd_CheckedChanged(object sender, EventArgs e)
        {
            bool result = !cb_DefaultTemporaryDevicePwd.Checked;
            tb_TemporaryDevicePwd.Enabled = result;
            tb_ConfirmTemporaryDevicePwd.Enabled = result;
            if (!result)
            {
                string pwd = "FFFFFF";
                tb_TemporaryDevicePwd.Text = pwd;
                tb_ConfirmTemporaryDevicePwd.Text = pwd;
                btn_TemporaryDevicePwdEnter.Focus();
            }
            else
            {
                tb_TemporaryDevicePwd.Text = string.Empty;
                tb_ConfirmTemporaryDevicePwd.Text = string.Empty;
                tb_TemporaryDevicePwd.Focus();
            }
        }

        private void tb_ConfirmTemporaryDevicePwd_KeyUp(object sender, KeyEventArgs e)
        {
            TemporaryDevicePwdKeyUp(sender, e);
        }

        private void tb_TemporaryDevicePwd_KeyUp(object sender, KeyEventArgs e)
        {
            TemporaryDevicePwdKeyUp(sender, e);
        }

        private void TemporaryDevicePwdKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_TemporaryDevicePwdEnter_Click(null, null);
            }
        }

        private void p_TemporaryInterface_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder(sender, e);
        }

        #endregion 临时加密

        #endregion 加密操作

    }
}