using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bll;
using System.Timers;
using System.Threading;
using Model;

namespace CBZN_ModuleTool
{

    /*
     * Sql Create Table ModuleNumber (Mid integer Primary key AUTOINCREMENT, Number Int)
     */
    public partial class MainForm : Form
    {

        private delegate void DefaultDelegate();
        private ModuleNumber Mnumber;
        private PortHelper Port;
        private ComPortHelper ComPort;
        //private System.Timers.Timer ConnectionTimer;
        private Mutex MyMutex;
        private Rectangle Rect;
        /// <summary>
        /// True Down False Up
        /// </summary>
        private bool IsDirection;
        private System.Timers.Timer Effect;
        private bool IsModuleResult;
        private bool IsMouseEnter;
        private bool IsMouseDown;

        public MainForm()
        {
            InitializeComponent();
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

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Black, 1), new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Mnumber == null)
                Mnumber = new ModuleNumber() { Number = 1 };

            DataValidation.IsProtocol = true;
            DataValidation.ProtocolHead = 2;
            DataValidation.ProtocolEnd = 3;
            DataValidation.IsValidation = true;


            Port = new PortHelper();
            Port.PortIsOpenChange = PortOpenOrCloseChange;
            Port.PortDataReceived = PortDataReceived;
            MyMutex = new Mutex();
            ComPort = new ComPortHelper();
            ComPort.CountChange += ComPortChange;
            ComPort.Start();


