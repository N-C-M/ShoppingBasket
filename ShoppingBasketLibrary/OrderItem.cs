using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QA.ShoppingBasket
{
    public class OrderItem
    {
        public string ProductName { get; private set; }
        public decimal LatestPrice { get; set; }
        public int Quantity { get; set; }

        /// <summary>
        /// Multiplies the latest price by the quantity of the product.
        /// </summary>
        public decimal TotalOrder
        {
            get { return LatestPrice * Quantity; }
        }

        /// <summary>
        /// Assigns the input strings to there respective properties.
        /// </summary>
        /// <param name="prodname"></param>
        /// <param name="latestPrice"></param>
        /// <param name="quantity"></param>
        public OrderItem(string prodname, decimal latestPrice, int quantity)
        {
            ProductName = prodname;
            LatestPrice = latestPrice;
            Quantity = quantity;
        }

        public OrderItem(string prodname, decimal latestPrice) : this(prodname, latestPrice, 1) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latestPrice"></param>
        /// <param name="qty"></param>
        /// <returns></returns>
        public int AddItems(decimal latestPrice, int qty)
        {
            Quantity += qty;
            LatestPrice = latestPrice;
            return Quantity;

        }

        public int AddItems(int qty)
        {
            Quantity += qty;
            return Quantity;
        }

        public int AddItem()
        {
            return ++Quantity;
        }

        public int RemoveItems(int qty)
        {
            if (qty <= Quantity)
            {
                Quantity -= qty;
            }
            else
            {
                Quantity = 0;
            }
            return Quantity;
        }

        public int RemoveItem()
        {
            if (Quantity > 0)
            {
                Quantity--;
            }
            return Quantity;
        }     
    }
}
