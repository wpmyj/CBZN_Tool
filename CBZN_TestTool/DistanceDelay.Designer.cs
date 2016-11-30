namespace CBZN_TestTool
{
    partial class DistanceDelay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.p_Title = new System.Windows.Forms.Panel();
            this.l_Title = new System.Windows.Forms.Label();
            this.btn_Close = new CCWin.SkinControl.SkinButton();
            this.dgv_BundledList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.t_OldTime = new System.Windows.Forms.DateTimePicker();
            this.t_NewTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_DelaySelected = new System.Windows.Forms.ComboBox();
            this.l_DelayValueTitle = new System.Windows.Forms.Label();
            this.ud_DelayValue = new System.Windows.Forms.NumericUpDown();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BundledList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_DelayValue)).BeginInit();
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
            this.p_Title.Size = new System.Drawing.Size(600, 40);
            this.p_Title.TabIndex = 5;
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
            this.l_Title.Size = new System.Drawing.Size(548, 40);
            this.l_Title.TabIndex = 4;
            this.l_Title.Text = "定距卡发行";
            this.l_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.p_Title_MouseDown);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Close.DownBack = global::CBZN_TestTool.Properties.Resources.DownClose;
            this.btn_Close.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btn_Close.Location = new System.Drawing.Point(554, 0);
            this.btn_Close.MouseBack = global::CBZN_TestTool.Properties.Resources.HoverClose;
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.NormlBack = global::CBZN_TestTool.Properties.Resources.NoneClose;
            this.btn_Close.Size = new System.Drawing.Size(46, 31);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.TabStop = false;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // dgv_BundledList
            // 
            this.dgv_BundledList.AllowUserToAddRows = false;
            this.dgv_BundledList.AllowUserToDeleteRows = false;
            this.dgv_BundledList.AllowUserToResizeColumns = false;
            this.dgv_BundledList.AllowUserToResizeRows = false;
            this.dgv_BundledList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_BundledList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_BundledList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_BundledList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_BundledList.ColumnHeadersHeight = 40;
            this.dgv_BundledList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_BundledList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column1,
            this.Column4});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_BundledList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_BundledList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_BundledList.EnableHeadersVisualStyles = false;
            this.dgv_BundledList.Location = new System.Drawing.Point(0, 40);
            this.dgv_BundledList.MultiSelect = false;
            this.dgv_BundledList.Name = "dgv_BundledList";
            this.dgv_BundledList.RowHeadersVisible = false;
            this.dgv_BundledList.RowTemplate.Height = 36;
            this.dgv_BundledList.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_BundledList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_BundledList.Size = new System.Drawing.Size(600, 184);
            this.dgv_BundledList.TabIndex = 0;
            this.dgv_BundledList.TabStop = false;
            this.dgv_BundledList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_BundledList_CellFormatting);
            this.dgv_BundledList.Paint += new System.Windows.Forms.PaintEventHandler(this.dgv_BundledList_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(56, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "当前期限：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(56, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "延期期限：";
            // 
            // t_OldTime
            // 
            this.t_OldTime.CustomFormat = "yyyy年MM月dd日";
            this.t_OldTime.Enabled = false;
            this.t_OldTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_OldTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.t_OldTime.Location = new System.Drawing.Point(130, 247);
            this.t_OldTime.Name = "t_OldTime";
            this.t_OldTime.Size = new System.Drawing.Size(150, 26);
            this.t_OldTime.TabIndex = 7;
            // 
            // t_NewTime
            // 
            this.t_NewTime.CustomFormat = "yyyy年MM月dd日";
            this.t_NewTime.Enabled = false;
            this.t_NewTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_NewTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.t_NewTime.Location = new System.Drawing.Point(130, 290);
            this.t_NewTime.Name = "t_NewTime";
            this.t_NewTime.Size = new System.Drawing.Size(150, 26);
            this.t_NewTime.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(320, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "延期方式：";
            // 
            // cb_DelaySelected
            // 
            this.cb_DelaySelected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_DelaySelected.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_DelaySelected.FormattingEnabled = true;
            this.cb_DelaySelected.Items.AddRange(new object[] {
            "按天延期",
            "按月延期",
            "按季延期",
            "按年延期",
            "选择延期"});
            this.cb_DelaySelected.Location = new System.Drawing.Point(394, 247);
            this.cb_DelaySelected.Name = "cb_DelaySelected";
            this.cb_DelaySelected.Size = new System.Drawing.Size(150, 28);
            this.cb_DelaySelected.TabIndex = 10;
            this.cb_DelaySelected.SelectedIndexChanged += new System.EventHandler(this.cb_DelaySelected_SelectedIndexChanged);
            // 
            // l_DelayValueTitle
            // 
            this.l_DelayValueTitle.AutoSize = true;
            this.l_DelayValueTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_DelayValueTitle.Location = new System.Drawing.Point(320, 295);
            this.l_DelayValueTitle.Name = "l_DelayValueTitle";
            this.l_DelayValueTitle.Size = new System.Drawing.Size(68, 17);
            this.l_DelayValueTitle.TabIndex = 11;
            this.l_DelayValueTitle.Text = "延期次数：";
            // 
            // ud_DelayValue
            // 
            this.ud_DelayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ud_DelayValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ud_DelayValue.Location = new System.Drawing.Point(394, 290);
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
            this.ud_DelayValue.TabIndex = 12;
            this.ud_DelayValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Column2
            // 
            this.Column2.HeaderText = "定距卡号或车牌号码";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            dataGridViewCellStyle5.Format = "D";
            dataGridViewCellStyle5.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column3.HeaderText = "有效期限";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 140;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "延期期限";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 140;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "场分区";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 210;
            // 
            // DistanceDelay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.ud_DelayValue);
            this.Controls.Add(this.l_DelayValueTitle);
            this.Controls.Add(this.cb_DelaySelected);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.t_NewTime);
            this.Controls.Add(this.t_OldTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_BundledList);
            this.Controls.Add(this.p_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DistanceDelay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DistanceDelay";
            this.Load += new System.EventHandler(this.DistanceDelay_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DistanceDelay_Paint);
            this.p_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BundledList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_DelayValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_Title;
        private System.Windows.Forms.Label l_Title;
        private CCWin.SkinControl.SkinButton btn_Close;
        private System.Windows.Forms.DataGridView dgv_BundledList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker t_OldTime;
        private System.Windows.Forms.DateTimePicker t_NewTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_DelaySelected;
        private System.Windows.Forms.Label l_DelayValueTitle;
        private System.Windows.Forms.NumericUpDown ud_DelayValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}