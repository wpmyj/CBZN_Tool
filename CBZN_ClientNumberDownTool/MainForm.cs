using CCWin.SkinControl;
using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Bll;

namespace CBZN_ClientNumberDownTool
{
    public partial class MainForm : Form
    {
        private ComPortHelper _m_ComPort;
        private delegate void ShowComPortNameHandler();
        private PortHelper _m_Port;
        private System.Timers.Timer _tiDelayTimeOut;
        private System.Timers.Timer _tiSearchDevicePort;
        private List<NumberLimit> _m_NumberLimits;
        private string _strUserinfoWhere;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            btn_Add.Enabled = false;
            ud_LimitValue.Visible = true;
            btn_Save.Visible = true;
            btn_Canel.Visible = true;
            ud_LimitValue.Focus();
        }

        private void btn_AddCustomer_Click(object sender, EventArgs e)
        {
            AddUserinfo();
            dgv_CustomerList.Focus();
        }

        private void btn_Canel_Click(object sender, EventArgs e)
        {
            HideLimit();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            int index = dgv_LimitList.SelectedRows[0].Index;
            if (MessageBox.Show("   确认删除限制编号:" + _m_NumberLimits[index].LimitNumber, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                try
                {
                    DbHelper.Db.Del<NumberLimit>(_m_NumberLimits[index].ID);
                    _m_NumberLimits.RemoveAt(index);
                    dgv_LimitList.Rows.RemoveAt(index);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误内容：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_DelCustomer_Click(object sender, EventArgs e)
        {
            int index = dgv_CustomerList.SelectedRows[0].Index;
            object username = dgv_CustomerList.Rows[index].Cells["UserName"].Value;
            if (MessageBox.Show(" 确认删除 " + username + " 客户编号信息吗？ ", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                int id = Convert.ToInt32(dgv_CustomerList.Rows[index].Cells["ID"].Value);
                try
                {
                    DbHelper.Db.Del<UserInfo>(id);
                    dgv_CustomerList.Rows.RemoveAt(index);
                    dgv_CustomerList.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误内容：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            LimitControl(false);
            tb_DownLoadDescription.Focus();
            int index = dgv_CustomerList.SelectedRows[0].Index;
            UserInfo m_userinfo = GetRowUserInfo(index);
            SendUpdateNumberDeal(m_userinfo.UserNumber);
        }

        private void SendUpdateNumberDeal(int number)
        {
            tb_DownLoadDescription.Text = string.Empty;
            ContentMessage("准备写入的数据。", Color.Black);
            try
            {
                byte[] by = PortAgreement.GetClientNumber(number);
                _m_Port.Write(by);
                ContentMessage("数据准备完成，发送数据。", Color.Black);
                if (_tiDelayTimeOut == null)
                {
                    _tiDelayTimeOut = new System.Timers.Timer(2000);
                    _tiDelayTimeOut.AutoReset = false;
                    _tiDelayTimeOut.Elapsed += _tiDelayTimeOut_Elapsed;
                }
                _tiDelayTimeOut.Start();
            }
            catch (Exception ex)
            {
                LimitControl(true);
                ContentMessage("错误内容：" + ex.Message, Color.Red);
            }
        }

        private void LimitControl(bool b)
        {
            btn_Down.Enabled = _m_Port.IsOpen ? b : false;
            btn_ShowCustomer.Enabled = b;
            btn_AddCustomer.Enabled = b;
            btn_EditCustomer.Enabled = b;
            btn_DelCustomer.Enabled = b;
            tb_SearchContent.Enabled = b;
            btn_Search.Enabled = b;
            dgv_CustomerList.Enabled = b;
            cb_page.Enabled = b;
            if (b)
            {
                btn_Previous.Enabled = cb_page.SelectedIndex > 0;
                btn_Next.Enabled = cb_page.SelectedIndex != cb_page.Items.Count - 1;
            }
            else
            {
                btn_Previous.Enabled = b;
                btn_Next.Enabled = b;
            }
        }

        void _tiDelayTimeOut_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ContentMessage("接收超时。", Color.Red);
            LimitControl(true);
        }

        private void btn_EditCustomer_Click(object sender, EventArgs e)
        {
            int index = dgv_CustomerList.SelectedRows[0].Index;
            UserInfo m_userinfo = GetRowUserInfo(index);
            using (UserEdit useredit = new UserEdit(m_userinfo))
            {
                if (useredit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    m_userinfo = useredit.Tag as UserInfo;
                    EditRowUserInfo(index, m_userinfo);
                    dgv_CustomerList.Focus();
                }
            }
        }

        private void EditRowUserInfo(int index, UserInfo m_userinfo)
        {
            PropertyInfo[] pinfos = typeof(UserInfo).GetProperties();
            foreach (PropertyInfo item in pinfos)
            {
                dgv_CustomerList.Rows[index].Cells[item.Name].Value = item.GetValue(m_userinfo, null);
            }
        }

        private UserInfo GetRowUserInfo(int index)
        {
            UserInfo m_userinfo = new UserInfo();
            PropertyInfo[] pinfos = typeof(UserInfo).GetProperties();
            foreach (PropertyInfo item in pinfos)
            {
                item.SetValue(m_userinfo, dgv_CustomerList.Rows[index].Cells[item.Name].Value, null);
            }
            return m_userinfo;
        }

        private void btn_Limit_Click(object sender, EventArgs e)
        {
            p1.Visible = false;
            p2.Visible = true;
            SetBtn(btn_Limit);
            this.AcceptButton = btn_Add;
            dgv_LimitList.Focus();
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                int limitnumber = (int)ud_LimitValue.Value;
                if (!IsLimitNumberExist(limitnumber))
                {
                    NumberLimit m_numberlimit = new NumberLimit()
                    {
                        LimitNumber = limitnumber
                    };
                    m_numberlimit.ID = DbHelper.Db.Insert<NumberLimit>(m_numberlimit);
                    _m_NumberLimits.Add(m_numberlimit);
                    dgv_LimitList.Rows.Add(limitnumber.ToString());
                }
                else
                {
                    MessageBox.Show(" " + limitnumber + " 重复添加限制编号。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                HideLimit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误内容：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsLimitNumberExist(int limitnumber)
        {
            foreach (NumberLimit item in _m_NumberLimits)
            {
                if (item.LimitNumber == limitnumber)
                {
                    return true;
                }
            }
            return false;
        }

        private void btn_Download_Click(object sender, EventArgs e)
        {
            p1.Visible = true;
            p2.Visible = false;
            SetBtn(btn_Download);
            this.AcceptButton = btn_Down;
            dgv_CustomerList.Focus();
        }

        private void btn_ShowCustomer_Click(object sender, EventArgs e)
        {
            ShowUserInfo();
        }

        private void ShowUserInfo()
        {
            ShowUserInfo(string.Empty);
        }

        private void ShowUserInfo(string searchwehre)
        {
            try
            {
                _strUserinfoWhere = searchwehre;
                int count = DbHelper.Db.GetCount<UserInfo>(_strUserinfoWhere);
                int page = count / 30;
                page += (count % 30) > 0 ? 1 : 0;
                if (page < 1)
                    page = 1;
                if (page > 100)
                    page = 100;
                cb_page.Items.Clear();
                for (int i = 1; i <= page; i++)
                {
                    cb_page.Items.Add(i);
                }
                if (cb_page.Items.Count > 0)
                    cb_page.SelectedIndex = 0;
                btn_Previous.Enabled = false;
                btn_Next.Enabled = cb_page.Items.Count >= 2;
                l_CountDescription.Text = "总共 " + count + " 条记录";
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误内容：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_CustomerList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgv_CustomerList.RowCount > 0)
            {
                if (!btn_EditCustomer.Enabled)
                {
                    btn_EditCustomer.Enabled = true;
                }
                if (!btn_DelCustomer.Enabled)
                {
                    btn_DelCustomer.Enabled = true;
                }

                if (_m_Port != null && _m_Port.IsOpen)
                    btn_Down.Enabled = true;
            }
        }

        private void dgv_CustomerList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgv_CustomerList.RowCount == 0)
            {
                btn_EditCustomer.Enabled = false;
                btn_DelCustomer.Enabled = false;
                btn_Down.Enabled = false;
            }
        }

        private void dgv_LimitList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgv_LimitList.RowCount > 0)
            {
                btn_Del.Enabled = true;
            }
        }

        private void dgv_LimitList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgv_LimitList.RowCount == 0)
                btn_Del.Enabled = false;
        }

        private void HideLimit()
        {
            ud_LimitValue.Visible = false;
            btn_Save.Visible = false;
            btn_Canel.Visible = false;
            btn_Add.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            p2.Visible = false;

            DataValidation.ProtocolHead = 2;
            DataValidation.ProtocolEnd = 3;
            DataValidation.IsProtocol = true;
            DataValidation.IsValidation = true;

            string path = Environment.CurrentDirectory + "\\Data.db";
            try
            {
                DbHelper.LoadDb(path);

                _m_NumberLimits = DbHelper.Db.ToList<NumberLimit>();
                foreach (NumberLimit item in _m_NumberLimits)
                {
                    dgv_LimitList.Rows.Add(item.LimitNumber.ToString());
                }

                ShowUserInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误内容" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            WinApi.ReleaseCapture();
            WinApi.SendMessage(this.Handle, WinApi.WM_SYSCOMMAND, WinApi.SC_MOVE + WinApi.HTCAPTION, 0);
        }

        private void SetBtn(SkinButton btn)
        {
            if (btn_Download.ControlState == CCWin.SkinClass.ControlState.Pressed)
                btn_Download.ControlState = CCWin.SkinClass.ControlState.Normal;
            btn_Download.BackColor = Color.Transparent;
            btn_Download.Enabled = true;
            btn_Limit.BackColor = Color.Transparent;
            btn_Limit.Enabled = true;
            if (btn.BackColor != btn.DownBaseColor)
            {
                btn.BackColor = btn.DownBaseColor;
                btn.Enabled = false;
            }
        }

        private void ud_LimitValue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                HideLimit();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btn_Save_Click(null, null);
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string strwhere = tb_SearchContent.Text.Trim();
            if (strwhere.Length > 0)
            {
                strwhere = GetSqlWhere(strwhere);
            }
            ShowUserInfo(strwhere);
        }

        private void tb_SearchContent_TextChanged(object sender, EventArgs e)
        {
            btn_Search_Click(null, null);
        }

        private string GetSqlWhere(string strwhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" and ( UserName like '%{0}%' ", strwhere);
            sb.AppendFormat(" or UserNumber like '%{0}%' ", strwhere);
            sb.AppendFormat(" or Description like  '%{0}%' ) ", strwhere);
            return sb.ToString();
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            cb_page.SelectedIndex -= 1;
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            cb_page.SelectedIndex += 1;
        }

        private void cb_page_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cb_page.SelectedIndex;
            dgv_CustomerList.Rows.Clear();
            try
            {
                List<UserInfo> m_userinfos = DbHelper.Db.ToList<UserInfo>(index * 30, 30, _strUserinfoWhere);
                foreach (UserInfo item in m_userinfos)
                {
                    dgv_CustomerList.Rows.Add(item.ID, item.UserName, item.UserNumber, item.Description, item.RecordTime);
                }
                bool result = index != 0;
                btn_Previous.Enabled = result;
                result = index != cb_page.Items.Count - 1;
                btn_Next.Enabled = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误内容：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_SearchContent_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Search_Click(null, null);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            _m_Port = new PortHelper();
            _m_Port.PortDataReceived = OnPortDataReceived;
            _m_Port.PortIsOpenChange = OnPortOpenAndCloseChange;

            _m_ComPort = new ComPortHelper();
            _m_ComPort.CountChange += _m_ComPort_CountChange;
            _m_ComPort.Start();

            dgv_CustomerList.Focus();
        }

        void _tiSearchDevicePort_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //0231 (地址 3030) 3030 (校验 3339) 03 //新检测串口设备
            //0230 (地址 3030) 3031 (数据) (校验 3339) 03 
            byte[] by = PortAgreement.GetSearchHost(1);
            for (int i = 0; i < 10; i++)
            {
                foreach (string item in _m_ComPort.PortNames)
                {
                    _m_Port.PortName = item;
                    try
                    {
                        _m_Port.Open();
                        _m_Port.Write(by);
                        Thread.Sleep(500);
                        if (_m_Port.IsOpen)
                        {
                            _tiSearchDevicePort.Stop();
                            _tiSearchDevicePort.Dispose();
                            _tiSearchDevicePort = null;
                            return;
                        }
                        _m_Port.Close();
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void OnPortOpenAndCloseChange(object e, bool value)
        {
            if (value)
            {
                l_ConnectionDescription.Text = "已连接";
                l_ConnectionDescription.ForeColor = Color.White;
                btn_PortOpenAndClose.Text = "关 闭";
                cb_PortNames.Enabled = false;
                btn_Down.Enabled = dgv_CustomerList.RowCount > 0;
            }
            else
            {
                l_ConnectionDescription.Text = "未连接";
                l_ConnectionDescription.ForeColor = Color.Red;
                btn_PortOpenAndClose.Text = "打 开";
                cb_PortNames.Enabled = true;
                btn_Down.Enabled = false;
            }
        }

        private void OnPortDataReceived(int port)
        {
            Thread.Sleep(30);
            try
            {
                int len = _m_Port.GetBytesToRead();
                if (len < 11) return;
                if (_tiDelayTimeOut != null)
                {
                    _tiDelayTimeOut.Stop();
                }
                byte[] by = new byte[len];
                _m_Port.Read(by, len);
                List<byte[]> bylist = DataValidation.Validation(by);
                foreach (byte[] item in bylist)
                {
                    ParsingParameter param = DataParsing.ParsingContent(item);
                    if (param.FunctionAddress == 49)
                    {
                        int result = (int)DataParsing.TemporaryContent(param.DataContent);
                        if (result == 1)
                        {
                            _m_Port.IsOpen = true;
                            return;
                        }
                    }
                    else if (param.FunctionAddress == 51)
                    {
                        int result = (int)DataParsing.TemporaryContent(param.DataContent);
                        if (result == 1)
                        {
                            ContentMessage("客户编号设置成功。", Color.Green);
                        }
                        else
                        {
                            ContentMessage("错误内容：接收到的数据校验不通过。", Color.Red);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误内容：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LimitControl(true);
        }

        private void ContentMessage(string content, Color cr)
        {
            tb_DownLoadDescription.SelectionColor = cr;
            tb_DownLoadDescription.AppendText(content + "\n");
        }

        void _m_ComPort_CountChange(List<string> portnames)
        {
            ShowComPortNameHandler showcomport = delegate
            {
                cb_PortNames.Items.Clear();
                cb_PortNames.Items.AddRange(portnames.ToArray());
                if (cb_PortNames.Items.Count > 0)
                    cb_PortNames.SelectedIndex = 0;
            };
            cb_PortNames.Invoke(showcomport);
            if (_m_Port.IsOpen)
            {
                if (!portnames.Contains(_m_Port.PortName))
                {
                    _m_Port.IsOpen = false;
                    try
                    {
                        _m_Port.Close();
                    }
                    catch
                    {

                    }
                }
            }

            if (!_m_Port.IsOpen)
            {
                if (_tiSearchDevicePort == null)
                {
                    _tiSearchDevicePort = new System.Timers.Timer();
                    _tiSearchDevicePort.AutoReset = false;
                    _tiSearchDevicePort.Elapsed += _tiSearchDevicePort_Elapsed;
                }
                _tiSearchDevicePort.Start();
            }
        }

        private void btn_PortOpenAndClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (_m_Port.IsOpen)
                {
                    _m_Port.Close();
                    _m_Port.IsOpen = false;
                    cb_PortNames.Focus();
                }
                else
                {
                    _m_Port.PortName = cb_PortNames.Text;
                    _m_Port.Open();
                    _m_Port.IsOpen = true;
                    dgv_CustomerList.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误内容：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_CustomerList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                btn_EditCustomer_Click(null, null);
            }
        }

        private UserInfo AddUserinfo()
        {
            UserInfo m_userinfo = null;
            using (UserAdd useradd = new UserAdd(_m_NumberLimits))
            {
                if (useradd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    m_userinfo = useradd.Tag as UserInfo;
                    //int index = dgv_CustomerList.Rows.Add(m_userinfo.ID, m_userinfo.UserName, m_userinfo.UserNumber, m_userinfo.Description, m_userinfo.RecordTime);
                    //dgv_CustomerList.FirstDisplayedScrollingRowIndex = index;
                    ShowUserInfo();
                }
            }
            return m_userinfo ?? default(UserInfo);
        }

        private void dgv_CustomerList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (btn_Down.Enabled)
                    btn_Down_Click(null, null);
            }
        }

        private void tb_DownLoadDescription_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btn_Down.Enabled)
                    btn_Down_Click(null, null);
            }
        }

    }
}