            Rect = new Rectangle(p_ComPort.Width / 2 - 20, p_ComPort.Height - 14, 40, 14);
        }

        private void PortDataReceived(int port)
        {
            Thread.Sleep(20);
            try
            {
                int len = Port.GetBytesToRead();
                if (len == 0) return;
                byte[] by = new byte[len];
                Port.Read(by, len);
                List<byte[]> bylist = DataValidation.Validation(by);
                foreach (byte[] item in bylist)
                {
                    ParsingParameter parameter = DataParsing.ParsingContent(item);
                    if (parameter.FunctionAddress == 67)
                    {
                        if (parameter.Command == 208)
                        {
                            IsModuleResult = DataParsing.TemporaryContent(parameter.DataContent) == 89;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PortOpenOrCloseChange(object e, bool flag)
        {
            DefaultDelegate PortChange = delegate
            {
                cb_PortName.Enabled = !flag;
                btn_OpenPort.Enabled = !flag;
                btn_ClosePort.Enabled = flag;
                btn_DownLoad.Enabled = flag;
            };
            btn_OpenPort.Invoke(PortChange);
        }

        private void ComPortChange(List<string> portnames)
        {
            if (Port.IsOpen && !portnames.Contains(Port.PortName))
            {
                try
                {
                    Port.IsOpen = false;
                    Port.Close();
                }
                catch (Exception)
                {

                }
            }
            DefaultDelegate ComChange = delegate
            {
                cb_PortName.Items.Clear();
                foreach (string item in portnames)
                {
                    cb_PortName.Items.Add(item);
                }
                if (!Port.IsOpen)
                {
                    if (cb_PortName.Items.Count > 0)
                    {
                        cb_PortName.SelectedIndex = 0;
                        btn_OpenPort.Enabled = true;
                    }
                    //if (ConnectionTimer == null)
                    //{
                    //    ConnectionTimer = new System.Timers.Timer(250);
                    //    ConnectionTimer.AutoReset = true;
                    //    ConnectionTimer.Elapsed += ConnectionTimer_Elapsed;
                    //}
                    //ConnectionTimer.Start();
                }
                else
                {
                    int index = cb_PortName.Items.IndexOf(Port.PortName);
                    cb_PortName.SelectedIndex = index;
                }
            };
            cb_PortName.Invoke(ComChange);
        }

        void ConnectionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MyMutex.WaitOne();
            if (Port.IsOpen)
            {
                //ConnectionTimer.Dispose();
                //ConnectionTimer.Stop();
            }
            else
            {
                foreach (string item in ComPort.PortNames)
                {
                    Port.PortName = item;
                    try
                    {

                    }
                    catch (Exception)
                    {

                    }
                }
            }
            MyMutex.ReleaseMutex();
        }

        private void p_ComPort_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                Image img = IsDirection ? Properties.Resources.down : Properties.Resources.top;
                g.DrawImage(img, p_ComPort.Width / 2 - img.Width / 2, Rect.Y, img.Width, img.Height);
            }
        }

        private void p_ComPort_MouseMove(object sender, MouseEventArgs e)
        {
            if (Rect.Contains(e.Location))
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void p_ComPort_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void p_ComPort_MouseDown(object sender, MouseEventArgs e)
        {
            if (Rect.Contains(e.Location))
            {
                StartEffect();
            }
        }

        private void StartEffect()
        {
            if (Effect == null)
            {
                Effect = new System.Timers.Timer(1);
                Effect.AutoReset = true;
                Effect.Elapsed += ShowEffect;
            }
            if (IsDirection)
            {
                ShowAndHideControl();
            }
            Effect.Start();
        }

        void ShowEffect(object sender, ElapsedEventArgs e)
        {
            if (IsDirection)
            {
                if (p_ComPort.Height >= rtb_ShowContent.Top - p_ComPort.Top)
                {
                    IsDirection = !IsDirection;
                    p_ComPort.Height = rtb_ShowContent.Top - p_ComPort.Top;
                    Effect.Stop();
                    return;
                }
                p_ComPort.Height += 15;
            }
            else
            {
                if (p_ComPort.Height <= Rect.Height)
                {
                    IsDirection = !IsDirection;
                    p_ComPort.Height = Rect.Height;
                    Effect.Stop();
                    ShowAndHideControl();
                    return;
                }
                p_ComPort.Height -= 15;
            }
        }

        private void ShowAndHideControl()
        {
            foreach (Control item in p_ComPort.Controls)
            {
                item.Visible = !item.Visible;
            }
        }

        private void p_ComPort_Resize(object sender, EventArgs e)
        {
            Rect.Y = p_ComPort.Height - 14;
            p_ComPort.Invalidate(new Rectangle(Rect.X, 0, Rect.Width, p_ComPort.Height));
        }

        private void btn_OpenPort_EnabledChanged(object sender, EventArgs e)
        {
            cb_PortName.Enabled = btn_OpenPort.Enabled;
        }

        private void btn_OpenPort_Click(object sender, EventArgs e)
        {
            try
            {
                Port.PortName = cb_PortName.Text;
                Port.Open();
                Port.IsOpen = true;
                StartEffect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ClosePort_Click(object sender, EventArgs e)
        {
            try
            {
                Port.Close();
                Port.IsOpen = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_DownLoad_Click(object sender, EventArgs e)
        {
            int id = 1;
            if (tb_ID.Text.Length != 0)
                id = Convert.ToInt32(tb_ID.Text);
            if (id < Mnumber.Number)
            {
                if (MessageBox.Show(string.Format(" ID 编号：{0}已经在使用中，是否重新下载写入。（当前流水编号：{1})", id, Mnumber.Number), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
            }
            btn_DownLoad.Image = null;
            btn_DownLoad.Enabled = false;
            tb_ID.Enabled = false;
            rtb_ShowContent.Clear();
            Thread setmodule = new Thread(ThreadSetModule);
            setmodule.Start(id);
        }

        private void ThreadSetModule(object obj)
        {
            int id = Convert.ToInt32(obj);
            bool iscomplete = false;
            try
            {
                ShowTxtContent("开启模块设置模式");
                OpenModule();

                ShowTxtContent("设置模块发送ID参数");
                ModuleTid(id);
                if (!IsModuleResult)
                {
                    ShowTxtContent("设置失败，尝试第二次设置模块发送ID参数");
                    ModuleTid(id);
                    if (!IsModuleResult)
                    {
                        ShowTxtContent("设置失败，尝试第三次设置模块发送ID参数");
                        ModuleTid(id);
                        if (!IsModuleResult)
                        {
                            ShowTxtContent("模块发送ID设置失败，退出设置操作");
                            iscomplete = true;
                        }
                    }
                }

                if (!iscomplete)
                {
                    ShowTxtContent("设置模块接收ID参数");
                    ModuleRid(id);
                    if (!IsModuleResult)
                    {
                        ShowTxtContent("设置失败，尝试第二次设置模块接收ID参数");
                        ModuleRid(id);
                        if (!IsModuleResult)
                        {
                            ShowTxtContent("设置失败，尝试第三次设置模块接收ID参数");
                            if (!IsModuleResult)
                            {
                                ShowTxtContent("模块接收ID设置失败，退出设置操作");
                                iscomplete = true;
                            }
                        }
                    }
                }

                ShowTxtContent("关闭模块设置模式");
                CloseModule();

            }
            catch (Exception ex)
            {
                iscomplete = true;
                ShowTxtContent(ex.Message);
            }

            if (!iscomplete)
            {
                id += 1;
                if (id > Mnumber.Number)
                    Mnumber.Number = id;
            }
            EnableDownLoadControls(iscomplete);
        }

        private void EnableDownLoadControls(bool flag)
        {
            DefaultDelegate enablecontrol = delegate
            {
                btn_DownLoad.Enabled = true;
                btn_DownLoad.Image = flag ? Properties.Resources.block : Properties.Resources.check;
                tb_ID.Enabled = true;
                tb_ID.Text = Mnumber.Number.ToString();
            };
            btn_DownLoad.Invoke(enablecontrol);
        }

        private void ShowTxtContent(string content)
        {
            DefaultDelegate DelegateShow = delegate
            {
                rtb_ShowContent.AppendText(content + "\n");
            };
            rtb_ShowContent.Invoke(DelegateShow);
        }

        private void OpenModule()
        {
            byte[] by = PortAgreement.GetOpenModule();
            if (Port.IsOpen)
            {
                Port.Write(by);
                Thread.Sleep(10);
            }
        }

        private void CloseModule()
        {
            byte[] by = PortAgreement.GetCloseModule();
            if (Port.IsOpen)
            {
                Port.Write(by);
                Thread.Sleep(10);
            }
        }

        private void ModuleTid(int id)
        {
            IsModuleResult = false;
            string content = string.Format("AT+TID=01{0:X8}", id);
            byte[] by = PortAgreement.GetSetModule(content);
            if (Port.IsOpen)
            {
                Port.Write(by);
                Thread.Sleep(200);
            }
        }

        private void ModuleRid(int id)
        {
            IsModuleResult = false;
            string content = string.Format("AT+RID=01{0:X8}", id);
            byte[] by = PortAgreement.GetSetModule(content);
            if (Port.IsOpen)
            {
                Port.Write(by);
                Thread.Sleep(200);
            }
        }

        private void btn_OpenPort_VisibleChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btn_OpenPort.Visible ? null : btn_DownLoad;
            if (btn_OpenPort.Visible)
                rtb_ShowContent.Focus();
        }

        private void tb_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || (e.KeyChar >= 48 && e.KeyChar <= 57))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tb_ID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btn_DownLoad.Enabled)
                {
                    btn_DownLoad_Click(null, null);
                }
            }
        }

        private void btn_DownLoad_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, btn_DownLoad.Width - 1, btn_DownLoad.Height - 1);
            SolidBrush background;
            if (IsMouseDown)
            {
                background = new SolidBrush(btn_DownLoad.FlatAppearance.MouseDownBackColor);
            }
            else if (IsMouseEnter)
            {
                background = new SolidBrush(btn_DownLoad.FlatAppearance.MouseOverBackColor);
            }
            else
            {
                background = !btn_DownLoad.Enabled ? new SolidBrush(Color.FromArgb(160, 160, 160)) : new SolidBrush(btn_DownLoad.BackColor);

            }
            g.FillRectangle(background, rect);
            g.DrawRectangle(new Pen(btn_DownLoad.FlatAppearance.BorderColor, btn_DownLoad.FlatAppearance.BorderSize), rect);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(btn_DownLoad.Text, btn_DownLoad.Font, new SolidBrush(btn_DownLoad.ForeColor), rect, sf);
            if (btn_DownLoad.Image != null)
            {
                Image img = btn_DownLoad.Image;
                Point p = new Point(30, (rect.Height - img.Height) / 2);
                g.DrawImage(btn_DownLoad.Image, new Rectangle(p, img.Size));
            }
        }

        private void btn_DownLoad_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
        }

        private void btn_DownLoad_MouseEnter(object sender, EventArgs e)
        {
            IsMouseEnter = true;
        }

        private void btn_DownLoad_MouseLeave(object sender, EventArgs e)
        {
            IsMouseEnter = false;
        }

        private void btn_DownLoad_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
        }

    }
}
