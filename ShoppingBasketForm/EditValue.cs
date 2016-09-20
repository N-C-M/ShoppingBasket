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
    public partial class EditValue : Form
    {
        /// <summary>
        /// Setting the ProdName property to the value of txtProdName.
        /// </summary>
        public string ProdName
        {
            get { return txtProdName.Text; }
            set { txtProdName.Text = value; }
        }

        /// <summary>
        /// Setting the Quantity property to the value of the txtQty.
        /// </summary>
        public int Quantity
        {
            get { return System.Convert.ToInt32(txtQty.Text); }
            set { txtQty.Text = value.ToString(); }
        }

        /// <summary>
        /// Setting the LatestPrice property to the value of the txtLatestPrice.
        /// </summary>
        public decimal LatestPrice
        {
            get { return System.Convert.ToDecimal(txtLatestPrice.Text); }
            set { txtLatestPrice.Text = value.ToString(); }
        }

        /// <summary>
        /// Initializing the EditValue form.
        /// </summary>
        public EditValue()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        /// <summary>
        /// Returing the value when the OK button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Making ActiveControl equal the value of txtQty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditValue_Load(object sender, EventArgs e)
        {
            ActiveControl = txtQty;
        }
    }
}
