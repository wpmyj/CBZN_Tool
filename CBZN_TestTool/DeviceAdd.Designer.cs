namespace CBZN_TestTool
{
    partial class DeviceAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceAdd));
            this.p_Title = new System.Windows.Forms.Panel();
            this.btn_Close = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ud_HostNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_IOMouth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_CameraDetection = new System.Windows.Forms.ComboBox();
            this.ud_WirelessNumber = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_CardReadDistance = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_OpenModel = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ud_FrequencyOffset = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_Partition = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_SAPBF = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_ReadCardDelay = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cb_Detection = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cb_Language = new System.Windows.Forms.ComboBox();
            this.btn_Cancel = new CCWin.SkinControl.SkinButton();
            this.btn_Enter = new CCWin.SkinControl.SkinButton();
            this.cb_Adds = new System.Windows.Forms.CheckBox();
            this.ud_BrakeNumber = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_FuzzyQuery = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.p_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_HostNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_WirelessNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_FrequencyOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_BrakeNumber)).BeginInit();
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
            this.p_Title.Size = new System.Drawing.Size(498, 40);
            this.p_Title.TabIndex = 3;
            this.p_Title.Paint += new System.Windows.Forms.PaintEventHandler(this.p_Title_Paint);
            this.p_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.p_Title_MouseDown);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Close.DownBack = global::CBZN_TestTool.Properties.Resources.DownClose;
            this.btn_Close.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btn_Close.Location = new System.Drawing.Point(452, 0);
            this.btn_Close.MouseBack = global::CBZN_TestTool.Properties.Resources.HoverClose;
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.NormlBack = global::CBZN_TestTool.Properties.Resources.NoneClose;
            this.btn_Close.Size = new System.Drawing.Size(46, 31);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "主机编号：";
            // 
            // ud_HostNumber
            // 
            this.ud_HostNumber.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ud_HostNumber.Location = new System.Drawing.Point(103, 55);
            this.ud_HostNumber.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.ud_HostNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ud_HostNumber.Name = "ud_HostNumber";
            this.ud_HostNumber.Size = new System.Drawing.Size(120, 26);
            this.ud_HostNumber.TabIndex = 5;
            this.ud_HostNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(27, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "进 出 口：";
            // 
            // cb_IOMouth
            // 
            this.cb_IOMouth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_IOMouth.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_IOMouth.FormattingEnabled = true;
            this.cb_IOMouth.Items.AddRange(new object[] {
            "入口",
            "出口"});
            this.cb_IOMouth.Location = new System.Drawing.Point(103, 100);
            this.cb_IOMouth.Name = "cb_IOMouth";
            this.cb_IOMouth.Size = new System.Drawing.Size(121, 28);
            this.cb_IOMouth.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(21, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "车牌识别：";
            // 
            // cb_CameraDetection
            // 
            this.cb_CameraDetection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CameraDetection.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_CameraDetection.FormattingEnabled = true;
            this.cb_CameraDetection.Items.AddRange(new object[] {
            "关闭",
            "开启"});
            this.cb_CameraDetection.Location = new System.Drawing.Point(103, 150);
            this.cb_CameraDetection.Name = "cb_CameraDetection";
            this.cb_CameraDetection.Size = new System.Drawing.Size(121, 28);
            this.cb_CameraDetection.TabIndex = 7;
            this.cb_CameraDetection.SelectedIndexChanged += new System.EventHandler(this.cb_CameraDetection_SelectedIndexChanged);
            // 
            // ud_WirelessNumber
            // 
            this.ud_WirelessNumber.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ud_WirelessNumber.Location = new System.Drawing.Point(103, 200);
            this.ud_WirelessNumber.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.ud_WirelessNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ud_WirelessNumber.Name = "ud_WirelessNumber";
            this.ud_WirelessNumber.Size = new System.Drawing.Size(120, 26);
            this.ud_WirelessNumber.TabIndex = 8;
            this.ud_WirelessNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(30, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "像机 ID：";
            // 
            // cb_CardReadDistance
            // 
            this.cb_CardReadDistance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CardReadDistance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_CardReadDistance.FormattingEnabled = true;
            this.cb_CardReadDistance.Items.AddRange(new object[] {
            "1.2 米",
            "2.5 米",
            "3.8 米",
            "5 米"});
            this.cb_CardReadDistance.Location = new System.Drawing.Point(355, 55);
            this.cb_CardReadDistance.Name = "cb_CardReadDistance";
            this.cb_CardReadDistance.Size = new System.Drawing.Size(121, 28);
            this.cb_CardReadDistance.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(273, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "读卡距离：";
            // 
            // cb_OpenModel
            // 
            this.cb_OpenModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_OpenModel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_OpenModel.FormattingEnabled = true;
            this.cb_OpenModel.Items.AddRange(new object[] {
            "畅泊：串口开闸",
            "畅泊：无线开闸",
            "学习控制器开闸",
            "继电器开闸"});
            this.cb_OpenModel.Location = new System.Drawing.Point(355, 100);
            this.cb_OpenModel.Name = "cb_OpenModel";
            this.cb_OpenModel.Size = new System.Drawing.Size(121, 28);
            this.cb_OpenModel.TabIndex = 17;
            this.cb_OpenModel.SelectedIndexChanged += new System.EventHandler(this.cb_OpenModel_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(273, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "开闸模式：";
            // 
            // ud_FrequencyOffset
            // 
            this.ud_FrequencyOffset.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ud_FrequencyOffset.Location = new System.Drawing.Point(103, 250);
            this.ud_FrequencyOffset.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.ud_FrequencyOffset.Name = "ud_FrequencyOffset";
            this.ud_FrequencyOffset.Size = new System.Drawing.Size(120, 26);
            this.ud_FrequencyOffset.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(21, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "频率偏移：";
            // 
            // cb_Partition
            // 
            this.cb_Partition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Partition.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Partition.FormattingEnabled = true;
            this.cb_Partition.Items.AddRange(new object[] {
            "关闭",
            "1 分区",
            "2 分区",
            "3 分区",
            "4 分区",
            "5 分区",
            "6 分区",
            "7 分区",
            "8 分区",
            "10 分区",
            "11 分区",
            "12 分区",
            "13 分区",
            "14 分区",
            "15 分区",
            "16 分区"});
            this.cb_Partition.Location = new System.Drawing.Point(103, 300);
            this.cb_Partition.Name = "cb_Partition";
            this.cb_Partition.Size = new System.Drawing.Size(121, 28);
            this.cb_Partition.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(27, 305);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "场 分 区：";
            // 
            // cb_SAPBF
            // 
            this.cb_SAPBF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SAPBF.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_SAPBF.FormattingEnabled = true;
            this.cb_SAPBF.Items.AddRange(new object[] {
            "关闭",
            "开启"});
            this.cb_SAPBF.Location = new System.Drawing.Point(103, 350);
            this.cb_SAPBF.Name = "cb_SAPBF";
            this.cb_SAPBF.Size = new System.Drawing.Size(121, 28);
            this.cb_SAPBF.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(27, 355);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 20);
            this.label11.TabIndex = 22;
            this.label11.Text = "防 潜 回：";
            // 
            // cb_ReadCardDelay
            // 
            this.cb_ReadCardDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ReadCardDelay.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_ReadCardDelay.FormattingEnabled = true;
            this.cb_ReadCardDelay.Items.AddRange(new object[] {
            "1 秒",
            "5 秒",
            "10 秒",
            "20 秒",
            "40 秒",
            "80 秒",
            "160 秒",
            "320 秒"});
            this.cb_ReadCardDelay.Location = new System.Drawing.Point(356, 199);
            this.cb_ReadCardDelay.Name = "cb_ReadCardDelay";
            this.cb_ReadCardDelay.Size = new System.Drawing.Size(121, 28);
            this.cb_ReadCardDelay.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(274, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "读卡延迟：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(273, 254);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 20);
            this.label13.TabIndex = 24;
            this.label13.Text = "离开车辆：";
            // 
            // cb_Detection
            // 
            this.cb_Detection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Detection.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Detection.FormattingEnabled = true;
            this.cb_Detection.Items.AddRange(new object[] {
            "关闭",
            "开启"});
            this.cb_Detection.Location = new System.Drawing.Point(355, 249);
            this.cb_Detection.Name = "cb_Detection";
            this.cb_Detection.Size = new System.Drawing.Size(121, 28);
            this.cb_Detection.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(273, 304);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 20);
            this.label14.TabIndex = 24;
            this.label14.Text = "语言种类：";
            // 
            // cb_Language
            // 
            this.cb_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Language.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Language.FormattingEnabled = true;
            this.cb_Language.Items.AddRange(new object[] {
            "普通话",
            "东北话",
            "四川话",
            "河南话",
            "陕西话"});
            this.cb_Language.Location = new System.Drawing.Point(355, 299);
            this.cb_Language.Name = "cb_Language";
            this.cb_Language.Size = new System.Drawing.Size(121, 28);
            this.cb_Language.TabIndex = 25;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Cancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.DownBack = null;
            this.btn_Cancel.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Cancel.FadeGlow = false;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.IsDrawBorder = false;
            this.btn_Cancel.IsDrawGlass = false;
            this.btn_Cancel.IsEnabledDraw = false;
            this.btn_Cancel.Location = new System.Drawing.Point(375, 395);
            this.btn_Cancel.MouseBack = null;
            this.btn_Cancel.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.NormlBack = null;
            this.btn_Cancel.Size = new System.Drawing.Size(100, 35);
            this.btn_Cancel.TabIndex = 26;
            this.btn_Cancel.TabStop = false;
            this.btn_Cancel.Text = "取 消";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Enter
            // 
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
            this.btn_Enter.IsEnabledDraw = false;
            this.btn_Enter.Location = new System.Drawing.Point(269, 395);
            this.btn_Enter.MouseBack = null;
            this.btn_Enter.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.NormlBack = null;
            this.btn_Enter.Size = new System.Drawing.Size(100, 35);
            this.btn_Enter.TabIndex = 26;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "添 加";
            this.btn_Enter.UseVisualStyleBackColor = false;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // cb_Adds
            // 
            this.cb_Adds.AutoSize = true;
            this.cb_Adds.Location = new System.Drawing.Point(181, 408);
            this.cb_Adds.Name = "cb_Adds";
            this.cb_Adds.Size = new System.Drawing.Size(72, 16);
            this.cb_Adds.TabIndex = 27;
            this.cb_Adds.Text = "多次添加";
            this.cb_Adds.UseVisualStyleBackColor = true;
            // 
            // ud_BrakeNumber
            // 
            this.ud_BrakeNumber.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ud_BrakeNumber.Location = new System.Drawing.Point(355, 150);
            this.ud_BrakeNumber.Maximum = new decimal(new int[] {
            16777215,
            0,
            0,
            0});
            this.ud_BrakeNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ud_BrakeNumber.Name = "ud_BrakeNumber";
            this.ud_BrakeNumber.Size = new System.Drawing.Size(120, 26);
            this.ud_BrakeNumber.TabIndex = 28;
            this.ud_BrakeNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(282, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "道闸 ID：";
            // 
            // cb_FuzzyQuery
            // 
            this.cb_FuzzyQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FuzzyQuery.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_FuzzyQuery.FormattingEnabled = true;
            this.cb_FuzzyQuery.Items.AddRange(new object[] {
            "关闭",
            "1",
            "2"});
            this.cb_FuzzyQuery.Location = new System.Drawing.Point(355, 350);
            this.cb_FuzzyQuery.Name = "cb_FuzzyQuery";
            this.cb_FuzzyQuery.Size = new System.Drawing.Size(121, 28);
            this.cb_FuzzyQuery.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(245, 355);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "模糊查询位数：";
            // 
            // DeviceAdd
            // 
            this.AcceptButton = this.btn_Enter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(500, 445);
            this.Controls.Add(this.cb_FuzzyQuery);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ud_BrakeNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_Adds);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.cb_Language);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cb_Detection);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cb_ReadCardDelay);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cb_SAPBF);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cb_Partition);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ud_FrequencyOffset);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cb_OpenModel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cb_CardReadDistance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ud_WirelessNumber);
            this.Controls.Add(this.cb_CameraDetection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_IOMouth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ud_HostNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.p_Title);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceAdd";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "添加编录";
            this.Load += new System.EventHandler(this.DeviceAdd_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DeviceAdd_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DeviceAdd_KeyUp);
            this.p_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ud_HostNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_WirelessNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_FrequencyOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_BrakeNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_Title;
        private CCWin.SkinControl.SkinButton btn_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ud_HostNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_IOMouth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_CameraDetection;
        private System.Windows.Forms.NumericUpDown ud_WirelessNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_CardReadDistance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_OpenModel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown ud_FrequencyOffset;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_Partition;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cb_SAPBF;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cb_ReadCardDelay;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cb_Detection;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cb_Language;
        private CCWin.SkinControl.SkinButton btn_Cancel;
        private CCWin.SkinControl.SkinButton btn_Enter;
        private System.Windows.Forms.CheckBox cb_Adds;
        private System.Windows.Forms.NumericUpDown ud_BrakeNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_FuzzyQuery;
        private System.Windows.Forms.Label label6;
    }
}