using E_Commerce_App.dao;
using E_Commerce_App.Entity;
using System.Data.Common;

namespace E_Commerce.Test
{
    public class Tests
    {
        private const string connectionString= "Server=TEJAS;Database=E-CommerseApplication;Trusted_Connection=True";

        [Test]
        public void GetAllFromCart()
        {
            IOrderProcessorRepository repo = new OrderProcessorRepositoryImpl();

            Customers customer=new Customers();
            customer.CustomerId = 5;

            var allProduct=repo.GetAllFromCart(customer);
            Console.WriteLine();

            Assert.IsNotNull(allProduct);
            Assert.GreaterOrEqual(customer.CustomerId, 0);
        }

        [Test]
        public void CreateProduct()
        {
            IOrderProcessorRepository repo = new OrderProcessorRepositoryImpl();
            Products product=new Products();
            product.Name = "Test";
            product.Price = 1;
            product.Description = "Description";
            product.StockQuantity = 1;

            var addProduct=repo.CreateProduct(product);

            Assert.AreEqual(true,addProduct);
        }

        [Test]
        public void AddToCart()
        {
            IOrderProcessorRepository repo = new OrderProcessorRepositoryImpl();
            Products product = new Products();
            Customers customers = new Customers();

            customers.CustomerId = 5;
            product.ProductId = 1;
            int quantity = 5;
            var addTocart=repo.AddToCart(customers,product,quantity);

            Assert.AreEqual (true,addTocart);

        }

        [Test]
        public void PlaceOrder()
        {
            IOrderProcessorRepository repo = new OrderProcessorRepositoryImpl();
            Products product = new Products();
            Customers customers = new Customers();
            Dictionary<Products, int> dict = new Dictionary<Products, int>();

            customers.CustomerId = 5;
            product.ProductId = 1;
            int quantity = 5;
            string shippingAddress = "ABC Test";
            dict.Add(product, quantity);

            var placeOrder=repo.PlaceOrder(customers,dict,shippingAddress);

            Assert.AreEqual (true,placeOrder);
        }

        [Test]
        public void CorrectException()
        {
            IOrderProcessorRepository repo = new OrderProcessorRepositoryImpl();

            int customerId = 3;
            int productId = 6;

            var customerExists=repo.CustomerExists(customerId);
            var productExists=repo.ProductExists(customerId);

            Assert.AreEqual(true, customerExists);
            Assert.AreEqual(true, productExists);
        }
    }
}