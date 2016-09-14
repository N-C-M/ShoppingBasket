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
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method to process and update the progress bar for the application splash screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            progressBar.Visible = true;

            this.progressBar.Value = this.progressBar.Value + 2;
            if (this.progressBar.Value == 10)
            {
                label3.Text = "Reading modules..";
            }
            else if (this.progressBar.Value == 20)
            {
                label3.Text = "Turning on modules.";
            }
            else if (this.progressBar.Value == 40)
            {
                label3.Text = "Starting modules..";
            }
            else if (this.progressBar.Value == 60)
            {
                label3.Text = "Loading modules..";
            }
            else if (this.progressBar.Value == 80)
            {
                label3.Text = "Done Loading modules..";
            }
            else if (this.progressBar.Value == 100)
            {
                frm.Show();
                timer1.Enabled = false;
                this.Hide();
            }
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            progressBar.Width = this.Width;
        }
    }
}
