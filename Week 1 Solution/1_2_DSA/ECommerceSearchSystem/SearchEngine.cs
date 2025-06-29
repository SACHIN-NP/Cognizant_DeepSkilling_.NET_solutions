using System;
using System.Collections.Generic;

namespace ECommerceSearchSystem
{
    public static class SearchEngine
    {
        // Linear search: O(n)
        public static List<Product> LinearSearchByName(Product[] products, string searchTerm)
        {
            var results = new List<Product>();
            foreach (var product in products)
            {
                if (product.ProductName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    results.Add(product);
            }
            return results;
        }

        // Binary search: O(log n), for exact match
        public static Product BinarySearchByName(Product[] sortedProducts, string exactName)
        {
            int left = 0, right = sortedProducts.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int cmp = string.Compare(sortedProducts[mid].ProductName, exactName, StringComparison.OrdinalIgnoreCase);
                if (cmp == 0) return sortedProducts[mid];
                if (cmp < 0) left = mid + 1;
                else right = mid - 1;
            }
            return null;
        }

        // Binary search for partial matches (returns all matches)
        public static List<Product> BinarySearchPartialMatch(Product[] sortedProducts, string searchTerm)
        {
            var results = new List<Product>();
            int left = 0, right = sortedProducts.Length - 1;
            int firstMatch = -1;

            // Find the first matching index
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (sortedProducts[mid].ProductName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    firstMatch = mid;
                    right = mid - 1;
                }
                else if (string.Compare(sortedProducts[mid].ProductName, searchTerm, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            // Collect all subsequent matches
            if (firstMatch != -1)
            {
                for (int i = firstMatch; i < sortedProducts.Length; i++)
                {
                    if (sortedProducts[i].ProductName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                        results.Add(sortedProducts[i]);
                    else
                        break;
                }
            }
            return results;
        }
    }
}
