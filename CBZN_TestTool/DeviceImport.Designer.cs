namespace CBZN_TestTool
{
    partial class DeviceImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceImport));
            this.pb_Import = new System.Windows.Forms.ProgressBar();
            this.p_Title = new System.Windows.Forms.Panel();
            this.l_Title = new System.Windows.Forms.Label();
            this.btn_Close = new CCWin.SkinControl.SkinButton();
            this.btn_Cancel = new CCWin.SkinControl.SkinButton();
            this.p_Title.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_Import
            // 
            this.pb_Import.Location = new System.Drawing.Point(25, 60);
            this.pb_Import.Name = "pb_Import";
            this.pb_Import.Size = new System.Drawing.Size(400, 30);
            this.pb_Import.TabIndex = 0;
            // 
            // p_Title
            // 
            this.p_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.p_Title.Controls.Add(this.l_Title);
            this.p_Title.Controls.Add(this.btn_Close);
            this.p_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Title.Location = new System.Drawing.Point(0, 0);
            this.p_Title.Name = "p_Title";
            this.p_Title.Size = new System.Drawing.Size(450, 40);
            this.p_Title.TabIndex = 4;
            // 
            // l_Title
            // 
            this.l_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Title.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_Title.ForeColor = System.Drawing.Color.White;
            this.l_Title.Location = new System.Drawing.Point(0, 0);
            this.l_Title.Name = "l_Title";
            this.l_Title.Size = new System.Drawing.Size(398, 40);
            this.l_Title.TabIndex = 4;
            this.l_Title.Text = "编录导入";
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
            this.btn_Close.Location = new System.Drawing.Point(404, 0);
            this.btn_Close.MouseBack = global::CBZN_TestTool.Properties.Resources.HoverClose;
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.NormlBack = global::CBZN_TestTool.Properties.Resources.NoneClose;
            this.btn_Close.Size = new System.Drawing.Size(46, 31);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Cancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Cancel.DownBack = null;
            this.btn_Cancel.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(159)))), ((int)(((byte)(241)))));
            this.btn_Cancel.FadeGlow = false;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.IsDrawBorder = false;
            this.btn_Cancel.IsDrawGlass = false;
            this.btn_Cancel.Location = new System.Drawing.Point(325, 105);
            this.btn_Cancel.MouseBack = null;
            this.btn_Cancel.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(185)))));
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.NormlBack = null;
            this.btn_Cancel.Size = new System.Drawing.Size(100, 35);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.TabStop = false;
            this.btn_Cancel.Text = "取 消";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // DeviceImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 150);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.p_Title);
            this.Controls.Add(this.pb_Import);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeviceImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编录导入";
            this.Load += new System.EventHandler(this.DeviceImport_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.l_Title_MouseDown);
            this.p_Title.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_Import;
        private System.Windows.Forms.Panel p_Title;
        private System.Windows.Forms.Label l_Title;
        private CCWin.SkinControl.SkinButton btn_Close;
        private CCWin.SkinControl.SkinButton btn_Cancel;
    }
}