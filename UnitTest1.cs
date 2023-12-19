using E_Commerce_App.dao;
using E_Commerce_App.Entity;
using E_Commerce_App.userException;
using System.Data.Common;

namespace E_Commerce.Test
{
    public class Tests
    {
       // private const string connectionString= "Server=TEJAS;Database=E-CommerseApplication;Trusted_Connection=True";

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
            product.ProductId = 3;
            int quantity = 5;
            string shippingAddress = "ABC Test";
            dict.Add(product, quantity);

            var placeOrder=repo.PlaceOrder(customers,dict,shippingAddress);

            Assert.AreEqual (true,placeOrder);
        }

        [Test]
        public void CorrectProductException()
        {
            IOrderProcessorRepository repo = new OrderProcessorRepositoryImpl();
            int productId = 1;                      
            Assert.Throws<ProductNotFoundException>(() => repo.DeleteProduct(productId));

        }

        [Test]
        public void CorrectCustomerException()
        {
            IOrderProcessorRepository repo = new OrderProcessorRepositoryImpl();
            int customerId = 7;
            Assert.Throws<ProductNotFoundException>(() => repo.DeleteCustomer(customerId));

        }
    }
}