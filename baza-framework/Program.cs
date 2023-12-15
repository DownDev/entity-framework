using baza_framework;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = new MyDbContext();
        context.Database.EnsureCreated();

        MyDbContextSeeder.Seed(context);

        int choice;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Read all products");
            Console.WriteLine("2. Read product by ID");
            Console.WriteLine("3. Update product price");
            Console.WriteLine("4. Delete product by ID");
            Console.WriteLine("0. Exit");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Products in the database:");
                        foreach (var product in context.Products)
                        {
                            Console.WriteLine($"{product.ProductID}: {product.ProductName} - {product.Price:C}");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter product ID:");
                        if (int.TryParse(Console.ReadLine(), out int productId))
                        {
                            var product = context.Products.Where(item => item.ProductID == productId).FirstOrDefault();
                            if (product != null)
                            {
                                Console.WriteLine($"{product.ProductID}: {product.ProductName} - {product.Price:C}");
                            }
                            else
                            {
                                Console.WriteLine("Product not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter product ID:");
                        if (int.TryParse(Console.ReadLine(), out int updateProductId))
                        {
                            var productToUpdate = context.Products.Where(item => item.ProductID == updateProductId).FirstOrDefault();
                            if (productToUpdate != null)
                            {
                                Console.WriteLine("Enter new price:");
                                if (double.TryParse(Console.ReadLine(), out double newPrice))
                                {
                                    context.Products.Attach(productToUpdate);
                                    productToUpdate.Price = newPrice;
                                    context.SaveChanges();
                                    Console.WriteLine("Product price updated.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid number.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Product not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter product ID:");
                        if (int.TryParse(Console.ReadLine(), out int deleteProductId))
                        {
                            var productToDelete = context.Products.Where(item => item.ProductID == deleteProductId).FirstOrDefault();
                            if (productToDelete != null)
                            {
                                context.Products.Remove(productToDelete);
                                context.SaveChanges();
                                Console.WriteLine("Product deleted.");
                            }
                            else
                            {
                                Console.WriteLine("Product not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Exiting program.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid number.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

        } while (choice != 0);
    }
}