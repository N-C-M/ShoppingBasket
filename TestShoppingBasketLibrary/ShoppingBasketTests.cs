using Microsoft.VisualStudio.TestTools.UnitTesting;
using QA.ShoppingBasket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestShoppingBasketLibrary
{
    /// <summary>
    /// Test Class for ShoppingBasket Tests
    /// </summary>

    [TestClass()]
    public class ShoppingBasketTests
    {
        /// <summary>
        /// Testing adding a new product with a quantity to the basket.
        /// </summary>
        
        [TestMethod]
        public void AddingProductWithQuantityTest()
        {
            ShoppingBasket Basket = new ShoppingBasket();
            string name = "Banana";
            decimal price = 0.75m;
            int quantity = 4;
            bool expected = true, actual = false;

            Basket.AddProduct(name, price, quantity);
            if (Basket.OrderItems[0].Quantity == 4)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// Testing adding a new product without a quantity to the basket.
        /// </summary>
        
        [TestMethod]
        public void AddingProductWithNoQuantityTest()
        {
            ShoppingBasket Basket = new ShoppingBasket();
            string name = "Banana";
            decimal price = 0.75m;
            bool expected = true, actual = false;

            Basket.AddProduct(name, price);
            if (Basket.OrderItems[0].Quantity == 1)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Adding quantity back onto item.
        /// </summary>
        
        [TestMethod]
        public void AddingQuantityTest()
        {
            ShoppingBasket Basket = new ShoppingBasket();
            string name = "Banana";
            decimal price = 0.75m;
            int addingQuantity = 4;
            bool expected = true, actual = false;
            Basket.AddProduct(name, price);

            Basket.AddProduct(name, price, addingQuantity);
            if (Basket.OrderItems[0].Quantity == 5)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }

        ///<summary>
        /// Adding a new price to item.
        /// </summary>
        
        [TestMethod]
        public void AddingNewPriceTest()
        {
            ShoppingBasket Basket = new ShoppingBasket();
            string name = "Banana";
            decimal price = 0.75m, addingPrice = 1.00m;
            bool expected = true, actual = false;
            Basket.AddProduct(name, price);

            Basket.AddProduct(name, addingPrice);
            if (Basket.OrderItems[0].Quantity == 2 && Basket.OrderItems[0].LatestPrice == 1.00m)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }

        ///<summary>
        /// Remove product from basket.
        /// </summary>
        
        [TestMethod]
        public void RemoveQuantityTest()
        {
            ShoppingBasket Basket = new ShoppingBasket();
            string name = "Banana";
            decimal price = 0.75m;
            int quantity = 3, removeQuantity = 1;
            bool expected = true, actual = false;
            Basket.AddProduct(name, price, quantity);

            Basket.RemoveProduct(name, removeQuantity);
            if(Basket.OrderItems[0].Quantity == 2)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);

        }

        ///<summary>
        /// Adding tow differnt products to the list
        /// </summary>
        
        [TestMethod]
        public void TwoProductsInTheList()
        {
            ShoppingBasket Basket = new ShoppingBasket();
            string name = "Banana", name2 = "Apple";
            decimal price = 0.75m, price2 = 1.00m;
            int quantity = 5, quantity2 = 3;
            bool expected = true, actual = false;
            Basket.AddProduct(name, price, quantity);
            Basket.AddProduct(name2, price2, quantity2);

            if(Basket.OrderItems[0].ProductName == "Banana" && Basket.OrderItems[1].ProductName == "Apple")
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }

        ///<summary>
        /// Clearing basket 
        /// </summary>
        
        [TestMethod]
        public void ClearingBasketTest()
        {
            ShoppingBasket Basket = new ShoppingBasket();
            string name = "Banana", name2 = "Apple";
            decimal price = 0.75m, price2 = 1.00m;
            int quantity = 5, quantity2 = 3;
            bool expected = true, actual = false;
            Basket.AddProduct(name, price, quantity);
            Basket.AddProduct(name2, price2, quantity2);

            Basket.ClearBasket();
            if(Basket.OrderItems.Count == 0)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }

        ///<summary>
        /// Number of items in basket
        /// </summary>
        
        [TestMethod]
        public void NumberOfItemsInBasketTest()
        {
            ShoppingBasket Basket = new ShoppingBasket();
            string name = "Banana", name2 = "Apple";
            decimal price = 0.75m, price2 = 1.00m;
            int quantity = 5, quantity2 = 3, expected = 8, actual = 0;
            Basket.AddProduct(name, price, quantity);
            Basket.AddProduct(name2, price2, quantity2);

            actual = Basket.NumberOfItems;

            Assert.AreEqual(expected, actual);
        }

        ///<summary>
        /// Number of products in the basket
        /// </summary>

        [TestMethod]
        public void NumberOfProductsInBasketTest()
        {
            ShoppingBasket Basket = new ShoppingBasket();
            string name = "Banana", name2 = "Apple", name3 = "Pies";
            decimal price = 0.75m, price2 = 1.00m, price3 = 1.50m;
            int quantity = 5, quantity2 = 3, quantity3 = 2, expected = 3, actual = 0;
            Basket.AddProduct(name, price, quantity);
            Basket.AddProduct(name2, price2, quantity2);
            Basket.AddProduct(name3, price3, quantity3);

            actual = Basket.NumberOfProducts;

            Assert.AreEqual(expected, actual);
        }

        ///<summary>
        /// Test to check if a product is in the basket
        /// </summary>
        
        [TestMethod]
        public void IsProductInBasketTest()
        {
            ShoppingBasket Basket = new ShoppingBasket();
            string name = "Banana", name2 = "Apple", name3 = "Pies";
            decimal price = 0.75m, price2 = 1.00m, price3 = 1.50m;
            int quantity = 5, quantity2 = 3, quantity3 = 2;
            bool expected = true, actual = false;
            Basket.AddProduct(name, price, quantity);
            Basket.AddProduct(name2, price2, quantity2);
            Basket.AddProduct(name3, price3, quantity3);

            actual = Basket.IsProductInBasket("Pies");

            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Checks the current price of an item in the basket
        /// </summary>
        
        [TestMethod]
        public void CurrentPriceOfItemInBasketTest()
        {
            ShoppingBasket Basket = new ShoppingBasket();
            string name = "Banana", name2 = "Apple", name3 = "pies";
            decimal price = 0.75m, price2 = 1.00m, price3 = 1.50m, expected = 1.00m, actual = 0m;
            int quantity = 5, quantity2 = 3, quantity3 = 2;
            Basket.AddProduct(name, price, quantity);
            Basket.AddProduct(name2, price2, quantity2);
            Basket.AddProduct(name3, price3, quantity3);

            actual = Basket.CurrentPrice(name2);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the current price of an item in the basket if the product is incorrect
        /// </summary>
        
        [TestMethod]
        public void IncorrectPriceOfItemInBasket()
        {
            ShoppingBasket Basket = new ShoppingBasket();
            string name = "Banana", name2 = "Apple", name3 = "pies";
            decimal price = 0.75m, price2 = 1.00m, price3 = 1.50m;
            int quantity = 5, quantity2 = 3, quantity3 = 2;
            Basket.AddProduct(name, price, quantity);
            Basket.AddProduct(name2, price2, quantity2);
            Basket.AddProduct(name3, price3, quantity3);

            try
            {
                Basket.CurrentPrice(name2);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is InvalidOperationException);
            }
        }
    }
}
