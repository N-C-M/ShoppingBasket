using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShoppingBasketForm
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            timer1.Interval = 100;
            timer1.Start();
        }

        private void Timer1_Tick(System.Object sender, System.EventArgs e)
        {
            pbCPU.Value = (Int32)CPU.NextValue();
            pbRAM.Value = (Int32)RAM.NextValue();

            lblcpu.Text = pbCPU.Value + "%";
            lblram.Text = pbRAM.Value + "%";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
