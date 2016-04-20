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
        public string ProdName
        {
            get { return txtProdName.Text; }
            set { txtProdName.Text = value; }
        }
        public int Quantity
        {
            get { return System.Convert.ToInt32(txtQty.Text); }
            set { txtQty.Text = value.ToString(); }
        }
        public decimal LatestPrice
        {
            get { return System.Convert.ToDecimal(txtLatestPrice.Text); }
            set { txtLatestPrice.Text = value.ToString(); }
        }

        public EditValue()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //// Do some validation
            //// such as check the value of the text box
            //if (true) // Do any validation
            //{
            //    // Put up message
            //    MessageBox.Show("You have an error");
            //}
            //else
            //{
            //    DialogResult = DialogResult.OK;
            //}

            DialogResult = DialogResult.OK;
        }

        private void EditValue_Load(object sender, EventArgs e)
        {
            ActiveControl = txtQty;
        }
    }
}
