namespace CBZN_ClientNumberDownTool
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.p_Left = new System.Windows.Forms.Panel();
            this.btn_Limit = new CCWin.SkinControl.SkinButton();
            this.btn_Download = new CCWin.SkinControl.SkinButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_PortOpenAndClose = new System.Windows.Forms.Button();
            this.cb_PortNames = new System.Windows.Forms.ComboBox();
            this.l_ConnectionDescription = new System.Windows.Forms.Label();
            this.p_top = new System.Windows.Forms.Panel();
            this.l_Title = new System.Windows.Forms.Label();
            this.btn_Min = new CCWin.SkinControl.SkinButton();
            this.btn_Close = new CCWin.SkinControl.SkinButton();
            this.p1 = new System.Windows.Forms.Panel();
            this.tb_DownLoadDescription = new System.Windows.Forms.RichTextBox();
            this.btn_Down = new System.Windows.Forms.Button();
            this.l_CountDescription = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.tb_SearchContent = new System.Windows.Forms.TextBox();
            this.btn_DelCustomer = new System.Windows.Forms.Button();
            this.btn_EditCustomer = new System.Windows.Forms.Button();
            this.btn_AddCustomer = new System.Windows.Forms.Button();
            this.btn_ShowCustomer = new System.Windows.Forms.Button();
            this.cb_page = new System.Windows.Forms.ComboBox();
            this.btn_Previous = new System.Windows.Forms.Button();
            this.dgv_CustomerList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Next = new System.Windows.Forms.Button();
            this.p2 = new System.Windows.Forms.Panel();
            this.btn_Canel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.ud_LimitValue = new System.Windows.Forms.NumericUpDown();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.dgv_LimitList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_Left.SuspendLayout();
            this.panel4.SuspendLayout();
            this.p_top.SuspendLayout();
            this.p1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CustomerList)).BeginInit();
            this.p2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_LimitValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LimitList)).BeginInit();
            this.SuspendLayout();
            // 
            // p_Left
            // 
            this.p_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(50)))), ((int)(((byte)(72)))));
            this.p_Left.Controls.Add(this.btn_Limit);
            this.p_Left.Controls.Add(this.btn_Download);
            this.p_Left.Controls.Add(this.panel4);
            this.p_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.p_Left.Location = new System.Drawing.Point(0, 0);
            this.p_Left.Name = "p_Left";
            this.p_Left.Size = new System.Drawing.Size(200, 500);
            this.p_Left.TabIndex = 0;
            this.p_Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            // 
            // btn_Limit
            // 
            this.btn_Limit.BackColor = System.Drawing.Color.Transparent;
            this.btn_Limit.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Limit.BorderColor = System.Drawing.Color.Transparent;
            this.btn_Limit.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Limit.DownBack = null;
            this.btn_Limit.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.btn_Limit.FadeGlow = false;
            this.btn_Limit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Limit.ForeColor = System.Drawing.Color.White;
            this.btn_Limit.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btn_Limit.IsDrawBorder = false;
            this.btn_Limit.IsDrawGlass = false;
            this.btn_Limit.IsEnabledDraw = false;
            this.btn_Limit.Location = new System.Drawing.Point(0, 220);
            this.btn_Limit.MouseBack = null;
            this.btn_Limit.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btn_Limit.Name = "btn_Limit";
            this.btn_Limit.NormlBack = null;
            this.btn_Limit.Size = new System.Drawing.Size(200, 60);
            this.btn_Limit.TabIndex = 3;
            this.btn_Limit.Text = "编 号 限 制";
            this.btn_Limit.UseVisualStyleBackColor = false;
            this.btn_Limit.Click += new System.EventHandler(this.btn_Limit_Click);
            // 
            // btn_Download
            // 
            this.btn_Download.BackColor = System.Drawing.Color.Transparent;
            this.btn_Download.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Download.BorderColor = System.Drawing.Color.Transparent;
            this.btn_Download.ControlState = CCWin.SkinClass.ControlState.Pressed;
            this.btn_Download.DownBack = null;
            this.btn_Download.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.btn_Download.Enabled = false;
            this.btn_Download.FadeGlow = false;
            this.btn_Download.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Download.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Download.ForeColor = System.Drawing.Color.White;
            this.btn_Download.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btn_Download.IsDrawBorder = false;
            this.btn_Download.IsDrawGlass = false;
            this.btn_Download.IsEnabledDraw = false;
            this.btn_Download.Location = new System.Drawing.Point(0, 150);
            this.btn_Download.MouseBack = null;
            this.btn_Download.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btn_Download.Name = "btn_Download";
            this.btn_Download.NormlBack = null;
            this.btn_Download.Size = new System.Drawing.Size(200, 60);
            this.btn_Download.TabIndex = 2;
            this.btn_Download.Text = "下 载 编 号";
            this.btn_Download.UseVisualStyleBackColor = false;
            this.btn_Download.Click += new System.EventHandler(this.btn_Download_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(36)))), ((int)(((byte)(59)))));
            this.panel4.Controls.Add(this.btn_PortOpenAndClose);
            this.panel4.Controls.Add(this.cb_PortNames);
            this.panel4.Controls.Add(this.l_ConnectionDescription);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 124);
            this.panel4.TabIndex = 0;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            // 
            // btn_PortOpenAndClose
            // 
            this.btn_PortOpenAndClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.btn_PortOpenAndClose.FlatAppearance.BorderSize = 0;
            this.btn_PortOpenAndClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btn_PortOpenAndClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(189)))), ((int)(((byte)(239)))));
            this.btn_PortOpenAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PortOpenAndClose.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_PortOpenAndClose.ForeColor = System.Drawing.Color.White;
            this.btn_PortOpenAndClose.Location = new System.Drawing.Point(40, 82);
            this.btn_PortOpenAndClose.Name = "btn_PortOpenAndClose";
            this.btn_PortOpenAndClose.Size = new System.Drawing.Size(120, 29);
            this.btn_PortOpenAndClose.TabIndex = 1;
            this.btn_PortOpenAndClose.Text = "打 开";
            this.btn_PortOpenAndClose.UseVisualStyleBackColor = false;
            this.btn_PortOpenAndClose.Click += new System.EventHandler(this.btn_PortOpenAndClose_Click);
            // 
            // cb_PortNames
            // 
            this.cb_PortNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_PortNames.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_PortNames.FormattingEnabled = true;
            this.cb_PortNames.Location = new System.Drawing.Point(40, 45);
            this.cb_PortNames.Name = "cb_PortNames";
            this.cb_PortNames.Size = new System.Drawing.Size(120, 29);
            this.cb_PortNames.TabIndex = 0;
            // 
            // l_ConnectionDescription
            // 
            this.l_ConnectionDescription.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_ConnectionDescription.ForeColor = System.Drawing.Color.Red;
            this.l_ConnectionDescription.Location = new System.Drawing.Point(63, 14);
            this.l_ConnectionDescription.Name = "l_ConnectionDescription";
            this.l_ConnectionDescription.Size = new System.Drawing.Size(75, 23);
            this.l_ConnectionDescription.TabIndex = 9;
            this.l_ConnectionDescription.Text = "未连接";
            this.l_ConnectionDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p_top
            // 
            this.p_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.p_top.Controls.Add(this.l_Title);
            this.p_top.Controls.Add(this.btn_Min);
            this.p_top.Controls.Add(this.btn_Close);
            this.p_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_top.Location = new System.Drawing.Point(200, 0);
            this.p_top.Name = "p_top";
            this.p_top.Size = new System.Drawing.Size(600, 35);
            this.p_top.TabIndex = 1;
            this.p_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            // 
            // l_Title
            // 
            this.l_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Title.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_Title.ForeColor = System.Drawing.Color.White;
            this.l_Title.Location = new System.Drawing.Point(0, 0);
            this.l_Title.Name = "l_Title";
            this.l_Title.Size = new System.Drawing.Size(509, 35);
            this.l_Title.TabIndex = 2;
            this.l_Title.Text = "畅泊客户编号下载工具";
            this.l_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            // 
            // btn_Min
            // 
            this.btn_Min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Min.BackColor = System.Drawing.Color.Transparent;
            this.btn_Min.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Min.DownBack = global::CBZN_ClientNumberDownTool.Properties.Resources.DownHover;
            this.btn_Min.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btn_Min.Location = new System.Drawing.Point(508, 0);
            this.btn_Min.MouseBack = global::CBZN_ClientNumberDownTool.Properties.Resources.HoverMin;
            this.btn_Min.Name = "btn_Min";
            this.btn_Min.NormlBack = global::CBZN_ClientNumberDownTool.Properties.Resources.NoneMin;
            this.btn_Min.Size = new System.Drawing.Size(46, 31);
            this.btn_Min.TabIndex = 1;
            this.btn_Min.TabStop = false;
            this.btn_Min.UseVisualStyleBackColor = false;
            this.btn_Min.Click += new System.EventHandler(this.btn_Min_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Close.DownBack = global::CBZN_ClientNumberDownTool.Properties.Resources.DownClose;
            this.btn_Close.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btn_Close.Location = new System.Drawing.Point(554, 0);
            this.btn_Close.MouseBack = global::CBZN_ClientNumberDownTool.Properties.Resources.HoverClose;
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.NormlBack = global::CBZN_ClientNumberDownTool.Properties.Resources.NoneClose;
            this.btn_Close.Size = new System.Drawing.Size(46, 31);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.TabStop = false;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // p1
            // 
            this.p1.Controls.Add(this.tb_DownLoadDescription);
            this.p1.Controls.Add(this.btn_Down);
            this.p1.Controls.Add(this.l_CountDescription);
            this.p1.Controls.Add(this.btn_Search);
            this.p1.Controls.Add(this.tb_SearchContent);
            this.p1.Controls.Add(this.btn_DelCustomer);
            this.p1.Controls.Add(this.btn_EditCustomer);
            this.p1.Controls.Add(this.btn_AddCustomer);
            this.p1.Controls.Add(this.btn_ShowCustomer);
            this.p1.Controls.Add(this.cb_page);
            this.p1.Controls.Add(this.btn_Previous);
            this.p1.Controls.Add(this.dgv_CustomerList);
            this.p1.Controls.Add(this.btn_Next);
            this.p1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p1.Location = new System.Drawing.Point(200, 35);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(600, 465);
            this.p1.TabIndex = 7;
            // 
            // tb_DownLoadDescription
            // 
            this.tb_DownLoadDescription.Location = new System.Drawing.Point(279, 396);
            this.tb_DownLoadDescription.Name = "tb_DownLoadDescription";
            this.tb_DownLoadDescription.ReadOnly = true;
            this.tb_DownLoadDescription.Size = new System.Drawing.Size(309, 65);
            this.tb_DownLoadDescription.TabIndex = 11;
            this.tb_DownLoadDescription.TabStop = false;
            this.tb_DownLoadDescription.Text = "";
            this.tb_DownLoadDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_DownLoadDescription_KeyUp);
            // 
            // btn_Down
            // 
            this.btn_Down.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(50)))), ((int)(((byte)(72)))));
            this.btn_Down.Enabled = false;
            this.btn_Down.FlatAppearance.BorderSize = 0;
            this.btn_Down.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btn_Down.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.btn_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Down.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Down.ForeColor = System.Drawing.Color.White;
            this.btn_Down.Location = new System.Drawing.Point(13, 396);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(260, 65);
            this.btn_Down.TabIndex = 10;
            this.btn_Down.Text = "下 载";
            this.btn_Down.UseVisualStyleBackColor = false;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // l_CountDescription
            // 
            this.l_CountDescription.AutoSize = true;
            this.l_CountDescription.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_CountDescription.Location = new System.Drawing.Point(19, 366);
            this.l_CountDescription.Name = "l_CountDescription";
            this.l_CountDescription.Size = new System.Drawing.Size(95, 20);
            this.l_CountDescription.TabIndex = 11;
            this.l_CountDescription.Text = "总共 0 条记录";
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(50)))), ((int)(((byte)(72)))));
            this.btn_Search.BackgroundImage = global::CBZN_ClientNumberDownTool.Properties.Resources.search;
            this.btn_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Search.FlatAppearance.BorderSize = 0;
            this.btn_Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btn_Search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Search.ForeColor = System.Drawing.Color.White;
            this.btn_Search.Location = new System.Drawing.Point(554, 15);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(29, 29);
            this.btn_Search.TabIndex = 5;
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // tb_SearchContent
            // 
            this.tb_SearchContent.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_SearchContent.Location = new System.Drawing.Point(359, 15);
            this.tb_SearchContent.Name = "tb_SearchContent";
            this.tb_SearchContent.Size = new System.Drawing.Size(195, 29);
            this.tb_SearchContent.TabIndex = 4;
            this.tb_SearchContent.TextChanged += new System.EventHandler(this.tb_SearchContent_TextChanged);
            this.tb_SearchContent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_SearchContent_KeyUp);
            // 
            // btn_DelCustomer
            // 
            this.btn_DelCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(50)))), ((int)(((byte)(72)))));
            this.btn_DelCustomer.Enabled = false;
            this.btn_DelCustomer.FlatAppearance.BorderSize = 0;
            this.btn_DelCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btn_DelCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.btn_DelCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DelCustomer.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_DelCustomer.ForeColor = System.Drawing.Color.White;
            this.btn_DelCustomer.Location = new System.Drawing.Point(272, 15);
            this.btn_DelCustomer.Name = "btn_DelCustomer";
            this.btn_DelCustomer.Size = new System.Drawing.Size(81, 29);
            this.btn_DelCustomer.TabIndex = 3;
            this.btn_DelCustomer.Text = "删除客户";
            this.btn_DelCustomer.UseVisualStyleBackColor = false;
            this.btn_DelCustomer.Visible = false;
            this.btn_DelCustomer.Click += new System.EventHandler(this.btn_DelCustomer_Click);
            // 
            // btn_EditCustomer
            // 
            this.btn_EditCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(50)))), ((int)(((byte)(72)))));
            this.btn_EditCustomer.Enabled = false;
            this.btn_EditCustomer.FlatAppearance.BorderSize = 0;
            this.btn_EditCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btn_EditCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.btn_EditCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EditCustomer.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_EditCustomer.ForeColor = System.Drawing.Color.White;
            this.btn_EditCustomer.Location = new System.Drawing.Point(187, 15);
            this.btn_EditCustomer.Name = "btn_EditCustomer";
            this.btn_EditCustomer.Size = new System.Drawing.Size(81, 29);
            this.btn_EditCustomer.TabIndex = 2;
            this.btn_EditCustomer.Text = "编辑客户";
            this.btn_EditCustomer.UseVisualStyleBackColor = false;
            this.btn_EditCustomer.Click += new System.EventHandler(this.btn_EditCustomer_Click);
            // 
            // btn_AddCustomer
            // 
            this.btn_AddCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(50)))), ((int)(((byte)(72)))));
            this.btn_AddCustomer.FlatAppearance.BorderSize = 0;
            this.btn_AddCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btn_AddCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.btn_AddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddCustomer.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AddCustomer.ForeColor = System.Drawing.Color.White;
            this.btn_AddCustomer.Location = new System.Drawing.Point(100, 15);
            this.btn_AddCustomer.Name = "btn_AddCustomer";
            this.btn_AddCustomer.Size = new System.Drawing.Size(81, 29);
            this.btn_AddCustomer.TabIndex = 1;
            this.btn_AddCustomer.Text = "新增客户";
            this.btn_AddCustomer.UseVisualStyleBackColor = false;
            this.btn_AddCustomer.Click += new System.EventHandler(this.btn_AddCustomer_Click);
            // 
            // btn_ShowCustomer
            // 
            this.btn_ShowCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(50)))), ((int)(((byte)(72)))));
            this.btn_ShowCustomer.FlatAppearance.BorderSize = 0;
            this.btn_ShowCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btn_ShowCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.btn_ShowCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowCustomer.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ShowCustomer.ForeColor = System.Drawing.Color.White;
            this.btn_ShowCustomer.Location = new System.Drawing.Point(13, 15);
            this.btn_ShowCustomer.Name = "btn_ShowCustomer";
            this.btn_ShowCustomer.Size = new System.Drawing.Size(81, 29);
            this.btn_ShowCustomer.TabIndex = 0;
            this.btn_ShowCustomer.Text = "显示客户";
            this.btn_ShowCustomer.UseVisualStyleBackColor = false;
            this.btn_ShowCustomer.Click += new System.EventHandler(this.btn_ShowCustomer_Click);
            // 
            // cb_page
            // 
            this.cb_page.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_page.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_page.FormattingEnabled = true;
            this.cb_page.Location = new System.Drawing.Point(395, 361);
            this.cb_page.Name = "cb_page";
            this.cb_page.Size = new System.Drawing.Size(100, 29);
            this.cb_page.TabIndex = 8;
            this.cb_page.SelectedIndexChanged += new System.EventHandler(this.cb_page_SelectedIndexChanged);
            // 
            // btn_Previous
            // 
            this.btn_Previous.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(50)))), ((int)(((byte)(72)))));
            this.btn_Previous.FlatAppearance.BorderSize = 0;
            this.btn_Previous.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btn_Previous.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.btn_Previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Previous.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Previous.ForeColor = System.Drawing.Color.White;
            this.btn_Previous.Location = new System.Drawing.Point(307, 361);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(81, 29);
            this.btn_Previous.TabIndex = 7;
            this.btn_Previous.Text = "上一页";
            this.btn_Previous.UseVisualStyleBackColor = false;
            this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // dgv_CustomerList
            // 
            this.dgv_CustomerList.AllowUserToAddRows = false;
            this.dgv_CustomerList.AllowUserToDeleteRows = false;
            this.dgv_CustomerList.AllowUserToResizeColumns = false;
            this.dgv_CustomerList.AllowUserToResizeRows = false;
            this.dgv_CustomerList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_CustomerList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_CustomerList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_CustomerList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_CustomerList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_CustomerList.ColumnHeadersHeight = 36;
            this.dgv_CustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_CustomerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.UserName,
            this.UserNumber,
            this.Description,
            this.RecordTime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_CustomerList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_CustomerList.EnableHeadersVisualStyles = false;
            this.dgv_CustomerList.Location = new System.Drawing.Point(0, 55);
            this.dgv_CustomerList.MultiSelect = false;
            this.dgv_CustomerList.Name = "dgv_CustomerList";
            this.dgv_CustomerList.ReadOnly = true;
            this.dgv_CustomerList.RowHeadersVisible = false;
            this.dgv_CustomerList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_CustomerList.RowTemplate.Height = 36;
            this.dgv_CustomerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_CustomerList.Size = new System.Drawing.Size(600, 300);
            this.dgv_CustomerList.StandardTab = true;
            this.dgv_CustomerList.TabIndex = 6;
            this.dgv_CustomerList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CustomerList_CellMouseDoubleClick);
            this.dgv_CustomerList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_CustomerList_RowsAdded);
            this.dgv_CustomerList.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_CustomerList_RowsRemoved);
            this.dgv_CustomerList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_CustomerList_KeyDown);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = " ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "客户名称";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserName.Width = 200;
            // 
            // UserNumber
            // 
            this.UserNumber.DataPropertyName = "UserNumber";
            this.UserNumber.HeaderText = "客户编号";
            this.UserNumber.Name = "UserNumber";
            this.UserNumber.ReadOnly = true;
            this.UserNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "说明";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Description.Width = 280;
            // 
            // RecordTime
            // 
            this.RecordTime.DataPropertyName = "RecordTime";
            this.RecordTime.HeaderText = "记录时间";
            this.RecordTime.Name = "RecordTime";
            this.RecordTime.ReadOnly = true;
            this.RecordTime.Visible = false;
            // 
            // btn_Next
            // 
            this.btn_Next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(50)))), ((int)(((byte)(72)))));
            this.btn_Next.FlatAppearance.BorderSize = 0;
            this.btn_Next.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btn_Next.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Next.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Next.ForeColor = System.Drawing.Color.White;
            this.btn_Next.Location = new System.Drawing.Point(502, 361);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(81, 29);
            this.btn_Next.TabIndex = 9;
            this.btn_Next.Text = "下一页";
            this.btn_Next.UseVisualStyleBackColor = false;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // p2
            // 
            this.p2.Controls.Add(this.btn_Canel);
            this.p2.Controls.Add(this.btn_Save);
            this.p2.Controls.Add(this.ud_LimitValue);
            this.p2.Controls.Add(this.btn_Del);
            this.p2.Controls.Add(this.btn_Add);
            this.p2.Controls.Add(this.dgv_LimitList);
            this.p2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p2.Location = new System.Drawing.Point(200, 35);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(600, 465);
            this.p2.TabIndex = 0;
            // 
            // btn_Canel
            // 
            this.btn_Canel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(50)))), ((int)(((byte)(72)))));
            this.btn_Canel.FlatAppearance.BorderSize = 0;
            this.btn_Canel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btn_Canel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.btn_Canel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Canel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Canel.ForeColor = System.Drawing.Color.White;
            this.btn_Canel.Location = new System.Drawing.Point(479, 243);
            this.btn_Canel.Name = "btn_Canel";
            this.btn_Canel.Size = new System.Drawing.Size(81, 29);
            this.btn_Canel.TabIndex = 4;
            this.btn_Canel.Text = "取 消";
            this.btn_Canel.UseVisualStyleBackColor = false;
            this.btn_Canel.Visible = false;
            this.btn_Canel.Click += new System.EventHandler(this.btn_Canel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(50)))), ((int)(((byte)(72)))));
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btn_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(392, 243);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(81, 29);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "添 加";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Visible = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // ud_LimitValue
            // 
            this.ud_LimitValue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ud_LimitValue.Location = new System.Drawing.Point(392, 193);
            this.ud_LimitValue.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ud_LimitValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ud_LimitValue.Name = "ud_LimitValue";
            this.ud_LimitValue.Size = new System.Drawing.Size(168, 29);
            this.ud_LimitValue.TabIndex = 2;
            this.ud_LimitValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ud_LimitValue.Visible = false;
            this.ud_LimitValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ud_LimitValue_KeyUp);
            // 
            // btn_Del
            // 
            this.btn_Del.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(50)))), ((int)(((byte)(72)))));
            this.btn_Del.Enabled = false;
            this.btn_Del.FlatAppearance.BorderSize = 0;
            this.btn_Del.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btn_Del.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.btn_Del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Del.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Del.ForeColor = System.Drawing.Color.White;
            this.btn_Del.Location = new System.Drawing.Point(428, 339);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(81, 29);
            this.btn_Del.TabIndex = 5;
            this.btn_Del.Text = "删 除";
            this.btn_Del.UseVisualStyleBackColor = false;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(50)))), ((int)(((byte)(72)))));
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(83)))));
            this.btn_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(428, 97);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(81, 29);
            this.btn_Add.TabIndex = 1;
            this.btn_Add.Text = "新增限制";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // dgv_LimitList
            // 
            this.dgv_LimitList.AllowUserToAddRows = false;
            this.dgv_LimitList.AllowUserToDeleteRows = false;
            this.dgv_LimitList.AllowUserToResizeColumns = false;
            this.dgv_LimitList.AllowUserToResizeRows = false;
            this.dgv_LimitList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_LimitList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_LimitList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_LimitList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_LimitList.ColumnHeadersHeight = 40;
            this.dgv_LimitList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_LimitList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_LimitList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_LimitList.EnableHeadersVisualStyles = false;
            this.dgv_LimitList.Location = new System.Drawing.Point(92, 22);
            this.dgv_LimitList.MultiSelect = false;
            this.dgv_LimitList.Name = "dgv_LimitList";
            this.dgv_LimitList.ReadOnly = true;
            this.dgv_LimitList.RowHeadersVisible = false;
            this.dgv_LimitList.RowTemplate.Height = 36;
            this.dgv_LimitList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_LimitList.Size = new System.Drawing.Size(240, 420);
            this.dgv_LimitList.StandardTab = true;
            this.dgv_LimitList.TabIndex = 0;
            this.dgv_LimitList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_LimitList_RowsAdded);
            this.dgv_LimitList.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_LimitList_RowsRemoved);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "编号限制列表";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.p_top);
            this.Controls.Add(this.p_Left);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "畅泊客户编号下载工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.p_Left.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.p_top.ResumeLayout(false);
            this.p1.ResumeLayout(false);
            this.p1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CustomerList)).EndInit();
            this.p2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ud_LimitValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LimitList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Left;
        private System.Windows.Forms.Panel p_top;
        private System.Windows.Forms.Panel panel4;
        private CCWin.SkinControl.SkinButton btn_Close;
        private CCWin.SkinControl.SkinButton btn_Min;
        private CCWin.SkinControl.SkinButton btn_Download;
        private CCWin.SkinControl.SkinButton btn_Limit;
        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.Panel p2;
        private System.Windows.Forms.DataGridView dgv_CustomerList;
        private System.Windows.Forms.ComboBox cb_page;
        private System.Windows.Forms.Button btn_Previous;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_DelCustomer;
        private System.Windows.Forms.Button btn_EditCustomer;
        private System.Windows.Forms.Button btn_AddCustomer;
        private System.Windows.Forms.Button btn_ShowCustomer;
        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridView dgv_LimitList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btn_Canel;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.NumericUpDown ud_LimitValue;
        private System.Windows.Forms.Label l_ConnectionDescription;
        private System.Windows.Forms.TextBox tb_SearchContent;
        private System.Windows.Forms.ComboBox cb_PortNames;
        private System.Windows.Forms.Button btn_PortOpenAndClose;
        private System.Windows.Forms.Label l_Title;
        private System.Windows.Forms.Label l_CountDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordTime;
        private System.Windows.Forms.RichTextBox tb_DownLoadDescription;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_Search;
    }
}

