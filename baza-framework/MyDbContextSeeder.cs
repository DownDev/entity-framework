using baza_framework.Models;

namespace baza_framework
{
    public static class MyDbContextSeeder
    {
        public static void Seed(MyDbContext context)
        {
            if (context.Products.Any())
            {
                return;
            }

            var categories = new List<ProductCategory>
        {
            new ProductCategory { CategoryID = 1, CategoryName = "Electronics" },
            new ProductCategory { CategoryID = 2, CategoryName = "Clothing" },
            new ProductCategory { CategoryID = 3, CategoryName = "Books" }
        };

            context.ProductCategories.AddRange(categories);

            var products = new List<Product>
        {
            new Product
            {
                ProductID = 1,
                ProductName = "Laptop",
                UnitName = "Piece",
                UnitScale = 1,
                InStock = 50,
                Price = 1200.0,
                DiscontinuedPrice = 1000.0,
                Category = categories[0]
            },
            new Product
            {
                ProductID = 2,
                ProductName = "T-Shirt",
                UnitName = "Piece",
                UnitScale = 2,
                InStock = 100,
                Price = 25.0,
                DiscontinuedPrice = 20.0,
                Category = categories[1]
            },
            new Product
            {
                ProductID = 3,
                ProductName = "Book",
                UnitName = "Piece",
                UnitScale = 3,
                InStock = 200,
                Price = 15.0,
                DiscontinuedPrice = 12.0,
                Category = categories[2]
            }
        };

            context.Products.AddRange(products);

            var orders = new List<Order>
        {
            new Order
            {
                OrderID = 1,
                OrderDate = DateTime.Now,
                Freight = 5.0,
                ShipDate = DateTime.Now.AddDays(2),
                Discount = 0.1
            },
            new Order
            {
                OrderID = 2,
                OrderDate = DateTime.Now.AddDays(-5),
                Freight = 8.0,
                ShipDate = DateTime.Now.AddDays(-3),
                Discount = 0.05
            }
        };

            context.Orders.AddRange(orders);

            context.OrderDetails.AddRange(
                new OrderDetail
                {
                    OrderDetailID = 1,
                    Price = 1200.0,
                    Quantity = 2.0,
                    Product = products[0],
                    Order = orders[0]
                },
                new OrderDetail
                {
                    OrderDetailID = 2,
                    Price = 25.0,
                    Quantity = 5.0,
                    Product = products[1],
                    Order = orders[1]
                }
            );

            context.SaveChanges();
        }
    }
}
