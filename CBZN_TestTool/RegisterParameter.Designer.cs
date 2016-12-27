namespace CBZN_TestTool
{
    partial class RegisterParameter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterParameter));
            this.p_Title = new System.Windows.Forms.Panel();
            this.l_Title = new System.Windows.Forms.Label();
            this.btn_Close = new CCWin.SkinControl.SkinButton();
            this.cb_CardPartition = new System.Windows.Forms.ComboBox();
            this.l_CardPartition = new System.Windows.Forms.Label();
            this.t_CardTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_CardDistance = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.p_CardPartition = new System.Windows.Forms.Panel();
            this.cb_Partition16 = new System.Windows.Forms.CheckBox();
            this.cb_Partition15 = new System.Windows.Forms.CheckBox();
            this.cb_Partition14 = new System.Windows.Forms.CheckBox();
            this.cb_Partition13 = new System.Windows.Forms.CheckBox();
            this.cb_Partition12 = new System.Windows.Forms.CheckBox();
            this.cb_Partition11 = new System.Windows.Forms.CheckBox();
            this.cb_Partition10 = new System.Windows.Forms.CheckBox();
            this.cb_Partition9 = new System.Windows.Forms.CheckBox();
            this.cb_Partition8 = new System.Windows.Forms.CheckBox();
            this.cb_Partition7 = new System.Windows.Forms.CheckBox();
            this.cb_Partition6 = new System.Windows.Forms.CheckBox();
            this.cb_Partition5 = new System.Windows.Forms.CheckBox();
            this.cb_Partition4 = new System.Windows.Forms.CheckBox();
            this.cb_Partition3 = new System.Windows.Forms.CheckBox();
            this.cb_Partition2 = new System.Windows.Forms.CheckBox();
            this.cb_Partition1 = new System.Windows.Forms.CheckBox();
            this.cb_AllSelected = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Canel = new CCWin.SkinControl.SkinButton();
            this.btn_Enter = new CCWin.SkinControl.SkinButton();
            this.p_Title.SuspendLayout();
            this.p_CardPartition.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_Title
            // 
            this.p_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.p_Title.Controls.Add(this.l_Title);
            this.p_Title.Controls.Add(this.btn_Close);
            this.p_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Title.Location = new System.Drawing.Point(0, 0);
            this.p_Title.Name = "p_Title";
            this.p_Title.Size = new System.Drawing.Size(472, 40);
            this.p_Title.TabIndex = 6;
            // 
            // l_Title
            // 
            this.l_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Title.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_Title.ForeColor = System.Drawing.Color.White;
            this.l_Title.Location = new System.Drawing.Point(0, 0);
            this.l_Title.Name = "l_Title";
            this.l_Title.Size = new System.Drawing.Size(420, 40);
            this.l_Title.TabIndex = 4;
            this.l_Title.Text = "批量发行参数";
            this.l_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.l_Title_MouseDown);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Close.DownBack = global::CBZN_TestTool.Properties.Resources.DownClose;
            this.btn_Close.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btn_Close.Location = new System.Drawing.Point(426, 0);
            this.btn_Close.MouseBack = global::CBZN_TestTool.Properties.Resources.HoverClose;
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.NormlBack = global::CBZN_TestTool.Properties.Resources.NoneClose;
            this.btn_Close.Size = new System.Drawing.Size(46, 31);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.TabStop = false;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // cb_CardPartition
            // 
            this.cb_CardPartition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CardPartition.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_CardPartition.FormattingEnabled = true;
            this.cb_CardPartition.Items.AddRange(new object[] {
            "关闭",
            "开启"});
            this.cb_CardPartition.Location = new System.Drawing.Point(93, 115);
            this.cb_CardPartition.Name = "cb_CardPartition";
            this.cb_CardPartition.Size = new System.Drawing.Size(130, 28);
            this.cb_CardPartition.TabIndex = 19;
            this.cb_CardPartition.SelectedIndexChanged += new System.EventHandler(this.cb_CardPartition_SelectedIndexChanged);
            // 
            // l_CardPartition
            // 
            this.l_CardPartition.AutoSize = true;
            this.l_CardPartition.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_CardPartition.Location = new System.Drawing.Point(19, 121);
            this.l_CardPartition.Name = "l_CardPartition";
            this.l_CardPartition.Size = new System.Drawing.Size(68, 17);
            this.l_CardPartition.TabIndex = 23;
            this.l_CardPartition.Text = "车场分区：";
            // 
            // t_CardTime
            // 
            this.t_CardTime.CustomFormat = "yyyy年MM月dd日";
            this.t_CardTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_CardTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.t_CardTime.Location = new System.Drawing.Point(93, 65);
            this.t_CardTime.Name = "t_CardTime";
            this.t_CardTime.Size = new System.Drawing.Size(130, 26);
            this.t_CardTime.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(19, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "有效期限：";
            // 
            // cb_CardDistance
            // 
            this.cb_CardDistance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CardDistance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_CardDistance.FormattingEnabled = true;
            this.cb_CardDistance.Items.AddRange(new object[] {
            "主机控制",
            "1.2 米",
            "2.5 米",
            "3.8 米",
            "5 米"});
            this.cb_CardDistance.Location = new System.Drawing.Point(326, 64);
            this.cb_CardDistance.Name = "cb_CardDistance";
            this.cb_CardDistance.Size = new System.Drawing.Size(130, 28);
            this.cb_CardDistance.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(252, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "读写距离：";
            // 
            // p_CardPartition
            // 
            this.p_CardPartition.Controls.Add(this.cb_Partition16);
            this.p_CardPartition.Controls.Add(this.cb_Partition15);
            this.p_CardPartition.Controls.Add(this.cb_Partition14);
            this.p_CardPartition.Controls.Add(this.cb_Partition13);
            this.p_CardPartition.Controls.Add(this.cb_Partition12);
            this.p_CardPartition.Controls.Add(this.cb_Partition11);
            this.p_CardPartition.Controls.Add(this.cb_Partition10);
            this.p_CardPartition.Controls.Add(this.cb_Partition9);
            this.p_CardPartition.Controls.Add(this.cb_Partition8);
            this.p_CardPartition.Controls.Add(this.cb_Partition7);
            this.p_CardPartition.Controls.Add(this.cb_Partition6);
            this.p_CardPartition.Controls.Add(this.cb_Partition5);
            this.p_CardPartition.Controls.Add(this.cb_Partition4);
            this.p_CardPartition.Controls.Add(this.cb_Partition3);
            this.p_CardPartition.Controls.Add(this.cb_Partition2);
            this.p_CardPartition.Controls.Add(this.cb_Partition1);
            this.p_CardPartition.Controls.Add(this.cb_AllSelected);
            this.p_CardPartition.Controls.Add(this.label7);
            this.p_CardPartition.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p_CardPartition.Location = new System.Drawing.Point(16, 155);
            this.p_CardPartition.Name = "p_CardPartition";
            this.p_CardPartition.Size = new System.Drawing.Size(440, 155);
            this.p_CardPartition.TabIndex = 24;
            this.p_CardPartition.Paint += new System.Windows.Forms.PaintEventHandler(this.p_CardPartition_Paint);
            // 
            // cb_Partition16
            // 
            this.cb_Partition16.AutoSize = true;
            this.cb_Partition16.Location = new System.Drawing.Point(14, 125);
            this.cb_Partition16.Name = "cb_Partition16";
            this.cb_Partition16.Size = new System.Drawing.Size(69, 21);
            this.cb_Partition16.TabIndex = 16;
            this.cb_Partition16.Text = "16 分区";
            this.cb_Partition16.UseVisualStyleBackColor = true;
            this.cb_Partition16.CheckedChanged += new System.EventHandler(this.cb_Partition_CheckedChanged);
            // 
            // cb_Partition15
            // 
            this.cb_Partition15.AutoSize = true;
            this.cb_Partition15.Location = new System.Drawing.Point(358, 98);
            this.cb_Partition15.Name = "cb_Partition15";
            this.cb_Partition15.Size = new System.Drawing.Size(69, 21);
            this.cb_Partition15.TabIndex = 15;
            this.cb_Partition15.Text = "15 分区";
            this.cb_Partition15.UseVisualStyleBackColor = true;
            this.cb_Partition15.CheckedChanged += new System.EventHandler(this.cb_Partition_CheckedChanged);
            // 
            // cb_Partition14
            // 
            this.cb_Partition14.AutoSize = true;
            this.cb_Partition14.Location = new System.Drawing.Point(272, 98);
            this.cb_Partition14.Name = "cb_Partition14";
            this.cb_Partition14.Size = new System.Drawing.Size(69, 21);
            this.cb_Partition14.TabIndex = 14;
            this.cb_Partition14.Text = "14 分区";
            this.cb_Partition14.UseVisualStyleBackColor = true;
            this.cb_Partition14.CheckedChanged += new System.EventHandler(this.cb_Partition_CheckedChanged);
            // 
            // cb_Partition13
            // 
            this.cb_Partition13.AutoSize = true;
            this.cb_Partition13.Location = new System.Drawing.Point(186, 98);
            this.cb_Partition13.Name = "cb_Partition13";
            this.cb_Partition13.Size = new System.Drawing.Size(69, 21);
            this.cb_Partition13.TabIndex = 13;
            this.cb_Partition13.Text = "13 分区";
            this.cb_Partition13.UseVisualStyleBackColor = true;
            this.cb_Partition13.CheckedChanged += new System.EventHandler(this.cb_Partition_CheckedChanged);
            // 
            // cb_Partition12
            // 
            this.cb_Partition12.AutoSize = true;
            this.cb_Partition12.Location = new System.Drawing.Point(100, 98);
            this.cb_Partition12.Name = "cb_Partition12";
            this.cb_Partition12.Size = new System.Drawing.Size(69, 21);
            this.cb_Partition12.TabIndex = 12;
            this.cb_Partition12.Text = "12 分区";
            this.cb_Partition12.UseVisualStyleBackColor = true;
            this.cb_Partition12.CheckedChanged += new System.EventHandler(this.cb_Partition_CheckedChanged);
            // 
            // cb_Partition11
            // 
            this.cb_Partition11.AutoSize = true;
            this.cb_Partition11.Location = new System.Drawing.Point(14, 98);
            this.cb_Partition11.Name = "cb_Partition11";
            this.cb_Partition11.Size = new System.Drawing.Size(69, 21);
            this.cb_Partition11.TabIndex = 11;
            this.cb_Partition11.Text = "11 分区";
            this.cb_Partition11.UseVisualStyleBackColor = true;
            this.cb_Partition11.CheckedChanged += new System.EventHandler(this.cb_Partition_CheckedChanged);
            // 
            // cb_Partition10
            // 
            this.cb_Partition10.AutoSize = true;
            this.cb_Partition10.Location = new System.Drawing.Point(358, 71);
            this.cb_Partition10.Name = "cb_Partition10";
            this.cb_Partition10.Size = new System.Drawing.Size(69, 21);
            this.cb_Partition10.TabIndex = 10;
            this.cb_Partition10.Text = "10 分区";
            this.cb_Partition10.UseVisualStyleBackColor = true;
            this.cb_Partition10.CheckedChanged += new System.EventHandler(this.cb_Partition_CheckedChanged);
            // 
            // cb_Partition9
            // 
            this.cb_Partition9.AutoSize = true;
            this.cb_Partition9.Location = new System.Drawing.Point(272, 71);
            this.cb_Partition9.Name = "cb_Partition9";
            this.cb_Partition9.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition9.TabIndex = 9;
            this.cb_Partition9.Text = "9 分区";
            this.cb_Partition9.UseVisualStyleBackColor = true;
            this.cb_Partition9.CheckedChanged += new System.EventHandler(this.cb_Partition_CheckedChanged);
            // 
            // cb_Partition8
            // 
            this.cb_Partition8.AutoSize = true;
            this.cb_Partition8.Location = new System.Drawing.Point(186, 71);
            this.cb_Partition8.Name = "cb_Partition8";
            this.cb_Partition8.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition8.TabIndex = 8;
            this.cb_Partition8.Text = "8 分区";
            this.cb_Partition8.UseVisualStyleBackColor = true;
            this.cb_Partition8.CheckedChanged += new System.EventHandler(this.cb_Partition_CheckedChanged);
            // 
            // cb_Partition7
            // 
            this.cb_Partition7.AutoSize = true;
            this.cb_Partition7.Location = new System.Drawing.Point(100, 71);
            this.cb_Partition7.Name = "cb_Partition7";
            this.cb_Partition7.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition7.TabIndex = 7;
            this.cb_Partition7.Text = "7 分区";
            this.cb_Partition7.UseVisualStyleBackColor = true;
            this.cb_Partition7.CheckedChanged += new System.EventHandler(this.cb_Partition_CheckedChanged);
            // 
            // cb_Partition6
            // 
            this.cb_Partition6.AutoSize = true;
            this.cb_Partition6.Location = new System.Drawing.Point(14, 71);
            this.cb_Partition6.Name = "cb_Partition6";
            this.cb_Partition6.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition6.TabIndex = 6;
            this.cb_Partition6.Text = "6 分区";
            this.cb_Partition6.UseVisualStyleBackColor = true;
            this.cb_Partition6.CheckedChanged += new System.EventHandler(this.cb_Partition_CheckedChanged);
            // 
            // cb_Partition5
            // 
            this.cb_Partition5.AutoSize = true;
            this.cb_Partition5.Location = new System.Drawing.Point(358, 44);
            this.cb_Partition5.Name = "cb_Partition5";
            this.cb_Partition5.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition5.TabIndex = 5;
            this.cb_Partition5.Text = "5 分区";
            this.cb_Partition5.UseVisualStyleBackColor = true;
            this.cb_Partition5.CheckedChanged += new System.EventHandler(this.cb_Partition_CheckedChanged);
            // 
            // cb_Partition4
            // 
            this.cb_Partition4.AutoSize = true;
            this.cb_Partition4.Location = new System.Drawing.Point(272, 44);
            this.cb_Partition4.Name = "cb_Partition4";
            this.cb_Partition4.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition4.TabIndex = 4;
            this.cb_Partition4.Text = "4 分区";
            this.cb_Partition4.UseVisualStyleBackColor = true;
            this.cb_Partition4.CheckedChanged += new System.EventHandler(this.cb_Partition_CheckedChanged);
            // 
            // cb_Partition3
            // 
            this.cb_Partition3.AutoSize = true;
            this.cb_Partition3.Location = new System.Drawing.Point(186, 44);
            this.cb_Partition3.Name = "cb_Partition3";
            this.cb_Partition3.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition3.TabIndex = 3;
            this.cb_Partition3.Text = "3 分区";
            this.cb_Partition3.UseVisualStyleBackColor = true;
            this.cb_Partition3.CheckedChanged += new System.EventHandler(this.cb_Partition_CheckedChanged);
            // 
            // cb_Partition2
            // 
            this.cb_Partition2.AutoSize = true;
            this.cb_Partition2.Location = new System.Drawing.Point(100, 44);
            this.cb_Partition2.Name = "cb_Partition2";
            this.cb_Partition2.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition2.TabIndex = 2;
            this.cb_Partition2.Text = "2 分区";
            this.cb_Partition2.UseVisualStyleBackColor = true;
            this.cb_Partition2.CheckedChanged += new System.EventHandler(this.cb_Partition_CheckedChanged);
            // 
            // cb_Partition1
            // 
            this.cb_Partition1.AutoSize = true;
            this.cb_Partition1.Location = new System.Drawing.Point(14, 44);
            this.cb_Partition1.Name = "cb_Partition1";
            this.cb_Partition1.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition1.TabIndex = 1;
            this.cb_Partition1.Text = "1 分区";
            this.cb_Partition1.UseVisualStyleBackColor = true;
            this.cb_Partition1.CheckedChanged += new System.EventHandler(this.cb_Partition_CheckedChanged);
            // 
            // cb_AllSelected
            // 
            this.cb_AllSelected.AutoSize = true;
            this.cb_AllSelected.Location = new System.Drawing.Point(14, 12);
            this.cb_AllSelected.Name = "cb_AllSelected";
            this.cb_AllSelected.Size = new System.Drawing.Size(87, 21);
            this.cb_AllSelected.TabIndex = 0;
            this.cb_AllSelected.Text = "全选或反选";
            this.cb_AllSelected.UseVisualStyleBackColor = true;
            this.cb_AllSelected.CheckedChanged += new System.EventHandler(this.cb_AllSelected_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(180, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "选择车场分区";
            // 
            // btn_Canel
            // 
            this.btn_Canel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Canel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Canel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Canel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Canel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Canel.DownBack = null;
            this.btn_Canel.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Canel.FadeGlow = false;
            this.btn_Canel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Canel.ForeColor = System.Drawing.Color.White;
            this.btn_Canel.IsDrawBorder = false;
            this.btn_Canel.IsDrawGlass = false;
            this.btn_Canel.Location = new System.Drawing.Point(360, 323);
            this.btn_Canel.MouseBack = null;
            this.btn_Canel.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Canel.Name = "btn_Canel";
            this.btn_Canel.NormlBack = null;
            this.btn_Canel.Size = new System.Drawing.Size(100, 35);
            this.btn_Canel.TabIndex = 26;
            this.btn_Canel.TabStop = false;
            this.btn_Canel.Text = "取 消";
            this.btn_Canel.UseVisualStyleBackColor = false;
            this.btn_Canel.Click += new System.EventHandler(this.btn_Canel_Click);
            // 
            // btn_Enter
            // 
            this.btn_Enter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btn_Enter.Location = new System.Drawing.Point(254, 323);
            this.btn_Enter.MouseBack = null;
            this.btn_Enter.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.NormlBack = null;
            this.btn_Enter.Size = new System.Drawing.Size(100, 35);
            this.btn_Enter.TabIndex = 25;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // RegisterParameter
            // 
            this.AcceptButton = this.btn_Enter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btn_Canel;
            this.ClientSize = new System.Drawing.Size(472, 370);
            this.Controls.Add(this.btn_Canel);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.p_CardPartition);
            this.Controls.Add(this.cb_CardPartition);
            this.Controls.Add(this.l_CardPartition);
            this.Controls.Add(this.t_CardTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_CardDistance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.p_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegisterParameter";
            this.Text = "批量发行参数";
            this.p_Title.ResumeLayout(false);
            this.p_CardPartition.ResumeLayout(false);
            this.p_CardPartition.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_Title;
        private System.Windows.Forms.Label l_Title;
        private CCWin.SkinControl.SkinButton btn_Close;
        private System.Windows.Forms.ComboBox cb_CardPartition;
        private System.Windows.Forms.Label l_CardPartition;
        private System.Windows.Forms.DateTimePicker t_CardTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_CardDistance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel p_CardPartition;
        private System.Windows.Forms.CheckBox cb_Partition16;
        private System.Windows.Forms.CheckBox cb_Partition15;
        private System.Windows.Forms.CheckBox cb_Partition14;
        private System.Windows.Forms.CheckBox cb_Partition13;
        private System.Windows.Forms.CheckBox cb_Partition12;
        private System.Windows.Forms.CheckBox cb_Partition11;
        private System.Windows.Forms.CheckBox cb_Partition10;
        private System.Windows.Forms.CheckBox cb_Partition9;
        private System.Windows.Forms.CheckBox cb_Partition8;
        private System.Windows.Forms.CheckBox cb_Partition7;
        private System.Windows.Forms.CheckBox cb_Partition6;
        private System.Windows.Forms.CheckBox cb_Partition5;
        private System.Windows.Forms.CheckBox cb_Partition4;
        private System.Windows.Forms.CheckBox cb_Partition3;
        private System.Windows.Forms.CheckBox cb_Partition2;
        private System.Windows.Forms.CheckBox cb_Partition1;
        private System.Windows.Forms.CheckBox cb_AllSelected;
        private System.Windows.Forms.Label label7;
        private CCWin.SkinControl.SkinButton btn_Canel;
        private CCWin.SkinControl.SkinButton btn_Enter;
    }
}