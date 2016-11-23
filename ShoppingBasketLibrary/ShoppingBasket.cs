using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace QA.ShoppingBasket
{
    public class ShoppingBasket
    {
        public List<OrderItem> OrderItems { get; private set; }

        public int NumberOfItems
        {
            get
            {
                int total = 0;
                foreach (OrderItem item in OrderItems)
                {
                    total += item.Quantity;
                }
                return total;
            }
        }

        public int NumberOfProducts
        {
            get
            {
                return OrderItems.Count;
            }
        }

        public decimal BasketTotal
        {
            get
            {
                decimal totalvalue = 0;
                foreach (OrderItem item in OrderItems)
                {
                    totalvalue += item.TotalOrder;
                }
                return totalvalue;

            }
        
        }

        public ShoppingBasket()
        {
            OrderItems = new List<OrderItem>();
        }

        public void AddProduct(string prodName, decimal latestPrice, int qty)
        {
            foreach (OrderItem item in OrderItems)
            {
                if (item.ProductName == prodName)
                {
                    item.AddItems(latestPrice, qty);
                    return;
                }       
            }
            OrderItems.Add(new OrderItem(prodName,latestPrice,qty));
        }

        public void AddProduct(string prodName, decimal latestPrice)
        {
            AddProduct(prodName, latestPrice, 1);
        }

        public void RemoveProduct(string prodName, int qty)
        {
            foreach (OrderItem item in OrderItems)
            {
                if (item.ProductName == prodName)
                {
                    if (item.Quantity > qty)
                    {
                        item.RemoveItems(qty);
                    }
                    else
                    {
                        OrderItems.Remove(item);
                        //throw new Exception("Not enough of that item in basket");
                    }
                }
                else
                {
                    throw new Exception("Product not found");
                }
            }
        }
            
        public void RemoveProduct(string prodName)
        {
            foreach (OrderItem item in OrderItems)
            {
                if (item.ProductName == prodName)
                {
                    OrderItems.Remove(item);
                    return;
                }
            }
            throw new InvalidOperationException
                (String.Format("Item {0} not found", prodName));
     
        }

        public void ClearBasket()
        {
            OrderItems.Clear();
        }

        public decimal CurrentPrice(string prodName)
        {
            foreach (OrderItem item in OrderItems)
            {
                if (item.ProductName == prodName)
                {
                    return item.LatestPrice;
                }
            }
            throw new Exception("Product not found");
        }

        public void UpdateDetails(string prodName, int newQty, decimal latestPrice)
        {
            foreach (OrderItem o in OrderItems)
            {
                if (o.ProductName == prodName)
                {
                    o.Quantity = newQty;
                    o.LatestPrice = latestPrice;
                }
            }
        }

        public bool IsProductInBasket(string prodName)
        {
            foreach (OrderItem item in OrderItems)
            {
                if (item.ProductName == prodName)
                {
                    return true;
                }
            }
            return false;
        }

        public void SaveBasket(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(File.Open(fileName, FileMode.Create, FileAccess.Write)))
            {
                foreach (OrderItem item in OrderItems)
                {
                    string details = string.Format("{0}\t{1}\t{2}", item.ProductName, item.Quantity, item.LatestPrice);
                    sw.WriteLine(details);
                }
            }
        }
    }
}
