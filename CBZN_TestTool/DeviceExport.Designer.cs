namespace CBZN_TestTool
{
    partial class DeviceExport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceExport));
            this.p_Title = new System.Windows.Forms.Panel();
            this.btn_Close = new CCWin.SkinControl.SkinButton();
            this.cb_Path = new System.Windows.Forms.ComboBox();
            this.btn_Enter = new CCWin.SkinControl.SkinButton();
            this.cb_SetControlPwd = new System.Windows.Forms.CheckBox();
            this.cb_SetHostPwd = new System.Windows.Forms.CheckBox();
            this.cb_SetCardMachinePwd = new System.Windows.Forms.CheckBox();
            this.tb_ControlPwd = new System.Windows.Forms.TextBox();
            this.tb_ConfirmControlPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_ConfirmHostPwd = new System.Windows.Forms.TextBox();
            this.tb_HostPwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_ConfirmCardMachinePwd = new System.Windows.Forms.TextBox();
            this.tb_CardMachinePwd = new System.Windows.Forms.TextBox();
            this.cb_DefaultControlPwd = new System.Windows.Forms.CheckBox();
            this.cb_DefaultHostPwd = new System.Windows.Forms.CheckBox();
            this.cb_DefaultCardMachinePwd = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_OldHostPwd = new System.Windows.Forms.TextBox();
            this.cb_DefaultOldHostPwd = new System.Windows.Forms.CheckBox();
            this.p_Title.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_Title
            // 
            this.p_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.p_Title.Controls.Add(this.btn_Close);
            this.p_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Title.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p_Title.Location = new System.Drawing.Point(1, 1);
            this.p_Title.Name = "p_Title";
            this.p_Title.Size = new System.Drawing.Size(448, 40);
            this.p_Title.TabIndex = 5;
            this.p_Title.Paint += new System.Windows.Forms.PaintEventHandler(this.p_Title_Paint);
            this.p_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DeviceExport_MouseDown);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Close.DownBack = global::CBZN_TestTool.Properties.Resources.DownClose;
            this.btn_Close.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btn_Close.Location = new System.Drawing.Point(402, 0);
            this.btn_Close.MouseBack = global::CBZN_TestTool.Properties.Resources.HoverClose;
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.NormlBack = global::CBZN_TestTool.Properties.Resources.NoneClose;
            this.btn_Close.Size = new System.Drawing.Size(46, 31);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // cb_Path
            // 
            this.cb_Path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_Path.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Path.FormattingEnabled = true;
            this.cb_Path.Location = new System.Drawing.Point(26, 505);
            this.cb_Path.Name = "cb_Path";
            this.cb_Path.Size = new System.Drawing.Size(295, 28);
            this.cb_Path.TabIndex = 13;
            this.cb_Path.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Path.DropDown += new System.EventHandler(this.cb_Path_DropDown);
            // 
            // btn_Enter
            // 
            this.btn_Enter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Enter.BackColor = System.Drawing.Color.Transparent;
            this.btn_Enter.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Enter.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Enter.DownBack = null;
            this.btn_Enter.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Enter.FadeGlow = false;
            this.btn_Enter.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Enter.ForeColor = System.Drawing.Color.White;
            this.btn_Enter.IsDrawBorder = false;
            this.btn_Enter.IsDrawGlass = false;
            this.btn_Enter.Location = new System.Drawing.Point(327, 501);
            this.btn_Enter.MouseBack = null;
            this.btn_Enter.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.NormlBack = null;
            this.btn_Enter.Size = new System.Drawing.Size(100, 35);
            this.btn_Enter.TabIndex = 14;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "导 出";
            this.btn_Enter.UseVisualStyleBackColor = false;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // cb_SetControlPwd
            // 
            this.cb_SetControlPwd.AutoSize = true;
            this.cb_SetControlPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_SetControlPwd.Location = new System.Drawing.Point(56, 62);
            this.cb_SetControlPwd.Name = "cb_SetControlPwd";
            this.cb_SetControlPwd.Size = new System.Drawing.Size(215, 21);
            this.cb_SetControlPwd.TabIndex = 0;
            this.cb_SetControlPwd.Text = "设置控制板密码 ( 显示屏操作密码 )";
            this.cb_SetControlPwd.UseVisualStyleBackColor = true;
            this.cb_SetControlPwd.CheckedChanged += new System.EventHandler(this.cb_SetControlPwd_CheckedChanged);
            // 
            // cb_SetHostPwd
            // 
            this.cb_SetHostPwd.AutoSize = true;
            this.cb_SetHostPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_SetHostPwd.Location = new System.Drawing.Point(56, 188);
            this.cb_SetHostPwd.Name = "cb_SetHostPwd";
            this.cb_SetHostPwd.Size = new System.Drawing.Size(215, 21);
            this.cb_SetHostPwd.TabIndex = 3;
            this.cb_SetHostPwd.Text = "设置主机的系统口令 ( 定距卡密码 )";
            this.cb_SetHostPwd.UseVisualStyleBackColor = true;
            this.cb_SetHostPwd.CheckedChanged += new System.EventHandler(this.cb_SetHostPwd_CheckedChanged);
            // 
            // cb_SetCardMachinePwd
            // 
            this.cb_SetCardMachinePwd.AutoSize = true;
            this.cb_SetCardMachinePwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_SetCardMachinePwd.Location = new System.Drawing.Point(56, 380);
            this.cb_SetCardMachinePwd.Name = "cb_SetCardMachinePwd";
            this.cb_SetCardMachinePwd.Size = new System.Drawing.Size(203, 21);
            this.cb_SetCardMachinePwd.TabIndex = 9;
            this.cb_SetCardMachinePwd.Text = "设置IC卡系统口令 ( 出卡机密码 )";
            this.cb_SetCardMachinePwd.UseVisualStyleBackColor = true;
            this.cb_SetCardMachinePwd.CheckedChanged += new System.EventHandler(this.cb_SetCardMachinePwd_CheckedChanged);
            // 
            // tb_ControlPwd
            // 
            this.tb_ControlPwd.Enabled = false;
            this.tb_ControlPwd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_ControlPwd.Location = new System.Drawing.Point(190, 96);
            this.tb_ControlPwd.MaxLength = 6;
            this.tb_ControlPwd.Name = "tb_ControlPwd";
            this.tb_ControlPwd.Size = new System.Drawing.Size(150, 26);
            this.tb_ControlPwd.TabIndex = 1;
            this.tb_ControlPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ControlPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKeyPress);
            // 
            // tb_ConfirmControlPwd
            // 
            this.tb_ConfirmControlPwd.Enabled = false;
            this.tb_ConfirmControlPwd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_ConfirmControlPwd.Location = new System.Drawing.Point(190, 139);
            this.tb_ConfirmControlPwd.MaxLength = 6;
            this.tb_ConfirmControlPwd.Name = "tb_ConfirmControlPwd";
            this.tb_ConfirmControlPwd.Size = new System.Drawing.Size(150, 26);
            this.tb_ConfirmControlPwd.TabIndex = 2;
            this.tb_ConfirmControlPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ConfirmControlPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(132, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "密 码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(112, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "确认密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(112, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "确认口令：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(132, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "口 令：";
            // 
            // tb_ConfirmHostPwd
            // 
            this.tb_ConfirmHostPwd.Enabled = false;
            this.tb_ConfirmHostPwd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_ConfirmHostPwd.Location = new System.Drawing.Point(190, 329);
            this.tb_ConfirmHostPwd.MaxLength = 6;
            this.tb_ConfirmHostPwd.Name = "tb_ConfirmHostPwd";
            this.tb_ConfirmHostPwd.Size = new System.Drawing.Size(150, 26);
            this.tb_ConfirmHostPwd.TabIndex = 8;
            this.tb_ConfirmHostPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ConfirmHostPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKeyPress);
            // 
            // tb_HostPwd
            // 
            this.tb_HostPwd.Enabled = false;
            this.tb_HostPwd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_HostPwd.Location = new System.Drawing.Point(190, 288);
            this.tb_HostPwd.MaxLength = 6;
            this.tb_HostPwd.Name = "tb_HostPwd";
            this.tb_HostPwd.Size = new System.Drawing.Size(150, 26);
            this.tb_HostPwd.TabIndex = 7;
            this.tb_HostPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_HostPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(112, 466);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "确认口令：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(132, 423);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "口 令：";
            // 
            // tb_ConfirmCardMachinePwd
            // 
            this.tb_ConfirmCardMachinePwd.Enabled = false;
            this.tb_ConfirmCardMachinePwd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_ConfirmCardMachinePwd.Location = new System.Drawing.Point(190, 460);
            this.tb_ConfirmCardMachinePwd.MaxLength = 8;
            this.tb_ConfirmCardMachinePwd.Name = "tb_ConfirmCardMachinePwd";
            this.tb_ConfirmCardMachinePwd.Size = new System.Drawing.Size(150, 26);
            this.tb_ConfirmCardMachinePwd.TabIndex = 12;
            this.tb_ConfirmCardMachinePwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ConfirmCardMachinePwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKeyPress);
            // 
            // tb_CardMachinePwd
            // 
            this.tb_CardMachinePwd.Enabled = false;
            this.tb_CardMachinePwd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_CardMachinePwd.Location = new System.Drawing.Point(190, 417);
            this.tb_CardMachinePwd.MaxLength = 8;
            this.tb_CardMachinePwd.Name = "tb_CardMachinePwd";
            this.tb_CardMachinePwd.Size = new System.Drawing.Size(150, 26);
            this.tb_CardMachinePwd.TabIndex = 11;
            this.tb_CardMachinePwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_CardMachinePwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKeyPress);
            // 
            // cb_DefaultControlPwd
            // 
            this.cb_DefaultControlPwd.AutoSize = true;
            this.cb_DefaultControlPwd.Enabled = false;
            this.cb_DefaultControlPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_DefaultControlPwd.Location = new System.Drawing.Point(301, 62);
            this.cb_DefaultControlPwd.Name = "cb_DefaultControlPwd";
            this.cb_DefaultControlPwd.Size = new System.Drawing.Size(75, 21);
            this.cb_DefaultControlPwd.TabIndex = 23;
            this.cb_DefaultControlPwd.Text = "默认密码";
            this.cb_DefaultControlPwd.UseVisualStyleBackColor = true;
            this.cb_DefaultControlPwd.CheckedChanged += new System.EventHandler(this.cb_DefaultControlPwd_CheckedChanged);
            // 
            // cb_DefaultHostPwd
            // 
            this.cb_DefaultHostPwd.AutoSize = true;
            this.cb_DefaultHostPwd.Enabled = false;
            this.cb_DefaultHostPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_DefaultHostPwd.Location = new System.Drawing.Point(301, 258);
            this.cb_DefaultHostPwd.Name = "cb_DefaultHostPwd";
            this.cb_DefaultHostPwd.Size = new System.Drawing.Size(75, 21);
            this.cb_DefaultHostPwd.TabIndex = 6;
            this.cb_DefaultHostPwd.Text = "默认密码";
            this.cb_DefaultHostPwd.UseVisualStyleBackColor = true;
            this.cb_DefaultHostPwd.CheckedChanged += new System.EventHandler(this.cb_DefaultHostPwd_CheckedChanged);
            // 
            // cb_DefaultCardMachinePwd
            // 
            this.cb_DefaultCardMachinePwd.AutoSize = true;
            this.cb_DefaultCardMachinePwd.Enabled = false;
            this.cb_DefaultCardMachinePwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_DefaultCardMachinePwd.Location = new System.Drawing.Point(301, 380);
            this.cb_DefaultCardMachinePwd.Name = "cb_DefaultCardMachinePwd";
            this.cb_DefaultCardMachinePwd.Size = new System.Drawing.Size(75, 21);
            this.cb_DefaultCardMachinePwd.TabIndex = 10;
            this.cb_DefaultCardMachinePwd.Text = "默认密码";
            this.cb_DefaultCardMachinePwd.UseVisualStyleBackColor = true;
            this.cb_DefaultCardMachinePwd.CheckedChanged += new System.EventHandler(this.cb_DefaultCardMachinePwd_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(124, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 27;
            this.label7.Text = "旧口令：";
            // 
            // tb_OldHostPwd
            // 
            this.tb_OldHostPwd.Enabled = false;
            this.tb_OldHostPwd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_OldHostPwd.Location = new System.Drawing.Point(190, 220);
            this.tb_OldHostPwd.MaxLength = 6;
            this.tb_OldHostPwd.Name = "tb_OldHostPwd";
            this.tb_OldHostPwd.Size = new System.Drawing.Size(150, 26);
            this.tb_OldHostPwd.TabIndex = 5;
            this.tb_OldHostPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_OldHostPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKeyPress);
            // 
            // cb_DefaultOldHostPwd
            // 
            this.cb_DefaultOldHostPwd.AutoSize = true;
            this.cb_DefaultOldHostPwd.Enabled = false;
            this.cb_DefaultOldHostPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_DefaultOldHostPwd.Location = new System.Drawing.Point(301, 188);
            this.cb_DefaultOldHostPwd.Name = "cb_DefaultOldHostPwd";
            this.cb_DefaultOldHostPwd.Size = new System.Drawing.Size(75, 21);
            this.cb_DefaultOldHostPwd.TabIndex = 4;
            this.cb_DefaultOldHostPwd.Text = "默认密码";
            this.cb_DefaultOldHostPwd.UseVisualStyleBackColor = true;
            this.cb_DefaultOldHostPwd.CheckedChanged += new System.EventHandler(this.cb_DefaultOldHostPwd_CheckedChanged);
            // 
            // DeviceExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 560);
            this.Controls.Add(this.cb_DefaultOldHostPwd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_OldHostPwd);
            this.Controls.Add(this.cb_DefaultCardMachinePwd);
            this.Controls.Add(this.cb_DefaultHostPwd);
            this.Controls.Add(this.cb_DefaultControlPwd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_ConfirmCardMachinePwd);
            this.Controls.Add(this.tb_CardMachinePwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_ConfirmHostPwd);
            this.Controls.Add(this.tb_HostPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ConfirmControlPwd);
            this.Controls.Add(this.tb_ControlPwd);
            this.Controls.Add(this.cb_SetCardMachinePwd);
            this.Controls.Add(this.cb_SetHostPwd);
            this.Controls.Add(this.cb_SetControlPwd);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.cb_Path);
            this.Controls.Add(this.p_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceExport";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编录导出";
            this.Load += new System.EventHandler(this.DeviceExport_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DeviceExport_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DeviceExport_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DeviceExport_MouseDown);
            this.p_Title.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_Title;
        private CCWin.SkinControl.SkinButton btn_Close;
        private System.Windows.Forms.ComboBox cb_Path;
        private CCWin.SkinControl.SkinButton btn_Enter;
        private System.Windows.Forms.CheckBox cb_SetControlPwd;
        private System.Windows.Forms.CheckBox cb_SetHostPwd;
        private System.Windows.Forms.CheckBox cb_SetCardMachinePwd;
        private System.Windows.Forms.TextBox tb_ControlPwd;
        private System.Windows.Forms.TextBox tb_ConfirmControlPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_ConfirmHostPwd;
        private System.Windows.Forms.TextBox tb_HostPwd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_ConfirmCardMachinePwd;
        private System.Windows.Forms.TextBox tb_CardMachinePwd;
        private System.Windows.Forms.CheckBox cb_DefaultControlPwd;
        private System.Windows.Forms.CheckBox cb_DefaultHostPwd;
        private System.Windows.Forms.CheckBox cb_DefaultCardMachinePwd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_OldHostPwd;
        private System.Windows.Forms.CheckBox cb_DefaultOldHostPwd;
    }
}