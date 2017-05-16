namespace CBZN_TestTool
{
    partial class ViceCardBundled
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViceCardBundled));
            this.p_Title = new System.Windows.Forms.Panel();
            this.btn_Close = new CCWin.SkinControl.SkinButton();
            this.btn_Canel = new NewControl.NewButton();
            this.btn_Enter = new NewControl.NewButton();
            this.dgv_ViceList = new System.Windows.Forms.DataGridView();
            this.c_Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_ViceCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_HostCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_SearchContent = new System.Windows.Forms.TextBox();
            this.btn_Search = new NewControl.NewButton();
            this.l_SearchTitle = new System.Windows.Forms.Label();
            this.p_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ViceList)).BeginInit();
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
            this.p_Title.Size = new System.Drawing.Size(398, 40);
            this.p_Title.TabIndex = 5;
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
            this.btn_Close.Location = new System.Drawing.Point(352, 0);
            this.btn_Close.MouseBack = global::CBZN_TestTool.Properties.Resources.HoverClose;
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.NormlBack = global::CBZN_TestTool.Properties.Resources.NoneClose;
            this.btn_Close.Size = new System.Drawing.Size(46, 31);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.TabStop = false;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Canel
            // 
            this.btn_Canel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Canel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Canel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Canel.FlatAppearance.BorderSize = 0;
            this.btn_Canel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Canel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Canel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Canel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Canel.ForeColor = System.Drawing.Color.White;
            this.btn_Canel.Location = new System.Drawing.Point(296, 449);
            this.btn_Canel.Name = "btn_Canel";
            this.btn_Canel.Size = new System.Drawing.Size(100, 35);
            this.btn_Canel.TabIndex = 10;
            this.btn_Canel.TabStop = false;
            this.btn_Canel.Text = "取 消";
            this.btn_Canel.UseVisualStyleBackColor = false;
            this.btn_Canel.Click += new System.EventHandler(this.btn_Canel_Click);
            // 
            // btn_Enter
            // 
            this.btn_Enter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Enter.Enabled = false;
            this.btn_Enter.FlatAppearance.BorderSize = 0;
            this.btn_Enter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Enter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Enter.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Enter.ForeColor = System.Drawing.Color.White;
            this.btn_Enter.Location = new System.Drawing.Point(190, 449);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(100, 35);
            this.btn_Enter.TabIndex = 9;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // dgv_ViceList
            // 
            this.dgv_ViceList.AllowUserToAddRows = false;
            this.dgv_ViceList.AllowUserToDeleteRows = false;
            this.dgv_ViceList.AllowUserToResizeColumns = false;
            this.dgv_ViceList.AllowUserToResizeRows = false;
            this.dgv_ViceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_ViceList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ViceList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_ViceList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_ViceList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ViceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ViceList.ColumnHeadersHeight = 40;
            this.dgv_ViceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ViceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_Selected,
            this.c_ViceCardNumber,
            this.c_HostCardNumber});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ViceList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ViceList.EnableHeadersVisualStyles = false;
            this.dgv_ViceList.Location = new System.Drawing.Point(4, 83);
            this.dgv_ViceList.MultiSelect = false;
            this.dgv_ViceList.Name = "dgv_ViceList";
            this.dgv_ViceList.RowHeadersVisible = false;
            this.dgv_ViceList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_ViceList.RowTemplate.Height = 36;
            this.dgv_ViceList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ViceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ViceList.Size = new System.Drawing.Size(392, 360);
            this.dgv_ViceList.TabIndex = 11;
            this.dgv_ViceList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ViceList_CellMouseDown);
            this.dgv_ViceList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ViceList_CellValueChanged);
            this.dgv_ViceList.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv_ViceList_CurrentCellDirtyStateChanged);
            this.dgv_ViceList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_ViceList_RowsAdded);
            // 
            // c_Selected
            // 
            this.c_Selected.HeaderText = "";
            this.c_Selected.Name = "c_Selected";
            this.c_Selected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_Selected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.c_Selected.Width = 30;
            // 
            // c_ViceCardNumber
            // 
            this.c_ViceCardNumber.HeaderText = "副卡编号";
            this.c_ViceCardNumber.Name = "c_ViceCardNumber";
            this.c_ViceCardNumber.ReadOnly = true;
            this.c_ViceCardNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_ViceCardNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // c_HostCardNumber
            // 
            this.c_HostCardNumber.HeaderText = "已绑定主卡编号";
            this.c_HostCardNumber.Name = "c_HostCardNumber";
            this.c_HostCardNumber.ReadOnly = true;
            this.c_HostCardNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_HostCardNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_HostCardNumber.Width = 240;
            // 
            // tb_SearchContent
            // 
            this.tb_SearchContent.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_SearchContent.Location = new System.Drawing.Point(4, 44);
            this.tb_SearchContent.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.tb_SearchContent.Name = "tb_SearchContent";
            this.tb_SearchContent.Size = new System.Drawing.Size(292, 33);
            this.tb_SearchContent.TabIndex = 12;
            this.tb_SearchContent.TextChanged += new System.EventHandler(this.tb_SearchContent_TextChanged);
            this.tb_SearchContent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_SearchContent_KeyPress);
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Search.FlatAppearance.BorderSize = 0;
            this.btn_Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Search.ForeColor = System.Drawing.Color.White;
            this.btn_Search.Location = new System.Drawing.Point(296, 44);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(100, 33);
            this.btn_Search.TabIndex = 13;
            this.btn_Search.TabStop = false;
            this.btn_Search.Text = "搜 索";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // l_SearchTitle
            // 
            this.l_SearchTitle.AutoSize = true;
            this.l_SearchTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_SearchTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_SearchTitle.ForeColor = System.Drawing.Color.Silver;
            this.l_SearchTitle.Location = new System.Drawing.Point(14, 50);
            this.l_SearchTitle.Name = "l_SearchTitle";
            this.l_SearchTitle.Size = new System.Drawing.Size(107, 20);
            this.l_SearchTitle.TabIndex = 14;
            this.l_SearchTitle.Text = "搜索的副卡编号";
            this.l_SearchTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.l_SearchTitle_MouseDown);
            // 
            // ViceCardBundled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 495);
            this.Controls.Add(this.l_SearchTitle);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.tb_SearchContent);
            this.Controls.Add(this.dgv_ViceList);
            this.Controls.Add(this.btn_Canel);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.p_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViceCardBundled";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "副卡选择";
            this.Load += new System.EventHandler(this.ViceCardBundled_Load);
            this.Shown += new System.EventHandler(this.ViceCardBundled_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ViceCardBundled_Paint);
            this.p_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ViceList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_Title;
        private CCWin.SkinControl.SkinButton btn_Close;
        private NewControl.NewButton btn_Canel;
        private NewControl.NewButton btn_Enter;
        private System.Windows.Forms.DataGridView dgv_ViceList;
        private System.Windows.Forms.TextBox tb_SearchContent;
        private NewControl.NewButton btn_Search;
        private System.Windows.Forms.Label l_SearchTitle;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ViceCardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_HostCardNumber;
    }
}