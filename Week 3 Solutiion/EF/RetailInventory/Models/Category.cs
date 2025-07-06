using System.ComponentModel.DataAnnotations;

namespace RetailInventory.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        // Navigation property - One category has many products
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}