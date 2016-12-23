using Bll;
using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CBZN_TestTool
{
    public partial class DeviceExport : Form
    {
        private string _where;

        public DeviceExport(string where)
        {
            InitializeComponent();
            this._where = where;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            bool result = VerifyContent();
            if (result) return;
            StreamWriter sw = null;

            try
            {
                int index = cb_Path.SelectedIndex;
                if (index == -1)
                {
                    MessageBox.Show(@"请选择导出的路径", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    cb_Path.Focus();
                    cb_Path.DroppedDown = true;
                    return;
                }
                DriveInfo[] driveinfos = DriveInfo.GetDrives();
                if (index >= driveinfos.Length)
                {
                    MessageBox.Show(@"无效磁盘路径", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cb_Path.Focus();
                    cb_Path.DroppedDown = true;
                    return;
                }
                string path = driveinfos[index].Name;
                path += "\\SZCBKJ";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += "\\OS";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                bool defaultcontrolpwd = cb_DefaultControlPwd.Checked;
                string controlpwd;
                if (defaultcontrolpwd)
                    controlpwd = "00000000000000";
                else
                    controlpwd = "3355AAEE" + tb_ControlPwd.Text;

                string oldhostpwd = tb_OldHostPwd.Text;
                string hostpwd = tb_HostPwd.Text;
                string cardmachine = tb_CardMachinePwd.Text;

                List<DeviceInfo> deviceinfos = DbHelper.Db.ToList<DeviceInfo>(_where);
                foreach (DeviceInfo item in deviceinfos)
                {
                    Dictionary<int, string> dic = new Dictionary<int, string>();
                    dic.Add(0, string.Format("{0:X2}{1:X2}{2}{3:X2}", item.HostNumber, item.FrequencyOffset, (item.CameraDetection == 0 ? string.Format("{0:X8}", item.HostNumber) : item.WirelessNumber.ToString().PadLeft(8, '0')), item.CameraDetection));//编号
                    dic.Add(1, string.Format("{0:X2}", item.CardReadDistance));//距离
                    dic.Add(2, string.Format("{0:X2}", item.ReadCardDelay));//设备延时
                    dic.Add(3, "");//客户编号 9887
                    dic.Add(4, oldhostpwd + hostpwd);//主机密码
                    dic.Add(5, "");//保留
                    dic.Add(6, "0101");//IC开关
                    dic.Add(7, DateTime.Now.ToString("yyMMddHHmmss"));//时间
                    dic.Add(8, string.Format("{0:X2}", item.Partition));//场分区
                    dic.Add(9, string.Format("{0:X2}", item.IOMouth));//进出口标志
                    dic.Add(10, string.Format("{0:X2}", item.SAPBF));//返潜回
                    dic.Add(11, controlpwd);//控制板密码
                    string str = string.Empty;
                    switch (item.OpenModel)
                    {
                        case 1:
                            str = item.DeviceBrand == 0 ? string.Format("{0:X6}FF", item.BrakeNumber) : "FFFFFFAA";//串口开闸  学习开闸
                            break;

                        case 2:
                            str = string.Format("{0:X6}55", item.BrakeNumber);//无线开闸
                            break;

                        default:
                            str = "FFFFFFF0";//继电器开闸
                            break;
                    }
                    dic.Add(12, str);
                    dic.Add(13, string.Format("{0:X2}", item.Language));//语言种类
                    dic.Add(14, "1E");
                    dic.Add(15, string.Format("{0:X2}", item.Detection));//车辆检测
                    dic.Add(16, cardmachine);//出卡机密码

                    sw = File.CreateText(string.Format("{0}\\FORM{1:X2}.txt", path, item.HostNumber));
                    foreach (KeyValuePair<int, string> key in dic)
                    {
                        sw.WriteLine("00{0:X2}<{1:X2},{2},{3:X2}>", key.Key, key.Value.Length, key.Value,
                        HexadecimalConversion.AsciiToInt(DataValidation.Xor(key.Value)));
                    }
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
                Close();
            }
        }

        private void cb_DefaultCardMachinePwd_CheckedChanged(object sender, EventArgs e)
        {
            bool result = !cb_DefaultCardMachinePwd.Checked;
            tb_CardMachinePwd.Enabled = result;
            tb_ConfirmCardMachinePwd.Enabled = result;
            if (!result)
            {
                string str = "FFFFFFFF";
                tb_CardMachinePwd.Text = str;
                tb_ConfirmCardMachinePwd.Text = str;
            }
            else
            {
                tb_CardMachinePwd.Text = string.Empty;
                tb_ConfirmCardMachinePwd.Text = string.Empty;
                tb_CardMachinePwd.Focus();
            }
        }

        private void cb_DefaultControlPwd_CheckedChanged(object sender, EventArgs e)
        {
            bool result = !cb_DefaultControlPwd.Checked;
            tb_ControlPwd.Enabled = result;
            tb_ConfirmControlPwd.Enabled = result;
            tb_ControlPwd.Text = string.Empty;
            tb_ConfirmControlPwd.Text = string.Empty;
            //3355AAEE
        }

        private void cb_DefaultHostPwd_CheckedChanged(object sender, EventArgs e)
        {
            bool result = !cb_DefaultHostPwd.Checked;
            tb_HostPwd.Enabled = result;
            tb_ConfirmHostPwd.Enabled = result;
            if (!result)
            {
                string str = "766554";
                tb_HostPwd.Text = str;
                tb_ConfirmHostPwd.Text = str;
            }
            else
            {
                tb_HostPwd.Text = string.Empty;
                tb_ConfirmHostPwd.Text = string.Empty;
                tb_HostPwd.Focus();
            }
        }

        private void cb_DefaultOldHostPwd_CheckedChanged(object sender, EventArgs e)
        {
            bool result = !cb_DefaultOldHostPwd.Checked;
            tb_OldHostPwd.Enabled = result;
            if (!result)
            {
                tb_OldHostPwd.Text = @"766554";
            }
            else
            {
                tb_OldHostPwd.Text = string.Empty;
                tb_OldHostPwd.Focus();
            }
        }

        private void cb_Path_DropDown(object sender, EventArgs e)
        {
            cb_Path.Items.Clear();
            DriveInfo[] driveinfos = DriveInfo.GetDrives();
            foreach (DriveInfo item in driveinfos)
            {
                cb_Path.Items.Add(item.Name);
            }
            cb_Path.SelectedIndex = 0;
        }

        private void cb_SetCardMachinePwd_CheckedChanged(object sender, EventArgs e)
        {
            bool result = cb_SetCardMachinePwd.Checked;
            cb_DefaultCardMachinePwd.Enabled = result;
            if (!cb_DefaultCardMachinePwd.Checked)
            {
                tb_CardMachinePwd.Enabled = result;
                tb_ConfirmCardMachinePwd.Enabled = result;
            }
        }

        private void cb_SetControlPwd_CheckedChanged(object sender, EventArgs e)
        {
            bool result = cb_SetControlPwd.Checked;
            cb_DefaultControlPwd.Enabled = result;
            if (!cb_DefaultControlPwd.Checked)
            {
                tb_ControlPwd.Enabled = result;
                tb_ConfirmControlPwd.Enabled = result;
            }
        }

        private void cb_SetHostPwd_CheckedChanged(object sender, EventArgs e)
        {
            bool result = cb_SetHostPwd.Checked;
            cb_DefaultHostPwd.Enabled = result;
            if (!cb_DefaultHostPwd.Checked)
            {
                tb_HostPwd.Enabled = result;
                tb_ConfirmHostPwd.Enabled = result;
            }

            cb_DefaultOldHostPwd.Enabled = result;
            if (!cb_DefaultOldHostPwd.Checked)
            {
                tb_OldHostPwd.Enabled = result;
            }
        }

        private void DeviceExport_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void DeviceExport_Load(object sender, EventArgs e)
        {
        }

        private void DeviceExport_MouseDown(object sender, MouseEventArgs e)
        {
            PcommApi.ReleaseCapture();
            PcommApi.SendMessage(this.Handle, PcommApi.WM_SYSCOMMAND, PcommApi.SC_MOVE + PcommApi.HTCAPTION, 0);
        }

        private void TxtKeyPress(object sender, KeyPressEventArgs e)
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

        private bool VerifyContent()
        {
            if (cb_SetControlPwd.Checked)
            {
                string controlpwd = tb_ControlPwd.Text;
                string confirmcontrolpwd = tb_ConfirmControlPwd.Text;
                if (!cb_DefaultControlPwd.Checked)
                {
                    if (controlpwd.Length == 0)
                    {
                        MessageBox.Show(@"控制板密码不能为空，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tb_ControlPwd.Focus();
                        return true;
                    }
                    if (controlpwd.Length < tb_ControlPwd.MaxLength)
                    {
                        MessageBox.Show(@"控制板密码长度不能小于6位，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tb_ControlPwd.Focus();
                        return true;
                    }
                    if (confirmcontrolpwd.Length == 0)
                    {
                        MessageBox.Show(@"确认控制板密码不能为空，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tb_ConfirmControlPwd.Focus();
                        return true;
                    }
                    if (confirmcontrolpwd.Length < tb_ConfirmControlPwd.MaxLength)
                    {
                        MessageBox.Show(@"确认控制板密码长度不能小于6位，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tb_ConfirmControlPwd.Focus();
                        return true;
                    }
                    if (controlpwd != confirmcontrolpwd)
                    {
                        MessageBox.Show(@"密码与确认密码不一致，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tb_ControlPwd.Focus();
                        return true;
                    }
                }
            }

            if (cb_SetHostPwd.Checked)
            {
                string oldhostpwd = tb_OldHostPwd.Text;
                string hostpwd = tb_HostPwd.Text;
                string confrimhostpwd = tb_ConfirmHostPwd.Text;
                if (oldhostpwd.Length == 0)
                {
                    MessageBox.Show(@"旧系统口令不能为空，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_OldHostPwd.Focus();
                    return true;
                }
                if (oldhostpwd.Length < tb_OldHostPwd.MaxLength)
                {
                    MessageBox.Show(@"旧系统口令长度不能小于6位，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_OldHostPwd.Focus();
                    return true;
                }
                if (hostpwd.Length == 0)
                {
                    MessageBox.Show(@"系统口令不能为空，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_HostPwd.Focus();
                    return true;
                }
                if (hostpwd.Length < tb_HostPwd.MaxLength)
                {
                    MessageBox.Show(@"系统口令长度不能小于6位，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_HostPwd.Focus();
                    return true;
                }
                if (confrimhostpwd.Length == 0)
                {
                    MessageBox.Show(@"确认系统口令不能为空，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_ConfirmHostPwd.Focus();
                    return true;
                }
                if (confrimhostpwd.Length < tb_ConfirmHostPwd.MaxLength)
                {
                    MessageBox.Show(@"确认系统口令长度不能小于6位，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_ConfirmHostPwd.Focus();
                    return true;
                }
                if (hostpwd != confrimhostpwd)
                {
                    MessageBox.Show(@"系统口令与确认系统口令不一致，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_HostPwd.Focus();
                    return true;
                }
            }

            if (cb_SetCardMachinePwd.Checked)
            {
                string cardmachine = tb_CardMachinePwd.Text;
                string confirmcardmachine = tb_ConfirmCardMachinePwd.Text;
                if (cardmachine.Length == 0)
                {
                    MessageBox.Show(@"IC系统口令不能为空，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_CardMachinePwd.Focus();
                    return true;
                }
                else if (cardmachine.Length < tb_CardMachinePwd.MaxLength)
                {
                    MessageBox.Show(@"IC系统口令长度不能小于6位，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_CardMachinePwd.Focus();
                    return true;
                }
                else if (confirmcardmachine.Length == 0)
                {
                    MessageBox.Show(@"确认IC系统口令不能为空，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_ConfirmCardMachinePwd.Focus();
                    return true;
                }
                else if (confirmcardmachine.Length < tb_ConfirmCardMachinePwd.MaxLength)
                {
                    MessageBox.Show(@"确认IC系统口令长度不能小于6位，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_ConfirmCardMachinePwd.Focus();
                    return true;
                }
                else if (cardmachine != confirmcardmachine)
                {
                    MessageBox.Show(@"IC系统口令与确认IC系统口令不一致，请重新输入。", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_CardMachinePwd.Focus();
                    return true;
                }
            }
            return false;
        }
    }
}