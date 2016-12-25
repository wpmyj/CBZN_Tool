using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bll;

namespace CBZN_ClientNumberDownTool
{
    public partial class UserEdit : Form
    {
        private UserInfo _m_userinfo;

        public UserEdit()
        {
            InitializeComponent();
        }

        public UserEdit(Model.UserInfo m_userinfo)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this._m_userinfo = m_userinfo;
        }

        private void l_Title_MouseDown(object sender, MouseEventArgs e)
        {
            UserEdit_MouseDown(sender, e);
        }

        private void UserEdit_MouseDown(object sender, MouseEventArgs e)
        {
            PcommApi.ReleaseCapture();
            PcommApi.SendMessage(this.Handle, PcommApi.WM_SYSCOMMAND, PcommApi.SC_MOVE + PcommApi.HTCAPTION, 0);
        }

        private void p_top_MouseDown(object sender, MouseEventArgs e)
        {
            UserEdit_MouseDown(sender, e);
        }

        private void UserEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void UserEdit_Load(object sender, EventArgs e)
        {
            tb_UserName.Text = _m_userinfo.UserName;
            ud_UserNumber.Value = _m_userinfo.UserNumber;
            tb_Description.Text = _m_userinfo.Description;

        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            string username = tb_UserName.Text.Trim();
            int usernumber = (int)ud_UserNumber.Value;
            string description = tb_Description.Text.Trim();

            try
            {
                if (_m_userinfo.UserNumber != usernumber)
                {
                    int count = DbHelper.Db.GetCount<UserInfo>(" and UserNumber= " + usernumber);
                    if (count == 0)
                    {
                        _m_userinfo.UserNumber = usernumber;
                    }
                    else
                    {
                        MessageBox.Show("   当前客户编号：" + usernumber + " 已经存在   ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ud_UserNumber.Focus();
                        return;
                    }
                }
                if (_m_userinfo.UserName != username)
                    _m_userinfo.UserName = username;
                if (_m_userinfo.Description != description)
                    _m_userinfo.Description = description;
                DbHelper.Db.Update<UserInfo>(_m_userinfo);
                this.Tag = _m_userinfo;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误内容：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
