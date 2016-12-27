namespace CBZN_TestTool
{
    partial class CardLoss
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
            this.dgv_LossList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Enter = new CCWin.SkinControl.SkinButton();
            this.btn_Cancel = new CCWin.SkinControl.SkinButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LossList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_LossList
            // 
            this.dgv_LossList.AllowUserToAddRows = false;
            this.dgv_LossList.AllowUserToDeleteRows = false;
            this.dgv_LossList.AllowUserToResizeColumns = false;
            this.dgv_LossList.AllowUserToResizeRows = false;
            this.dgv_LossList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_LossList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_LossList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_LossList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_LossList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_LossList.ColumnHeadersHeight = 40;
            this.dgv_LossList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_LossList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_LossList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_LossList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_LossList.EnableHeadersVisualStyles = false;
            this.dgv_LossList.Location = new System.Drawing.Point(1, 6);
            this.dgv_LossList.MultiSelect = false;
            this.dgv_LossList.Name = "dgv_LossList";
            this.dgv_LossList.ReadOnly = true;
            this.dgv_LossList.RowHeadersVisible = false;
            this.dgv_LossList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_LossList.RowTemplate.Height = 36;
            this.dgv_LossList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_LossList.Size = new System.Drawing.Size(233, 335);
            this.dgv_LossList.TabIndex = 0;
            this.dgv_LossList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_LossList_CellDoubleClick);
            this.dgv_LossList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_LossList_RowsAdded);
            this.dgv_LossList.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_LossList_RowsRemoved);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "卡片编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 200;
            // 
            // btn_Enter
            // 
            this.btn_Enter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Enter.BackColor = System.Drawing.Color.Transparent;
            this.btn_Enter.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Enter.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Enter.DownBack = null;
            this.btn_Enter.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Enter.Enabled = false;
            this.btn_Enter.FadeGlow = false;
            this.btn_Enter.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Enter.ForeColor = System.Drawing.Color.White;
            this.btn_Enter.IsDrawBorder = false;
            this.btn_Enter.IsDrawGlass = false;
            this.btn_Enter.Location = new System.Drawing.Point(15, 354);
            this.btn_Enter.MouseBack = null;
            this.btn_Enter.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.NormlBack = null;
            this.btn_Enter.Size = new System.Drawing.Size(100, 35);
            this.btn_Enter.TabIndex = 7;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btn_Cancel.Location = new System.Drawing.Point(121, 354);
            this.btn_Cancel.MouseBack = null;
            this.btn_Cancel.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.NormlBack = null;
            this.btn_Cancel.Size = new System.Drawing.Size(100, 35);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.TabStop = false;
            this.btn_Cancel.Text = "取 消";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // CardLoss
            // 
            this.AcceptButton = this.btn_Enter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(235, 400);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.dgv_LossList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CardLoss";
            this.Padding = new System.Windows.Forms.Padding(1, 6, 1, 1);
            this.Text = "CardLoss";
            this.Deactivate += new System.EventHandler(this.CardLoss_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CardLoss_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CardLoss_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LossList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_LossList;
        private CCWin.SkinControl.SkinButton btn_Enter;
        private CCWin.SkinControl.SkinButton btn_Cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}