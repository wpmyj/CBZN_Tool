using System.Drawing;
using Bll;
using Dal;
using Microsoft.VisualBasic.FileIO;
using Model;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows.Forms;

namespace CBZN_TestTool
{
    public partial class DeviceImport : Form
    {
        private readonly string[] _fileNames;
        private bool _isClose;
        private System.Timers.Timer _timer;

        public DeviceImport(string[] fileNames)
        {
            InitializeComponent();
            _fileNames = fileNames;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            _isClose = true;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            _isClose = true;
        }

        private void DeviceImport_Load(object sender, EventArgs e)
        {
            pb_Import.Maximum = _fileNames.Length;
            pb_Import.Minimum = 0;
            pb_Import.Value = 0;
            _timer = new System.Timers.Timer { AutoReset = false };
            _timer.Elapsed += Import;
            _timer.Start();
        }

        private void GetDeviceInfo(string filename)
        {
            try
            {
                DeviceInfo dinfo = new DeviceInfo();
                using (TextFieldParser tfp = new TextFieldParser(filename))
                {
                    tfp.Delimiters = new[] { ",", "<", ">" };
                    tfp.TextFieldType = FieldType.Delimited;
                    while (!tfp.EndOfData)
                    {
                        string[] content = tfp.ReadFields();
                        if (content != null)
                        {
                            int number = Convert.ToInt32(content[0], 16);
                            string value = content[2];
                            switch (number)
                            {
                                case 0:
                                    dinfo.HostNumber = HexadecimalConversion.StrToInt(value.Substring(0, 2));
                                    dinfo.FrequencyOffset = HexadecimalConversion.StrToInt(value.Substring(2, 2));
                                    dinfo.WirelessNumber = HexadecimalConversion.StrToInt(value.Substring(4, 8));
                                    dinfo.CameraDetection = HexadecimalConversion.StrToInt(value.Substring(12, 2));
                                    break;

                                case 1:
                                    dinfo.CardReadDistance = HexadecimalConversion.StrToInt(value);
                                    break;

                                case 2:
                                    dinfo.ReadCardDelay = HexadecimalConversion.StrToInt(value);
                                    break;

                                case 8:
                                    dinfo.Partition = Convert.ToInt32(value, 16);
                                    break;

                                case 9:
                                    if (!string.IsNullOrEmpty(value))
                                        dinfo.IOMouth = HexadecimalConversion.StrToInt(value);
                                    break;

                                case 10:
                                    dinfo.SAPBF = HexadecimalConversion.StrToInt(value);
                                    break;

                                case 12:
                                    switch (value.Substring(value.Length - 2, 2))
                                    {
                                        case "F0"://继电器开闸
                                            dinfo.OpenModel = 3;
                                            dinfo.BrakeNumber = 1;
                                            break;

                                        case "AA"://学习遥控器开闸
                                            dinfo.OpenModel = 2;
                                            dinfo.BrakeNumber = 1;
                                            break;

                                        case "FF"://串口开闸
                                            dinfo.OpenModel = 0;
                                            dinfo.BrakeNumber = Convert.ToInt32(value.Substring(0, 6), 16);
                                            break;

                                        case "55"://无线电开闸
                                            dinfo.OpenModel = 1;
                                            dinfo.BrakeNumber = Convert.ToInt32(value.Substring(0, 6), 16);
                                            break;
                                    }
                                    break;

                                case 13:
                                    dinfo.Language = HexadecimalConversion.StrToInt(value);
                                    break;

                                case 15:
                                    dinfo.Detection = HexadecimalConversion.StrToInt(value);
                                    break;
                                case 17:
                                    dinfo.Detection = HexadecimalConversion.StrToInt(value);
                                    break;
                            }
                        }
                    }
                }
                DbHelper.Db.Insert(dinfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Import(object sender, ElapsedEventArgs e)
        {
            foreach (string item in _fileNames)
            {
                if (_isClose)
                    break;
                if (File.Exists(item))
                {
                    string name = Path.GetFileNameWithoutExtension(item);
                    if (Regex.IsMatch(name, @"FORM(([A-F]+[0-9])|([0-9]+[A-F])|[A-F]{2}|\d{2})"))
                    {
                        GetDeviceInfo(item);
                    }
                }
                pb_Import.PerformStep();
            }
            Close();
        }

        private void l_Title_MouseDown(object sender, MouseEventArgs e)
        {
            WinApi.ReleaseCapture();
            WinApi.SendMessage(this.Handle, WinApi.WM_SYSCOMMAND, WinApi.SC_MOVE + WinApi.HTCAPTION, 0);
        }

        private void DeviceImport_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g=e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 1), 0, 0, Width - 1, Height - 1);
            }
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