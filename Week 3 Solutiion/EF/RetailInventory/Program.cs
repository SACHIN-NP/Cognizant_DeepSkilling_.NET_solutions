
//To Run LAB-4
// using Microsoft.EntityFrameworkCore;
// using RetailInventory.Data;
// using RetailInventory.Models;

// namespace RetailInventory
// {
//     class Program
//     {
//         static async Task Main(string[] args)
//         {
//             Console.WriteLine("=== Retail Inventory System ===");
//             Console.WriteLine("Lab 4: Inserting Initial Data");
            
//             using var context = new AppDbContext();
            
//             // Ensure database exists
//             await context.Database.EnsureCreatedAsync();
            
//             // Check if data already exists
//             var existingCategories = await context.Categories.CountAsync();
//             if (existingCategories > 0)
//             {
//                 Console.WriteLine("Data already exists in database.");
//                 return;
//             }
            
//             Console.WriteLine("Inserting initial data...");
            
//             // Create categories
//             var electronics = new Category 
//             { 
//                 Name = "Electronics", 
//                 Description = "Electronic devices and accessories" 
//             };
            
//             var groceries = new Category 
//             { 
//                 Name = "Groceries", 
//                 Description = "Food and household items" 
//             };
            
//             // Add categories to context
//             await context.Categories.AddRangeAsync(electronics, groceries);
            
//             // Create products
//             var product1 = new Product 
//             { 
//                 Name = "Laptop", 
//                 Price = 75000, 
//                 StockQuantity = 10,
//                 Category = electronics 
//             };
            
//             var product2 = new Product 
//             { 
//                 Name = "Rice Bag", 
//                 Price = 1200, 
//                 StockQuantity = 50,
//                 Category = groceries 
//             };
            
//             var product3 = new Product 
//             { 
//                 Name = "Wireless Mouse", 
//                 Price = 2500, 
//                 StockQuantity = 25,
//                 Category = electronics 
//             };
            
//             var product4 = new Product 
//             { 
//                 Name = "Organic Honey", 
//                 Price = 450, 
//                 StockQuantity = 30,
//                 Category = groceries 
//             };
            
//             // Add products to context
//             await context.Products.AddRangeAsync(product1, product2, product3, product4);
            
//             // Save all changes to database
//             await context.SaveChangesAsync();
            
//             Console.WriteLine("Data inserted successfully!");
//             Console.WriteLine("\nInserted Categories:");
//             Console.WriteLine($"- {electronics.Name} (ID: {electronics.Id})");
//             Console.WriteLine($"- {groceries.Name} (ID: {groceries.Id})");
            
//             Console.WriteLine("\nInserted Products:");
//             Console.WriteLine($"- {product1.Name} - ₹{product1.Price} (ID: {product1.Id})");
//             Console.WriteLine($"- {product2.Name} - ₹{product2.Price} (ID: {product2.Id})");
//             Console.WriteLine($"- {product3.Name} - ₹{product3.Price} (ID: {product3.Id})");
//             Console.WriteLine($"- {product4.Name} - ₹{product4.Price} (ID: {product4.Id})");
//         }
//     }
// }




// To Run Lab-5

