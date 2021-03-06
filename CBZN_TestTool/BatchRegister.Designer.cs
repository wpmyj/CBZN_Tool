﻿namespace CBZN_TestTool
{
    partial class BatchRegister
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchRegister));
            this.p_Title = new System.Windows.Forms.Panel();
            this.btn_Close = new CCWin.SkinControl.SkinButton();
            this.dgv_RegisterList = new System.Windows.Forms.DataGridView();
            this.c_State = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Canel = new NewControl.NewButton();
            this.btn_Enter = new NewControl.NewButton();
            this.btn_Param = new NewControl.NewButton();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.p_Botton = new System.Windows.Forms.Panel();
            this.p_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RegisterList)).BeginInit();
            this.p_Botton.SuspendLayout();
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
            this.p_Title.Size = new System.Drawing.Size(333, 40);
            this.p_Title.TabIndex = 6;
            this.p_Title.Paint += new System.Windows.Forms.PaintEventHandler(this.p_Title_Paint);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.DownBack = global::CBZN_TestTool.Properties.Resources.DownClose;
            this.btn_Close.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btn_Close.Location = new System.Drawing.Point(287, 0);
            this.btn_Close.MouseBack = global::CBZN_TestTool.Properties.Resources.HoverClose;
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.NormlBack = global::CBZN_TestTool.Properties.Resources.NoneClose;
            this.btn_Close.Size = new System.Drawing.Size(46, 31);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.TabStop = false;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // dgv_RegisterList
            // 
            this.dgv_RegisterList.AllowUserToAddRows = false;
            this.dgv_RegisterList.AllowUserToDeleteRows = false;
            this.dgv_RegisterList.AllowUserToResizeColumns = false;
            this.dgv_RegisterList.AllowUserToResizeRows = false;
            this.dgv_RegisterList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_RegisterList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_RegisterList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_RegisterList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_RegisterList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_RegisterList.ColumnHeadersHeight = 40;
            this.dgv_RegisterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_RegisterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_State,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_RegisterList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_RegisterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_RegisterList.EnableHeadersVisualStyles = false;
            this.dgv_RegisterList.Location = new System.Drawing.Point(1, 41);
            this.dgv_RegisterList.MultiSelect = false;
            this.dgv_RegisterList.Name = "dgv_RegisterList";
            this.dgv_RegisterList.ReadOnly = true;
            this.dgv_RegisterList.RowHeadersVisible = false;
            this.dgv_RegisterList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_RegisterList.RowTemplate.Height = 36;
            this.dgv_RegisterList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_RegisterList.Size = new System.Drawing.Size(333, 458);
            this.dgv_RegisterList.TabIndex = 0;
            this.dgv_RegisterList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_RegisterList_CellFormatting);
            this.dgv_RegisterList.Paint += new System.Windows.Forms.PaintEventHandler(this.dgv_RegisterList_Paint);
            // 
            // c_State
            // 
            this.c_State.HeaderText = "注册状态";
            this.c_State.Image = global::CBZN_TestTool.Properties.Resources.block;
            this.c_State.Name = "c_State";
            this.c_State.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "卡号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 200;
            // 
            // btn_Canel
            // 
            this.btn_Canel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Canel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Canel.FlatAppearance.BorderSize = 0;
            this.btn_Canel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Canel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Canel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Canel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Canel.ForeColor = System.Drawing.Color.White;
            this.btn_Canel.Location = new System.Drawing.Point(222, 8);
            this.btn_Canel.Name = "btn_Canel";
            this.btn_Canel.Size = new System.Drawing.Size(100, 35);
            this.btn_Canel.TabIndex = 3;
            this.btn_Canel.TabStop = false;
            this.btn_Canel.Text = "取 消";
            this.btn_Canel.UseVisualStyleBackColor = false;
            this.btn_Canel.Click += new System.EventHandler(this.btn_Canel_Click);
            // 
            // btn_Enter
            // 
            this.btn_Enter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Enter.FlatAppearance.BorderSize = 0;
            this.btn_Enter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Enter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Enter.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Enter.ForeColor = System.Drawing.Color.White;
            this.btn_Enter.Location = new System.Drawing.Point(116, 8);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(100, 35);
            this.btn_Enter.TabIndex = 2;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // btn_Param
            // 
            this.btn_Param.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Param.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Param.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Param.FlatAppearance.BorderSize = 0;
            this.btn_Param.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Param.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Param.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Param.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Param.ForeColor = System.Drawing.Color.White;
            this.btn_Param.Location = new System.Drawing.Point(10, 8);
            this.btn_Param.Name = "btn_Param";
            this.btn_Param.Size = new System.Drawing.Size(100, 35);
            this.btn_Param.TabIndex = 1;
            this.btn_Param.TabStop = false;
            this.btn_Param.Text = "修改参数";
            this.btn_Param.UseVisualStyleBackColor = false;
            this.btn_Param.Click += new System.EventHandler(this.btn_Param_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "注册状态";
            this.dataGridViewImageColumn1.Image = global::CBZN_TestTool.Properties.Resources.block;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // p_Botton
            // 
            this.p_Botton.Controls.Add(this.btn_Canel);
            this.p_Botton.Controls.Add(this.btn_Param);
            this.p_Botton.Controls.Add(this.btn_Enter);
            this.p_Botton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_Botton.Location = new System.Drawing.Point(1, 449);
            this.p_Botton.Name = "p_Botton";
            this.p_Botton.Size = new System.Drawing.Size(333, 50);
            this.p_Botton.TabIndex = 7;
            // 
            // BatchRegister
            // 
            this.AcceptButton = this.btn_Enter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btn_Close;
            this.ClientSize = new System.Drawing.Size(335, 500);
            this.Controls.Add(this.p_Botton);
            this.Controls.Add(this.dgv_RegisterList);
            this.Controls.Add(this.p_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatchRegister";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "批量发行";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BatchRegister_FormClosed);
            this.Load += new System.EventHandler(this.BatchRegister_Load);
            this.Shown += new System.EventHandler(this.BatchRegister_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BatchRegister_Paint);
            this.p_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RegisterList)).EndInit();
            this.p_Botton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Title;
        private CCWin.SkinControl.SkinButton btn_Close;
        private System.Windows.Forms.DataGridView dgv_RegisterList;
        private NewControl.NewButton btn_Canel;
        private NewControl.NewButton btn_Enter;
        private NewControl.NewButton btn_Param;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn c_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Panel p_Botton;
    }
}