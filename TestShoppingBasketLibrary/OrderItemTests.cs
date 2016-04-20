using QA.ShoppingBasket;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestShoppingBasketLibrary
{
    
    
    /// <summary>
    ///This is a test class for OrderItemTest and is intended
    ///to contain all OrderItemTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OrderItemTests
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for OrderItem Constructor
        ///</summary>
        [TestMethod()]
        public void OrderItemConstructorTest2Params()
        {
            string prodname = "Banana";
            decimal latestPrice = 0.75m; 
            OrderItem target = new OrderItem(prodname, latestPrice);
            Assert.AreEqual(prodname, target.ProductName);
            Assert.AreEqual(latestPrice, target.LatestPrice);
            Assert.AreEqual(1, target.Quantity);
        }

        /// <summary>
        ///A test for OrderItem Constructor
        ///</summary>
        [TestMethod()]
        public void OrderItemConstructorTest3Params()
        {
            string prodname = "Banana";
            decimal latestPrice = 0.75m;
            int quantity = 2;
            OrderItem target = new OrderItem(prodname, latestPrice, quantity);
            Assert.AreEqual(prodname, target.ProductName);
            Assert.AreEqual(latestPrice, target.LatestPrice);
            Assert.AreEqual(quantity, target.Quantity);
        }

        /// <summary>
        ///A test for AddItem
        ///</summary>
        [TestMethod()]
        public void AddItemTest()
        {
            string prodname = "Banana";
            decimal latestPrice = 0.75m;
            int quantity = 2;
            OrderItem target = new OrderItem(prodname, latestPrice, quantity);
            int expected = 3;
            int actual = target.AddItem();
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for AddItems
        ///</summary>
        [TestMethod()]
        public void AddItemsTestQtyOnly()
        {
            string prodname = "Banana";
            decimal latestPrice = 0.75m;
            int quantity = 3;
            OrderItem target = new OrderItem(prodname, latestPrice, quantity);

            int qty = 2;
            int actual = target.AddItems(qty);
            int expected = 5;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AddItems
        ///</summary>
        [TestMethod()]
        public void AddItemsTestQtyAndPrice()
        {
 
            string prodname = "Banana";
            decimal latestPrice = 0.75m;
            int quantity = 3;
            OrderItem target = new OrderItem(prodname, latestPrice, quantity);
            
            decimal latestPriceChange = 0.75m;
            int qty = 2;
            
            int actual = target.AddItems(latestPriceChange,qty);
            int expected = 5;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(latestPriceChange, target.LatestPrice);
        }

        /// <summary>
        ///A test for RemoveItem
        ///</summary>
        [TestMethod()]
        public void RemoveItemTest()
        {
            string prodname = "Banana";
            decimal latestPrice = 0.75m;
            int quantity = 3;
            OrderItem target = new OrderItem(prodname, latestPrice, quantity);
    
            int actual = target.RemoveItem();
            int expected = 2;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RemoveItems
        ///</summary>
        [TestMethod()]
        public void RemoveItemsTest()
        {
            string prodname = "Pies"; 
            decimal latestPrice = 1.50m;
            int quantity = 6; 
            OrderItem target = new OrderItem(prodname, latestPrice, quantity);
            int quantityToRemove = 5;
            int expected = 1; 
            int actual;
            actual = target.RemoveItems(quantityToRemove);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LatestPrice
        ///</summary>
        [TestMethod()]
        public void LatestPriceTest()
        {
            OrderItem target = new OrderItem("Apples", 1.00m); 
            decimal expected = 1.00m; 
            decimal actual;
            actual = target.LatestPrice;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ProductName
        ///</summary>
        [TestMethod()]
        public void ProductNameTest()
        {
            OrderItem target = new OrderItem("Apples", 1.00m);
            string expected = "Apples"; 
            string actual;
            actual = target.ProductName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Quantity
        ///</summary>
        [TestMethod()]
        public void QuantityOfMoreThanOneTest()
        {
            OrderItem target = new OrderItem("Apples", 1.00m, 3);
            int expected = 3; 
            int actual;
            actual = target.Quantity;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Quantity
        ///</summary>
        [TestMethod()]
        public void QuantityOfOneTest()
        {
            OrderItem target = new OrderItem("Apples", 1.00m);
            int expected = 1;
            int actual;
            actual = target.Quantity;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TotalOrder
        ///</summary>
        [TestMethod()]
        public void TotalOrderTest()
        {
            string prodname = "Bread"; 
            decimal latestPrice = 1.89m;
            int quantity = 3;
            decimal expected = 5.67m;
            OrderItem target = new OrderItem(prodname, latestPrice, quantity); 
            decimal actual;
            actual = target.TotalOrder;
            Assert.AreEqual(expected, actual);
        }
    }
}