using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Retail Inventory System ===");
            Console.WriteLine("Lab 5: Retrieving Data from Database\n");
            
            using var context = new AppDbContext();
            
            // Ensure database and data exist
            await context.Database.EnsureCreatedAsync();
            await EnsureDataExistsAsync(context);
            
            // Lab 5 Operations
            await RetrieveAllProductsAsync(context);
            await FindProductByIdAsync(context);
            await FindExpensiveProductAsync(context);
            await FindProductsByCategoryAsync(context);
            await DisplayCategoryWithProductsAsync(context);
        }
        
        static async Task EnsureDataExistsAsync(AppDbContext context)
        {
            var count = await context.Products.CountAsync();
            if (count == 0)
            {
                Console.WriteLine("No data found. Inserting sample data...");
                
                var electronics = new Category { Name = "Electronics", Description = "Electronic devices" };
                var groceries = new Category { Name = "Groceries", Description = "Food items" };
                
                await context.Categories.AddRangeAsync(electronics, groceries);
                
                var products = new List<Product>
                {
                    new Product { Name = "Laptop", Price = 75000, StockQuantity = 10, Category = electronics },
                    new Product { Name = "Rice Bag", Price = 1200, StockQuantity = 50, Category = groceries },
                    new Product { Name = "Wireless Mouse", Price = 2500, StockQuantity = 25, Category = electronics },
                    new Product { Name = "Organic Honey", Price = 450, StockQuantity = 30, Category = groceries }
                };
                
                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
                Console.WriteLine("Sample data inserted.\n");
            }
        }
        
        // 1. Retrieve All Products
        static async Task RetrieveAllProductsAsync(AppDbContext context)
        {
            Console.WriteLine("=== 1. RETRIEVE ALL PRODUCTS ===");
            
            var products = await context.Products
                .Include(p => p.Category)  // Include related category data
                .ToListAsync();
            
            Console.WriteLine($"Total products found: {products.Count}");
            Console.WriteLine($"{"Name",-15} {"Price",-10} {"Stock",-8} {"Category",-12}");
            Console.WriteLine(new string('-', 50));
            
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name,-15} ₹{p.Price,-9} {p.StockQuantity,-8} {p.Category.Name,-12}");
            }
            Console.WriteLine();
        }
        
        // 2. Find Product by ID
        static async Task FindProductByIdAsync(AppDbContext context)
        {
            Console.WriteLine("=== 2. FIND PRODUCT BY ID ===");
            
            // Find product with ID 1
            var product = await context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == 1);
            
            if (product != null)
            {
                Console.WriteLine($"Product found:");
                Console.WriteLine($"ID: {product.Id}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: ₹{product.Price}");
                Console.WriteLine($"Stock: {product.StockQuantity}");
                Console.WriteLine($"Category: {product.Category.Name}");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
            Console.WriteLine();
        }
        
        // 3. Find Expensive Products
        static async Task FindExpensiveProductAsync(AppDbContext context)
        {
            Console.WriteLine("=== 3. FIND EXPENSIVE PRODUCTS ===");
            
            // Find products above ₹50000
            var expensive = await context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Price > 50000);
            
            if (expensive != null)
            {
                Console.WriteLine($"Expensive product found:");
                Console.WriteLine($"Name: {expensive.Name}");
                Console.WriteLine($"Price: ₹{expensive.Price}");
                Console.WriteLine($"Category: {expensive.Category.Name}");
            }
            else
            {
                Console.WriteLine("No expensive products found!");
            }
            Console.WriteLine();
        }
        
        // 4. Find Products by Category
        static async Task FindProductsByCategoryAsync(AppDbContext context)
        {
            Console.WriteLine("=== 4. FIND PRODUCTS BY CATEGORY ===");
            
            // Find all electronics products
            var electronicsProducts = await context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Name == "Electronics")
                .ToListAsync();
            
            Console.WriteLine($"Electronics products ({electronicsProducts.Count}):");
            foreach (var product in electronicsProducts)
            {
                Console.WriteLine($"- {product.Name} - ₹{product.Price}");
            }
            Console.WriteLine();
        }
        
        // 5. Display Categories with Product Count
        static async Task DisplayCategoryWithProductsAsync(AppDbContext context)
        {
            Console.WriteLine("=== 5. CATEGORIES WITH PRODUCT COUNT ===");
            
            var categories = await context.Categories
                .Include(c => c.Products)
                .ToListAsync();
            
            Console.WriteLine($"{"Category",-15} {"Products Count",-15}");
            Console.WriteLine(new string('-', 35));
            
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Name,-15} {category.Products.Count,-15}");
            }
            Console.WriteLine();
        }
    }
}