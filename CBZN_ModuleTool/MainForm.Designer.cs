namespace CBZN_ModuleTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.p_Title = new System.Windows.Forms.Panel();
            this.l_Title = new System.Windows.Forms.Label();
            this.btn_Close = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rtb_ShowContent = new System.Windows.Forms.RichTextBox();
            this.p_ComPort = new System.Windows.Forms.Panel();
            this.btn_ClosePort = new CCWin.SkinControl.SkinButton();
            this.btn_OpenPort = new CCWin.SkinControl.SkinButton();
            this.cb_PortName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ID = new System.Windows.Forms.TextBox();
            this.btn_DownLoad = new System.Windows.Forms.Button();
            this.p_Title.SuspendLayout();
            this.p_ComPort.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_Title
            // 
            this.p_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.p_Title.Controls.Add(this.l_Title);
            this.p_Title.Controls.Add(this.btn_Close);
            this.p_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Title.Location = new System.Drawing.Point(1, 0);
            this.p_Title.Name = "p_Title";
            this.p_Title.Size = new System.Drawing.Size(358, 40);
            this.p_Title.TabIndex = 3;
            this.p_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.p_Title_MouseDown);
            // 
            // l_Title
            // 
            this.l_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Title.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_Title.ForeColor = System.Drawing.Color.White;
            this.l_Title.Location = new System.Drawing.Point(0, 0);
            this.l_Title.Name = "l_Title";
            this.l_Title.Size = new System.Drawing.Size(306, 40);
            this.l_Title.TabIndex = 4;
            this.l_Title.Text = "模块编号下载工具";
            this.l_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.p_Title_MouseDown);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Close.DownBack = global::CBZN_ModuleTool.Properties.Resources.DownClose;
            this.btn_Close.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btn_Close.Location = new System.Drawing.Point(312, 0);
            this.btn_Close.MouseBack = global::CBZN_ModuleTool.Properties.Resources.HoverClose;
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.NormlBack = global::CBZN_ModuleTool.Properties.Resources.NoneClose;
            this.btn_Close.Size = new System.Drawing.Size(46, 31);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.TabStop = false;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(63, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID 编号";
            // 
            // rtb_ShowContent
            // 
            this.rtb_ShowContent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtb_ShowContent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb_ShowContent.Location = new System.Drawing.Point(1, 199);
            this.rtb_ShowContent.Name = "rtb_ShowContent";
            this.rtb_ShowContent.ReadOnly = true;
            this.rtb_ShowContent.Size = new System.Drawing.Size(358, 200);
            this.rtb_ShowContent.TabIndex = 0;
            this.rtb_ShowContent.Text = "";
            // 
            // p_ComPort
            // 
            this.p_ComPort.Controls.Add(this.btn_ClosePort);
            this.p_ComPort.Controls.Add(this.btn_OpenPort);
            this.p_ComPort.Controls.Add(this.cb_PortName);
            this.p_ComPort.Controls.Add(this.label2);
            this.p_ComPort.Location = new System.Drawing.Point(1, 40);
            this.p_ComPort.Margin = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.p_ComPort.Name = "p_ComPort";
            this.p_ComPort.Size = new System.Drawing.Size(358, 159);
            this.p_ComPort.TabIndex = 31;
            this.p_ComPort.Paint += new System.Windows.Forms.PaintEventHandler(this.p_ComPort_Paint);
            this.p_ComPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.p_ComPort_MouseDown);
            this.p_ComPort.MouseLeave += new System.EventHandler(this.p_ComPort_MouseLeave);
            this.p_ComPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.p_ComPort_MouseMove);
            this.p_ComPort.Resize += new System.EventHandler(this.p_ComPort_Resize);
            // 
            // btn_ClosePort
            // 
            this.btn_ClosePort.BackColor = System.Drawing.Color.Transparent;
            this.btn_ClosePort.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_ClosePort.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_ClosePort.DownBack = null;
            this.btn_ClosePort.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_ClosePort.Enabled = false;
            this.btn_ClosePort.FadeGlow = false;
            this.btn_ClosePort.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ClosePort.ForeColor = System.Drawing.Color.White;
            this.btn_ClosePort.IsDrawBorder = false;
            this.btn_ClosePort.IsDrawGlass = false;
            this.btn_ClosePort.Location = new System.Drawing.Point(202, 88);
            this.btn_ClosePort.MouseBack = null;
            this.btn_ClosePort.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_ClosePort.Name = "btn_ClosePort";
            this.btn_ClosePort.NormlBack = null;
            this.btn_ClosePort.Size = new System.Drawing.Size(100, 35);
            this.btn_ClosePort.TabIndex = 3;
            this.btn_ClosePort.TabStop = false;
            this.btn_ClosePort.Text = "关 闭";
            this.btn_ClosePort.UseVisualStyleBackColor = false;
            this.btn_ClosePort.Click += new System.EventHandler(this.btn_ClosePort_Click);
            // 
            // btn_OpenPort
            // 
            this.btn_OpenPort.BackColor = System.Drawing.Color.Transparent;
            this.btn_OpenPort.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_OpenPort.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_OpenPort.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_OpenPort.DownBack = null;
            this.btn_OpenPort.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_OpenPort.Enabled = false;
            this.btn_OpenPort.FadeGlow = false;
            this.btn_OpenPort.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OpenPort.ForeColor = System.Drawing.Color.White;
            this.btn_OpenPort.IsDrawBorder = false;
            this.btn_OpenPort.IsDrawGlass = false;
            this.btn_OpenPort.Location = new System.Drawing.Point(61, 88);
            this.btn_OpenPort.MouseBack = null;
            this.btn_OpenPort.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_OpenPort.Name = "btn_OpenPort";
            this.btn_OpenPort.NormlBack = null;
            this.btn_OpenPort.Size = new System.Drawing.Size(100, 35);
            this.btn_OpenPort.TabIndex = 2;
            this.btn_OpenPort.TabStop = false;
            this.btn_OpenPort.Text = "打 开";
            this.btn_OpenPort.UseVisualStyleBackColor = false;
            this.btn_OpenPort.EnabledChanged += new System.EventHandler(this.btn_OpenPort_EnabledChanged);
            this.btn_OpenPort.VisibleChanged += new System.EventHandler(this.btn_OpenPort_VisibleChanged);
            this.btn_OpenPort.Click += new System.EventHandler(this.btn_OpenPort_Click);
            // 
            // cb_PortName
            // 
            this.cb_PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_PortName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cb_PortName.FormattingEnabled = true;
            this.cb_PortName.Location = new System.Drawing.Point(127, 35);
            this.cb_PortName.Name = "cb_PortName";
            this.cb_PortName.Size = new System.Drawing.Size(175, 29);
            this.cb_PortName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(57, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "连接端口";
            // 
            // tb_ID
            // 
            this.tb_ID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_ID.Location = new System.Drawing.Point(121, 72);
            this.tb_ID.MaxLength = 8;
            this.tb_ID.Name = "tb_ID";
            this.tb_ID.Size = new System.Drawing.Size(175, 29);
            this.tb_ID.TabIndex = 4;
            this.tb_ID.Text = "1";
            this.tb_ID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_ID_KeyDown);
            this.tb_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ID_KeyPress);
            // 
            // btn_DownLoad
            // 
            this.btn_DownLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_DownLoad.Enabled = false;
            this.btn_DownLoad.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_DownLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_DownLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_DownLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DownLoad.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_DownLoad.ForeColor = System.Drawing.Color.White;
            this.btn_DownLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DownLoad.Location = new System.Drawing.Point(67, 120);
            this.btn_DownLoad.Name = "btn_DownLoad";
            this.btn_DownLoad.Size = new System.Drawing.Size(230, 60);
            this.btn_DownLoad.TabIndex = 32;
            this.btn_DownLoad.Text = "下 载";
            this.btn_DownLoad.UseVisualStyleBackColor = false;
            this.btn_DownLoad.Click += new System.EventHandler(this.btn_DownLoad_Click);
            this.btn_DownLoad.Paint += new System.Windows.Forms.PaintEventHandler(this.btn_DownLoad_Paint);
            this.btn_DownLoad.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_DownLoad_MouseDown);
            this.btn_DownLoad.MouseEnter += new System.EventHandler(this.btn_DownLoad_MouseEnter);
            this.btn_DownLoad.MouseLeave += new System.EventHandler(this.btn_DownLoad_MouseLeave);
            this.btn_DownLoad.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_DownLoad_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(360, 400);
            this.Controls.Add(this.p_ComPort);
            this.Controls.Add(this.btn_DownLoad);
            this.Controls.Add(this.rtb_ShowContent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ID);
            this.Controls.Add(this.p_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.p_Title.ResumeLayout(false);
            this.p_ComPort.ResumeLayout(false);
            this.p_ComPort.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_Title;
        private System.Windows.Forms.Label l_Title;
        private CCWin.SkinControl.SkinButton btn_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtb_ShowContent;
        private System.Windows.Forms.Panel p_ComPort;
        private System.Windows.Forms.Label label2;
        private CCWin.SkinControl.SkinButton btn_ClosePort;
        private CCWin.SkinControl.SkinButton btn_OpenPort;
        private System.Windows.Forms.ComboBox cb_PortName;
        private System.Windows.Forms.TextBox tb_ID;
        private System.Windows.Forms.Button btn_DownLoad;


    }
}

