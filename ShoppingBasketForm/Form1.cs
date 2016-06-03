using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QA.ShoppingBasket;

namespace ShoppingBasketForm
{
    public partial class Form1 : Form
    {
        private ShoppingBasket basket = new ShoppingBasket();

        public Form1()
        {
            InitializeComponent();
        }
        private void RenderItems()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            txtNoItems.Text = basket.NumberOfItems.ToString();
            txtTotalValue.Text = basket.BasketTotal.ToString("C2");

            lbItems.Items.Clear();
            foreach (OrderItem item in basket.OrderItems)
            {
                if (item.Quantity > 0)
                {
                    lbItems.Items.Add(
                  string.Format("{0,-15}{1,4}{2,10:C2}{3,10:C2}",
                  item.ProductName, item.Quantity, item.LatestPrice, item.TotalOrder));
                }

            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal value;
            if (decimal.TryParse(txtLatestPrice.Text, out value))
            {
                basket.AddProduct(txtProdName.Text, value, (int)numQty.Value);
            }
            else
            {
                MessageBox.Show("You can't add a product without values!", "Values Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RenderItems();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbItems.SelectedIndex >= 0)
            {
                // A book has been selected
                OrderItem o = basket.OrderItems[lbItems.SelectedIndex];
                basket.RemoveProduct(o.ProductName);
                RenderItems();
            }
            else
            {
                MessageBox.Show("Please select a row", "Remove OrderItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditValue ev = new EditValue();
            if (lbItems.SelectedIndex >= 0)
            {
                OrderItem o = basket.OrderItems[lbItems.SelectedIndex];

                ev.ProdName = o.ProductName;
                ev.Quantity = o.Quantity;
                ev.LatestPrice = o.LatestPrice;

                DialogResult dr = ev.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    basket.UpdateDetails(o.ProductName, ev.Quantity, ev.LatestPrice);
                    RenderItems();
                }
            }
            else
            {
                {
                    MessageBox.Show("Please select a row to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {  
            // needs updating
            basket.OrderItems.Clear();
            RenderItems();
            txtProdName.Text = "";
            txtLatestPrice.Text = "";
            numQty.Value = 0;
            MessageBox.Show("Basket has been emptied", "Basket Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt";

            if (basket.BasketTotal <= 0)
            {
                MessageBox.Show("You can't save an empty basket!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(sfd.FileName);
                basket.SaveBasket(sfd.FileName);
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RenderItems();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();

            DialogResult dr = a.ShowDialog();
            if (dr == DialogResult.OK)
            {
                RenderItems();
            }
        }
    }
}
