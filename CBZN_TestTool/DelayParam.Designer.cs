namespace CBZN_TestTool
{
    partial class DelayParam
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
            this.p_Title = new System.Windows.Forms.Panel();
            this.btn_Close = new CCWin.SkinControl.SkinButton();
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
            this.cb_CardPartition = new System.Windows.Forms.ComboBox();
            this.l_CardPartition = new System.Windows.Forms.Label();
            this.ud_DelayValue = new System.Windows.Forms.NumericUpDown();
            this.l_DelayValueTitle = new System.Windows.Forms.Label();
            this.cb_DelaySelected = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.t_NewTime = new System.Windows.Forms.DateTimePicker();
            this.t_OldTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.p_Title.SuspendLayout();
            this.p_CardPartition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_DelayValue)).BeginInit();
            this.SuspendLayout();
            // 
            // p_Title
            // 
            this.p_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.p_Title.Controls.Add(this.btn_Close);
            this.p_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Title.Location = new System.Drawing.Point(1, 1);
            this.p_Title.Name = "p_Title";
            this.p_Title.Size = new System.Drawing.Size(548, 40);
            this.p_Title.TabIndex = 6;
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
            this.btn_Close.Location = new System.Drawing.Point(502, 0);
            this.btn_Close.MouseBack = global::CBZN_TestTool.Properties.Resources.HoverClose;
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.NormlBack = global::CBZN_TestTool.Properties.Resources.NoneClose;
            this.btn_Close.Size = new System.Drawing.Size(46, 31);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.TabStop = false;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
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
            this.p_CardPartition.Location = new System.Drawing.Point(30, 186);
            this.p_CardPartition.Name = "p_CardPartition";
            this.p_CardPartition.Size = new System.Drawing.Size(491, 155);
            this.p_CardPartition.TabIndex = 38;
            this.p_CardPartition.Paint += new System.Windows.Forms.PaintEventHandler(this.p_CardPartition_Paint);
            // 
            // cb_Partition16
            // 
            this.cb_Partition16.AutoSize = true;
            this.cb_Partition16.Location = new System.Drawing.Point(39, 125);
            this.cb_Partition16.Name = "cb_Partition16";
            this.cb_Partition16.Size = new System.Drawing.Size(69, 21);
            this.cb_Partition16.TabIndex = 16;
            this.cb_Partition16.Text = "16 分区";
            this.cb_Partition16.UseVisualStyleBackColor = true;
            this.cb_Partition16.CheckedChanged += new System.EventHandler(this.PartitionSelected);
            // 
            // cb_Partition15
            // 
            this.cb_Partition15.AutoSize = true;
            this.cb_Partition15.Location = new System.Drawing.Point(383, 98);
            this.cb_Partition15.Name = "cb_Partition15";
            this.cb_Partition15.Size = new System.Drawing.Size(69, 21);
            this.cb_Partition15.TabIndex = 15;
            this.cb_Partition15.Text = "15 分区";
            this.cb_Partition15.UseVisualStyleBackColor = true;
            this.cb_Partition15.CheckedChanged += new System.EventHandler(this.PartitionSelected);
            // 
            // cb_Partition14
            // 
            this.cb_Partition14.AutoSize = true;
            this.cb_Partition14.Location = new System.Drawing.Point(297, 98);
            this.cb_Partition14.Name = "cb_Partition14";
            this.cb_Partition14.Size = new System.Drawing.Size(69, 21);
            this.cb_Partition14.TabIndex = 14;
            this.cb_Partition14.Text = "14 分区";
            this.cb_Partition14.UseVisualStyleBackColor = true;
            this.cb_Partition14.CheckedChanged += new System.EventHandler(this.PartitionSelected);
            // 
            // cb_Partition13
            // 
            this.cb_Partition13.AutoSize = true;
            this.cb_Partition13.Location = new System.Drawing.Point(211, 98);
            this.cb_Partition13.Name = "cb_Partition13";
            this.cb_Partition13.Size = new System.Drawing.Size(69, 21);
            this.cb_Partition13.TabIndex = 13;
            this.cb_Partition13.Text = "13 分区";
            this.cb_Partition13.UseVisualStyleBackColor = true;
            this.cb_Partition13.CheckedChanged += new System.EventHandler(this.PartitionSelected);
            // 
            // cb_Partition12
            // 
            this.cb_Partition12.AutoSize = true;
            this.cb_Partition12.Location = new System.Drawing.Point(125, 98);
            this.cb_Partition12.Name = "cb_Partition12";
            this.cb_Partition12.Size = new System.Drawing.Size(69, 21);
            this.cb_Partition12.TabIndex = 12;
            this.cb_Partition12.Text = "12 分区";
            this.cb_Partition12.UseVisualStyleBackColor = true;
            this.cb_Partition12.CheckedChanged += new System.EventHandler(this.PartitionSelected);
            // 
            // cb_Partition11
            // 
            this.cb_Partition11.AutoSize = true;
            this.cb_Partition11.Location = new System.Drawing.Point(39, 98);
            this.cb_Partition11.Name = "cb_Partition11";
            this.cb_Partition11.Size = new System.Drawing.Size(69, 21);
            this.cb_Partition11.TabIndex = 11;
            this.cb_Partition11.Text = "11 分区";
            this.cb_Partition11.UseVisualStyleBackColor = true;
            this.cb_Partition11.CheckedChanged += new System.EventHandler(this.PartitionSelected);
            // 
            // cb_Partition10
            // 
            this.cb_Partition10.AutoSize = true;
            this.cb_Partition10.Location = new System.Drawing.Point(383, 71);
            this.cb_Partition10.Name = "cb_Partition10";
            this.cb_Partition10.Size = new System.Drawing.Size(69, 21);
            this.cb_Partition10.TabIndex = 10;
            this.cb_Partition10.Text = "10 分区";
            this.cb_Partition10.UseVisualStyleBackColor = true;
            this.cb_Partition10.CheckedChanged += new System.EventHandler(this.PartitionSelected);
            // 
            // cb_Partition9
            // 
            this.cb_Partition9.AutoSize = true;
            this.cb_Partition9.Location = new System.Drawing.Point(297, 71);
            this.cb_Partition9.Name = "cb_Partition9";
            this.cb_Partition9.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition9.TabIndex = 9;
            this.cb_Partition9.Text = "9 分区";
            this.cb_Partition9.UseVisualStyleBackColor = true;
            this.cb_Partition9.CheckedChanged += new System.EventHandler(this.PartitionSelected);
            // 
            // cb_Partition8
            // 
            this.cb_Partition8.AutoSize = true;
            this.cb_Partition8.Location = new System.Drawing.Point(211, 71);
            this.cb_Partition8.Name = "cb_Partition8";
            this.cb_Partition8.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition8.TabIndex = 8;
            this.cb_Partition8.Text = "8 分区";
            this.cb_Partition8.UseVisualStyleBackColor = true;
            this.cb_Partition8.CheckedChanged += new System.EventHandler(this.PartitionSelected);
            // 
            // cb_Partition7
            // 
            this.cb_Partition7.AutoSize = true;
            this.cb_Partition7.Location = new System.Drawing.Point(125, 71);
            this.cb_Partition7.Name = "cb_Partition7";
            this.cb_Partition7.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition7.TabIndex = 7;
            this.cb_Partition7.Text = "7 分区";
            this.cb_Partition7.UseVisualStyleBackColor = true;
            this.cb_Partition7.CheckedChanged += new System.EventHandler(this.PartitionSelected);
            // 
            // cb_Partition6
            // 
            this.cb_Partition6.AutoSize = true;
            this.cb_Partition6.Location = new System.Drawing.Point(39, 71);
            this.cb_Partition6.Name = "cb_Partition6";
            this.cb_Partition6.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition6.TabIndex = 6;
            this.cb_Partition6.Text = "6 分区";
            this.cb_Partition6.UseVisualStyleBackColor = true;
            this.cb_Partition6.CheckedChanged += new System.EventHandler(this.PartitionSelected);
            // 
            // cb_Partition5
            // 
            this.cb_Partition5.AutoSize = true;
            this.cb_Partition5.Location = new System.Drawing.Point(383, 44);
            this.cb_Partition5.Name = "cb_Partition5";
            this.cb_Partition5.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition5.TabIndex = 5;
            this.cb_Partition5.Text = "5 分区";
            this.cb_Partition5.UseVisualStyleBackColor = true;
            this.cb_Partition5.CheckedChanged += new System.EventHandler(this.PartitionSelected);
            // 
            // cb_Partition4
            // 
            this.cb_Partition4.AutoSize = true;
            this.cb_Partition4.Location = new System.Drawing.Point(297, 44);
            this.cb_Partition4.Name = "cb_Partition4";
            this.cb_Partition4.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition4.TabIndex = 4;
            this.cb_Partition4.Text = "4 分区";
            this.cb_Partition4.UseVisualStyleBackColor = true;
            this.cb_Partition4.CheckedChanged += new System.EventHandler(this.PartitionSelected);
            // 
            // cb_Partition3
            // 
            this.cb_Partition3.AutoSize = true;
            this.cb_Partition3.Location = new System.Drawing.Point(211, 44);
            this.cb_Partition3.Name = "cb_Partition3";
            this.cb_Partition3.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition3.TabIndex = 3;
            this.cb_Partition3.Text = "3 分区";
            this.cb_Partition3.UseVisualStyleBackColor = true;
            this.cb_Partition3.CheckedChanged += new System.EventHandler(this.PartitionSelected);
            // 
            // cb_Partition2
            // 
            this.cb_Partition2.AutoSize = true;
            this.cb_Partition2.Location = new System.Drawing.Point(125, 44);
            this.cb_Partition2.Name = "cb_Partition2";
            this.cb_Partition2.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition2.TabIndex = 2;
            this.cb_Partition2.Text = "2 分区";
            this.cb_Partition2.UseVisualStyleBackColor = true;
            this.cb_Partition2.CheckedChanged += new System.EventHandler(this.PartitionSelected);
            // 
            // cb_Partition1
            // 
            this.cb_Partition1.AutoSize = true;
            this.cb_Partition1.Location = new System.Drawing.Point(39, 44);
            this.cb_Partition1.Name = "cb_Partition1";
            this.cb_Partition1.Size = new System.Drawing.Size(62, 21);
            this.cb_Partition1.TabIndex = 1;
            this.cb_Partition1.Text = "1 分区";
            this.cb_Partition1.UseVisualStyleBackColor = true;
            this.cb_Partition1.CheckedChanged += new System.EventHandler(this.PartitionSelected);
            // 
            // cb_AllSelected
            // 
            this.cb_AllSelected.AutoSize = true;
            this.cb_AllSelected.Location = new System.Drawing.Point(39, 11);
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
            // cb_CardPartition
            // 
            this.cb_CardPartition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CardPartition.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_CardPartition.FormattingEnabled = true;
            this.cb_CardPartition.Items.AddRange(new object[] {
            "关闭",
            "开启"});
            this.cb_CardPartition.Location = new System.Drawing.Point(107, 146);
            this.cb_CardPartition.Name = "cb_CardPartition";
            this.cb_CardPartition.Size = new System.Drawing.Size(150, 28);
            this.cb_CardPartition.TabIndex = 3;
            this.cb_CardPartition.SelectedIndexChanged += new System.EventHandler(this.cb_CardPartition_SelectedIndexChanged);
            // 
            // l_CardPartition
            // 
            this.l_CardPartition.AutoSize = true;
            this.l_CardPartition.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_CardPartition.Location = new System.Drawing.Point(34, 152);
            this.l_CardPartition.Name = "l_CardPartition";
            this.l_CardPartition.Size = new System.Drawing.Size(68, 17);
            this.l_CardPartition.TabIndex = 37;
            this.l_CardPartition.Text = "车场分区：";
            // 
            // ud_DelayValue
            // 
            this.ud_DelayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ud_DelayValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ud_DelayValue.Location = new System.Drawing.Point(371, 102);
            this.ud_DelayValue.Maximum = new decimal(new int[] {
            356,
            0,
            0,
            0});
            this.ud_DelayValue.Minimum = new decimal(new int[] {
            356,
            0,
            0,
            -2147483648});
            this.ud_DelayValue.Name = "ud_DelayValue";
            this.ud_DelayValue.Size = new System.Drawing.Size(150, 26);
            this.ud_DelayValue.TabIndex = 1;
            this.ud_DelayValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ud_DelayValue.ValueChanged += new System.EventHandler(this.ud_DelayValue_ValueChanged);
            // 
            // l_DelayValueTitle
            // 
            this.l_DelayValueTitle.AutoSize = true;
            this.l_DelayValueTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_DelayValueTitle.Location = new System.Drawing.Point(298, 107);
            this.l_DelayValueTitle.Name = "l_DelayValueTitle";
            this.l_DelayValueTitle.Size = new System.Drawing.Size(68, 17);
            this.l_DelayValueTitle.TabIndex = 34;
            this.l_DelayValueTitle.Text = "延期次数：";
            // 
            // cb_DelaySelected
            // 
            this.cb_DelaySelected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_DelaySelected.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_DelaySelected.FormattingEnabled = true;
            this.cb_DelaySelected.Items.AddRange(new object[] {
            "按 天 延期",
            "按 月 延期",
            "按 季 延期",
            "按 年 延期"});
            this.cb_DelaySelected.Location = new System.Drawing.Point(371, 59);
            this.cb_DelaySelected.Name = "cb_DelaySelected";
            this.cb_DelaySelected.Size = new System.Drawing.Size(150, 28);
            this.cb_DelaySelected.TabIndex = 0;
            this.cb_DelaySelected.SelectedIndexChanged += new System.EventHandler(this.cb_DelaySelected_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(298, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "延期方式：";
            // 
            // t_NewTime
            // 
            this.t_NewTime.CustomFormat = "yyyy年MM月dd日";
            this.t_NewTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_NewTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.t_NewTime.Location = new System.Drawing.Point(107, 102);
            this.t_NewTime.Name = "t_NewTime";
            this.t_NewTime.Size = new System.Drawing.Size(150, 26);
            this.t_NewTime.TabIndex = 2;
            // 
            // t_OldTime
            // 
            this.t_OldTime.CustomFormat = "yyyy年MM月dd日";
            this.t_OldTime.Enabled = false;
            this.t_OldTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_OldTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.t_OldTime.Location = new System.Drawing.Point(107, 59);
            this.t_OldTime.Name = "t_OldTime";
            this.t_OldTime.Size = new System.Drawing.Size(150, 26);
            this.t_OldTime.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(34, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "延期期限：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(34, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "当前期限：";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(431, 352);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(90, 33);
            this.btn_Cancel.TabIndex = 40;
            this.btn_Cancel.TabStop = false;
            this.btn_Cancel.Text = "取 消";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Enter
            // 
            this.btn_Enter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Enter.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Enter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Enter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Enter.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Enter.ForeColor = System.Drawing.Color.White;
            this.btn_Enter.Location = new System.Drawing.Point(335, 352);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(90, 33);
            this.btn_Enter.TabIndex = 39;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // DelayParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 395);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.p_CardPartition);
            this.Controls.Add(this.cb_CardPartition);
            this.Controls.Add(this.l_CardPartition);
            this.Controls.Add(this.ud_DelayValue);
            this.Controls.Add(this.l_DelayValueTitle);
            this.Controls.Add(this.cb_DelaySelected);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.t_NewTime);
            this.Controls.Add(this.t_OldTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.p_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DelayParam";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "定距卡延期";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DelayParam_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DelayParam_FormClosed);
            this.Load += new System.EventHandler(this.DelayParam_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SingleCardDelay_Paint);
            this.Resize += new System.EventHandler(this.DelayParam_Resize);
            this.p_Title.ResumeLayout(false);
            this.p_CardPartition.ResumeLayout(false);
            this.p_CardPartition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_DelayValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_Title;
        private CCWin.SkinControl.SkinButton btn_Close;
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
        private System.Windows.Forms.ComboBox cb_CardPartition;
        private System.Windows.Forms.Label l_CardPartition;
        private System.Windows.Forms.NumericUpDown ud_DelayValue;
        private System.Windows.Forms.Label l_DelayValueTitle;
        private System.Windows.Forms.ComboBox cb_DelaySelected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker t_NewTime;
        private System.Windows.Forms.DateTimePicker t_OldTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Enter;
    }
}