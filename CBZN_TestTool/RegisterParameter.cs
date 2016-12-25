using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CBZN_TestTool
{
    public partial class RegisterParameter : Form
    {
        public RegisterParameter()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            Load += RegisterParameter_Load;
            Paint += RegisterParameter_Paint;
        }

        private void RegisterParameter_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 1), new Rectangle(0, 0, Width - 1, Height - 1));
            }
        }

        private void RegisterParameter_Load(object sender, EventArgs e)
        {
            
        }

        private void cb_CardPartition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
