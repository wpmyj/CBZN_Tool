using System.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace NewControl
{
    public partial class NewButton : Button
    {
        private bool _isEnter;
        private bool _isDown;

        public NewButton()
        {
            InitializeComponent();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            _isDown = false;
            base.OnMouseUp(mevent);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            _isDown = true;
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (_isDown) _isDown = false;
            _isEnter = false;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isEnter = true;
            base.OnMouseEnter(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            Color background = this.BackColor;
            Color forecolor = this.ForeColor;
            if (this.Enabled)
            {
                if (_isDown)
                {
                    background = this.FlatAppearance.MouseDownBackColor;
                }
                else if (_isEnter)
                {
                    background = this.FlatAppearance.MouseOverBackColor;
                }
            }
            else
            {
                background = Color.FromArgb(160, 160, 160);
                forecolor = Color.White;
            }
            StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.FillRectangle(new SolidBrush(background), rect);
            if (FlatAppearance.BorderSize > 0)
            {
                g.DrawRectangle(new Pen(FlatAppearance.BorderColor, FlatAppearance.BorderSize), 0, 0, rect.Width - 1, rect.Height - 1);
            }
            g.DrawString(Text, Font, new SolidBrush(forecolor), rect, sf);
        }
    }
}
