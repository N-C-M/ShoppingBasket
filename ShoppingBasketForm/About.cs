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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
