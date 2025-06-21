using System;
using System.Linq;
using System.Diagnostics;

namespace ECommerceSearchSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== E-COMMERCE SEARCH FUNCTIONALITY ===\n");

            // Sample data
            var products = GenerateProductData();
            var sortedProducts = products.OrderBy(p => p.ProductName).ToArray();

            // Demonstrate search scenarios
            DemonstrateSearchScenarios(products, sortedProducts);

            // Performance analysis
            PerformanceAnalysis(products, sortedProducts);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static Product[] GenerateProductData()
        {
            return new Product[]
            {
                new Product(1, "Apple iPhone 14", "Electronics"),
                new Product(2, "Samsung Galaxy S23", "Electronics"),
                new Product(3, "Dell Laptop", "Computers"),
                new Product(4, "Nike Running Shoes", "Sports"),
                new Product(5, "Adidas T-Shirt", "Clothing"),
                new Product(6, "Sony Headphones", "Electronics"),
                new Product(7, "HP Printer", "Office"),
                new Product(8, "Canon Camera", "Electronics"),
                new Product(9, "Puma Sneakers", "Sports"),
                new Product(10, "Levi's Jeans", "Clothing"),
                new Product(11, "Microsoft Surface", "Computers"),
                new Product(12, "Bose Speaker", "Electronics"),
                new Product(13, "Under Armour Hoodie", "Clothing"),
                new Product(14, "Logitech Mouse", "Computers"),
                new Product(15, "Apple Watch", "Electronics"),
                new Product(16, "Reebok Training Shoes", "Sports"),
                new Product(17, "Epson Scanner", "Office"),
                new Product(18, "JBL Earbuds", "Electronics"),
                new Product(19, "Champion Shorts", "Clothing"),
                new Product(20, "Acer Monitor", "Computers")
            };
        }

        static void DemonstrateSearchScenarios(Product[] products, Product[] sortedProducts)
        {
            Console.WriteLine("=== SEARCH DEMONSTRATIONS ===");

            // Linear search
            var linearResults = SearchEngine.LinearSearchByName(products, "iPhone");
            Console.WriteLine("Linear Search for 'iPhone':");
            foreach (var product in linearResults)
                Console.WriteLine($"  Found: {product}");

            // Binary search (exact)
            var binaryResult = SearchEngine.BinarySearchByName(sortedProducts, "Apple iPhone 14");
            Console.WriteLine("\nBinary Search for 'Apple iPhone 14':");
            if (binaryResult != null)
                Console.WriteLine($"  Found: {binaryResult}");
            else
                Console.WriteLine("  Not found");

            // Linear search by category
            var electronics = products.Where(p => p.Category.Equals("Electronics", StringComparison.OrdinalIgnoreCase)).ToList();
            Console.WriteLine("\nLinear Search for 'Electronics' category:");
            foreach (var product in electronics)
                Console.WriteLine($"  - {product}");
        }

        static void PerformanceAnalysis(Product[] products, Product[] sortedProducts)
        {
            Console.WriteLine("\n=== PERFORMANCE ANALYSIS ===");
            string[] searchTerms = { "Apple", "Samsung", "Nike", "Electronics" };

            foreach (var term in searchTerms)
            {
                var stopwatch = new Stopwatch();

                // Linear search
                stopwatch.Start();
                var linearResults = SearchEngine.LinearSearchByName(products, term);
                stopwatch.Stop();
                var linearTime = stopwatch.ElapsedTicks;

                // Binary search
                stopwatch.Restart();
                var binaryResult = SearchEngine.BinarySearchByName(sortedProducts, term);
                stopwatch.Stop();
                var binaryTime = stopwatch.ElapsedTicks;

                Console.WriteLine($"\nSearch Term: '{term}'");
                Console.WriteLine($"Linear Search: {linearTime} ticks, Results: {linearResults.Count}");
                Console.WriteLine($"Binary Search: {binaryTime} ticks, Result: {(binaryResult != null ? 1 : 0)}");
                if (binaryTime > 0)
                    Console.WriteLine($"Binary Search is {(double)linearTime / binaryTime:F2}x faster than Linear Search");
            }
        }
    }
}
