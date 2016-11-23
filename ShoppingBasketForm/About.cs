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
    public partial class About : MaterialSkin.Controls.MaterialForm
    {
        /// <summary>
        /// Initializing the About form.
        /// </summary>
        public About()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;  
        }

        /// <summary>
        /// Returning the cancel value when the button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
