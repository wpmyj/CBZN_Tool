using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bll;
using Model;
using Dal;

namespace CBZN_ClientNumberDownTool
{
    public partial class UserAdd : Form
    {
        private List<NumberLimit> _m_NumberLimits;
        private List<int> _AllNumber;

        public UserAdd(List<NumberLimit> m_NumberLimits)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this._m_NumberLimits = m_NumberLimits;
        }

        private void l_Title_MouseDown(object sender, MouseEventArgs e)
        {
            UserAdd_MouseDown(sender, e);
        }

        private void p_top_MouseDown(object sender, MouseEventArgs e)
        {
            UserAdd_MouseDown(sender, e);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserAdd_MouseDown(object sender, MouseEventArgs e)
        {
            PcommApi.ReleaseCapture();
            PcommApi.SendMessage(this.Handle, PcommApi.WM_SYSCOMMAND, PcommApi.SC_MOVE + PcommApi.HTCAPTION, 0);
        }

        private void UserAdd_Load(object sender, EventArgs e)
        {
            int limitnumber = 1;
            List<UserInfo> m_userinfo = DbHelper.Db.ToList<UserInfo>();
            _AllNumber = new List<int>();
            foreach (UserInfo item in m_userinfo)
            {
                _AllNumber.Add(item.UserNumber);
            }
            foreach (NumberLimit item in _m_NumberLimits)
            {
                _AllNumber.Add(item.LimitNumber);
            }
            limitnumber = CreateLimitNumber(limitnumber);
            ud_UserNumber.Value = limitnumber;
        }

        private int CreateLimitNumber(int number)
        {
            if (_AllNumber.Contains(number))
            {
                number = CreateLimitNumber(++number);
            }
            return number;
        }

        private bool NumberIsExist(int limitnumber)
        {
            foreach (NumberLimit item in _m_NumberLimits)
            {
                if (item.LimitNumber == limitnumber)
                    return true;
            }
            return false;
        }

        private void UserAdd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            string username = tb_UserName.Text.Trim();
            int usernumber = (int)ud_UserNumber.Value;
            string description = tb_Description.Text.Trim();

            try
            {
                if(username.Length==0)
                {
                    MessageBox.Show("   客户名称不能为空，请重新输入。   ","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                int count = DbHelper.Db.GetCount<UserInfo>(" and UserNumber=" + usernumber);
                if (count != 0)
                {
                    MessageBox.Show("   当前客户编号：" + usernumber + " 已经存在   ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (NumberIsExist(usernumber))
                {
                    MessageBox.Show("   当前客户编号：" + usernumber + " 已经存在   ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                UserInfo m_userinfo = new UserInfo()
                    {
                        UserName = username,
                        UserNumber = usernumber,
                        Description = description,
                        RecordTime = DateTime.Now
                    };

                m_userinfo.ID = DbHelper.Db.Insert<UserInfo>(m_userinfo);
                this.Tag = m_userinfo;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误内容" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
