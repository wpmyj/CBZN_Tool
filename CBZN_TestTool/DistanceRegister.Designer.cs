﻿using System;

namespace CBZN_TestTool
{
    partial class DistanceRegister
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistanceRegister));
            this.p_Title = new System.Windows.Forms.Panel();
            this.btn_Close = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_CardNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_CardType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_CardDistance = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.t_CardTime = new System.Windows.Forms.DateTimePicker();
            this.l_ParkingRestrictions = new System.Windows.Forms.Label();
            this.cb_ParkingRestrictions = new System.Windows.Forms.ComboBox();
            this.cb_CardPartition = new System.Windows.Forms.ComboBox();
            this.l_CardPartition = new System.Windows.Forms.Label();
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
            this.btn_Enter = new NewControl.NewButton();
            this.btn_Canel = new NewControl.NewButton();
            this.p_Bundled = new System.Windows.Forms.Panel();
            this.btn_Add = new NewControl.NewButton();
            this.btn_Remove = new NewControl.NewButton();
            this.cb_AllSelectedBundled = new System.Windows.Forms.CheckBox();
            this.dgv_BundledList = new System.Windows.Forms.DataGridView();
            this.c_selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_LockState = new System.Windows.Forms.DataGridViewImageColumn();
            this.c_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.p_Title.SuspendLayout();
            this.p_CardPartition.SuspendLayout();
            this.p_Bundled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BundledList)).BeginInit();
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
            this.p_Title.Size = new System.Drawing.Size(478, 40);
            this.p_Title.TabIndex = 4;
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
            this.btn_Close.Location = new System.Drawing.Point(432, 0);
            this.btn_Close.MouseBack = global::CBZN_TestTool.Properties.Resources.HoverClose;
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.NormlBack = global::CBZN_TestTool.Properties.Resources.NoneClose;
            this.btn_Close.Size = new System.Drawing.Size(46, 31);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.TabStop = false;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "卡片编号：";
            // 
            // tb_CardNumber
            // 
            this.tb_CardNumber.Enabled = false;
            this.tb_CardNumber.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_CardNumber.Location = new System.Drawing.Point(94, 55);
            this.tb_CardNumber.Name = "tb_CardNumber";
            this.tb_CardNumber.Size = new System.Drawing.Size(130, 26);
            this.tb_CardNumber.TabIndex = 0;
            this.tb_CardNumber.Text = "12345678";
            this.tb_CardNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(21, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "卡片类型：";
            // 
            // cb_CardType
            // 
            this.cb_CardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CardType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_CardType.FormattingEnabled = true;
            this.cb_CardType.Items.AddRange(new object[] {
            "单卡",
            "组合卡",
            "车牌识别卡"});
            this.cb_CardType.Location = new System.Drawing.Point(94, 160);
            this.cb_CardType.Name = "cb_CardType";
            this.cb_CardType.Size = new System.Drawing.Size(130, 28);
            this.cb_CardType.TabIndex = 1;
            this.cb_CardType.SelectedIndexChanged += new System.EventHandler(this.cb_CardType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(21, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "读写距离：";
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
            this.cb_CardDistance.Location = new System.Drawing.Point(94, 105);
            this.cb_CardDistance.Name = "cb_CardDistance";
            this.cb_CardDistance.Size = new System.Drawing.Size(130, 28);
            this.cb_CardDistance.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(257, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "有效期限：";
            // 
            // t_CardTime
            // 
            this.t_CardTime.CustomFormat = "yyyy年MM月dd日";
            this.t_CardTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_CardTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.t_CardTime.Location = new System.Drawing.Point(330, 55);
            this.t_CardTime.Name = "t_CardTime";
            this.t_CardTime.Size = new System.Drawing.Size(130, 26);
            this.t_CardTime.TabIndex = 2;
            // 
            // l_ParkingRestrictions
            // 
            this.l_ParkingRestrictions.AutoSize = true;
            this.l_ParkingRestrictions.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_ParkingRestrictions.Location = new System.Drawing.Point(257, 112);
            this.l_ParkingRestrictions.Name = "l_ParkingRestrictions";
            this.l_ParkingRestrictions.Size = new System.Drawing.Size(68, 17);
            this.l_ParkingRestrictions.TabIndex = 13;
            this.l_ParkingRestrictions.Text = "车位限制：";
            // 
            // cb_ParkingRestrictions
            // 
            this.cb_ParkingRestrictions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ParkingRestrictions.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_ParkingRestrictions.FormattingEnabled = true;
            this.cb_ParkingRestrictions.Items.AddRange(new object[] {
            "关闭",
            "开启"});
            this.cb_ParkingRestrictions.Location = new System.Drawing.Point(330, 105);
            this.cb_ParkingRestrictions.Name = "cb_ParkingRestrictions";
            this.cb_ParkingRestrictions.Size = new System.Drawing.Size(130, 28);
            this.cb_ParkingRestrictions.TabIndex = 3;
            // 
            // cb_CardPartition
            // 
            this.cb_CardPartition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CardPartition.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_CardPartition.FormattingEnabled = true;
            this.cb_CardPartition.Items.AddRange(new object[] {
            "关闭",
            "开启"});
            this.cb_CardPartition.Location = new System.Drawing.Point(330, 160);
            this.cb_CardPartition.Name = "cb_CardPartition";
            this.cb_CardPartition.Size = new System.Drawing.Size(130, 28);
            this.cb_CardPartition.TabIndex = 4;
            this.cb_CardPartition.SelectedIndexChanged += new System.EventHandler(this.cb_CardPartition_SelectedIndexChanged);
            // 
            // l_CardPartition
            // 
            this.l_CardPartition.AutoSize = true;
            this.l_CardPartition.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_CardPartition.Location = new System.Drawing.Point(257, 167);
            this.l_CardPartition.Name = "l_CardPartition";
            this.l_CardPartition.Size = new System.Drawing.Size(68, 17);
            this.l_CardPartition.TabIndex = 15;
            this.l_CardPartition.Text = "车场分区：";
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
            this.p_CardPartition.Location = new System.Drawing.Point(20, 200);
            this.p_CardPartition.Name = "p_CardPartition";
            this.p_CardPartition.Size = new System.Drawing.Size(440, 155);
            this.p_CardPartition.TabIndex = 5;
            this.p_CardPartition.VisibleChanged += new System.EventHandler(this.p_CardPartition_VisibleChanged);
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
            this.cb_Partition16.CheckedChanged += new System.EventHandler(this.PartitionCheckedChanged);
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
            this.cb_Partition15.CheckedChanged += new System.EventHandler(this.PartitionCheckedChanged);
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
            this.cb_Partition14.CheckedChanged += new System.EventHandler(this.PartitionCheckedChanged);
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
            this.cb_Partition13.CheckedChanged += new System.EventHandler(this.PartitionCheckedChanged);
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
            this.cb_Partition12.CheckedChanged += new System.EventHandler(this.PartitionCheckedChanged);
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
            this.cb_Partition11.CheckedChanged += new System.EventHandler(this.PartitionCheckedChanged);
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
            this.cb_Partition10.CheckedChanged += new System.EventHandler(this.PartitionCheckedChanged);
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
            this.cb_Partition9.CheckedChanged += new System.EventHandler(this.PartitionCheckedChanged);
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
            this.cb_Partition8.CheckedChanged += new System.EventHandler(this.PartitionCheckedChanged);
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
            this.cb_Partition7.CheckedChanged += new System.EventHandler(this.PartitionCheckedChanged);
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
            this.cb_Partition6.CheckedChanged += new System.EventHandler(this.PartitionCheckedChanged);
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
            this.cb_Partition5.CheckedChanged += new System.EventHandler(this.PartitionCheckedChanged);
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
            this.cb_Partition4.CheckedChanged += new System.EventHandler(this.PartitionCheckedChanged);
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
            this.cb_Partition3.CheckedChanged += new System.EventHandler(this.PartitionCheckedChanged);
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
            this.cb_Partition2.CheckedChanged += new System.EventHandler(this.PartitionCheckedChanged);
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
            this.cb_Partition1.CheckedChanged += new System.EventHandler(this.PartitionCheckedChanged);
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
            this.cb_AllSelected.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cb_AllSelected_MouseDown);
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
            // btn_Enter
            // 
            this.btn_Enter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Enter.FlatAppearance.BorderSize = 0;
            this.btn_Enter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Enter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Enter.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Enter.ForeColor = System.Drawing.Color.White;
            this.btn_Enter.Location = new System.Drawing.Point(255, 448);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(100, 35);
            this.btn_Enter.TabIndex = 7;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // btn_Canel
            // 
            this.btn_Canel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Canel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Canel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Canel.FlatAppearance.BorderSize = 0;
            this.btn_Canel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Canel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Canel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Canel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Canel.ForeColor = System.Drawing.Color.White;
            this.btn_Canel.Location = new System.Drawing.Point(361, 448);
            this.btn_Canel.Name = "btn_Canel";
            this.btn_Canel.Size = new System.Drawing.Size(100, 35);
            this.btn_Canel.TabIndex = 8;
            this.btn_Canel.TabStop = false;
            this.btn_Canel.Text = "取 消";
            this.btn_Canel.UseVisualStyleBackColor = false;
            this.btn_Canel.Click += new System.EventHandler(this.btn_Canel_Click);
            // 
            // p_Bundled
            // 
            this.p_Bundled.Controls.Add(this.btn_Add);
            this.p_Bundled.Controls.Add(this.btn_Remove);
            this.p_Bundled.Controls.Add(this.cb_AllSelectedBundled);
            this.p_Bundled.Controls.Add(this.dgv_BundledList);
            this.p_Bundled.Controls.Add(this.label8);
            this.p_Bundled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p_Bundled.Location = new System.Drawing.Point(20, 200);
            this.p_Bundled.Name = "p_Bundled";
            this.p_Bundled.Size = new System.Drawing.Size(440, 238);
            this.p_Bundled.TabIndex = 6;
            this.p_Bundled.Paint += new System.Windows.Forms.PaintEventHandler(this.p_Bundled_Paint);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(337, 12);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(100, 35);
            this.btn_Add.TabIndex = 17;
            this.btn_Add.TabStop = false;
            this.btn_Add.Text = "添 加";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Remove.Enabled = false;
            this.btn_Remove.FlatAppearance.BorderSize = 0;
            this.btn_Remove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Remove.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Remove.ForeColor = System.Drawing.Color.White;
            this.btn_Remove.Location = new System.Drawing.Point(4, 12);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(100, 35);
            this.btn_Remove.TabIndex = 16;
            this.btn_Remove.TabStop = false;
            this.btn_Remove.Text = "移 除";
            this.btn_Remove.UseVisualStyleBackColor = false;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // cb_AllSelectedBundled
            // 
            this.cb_AllSelectedBundled.AutoSize = true;
            this.cb_AllSelectedBundled.Location = new System.Drawing.Point(8, 68);
            this.cb_AllSelectedBundled.Name = "cb_AllSelectedBundled";
            this.cb_AllSelectedBundled.Size = new System.Drawing.Size(15, 14);
            this.cb_AllSelectedBundled.TabIndex = 3;
            this.cb_AllSelectedBundled.UseVisualStyleBackColor = true;
            this.cb_AllSelectedBundled.CheckedChanged += new System.EventHandler(this.cb_AllSelectedBundled_CheckedChanged);
            this.cb_AllSelectedBundled.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cb_AllSelectedBundled_MouseDown);
            // 
            // dgv_BundledList
            // 
            this.dgv_BundledList.AllowUserToAddRows = false;
            this.dgv_BundledList.AllowUserToDeleteRows = false;
            this.dgv_BundledList.AllowUserToResizeColumns = false;
            this.dgv_BundledList.AllowUserToResizeRows = false;
            this.dgv_BundledList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_BundledList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_BundledList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_BundledList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_BundledList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_BundledList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_BundledList.ColumnHeadersHeight = 40;
            this.dgv_BundledList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_BundledList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_selected,
            this.c_LockState,
            this.c_Number,
            this.Time,
            this.Column4});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_BundledList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_BundledList.EnableHeadersVisualStyles = false;
            this.dgv_BundledList.Location = new System.Drawing.Point(1, 53);
            this.dgv_BundledList.MultiSelect = false;
            this.dgv_BundledList.Name = "dgv_BundledList";
            this.dgv_BundledList.RowHeadersVisible = false;
            this.dgv_BundledList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_BundledList.RowTemplate.Height = 36;
            this.dgv_BundledList.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_BundledList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_BundledList.Size = new System.Drawing.Size(438, 183);
            this.dgv_BundledList.TabIndex = 0;
            this.dgv_BundledList.TabStop = false;
            this.dgv_BundledList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_BundledList_CellFormatting);
            this.dgv_BundledList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_BundledList_CellValueChanged);
            this.dgv_BundledList.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv_BundledList_CurrentCellDirtyStateChanged);
            // 
            // c_selected
            // 
            this.c_selected.HeaderText = "";
            this.c_selected.Name = "c_selected";
            this.c_selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_selected.Width = 30;
            // 
            // c_LockState
            // 
            this.c_LockState.HeaderText = "解锁状态";
            this.c_LockState.Name = "c_LockState";
            this.c_LockState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_LockState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.c_LockState.Width = 80;
            // 
            // c_Number
            // 
            this.c_Number.HeaderText = "副卡卡号或车牌号码";
            this.c_Number.Name = "c_Number";
            this.c_Number.ReadOnly = true;
            this.c_Number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_Number.Width = 128;
            // 
            // Time
            // 
            dataGridViewCellStyle2.Format = "D";
            dataGridViewCellStyle2.NullValue = null;
            this.Time.DefaultCellStyle = dataGridViewCellStyle2;
            this.Time.HeaderText = "副卡有效期限";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Time.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "副卡场分区";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 140;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(186, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "捆绑列表";
            // 
            // DistanceRegister
            // 
            this.AcceptButton = this.btn_Enter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btn_Canel;
            this.ClientSize = new System.Drawing.Size(480, 495);
            this.Controls.Add(this.btn_Canel);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.cb_CardPartition);
            this.Controls.Add(this.l_CardPartition);
            this.Controls.Add(this.cb_ParkingRestrictions);
            this.Controls.Add(this.l_ParkingRestrictions);
            this.Controls.Add(this.t_CardTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_CardDistance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_CardType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_CardNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.p_Title);
            this.Controls.Add(this.p_Bundled);
            this.Controls.Add(this.p_CardPartition);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DistanceRegister";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "定距卡发行";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DistanceRegister_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DistanceRegister_FormClosed);
            this.Load += new System.EventHandler(this.DistanceRegister_Load);
            this.Shown+=new System.EventHandler(this.DistanceRegister_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DistanceRegister_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DistanceRegister_KeyUp);
            this.Resize += new System.EventHandler(this.DistanceRegister_Resize);
            this.p_Title.ResumeLayout(false);
            this.p_CardPartition.ResumeLayout(false);
            this.p_CardPartition.PerformLayout();
            this.p_Bundled.ResumeLayout(false);
            this.p_Bundled.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BundledList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_Title;
        private CCWin.SkinControl.SkinButton btn_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_CardNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_CardType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_CardDistance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker t_CardTime;
        private System.Windows.Forms.Label l_ParkingRestrictions;
        private System.Windows.Forms.ComboBox cb_ParkingRestrictions;
        private System.Windows.Forms.ComboBox cb_CardPartition;
        private System.Windows.Forms.Label l_CardPartition;
        private System.Windows.Forms.Panel p_CardPartition;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cb_AllSelected;
        private System.Windows.Forms.CheckBox cb_Partition1;
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
        private System.Windows.Forms.CheckBox cb_Partition16;
        private NewControl.NewButton btn_Enter;
        private NewControl.NewButton btn_Canel;
        private System.Windows.Forms.Panel p_Bundled;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgv_BundledList;
        private System.Windows.Forms.CheckBox cb_AllSelectedBundled;
        private NewControl.NewButton btn_Remove;
        private NewControl.NewButton btn_Add;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_selected;
        private System.Windows.Forms.DataGridViewImageColumn c_LockState;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}