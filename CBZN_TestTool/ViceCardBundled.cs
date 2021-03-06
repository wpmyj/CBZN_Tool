﻿using System.Collections;
using DB_ROM;
using Dal;
using Model;
using Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CBZN_TestTool
{
    public partial class ViceCardBundled : Form
    {
        bool _isAddRow;
        /// <summary>
        /// 选择添加的副卡列表
        /// </summary>
        List<CardInfo> _mAddViceCard;
        /// <summary>
        /// 已捆绑的副卡集合
        /// </summary>
        List<CardInfo> _bundledViceCard;

        public ViceCardBundled(List<CardInfo> bundledvicecard)
        {
            InitializeComponent();

            _bundledViceCard = bundledvicecard;
        }

        /// <summary>
        /// 标题容器重绘事件
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
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViceCardBundled_Load(object sender, EventArgs e)
        {
            _mAddViceCard = new List<CardInfo>();
            _isAddRow = true;
            foreach (CardInfo item in DistanceRegister.Instance._mViceCardInfo)
            {
                bool check = GetViceCardExists(item.CardNumber);
                dgv_ViceList.Rows.Add(new object[] { check, item.CardNumber, string.Empty });
            }
            _isAddRow = false;
        }

        /// <summary>
        /// 获取当前副卡是否已经存在捆绑集合中
        /// </summary>
        /// <param name="vicecardnumber"></param>
        /// <returns></returns>
        private bool GetViceCardExists(string vicecardnumber)
        {
            foreach (CardInfo item in _mAddViceCard)
            {
                if (item.CardNumber.Equals(vicecardnumber))
                    return true;
            }
            foreach (CardInfo item in _bundledViceCard)
            {
                if (item.CardNumber.Equals(vicecardnumber))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 窗体第一次显示事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViceCardBundled_Shown(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 窗体重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViceCardBundled_Paint(object sender, PaintEventArgs e)
        {
            //绘制边框
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 1), 0, 0, Width - 1, Height - 1);
            }
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Search_Click(object sender, EventArgs e)
        {
            string content = tb_SearchContent.Text.Trim();
            string where = string.Empty;
            if (string.IsNullOrEmpty(content))
            {
                where = $" and CardNumber like '%{content}%' ";
            }
            try
            {
                _isAddRow = true;
                //获取搜索副卡内容
                List<CardInfo> vicecardinfos = DbHelper.Db.ToList<CardInfo>(" and CardType=3 " + where);
                //移除旧的搜索副卡内容
                for (int i = dgv_ViceList.RowCount - 1; i >= DistanceRegister.Instance._mViceCardInfo.Count; i--)
                {
                    dgv_ViceList.Rows.RemoveAt(i);
                }
                //添加新的搜索副卡内容
                foreach (CardInfo item in vicecardinfos)
                {
                    bool check = GetViceCardExists(item.CardNumber);
                    dgv_ViceList.Rows.Add(new object[] { check, item.CardNumber, string.Empty });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isAddRow = false;
            }
        }

        /// <summary>
        /// 鼠标按下搜索标题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void l_SearchTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_SearchContent.Focus();
        }

        /// <summary>
        /// 搜索内容变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_SearchContent_TextChanged(object sender, EventArgs e)
        {
            l_SearchTitle.Visible = tb_SearchContent.TextLength == 0;
        }

        /// <summary>
        /// 搜索内容按键按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_SearchContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_Search_Click(null, null);
            }
        }

        /// <summary>
        /// 列表添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ViceList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                string vicecardnumber = dgv_ViceList["c_ViceCardNumber", e.RowIndex].Value.ToString();
                //添加行时获取当前行副卡所对应的主卡编号
                List<BundledInfo> bundledinfos = DbHelper.Db.ToList<BundledInfo>($" and ViceCardNumber='{vicecardnumber}' ");
                StringBuilder sb = new StringBuilder();
                foreach (BundledInfo item in bundledinfos)
                {
                    sb.Append($"{item.HostCardNumber} ");
                }
                //显示主卡编号
                dgv_ViceList["c_HostCardNumber", e.RowIndex].Value = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 单元格状态因其内容更改而更改的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ViceList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_ViceList.IsCurrentCellDirty)
                dgv_ViceList.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        /// <summary>
        /// 单元格内容变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ViceList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_isAddRow) return;
            bool check = Convert.ToBoolean(dgv_ViceList["c_Selected", e.RowIndex].Value);
            object vicecardnumber = dgv_ViceList["c_ViceCardNumber", e.RowIndex].Value;
            if (check)
            {
                CardInfo info = DbHelper.Db.FirstDefault<CardInfo>($" and CardNumber = '{vicecardnumber}' ");
                if (info == null)
                {
                    if (e.RowIndex < DistanceRegister.Instance._mViceCardInfo.Count)
                    {
                        info = DistanceRegister.Instance._mViceCardInfo[e.RowIndex];
                        info.CardTime = DateTime.Now;
                    }
                }
                _mAddViceCard.Add(info);
            }
            else
            {
                foreach (CardInfo item in _mAddViceCard)
                {
                    if (item.CardNumber.Equals(vicecardnumber))
                    {
                        _mAddViceCard.Remove(item);
                        break;
                    }
                }
            }
            btn_Enter.Enabled = _mAddViceCard.Count > 0;
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Enter_Click(object sender, EventArgs e)
        {
            if (_bundledViceCard.Count + _mAddViceCard.Count > 4)
            {
                MessageBox.Show("副卡绑定最多 4 张,请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Tag = _mAddViceCard;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Canel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 标题窗口鼠标按下事件
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
        /// 单元格鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ViceList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.Button == MouseButtons.Left)
            {
                string vicecardnumber = dgv_ViceList["c_ViceCardNumber", e.RowIndex].Value.ToString();
                foreach (CardInfo item in _bundledViceCard)
                {
                    if (item.CardNumber == vicecardnumber)
                    {
                        MessageBox.Show($"定距卡:{vicecardnumber}已经绑定,不能修改当前选项.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }
    }
}
