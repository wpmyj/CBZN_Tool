using Bll;
using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace CBZN_ModuleTool
{
    public partial class MainForm : Form
    {
        private ComPortHelper _comPort;

        /// <summary>
        /// True Down False Up
        /// </summary>
        private bool _isDirection;

        private bool _isMouseDown;

        private bool _isMouseEnter;

        private ModuleNumber _mNumber;

        private int _currentNumber;

        private PortHelper _mPort;

        //private System.Timers.Timer ConnectionTimer;
        private Mutex _myMutex;

        private Rectangle _rect;

        private System.Timers.Timer _tEffect;

        private System.Timers.Timer _tOverTime;

        public MainForm()
        {
            InitializeComponent();
        }

        private delegate void DefaultDelegate();

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ClosePort_Click(object sender, EventArgs e)
        {
            try
            {
                _mPort.Close();
                _mPort.IsOpen = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_DownLoad_Click(object sender, EventArgs e)
        {
            _currentNumber = 1;
            if (tb_ID.Text.Length != 0)
            {
                _currentNumber = Convert.ToInt32(tb_ID.Text);
                if (_currentNumber == 0)
                {
                    MessageBox.Show("ID 编号从1开始。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (_currentNumber > 99999999)
            {
                MessageBox.Show("ID 编号已经超出可写范围(0 - 99999999)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_currentNumber < _mNumber.Number)
            {
                if (MessageBox.Show(string.Format(" ID 编号：{0}已经在使用中，是否重新下载写入。（当前流水编号：{1})", _currentNumber, _mNumber.Number), @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
            }
            btn_DownLoad.Image = null;
            btn_DownLoad.Enabled = false;
            tb_ID.Enabled = false;

            byte[] by = PortAgreement.SetModuleNumber(tb_ID.Text);
            _mPort.Write(by);

            if (_tOverTime == null)
            {
                _tOverTime = new System.Timers.Timer(5000);
                _tOverTime.AutoReset = false;
                _tOverTime.Elapsed += _tOverTime_Elapsed;
                _tOverTime.Start();
            }
        }

        void _tOverTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            EnableDownLoadControls(true);
            _tOverTime.Dispose();
            _tOverTime = null;
        }

        private void btn_DownLoad_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown = true;
        }

        private void btn_DownLoad_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnter = true;
        }

        private void btn_DownLoad_MouseLeave(object sender, EventArgs e)
        {
            _isMouseEnter = false;
        }

        private void btn_DownLoad_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private void btn_DownLoad_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, btn_DownLoad.Width - 1, btn_DownLoad.Height - 1);
            SolidBrush background;
            if (_isMouseDown)
            {
                background = new SolidBrush(btn_DownLoad.FlatAppearance.MouseDownBackColor);
            }
            else if (_isMouseEnter)
            {
                background = new SolidBrush(btn_DownLoad.FlatAppearance.MouseOverBackColor);
            }
            else
            {
                background = !btn_DownLoad.Enabled ? new SolidBrush(Color.FromArgb(160, 160, 160)) : new SolidBrush(btn_DownLoad.BackColor);
            }
            g.FillRectangle(background, rect);
            g.DrawRectangle(new Pen(btn_DownLoad.FlatAppearance.BorderColor, btn_DownLoad.FlatAppearance.BorderSize), rect);

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString(btn_DownLoad.Text, btn_DownLoad.Font, new SolidBrush(btn_DownLoad.ForeColor), rect, sf);
            if (btn_DownLoad.Image == null) return;
            Image img = btn_DownLoad.Image;
            Point p = new Point(30, (rect.Height - img.Height) / 2);
            g.DrawImage(btn_DownLoad.Image, new Rectangle(p, img.Size));
        }

        private void btn_OpenPort_Click(object sender, EventArgs e)
        {
            try
            {
                _mPort.PortName = cb_PortName.Text;
                _mPort.Open();
                _mPort.IsOpen = true;
                StartEffect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_OpenPort_EnabledChanged(object sender, EventArgs e)
        {
            cb_PortName.Enabled = btn_OpenPort.Enabled;
        }

        private void btn_OpenPort_VisibleChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btn_OpenPort.Visible ? null : btn_DownLoad;
        }

        private void ComPortChange(List<string> portnames)
        {
            if (_mPort.IsOpen && !portnames.Contains(_mPort.PortName))
            {
                try
                {
                    _mPort.IsOpen = false;
                    _mPort.Close();
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            DefaultDelegate comChange = delegate
            {
                cb_PortName.Items.Clear();
                foreach (string item in portnames)
                {
                    cb_PortName.Items.Add(item);
                }
                if (!_mPort.IsOpen)
                {
                    if (cb_PortName.Items.Count <= 0) return;
                    cb_PortName.SelectedIndex = 0;
                    btn_OpenPort.Enabled = true;
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
                    int index = cb_PortName.Items.IndexOf(_mPort.PortName);
                    cb_PortName.SelectedIndex = index;
                }
            };
            cb_PortName.Invoke(comChange);
        }

        private void ConnectionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _myMutex.WaitOne();
            if (_mPort.IsOpen)
            {
                //ConnectionTimer.Dispose();
                //ConnectionTimer.Stop();
            }
            else
            {
                foreach (string item in _comPort.PortNames)
                {
                    _mPort.PortName = item;
                    try
                    {
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }
            _myMutex.ReleaseMutex();
        }

        private void EnableDownLoadControls(bool flag)
        {
            DefaultDelegate enablecontrol = delegate
            {
                btn_DownLoad.Enabled = true;
                btn_DownLoad.Image = flag ? Properties.Resources.block : Properties.Resources.check;
                tb_ID.Enabled = true;
                if (!flag)
                    _currentNumber++;
                tb_ID.Text = _currentNumber.ToString();
                _tOverTime.Stop();
                _tOverTime.Dispose();
                _tOverTime = null;
            };
            btn_DownLoad.Invoke(enablecontrol);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + "\\Data.db";
            DbHelper.LoadDb(path);

            DataValidation.IsProtocol = true;
            DataValidation.ProtocolHead = 2;
            DataValidation.ProtocolEnd = 3;
            DataValidation.IsValidation = true;

            _mPort = new PortHelper
            {
                PortIsOpenChange = PortOpenOrCloseChange,
                PortDataReceived = PortDataReceived
            };
            _myMutex = new Mutex();
            _comPort = new ComPortHelper();
            _comPort.CountChange += ComPortChange;
            _comPort.Start();

            _rect = new Rectangle(p_ComPort.Width / 2 - 20, p_ComPort.Height - 14, 40, 14);

            _mNumber = DbHelper.Db.FirstDefault<ModuleNumber>() ?? new ModuleNumber() { Number = 1 };
            tb_ID.Text = _mNumber.Number.ToString();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Black, 1), new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }

        private void p_ComPort_MouseDown(object sender, MouseEventArgs e)
        {
            if (_rect.Contains(e.Location))
            {
                StartEffect();
            }
        }

        private void p_ComPort_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void p_ComPort_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = _rect.Contains(e.Location) ? Cursors.Hand : Cursors.Default;
        }

        private void p_ComPort_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                Image img = _isDirection ? Properties.Resources.down : Properties.Resources.top;
                g.DrawImage(img, p_ComPort.Width / 2 - img.Width / 2, _rect.Y, img.Width, img.Height);
            }
        }

        private void p_ComPort_Resize(object sender, EventArgs e)
        {
            _rect.Y = p_ComPort.Height - 14;
            p_ComPort.Invalidate(new Rectangle(_rect.X, 0, _rect.Width, p_ComPort.Height));
        }

        private void p_Title_MouseDown(object sender, MouseEventArgs e)
        {
            WinApi.ReleaseCapture();
            WinApi.SendMessage(this.Handle, WinApi.WM_SYSCOMMAND, WinApi.SC_MOVE + WinApi.HTCAPTION, 0);
        }

        private void PortDataReceived(int port)
        {
            Thread.Sleep(20);
            try
            {
                int len = _mPort.GetBytesToRead();
                if (len == 0) return;
                byte[] by = new byte[len];
                _mPort.Read(by, len);
                List<byte[]> bylist = DataValidation.Validation(by);
                foreach (byte[] item in bylist)
                {
                    if (item == null) continue;
                    ParsingParameter parameter = DataParsing.ParsingContent(item);
                    if (parameter.FunctionAddress == 50)
                    {
                        if (parameter.Command == 1)
                        {
                            long number = DataParsing.TemporaryContent(parameter.DataContent);
                            if (number == 1)
                            {
                                if (_currentNumber >= _mNumber.Number)
                                {
                                    _mNumber.Number = _currentNumber;
                                    if (_mNumber.Mid > 0)
                                        DbHelper.Db.Update<ModuleNumber>(_mNumber);
                                    else
                                        _mNumber.Mid = DbHelper.Db.Insert<ModuleNumber>(_mNumber);
                                }
                                EnableDownLoadControls(false);
                                return;
                            }
                            else
                            {
                                EnableDownLoadControls(true);
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            EnableDownLoadControls(true);
        }

        private void PortOpenOrCloseChange(object e, bool flag)
        {
            DefaultDelegate portChange = delegate
            {
                cb_PortName.Enabled = !flag;
                btn_OpenPort.Enabled = !flag;
                btn_ClosePort.Enabled = flag;
                btn_DownLoad.Enabled = flag;
            };
            btn_OpenPort.Invoke(portChange);
        }

        private void ShowAndHideControl()
        {
            foreach (Control item in p_ComPort.Controls)
            {
                item.Visible = !item.Visible;
            }
            if (_isDirection)
            {
                if (_mPort.IsOpen)
                {
                    btn_ClosePort.Focus();
                }
                else
                {
                    btn_OpenPort.Focus();
                }
            }
            else
            {
                tb_ID.Focus();
            }
        }

        private void ShowTEffect(object sender, ElapsedEventArgs e)
        {
            if (_isDirection)
            {
                if (p_ComPort.Height >= Height - p_ComPort.Top)
                {
                    _isDirection = !_isDirection;
                    p_ComPort.Height = Height - p_ComPort.Top;
                    _tEffect.Stop();
                    return;
                }
                p_ComPort.Height += 15;
            }
            else
            {
                if (p_ComPort.Height <= _rect.Height)
                {
                    _isDirection = !_isDirection;
                    p_ComPort.Height = _rect.Height;
                    _tEffect.Stop();
                    ShowAndHideControl();
                    return;
                }
                p_ComPort.Height -= 15;
            }
        }

        private void StartEffect()
        {
            if (_tEffect == null)
            {
                _tEffect = new System.Timers.Timer(1) { AutoReset = true };
                _tEffect.Elapsed += ShowTEffect;
            }
            if (_isDirection)
            {
                ShowAndHideControl();
            }
            _tEffect.Start();
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

    }
}