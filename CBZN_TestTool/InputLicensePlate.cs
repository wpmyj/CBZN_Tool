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

namespace CBZN_TestTool
{
    public partial class InputLicensePlate : Form
    {
        public InputLicensePlate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// panel 标题重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void p_Title_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                StringFormat sf = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(Text, p_Title.Font, Brushes.White, new Rectangle(0, 0, p_Title.Width, p_Title.Height), sf);//绘制标题
            }
        }

        /// <summary>
        /// 标题窗体鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void p_Title_MouseDown(object sender, MouseEventArgs e)
        {
            //使用以下两个方法移动窗体
            WinApi.ReleaseCapture();
            WinApi.SendMessage(Handle, WinApi.WM_SYSCOMMAND, WinApi.SC_MOVE + WinApi.HTCAPTION, 0);
        }

        /// <summary>
        /// 窗体重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputLicensePlate_Paint(object sender, PaintEventArgs e)
        {
            //绘制边框
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 1), 0, 0, Width - 1, Height - 1);
            }
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Enter_Click(object sender, EventArgs e)
        {
            string strtxt = tb_LicensePlate.Text.Trim();
            if (strtxt.Length == 0)
            {
                l_LicensePlateTitle.Text = "内容不能为空";
                l_LicensePlateTitle.ForeColor = Color.Red;
                tb_LicensePlate.Focus();
                return;
            }
            else if (strtxt.Length < 7)
            {
                l_LicensePlateTitle.Text = "车牌号码长度为7或8位";
                l_LicensePlateTitle.ForeColor = Color.Red;
                tb_LicensePlate.Focus();
                return;
            }
            foreach (CardInfo item in DistanceRegister.Instance._mBundledCardinfo)
            {
                if (item.CardNumber == strtxt)
                {
                    MessageBox.Show($"车牌号码:{strtxt}已经存在捆绑列表中,请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            this.Tag = strtxt;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 内容标题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void l_LicensePlateTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_LicensePlate.Focus();
        }

        /// <summary>
        /// 内容文本变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_LicensePlate_TextChanged(object sender, EventArgs e)
        {
            l_LicensePlateTitle.Visible = tb_LicensePlate.TextLength == 0;
        }

        /// <summary>
        /// 内容键盘按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_LicensePlate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_Enter_Click(null, null);
            }
        }

        /// <summary>
        /// 内容失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_LicensePlate_Leave(object sender, EventArgs e)
        {
            tb_LicensePlate.Focus();
        }

        /// <summary>
        /// 按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;
            int index = tb_LicensePlate.SelectionStart;
            int len = tb_LicensePlate.SelectionLength;
            if (len == 0)
            {
                if (tb_LicensePlate.TextLength == tb_LicensePlate.MaxLength) return;
                tb_LicensePlate.Text = tb_LicensePlate.Text.Insert(index, btn.Text);
                tb_LicensePlate.SelectionStart = ++index;
            }
            else
            {
                tb_LicensePlate.SelectedText = btn.Text;
            }
        }

        /// <summary>
        /// 后退
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            int index = tb_LicensePlate.SelectionStart;
            if (index == 0) return;
            tb_LicensePlate.Text = tb_LicensePlate.Text.Remove(index - 1, 1);
            tb_LicensePlate.SelectionStart = index - 1;
        }
    }
}
