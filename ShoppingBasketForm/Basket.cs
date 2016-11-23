using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QA.ShoppingBasket;
using MaterialSkin.Controls;
using MaterialSkin;

namespace ShoppingBasketForm
{
    public partial class Basket : MaterialForm
    {
        private ShoppingBasket basket = new ShoppingBasket();

        public Basket()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        /// <summary>
        /// Creates and adds an item to a data grid.
        /// </summary>
        private void RenderItems()
        {
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

        /// <summary>
        /// This method is used when adding a product to the basket.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_Button_Click(object sender, EventArgs e)
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


        /// <summary>
        /// This method is used when removing a product from the basket.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void remove_Button_Click(object sender, EventArgs e)
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

        /// <summary>
        /// This method is used when you are wanting to edit an exsisting product in the basket.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void edit_Button_Click(object sender, EventArgs e)
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

        /// <summary>
        /// This method is used to clear our exsisting products in the basket.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearbasket_Button_Click(object sender, EventArgs e)
        {
            basket.OrderItems.Clear();
            RenderItems();
            txtProdName.Text = ""; ;
            txtLatestPrice.Text = "";
            numQty.Value = 0;
            MessageBox.Show("Basket has been emptied", "Basket Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } 

        /// <summary>
        /// This method is used when you want to save the basket to a .txt file e.g. a receipt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Button_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Calls the method that creates the data grid. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            RenderItems();
        }

        /// <summary>
        /// This method is used when you want to exit out of the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_Button_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }  

        /// <summary>
        /// This method is used to open the about form from the tool strip menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();

            DialogResult dr = a.ShowDialog();
            if (dr == DialogResult.OK)
            {
                RenderItems();
            }
        }

        /// <summary>
        /// This method allows the end user to correctly terminate the application using the ribbon exit icon by sending the correct exit code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Basket_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }  
    }
}


